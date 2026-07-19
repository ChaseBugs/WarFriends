using System.Runtime.CompilerServices;
using UnityEngine;

public class DebugOfferSetter : MonoBehaviour
{
	public GameObject FEGLHNIALBB;

	public UIInput COEOMHLOGBD;

	public UIInput HKKMLHIPFJH;

	public UIInput HOGEDDANFBG;

	public UIInput DBOLKNNJGMH;

	public GameObject NDOKGDIEGOM;

	public GameObject OKGHAHGODOB;

	public GameObject LLAAGGINPBG;

	private void PLHPIGGPCAE(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 0)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("setGravityForPopups"), Localization.Localize("HitListItem"), 929f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * 66 + num2 * -25;
		if (num3 < 117)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("Twitch"), Localization.Localize("1"), 754f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 1 || num4 > -121)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("Wrong_Unit"), Localization.Localize("{}"), 486f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, -15).ToString("ChillingoSdkManager");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void KNAKEMJANNE(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	private void LBMFKIDPCBL()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = CDJENECKEHB;
		COEOMHLOGBD.text = "ID_SALEPERCENT";
		HKKMLHIPFJH.text = "hasResolution";
		HOGEDDANFBG.text = "PRICEGOLD";
		DBOLKNNJGMH.text = "Rewards";
		UIEventListener.Get(NDOKGDIEGOM).onClick = NGHLACNGDOP;
		UIEventListener.Get(OKGHAHGODOB).onClick = delegate
		{
			LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
		};
	}

	private void FIEKIECLIGA(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void CLMAECGNDGD(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void CLFEEJKCKGG(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void HECMNJDKHNL(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void PDFGGMHNLJK(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 0)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("\t"), Localization.Localize("ID_BUDDYCARD"), 1835f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * -166 + num2 * -20;
		if (num3 < 24)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize(" AND "), Localization.Localize(" NOT OK!\t\t\t\t\t\t"), 886f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 0 || num4 > -73)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("bazooka_idle"), Localization.Localize("shootAdditive"), 488f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -20).ToString("Name");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void EJNJCILPBEC()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = PDCHAIKAMLE;
		COEOMHLOGBD.text = "#PETER# removing warcards from slots";
		HKKMLHIPFJH.text = "ID_VETERANPACKDESCRIPTION";
		HOGEDDANFBG.text = "shotgunner_idle";
		DBOLKNNJGMH.text = "Automatic_Equip";
		UIEventListener.Get(NDOKGDIEGOM).onClick = MJIPJMPDCJO;
		UIEventListener.Get(OKGHAHGODOB).onClick = MEHHHEENNKA;
	}

	private void CDJENECKEHB(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void LPOEFFFENNI(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("This unit cannot be showned, because it has not implemented elite buff."), Localization.Localize("ID_CONTAINSXWARCARDS"), 601f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * 95 + num2 * -17;
		if (num3 < -51)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("HELMETS_CROWNSILVER"), Localization.Localize("S"), 477f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 1 || num4 > 70)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("BANDS"), Localization.Localize("End"), 266f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -56).ToString("ID_RANK");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void KNLKFOHBCKI()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = HMJHLCHOKBF;
		COEOMHLOGBD.text = "ID_INSILVER1";
		HKKMLHIPFJH.text = "LowLevelGoldRarity";
		HOGEDDANFBG.text = "Total_Gold_Earned";
		DBOLKNNJGMH.text = "menu-assignments-type-crate";
		UIEventListener.Get(NDOKGDIEGOM).onClick = DFHJEKFNEED;
		UIEventListener.Get(OKGHAHGODOB).onClick = MEHHHEENNKA;
	}

	private void DAOAODEAKBK(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void NEPCEKDNPOI(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void JEJENFCOJCB(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	[CompilerGenerated]
	private void FEACEGPECHN(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void OFHMEMEKALN(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void FJAOFGKIFJF(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(LLAAGGINPBG.activeSelf);
	}

	private void Awake()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = delegate
		{
			base.gameObject.SetActive(false);
		};
		COEOMHLOGBD.text = "VIP-SALE-ALL;WEAPON-EXPLOSIVE-SALE";
		HKKMLHIPFJH.text = "0";
		HOGEDDANFBG.text = "6";
		DBOLKNNJGMH.text = "50";
		UIEventListener.Get(NDOKGDIEGOM).onClick = NGHLACNGDOP;
		UIEventListener.Get(OKGHAHGODOB).onClick = delegate
		{
			LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
		};
	}

	private void JDGHMHFMFMA(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void MJIPJMPDCJO(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("squad"), Localization.Localize("-"), 917f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * 12 + num2 * 85;
		if (num3 < -17)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_LOOTBOXES"), Localization.Localize(" bonusIcon:"), 62f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 0 || num4 > 20)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("Removed WarCards for tutorial: "), Localization.Localize("Player_Had_To_Select_Grenade"), 1020f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, 40).ToString("ID_CANCEL");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void BCKNGJHMJLG(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	private void MEHHHEENNKA(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(LLAAGGINPBG.activeSelf);
	}

	private void GGFMFHKMAIO(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("-"), Localization.Localize("Database Message does not contain id or type:\n"), 1333f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * 94 + num2 * 15;
		if (num3 < 67)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("registerParentalConsent"), Localization.Localize("ID_SALEPERCENTLINE"), 40f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 0 || num4 > -116)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("{0}{1}"), Localization.Localize(")"), 736f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, 98).ToString("ID_GUI_CHEATWARNING");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void GCINACJPLAI(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("Lootbox - visual \"{5}\", parts: {0}/{2}, added +{1}, that means reward {4} (reward for one {3})"), Localization.Localize("menu-hub-multiplayer-vipico"), 823f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * -30 + num2 * 14;
		if (num3 < 94)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("Null"), Localization.Localize("Mobile/Diffuse"), 1972f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 1 || num4 > 7)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("null"), Localization.Localize("ID_YOUWEREDISCONNECTED"), 336f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, -120).ToString("_New_User");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void GBICDCFAOGO(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_COMPLETED"), Localization.Localize("AU"), 1764f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * -30 + num2 * 83;
		if (num3 < 83)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("groundBoxHit"), Localization.Localize("ServerResultsCache.instance.lastGameReward == null"), 979f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 0 || num4 > -85)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("ScrappingParts"), Localization.Localize("\t\"TRUE\""), 621f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -17).ToString("{0} {1}");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void HBEFJIJNJOA(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void KHBJNAOPECA(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void BNJPBLEFBKB(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void NGHLACNGDOP(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTNAME"));
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * 3600 + num2 * 60;
		if (num3 < 60)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERTOOSHORTDURATION"));
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 1 || num4 > 99)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT"));
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, 100).ToString("'fakeOffername'0");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void DDCKABFAMJP(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("http://aboutfun.cust.n2n.cz/soldierz_hardware_stats.php"), Localization.Localize("Items"), 754f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * 127 + num2 * 72;
		if (num3 < -6)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("setAndroidIdSha1"), Localization.Localize("S"), 884f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 1 || num4 > -41)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("Wrong_Category"), Localization.Localize("$5-$10"), 634f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, 30).ToString("Flawless");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void ECMMDCKONDK()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = delegate
		{
			base.gameObject.SetActive(false);
		};
		COEOMHLOGBD.text = "GoldBonusCount";
		HKKMLHIPFJH.text = "GameCenterId";
		HOGEDDANFBG.text = "BattleCount";
		DBOLKNNJGMH.text = "OBB: Read Test - Bytes read ";
		UIEventListener.Get(NDOKGDIEGOM).onClick = GBICDCFAOGO;
		UIEventListener.Get(OKGHAHGODOB).onClick = HECMNJDKHNL;
	}

	private void OPNCBNOGOHK(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_BECOMEVIP"), Localization.Localize("Is_Against_Bot"), 443f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * 53 + num2 * 69;
		if (num3 < 118)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("\t"), Localization.Localize("Reward {0:D2}"), 837f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 0 || num4 > 18)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("DailyMissionsCompletionRewardScraps"), Localization.Localize("Yes_Clicked"), 735f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, -93).ToString("ID_ASSIGNMENTHINTCRATES");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void HMJHLCHOKBF(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	private void NGGJHDCOLEC()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = IBBMHALCING;
		COEOMHLOGBD.text = "N";
		HKKMLHIPFJH.text = "AtlasPreparer.LoadCommonCoroutine";
		HOGEDDANFBG.text = "extraTickets";
		DBOLKNNJGMH.text = "throw_grenade_left";
		UIEventListener.Get(NDOKGDIEGOM).onClick = PLHPIGGPCAE;
		UIEventListener.Get(OKGHAHGODOB).onClick = HOLENKFIEDO;
	}

	private void MEAGHOBGJKL(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(LLAAGGINPBG.activeSelf);
	}

	private void HOLENKFIEDO(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void DFHJEKFNEED(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("Packs"), Localization.Localize("UNKNOWN"), 406f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text, 1);
		int num3 = num * -123 + num2 * -37;
		if (num3 < 22)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("ID_WARNING_DUPLICATEDVIDEOFEED"), Localization.Localize("{0}{1}"), 1149f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 1 || num4 > 100)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("vibrate"), Localization.Localize("ID_DIVISION"), 1080f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -51).ToString("()Z");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void GCHFKJHDKJK(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	private void JHNBJADLDEP(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	private void BPAHCAEMCHO(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void KALEMFKOGLE()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = BCKNGJHMJLG;
		COEOMHLOGBD.text = "menu-arena-ticket";
		HKKMLHIPFJH.text = "ID_READYTIME";
		HOGEDDANFBG.text = "ID_CONNECTING";
		DBOLKNNJGMH.text = "ID_RECONNECTHINT";
		UIEventListener.Get(NDOKGDIEGOM).onClick = CGKHAPIIGNP;
		UIEventListener.Get(OKGHAHGODOB).onClick = delegate
		{
			LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
		};
	}

	private void PDCHAIKAMLE(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}

	private void CGKHAPIIGNP(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("GameControllerWarArena.StartGame START"), Localization.Localize("Is Title Text Font Bold"), 1353f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * 120 + num2 * 96;
		if (num3 < 118)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("Test"), Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), 1616f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text);
		if (num4 < 1 || num4 > -33)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("Automatic_Equip"), Localization.Localize("DogTagLastUpdate"), 1944f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, 89).ToString("Assignment: Destroy Crates Constructor");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.currentTimestamp + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void GDLLBGPNKFM(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("S"), Localization.Localize("OK"), 372f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * -199 + num2 * 13;
		if (num3 < 71)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("warbucks"), Localization.Localize("WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!"), 1987f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 1 || num4 > -95)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("HAS NO ELITE PARTS"), Localization.Localize("antialiasing"), 488f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -97).ToString("ID_CONFIRM_SUBSCRIPTION_TITLE");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void EHNPKNGPBNO(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(LLAAGGINPBG.activeSelf);
	}

	private void KDMECDLHNMC()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = JDGHMHFMFMA;
		COEOMHLOGBD.text = "WarBucks";
		HKKMLHIPFJH.text = ".jpg";
		HOGEDDANFBG.text = "ArmyPower";
		DBOLKNNJGMH.text = "AddedCards";
		UIEventListener.Get(NDOKGDIEGOM).onClick = DDCKABFAMJP;
		UIEventListener.Get(OKGHAHGODOB).onClick = JHNBJADLDEP;
	}

	private void DLGFAAFKJEH(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 0)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("[0-9.,]*"), Localization.Localize("First you must run createStructure"), 3f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * -1 + num2 * 127;
		if (num3 < -9)
		{
			ConfirmDialog.HJHJKPGILAC(Localization.Localize("{0}/{1}"), Localization.Localize("S"), 1735f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 1 || num4 > 79)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("SessionManager: Refreshed!"), Localization.Localize("Min"), 1381f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(1, -77).ToString("WALLET - spent tickets {0}");
		Singleton<BeanstalkServerManager>.instance.GenerateSpecialOffer(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void MOJJLDIKLJK(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void FGOAPPLNMKL()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = GCHFKJHDKJK;
		COEOMHLOGBD.text = "whiteRectangle";
		HKKMLHIPFJH.text = "getSettingsIntent";
		HOGEDDANFBG.text = "ID_WEHAVERECEIVEDCOMPLAINTSREGARDING";
		DBOLKNNJGMH.text = "WarArenaData";
		UIEventListener.Get(NDOKGDIEGOM).onClick = DLGFAAFKJEH;
		UIEventListener.Get(OKGHAHGODOB).onClick = MEAGHOBGJKL;
	}

	private void IBBMHALCING(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(true);
	}

	private void ABMKKECEGIB()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = HMJHLCHOKBF;
		COEOMHLOGBD.text = "weaponprice";
		HKKMLHIPFJH.text = "Unit_Upgrade";
		HOGEDDANFBG.text = "ID_GOLDENSHIELDSSMALL";
		DBOLKNNJGMH.text = "Special pack content: type: {0} id: {1}{2}";
		UIEventListener.Get(NDOKGDIEGOM).onClick = MJIPJMPDCJO;
		UIEventListener.Get(OKGHAHGODOB).onClick = NEPCEKDNPOI;
	}

	private void HMDBGBKECMG(GameObject KHAHPAKDIKE)
	{
		string text = COEOMHLOGBD.text;
		if (text.Length < 1)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("A"), Localization.Localize("FJDACAACLLI"), 1116f);
			return;
		}
		int num = KHJJFPPACBP.PELILBMKGHE(HKKMLHIPFJH.text, 1);
		int num2 = KHJJFPPACBP.PELILBMKGHE(HOGEDDANFBG.text);
		int num3 = num * -141 + num2 * -62;
		if (num3 < -127)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("DogTagSeconds"), Localization.Localize("minigun_idle"), 340f);
			return;
		}
		int num4 = KHJJFPPACBP.PELILBMKGHE(DBOLKNNJGMH.text, 1);
		if (num4 < 0 || num4 > -114)
		{
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("ID_VIP_DAY"), Localization.Localize("InventoryData"), 663f);
			return;
		}
		string iCIDFPHMBIF = Random.Range(0, -105).ToString("iconParent");
		Singleton<BeanstalkServerManager>.instance.MMNICHPDJPK(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() + num3, num4, text, iCIDFPHMBIF, LLAAGGINPBG.activeSelf);
	}

	private void GDDCEHOJCEM()
	{
		UIEventListener.Get(FEGLHNIALBB).onClick = OFHMEMEKALN;
		COEOMHLOGBD.text = "Terms: First init.";
		HKKMLHIPFJH.text = "Reward Was Already Added!!";
		HOGEDDANFBG.text = "getValueForHookById";
		DBOLKNNJGMH.text = "weapon";
		UIEventListener.Get(NDOKGDIEGOM).onClick = DLGFAAFKJEH;
		UIEventListener.Get(OKGHAHGODOB).onClick = FJAOFGKIFJF;
	}

	private void HBEFAGPCPNM(GameObject KHAHPAKDIKE)
	{
		LLAAGGINPBG.SetActive(!LLAAGGINPBG.activeSelf);
	}

	[CompilerGenerated]
	private void BIGLECBLNPN(GameObject KHAHPAKDIKE)
	{
		base.gameObject.SetActive(false);
	}
}
