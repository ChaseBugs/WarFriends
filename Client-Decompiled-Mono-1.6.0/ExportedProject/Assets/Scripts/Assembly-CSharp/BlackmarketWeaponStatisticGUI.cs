using System.Collections.Generic;
using UnityEngine;

public class BlackmarketWeaponStatisticGUI : Core_BaseScript
{
	[SerializeField]
	[Header("Left")]
	private UISprite mStatIcon;

	[SerializeField]
	[Header("Middle")]
	private UISprite mProgressWhite;

	[SerializeField]
	private UISprite mProgressBlue;

	[SerializeField]
	private UILabel mMaxStatNumber;

	[SerializeField]
	private UILabel mStatNumber;

	[SerializeField]
	private UILabel mCompareNumber;

	[SerializeField]
	private UISprite mCompareMarker;

	private string HJKFEJECBBF(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private string NHOGKIFDGIG(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void FDPBHCFLBII(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[0];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("SendLogs", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 1047f, 1539f, 28);
	}

	private void CILILGGFIFG(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 909f;
		mProgressBlue.fillAmount = 1484f;
		mProgressBlue.color = Colours.goldUpgrade;
		FKBNCMPBLOA(string.Empty);
		mStatNumber.text = NPLLLDBOFFG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void IGEFMGGGOKP(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.NKNOPGAOFKA();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_LOOTDUPLICATEONE" || tuple.Value1 == "\"{0}\"\t";
		bool flag2 = tuple.Value1 == "GameLauncher.Async" || tuple.Value1 == "{0}{1}";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[5] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? KPKOBGEBBMD(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 292f)
		{
			num2 = 1371f;
		}
		if (flag && num == 597f)
		{
			num = 77f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(485f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DMANIDFOAIN(num, flag);
			}
			else
			{
				KDIOPMAFIGI(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "facebookFriends") && tuple2.Value1 == "{0} {1}";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && (!flag2 || flag3);
		BCCNFIEBJNJ(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void IGCCBAMJJLG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFNIJHBGNDH(LFDFAGMGFCF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NJJAMBCONHC(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void EOMCJCJAEPK(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FKBNCMPBLOA(CBMKLDPOPDM(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = CBMKLDPOPDM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void KDIOPMAFIGI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GMCBBBAAGJO(HJKFEJECBBF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HJKFEJECBBF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void NFDKMDJNIEN(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[1];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("INVALID_ACCOUNT", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 872f, 1041f, -85);
	}

	public void HGCDFJNMCPI(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.NKGNPLBFFAC();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT") && tuple.Value1 == "Country";
		bool flag2 = tuple.Value1 == "ID_CONFIRM_EXITINGCOOP" || tuple.Value1 == "menu-arena-ticket";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[7] : LevelManager.instance.DamageFunction(tuple.Value2[3]));
		float num3 = ((!flag2) ? DCILMNDKLJI(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(NMLKOJFEBOI(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1565f)
		{
			num2 = 1980f;
		}
		if (flag && num == 1238f)
		{
			num = 1790f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(575f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				BFFINGAALKB(num, flag);
			}
			else
			{
				IHMCLIIFHDF(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "getCampaignId" || tuple2.Value1 == "ID_WARSHOP_GOLD";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || (!(tuple2.Value1 == tuple.Value1) && flag2 && flag3);
		JNOKHNPOKMF(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void OJOPBKMBDIJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		AOJLBAJJHDK(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 762f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void HCCDHJAEBMK(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[0];
			array[0] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("ID_HEALTH", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 43f, 947f, -110);
	}

	private void PCFNELBCBBI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		EJEIICGCOBF(JHJHGHKMPFJ(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void EKPDCEECNEP(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GFEHEEMDGNG(LFDFAGMGFCF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = JHJHGHKMPFJ(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1507f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void BKDOJODDMFJ(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 893f;
		mProgressBlue.fillAmount = 291f;
		mProgressBlue.color = Colours.goldUpgrade;
		EJEIICGCOBF(string.Empty);
		mStatNumber.text = IIMEIKNLOCE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	public void IMOLCHNMGBM(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "SubscriptionBought" || tuple.Value1 == ")";
		bool flag2 = tuple.Value1 == "Buy_Rental_Power_Band_Gold" || tuple.Value1 == "ID_WARNING_OFFEREXPIRED_TEXT";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[6] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		float num3 = ((!flag2) ? EKKDNFGOAMD(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ICAOINNLFID(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1576f)
		{
			num2 = 1372f;
		}
		if (flag && num == 753f)
		{
			num = 486f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(1639f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				EEAGMMKCLEG(num, flag);
			}
			else
			{
				CHEFMCMCJDA(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "Can not find asset {0}") && tuple2.Value1 == "CAUGHT AN MISSION EXCEPTION ";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && (!flag2 || flag3);
		JPHJJCFLALE(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	public void HCINKMDCPLN(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "registerCustomProfileString" || tuple.Value1 == "dd/M/yyyy";
		bool flag2 = !(tuple.Value1 == "MatchStart") && tuple.Value1 == "ID_WARNING_CANNOTCREATESQUAD_TEXT";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[6]));
		float num3 = ((!flag2) ? COKGPOMCPJM(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(DCILMNDKLJI(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1512f)
		{
			num2 = 800f;
		}
		if (flag && num == 1755f)
		{
			num = 1045f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(983f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				GJPHOJHDKJF(num, flag);
			}
			else
			{
				JIGNLBJGJEG(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "weapon doesnt have ammo setup") && tuple2.Value1 == "InstantBattleEnded: Paid Instant Battles = ";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && (!flag2 || flag3);
		BCCNFIEBJNJ(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void GJPHOJHDKJF(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1119f;
		mProgressBlue.fillAmount = 778f;
		mProgressBlue.color = Colours.goldUpgrade;
		FKBNCMPBLOA(string.Empty);
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private float KCHKLOPJOHF(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 227f : 653f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.DHEEPGEEIEN()[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	public void KGGODLIMAGA(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "WarFriends demande l'autorisation d'accéder à votre média de stockage afin de télécharger des données essentielles au jeu.Sans cette autorisation, le jeu ne pourra pas fonctionner et va fermer. Veuillez réessayer ou quitter WarFriends.") && tuple.Value1 == ")";
		bool flag2 = !(tuple.Value1 == "+{0}") && tuple.Value1 == "ID_THATWASGOODRUNSOLDIER0WINS";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[6] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		float num3 = ((!flag2) ? KPKOBGEBBMD(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ICAOINNLFID(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 858f)
		{
			num2 = 359f;
		}
		if (flag && num == 1104f)
		{
			num = 307f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(1295f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DMANIDFOAIN(num, flag);
			}
			else
			{
				EOMCJCJAEPK(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "WinLooseStreak") && tuple2.Value1 == "Walk";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && flag2 && flag3;
		BCCNFIEBJNJ(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void EFLOPHFMHFE(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFEHEEMDGNG(KFCKBJJIHPM(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void AFHBDKJJBCI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		AOJLBAJJHDK(NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HJKFEJECBBF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void LKMFGKNKNEI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GFEHEEMDGNG(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1235f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void DCHJGFAIMMC(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	public void JHEDPOHOPHH(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> guiStatistics = JMMJHCOKCGG.MGAGEKAAJOL.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "ID_DAYSAGO") && tuple.Value1 == "Id";
		bool flag2 = !(tuple.Value1 == "Id") && tuple.Value1 == "Lcom/google/android/gms/games/request/Requests;";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[3] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		float num3 = ((!flag2) ? FEGKKKLGODO(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ILBAGMDGDNF(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1589f)
		{
			num2 = 857f;
		}
		if (flag && num == 1636f)
		{
			num = 1997f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(273f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				OPLBNDBHJPK(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKGNPLBFFAC()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "Refresh_Level") && tuple2.Value1 == "game-card-ico-backstab";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || (!(tuple2.Value1 == tuple.Value1) && flag2 && flag3);
		JPHJJCFLALE(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void PCLBHLCGACN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 73f;
		mProgressBlue.fillAmount = 1466f;
		mProgressBlue.color = Colours.goldUpgrade;
		EJEIICGCOBF(string.Empty);
		mStatNumber.text = CBMKLDPOPDM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void KEBNFCALOAD(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FKBNCMPBLOA(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	public void InitializeStat(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> guiStatistics = JMMJHCOKCGG.MGAGEKAAJOL.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_SLOTUPGRADE_ROF" || tuple.Value1 == "ID_SLOTUPGRADE_HEAT";
		bool flag2 = tuple.Value1 == "ID_SLOTUPGRADE_POWER" || tuple.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		float num3 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 0f)
		{
			num2 = 1f;
		}
		if (flag && num == 0f)
		{
			num = 1f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(0.85f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				PJALMHPEHMN(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_SLOTUPGRADE_POWER" || tuple2.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || (flag2 && flag3));
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private string CBMKLDPOPDM(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void OPDGBEBAOJI(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 44f;
		mProgressBlue.fillAmount = 1532f;
		mProgressBlue.color = Colours.goldUpgrade;
		NFDKMDJNIEN(string.Empty);
		mStatNumber.text = LFDFAGMGFCF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void NGAOKCIFNPP(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFEHEEMDGNG(IIMEIKNLOCE(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void LOPCCJAHEHA(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FKBNCMPBLOA(HHFEDOENEIP(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = LFDFAGMGFCF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 610f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void GFEHEEMDGNG(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[0];
			array[0] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("enemy point is not free", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 278f, 1687f, -37);
	}

	private void IHMCLIIFHDF(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FDPBHCFLBII(PKGIGFICHHG(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void HGAGMKOEHOD(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GFEHEEMDGNG(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HHFEDOENEIP(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 721f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private string JHJHGHKMPFJ(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void BGDMEBEPFHN(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FDPBHCFLBII(HHFEDOENEIP(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = IIMEIKNLOCE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 394f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void DGKIMDKDAHF(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFEHEEMDGNG(PKGIGFICHHG(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void LDDIIFMJLNN(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> guiStatistics = JMMJHCOKCGG.MGAGEKAAJOL.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "ID_WARNING_OFFEREXPIRED_TEXT") && tuple.Value1 == "ID_CATEGORY_LOW_PL_PRIMARY";
		bool flag2 = !(tuple.Value1 == "ID_SKILLSHOTHINT_ARMYKILL") && tuple.Value1 == "MessageId";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		float num3 = ((!flag2) ? ICAOINNLFID(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(BJAMLELPFHB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1782f)
		{
			num2 = 1055f;
		}
		if (flag && num == 1941f)
		{
			num = 265f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(1663f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				CILILGGFIFG(num, flag);
			}
			else
			{
				KDIOPMAFIGI(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKGNPLBFFAC()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "[-]") && tuple2.Value1 == "-{0}-{1}";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && flag2 && flag3;
		BGDMEBEPFHN(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void IDOCCGNLLCN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1942f;
		mProgressBlue.fillAmount = 61f;
		mProgressBlue.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		mStatNumber.text = HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private float JCDFMFBPAAB(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? float.MinValue : float.MaxValue);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.guiStatistics[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void HHLIOIKLFFE(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		HCCDHJAEBMK(NHOGKIFDGIG(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = LFDFAGMGFCF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void PBPLFODKPBI(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "InAppHandlerIos: Purchase failed! " || tuple.Value1 == "height";
		bool flag2 = !(tuple.Value1 == "ID_GUI_LIKEFB_NOW") && tuple.Value1 == "damage";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[3] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		float num3 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ICAOINNLFID(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 241f)
		{
			num2 = 18f;
		}
		if (flag && num == 421f)
		{
			num = 1200f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(1248f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				BKDOJODDMFJ(num, flag);
			}
			else
			{
				KDIOPMAFIGI(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "OnAdClickedWithURL()") && tuple2.Value1 == "account";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		BCCNFIEBJNJ(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void GMCBBBAAGJO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			mMaxStatNumber.text = Localization.LocalizeFormat("ID_MAXSTAT", ECPOBELNKOO);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 25f, 20f, 180);
	}

	private void CICFLPBDGDH(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 932f;
		mProgressBlue.fillAmount = 267f;
		mProgressBlue.color = Colours.goldUpgrade;
		GFNIJHBGNDH(string.Empty);
		mStatNumber.text = JHJHGHKMPFJ(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void IAGABPPBOEB(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "defendPosition" || tuple.Value1 == "BoughtIndex";
		bool flag2 = tuple.Value1 == "ID_INVITATIONDENIED" || tuple.Value1 == "GameCenterId";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		float num3 = ((!flag2) ? NMLKOJFEBOI(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(FEGKKKLGODO(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1281f)
		{
			num2 = 1693f;
		}
		if (flag && num == 852f)
		{
			num = 287f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(789f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DDEIBBDOJAJ(num, flag);
			}
			else
			{
				DGKIMDKDAHF(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.DHEEPGEEIEN()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "[CardHealthChangeUnit] - used again after spawning start, but before finish!!!") && tuple2.Value1 == "ID_INELITE1";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || (!(tuple2.Value1 == tuple.Value1) && flag2 && flag3);
		JNOKHNPOKMF(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void CHEFMCMCJDA(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FDPBHCFLBII(HODBOCBJMJD(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void EEAGMMKCLEG(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1692f;
		mProgressBlue.fillAmount = 1448f;
		mProgressBlue.color = Colours.goldUpgrade;
		FKBNCMPBLOA(string.Empty);
		mStatNumber.text = NPLLLDBOFFG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private string EJCNNBKLADB(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void KFLGMFCBFKC(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GMCBBBAAGJO(CBMKLDPOPDM(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void BLBNFLOHPOE(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 357f;
		mProgressBlue.fillAmount = 747f;
		mProgressBlue.color = Colours.goldUpgrade;
		NFDKMDJNIEN(string.Empty);
		mStatNumber.text = LOIKIMOOMOI(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void JBIPDGBOPGJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FKBNCMPBLOA(NJJAMBCONHC(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 597f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	public void ADHIPKKPBOB(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "WALLET - reward WB {0} animate:{1}") && tuple.Value1 == "country-slovenia";
		bool flag2 = !(tuple.Value1 == "GamesPlayed()") && tuple.Value1 == "ID_ARENARULES_UNBREAKABLESHIELDS";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[6]));
		float num3 = ((!flag2) ? NMLKOJFEBOI(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(DCILMNDKLJI(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 59f)
		{
			num2 = 1271f;
		}
		if (flag && num == 1912f)
		{
			num = 1848f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(364f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DGOGCAOEDCL(num, flag);
			}
			else
			{
				NGAOKCIFNPP(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_GUI_BEADVISED" || tuple2.Value1 == "S";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || !flag2 || flag3);
		EKPDCEECNEP(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private string LFDFAGMGFCF(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void CNKEAIEPMAB(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		AOJLBAJJHDK(HJKFEJECBBF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void DDDPFOPLMMD(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.DHEEPGEEIEN();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "PlayWindowCount") && tuple.Value1 == "ID_STAT_HANDGUNKILLS";
		bool flag2 = !(tuple.Value1 == "RETRYPERM") && tuple.Value1 == "ID_DAYS";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[7]));
		float num3 = ((!flag2) ? NMLKOJFEBOI(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(COKGPOMCPJM(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 233f)
		{
			num2 = 1575f;
		}
		if (flag && num == 1446f)
		{
			num = 429f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(119f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DMANIDFOAIN(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "null" || tuple2.Value1 == "RETRYPERM";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private string IIMEIKNLOCE(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void GFNIJHBGNDH(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[1];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("friend name", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 842f, 1238f, 53);
	}

	private string NPLLLDBOFFG(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private float COKGPOMCPJM(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 741f : 1496f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void DGOGCAOEDCL(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1095f;
		mProgressBlue.fillAmount = 120f;
		mProgressBlue.color = Colours.goldUpgrade;
		EJEIICGCOBF(string.Empty);
		mStatNumber.text = HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private float DCILMNDKLJI(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 998f : 75f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.guiStatistics[EOABNODPOLD].Value2[0];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void JPHJJCFLALE(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		NFDKMDJNIEN(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1288f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void OCHHLNDCHFL(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		AOJLBAJJHDK(HODBOCBJMJD(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = IIMEIKNLOCE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 119f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void LHOCMDJNICJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		NFDKMDJNIEN(HODBOCBJMJD(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private string PKGIGFICHHG(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private float EKKDNFGOAMD(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1936f : 1247f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.JCGBOEDOMKG()[EOABNODPOLD].Value2[0];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void OPLBNDBHJPK(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 20f;
		mProgressBlue.fillAmount = 894f;
		mProgressBlue.color = Colours.goldUpgrade;
		NFDKMDJNIEN(string.Empty);
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void LFILDMLMOMM(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FKBNCMPBLOA(NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = JHJHGHKMPFJ(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1155f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void JIGNLBJGJEG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FDPBHCFLBII(LFDFAGMGFCF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private string NJJAMBCONHC(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	public void DPPIEPOKMEG(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "Battle Start" || tuple.Value1 == "relog to different facebook";
		bool flag2 = !(tuple.Value1 == "ID_INMASTER1") && tuple.Value1 == "withPublisherSubAdgroup";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[6] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? DCILMNDKLJI(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1451f)
		{
			num2 = 1018f;
		}
		if (flag && num == 898f)
		{
			num = 899f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(419f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				CIICPLKDJIG(num, flag);
			}
			else
			{
				KEBNFCALOAD(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "NetworkReInstantiate" || tuple2.Value1 == "N";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && !(tuple2.Value1 == tuple.Value1) && flag2 && flag3;
		ILIJELHGCLP(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void JIIHOBILMNM(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFNIJHBGNDH(LFDFAGMGFCF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = HJKFEJECBBF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void GIANAHIMJHH(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	public void PFPEAGPIBPE(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_JOINSQUADDESCRIPTION3" || tuple.Value1 == "ID_OVERTIMEKILL";
		bool flag2 = !(tuple.Value1 == "menu-army-reload-ico") && tuple.Value1 == "{0} x {1}{2}[-]";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[6] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? KPKOBGEBBMD(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ILBAGMDGDNF(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1637f)
		{
			num2 = 360f;
		}
		if (flag && num == 929f)
		{
			num = 644f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(1306f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				GJPHOJHDKJF(num, flag);
			}
			else
			{
				IGCCBAMJJLG(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "com.hasoffers.unitytestapp") && tuple2.Value1 == "ResumeGameRPC";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || (flag2 && flag3));
		HGAGMKOEHOD(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private string LOIKIMOOMOI(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void PJALMHPEHMN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1f;
		mProgressBlue.fillAmount = 1f;
		mProgressBlue.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private float NMLKOJFEBOI(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 74f : 1486f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.EKKFCKDPMNI()[EOABNODPOLD].Value2[0];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void AIBDOAFOPFH(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GFEHEEMDGNG(IIMEIKNLOCE(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1236f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void CIICPLKDJIG(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1413f;
		mProgressBlue.fillAmount = 1208f;
		mProgressBlue.color = Colours.goldUpgrade;
		FDPBHCFLBII(string.Empty);
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void EJEIICGCOBF(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[0];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat(", there is more records on server than on client (records missing = ", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 1983f, 1659f, -74);
	}

	private void DANEGLCGFLO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1136f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void BCCNFIEBJNJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		AOJLBAJJHDK(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1990f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void DCLPNCNGBAA(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FKBNCMPBLOA(JHJHGHKMPFJ(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = KFCKBJJIHPM(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private string HODBOCBJMJD(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void JNOKHNPOKMF(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		NFDKMDJNIEN(HHFEDOENEIP(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = NHOGKIFDGIG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 353f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void BFFINGAALKB(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 202f;
		mProgressBlue.fillAmount = 1264f;
		mProgressBlue.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		mStatNumber.text = HHFEDOENEIP(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void AOJLBAJJHDK(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[1];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("Reward", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 100f, 1255f, 106);
	}

	public void FKBIACGBDDH(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_SALEPERCENTLINE" || tuple.Value1 == "Show squad ";
		bool flag2 = tuple.Value1 == "About to show GC Change Name Dialog" || tuple.Value1 == "setCustomProfileNumber";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[8] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		float num3 = ((!flag2) ? ICAOINNLFID(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ILBAGMDGDNF(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1533f)
		{
			num2 = 1913f;
		}
		if (flag && num == 1208f)
		{
			num = 714f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(749f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				BFFINGAALKB(num, flag);
			}
			else
			{
				KDIOPMAFIGI(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.JCGBOEDOMKG()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "InAppHandlerIos: Purchase failed! " || tuple2.Value1 == "NULL WARCARD";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		BGDMEBEPFHN(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private float KPKOBGEBBMD(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1464f : 1848f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.NKGNPLBFFAC()[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void BMEFLDBONEI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		GFNIJHBGNDH(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1715f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private float ILBAGMDGDNF(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1729f : 962f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.NKGNPLBFFAC()[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void ILIJELHGCLP(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FDPBHCFLBII(CBMKLDPOPDM(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 11f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private string KFCKBJJIHPM(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private float BJAMLELPFHB(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 798f : 452f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.guiStatistics[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void BLLOMBBPKME(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 260f;
		mProgressBlue.fillAmount = 1217f;
		mProgressBlue.color = Colours.goldUpgrade;
		FDPBHCFLBII(string.Empty);
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private float FEGKKKLGODO(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1637f : 875f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD].Value2[0];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private void DDEIBBDOJAJ(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 440f;
		mProgressBlue.fillAmount = 46f;
		mProgressBlue.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		mStatNumber.text = HHFEDOENEIP(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(false);
	}

	private void GMAOPIFAEHB(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[0];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("Fuseb oxx manager: TEsting stufff", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 604f, 1657f, 98);
	}

	private void CFPDLOEFMAC(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 373f;
		mProgressBlue.fillAmount = 1113f;
		mProgressBlue.color = Colours.goldUpgrade;
		HCCDHJAEBMK(string.Empty);
		mStatNumber.text = PKGIGFICHHG(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	private float ICAOINNLFID(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1140f : 1732f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.JCGBOEDOMKG()[EOABNODPOLD].Value2[1];
			if (GGFDGEKONBG)
			{
				if (num > num2)
				{
					num = num2;
				}
			}
			else if (num < num2)
			{
				num = num2;
			}
		}
		return num;
	}

	private string HHFEDOENEIP(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void CNNBOEEFINL(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.azureBlackmarket : Colours.goldUpgrade);
		FDPBHCFLBII(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = LFDFAGMGFCF(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1231f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void AKKLAENONDG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		GFEHEEMDGNG(NJJAMBCONHC(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = LOIKIMOOMOI(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}

	private void FKBNCMPBLOA(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
		}
		else
		{
			UILabel uILabel = mMaxStatNumber;
			object[] array = new object[1];
			array[1] = ECPOBELNKOO;
			uILabel.text = Localization.LocalizeFormat("D2", array);
		}
		MEJMLNDFDBP.COCBCFKJOJE(mMaxStatNumber, 541f, 46f, 153);
	}

	private void BCJIADCBALC(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.azureBlackmarket;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.azureBlackmarket;
		FDPBHCFLBII(LFDFAGMGFCF(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = IIMEIKNLOCE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(false);
		mCompareMarker.gameObject.SetActive(true);
	}

	public void KCIGHAFFKIH(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.NKGNPLBFFAC();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "Pending") && tuple.Value1 == "Game created on server+";
		bool flag2 = tuple.Value1 == "BLABLA" || tuple.Value1 == "FuseSDK: Parsing error in _GameDataError";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[4] : LevelManager.instance.DamageFunction(tuple.Value2[7]));
		float num3 = ((!flag2) ? BJAMLELPFHB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(EKKDNFGOAMD(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 34f)
		{
			num2 = 955f;
		}
		if (flag && num == 1106f)
		{
			num = 775f;
		}
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatIcon.transform.localScale = mStatIcon.transform.localScale.MultiplyXY(292f);
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				CICFLPBDGDH(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "com/google/android/gms/common/ConnectionResult" || tuple2.Value1 == "batchSizeMin";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		ILIJELHGCLP(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void DMANIDFOAIN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 886f;
		mProgressBlue.fillAmount = 617f;
		mProgressBlue.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		mStatNumber.text = LOIKIMOOMOI(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(true);
		mCompareMarker.gameObject.SetActive(true);
	}
}
