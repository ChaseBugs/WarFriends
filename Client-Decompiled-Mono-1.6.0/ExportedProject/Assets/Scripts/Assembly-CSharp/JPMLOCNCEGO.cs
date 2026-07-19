using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class JPMLOCNCEGO
{
	public string INFLHPGMEOB;

	public string OKMNFHNBMFA;

	public string JPCIACBHGHO;

	public string KPKHDEMIEJK;

	public int CJJHPGFOHCH;

	public int DBOLKNNJGMH;

	public string MODHHKHPHOJ;

	public string CICDGFDHBDO;

	public JANNFNFOIEE FJLBLLLEELD;

	public string NCKBCFBJNBA;

	public Dictionary<string, string> JKACLINPIGD;

	public bool MJPOBONOBCD;

	public bool IDGABEICMFF;

	public string GDIAEJILINE
	{
		get
		{
			return string.Format("{0}-{1}", INFLHPGMEOB, Localization.instance.currentLanguage);
		}
	}

	public bool APLNKNOHGFN
	{
		get
		{
			switch (FJLBLLLEELD)
			{
			case JANNFNFOIEE.ArmyScreenUnitOneBuy:
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.Unit(NCKBCFBJNBA);
				return levelBehaviour != null && levelBehaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed;
			}
			case JANNFNFOIEE.ArmyScreenUnitOneUpgrade:
			case JANNFNFOIEE.ArmyDeliveryTimeOne:
			case JANNFNFOIEE.ArmyDeliveryCostOne:
			{
				LevelBehaviour levelBehaviour3 = LevelManager.instance.Unit(NCKBCFBJNBA);
				return levelBehaviour3 != null && levelBehaviour3.upgradeSlots.bought && levelBehaviour3.upgradeSlots.canBeUpgraded;
			}
			case JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy:
			{
				LevelBehaviour levelBehaviour2 = LevelManager.instance.Unit(NCKBCFBJNBA);
				if (levelBehaviour2 == null)
				{
					return false;
				}
				return levelBehaviour2.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || (levelBehaviour2.upgradeSlots.bought && levelBehaviour2.upgradeSlots.canBeUpgraded);
			}
			case JANNFNFOIEE.ArmyScreenFlatBuy:
			case JANNFNFOIEE.ArmyScreenTypeFlatBuy:
			case JANNFNFOIEE.ArmyScreenFlatUpgrade:
			case JANNFNFOIEE.ArmyScreenTypeFlatUpgrade:
			case JANNFNFOIEE.ArmyScreenFlatUpgradeBuy:
			case JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy:
			case JANNFNFOIEE.ArmyDeliveryTimeType:
			case JANNFNFOIEE.ArmyDeliveryTimeAll:
			case JANNFNFOIEE.ArmyDeliveryCostType:
			case JANNFNFOIEE.ArmyDeliveryCostAll:
				return OBLFKLGHFCE();
			case JANNFNFOIEE.WeaponScreenWeaponOneBuy:
			{
				WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.Weapon(NCKBCFBJNBA);
				return weaponLevelsSetup2 != null && weaponLevelsSetup2.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
			}
			case JANNFNFOIEE.WeaponScreenWeaponOneUpgrade:
			case JANNFNFOIEE.WeaponDeliveryTimeOne:
			case JANNFNFOIEE.WeaponDeliveryCostOne:
			{
				WeaponLevelsSetup weaponLevelsSetup3 = LevelManager.instance.Weapon(NCKBCFBJNBA);
				return weaponLevelsSetup3 != null && weaponLevelsSetup3.bought && weaponLevelsSetup3.canBeUpgraded;
			}
			case JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy:
			{
				WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(NCKBCFBJNBA);
				if (weaponLevelsSetup == null)
				{
					return false;
				}
				return weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded);
			}
			case JANNFNFOIEE.WeaponScreenFlatBuy:
			case JANNFNFOIEE.WeaponScreenSlotFlatBuy:
			case JANNFNFOIEE.WeaponScreenTypeFlatBuy:
			case JANNFNFOIEE.WeaponScreenFlatUpgrade:
			case JANNFNFOIEE.WeaponScreenSlotFlatUpgrade:
			case JANNFNFOIEE.WeaponScreenTypeFlatUpgrade:
			case JANNFNFOIEE.WeaponScreenFlatUpgradeBuy:
			case JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy:
			case JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy:
			case JANNFNFOIEE.WeaponDeliveryTimeType:
			case JANNFNFOIEE.WeaponDeliveryTimeSlot:
			case JANNFNFOIEE.WeaponDeliveryTimeAll:
			case JANNFNFOIEE.WeaponDeliveryCostType:
			case JANNFNFOIEE.WeaponDeliveryCostSlot:
			case JANNFNFOIEE.WeaponDeliveryCostAll:
				return INDLIEADMNE();
			case JANNFNFOIEE.BuyInApp:
				return !PlayerAnalytics.instance.IsPackBought(NCKBCFBJNBA);
			case JANNFNFOIEE.PurchasesFreeAddOne:
				if (JKACLINPIGD != null && JKACLINPIGD.ContainsKey("id"))
				{
					string text = JKACLINPIGD["id"];
					if (text.Contains("pack"))
					{
						string text2 = Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Starter);
						if (text2.StartsWith(text) && PlayerAnalytics.instance.showStarterPack)
						{
							return true;
						}
						text2 = Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value);
						if (text2.StartsWith(text) && !PlayerAnalytics.instance.IsPackBought(text2))
						{
							return true;
						}
						text2 = Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Money);
						if (text2.StartsWith(text) && PlayerAnalytics.instance.showMoneyPack)
						{
							return true;
						}
						for (int i = 1; i < 7; i++)
						{
							text2 = i.ToString("'elitepack'0");
							if (text2.StartsWith(text) && PlayerAnalytics.instance.ShowPack(text2))
							{
								return true;
							}
						}
						for (int j = 1; j < 6; j++)
						{
							text2 = j.ToString("'veteranpack'0");
							if (text2.StartsWith(text) && PlayerAnalytics.instance.ShowPack(text2))
							{
								return true;
							}
						}
						List<JGBBPCGNCPC> specialPackOffer = Singleton<OfferManager>.instance.GetSpecialPackOffer();
						if (specialPackOffer != null)
						{
							for (int k = 0; k < specialPackOffer.Count; k++)
							{
								if (specialPackOffer[k].KJBPJOMHNKB.StartsWith(text) && specialPackOffer[k].MGJIPPFKDOE > Singleton<BeanstalkServerManager>.instance.currentTimestamp && !PlayerAnalytics.instance.IsPackBought(specialPackOffer[k].KJBPJOMHNKB))
								{
									return true;
								}
							}
						}
						return false;
					}
					return true;
				}
				return false;
			default:
				return true;
			}
		}
	}

	private int FABOAIMLLOI
	{
		get
		{
			int result = 0;
			int.TryParse(NCKBCFBJNBA, out result);
			return result;
		}
	}

	private bool HLFOCAMAGOE()
	{
		int num = FABOAIMLLOI;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			int num2 = 0 << (int)(behaviour.unitType & (LevelBehaviour.UnitType)41);
			if (FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy && (num2 & num) > 1 && behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked)
			{
				return false;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || FJLBLLLEELD == (JANNFNFOIEE)123 || FJLBLLLEELD == (JANNFNFOIEE)100) && (num2 & num) > 0 && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return false;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)(-5) && (num2 & num) > 0 && (behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.Locked || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return false;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.VIPFlat && behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneBuy || FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostAll || FJLBLLLEELD == (JANNFNFOIEE)85) && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return false;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)(-105) && (behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return true;
			}
		}
		return true;
	}

	public static JPMLOCNCEGO IDCHLPKNGHJ()
	{
		JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
		jPMLOCNCEGO.INFLHPGMEOB = "bad visuals for";
		jPMLOCNCEGO.OKMNFHNBMFA = "squadsFromLeague";
		jPMLOCNCEGO.JPCIACBHGHO = "Google2u.AssaultRifle_AK47";
		jPMLOCNCEGO.KPKHDEMIEJK = "DOWNLOAD";
		jPMLOCNCEGO.CJJHPGFOHCH = Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + -182;
		jPMLOCNCEGO.DBOLKNNJGMH = -7;
		jPMLOCNCEGO.MODHHKHPHOJ = "ID_UPGRADEFORCHEAPER";
		jPMLOCNCEGO.CICDGFDHBDO = jPMLOCNCEGO.MODHHKHPHOJ;
		jPMLOCNCEGO.FJLBLLLEELD = JANNFNFOIEE.VIPFlat;
		jPMLOCNCEGO.MJPOBONOBCD = false;
		return jPMLOCNCEGO;
	}

	public static JPMLOCNCEGO PHHEGMGMBAM(JToken NDPMDKGJAFH, string IMOCKMIAJHN)
	{
		if (NDPMDKGJAFH["idle"] != null && NDPMDKGJAFH["Overtime_Was_Already_Explained"] != null && NDPMDKGJAFH["Name"] != null)
		{
			JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
			if (NDPMDKGJAFH[" AND "] == null)
			{
				Debug.LogError("userId");
				return null;
			}
			jPMLOCNCEGO.INFLHPGMEOB = IMOCKMIAJHN;
			jPMLOCNCEGO.CJJHPGFOHCH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_COOPCANCELED"], 1);
			jPMLOCNCEGO.DBOLKNNJGMH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["Shotgunner"]);
			jPMLOCNCEGO.MJPOBONOBCD = NDPMDKGJAFH["OK"] != null && KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_XSKIRMISHESRESULT"]) == 1;
			jPMLOCNCEGO.IDGABEICMFF = NDPMDKGJAFH["hookId"] == null || KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_COMPLETEALLTENSTARTERASSIGNMENTS"], 1) == 1;
			if (!jPMLOCNCEGO.IDGABEICMFF)
			{
				jPMLOCNCEGO.MJPOBONOBCD = false;
			}
			else if (NDPMDKGJAFH["ID_TUTORIAL_GO_BUY_ARMY_6"] == null || NDPMDKGJAFH["INTERRUPTED"] == null)
			{
				Debug.LogError("SquadId");
				return null;
			}
			jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["GameReward"], 1);
			jPMLOCNCEGO.OKMNFHNBMFA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["Only Sliced is supported now"], string.Empty);
			if (NDPMDKGJAFH["ВЫХОД"] != null)
			{
				jPMLOCNCEGO.KPKHDEMIEJK = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["ID_GUI_ALLCARDS"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.KPKHDEMIEJK = string.Empty;
			}
			if (NDPMDKGJAFH["Player_Had_To_Select_Grenade"] != null)
			{
				jPMLOCNCEGO.JPCIACBHGHO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["Wrong_Weapon"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.JPCIACBHGHO = string.Empty;
			}
			if (NDPMDKGJAFH["Total_Sessions"] != null)
			{
				if (jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.WarshopCardpacksFlat)
				{
					JToken jToken = NDPMDKGJAFH["VipStart"];
					int jJBHBKCGLGK = KHJJFPPACBP.HNMDPGKPLNK(jToken["FinishChoosingCardsRPC"]);
					int bBPAMDDFNDM = KHJJFPPACBP.HNMDPGKPLNK(jToken["Money Pack was already bought!"]);
					int oHOCBKNLCLD = KHJJFPPACBP.HNMDPGKPLNK(jToken["No overlay to display cards!"], 1);
					Singleton<DogTagManager>.instance.MOGKLGDDEJL(jJBHBKCGLGK, bBPAMDDFNDM, oHOCBKNLCLD, jPMLOCNCEGO.CJJHPGFOHCH);
				}
				else if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)78 || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-12) || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-24) || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-62))
				{
					jPMLOCNCEGO.JKACLINPIGD = new Dictionary<string, string>();
					foreach (JToken item in NDPMDKGJAFH["ID_HOU"].AsJEnumerable())
					{
						if (item is JProperty)
						{
							JProperty jProperty = item as JProperty;
							jPMLOCNCEGO.JKACLINPIGD.Add(jProperty.Name, KHJJFPPACBP.BKFCLMMJNHK(jProperty.Value, string.Empty));
						}
					}
				}
				else
				{
					jPMLOCNCEGO.NCKBCFBJNBA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH[", databaseType= "], string.Empty);
				}
			}
			else
			{
				jPMLOCNCEGO.NCKBCFBJNBA = string.Empty;
			}
			if (NDPMDKGJAFH["#VOJTA# ERROR ACHIEVEMENT ALREADY CLAIMED!!"] != null)
			{
				jPMLOCNCEGO.MODHHKHPHOJ = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["()Ljava/lang/String;"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.MODHHKHPHOJ = string.Empty;
			}
			if (NDPMDKGJAFH["eventEnd"] != null)
			{
				jPMLOCNCEGO.CICDGFDHBDO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["GOT MAINTENANCE MESSAGE IN LOGIN TO ACCOUNT"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.CICDGFDHBDO = string.Empty;
			}
			return jPMLOCNCEGO;
		}
		return null;
	}

	public static JPMLOCNCEGO GDKBNJELNKA(int NOCEDALFEJM = 0)
	{
		JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
		jPMLOCNCEGO.INFLHPGMEOB = NOCEDALFEJM.ToString("com/google/android/gms/common/api/Status");
		jPMLOCNCEGO.OKMNFHNBMFA = NOCEDALFEJM.ToString("ID_TUTORIAL_GRENADETHROW_DOWN");
		jPMLOCNCEGO.JPCIACBHGHO = ((NOCEDALFEJM != 0) ? "#AccoutCheck# GoogleLoggedIn tutorial - ALL OK - logged to gpgs connectet to this account" : string.Empty);
		jPMLOCNCEGO.KPKHDEMIEJK = ((NOCEDALFEJM != 1) ? "VipRewardForDay" : " NOT OK!\t\t\t\t\t\t");
		jPMLOCNCEGO.CJJHPGFOHCH = ((NOCEDALFEJM != 1) ? (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + 96) : 0);
		jPMLOCNCEGO.DBOLKNNJGMH = 85 - NOCEDALFEJM;
		if (NOCEDALFEJM == 0)
		{
			jPMLOCNCEGO.MODHHKHPHOJ = "ProductId";
		}
		else if (NOCEDALFEJM == 0)
		{
			jPMLOCNCEGO.MODHHKHPHOJ = "NextDailyRewardLocalnotification";
		}
		else
		{
			jPMLOCNCEGO.MODHHKHPHOJ = "Missing reference to atlas.";
		}
		jPMLOCNCEGO.CICDGFDHBDO = jPMLOCNCEGO.MODHHKHPHOJ;
		jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)(NOCEDALFEJM + -90);
		if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-3))
		{
			jPMLOCNCEGO.NCKBCFBJNBA = "\n";
		}
		if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)126)
		{
			jPMLOCNCEGO.NCKBCFBJNBA = "Exception when creating cards for tutorial - creating default instead, msg = ";
		}
		jPMLOCNCEGO.MJPOBONOBCD = false;
		return jPMLOCNCEGO;
	}

	private bool BCPALIOIKKD()
	{
		int num = FABOAIMLLOI;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			int bHCEOOLEHHG = (int)weaponLevelsSetup.BHCEOOLEHHG;
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-45) || FJLBLLLEELD == (JANNFNFOIEE)100) && (bHCEOOLEHHG & num) > 1 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)78 || FJLBLLLEELD == (JANNFNFOIEE)(-82) || FJLBLLLEELD == (JANNFNFOIEE)(-94) || FJLBLLLEELD == (JANNFNFOIEE)107 || FJLBLLLEELD == (JANNFNFOIEE)100 || FJLBLLLEELD == (JANNFNFOIEE)114) && (bHCEOOLEHHG & num) > 1 && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostType || FJLBLLLEELD == JANNFNFOIEE.BattleRewardSquadpoints) && (bHCEOOLEHHG & num) > 1 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.BuyInApp && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				return false;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-27) || FJLBLLLEELD == (JANNFNFOIEE)(-44) || FJLBLLLEELD == (JANNFNFOIEE)104) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)119 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}

	public static JPMLOCNCEGO PPBJHFHLIPH(JToken NDPMDKGJAFH, string IMOCKMIAJHN)
	{
		if (NDPMDKGJAFH["877"] != null && NDPMDKGJAFH["ID_DIVISION"] != null && NDPMDKGJAFH["KLHPEJKKNPD"] != null)
		{
			JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
			if (NDPMDKGJAFH["ID_TUTORIAL_DELIVERED_UNIT"] == null)
			{
				Debug.LogError("batchSizeMax");
				return null;
			}
			jPMLOCNCEGO.INFLHPGMEOB = IMOCKMIAJHN;
			jPMLOCNCEGO.CJJHPGFOHCH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["BattleCount"], 1);
			jPMLOCNCEGO.DBOLKNNJGMH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["C3"]);
			jPMLOCNCEGO.MJPOBONOBCD = NDPMDKGJAFH["212 MENU LEVEL UP SHOWN"] != null && KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_HOU"], 1) == 1;
			jPMLOCNCEGO.IDGABEICMFF = NDPMDKGJAFH["Player_Waited_Till_Delivery_Ends"] == null || KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["InAppHandlerIos: purchase was cancellled, "], 1) == 0;
			if (!jPMLOCNCEGO.IDGABEICMFF)
			{
				jPMLOCNCEGO.MJPOBONOBCD = true;
			}
			else if (NDPMDKGJAFH["SquadWarsId"] == null || NDPMDKGJAFH["ID_DAILYMISSIONX"] == null)
			{
				Debug.LogError("ID_CONFIRM_THANKYOU");
				return null;
			}
			jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_TUTORIAL_START_PHASE2"], 1);
			jPMLOCNCEGO.OKMNFHNBMFA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["MoneyPackDeadline"], string.Empty);
			if (NDPMDKGJAFH["Local"] != null)
			{
				jPMLOCNCEGO.KPKHDEMIEJK = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["S"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.KPKHDEMIEJK = string.Empty;
			}
			if (NDPMDKGJAFH["BeforeLeagueId"] != null)
			{
				jPMLOCNCEGO.JPCIACBHGHO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["facebookFriends"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.JPCIACBHGHO = string.Empty;
			}
			if (NDPMDKGJAFH["ID_COMEBACKTOMORROW"] != null)
			{
				if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)87)
				{
					JToken jToken = NDPMDKGJAFH["S"];
					int jJBHBKCGLGK = KHJJFPPACBP.HNMDPGKPLNK(jToken["temp_facebook_user_id"], 1);
					int bBPAMDDFNDM = KHJJFPPACBP.HNMDPGKPLNK(jToken["Amount"]);
					int oHOCBKNLCLD = KHJJFPPACBP.HNMDPGKPLNK(jToken["Medals/"]);
					Singleton<DogTagManager>.instance.KCLNCPAGAKG(jJBHBKCGLGK, bBPAMDDFNDM, oHOCBKNLCLD, jPMLOCNCEGO.CJJHPGFOHCH);
				}
				else if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)83 || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-36) || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-13) || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-103))
				{
					jPMLOCNCEGO.JKACLINPIGD = new Dictionary<string, string>();
					foreach (JToken item in NDPMDKGJAFH["withRevenue"].AsJEnumerable())
					{
						if (item is JProperty)
						{
							JProperty jProperty = item as JProperty;
							jPMLOCNCEGO.JKACLINPIGD.Add(jProperty.Name, KHJJFPPACBP.BKFCLMMJNHK(jProperty.Value, string.Empty));
						}
					}
				}
				else
				{
					jPMLOCNCEGO.NCKBCFBJNBA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["Position"], string.Empty);
				}
			}
			else
			{
				jPMLOCNCEGO.NCKBCFBJNBA = string.Empty;
			}
			if (NDPMDKGJAFH["ID_GOLD"] != null)
			{
				jPMLOCNCEGO.MODHHKHPHOJ = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["BonusHP"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.MODHHKHPHOJ = string.Empty;
			}
			if (NDPMDKGJAFH["\n{0}"] != null)
			{
				jPMLOCNCEGO.CICDGFDHBDO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["These IDs are not in dictionary XLS:\n"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.CICDGFDHBDO = string.Empty;
			}
			return jPMLOCNCEGO;
		}
		return null;
	}

	[SpecialName]
	public string FLFMHFIGNKE()
	{
		return string.Format("Not a player visual.", INFLHPGMEOB, Localization.instance.currentLanguage);
	}

	private bool INDLIEADMNE()
	{
		int num = FABOAIMLLOI;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			int bHCEOOLEHHG = (int)weaponLevelsSetup.BHCEOOLEHHG;
			if ((FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy || FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatBuy) && (bHCEOOLEHHG & num) > 0 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgrade || FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgrade || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostSlot || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostType || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeSlot || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeType) && (bHCEOOLEHHG & num) > 0 && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatUpgradeBuy || FJLBLLLEELD == JANNFNFOIEE.WeaponScreenTypeFlatUpgradeBuy) && (bHCEOOLEHHG & num) > 0 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatBuy && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgrade || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryCostAll || FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeAll) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.WeaponScreenFlatUpgradeBuy && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}

	public static JPMLOCNCEGO LFKDFKJKGPD(JToken NDPMDKGJAFH, string IMOCKMIAJHN)
	{
		if (NDPMDKGJAFH["ID_STATE_GAMEFINISHED"] != null && NDPMDKGJAFH["ID_MIN"] != null && NDPMDKGJAFH["#PHOTON# switching to TCP"] != null)
		{
			JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
			if (NDPMDKGJAFH["Id"] == null)
			{
				Debug.LogError("setCustomProfileNumber");
				return null;
			}
			jPMLOCNCEGO.INFLHPGMEOB = IMOCKMIAJHN;
			jPMLOCNCEGO.CJJHPGFOHCH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["stand_up_crawl"], 1);
			jPMLOCNCEGO.DBOLKNNJGMH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["CheckDisable"]);
			jPMLOCNCEGO.MJPOBONOBCD = NDPMDKGJAFH["CLIENT REMINDERS:\nTutorial upgrade weapon running \"{0}\"\n"] != null && KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["({0}\u00a0/\u00a0{1})"], 1) == 1;
			jPMLOCNCEGO.IDGABEICMFF = NDPMDKGJAFH["oo"] == null || KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["DogtagsRefillRankUp"], 1) == 1;
			if (!jPMLOCNCEGO.IDGABEICMFF)
			{
				jPMLOCNCEGO.MJPOBONOBCD = true;
			}
			else if (NDPMDKGJAFH["PlayerArmyPower"] == null || NDPMDKGJAFH["seconds"] == null)
			{
				Debug.LogError("BoughtIndex");
				return null;
			}
			jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["ID_PURCHASEINPROGRESS"]);
			jPMLOCNCEGO.OKMNFHNBMFA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["discount"], string.Empty);
			if (NDPMDKGJAFH["ID_TUTORIAL_UPGRADEWEAPON_5"] != null)
			{
				jPMLOCNCEGO.KPKHDEMIEJK = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["ok"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.KPKHDEMIEJK = string.Empty;
			}
			if (NDPMDKGJAFH["com/google/android/gms/common/api/Status"] != null)
			{
				jPMLOCNCEGO.JPCIACBHGHO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["ChangeCamoRPC"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.JPCIACBHGHO = string.Empty;
			}
			if (NDPMDKGJAFH["THANK YOU"] != null)
			{
				if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-85))
				{
					JToken jToken = NDPMDKGJAFH["country-noflag"];
					int jJBHBKCGLGK = KHJJFPPACBP.HNMDPGKPLNK(jToken["ID_STATE_OPPONENTDISCONECTED"]);
					int bBPAMDDFNDM = KHJJFPPACBP.HNMDPGKPLNK(jToken["ID_WAITINGTIME"]);
					int oHOCBKNLCLD = KHJJFPPACBP.HNMDPGKPLNK(jToken["ID_ARENARULES_MATCHCARDSETS"], 1);
					Singleton<DogTagManager>.instance.KKLOBNHDIPG(jJBHBKCGLGK, bBPAMDDFNDM, oHOCBKNLCLD, jPMLOCNCEGO.CJJHPGFOHCH);
				}
				else if (jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)98 || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-96) || jPMLOCNCEGO.FJLBLLLEELD == (JANNFNFOIEE)(-95) || jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade)
				{
					jPMLOCNCEGO.JKACLINPIGD = new Dictionary<string, string>();
					foreach (JToken item in NDPMDKGJAFH["ID_AFFECTEDENEMYUNITS"].AsJEnumerable())
					{
						if (item is JProperty)
						{
							JProperty jProperty = item as JProperty;
							jPMLOCNCEGO.JKACLINPIGD.Add(jProperty.Name, KHJJFPPACBP.BKFCLMMJNHK(jProperty.Value, string.Empty));
						}
					}
				}
				else
				{
					jPMLOCNCEGO.NCKBCFBJNBA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["InAppHandlerIos: restore transactions"], string.Empty);
				}
			}
			else
			{
				jPMLOCNCEGO.NCKBCFBJNBA = string.Empty;
			}
			if (NDPMDKGJAFH["FLOATVALUE"] != null)
			{
				jPMLOCNCEGO.MODHHKHPHOJ = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["GooglePlay"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.MODHHKHPHOJ = string.Empty;
			}
			if (NDPMDKGJAFH["\"}"] != null)
			{
				jPMLOCNCEGO.CICDGFDHBDO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["game-ico-blind"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.CICDGFDHBDO = string.Empty;
			}
			return jPMLOCNCEGO;
		}
		return null;
	}

	public static JPMLOCNCEGO CHNFMMNDFCD(JToken NDPMDKGJAFH, string IMOCKMIAJHN)
	{
		if (NDPMDKGJAFH["end"] != null && NDPMDKGJAFH["sale"] != null && NDPMDKGJAFH["offerType"] != null)
		{
			JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
			if (NDPMDKGJAFH["title"] == null)
			{
				Debug.LogError("null title for offer!");
				return null;
			}
			jPMLOCNCEGO.INFLHPGMEOB = IMOCKMIAJHN;
			jPMLOCNCEGO.CJJHPGFOHCH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["end"]);
			jPMLOCNCEGO.DBOLKNNJGMH = KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["sale"]);
			jPMLOCNCEGO.MJPOBONOBCD = NDPMDKGJAFH["showed"] != null && KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["showed"]) == 1;
			jPMLOCNCEGO.IDGABEICMFF = NDPMDKGJAFH["canShow"] != null && KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["canShow"]) == 1;
			if (!jPMLOCNCEGO.IDGABEICMFF)
			{
				jPMLOCNCEGO.MJPOBONOBCD = true;
			}
			else if (NDPMDKGJAFH["bigURL"] == null || NDPMDKGJAFH["smallURL"] == null)
			{
				Debug.LogError("null image url for offer!");
				return null;
			}
			jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)KHJJFPPACBP.HNMDPGKPLNK(NDPMDKGJAFH["offerType"]);
			jPMLOCNCEGO.OKMNFHNBMFA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["title"], string.Empty);
			if (NDPMDKGJAFH["button"] != null)
			{
				jPMLOCNCEGO.KPKHDEMIEJK = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["button"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.KPKHDEMIEJK = string.Empty;
			}
			if (NDPMDKGJAFH["description"] != null)
			{
				jPMLOCNCEGO.JPCIACBHGHO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["description"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.JPCIACBHGHO = string.Empty;
			}
			if (NDPMDKGJAFH["otherInfo"] != null)
			{
				if (jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.DogtagRefill)
				{
					JToken jToken = NDPMDKGJAFH["otherInfo"];
					int jJBHBKCGLGK = KHJJFPPACBP.HNMDPGKPLNK(jToken["DogTagSeconds"]);
					int bBPAMDDFNDM = KHJJFPPACBP.HNMDPGKPLNK(jToken["DogTagLastUpdate"]);
					int oHOCBKNLCLD = KHJJFPPACBP.HNMDPGKPLNK(jToken["DogtagRefill"]);
					Singleton<DogTagManager>.instance.KCLNCPAGAKG(jJBHBKCGLGK, bBPAMDDFNDM, oHOCBKNLCLD, jPMLOCNCEGO.CJJHPGFOHCH);
				}
				else if (jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.PurchasesFreeAddAll || jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.PurchasesFreeAddOne || jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.PurchasesFreeAddCategory || jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.PurchaseGiftAfter)
				{
					jPMLOCNCEGO.JKACLINPIGD = new Dictionary<string, string>();
					foreach (JToken item in NDPMDKGJAFH["otherInfo"].AsJEnumerable())
					{
						if (item is JProperty)
						{
							JProperty jProperty = item as JProperty;
							jPMLOCNCEGO.JKACLINPIGD.Add(jProperty.Name, KHJJFPPACBP.BKFCLMMJNHK(jProperty.Value, string.Empty));
						}
					}
				}
				else
				{
					jPMLOCNCEGO.NCKBCFBJNBA = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["otherInfo"], string.Empty);
				}
			}
			else
			{
				jPMLOCNCEGO.NCKBCFBJNBA = string.Empty;
			}
			if (NDPMDKGJAFH["bigURL"] != null)
			{
				jPMLOCNCEGO.MODHHKHPHOJ = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["bigURL"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.MODHHKHPHOJ = string.Empty;
			}
			if (NDPMDKGJAFH["smallURL"] != null)
			{
				jPMLOCNCEGO.CICDGFDHBDO = KHJJFPPACBP.BKFCLMMJNHK(NDPMDKGJAFH["smallURL"], string.Empty);
			}
			else
			{
				jPMLOCNCEGO.CICDGFDHBDO = string.Empty;
			}
			return jPMLOCNCEGO;
		}
		return null;
	}

	private bool OBLFKLGHFCE()
	{
		int num = FABOAIMLLOI;
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			int num2 = 1 << (int)behaviour.unitType;
			if (FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatBuy && (num2 & num) > 0 && behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgrade || FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostType || FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeType) && (num2 & num) > 0 && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.ArmyScreenTypeFlatUpgradeBuy && (num2 & num) > 0 && (behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatBuy && behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed)
			{
				return true;
			}
			if ((FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgrade || FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryCostAll || FJLBLLLEELD == JANNFNFOIEE.ArmyDeliveryTimeAll) && behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)
			{
				return true;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.ArmyScreenFlatUpgradeBuy && (behaviour.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.NotBuyed || (behaviour.upgradeSlots.bought && behaviour.upgradeSlots.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}

	public static JPMLOCNCEGO JNHIECOHDFL(int NOCEDALFEJM = 0)
	{
		JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
		jPMLOCNCEGO.INFLHPGMEOB = NOCEDALFEJM.ToString("'ID'0");
		jPMLOCNCEGO.OKMNFHNBMFA = NOCEDALFEJM.ToString("'Offer '0");
		jPMLOCNCEGO.JPCIACBHGHO = ((NOCEDALFEJM != 0) ? "Description!!!!!!! Motherfuckers :-)" : string.Empty);
		jPMLOCNCEGO.KPKHDEMIEJK = ((NOCEDALFEJM != 1) ? "BYATCH" : "GO TO OFFER");
		jPMLOCNCEGO.CJJHPGFOHCH = ((NOCEDALFEJM != 3) ? (Singleton<BeanstalkServerManager>.instance.currentTimestamp + 3600) : 0);
		jPMLOCNCEGO.DBOLKNNJGMH = 60 - NOCEDALFEJM;
		switch (NOCEDALFEJM)
		{
		case 0:
			jPMLOCNCEGO.MODHHKHPHOJ = "http://www.about-fun.com/img/game-war-third-bg.jpg";
			break;
		case 1:
			jPMLOCNCEGO.MODHHKHPHOJ = "http://www.imgawards.com/wp-content/uploads/2015/12/Cover-Winter_WarFriends.png";
			break;
		default:
			jPMLOCNCEGO.MODHHKHPHOJ = "http://a4.mzstatic.com/eu/r30/Purple111/v4/30/72/db/3072db24-2849-d8a8-cdf4-739c12e46a00/screen520x924.jpeg";
			break;
		}
		jPMLOCNCEGO.CICDGFDHBDO = jPMLOCNCEGO.MODHHKHPHOJ;
		jPMLOCNCEGO.FJLBLLLEELD = (JANNFNFOIEE)(NOCEDALFEJM + 12);
		if (jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.ArmyScreenUnitOneUpgradeBuy)
		{
			jPMLOCNCEGO.NCKBCFBJNBA = "Google2u.DBUpgradeSlotsCar";
		}
		if (jPMLOCNCEGO.FJLBLLLEELD == JANNFNFOIEE.WeaponScreenSlotFlatBuy)
		{
			jPMLOCNCEGO.NCKBCFBJNBA = "Primary";
		}
		jPMLOCNCEGO.MJPOBONOBCD = true;
		return jPMLOCNCEGO;
	}

	private bool FNOLDMFNDHM()
	{
		int num = FABOAIMLLOI;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			int bHCEOOLEHHG = (int)weaponLevelsSetup.BHCEOOLEHHG;
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-45) || FJLBLLLEELD == (JANNFNFOIEE)(-45)) && (bHCEOOLEHHG & num) > 0 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				return false;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-81) || FJLBLLLEELD == (JANNFNFOIEE)(-78) || FJLBLLLEELD == (JANNFNFOIEE)(-128) || FJLBLLLEELD == (JANNFNFOIEE)84 || FJLBLLLEELD == JANNFNFOIEE.PurchaseGiftAfter || FJLBLLLEELD == (JANNFNFOIEE)(-52)) && (bHCEOOLEHHG & num) > 1 && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return false;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-4) || FJLBLLLEELD == JANNFNFOIEE.VIPOne) && (bHCEOOLEHHG & num) > 0 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)84 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				return true;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)72 || FJLBLLLEELD == (JANNFNFOIEE)76 || FJLBLLLEELD == (JANNFNFOIEE)(-125)) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return false;
			}
			if (FJLBLLLEELD == JANNFNFOIEE.WeaponDeliveryTimeSlot && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
		}
		return true;
	}

	public static JPMLOCNCEGO IDEAFEPKJAB()
	{
		JPMLOCNCEGO jPMLOCNCEGO = new JPMLOCNCEGO();
		jPMLOCNCEGO.INFLHPGMEOB = "LOOTBOXDISCOUNT";
		jPMLOCNCEGO.OKMNFHNBMFA = "LOOTBOXES DISCOUNTED";
		jPMLOCNCEGO.JPCIACBHGHO = "Buy as many as you can";
		jPMLOCNCEGO.KPKHDEMIEJK = "GO TO WARSHOP";
		jPMLOCNCEGO.CJJHPGFOHCH = Singleton<BeanstalkServerManager>.instance.currentTimestamp + 3600;
		jPMLOCNCEGO.DBOLKNNJGMH = 20;
		jPMLOCNCEGO.MODHHKHPHOJ = "https://i.ytimg.com/vi/U6Da9jKbXu0/hqdefault.jpg";
		jPMLOCNCEGO.CICDGFDHBDO = jPMLOCNCEGO.MODHHKHPHOJ;
		jPMLOCNCEGO.FJLBLLLEELD = JANNFNFOIEE.WarshopLootboxesFlat;
		jPMLOCNCEGO.MJPOBONOBCD = false;
		return jPMLOCNCEGO;
	}

	private bool JBBJDMOLOPO()
	{
		int num = FABOAIMLLOI;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			int bHCEOOLEHHG = (int)weaponLevelsSetup.BHCEOOLEHHG;
			if ((FJLBLLLEELD == (JANNFNFOIEE)92 || FJLBLLLEELD == JANNFNFOIEE.WeaponScreenWeaponOneUpgradeBuy) && (bHCEOOLEHHG & num) > 0 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				return false;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)117 || FJLBLLLEELD == (JANNFNFOIEE)(-76) || FJLBLLLEELD == (JANNFNFOIEE)62 || FJLBLLLEELD == (JANNFNFOIEE)90 || FJLBLLLEELD == (JANNFNFOIEE)91 || FJLBLLLEELD == (JANNFNFOIEE)(-35)) && (bHCEOOLEHHG & num) > 0 && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return false;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-97) || FJLBLLLEELD == (JANNFNFOIEE)(-40)) && (bHCEOOLEHHG & num) > 0 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)99 && weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				return true;
			}
			if ((FJLBLLLEELD == (JANNFNFOIEE)(-60) || FJLBLLLEELD == (JANNFNFOIEE)84 || FJLBLLLEELD == (JANNFNFOIEE)115) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)
			{
				return false;
			}
			if (FJLBLLLEELD == (JANNFNFOIEE)59 && (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || (weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded)))
			{
				return true;
			}
		}
		return false;
	}
}
