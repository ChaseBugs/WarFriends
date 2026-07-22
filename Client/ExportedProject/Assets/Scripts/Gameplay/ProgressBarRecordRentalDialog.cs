using System.Collections.Generic;
using UnityEngine;

public class ProgressBarRecordRentalDialog : Core_BaseScript
{
	[SerializeField]
	[Header("Left")]
	private UISprite mStatIcon;

	[SerializeField]
	[Header("Middle")]
	private UILabel mStatName;

	[SerializeField]
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

	private float GMGCKMAPEJP(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1883f : 1094f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD].Value2[0];
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

	private float JICNIPOHANK(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 168f : 1416f);
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

	private string AEJIDLOACKE(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void CHONAMILBBN(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 374f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 1173f);
			mStatName.transform.localScale = new Vector3(num, num, 1942f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		UILabel uILabel = mMaxStatNumber;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		uILabel.text = Localization.LocalizeFormat("ID_WARNING_MAINTENANCE_TEXT", array);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + "StartingCurrency" + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(146f / x);
		if (num2 < 1380f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + "ID_HEALTH" + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(25f / x);
		}
		if (num2 < 685f)
		{
			Debug.LogError("Bad object with NavigationHelperCapsule LAYER");
		}
		float num3 = Mathf.Clamp(num2, 1429f, 899f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1749f);
		mStatName.transform.localScale = new Vector3(num3, num3, 1582f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
	}

	private void IPLNJMJFJDO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		CHONAMILBBN(BPDCFBIOIBE(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = AEJIDLOACKE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 904f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private void GMCBBBAAGJO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 25f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 1f);
			mStatName.transform.localScale = new Vector3(num, num, 1f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		mMaxStatNumber.text = Localization.LocalizeFormat("ID_MAXSTAT", ECPOBELNKOO);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + " " + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(224f / x);
		if (num2 < 20f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + " " + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(224f / x);
		}
		if (num2 < 20f)
		{
			Debug.LogError("Problem for max! in weapon stats");
		}
		float num3 = Mathf.Clamp(num2, 20f, 25f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1f);
		mStatName.transform.localScale = new Vector3(num3, num3, 1f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
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

	private void DIGJOBGGDIO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.blue;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.blue;
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = AEJIDLOACKE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(value: false);
		mCompareMarker.gameObject.SetActive(value: false);
	}

	public void MPFIACGCMGF(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_RENTAL_SNIPERRIFLE" || tuple.Value1 == "false";
		bool flag2 = !(tuple.Value1 == "Locale") && tuple.Value1 == "battleID";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[5] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? JFBHHBAMDHC(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JICNIPOHANK(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1578f)
		{
			num2 = 1755f;
		}
		if (flag && num == 427f)
		{
			num = 1763f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(1768f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_ACTIVATEINSTEADOF"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DIIAAMOGCDH(num, flag);
			}
			else
			{
				DIGJOBGGDIO(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "menu-gold") && tuple2.Value1 == "weapons/";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || (!(tuple2.Value1 == tuple.Value1) && (!flag2 || flag3));
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void EOMCJCJAEPK(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.blue;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.blue;
		CHONAMILBBN(BPDCFBIOIBE(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = BPDCFBIOIBE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(value: true);
		mCompareMarker.gameObject.SetActive(value: true);
	}

	private void DIIAAMOGCDH(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 950f;
		mProgressBlue.fillAmount = 1243f;
		mProgressBlue.color = Colours.goldUpgrade;
		CHONAMILBBN(string.Empty);
		mStatNumber.text = LOIKIMOOMOI(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(value: true);
		mCompareMarker.gameObject.SetActive(value: false);
	}

	public void OEKBNBEPBDB(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.DHEEPGEEIEN();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_NOTIFICATION_LAPSED_END" || tuple.Value1 == "Gold";
		bool flag2 = !(tuple.Value1 == "ID_") && tuple.Value1 == "_CameraWS";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[5]));
		float num3 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(ABAHJDOLCDN(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1769f)
		{
			num2 = 1873f;
		}
		if (flag && num == 1189f)
		{
			num = 1506f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(524f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("setResultCallback"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				PJALMHPEHMN(num, flag);
			}
			else
			{
				DIGJOBGGDIO(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "SessionManager: IN MENU!!") && tuple2.Value1 == "RETRYPERM";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG != MGNGHNNPOID.BHCEOOLEHHG || tuple2.Value1 == tuple.Value1 || !flag2 || flag3;
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private float JFBHHBAMDHC(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1668f : 1079f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.EKKFCKDPMNI()[EOABNODPOLD].Value2[1];
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

	public void PMNILJFFAHP(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.NKNOPGAOFKA();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "ID_CONFIRM_ERROR") && tuple.Value1 == "ID_NOTIFICATION_LAPSED_MORE";
		bool flag2 = tuple.Value1 == "set schedule gc check 2" || tuple.Value1 == "ID_YOUROPPONENTHASNOTACCEPTED";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[5]));
		float num3 = ((!flag2) ? JICNIPOHANK(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(PBHCIKAKOAF(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 98f)
		{
			num2 = 708f;
		}
		if (flag && num == 761f)
		{
			num = 1222f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(1967f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("PlayerLevel"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DIIAAMOGCDH(num, flag);
			}
			else
			{
				DIGJOBGGDIO(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.EKKFCKDPMNI()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_HEALTH" || tuple2.Value1 == "ko";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || !flag2 || flag3);
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	public void LNDBIIODAEB(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "oo" || tuple.Value1 == "warbucks";
		bool flag2 = tuple.Value1 == "Special pack content: type: {0} rarity: {1} amount: {2}{3}" || tuple.Value1 == "unity";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[5] : LevelManager.instance.DamageFunction(tuple.Value2[3]));
		float num3 = ((!flag2) ? PBHCIKAKOAF(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JICNIPOHANK(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 995f)
		{
			num2 = 1307f;
		}
		if (flag && num == 1657f)
		{
			num = 1430f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(1344f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("dataEnabled"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DIIAAMOGCDH(num, flag);
			}
			else
			{
				DIGJOBGGDIO(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "ID_STATE_OPPONENTDISCONECTED") && tuple2.Value1 == "shield_shot";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || !flag2 || flag3);
		BMEFLDBONEI(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void GIANAHIMJHH(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		mStatIcon.color = Colours.blue;
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = Colours.blue;
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Color.white;
		mCompareNumber.gameObject.SetActive(value: false);
		mCompareMarker.gameObject.SetActive(value: false);
	}

	private void MAAIEPGBAGM(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 642f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 223f);
			mStatName.transform.localScale = new Vector3(num, num, 355f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		UILabel uILabel = mMaxStatNumber;
		object[] array = new object[0];
		array[0] = ECPOBELNKOO;
		uILabel.text = Localization.LocalizeFormat("[FFFFFF]{0}[-]  {1}", array);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + "ID_CONFIRM_ERROR" + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(566f / x);
		if (num2 < 1532f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + "com/google/android/gms/common/api/ResultCallback" + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(1180f / x);
		}
		if (num2 < 43f)
		{
			Debug.LogError("{0} {1}{2} / {3}");
		}
		float num3 = Mathf.Clamp(num2, 1653f, 237f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1790f);
		mStatName.transform.localScale = new Vector3(num3, num3, 338f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
	}

	private void NKBLGMJAJAA(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 495f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 181f);
			mStatName.transform.localScale = new Vector3(num, num, 1480f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		UILabel uILabel = mMaxStatNumber;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		uILabel.text = Localization.LocalizeFormat("Scripts", array);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + "Can not spawn unit, already reached maxGeneratedCount" + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(1875f / x);
		if (num2 < 998f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + "ID_INGOLD2" + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(1463f / x);
		}
		if (num2 < 1045f)
		{
			Debug.LogError("Empty pack ");
		}
		float num3 = Mathf.Clamp(num2, 35f, 597f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1375f);
		mStatName.transform.localScale = new Vector3(num3, num3, 43f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
	}

	private void BMEFLDBONEI(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		NKBLGMJAJAA(LOIKIMOOMOI(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 601f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
	}

	private float PBHCIKAKOAF(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1194f : 970f);
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

	private void MIMJBOBJIKO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 940f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 1441f);
			mStatName.transform.localScale = new Vector3(num, num, 1817f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		UILabel uILabel = mMaxStatNumber;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		uILabel.text = Localization.LocalizeFormat("game-label-lose", array);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + "preloadAdForZoneID" + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(861f / x);
		if (num2 < 1470f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + "#Notifications# Received a with data id = {0}" + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(1197f / x);
		}
		if (num2 < 887f)
		{
			Debug.LogError("ID_REMINDER_GETVALUABLECARDPACKS");
		}
		float num3 = Mathf.Clamp(num2, 1595f, 432f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1897f);
		mStatName.transform.localScale = new Vector3(num3, num3, 813f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
	}

	private float ABAHJDOLCDN(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1536f : 1148f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.NKGNPLBFFAC()[EOABNODPOLD].Value2[0];
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

	public void LPMJFHACLIP(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "Set match state: " || tuple.Value1 == "C2";
		bool flag2 = !(tuple.Value1 == "OfflineRoom") && tuple.Value1 == "1";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(PBHCIKAKOAF(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 145f)
		{
			num2 = 383f;
		}
		if (flag && num == 1295f)
		{
			num = 828f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(422f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("603 GAME STARTED"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				LLFEPHEOMIP(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "SERVICE_VERSION_UPDATE_REQUIRED") && tuple2.Value1 == "ID_SQUADREQUIREDMEDALS";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7 && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || !flag2 || flag3);
		EKLAEFPIBNO(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private string LOIKIMOOMOI(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void KBGIPPOOCOC(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1858f;
		mProgressBlue.fillAmount = 1289f;
		mProgressBlue.color = Colours.goldUpgrade;
		CHONAMILBBN(string.Empty);
		mStatNumber.text = AEJIDLOACKE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(value: false);
		mCompareMarker.gameObject.SetActive(value: true);
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
		mStatIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
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

	private void PBIOJPDBMBD(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			mMaxStatNumber.text = string.Empty;
			float y = mMaxStatNumber.transform.localScale.y;
			float y2 = mStatName.transform.localScale.y;
			float num = 340f;
			mMaxStatNumber.transform.localScale = new Vector3(num, num, 500f);
			mStatName.transform.localScale = new Vector3(num, num, 845f);
			MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y);
			MEJMLNDFDBP.DBAECLDBEHF(mStatName, y2);
			return;
		}
		float y3 = mMaxStatNumber.transform.localScale.y;
		float y4 = mStatName.transform.localScale.y;
		mMaxStatNumber.text = Localization.LocalizeFormat("ID_CONFIRM_LANGUAGECHANGE", ECPOBELNKOO);
		float x = mMaxStatNumber.getSizeForString(mStatName.text + "ID_ARENARULES_BRONZEWARCARDS" + mMaxStatNumber.text).x;
		float num2 = Mathf.Floor(1240f / x);
		if (num2 < 824f)
		{
			mMaxStatNumber.text = ECPOBELNKOO;
			x = mMaxStatNumber.getSizeForString(mStatName.text + "Time" + mMaxStatNumber.text).x;
			num2 = Mathf.Floor(187f / x);
		}
		if (num2 < 1471f)
		{
			Debug.LogError("GOT REWARDS!!");
		}
		float num3 = Mathf.Clamp(num2, 1943f, 1129f);
		mMaxStatNumber.transform.localScale = new Vector3(num3, num3, 1314f);
		mStatName.transform.localScale = new Vector3(num3, num3, 1291f);
		MEJMLNDFDBP.DBAECLDBEHF(mMaxStatNumber, y3);
		MEJMLNDFDBP.DBAECLDBEHF(mStatName, y4);
	}

	public void KDBACGHKHLF(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.DHEEPGEEIEN();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "ObtainedCards" || tuple.Value1 == "PrepareBotForDeathMatch 9";
		bool flag2 = !(tuple.Value1 == "Squad") && tuple.Value1 == "ID_ANDROIDRESTOREPURCHASES";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[4] : LevelManager.instance.DamageFunction(tuple.Value2[4]));
		float num3 = ((!flag2) ? GMGCKMAPEJP(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JICNIPOHANK(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 1003f)
		{
			num2 = 825f;
		}
		if (flag && num == 514f)
		{
			num = 1577f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(1471f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("DeadRadius"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				GJCOIKEPOLL(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.DHEEPGEEIEN()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "0.##") && tuple2.Value1 == "pt";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed && JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || (flag2 && flag3));
		IPLNJMJFJDO(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}

	private void LLFEPHEOMIP(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 801f;
		mProgressBlue.fillAmount = 90f;
		mProgressBlue.color = Colours.goldUpgrade;
		NKBLGMJAJAA(string.Empty);
		mStatNumber.text = BPDCFBIOIBE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(value: true);
		mCompareMarker.gameObject.SetActive(value: false);
	}

	private string BPDCFBIOIBE(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void GJCOIKEPOLL(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		mStatIcon.color = Colours.goldUpgrade;
		mProgressWhite.fillAmount = 1882f;
		mProgressBlue.fillAmount = 1037f;
		mProgressBlue.color = Colours.goldUpgrade;
		PBIOJPDBMBD(string.Empty);
		mStatNumber.text = BPDCFBIOIBE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = Colours.goldUpgrade;
		mCompareNumber.gameObject.SetActive(value: false);
		mCompareMarker.gameObject.SetActive(value: true);
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
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(27f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_ATTACK"));
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

	private void EKLAEFPIBNO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		mStatIcon.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		mProgressWhite.fillAmount = fillAmount2;
		mProgressBlue.fillAmount = fillAmount;
		mProgressBlue.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		PBIOJPDBMBD(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		mStatNumber.text = BPDCFBIOIBE(IDEBKDPMPGM, ELEAKMKMEBG);
		mStatNumber.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		mCompareNumber.gameObject.SetActive(flag4);
		mCompareMarker.gameObject.SetActive(flag4);
		if (flag4)
		{
			mCompareNumber.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 593f);
			mCompareMarker.transform.localPosition = mCompareMarker.transform.localPosition.ReplaceX(mProgressBlue.transform.parent.localPosition.x + mProgressBlue.transform.localPosition.x + mProgressBlue.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			mProgressBlue.color = color;
			mStatNumber.color = color;
			mCompareNumber.color = color;
		}
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
		mCompareNumber.gameObject.SetActive(value: false);
		mCompareMarker.gameObject.SetActive(value: false);
	}

	private string EJCNNBKLADB(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	public void BMBPBNOKGPC(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.NKGNPLBFFAC();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "isConnectionFailedListenerRegistered") && tuple.Value1 == "phoneType";
		bool flag2 = !(tuple.Value1 == "Labels Z used:\n") && tuple.Value1 == "FuseSDK: Parsing error in _AccountLoginComplete";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float bIJFBAABMKC = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[3]));
		float num3 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JFBHHBAMDHC(JMMJHCOKCGG, EOABNODPOLD, flag)));
		if (!flag && num2 == 240f)
		{
			num2 = 291f;
		}
		if (flag && num == 597f)
		{
			num = 468f;
		}
		mStatIcon.transform.localPosition = mStatIcon.transform.localPosition.ReplaceX(1074f);
		mStatIcon.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		mStatIcon.MakePixelPerfect();
		mStatName.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("Reward"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				LLFEPHEOMIP(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, bIJFBAABMKC, num2, num3, flag);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "MIN_FPS") && tuple2.Value1 == "CardWasUsedOnline";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering;
		bool pGKLPEABJLO = JMMJHCOKCGG.BHCEOOLEHHG == MGNGHNNPOID.BHCEOOLEHHG && (tuple2.Value1 == tuple.Value1 || !flag2 || flag3);
		DCHJGFAIMMC(num, bIJFBAABMKC, num2, gFEAMPMFKLM, num3, flag, jPAHNGPHECO, pGKLPEABJLO);
	}
}
