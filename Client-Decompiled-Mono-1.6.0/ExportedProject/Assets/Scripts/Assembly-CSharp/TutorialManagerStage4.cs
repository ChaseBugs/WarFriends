using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class TutorialManagerStage4 : TutorialManagerBase
{
	private sealed class LIMNGFDOBNO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int ICDIPDJOMKO;

		internal float IKAKODPFHAC;

		internal bool PBEIEFKCHPN;

		internal bool PKBPMHOAGMI;

		internal string MMNDGIHINGF;

		internal Vector3 JFOMIIDCEKM;

		internal Transform JFCIFNAPAOC;

		internal WeaponGuiRecord APHENMOFJJP;

		internal WeaponGuiRecord CADIPBGKAKK;

		internal Vector3 DNHJMCLEGAB;

		internal Vector3 KIPCNCCJDNC;

		internal List<WeaponGuiRecord>.Enumerator KFCAECGLKKO;

		internal Vector3 DHEGKFCAAGP;

		internal bool ELPHLDJPBNJ;

		internal bool PECMCAOEMND;

		internal bool AHHEMONLINF;

		internal TutorialManagerStage4 BJGCPDNMHDH;

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

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void IBLNBELFKNF()
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

		public void IKGBMDKKAPA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void GGLMLMFEJCD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MPLPDIGFPBH()
		{
			throw new NotSupportedException();
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KLECLPIKEJK()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ENENMOAOOBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("N");
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
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
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
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("CardTrade_Withdraw"), Localization.Localize("Everyplay Exception: "), 960f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, false, 858f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Special pack \"{0}\" already in offer manager cache.");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1355f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("()Z", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("Different names \"{0}\" and \"{1}\"\n"), Localization.Localize("game-card-ico-disarmed"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 854f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, false, 914f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 662f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 117f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.DMNHLHOBANG() : 18);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("xmas"), Localization.Localize("ID_TOBENUMBERONE1"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 924f, TutorialDialog.DODBDLEJOAM.BottomRight);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 98;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array3 = new object[0];
					array3[0] = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("205 STAGE 6 GRENADE SELECTED", array3);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 526f, TutorialDialog.DODBDLEJOAM.TopRight);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 304f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, false, true, 486f);
					GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 53;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(899f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_WAITINGFOROPPONENTCARDS", 582f, TutorialDialog.DODBDLEJOAM.TopLeft);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.CJAIGEJNDOH().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, false, 1087f);
							GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("Gold");
				object[] array4 = new object[1];
				array4[1] = Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT");
				instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("Squad Member record does not have DatabasePlayer", array4), 1336f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1410f, 1428f, 1791f), false, true, 994f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -125;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("grenadeExplosion");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1843f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1436f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -14;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ServerPrice");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("Measure Event With Event Items");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE", array2), 1432f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(649f, 1627f, 768f), true, false, 191f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("false"), Localization.LocalizeFormat("ID_LOADING", Localization.Localize("getGameConfigurationValue")), 1697f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(703f, 1489f, 268f), true, true, 43f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			case 17u:
				if (APHENMOFJJP.ADOICOAEIFA().weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					if (PECMCAOEMND && APHENMOFJJP.EAJJDMMGMKK().weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(807f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(739f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 105;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Country", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1016f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].NLBHEBNFBFN() != APHENMOFJJP.OFABMGFOFPI())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1339f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 118;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_COOPCANCELED");
				object[] array = new object[0];
				array[0] = Localization.Localize("Tier");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("count", array), 145f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, false, true, 53f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].IDMPHABHMGI() != APHENMOFJJP.NGOGADPALJO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 73;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1943f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.GMEFFFKMDCE().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 81;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1554f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("null", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1997f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 66;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("ID_EVENTSTARTSINSMALL", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(679f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -11;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.ADOICOAEIFA().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(418f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -117;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 85;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(658f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return false;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.LOKBALDOPIK();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Gold");
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
						CLPPIAGLCJJ = 3;
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
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ID_AFFECTEDOWNUNITS"), Localization.Localize("Shots_Hits"), 1295f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, false, 239f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("213 MENU ARMY SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(231f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_WARNING_INCORRECTASSIGNMENTS_TEXT", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("EliminateUnits"), Localization.Localize("menu-cards-bronzepack"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1846f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, false, 454f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
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
				IKAKODPFHAC = 791f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 437f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.PCAMHGKJOKM() : 28);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("ID_DOWNLOADING_CONFIGURATIONS"), Localization.Localize("ID_WARCARDSARESPECIALBONUSES"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 731f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -33;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array4 = new object[1];
					array4[1] = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("getCustomProfileGeolocation", array4);
					GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB(MMNDGIHINGF, 831f, TutorialDialog.DODBDLEJOAM.Left);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 212f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, false, false, 825f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -111;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(356f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("Level", 828f, TutorialDialog.DODBDLEJOAM.TopRight);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.OFABMGFOFPI().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, false, 1496f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("_"), Localization.LocalizeFormat("DeviceLogin(", Localization.Localize("SquadMates")), 424f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(748f, 1651f, 601f), true, true, 922f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -119;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("MyGolds");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(522f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(34f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 90;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize(" & ");
				object[] array3 = new object[1];
				array3[1] = Localization.Localize("HeroicReward");
				instance3.PBEAOCBHFGD(aMKLKMJEMJM3, Localization.LocalizeFormat("Drone", array3), 1678f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(776f, 1222f, 1685f), true, false, 407f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("\tTotal wins: {0}/{1}");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("D2");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("PNManager: registration failed: ", array2), 728f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1878f, 565f, 577f), false, false, 1827f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.CJAIGEJNDOH().weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
				{
					if (PECMCAOEMND && APHENMOFJJP.weaponSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1796f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(306f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 67;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("RealMoney", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(53f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].INHNFHEMNFF() != APHENMOFJJP.NGOGADPALJO())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1656f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -80;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("veteranpack0");
				object[] array = new object[0];
				array[0] = Localization.Localize("ItemsOwned_Rarity_3");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("http://localhost:3000/socket.io/", array), 1794f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 78f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].PMJFFNLKKLB() != APHENMOFJJP.GMEFFFKMDCE())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1129f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.NGOGADPALJO().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -95;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1917f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("Days_Since_Install", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1304f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -102;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("AA:BB:CC:DD:EE:FF", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(971f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 45;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.NGOGADPALJO().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(768f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 113;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -103;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("_GrassWind");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1700f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		[SpecialName]
		private object HJHFKNCBGDG()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
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
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.LOKBALDOPIK();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Try out: Equipping weapon \"{0}\" instead of weapon \"{1}\"");
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
				if (!GuiScreenSingle<MainScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("shield_unhide"), Localization.Localize("Reason"), 1422f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, false, 271f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("bronze");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1105f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("'", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize("fr"), Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1486f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, false, 275f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 315f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1050f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.PIIFMLHFAAE() : 135);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("Rule Record For Height"), Localization.Localize("Grenade_Throwing_Tutorial_Duration"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1650f, TutorialDialog.DODBDLEJOAM.BottomRight);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -107;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					object[] array4 = new object[1];
					array4[1] = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("A", array4);
					GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF(MMNDGIHINGF, 1940f, TutorialDialog.DODBDLEJOAM.Left);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1247f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, true, true, 1036f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(837f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("speed", 1413f, TutorialDialog.DODBDLEJOAM.BottomRight);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.EAJJDMMGMKK().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, true, 105f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance4 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM4 = Localization.Localize("#PETER# Removing squad left message - message time:{0}, server time:{1}, isInSquad:{2}");
				object[] array5 = new object[0];
				array5[1] = Localization.Localize("currentActivity");
				instance4.DOLDLDECPIO(aMKLKMJEMJM4, Localization.LocalizeFormat("com/google/android/gms/common/ConnectionResult", array5), 1448f, TutorialDialog.DODBDLEJOAM.BottomLeft, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1449f, 192f, 1187f), false, true, 1810f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_CONFIRM_CONNECTTOGOOGLENAMETEXT");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1277f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(474f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -21;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("Starter_Assignment_Completed");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("ArmyPower");
				instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("0", array3), 1906f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1433f, 996f, 1572f), true, true, 471f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("game-card-ico-paralyzethese");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("ArmyPower", array2), 1872f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1913f, 160f, 416f), true, false, 746f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && APHENMOFJJP.PMIIPNOJFLF().weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(203f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(135f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 119;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("withAttribute2", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(977f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].DLNNBFIIJPA() != APHENMOFJJP.weaponSetup)
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(766f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -126;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("http://www.imgawards.com/wp-content/uploads/2015/12/Cover-Winter_WarFriends.png");
				object[] array = new object[0];
				array[0] = Localization.Localize("menu-medals-ico-small");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("ID_CONFIRM_NOSQUADACTIONS_TEXT", array), 1405f, TutorialDialog.DODBDLEJOAM.Left, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, false, true, 1937f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ, false);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].INHNFHEMNFF() != APHENMOFJJP.ADOICOAEIFA())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 126;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(243f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.NGOGADPALJO().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -116;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1466f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("ID_TIERSCOMPLETED", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1194f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -107;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("Title", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(652f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 108;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.ADOICOAEIFA().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1496f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -39;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -87;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ID_");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1729f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return true;
		}

		[SpecialName]
		private object KDLMIDIEPHD()
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
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.OILMPBGNNBD();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Generate army 2");
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
				if (!GuiScreenSingle<MainScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("Card_2_Played"), Localization.Localize("ID_GETFREEGOLD"), 1422f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, false, 93f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("id");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(487f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("), ", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("{0}{1}"), Localization.Localize("[^\\d]"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1740f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 504f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 1698f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 903f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.HBHAGIGNGKD() : 95);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("LeagueEntered"), Localization.Localize("rifle_shot_loop"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1755f);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -11;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					object[] array3 = new object[0];
					array3[1] = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("SuggestedSquad", array3);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 1589f, TutorialDialog.DODBDLEJOAM.Top);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 180f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, true, false, 689f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -100;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(126f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("width", 1147f, TutorialDialog.DODBDLEJOAM.Right);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.GMEFFFKMDCE().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, true, true, 1176f);
							GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("FacebookManagerOnSessionOpenedEvent"), Localization.LocalizeFormat("ID_SKULL", Localization.Localize("ID_CONFIRM_ERROR")), 123f, TutorialDialog.DODBDLEJOAM.Top);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1558f, 788f, 1179f), false, false, 1239f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 81;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Player_Avoided_Grenade_On_First_Try");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1529f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(677f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -14;
				}
				break;
			case 15u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("ID_TUTORIAL_DELIVER"), Localization.LocalizeFormat("newHeroicPoints", Localization.Localize("ChatClient: ")), 1988f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(66f, 1053f, 291f), true, true, 494f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = false;
				goto case 17u;
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("flawless");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("ID_CONFIRM_SERVERERROR");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("menu-squad-1", array2), 1584f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1293f, 1744f, 1931f), false, true, 488f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.OFABMGFOFPI().weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered)
				{
					if (PECMCAOEMND && APHENMOFJJP.OFABMGFOFPI().weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1247f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1618f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 64;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_FRIENDREFUSEDREMATCHCOOP", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(456f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].KBCDILLLFIJ() != APHENMOFJJP.OFABMGFOFPI())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(931f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 45;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
				object[] array = new object[0];
				array[1] = Localization.Localize("id");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("Awaiting players - Player id:\"{0}\" is not in list of awaiting members", array), 1944f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 1194f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].weaponLevelsSetup != APHENMOFJJP.OFABMGFOFPI())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -35;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(977f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.EAJJDMMGMKK().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 38;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(415f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("ID_CHANGINGLANGUAGE", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1947f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -38;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("ID_ARENARULES_FIXEDSPAWNING", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1210f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 127;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.GMEFFFKMDCE().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(741f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 69;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -31;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("tickets");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(662f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return false;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void INBELBGOCLD()
		{
			throw new NotSupportedException();
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
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
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("401 START");
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
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_1"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_2"), 0.1f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("402 MENU BATTLE SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("WeaponTutorial", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 0.3f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 0f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 20f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.upgradePrice : 500);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 0.3f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 9;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					MMNDGIHINGF = Localization.LocalizeFormat("ID_TUTORIAL_UPGRADEWEAPON_5", GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 0.25f);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 0.5f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 10;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("ID_TUTORIAL_UPGRADEWEAPON_6", 0.25f);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.weaponSetup.KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_7"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_UPGRADE")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 14;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("405 MENU WEAPON SCREEN BUY UPGRADE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 15;
				}
				break;
			case 15u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_8"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_DELIVERNOW")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = true;
				goto case 17u;
			case 16u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_9"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_ACTIVATION")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(40f, -56f, 0f));
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			case 17u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Active)
				{
					if (PECMCAOEMND && APHENMOFJJP.weaponSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
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
							CLPPIAGLCJJ = 16;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("406 MENU WEAPON SCREEN UPGRADE ACTIVATED", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].weaponLevelsSetup != APHENMOFJJP.weaponSetup)
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1.1f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 18;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_10"), Localization.LocalizeFormat("ID_TUTORIAL_TAPON", Localization.Localize("ID_GUI_EQUIP")), 0.6f, TutorialDialog.DODBDLEJOAM.BottomLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ, false);
				goto case 19u;
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].weaponLevelsSetup != APHENMOFJJP.weaponSetup)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 19;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
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
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("407 MENU WEAPON SCREEN WEAPON EQUIPPED", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(2.8f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 20;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("404 MENU WEAPON SCREEN SELECT WEAPON", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 13;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(0.5f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 11;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 17;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("403 MENU WEAPON SCREEN SHOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide();
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.ANLNFNOJNDF();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Action ");
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
						CLPPIAGLCJJ = 3;
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
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("squad"), Localization.Localize("ID_SLOTUPGRADE_AMMO"), 699f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 1638f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GameLoginManager: Invite Facebook Friends");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1655f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("Id", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.EOPPCIEONEG(Localization.Localize("ID_STAT_BESTACCURACY"), Localization.Localize("ID_FB_LOGIN_TUTORIAL_TEXT"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1738f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 1329f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 648f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1452f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.HBHAGIGNGKD() : 193);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("Swipe Raycasts End FAILED!"), Localization.Localize("{0} / {1}"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1415f, TutorialDialog.DODBDLEJOAM.Left);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -105;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					MMNDGIHINGF = Localization.LocalizeFormat("HELMETS", GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF(MMNDGIHINGF, 1190f, TutorialDialog.DODBDLEJOAM.BottomLeft);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1522f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, false, false, 1352f);
					GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -22;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1294f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("NULL", 179f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.EAJJDMMGMKK().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, true, true, 1454f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize(" Special ");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("Corrected squad name for current player");
				instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("WarCards", array3), 1805f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1146f, 1838f, 587f), false, false, 424f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.ADOICOAEIFA().weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -112;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("YES");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1049f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1414f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 96;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("WarbucksBalance");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("AdminPlayerId");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_SIGNOUT", array2), 874f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1470f, 788f, 881f), true, false, 156f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("UnitID"), Localization.LocalizeFormat("AssignmentId", Localization.Localize("ID_SALEPERCENTLINE")), 699f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(749f, 1199f, 1843f), false, false, 1594f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			case 17u:
				if (APHENMOFJJP.CJAIGEJNDOH().weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering)
				{
					if (PECMCAOEMND && APHENMOFJJP.CJAIGEJNDOH().weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(1884f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1130f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -40;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("\\D*", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1623f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].PMJFFNLKKLB() != APHENMOFJJP.OFABMGFOFPI())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1338f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -107;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("EventAssignmentUpdate");
				object[] array = new object[0];
				array[0] = Localization.Localize("ShieldRechargeRate");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = ", array), 349f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, false, 314f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].HHMKPPOAOBJ() != APHENMOFJJP.OFABMGFOFPI())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -13;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1292f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.EAJJDMMGMKK().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.EIDNJNBEPFI(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -126;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1119f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("No main position was set in map definition", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1777f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 70;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("registerForPushNotifications", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(584f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 40;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.CJAIGEJNDOH().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1651f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 75;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 106;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_GRENADELAUNCHERKILLS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1795f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return false;
		}

		[DebuggerHidden]
		public LIMNGFDOBNO()
		{
		}

		[SpecialName]
		private object ADNCCLOOEAD()
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
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.LOKBALDOPIK();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("ID_BUDDYCARD");
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
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
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
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("saved obtained cards: "), Localization.Localize("WarFriends richiede l'autorizzazione alla memorizzazione multimediale per scaricare dati fondamentali per il gioco.Accetta la finestra di dialogo di autorizzazione che verrà visualizzata. Non useremo questa autorizzazione per altri scopi."), 400f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, true, 1998f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GameLauncher.Async done");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(827f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_STATE_CONNECTINGTOSERVER", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("ID_SALEPERCENTLINE"), Localization.Localize("NULL"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 341f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 60f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 1728f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 809f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.IMCENIMADBD() : (-186));
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_ARENABOXDESCRIPTION_WARBUCKS"), Localization.Localize("game-card-ico-disarmed"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1912f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 96;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array3 = new object[1];
					array3[1] = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("warfriends-qa.eu-west-1.elasticbeanstalk.com/", array3);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 993f, TutorialDialog.DODBDLEJOAM.Right);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1799f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, true, false, 1164f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -6;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(991f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("WarCards", 1765f);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.GMEFFFKMDCE().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, false, false, 244f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("GameController.Start DONE"), Localization.LocalizeFormat("AtlasPreparer.LoadTutorialCoroutine", Localization.Localize("), ")), 1466f);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(612f, 1937f, 584f), true, true, 216f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 69;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Level");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(424f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1377f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("Friend");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize(", interval = ");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat(",", array2), 715f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(189f, 96f, 1360f), false, false, 761f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("squadMembers"), Localization.LocalizeFormat("WebPlayer", Localization.Localize("Found labels with dynamic font in children:\n")), 1710f, TutorialDialog.DODBDLEJOAM.Left, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1874f, 1404f, 65f), false, false, 711f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			case 17u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && APHENMOFJJP.EAJJDMMGMKK().weaponState == (WeaponLevelsSetup.JLANLLEABDC)8)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(721f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1340f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 102;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("202 GAME STARTED", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(798f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].CKJOBHNNFAM() != APHENMOFJJP.ADOICOAEIFA())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(621f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 36;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Status");
				object[] array = new object[0];
				array[0] = Localization.Localize("T");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("com/google/android/gms/common/ConnectionResult", array), 713f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 1995f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ENBMDAIKKMM() != APHENMOFJJP.EAJJDMMGMKK())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(584f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.ADOICOAEIFA().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 124;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(957f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("#PETER# NOTIFICATION CENTER - Add message ", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1268f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 119;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("N", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(931f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -96;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.NGOGADPALJO().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1356f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 86;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 75;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("discount");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(741f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return false;
		}

		public bool ILNBJIJONKD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.MNDIJBOCFPM();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Get Experiment Details clicked");
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
						CLPPIAGLCJJ = 3;
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
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("warbucks"), Localization.Localize("ID_HEADERMAXCHAR"), 784f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, true, 1613f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_GOLDENLOOTBOXSMALL");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(368f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("game-card-ico-shielddestroyer", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("ShowRope"), Localization.Localize("Scripts"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 691f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, true, 187f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 860f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 219f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.upgradePrice : 176);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("game-card-ico-paralyzethese"), Localization.Localize("ServerErrorHandler: squadCreationsCount = "), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 715f, TutorialDialog.DODBDLEJOAM.TopRight);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					MMNDGIHINGF = Localization.LocalizeFormat("{0} {1}", GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 1148f, TutorialDialog.DODBDLEJOAM.BottomLeft);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1929f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, true, false, 1724f);
					GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 117;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(461f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("ID_LOADING", 310f, TutorialDialog.DODBDLEJOAM.BottomRight);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.CJAIGEJNDOH().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, false, true, 1747f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance4 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM4 = Localization.Localize("registerCustomProfileDate");
				object[] array4 = new object[0];
				array4[0] = Localization.Localize("bot-");
				instance4.PBEAOCBHFGD(aMKLKMJEMJM4, Localization.LocalizeFormat(")", array4), 1894f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1815f, 223f, 1686f), false, false, 1932f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -65;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_EARLYUNLOCK2");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1213f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1491f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 30;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("Client threw exception while trying to react to error response from the server.");
				object[] array3 = new object[1];
				array3[1] = Localization.Localize("ID_YOUNEEDXTICKETSFOREXTRAHEART");
				instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("ID_STAT_SQUADWARSWINS", array3), 1535f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1742f, 1795f, 90f), false, false, 585f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("SkillRequirement");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("CardsInCardPack");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("Finish game network", array2), 430f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1330f, 1496f, 785f), false, true, 1690f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.OFABMGFOFPI().weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering)
				{
					if (PECMCAOEMND && APHENMOFJJP.CJAIGEJNDOH().weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1462f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1096f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 65;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Manual_Unit_Spawn", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(877f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].BHDJIJGIHCL() != APHENMOFJJP.GMEFFFKMDCE())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1453f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -33;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ExpiresOn");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("PowerBandId", array), 783f, TutorialDialog.DODBDLEJOAM.Top, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 1809f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].LMPIDJLMPLG() != APHENMOFJJP.PMIIPNOJFLF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(449f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.EAJJDMMGMKK().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -109;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(806f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("\t\"TRUE\"", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1862f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent(" on close show player dialog for ", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(750f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -61;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.GMEFFFKMDCE().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1437f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 104;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -99;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("RETRYPERM");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1470f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return false;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LGDOCMENCOG()
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
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.PAMBHKIFKAP();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent(" TOTAL MEMORY (GC): ");
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
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
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
				if (!GuiScreenSingle<MainScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("PACK"), Localization.Localize("country-indonesia"), 1116f, TutorialDialog.DODBDLEJOAM.Left, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 1523f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Data");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1585f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("AdWillClose()", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("_MatCap"), Localization.Localize("====== Connecting to region: "), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1150f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, false, 977f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 834f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1541f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.PIIFMLHFAAE() : 194);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.EOPPCIEONEG(Localization.Localize("VIP - {0}\n"), Localization.Localize("ID_ARENARULES_RANDOMWEAPONS"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1471f, TutorialDialog.DODBDLEJOAM.TopRight);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 89;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					MMNDGIHINGF = Localization.LocalizeFormat("Exception message: ", GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD(MMNDGIHINGF, 252f, TutorialDialog.DODBDLEJOAM.TopLeft);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 742f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, false, false, 854f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -58;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1905f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("lapsed_player_2", 1399f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.ADOICOAEIFA().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, false, false, 1822f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("Gold");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("x{0}");
				instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("{0}{1}", array3), 1665f);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(565f, 1074f, 1360f), true, true, 1085f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 106;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_OFFERACTIVE");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(120f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(937f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("null");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("ID_GOLDSMALL");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("N", array2), 1772f, TutorialDialog.DODBDLEJOAM.BottomLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1045f, 1562f, 1943f), true, true, 1529f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Play_Card_Tutorial_Duration"), Localization.LocalizeFormat("Days_Since_Install", Localization.Localize("ID_BOSS")), 1258f, TutorialDialog.DODBDLEJOAM.Top, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(597f, 1049f, 1862f), true, false, 694f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			case 17u:
				if (APHENMOFJJP.GMEFFFKMDCE().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && APHENMOFJJP.NGOGADPALJO().weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
						GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(858f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1279f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 72;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Refresh_Skirmish", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1654f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ALEBNFNFOEP() != APHENMOFJJP.GMEFFFKMDCE())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(155f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -75;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Yes_Clicked");
				object[] array = new object[0];
				array[1] = Localization.Localize("dataEnabled");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("N", array), 861f, TutorialDialog.DODBDLEJOAM.BottomLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, false, true, 1034f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].JCPKCKIHFBI() != APHENMOFJJP.PMIIPNOJFLF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 105;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1703f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.PMIIPNOJFLF().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -26;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(466f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("ID_CONFIRM_SQUADLEAVEERROR", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(413f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 62;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB(")", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1637f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -12;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				if (APHENMOFJJP.OFABMGFOFPI().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(747f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -57;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 12;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_RENTAL_GRENADELAUNCHER");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1103f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void LFOLGBNBBAG()
		{
			throw new NotSupportedException();
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("ID_TRYFORFREE");
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
						CLPPIAGLCJJ = 8;
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
				if (!GuiScreenSingle<MainScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("no player Id found"), Localization.Localize("ID_CLOSESIN"), 1184f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, false, 574f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Assignment: Handled: \nId:{0} isSquadEvent:{1} secondParameter:{2} levelProgress:{3}\n");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(711f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize(" finished"), Localization.Localize("squadMembers"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1705f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, true, 539f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
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
				IKAKODPFHAC = 1505f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1511f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.ABFHNCJEOAA() : 29);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("hearthPrice"), Localization.Localize("Number"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 794f, TutorialDialog.DODBDLEJOAM.Top);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 31;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					MMNDGIHINGF = Localization.LocalizeFormat("Directory \"{0}\" does not exists", GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.ShowSpecial(MMNDGIHINGF, 1605f, TutorialDialog.DODBDLEJOAM.Right);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 236f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, false, false, 396f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -89;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(331f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF("Daily_Reward_Claimed", 1279f, TutorialDialog.DODBDLEJOAM.Right);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.CJAIGEJNDOH().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, true, true, 1327f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("ID_GUI_INVITETOSQUAD");
				object[] array3 = new object[1];
				array3[1] = Localization.Localize("elite");
				instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("vipExpire", array3), 837f, TutorialDialog.DODBDLEJOAM.TopLeft);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(81f, 153f, 1716f), false, true, 323f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 118;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_STAT_WINS");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(588f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(721f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 10;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("Beanstalk: Dev access unlocked");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("BoobyTrapSetRPC");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("Exception message: ", array2), 455f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1094f, 1019f, 53f), false, false, 484f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_WARSHOP_CARDPACKS");
				object[] array = new object[0];
				array[1] = Localization.Localize("Metal");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Reward", array), 928f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(878f, 1683f, 1962f), true, true, 818f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					if (PECMCAOEMND && APHENMOFJJP.weaponSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(975f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(690f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 67;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("isSuccess", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(25f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].MOGCFBHKAFO() != APHENMOFJJP.EAJJDMMGMKK())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1535f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 65;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("audio/game0"), Localization.LocalizeFormat("game-card-ico-swiftimmortality", Localization.Localize("{0} Emblem {1} LVL {2}")), 1660f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, false, true, 824f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].JGDAEBDGJBM() != APHENMOFJJP.EAJJDMMGMKK())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -107;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1922f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.PMIIPNOJFLF().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -28;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(267f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("ID_TUTORIAL_GO_BUY_ARMY_2_DOWN", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1565f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 25;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("SetCurrentPoint", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(451f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.PMIIPNOJFLF().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(1982f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 86;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 72;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("S");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(920f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return false;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public bool LDINGGNOLKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.ANLNFNOJNDF();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("SetHitByUnit , ");
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
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("ExplodeRPC"), Localization.Localize("com.chillingo.warfriends.android.gplay.localpersistencemanager.LocalPersistenceManager"), 1082f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, false, 241f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("BUDDY WARCARD");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(689f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("#Mission# New Wawe comming", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize("ID_YOUVEENTEREDALEAGUE"), Localization.Localize("ID_SAVEPERCENTLINE"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 194f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, false, 1006f);
				GuiElementSingle<TutorialClickOverlay>.instance.FCGLGPIBAEN(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = true;
				IKAKODPFHAC = 154f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 15f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.upgradePrice : (-17));
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("AtlasPreparer.LoadImagesCoroutine"), Localization.Localize("FriendsListError("), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 437f, TutorialDialog.DODBDLEJOAM.TopLeft);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -51;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array4 = new object[0];
					array4[0] = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("IsRestore", array4);
					GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM(MMNDGIHINGF, 893f);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1377f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, false, true, 648f);
					GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -110;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(571f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM(".", 1271f, TutorialDialog.DODBDLEJOAM.TopRight);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.weaponSetup.KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, false, false, 1638f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance4 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM4 = Localization.Localize("DogTagRefillTime");
				object[] array5 = new object[0];
				array5[1] = Localization.Localize("eventEnd");
				instance4.ShowMenuTutorial(aMKLKMJEMJM4, Localization.LocalizeFormat("#VOJTA# Tutorial state of current player account type: FB connect: ", array5), 230f, TutorialDialog.DODBDLEJOAM.Top);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1789f, 1527f, 522f), false, true, 1175f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.OFABMGFOFPI().weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -102;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_TUTORIAL_PLAY_CARD_DOWN");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(994f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(415f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -82;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("S");
				object[] array3 = new object[1];
				array3[1] = Localization.Localize("hashCode");
				instance3.ShowMenuTutorial(aMKLKMJEMJM3, Localization.LocalizeFormat("ID_UNITTYPE2", array3), 221f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(493f, 1714f, 751f), true, false, 1678f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_ROUNDREWARD");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("ID_OPPONENTREFUSEDTHEREMATCH");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("ID_RANDOMWARCARDCRAFTINGINPROGRESS", array2), 1970f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1109f, 1049f, 48f), true, false, 805f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.ADOICOAEIFA().weaponState != WeaponLevelsSetup.JLANLLEABDC.Active)
				{
					if (PECMCAOEMND && APHENMOFJJP.ADOICOAEIFA().weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1332f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(276f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -72;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Regions", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1956f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].MJOAIHHAPFG() != APHENMOFJJP.CJAIGEJNDOH())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(606f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -7;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Start TimeLock: ");
				object[] array = new object[1];
				array[1] = Localization.Localize("ID_VISUALCATEGORY2");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("ID_ARENASTARTSTIMER", array), 1024f, TutorialDialog.DODBDLEJOAM.Top, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 1357f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].KBCDILLLFIJ() != APHENMOFJJP.weaponSetup)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -57;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1285f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.PMIIPNOJFLF().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(16f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("-{0}%", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(517f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 23;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("#Mission Rewards# 5 Heroic Missions completed. Gained {0} {1} elite parts", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1712f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -59;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				if (APHENMOFJJP.EAJJDMMGMKK().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(42f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 73;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 60;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("ID_SQUADEVENT");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1320f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return false;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.MNDIJBOCFPM();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("PlayerData");
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
						CLPPIAGLCJJ = 6;
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
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_USEREXISTSGAMECENTERTEXT"), Localization.Localize("ID_SLOTUPGRADE_DAMAGE"), 1408f, TutorialDialog.DODBDLEJOAM.Top);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, false, 1246f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("GrenadeExplodeDamage");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1286f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("currentMode: ", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("SCHEDULING PLAYER STATUS UPDATE!!"), Localization.Localize("#PETER# User was watching ad - waiting for server reward"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1521f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, true, 1875f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
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
				IKAKODPFHAC = 1822f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 445f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.CHGEPEGCLKE() : (-128));
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("damage"), Localization.Localize("_MatCap"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1031f, TutorialDialog.DODBDLEJOAM.TopLeft);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 92;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array4 = new object[0];
					array4[0] = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("LoadingFinishedRPC", array4);
					GuiElementSingle<TutorialDialog>.instance.GPIFEPGEHLF(MMNDGIHINGF, 1612f, TutorialDialog.DODBDLEJOAM.BottomRight);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1763f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, true, false, 598f);
					GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 117;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(909f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("Got ", 1218f, TutorialDialog.DODBDLEJOAM.Left);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.EAJJDMMGMKK().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, true, 1524f);
							GuiElementSingle<TutorialClickOverlay>.instance.NNPKOKCJMHL(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("Sessions"), Localization.LocalizeFormat("http://localhost:8081/", Localization.Localize("GPGS: Log In")), 1433f);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1723f, 711f, 593f), false, true, 930f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("N");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(172f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1116f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -64;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("D3");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("ALL: \n");
				instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("ExpireTime", array3), 252f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(909f, 1953f, 1972f), true, false, 794f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_CONFIRM_ERROR");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("menu-army-ammo-ico");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("PlayerInfoId", array2), 686f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1199f, 1028f, 201f), true, false, 1869f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.OFABMGFOFPI().weaponState != WeaponLevelsSetup.JLANLLEABDC.Active)
				{
					if (PECMCAOEMND && APHENMOFJJP.CJAIGEJNDOH().weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1036f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1045f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 28;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_CONFIRM_JOININGSAMESQUAD", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1041f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].NNACPNBKBJA() != APHENMOFJJP.NGOGADPALJO())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1558f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -94;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_STAT_UNITSDEPLOYED");
				object[] array = new object[0];
				array[1] = Localization.Localize("Tickets");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ID_CONFIRM_JOININGSQUAD_TEXT", array), 1486f, TutorialDialog.DODBDLEJOAM.Top, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 960f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].MOGCFBHKAFO() != APHENMOFJJP.PMIIPNOJFLF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 37;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1492f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -54;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(990f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("ID_ARENARULES_LIVE", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(411f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 21;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("ID_XOFPLAYERSGETSPROMOTED", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(1207f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 14;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				if (APHENMOFJJP.CJAIGEJNDOH().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1700f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 71;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("getSessionPercentile");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1009f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return false;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.LOKBALDOPIK();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("ID_READYTIME");
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
				if (!GuiScreenSingle<MainScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("RewardItem"), Localization.Localize("{0}{1}"), 1145f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 486f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(593f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("px :\n ", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("ID_AVOIDRELEGATION1"), Localization.Localize("\n"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 392f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, true, true, 253f);
				GuiElementSingle<TutorialClickOverlay>.instance.MEBFBNDKOGD(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 556f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1042f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.DMNHLHOBANG() : 123);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("ID_CONFIRM_SERVERERROR"), Localization.Localize("menu-assignments-type-cards"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1979f, TutorialDialog.DODBDLEJOAM.Left);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -78;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array3 = new object[0];
					array3[1] = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("small_icon", array3);
					GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD(MMNDGIHINGF, 1f, TutorialDialog.DODBDLEJOAM.Left);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1716f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, false, true, 322f);
					GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 124;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1894f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD("ID_BRONZEWARCARDS", 926f, TutorialDialog.DODBDLEJOAM.TopRight);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.EAJJDMMGMKK().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(DNHJMCLEGAB, true, false, 89f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("ID_TOCOMPLETE");
				object[] array4 = new object[0];
				array4[1] = Localization.Localize("ID_ARENARULES_UNLIMITEDAMMO");
				instance3.BLHPAFCOPMD(aMKLKMJEMJM3, Localization.LocalizeFormat("Add RARITY {0} warcard - {1}", array4), 1939f, TutorialDialog.DODBDLEJOAM.Top);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(741f, 457f, 128f), true, true, 1317f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.PMIIPNOJFLF().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 104;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("veteranpack");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1634f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(22f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 68;
				}
				break;
			case 15u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("Player_Level"), Localization.LocalizeFormat("ItemsOwned_Rarity_2", Localization.Localize("menu-arena-ticket")), 1017f, TutorialDialog.DODBDLEJOAM.BottomLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(324f, 1997f, 171f), true, false, 184f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = false;
				goto case 17u;
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("#VAVRO# IT WAS ");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("bazooka_idle");
				instance2.PBEAOCBHFGD(aMKLKMJEMJM2, Localization.LocalizeFormat("country-mexico", array2), 1583f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1470f, 824f, 1789f), false, false, 1454f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != (WeaponLevelsSetup.JLANLLEABDC)8)
				{
					if (PECMCAOEMND && APHENMOFJJP.EAJJDMMGMKK().weaponState == WeaponLevelsSetup.JLANLLEABDC.Active)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = false;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
						GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(158f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1292f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 37;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("PauseGameRPC", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(402f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].JBKEFFEKHEG() != APHENMOFJJP.PMIIPNOJFLF())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(337f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -89;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Daily_mission_end");
				object[] array = new object[1];
				array[1] = Localization.Localize("113 STAGE 4 SPAWN 1 DONE");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("Finished", array), 51f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, false, false, 1789f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].weaponLevelsSetup != APHENMOFJJP.weaponSetup)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -106;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(913f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_08dc:
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.OOIJFHGCCNH(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 67;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1605f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("Player_Waited_Till_Delivery_Ends", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1848f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -65;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("KickedPlayerId", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(886f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -114;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(152f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -66;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 71;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Warfriend{0}");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(446f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.OILMPBGNNBD();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Checking success string: ");
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
						CLPPIAGLCJJ = 6;
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
				if (!GuiScreenSingle<MainScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.MAKIDBFPIEE();
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("menu-arena-ticket"), Localization.Localize("ID_MOREXP"), 125f, TutorialDialog.DODBDLEJOAM.BottomRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, false, false, 486f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("hashCode");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(686f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_READYTIME", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.MHAIBHBGBOO())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize(" does not have defined look!!!!!!"), Localization.Localize("ID_CONFIRM_LOGINFAILURE"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1059f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 383f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD);
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 1236f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 934f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.CHGEPEGCLKE() : 102);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.KHPBNEBLEEF(Localization.Localize("Total_Sessions"), Localization.Localize("special"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1468f, TutorialDialog.DODBDLEJOAM.TopLeft);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 114;
					}
					break;
				}
				PBEIEFKCHPN = false;
				PKBPMHOAGMI = true;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					MMNDGIHINGF = Localization.LocalizeFormat("GameController.Awake START", GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].FKLKLCBOMNE.text);
					GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM(MMNDGIHINGF, 1558f, TutorialDialog.DODBDLEJOAM.BottomRight);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 1386f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, true, true, 1726f);
					GuiElementSingle<TutorialClickOverlay>.instance.IGNJKOKGNOI(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -106;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(604f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB("ID_OK", 531f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.CJAIGEJNDOH().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, true, 588f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance4 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM4 = Localization.Localize("b");
				object[] array4 = new object[1];
				array4[1] = Localization.Localize("SlotIndex");
				instance4.DOLDLDECPIO(aMKLKMJEMJM4, Localization.LocalizeFormat("setDeviceId", array4), 124f, TutorialDialog.DODBDLEJOAM.BottomRight, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(383f, 156f, 75f), false, true, 1043f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.OFABMGFOFPI().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 76;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("put");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1429f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				PHDOCKCBJOF = new WaitForSeconds(492f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -66;
				}
				break;
			case 15u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("SyncKevlar");
				object[] array3 = new object[0];
				array3[0] = Localization.Localize("GameBan");
				instance3.DOLDLDECPIO(aMKLKMJEMJM3, Localization.LocalizeFormat("country-finland", array3), 1284f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(115f, 1380f, 1001f), true, true, 1714f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = true;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("ID_LEADER");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize(")");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Action ", array2), 1943f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(791f, 632f, 671f), true, false, 440f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					if (PECMCAOEMND && APHENMOFJJP.GMEFFFKMDCE().weaponState == (WeaponLevelsSetup.JLANLLEABDC)8)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(270f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1101f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 30;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("Unit Icon {0}", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1801f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ALEBNFNFOEP() != APHENMOFJJP.weaponSetup)
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1603f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -116;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("Fuseboxx: Fuseboxx Config Value not found!");
				object[] array = new object[0];
				array[1] = Localization.Localize("isRandomMap");
				instance.DOLDLDECPIO(aMKLKMJEMJM, Localization.LocalizeFormat("ID_COMPLETEIN", array), 1485f);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 747f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ, false);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ENBMDAIKKMM() != APHENMOFJJP.PMIIPNOJFLF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 17;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(557f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.NFPJIFHLFNB(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -126;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(129f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("Gold", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1074f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -110;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("{0} {1}", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(66f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -28;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				if (APHENMOFJJP.CJAIGEJNDOH().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(180f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -15;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 36;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("run_grenadelauncher");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(979f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EFDJMHAPDLB()
		{
			throw new NotSupportedException();
		}

		public void FLOBHENENIC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public void FGLAPPKJHBK()
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
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.HGIDIBNNPEJ();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("[.,]*");
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
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("service"), Localization.Localize("Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?"), 1576f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 1559f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("gold");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(461f);
				BJGCPDNMHDH.mRewardShowable = true;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("ID_TUTORIAL_GO_BUY_ARMY_2", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.HNOHAMJNOKH(Localization.Localize("ID_CONFIRM_SUBSCRIPTION_TITLE"), Localization.Localize("S"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 38f, TutorialDialog.DODBDLEJOAM.TopRight);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 303f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 0;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 1987f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1895f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.PCAMHGKJOKM() : (-15));
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize(" (#"), Localization.Localize("menu-weapons-tab"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 681f, TutorialDialog.DODBDLEJOAM.TopRight);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -37;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array3 = new object[0];
					array3[0] = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("ID_CLOSESIN", array3);
					GuiElementSingle<TutorialDialog>.instance.GKODNFIOLPB(MMNDGIHINGF, 1593f, TutorialDialog.DODBDLEJOAM.Bottom);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 271f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, true, true, 1616f);
					GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -27;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(20f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM("ticketsSpent", 934f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.EAJJDMMGMKK().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, true, 848f);
							GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("ID_DELIVEREDTIME");
				object[] array4 = new object[0];
				array4[0] = Localization.Localize("ID_PVP_BATTLE");
				instance3.PBEAOCBHFGD(aMKLKMJEMJM3, Localization.LocalizeFormat("#STEPAN# Achievement '{0}' progress '{1}' could not be reported.", array4), 1758f, TutorialDialog.DODBDLEJOAM.Top, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1599f, 1524f, 1047f), true, false, 1900f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.weaponSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -73;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Arena Lives: ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1260f);
				ELPHLDJPBNJ = false;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(325f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -23;
				}
				break;
			case 15u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("_#");
				object[] array2 = new object[0];
				array2[0] = Localization.Localize("ID_UPGRADE");
				instance2.ShowMenuTutorial(aMKLKMJEMJM2, Localization.LocalizeFormat("UnsentRewards", array2), 1592f, TutorialDialog.DODBDLEJOAM.TopLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1311f, 1752f, 1539f), false, false, 1069f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = false;
				goto case 17u;
			}
			case 16u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ADDING {0} WARCARD/-S FROM CARDPOOL");
				object[] array = new object[1];
				array[1] = Localization.Localize("-");
				instance.PBEAOCBHFGD(aMKLKMJEMJM, Localization.LocalizeFormat("game-card-ico-mineyourstep-full", array), 651f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(978f, 1058f, 1868f), false, true, 1844f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.PMIIPNOJFLF().weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked)
				{
					if (PECMCAOEMND && APHENMOFJJP.ADOICOAEIFA().weaponState == WeaponLevelsSetup.JLANLLEABDC.Active)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
						GuiElementSingle<TutorialClickOverlay>.instance.Hide(569f);
						Singleton<GuiManager>.instance.CMCCOCBIGBB();
						PHDOCKCBJOF = new WaitForSeconds(1673f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -19;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("{0}/{1} ({2})\n", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1571f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].DLNNBFIIJPA() != APHENMOFJJP.weaponSetup)
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1379f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 69;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("category"), Localization.LocalizeFormat("{0} Squad Member {1}", Localization.Localize("Experience")), 609f, TutorialDialog.DODBDLEJOAM.Center, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, false, 925f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].PMJFFNLKKLB() != APHENMOFJJP.OFABMGFOFPI())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 88;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(496f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.OFABMGFOFPI().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 120;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1429f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("localPlayerLeaderboard", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(858f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -69;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.NEPAMFBPPHB("Id", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(893f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 23;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(460f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 47;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("bronze");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1982f);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 9u;
			}
			return false;
		}

		[SpecialName]
		private object MFNFCFAJKCM()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMEIAAMCBGA()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.StartTutorial(true);
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("#Game Rewards# - Squad Points: {0} (after offer mult x{1} on server)");
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
				if (GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF())
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
				if (!GuiScreenSingle<MainScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.DOLDLDECPIO(Localization.Localize("CONTENTS_FILE_DESCRIPTOR"), Localization.Localize("FuseSDK: Parsing error in _PurchaseVerification"), 1204f, TutorialDialog.DODBDLEJOAM.Bottom, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 1409f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH);
				goto case 4u;
			case 4u:
				if (GuiScreenSingle<MainScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent(" set league ");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NNOOPCFHDJK();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1884f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("LeagueId", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.IOEJCIDBAPL(Localization.Localize("ID_SKILLSHOTHINT_LONGSHOT"), Localization.Localize("AdminId"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1916f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 1228f);
				GuiElementSingle<TutorialClickOverlay>.instance.JGHBBJEFLEB(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 1334f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 859f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.CHGEPEGCLKE() : 38);
					BJGCPDNMHDH.mGoldAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice : 0);
					GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("BlackMarketOffer"), Localization.Localize("ID_CATEGORY_LOW_PL_LMG"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 291f, TutorialDialog.DODBDLEJOAM.BottomLeft);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -102;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = true;
					object[] array3 = new object[0];
					array3[0] = GuiScreenSingle<WeaponScreen>.instance.ILDCKDKKHJC()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("(Lcom/google/android/gms/common/api/GoogleApiClient$ConnectionCallbacks;)Z", array3);
					GuiElementSingle<TutorialDialog>.instance.CLINGHOGNGM(MMNDGIHINGF, 1117f);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.AKKJBKJAFCB()[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 591f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(JFOMIIDCEKM, true, true, 474f);
					GuiElementSingle<TutorialClickOverlay>.instance.EEMMKEMADFC(JFOMIIDCEKM, JFCIFNAPAOC.localScale);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 85;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(238f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.NIGINCPEHFP("Daily", 1358f, TutorialDialog.DODBDLEJOAM.Right);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.weaponSetup.KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, true, 1200f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO();
				goto IL_08dc;
			case 13u:
			{
				TutorialDialog instance3 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM3 = Localization.Localize("GameCenterPassword");
				object[] array4 = new object[0];
				array4[1] = Localization.Localize("menu-squad-8");
				instance3.PBEAOCBHFGD(aMKLKMJEMJM3, Localization.LocalizeFormat("WarArenaRuleConcreteMap", array4), 407f);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(525f, 86f, 993f), true, false, 1605f);
				GuiElementSingle<TutorialClickOverlay>.instance.PGOLMCBEIOD(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto case 14u;
			}
			case 14u:
				if (APHENMOFJJP.NGOGADPALJO().weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 71;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("SpentParts");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.Hide(1970f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1814f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 9;
				}
				break;
			case 15u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("menu-crown-gold"), Localization.LocalizeFormat("OK", Localization.Localize("{0}{1}")), 1766f, TutorialDialog.DODBDLEJOAM.Right, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1946f, 952f, 619f), true, true, 1554f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = false;
				goto case 17u;
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("value");
				object[] array2 = new object[0];
				array2[1] = Localization.Localize("WarBucks");
				instance2.DOLDLDECPIO(aMKLKMJEMJM2, Localization.LocalizeFormat("Beanstalk check: Application not reachable!", array2), 145f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DHEGKFCAAGP, new Vector3(1671f, 891f, 1113f), true, true, 684f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.ADOICOAEIFA().weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
				{
					if (PECMCAOEMND && APHENMOFJJP.PMIIPNOJFLF().weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
					{
						ELPHLDJPBNJ = true;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.JHIDOPOGNLO();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1446f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1388f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 64;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("NetworkReInstantiate_1", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(733f);
				AHHEMONLINF = false;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ANOHEJKJAKG() != APHENMOFJJP.ADOICOAEIFA())
				{
					AHHEMONLINF = true;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(587f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 41;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ID_CONFIRM_ALREADYLEADER");
				object[] array = new object[0];
				array[1] = Localization.Localize("rateAppClientVersion");
				instance.BLHPAFCOPMD(aMKLKMJEMJM, Localization.LocalizeFormat("ID_ROUNDREWARD", array), 1825f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 1182f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].IDMPHABHMGI() != APHENMOFJJP.PMIIPNOJFLF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(1128f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.weaponSetup.KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.UpdateTapAnimation(DNHJMCLEGAB);
						GuiElementSingle<TutorialClickOverlay>.instance.AJNGLEIBMHD(DNHJMCLEGAB, KIPCNCCJDNC, false);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 104;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(94f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("Still waiting for server\nBe patient :-)", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(1812f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 18;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("Winstreak", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(1600f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				if (APHENMOFJJP.GMEFFFKMDCE().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(1348f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -20;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = true;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 72;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("PlayerWeapons");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.NECJPGELBIH();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1932f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return false;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPAFPFPNDNO()
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
				BJGCPDNMHDH.StartTutorial(false);
				Singleton<MessageManager>.instance.StopMessageCoroutine();
				BJGCPDNMHDH.mWeaponToUpgrade = BJGCPDNMHDH.ChooseWeapon();
				Singleton<EventTrackingManager>.instance.RegisterTutorialMenuTutorialEvent("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot accept player");
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
				if (GuiScreenSingle<EndScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
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
				if (!GuiScreenSingle<MainScreen>.instance.AFOFDNJOJHG())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
				GuiElementSingle<TutorialDialog>.instance.PBEAOCBHFGD(Localization.Localize("goldShields"), Localization.Localize("Card_3_Played"), 972f, TutorialDialog.DODBDLEJOAM.Bottom);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH.transform.position, true, true, 28f);
				GuiElementSingle<TutorialClickOverlay>.instance.LPKOHAKMOOC(GuiScreenSingle<MainScreen>.instance.AMHDJLIKNBH, false);
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
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("isNotificationAvailable");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.JIMPCGDILNF(1108f);
				BJGCPDNMHDH.mRewardShowable = false;
				Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA("[-]", BJGCPDNMHDH.mWeaponToUpgrade.DHHKOKKDDDO());
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 5u;
			case 5u:
				if (!GuiScreenSingle<BattlePreparationScreen>.instance.BKIGLABDGCP())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 6u;
			case 6u:
				if (GuiElementSingle<TutorialDialog>.instance.gameObject.activeSelf)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GuiElementSingle<TutorialDialog>.instance.BELJAOIJCOJ(Localization.Localize("Skillshot {0}"), Localization.Localize("ID_SERVER_ERROR"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 368f, TutorialDialog.DODBDLEJOAM.Left);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD.transform.position, false, false, 1052f);
				GuiElementSingle<TutorialClickOverlay>.instance.CAIGHMDPBDI(GuiScreenSingle<BattlePreparationScreen>.instance.KAPHPGAINPD.KAPHPGAINPD, false);
				GuiScreenSingle<WeaponScreen>.instance.EOOIBDMOAFJ(BJGCPDNMHDH.mWeaponToUpgrade);
				ICDIPDJOMKO = 1;
				goto case 7u;
			case 7u:
				if (!GuiElementSingle<TutorialDialog>.instance.LHDGJFHPJNM())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				BJGCPDNMHDH.mRewardShowable = false;
				IKAKODPFHAC = 755f;
				goto IL_0493;
			case 8u:
				IKAKODPFHAC += Time.deltaTime;
				if (IKAKODPFHAC > 1955f)
				{
					BJGCPDNMHDH.mWarbucksAdded = ((!(BJGCPDNMHDH.mWeaponToUpgrade == null)) ? BJGCPDNMHDH.mWeaponToUpgrade.MGAGEKAAJOL.upgradePrice : 77);
					BJGCPDNMHDH.mGoldAdded = ((BJGCPDNMHDH.mWeaponToUpgrade == null) ? 1 : BJGCPDNMHDH.mWeaponToUpgrade.instantWeaponDeliveryPrice);
					GuiElementSingle<TutorialDialog>.instance.NHJEOINEAEO(Localization.Localize("Enemy has no army"), Localization.Localize("WarbucksAdded"), BJGCPDNMHDH.mWarbucksAdded, BJGCPDNMHDH.mGoldAdded, 1531f, TutorialDialog.DODBDLEJOAM.Right);
				}
				goto IL_0493;
			case 9u:
				if (!GuiScreenSingle<WeaponScreen>.instance.BJNBLINDAED())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 31;
					}
					break;
				}
				PBEIEFKCHPN = true;
				PKBPMHOAGMI = false;
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PBEIEFKCHPN = false;
					object[] array3 = new object[0];
					array3[0] = GuiScreenSingle<WeaponScreen>.instance.DGMADFPFHHE()[ICDIPDJOMKO].FKLKLCBOMNE.text;
					MMNDGIHINGF = Localization.LocalizeFormat("Spend_Gold_On_Army", array3);
					GuiElementSingle<TutorialDialog>.instance.FJFFALBAFBD(MMNDGIHINGF, 315f);
					JFOMIIDCEKM = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].transform.position;
					JFCIFNAPAOC = GuiScreenSingle<WeaponScreen>.instance.weaponCategoryButtons[ICDIPDJOMKO].KMFGCJEGJJK.transform;
					if (JFCIFNAPAOC != null)
					{
						JFOMIIDCEKM.x += JFCIFNAPAOC.lossyScale.x * 233f;
					}
					GuiElementSingle<TutorialOverlayGuiElement>.instance.COAHBECNKBK(JFOMIIDCEKM, true, false, 476f);
					GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(JFOMIIDCEKM, JFCIFNAPAOC.localScale, false);
					goto case 10u;
				}
				goto IL_06c2;
			case 10u:
				if (GuiScreenSingle<WeaponScreen>.instance.selectedCategory != (GuiScreenSingle<WeaponScreen>.instance.selectedCategory & BJGCPDNMHDH.mWeaponToUpgrade.BHCEOOLEHHG))
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 33;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.Hide();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(877f);
				goto IL_06c2;
			case 11u:
				GuiElementSingle<TutorialDialog>.instance.ShowSpecial("Bullet with NO weapon", 113f, TutorialDialog.DODBDLEJOAM.Top);
				CADIPBGKAKK = null;
				DNHJMCLEGAB = Vector3.zero;
				KIPCNCCJDNC = Vector3.one;
				KFCAECGLKKO = GuiScreenSingle<WeaponScreen>.instance.weaponIcons.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						WeaponGuiRecord current = KFCAECGLKKO.Current;
						if (current.ADOICOAEIFA().KAJHANBHNKK == BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
						{
							CADIPBGKAKK = current;
							DNHJMCLEGAB = CADIPBGKAKK.transform.position;
							KIPCNCCJDNC = CADIPBGKAKK.GetComponent<BoxCollider>().size;
							GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(DNHJMCLEGAB, true, false, 783f);
							GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC, false);
							break;
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				goto IL_08dc;
			case 12u:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.selectedIcon;
				goto IL_08dc;
			case 13u:
				GuiElementSingle<TutorialDialog>.instance.ShowMenuTutorial(Localization.Localize("ID_SALEPERCENTLINE"), Localization.LocalizeFormat("ID_ARENARULES_UNITCOST", Localization.Localize("null")), 1689f, TutorialDialog.DODBDLEJOAM.TopLeft, false);
				DHEGKFCAAGP = GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.HJKCBBANLDM.cachedTransform.position;
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1189f, 586f, 143f), false, false, 354f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				goto case 14u;
			case 14u:
				if (APHENMOFJJP.CJAIGEJNDOH().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = -67;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("menu-event-day-bg");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(231f);
				ELPHLDJPBNJ = true;
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(114f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -9;
				}
				break;
			case 15u:
				GuiElementSingle<TutorialDialog>.instance.BLHPAFCOPMD(Localization.Localize("On Login to Custom playerAccount"), Localization.LocalizeFormat("GoldTransactionAmount", Localization.Localize("#VAVRO# Accept Challenge Message {0}")), 583f, TutorialDialog.DODBDLEJOAM.Top, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(771f, 98f, 128f), false, false, 56f);
				GuiElementSingle<TutorialClickOverlay>.instance.LECHCOBHAFP(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC, false);
				PECMCAOEMND = false;
				goto case 17u;
			case 16u:
			{
				TutorialDialog instance2 = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM2 = Localization.Localize("\t\"TRUE\"");
				object[] array2 = new object[1];
				array2[1] = Localization.Localize("D5");
				instance2.BLHPAFCOPMD(aMKLKMJEMJM2, Localization.LocalizeFormat("SETTING HalfResNoMs", array2), 344f, TutorialDialog.DODBDLEJOAM.Right);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.NACPFGIANHD(DHEGKFCAAGP, new Vector3(1644f, 1379f, 986f), false, true, 1279f);
				GuiElementSingle<TutorialClickOverlay>.instance.GBHNBKFGCPG(GuiScreenSingle<WeaponScreen>.instance.EMHGMNAABDN.EDHCOMHOKDC);
				goto IL_0c35;
			}
			case 17u:
				if (APHENMOFJJP.EAJJDMMGMKK().weaponState != (WeaponLevelsSetup.JLANLLEABDC)7)
				{
					if (PECMCAOEMND && APHENMOFJJP.OFABMGFOFPI().weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
					{
						ELPHLDJPBNJ = false;
						PECMCAOEMND = true;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
						GuiElementSingle<TutorialDialog>.instance.Hide();
						GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1241f);
						Singleton<GuiManager>.instance.TurnOffInputCompletly();
						PHDOCKCBJOF = new WaitForSeconds(1882f);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = -56;
						}
						break;
					}
					goto IL_0c35;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialDeliveredEvent("ID_STARTERPACK", ELPHLDJPBNJ);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.AGJFMINNOBH(1093f);
				AHHEMONLINF = true;
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].JCPKCKIHFBI() != APHENMOFJJP.EAJJDMMGMKK())
				{
					AHHEMONLINF = false;
					Singleton<GuiManager>.instance.CMCCOCBIGBB();
					PHDOCKCBJOF = new WaitForSeconds(759f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 110;
					}
					break;
				}
				goto IL_0dff;
			case 18u:
			{
				TutorialDialog instance = GuiElementSingle<TutorialDialog>.instance;
				string aMKLKMJEMJM = Localization.Localize("ArenaVisualMessage");
				object[] array = new object[0];
				array[0] = Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT");
				instance.ShowMenuTutorial(aMKLKMJEMJM, Localization.LocalizeFormat("$#", array), 1886f, TutorialDialog.DODBDLEJOAM.TopRight, false);
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StartTapAnimation(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ.transform.position, true, true, 614f);
				GuiElementSingle<TutorialClickOverlay>.instance.SetByButton(GuiScreenSingle<WeaponScreen>.instance.BKLPGLKGCLG.BEJIFJIKHPJ);
				goto case 19u;
			}
			case 19u:
				if (PlayerInventory.instance.inventorySlots[ICDIPDJOMKO].ANOHEJKJAKG() != APHENMOFJJP.EAJJDMMGMKK())
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 40;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.FEPJCDADLJA();
				GuiElementSingle<TutorialClickOverlay>.instance.BIBPLCKJJGE(878f);
				goto IL_0dff;
			case 20u:
				BJGCPDNMHDH.CleanUpAfterTutorial();
				BJGCPDNMHDH.FinishTutorial();
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_08dc:
				if (APHENMOFJJP.NGOGADPALJO().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					if (CADIPBGKAKK != null && CADIPBGKAKK.transform.position != DNHJMCLEGAB)
					{
						DNHJMCLEGAB = CADIPBGKAKK.transform.position;
						GuiElementSingle<TutorialOverlayGuiElement>.instance.IMOAGBADPCC(DNHJMCLEGAB, false);
						GuiElementSingle<TutorialClickOverlay>.instance.SetAndShow(DNHJMCLEGAB, KIPCNCCJDNC);
					}
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 53;
					}
					break;
				}
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.LLOKPDFKHDI();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(1893f);
				goto IL_0929;
				IL_0dff:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponEquippedEvent("Call ConnectToNameServer to ping available regions.", AHHEMONLINF);
				PHDOCKCBJOF = new WaitForSeconds(239f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 97;
				}
				break;
				IL_0929:
				Singleton<EventTrackingManager>.instance.RegisterTutorialWeaponSelectedEvent("N0", PBEIEFKCHPN, PKBPMHOAGMI);
				Singleton<GuiManager>.instance.CMCCOCBIGBB();
				PHDOCKCBJOF = new WaitForSeconds(5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 96;
				}
				break;
				IL_06c2:
				APHENMOFJJP = GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP();
				if (APHENMOFJJP.CJAIGEJNDOH().KAJHANBHNKK != BJGCPDNMHDH.mWeaponToUpgrade.KAJHANBHNKK)
				{
					PKBPMHOAGMI = false;
					Singleton<GuiManager>.instance.TurnOffInputCompletly();
					PHDOCKCBJOF = new WaitForSeconds(575f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_0929;
				IL_0c35:
				PHDOCKCBJOF = false;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = -18;
				}
				break;
				IL_0493:
				if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
				{
					PHDOCKCBJOF = null;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				Singleton<EventTrackingManager>.instance.RegisterTutorialEvent("Hide Ground");
				GuiElementSingle<TutorialOverlayGuiElement>.instance.StopTapAnimation();
				GuiElementSingle<TutorialDialog>.instance.BMINKIDMOGL();
				GuiElementSingle<TutorialClickOverlay>.instance.PKLDJJIALHA(881f);
				Singleton<GuiManager>.instance.TurnOffInputCompletly();
				goto case 9u;
			}
			return true;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FCBCEDKNBKC()
		{
			return PHDOCKCBJOF;
		}

		public void PPHBGPPJBNK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}
	}

	private static TutorialManagerStage4 mInstance;

	public const string id = "Stage4";

	private WeaponLevelsSetup mWeaponToUpgrade;

	private int mGoldAdded;

	private int mWarbucksAdded;

	private bool mRewardShowable;

	private int mNumberOfGames;

	public static TutorialManagerStage4 instance
	{
		get
		{
			mInstance = mInstance ?? UnityEngine.Object.FindObjectOfType<TutorialManagerStage4>();
			return mInstance;
		}
	}

	public bool wasFinished
	{
		get
		{
			return data.started;
		}
	}

	public int numberOfGames
	{
		get
		{
			if (mNumberOfGames < 1)
			{
				mNumberOfGames = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TutorialUpgradeWeaponAfterGames).FLOATVALUE;
			}
			return mNumberOfGames;
		}
	}

	private bool canRunTutorial
	{
		get
		{
			return !LevelManager.instance.isLevelUp && !wasFinished && !TutorialManagerStage5.instance.isTutorialRunning;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mInstance = this;
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += delegate
		{
			mNumberOfGames = 0;
		};
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
			GuiElementSingle<TutorialDialog>.instance.ShowReward(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3"), Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_4"), mWarbucksAdded, mGoldAdded, 0.3f, TutorialDialog.DODBDLEJOAM.Right);
		}
	}

	public bool TryToStartWeaponUpgradeTutorial()
	{
		if (wasFinished)
		{
			return false;
		}
		if (StatsManager.instance.totalGames < numberOfGames)
		{
			return false;
		}
		if (StatsManager.instance.weaponsUpgrades > 0 || LevelManager.instance.DeliveringWeapon() != null)
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
		StartCoroutine(RadicalRoutine.Run(UpdateWeaponTutorial()));
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

	private WeaponLevelsSetup ChooseWeapon()
	{
		return LevelManager.instance.Weapon("Google2u.AssaultRifle_AK47");
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
	public IEnumerator UpdateWeaponTutorial()
	{
		LIMNGFDOBNO lIMNGFDOBNO = new LIMNGFDOBNO();
		lIMNGFDOBNO.BJGCPDNMHDH = this;
		return lIMNGFDOBNO;
	}
}
