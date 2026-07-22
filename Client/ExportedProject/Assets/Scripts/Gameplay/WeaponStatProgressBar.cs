using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponStatProgressBar : Core_BaseScript
{
	[Header("Left")]
	[FormerlySerializedAs("OCLAJPKKOIK")]
	public UISprite HMMKJFFOEFN;

	[Header("Middle")]
	[FormerlySerializedAs("HDCDAOCMPIF")]
	public UILabel CKBELNDIMJG;

	[FormerlySerializedAs("LNAECEALDEP")]
	public UISprite OCMNNPMNOCB;

	[FormerlySerializedAs("PHLPFKOPFHP")]
	public UISprite KCDCGGKKMOM;

	[FormerlySerializedAs("KGPAKLINGNL")]
	public UILabel CGNKNENMLPB;

	[FormerlySerializedAs("MCGFIMLGOCI")]
	public UILabel PNBGMFFKJIP;

	[FormerlySerializedAs("OIMPEOMHIDK")]
	public UILabel HOGEHLBFNIC;

	[FormerlySerializedAs("MPLGIHFPILK")]
	public UISprite KPOFBDOECON;

	[Header("Right")]
	[FormerlySerializedAs("ONIHPKHLGNH")]
	public UISprite MBMIOELEAND;

	[FormerlySerializedAs("POJFBOCBLGG")]
	public GameObject DPOBDDMIBEF;

	[FormerlySerializedAs("PINDJGHEKJE")]
	public UISprite HANAADNFJDN;

	[FormerlySerializedAs("LFLANADPJHC")]
	public UILabel GMBDMEAAFPG;

	[FormerlySerializedAs("MAMJPMODAEJ")]
	public UILabel KIIOABOEJBN;

	private Vector3 JKMICGMIBFN = new Vector3(88f, 74f, 1f);

	private Vector3 DGKGAKCGIHH = new Vector3(176f, 148f, 1f);

	private Vector3 NMFBHDFAAKL = new Vector3(57f, 57f, 1f);

	private Vector3 DGAIKOFGBFD = new Vector3(80f, 80f, 1f);

	private bool AHBIJGBFIKN;

	private void HIAELNGAMGA(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		HBCOHJBMEIG((!flag) ? HIEKCCGGOOI(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		BCHLBDHEFDA(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1503f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(JPAHNGPHECO && flag5 && flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? $"Dictionary filled and contains {MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)} ids\n" : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		NFCFHPFBPBA(BPBBJDIANBD);
		POHGJIGPNJG(!BPBBJDIANBD || flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: true);
		}
	}

	private void MKJOBBADKPM(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 396f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Loop;
		}
	}

	private void GLEOEKMGAIG(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1826f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
		}
	}

	private void AKKLAENONDG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		HBCOHJBMEIG(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		JOFKAKKFKDP(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(flag);
		GLEOEKMGAIG(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("doesnt exist", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		FFMKHJFNFJD(!BPBBJDIANBD || flag, !BPBBJDIANBD || flag);
	}

	private void FFMKHJFNFJD(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			MBMIOELEAND.alpha = 145f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 534f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 844f * num, 560f, 175f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 977f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 1;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	private void MGOBFPHPGDK(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		INLDGGAFKNA((!flag) ? HMHIOHKNHDE(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		FCGGPMOJEMI(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 253f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(!JPAHNGPHECO || !flag5 || flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("#PETER# League Arc - stop ignore on ", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		ANDBHFNMLML(BPBBJDIANBD);
		GBJHCOAPIEE(BPBBJDIANBD && flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	private void INLDGGAFKNA(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 89f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 43f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1166f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("CardId", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "level" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1504f / x);
		if (num2 < 253f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "HitListItem" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(774f / x);
		}
		if (num2 < 49f)
		{
			Debug.LogError("ID_SLOTUPGRADE_AMMO");
		}
		float num3 = Mathf.Clamp(num2, 332f, 627f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 157f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 243f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private float NNHNGNIDKFM(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1442f : 516f);
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

	private void NNKJMDOHFFN(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		BBDAJEMKKPE(DLHLNKCLMBE(OEPAHDJLAKG, ELEAKMKMEBG));
		HKOLFBCHGAJ(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(flag);
		ANDBHFNMLML(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("Skip assignment success", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		KMOBEGCLCDO(BPBBJDIANBD && flag, BPBBJDIANBD && flag);
	}

	public void NNKBLCDKCKB()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1232f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 6;
			tweenScale.style = (UITweener.Style)3;
		}
	}

	private void BCHLBDHEFDA(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(415f, 582f, 1708f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(917f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1133f, 1464f, -198);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 728f);
		x = Mathf.Round(x * 1570f);
		DGAIKOFGBFD = new Vector3(x, x, 345f);
	}

	private void FCGGPMOJEMI(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(605f, 1341f, 1667f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(1505f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1910f, 1377f, -147);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 1082f);
		x = Mathf.Round(x * 1945f);
		DGAIKOFGBFD = new Vector3(x, x, 917f);
	}

	private void CLFLNNNMNDO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		JDEFALJKGPM(BNPIAOJABLC(OEPAHDJLAKG, ELEAKMKMEBG));
		KGKFGMCPJOC(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(flag);
		LBPMKHOOGKE(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format(". ", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		KMOBEGCLCDO(BPBBJDIANBD && flag, !BPBBJDIANBD || flag);
	}

	private void PEFDNCODCPO(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 785f;
		KCDCGGKKMOM.fillAmount = 1426f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		HBCOHJBMEIG(string.Empty);
		BAOCBAKEJPJ(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GBJHCOAPIEE(HMFNIBOFGMB: false, NABOFKMBMKH: false);
	}

	private void DCHJGFAIMMC(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		GMCBBBAAGJO((!flag) ? EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		JOFKAKKFKDP(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(JPAHNGPHECO && flag5 && !flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? $"+{MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)}" : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		ANDBHFNMLML(BPBBJDIANBD);
		KEFCFMIDHBF(BPBBJDIANBD && flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: true);
		}
	}

	private void IPLNJMJFJDO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		HBCOHJBMEIG((!flag) ? HIEKCCGGOOI(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		HKOLFBCHGAJ(HIEKCCGGOOI(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1653f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(!JPAHNGPHECO || !flag5 || !flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("0$", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		NFCFHPFBPBA(BPBBJDIANBD);
		KEFCFMIDHBF(BPBBJDIANBD && flag5, !BPBBJDIANBD || flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	private void PIHBIAEBGMH(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 1512f;
		KCDCGGKKMOM.fillAmount = 1326f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		HBNBEHADDKO(string.Empty);
		BCHLBDHEFDA(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		AIOPMALGJJN(HMFNIBOFGMB: false, NABOFKMBMKH: false);
	}

	public void IGEFMGGGOKP(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.ECAINKOHNLI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "ID_TUTORIAL_TAPON") && tuple.Value1 == "ID_RANKEDBATTLE";
		bool flag2 = !(tuple.Value1 == "Google2u.DBUpgradeSlotsCar") && tuple.Value1 == "Removing facebook from current player!!";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? tuple.Value2[3] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? EEBCFFJOOCE(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(NNHNGNIDKFM(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 1005f)
		{
			num2 = 997f;
		}
		if (flag && num == 842f)
		{
			num = 600f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(33f, HMMKJFFOEFN.transform.localPosition.y, 174f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("There is no unit selected as tutorial unit!!!!!!"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				PIHBIAEBGMH(num, flag);
			}
			else
			{
				PKMFHMCLPOO(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_CRAFTWARCARDS" || tuple2.Value1 == "ID_NEWLOOTBOXINBATTLE";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering;
		bool pGKLPEABJLO = !(tuple2.Value1 == tuple.Value1) && (!flag2 || flag3);
		BCCNFIEBJNJ(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
	}

	public void KCNKMHNMDHC()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1528f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 4;
			tweenScale.style = (UITweener.Style)3;
		}
	}

	private void ANDBHFNMLML(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.PingPong;
		}
	}

	private void LBPMKHOOGKE(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1047f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Once;
		}
	}

	private void JINABAKLCLB(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 615f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1784f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 458f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[0];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("UnitTutorial", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_MAX" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1123f / x);
		if (num2 < 1268f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "order" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(830f / x);
		}
		if (num2 < 115f)
		{
			Debug.LogError("ID_ARENACROWN_DURATION");
		}
		float num3 = Mathf.Clamp(num2, 699f, 1556f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 571f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 425f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	public void FGPILHIMEAM(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.JCGBOEDOMKG();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "ID_VALUEPACK") && tuple.Value1 == "Skipping next player league notification";
		bool flag2 = tuple.Value1 == "SubscriptionNoChange" || tuple.Value1 == "Could not find parent screen";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[4] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? KCNGOMOACOM(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(NNHNGNIDKFM(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 140f)
		{
			num2 = 1089f;
		}
		if (flag && num == 1916f)
		{
			num = 1920f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(1985f, HMMKJFFOEFN.transform.localPosition.y, 393f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_SQUADMEMBERSLOWER"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				PCLBHLCGACN(num, flag);
			}
			else
			{
				PKMFHMCLPOO(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == " ") && tuple2.Value1 == "#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERING\t\tbutton type: DELIVER NOW";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		JPHJJCFLALE(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active);
	}

	private string DLHLNKCLMBE(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	public void INHEGDNOCMD()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1399f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = (UITweener.Style)7;
		}
	}

	private void KGKFGMCPJOC(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1076f, 1159f, 199f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(49f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1995f, 1939f, -130);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 1922f);
		x = Mathf.Round(x * 1357f);
		DGAIKOFGBFD = new Vector3(x, x, 981f);
	}

	private void PJALMHPEHMN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 1f;
		KCDCGGKKMOM.fillAmount = 1f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		JOFKAKKFKDP(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		KEFCFMIDHBF(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	public void MEJNJKOEMIF()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1245f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 3;
			tweenScale.style = UITweener.Style.Loop;
		}
	}

	public void JNKJBACNMGN()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1755f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 0;
			tweenScale.style = UITweener.Style.PingPong;
		}
	}

	private void JPHJJCFLALE(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		GMCBBBAAGJO((!flag) ? HIEKCCGGOOI(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		KGKFGMCPJOC(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1344f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(JPAHNGPHECO && flag5 && flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("Error setting match state {0} to player {1}", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		LBPMKHOOGKE(BPBBJDIANBD);
		AIOPMALGJJN(!BPBBJDIANBD || flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	private void KMOBEGCLCDO(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			MBMIOELEAND.alpha = 519f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 1762f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 39f * num, 1067f, 505f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1931f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	private void BBBIOODCEHJ(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 601f;
		KCDCGGKKMOM.fillAmount = 1923f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		HBNBEHADDKO(string.Empty);
		BCDGMIEDNNA(HMHIOHKNHDE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: true);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		GBJHCOAPIEE(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	private void JOFKAKKFKDP(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(57f, 57f, 1f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(-4f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 57f, 20f, 155);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 1f);
		x = Mathf.Round(x * 1.4f);
		DGAIKOFGBFD = new Vector3(x, x, 1f);
	}

	private void PCLBHLCGACN(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 801f;
		KCDCGGKKMOM.fillAmount = 719f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		FCGGPMOJEMI(BNPIAOJABLC(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(value: true);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		AIOPMALGJJN(HMFNIBOFGMB: true, NABOFKMBMKH: true);
	}

	private void BAOCBAKEJPJ(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1346f, 1492f, 1212f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(1931f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 416f, 746f, -172);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 1189f);
		x = Mathf.Round(x * 1385f);
		DGAIKOFGBFD = new Vector3(x, x, 224f);
	}

	private void JDEFALJKGPM(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1048f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1962f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 271f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("Army_Unit_ID", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "StartMovementAtTimeRPC" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(465f / x);
		if (num2 < 193f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ShowArenaDialog" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(932f / x);
		}
		if (num2 < 1377f)
		{
			Debug.LogError("init");
		}
		float num3 = Mathf.Clamp(num2, 1725f, 729f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 175f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1182f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void LOIKFBELLAJ(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1664f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)3;
		}
	}

	private void LLFEPHEOMIP(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 850f;
		KCDCGGKKMOM.fillAmount = 1288f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		HBCOHJBMEIG(string.Empty);
		BCHLBDHEFDA(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		KMOBEGCLCDO(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	private void FBAJJCLBNHF(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			MBMIOELEAND.alpha = 1301f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 1536f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1061f * num, 444f, 160f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 2f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	public void HEFPMCLAOIE()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 960f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 7;
			tweenScale.style = (UITweener.Style)6;
		}
	}

	public void BFKIJPDCKPM()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 841f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 8;
			tweenScale.style = (UITweener.Style)8;
		}
	}

	private string EJCNNBKLADB(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	public void MIJNLELOJEC(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "Parts" || tuple.Value1 == "facebookLogin";
		bool flag2 = !(tuple.Value1 == "BAND_EMPTY") && tuple.Value1 == "registerCustomEventString";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? FAKGADCPAJP(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num == num3;
		if (!flag && num2 == 432f)
		{
			num2 = 883f;
		}
		if (flag && num == 1133f)
		{
			num = 1296f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(1505f, HMMKJFFOEFN.transform.localPosition.y, 1169f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("moneypack1"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				LLFEPHEOMIP(num, flag);
			}
			else
			{
				NNKJMDOHFFN(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == " was activated (through fast activation).") && tuple2.Value1 == "ID_TUTORIAL_GO_BUY_ARMY_6_DOWN";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		BCCNFIEBJNJ(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7);
	}

	private void OJOPBKMBDIJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		JDEFALJKGPM((!flag) ? HIEKCCGGOOI(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		BCHLBDHEFDA(NPLLLDBOFFG(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 53f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(!JPAHNGPHECO || !flag5 || flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("reload_pistol", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		GLEOEKMGAIG(BPBBJDIANBD);
		FBAJJCLBNHF(BPBBJDIANBD && flag5, !BPBBJDIANBD || flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: true);
		}
	}

	private void MDPECKHFODC(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 1360f;
		KCDCGGKKMOM.fillAmount = 1917f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		HKOLFBCHGAJ(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: true);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		KMOBEGCLCDO(HMFNIBOFGMB: true, NABOFKMBMKH: false);
	}

	private void IGCCBAMJJLG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		JINABAKLCLB(BNPIAOJABLC(OEPAHDJLAKG, ELEAKMKMEBG));
		JOFKAKKFKDP(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(flag);
		LELHPMLIICK(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("ID_WARNING_ALREADYCRAFTING", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		FFMKHJFNFJD(BPBBJDIANBD && flag, !BPBBJDIANBD || flag);
	}

	private void HBCOHJBMEIG(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 275f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1955f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 872f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("\"", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "forever" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1993f / x);
		if (num2 < 129f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_GUI_BRONZE" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(465f / x);
		}
		if (num2 < 305f)
		{
			Debug.LogError("Shown facebook login failed dialog");
		}
		float num3 = Mathf.Clamp(num2, 452f, 462f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 354f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 844f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void GIANAHIMJHH(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		GMCBBBAAGJO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		JOFKAKKFKDP(EJCNNBKLADB(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(flag);
		ANDBHFNMLML(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? $"+{MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)}" : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		KEFCFMIDHBF(BPBBJDIANBD && flag, BPBBJDIANBD && flag);
	}

	private string HMHIOHKNHDE(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void BCCNFIEBJNJ(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		GMCBBBAAGJO((!flag) ? HODBOCBJMJD(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		BAOCBAKEJPJ(NPLLLDBOFFG(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 280f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(!JPAHNGPHECO || !flag5 || !flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("Time", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		GIIIPDHFCEE(BPBBJDIANBD);
		AIOPMALGJJN(!BPBBJDIANBD || flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	private void NFCFHPFBPBA(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 644f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Once;
		}
	}

	public void IKGOCCDELLN(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.DHEEPGEEIEN();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "elite1" || tuple.Value1 == "VipReward1";
		bool flag2 = !(tuple.Value1 == "startSession") && tuple.Value1 == "Shown facebook login failed dialog";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[4]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? FAKGADCPAJP(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(CEFBMOEOGHH(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 1051f)
		{
			num2 = 354f;
		}
		if (flag && num == 1360f)
		{
			num = 1771f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(182f, HMMKJFFOEFN.transform.localPosition.y, 1438f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("Stop Loading called when Game is loading or running"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				OEKNGOHCLLE(num, flag);
			}
			else
			{
				JPNOHFKNCBP(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.ECAINKOHNLI()[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "Prefabs to go through: {0} + {1}\n" || tuple2.Value1 == "{0}{1}[-]";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7 && JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)8 && JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || !flag2 || flag3;
		IPLNJMJFJDO(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering);
	}

	private void LELHPMLIICK(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1540f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)8;
		}
	}

	public void ADHIPKKPBOB(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.ECAINKOHNLI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = tuple.Value1 == "N" || tuple.Value1 == "ID_STAT_WINLOSSRATIO";
		bool flag2 = !(tuple.Value1 == "ID_DELIVEREDTIME") && tuple.Value1 == "HERUNTERLADEN";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[8] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? NNHNGNIDKFM(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(CEFBMOEOGHH(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num == num3;
		if (!flag && num2 == 896f)
		{
			num2 = 577f;
		}
		if (flag && num == 1743f)
		{
			num = 68f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(1373f, HMMKJFFOEFN.transform.localPosition.y, 951f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("Turret"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DKGKBNGNECH(num, flag);
			}
			else
			{
				AKKLAENONDG(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_CONFIRM_LEAVESQUAD" || tuple2.Value1 == "Squad Member record does not have DatabasePlayer";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		JPHJJCFLALE(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering);
	}

	private void BBDAJEMKKPE(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1202f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1882f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 614f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("game-card-ico-disarmed", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "DepositedCards" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1245f / x);
		if (num2 < 1371f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "0" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(144f / x);
		}
		if (num2 < 1322f)
		{
			Debug.LogError("Chat: Trying to change public channel, but player data are not loaded yet.");
		}
		float num3 = Mathf.Clamp(num2, 1353f, 475f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 332f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 902f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void PKMFHMCLPOO(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		HBNBEHADDKO(EJCNNBKLADB(OEPAHDJLAKG, ELEAKMKMEBG));
		JOFKAKKFKDP(HIEKCCGGOOI(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(flag);
		GLEOEKMGAIG(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("damage", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		FFMKHJFNFJD(!BPBBJDIANBD || flag, BPBBJDIANBD && flag);
	}

	private float EEBCFFJOOCE(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 1945f : 458f);
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

	private void GIIIPDHFCEE(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 328f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.PingPong;
		}
	}

	private void GMCBBBAAGJO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 25f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 1f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		CGNKNENMLPB.text = Localization.LocalizeFormat("ID_MAXSTAT", ECPOBELNKOO);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(224f / x);
		if (num2 < 20f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + " " + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(224f / x);
		}
		if (num2 < 20f)
		{
			Debug.LogError("Problem for max! in army/weapon stats");
		}
		float num3 = Mathf.Clamp(num2, 20f, 25f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 1f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void JPNOHFKNCBP(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		BBDAJEMKKPE(NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG));
		FCGGPMOJEMI(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(flag);
		ANDBHFNMLML(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("grenadeExplosion", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		GBJHCOAPIEE(!BPBBJDIANBD || flag, !BPBBJDIANBD || flag);
	}

	private void DOJJCEMNNJM(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 838f;
		KCDCGGKKMOM.fillAmount = 177f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		JINABAKLCLB(string.Empty);
		BAOCBAKEJPJ(BNPIAOJABLC(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(value: true);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		POHGJIGPNJG(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	public void OFLHCIBMNMB()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1531f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 0;
			tweenScale.style = (UITweener.Style)7;
		}
	}

	public void IEAEMKAKIBN()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 142f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 7;
			tweenScale.style = (UITweener.Style)3;
		}
	}

	private void OEKNGOHCLLE(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 286f;
		KCDCGGKKMOM.fillAmount = 1434f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		JINABAKLCLB(string.Empty);
		BCHLBDHEFDA(DLHLNKCLMBE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		AIOPMALGJJN(HMFNIBOFGMB: true, NABOFKMBMKH: true);
	}

	private string BNPIAOJABLC(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void CNCIPMAMIDL(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		INLDGGAFKNA(HMHIOHKNHDE(OEPAHDJLAKG, ELEAKMKMEBG));
		BCDGMIEDNNA(HMHIOHKNHDE(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(flag);
		GIIIPDHFCEE(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("add", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		AIOPMALGJJN(!BPBBJDIANBD || flag, !BPBBJDIANBD || flag);
	}

	public void AnimateStat()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 4f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
	}

	public void NEKGLDANFCA()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1848f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 7;
			tweenScale.style = (UITweener.Style)8;
		}
	}

	private float FAKGADCPAJP(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 115f : 717f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.LNOHKLNBCGM()[EOABNODPOLD].Value2[1];
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

	public void FFFHIACHFPP()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1945f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = (UITweener.Style)6;
		}
	}

	private float GDLOEKEODEB(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 149f : 766f);
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup.BHCEOOLEHHG != JMMJHCOKCGG.BHCEOOLEHHG)
			{
				continue;
			}
			float num2 = weaponLevelsSetup.MGAGEKAAJOL.DHEEPGEEIEN()[EOABNODPOLD].Value2[0];
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

	private void BIICOFLGGOC(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 743f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)3;
		}
	}

	private void BCDGMIEDNNA(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(11f, 260f, 1316f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(1928f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1161f, 333f, 169);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 275f);
		x = Mathf.Round(x * 1402f);
		DGAIKOFGBFD = new Vector3(x, x, 363f);
	}

	private void AIOPMALGJJN(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			MBMIOELEAND.alpha = 1569f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 1795f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 647f * num, 200f, 952f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1570f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 1;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	private float CCJELOOMLLL(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 458f : 427f);
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

	private void LAOOJBIIOEP(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 309f;
		KCDCGGKKMOM.fillAmount = 208f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		HBNBEHADDKO(string.Empty);
		KGKFGMCPJOC(BNPIAOJABLC(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: false);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		KEFCFMIDHBF(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	public void HKFIIJJKIEL(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.EKKFCKDPMNI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "Location") && tuple.Value1 == "C3";
		bool flag2 = tuple.Value1 == "RecieveOponentScore" || tuple.Value1 == "BEANSTALK: ON RESTORE PACKS";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[8]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(EEBCFFJOOCE(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 270f)
		{
			num2 = 763f;
		}
		if (flag && num == 847f)
		{
			num = 1863f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(1464f, HMMKJFFOEFN.transform.localPosition.y, 931f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("Invite was already send, ignoring click."));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DKGKBNGNECH(num, flag);
			}
			else
			{
				KAOEBOAFCME(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.NKNOPGAOFKA()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "StarterAssignmentsReward") && tuple2.Value1 == "menu-weaponstats-accuracy";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		bool pGKLPEABJLO = !(tuple2.Value1 == tuple.Value1) && flag2 && flag3;
		BCCNFIEBJNJ(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
	}

	private float JICNIPOHANK(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 819f : 879f);
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

	private void POHGJIGPNJG(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			MBMIOELEAND.alpha = 1723f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 165f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1225f * num, 870f, 305f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1294f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 1;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	private void KEFCFMIDHBF(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			MBMIOELEAND.alpha = 1f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 2f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	public void BAOJGBICMCC()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1825f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = (UITweener.Style)5;
		}
	}

	private string NPLLLDBOFFG(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void HKOLFBCHGAJ(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1788f, 1054f, 1566f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(105f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 735f, 1129f, 32);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 130f);
		x = Mathf.Round(x * 403f);
		DGAIKOFGBFD = new Vector3(x, x, 381f);
	}

	private void GBJHCOAPIEE(bool HMFNIBOFGMB, bool NABOFKMBMKH)
	{
		MBMIOELEAND.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = MBMIOELEAND.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			MBMIOELEAND.alpha = 768f;
			TweenScale component2 = MBMIOELEAND.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			MBMIOELEAND.transform.localScale = JKMICGMIBFN;
		}
		else
		{
			float num = 1735f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(MBMIOELEAND.gameObject, 1057f * num, 1433f, 796f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 1;
			TweenScale tweenScale = TweenScale.Begin(MBMIOELEAND.gameObject, 1116f * num, JKMICGMIBFN, DGKGAKCGIHH);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		MBMIOELEAND.gameObject.SetActive(NABOFKMBMKH);
	}

	private void ABPDEOIGCAH(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = JPAHNGPHECO && IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = PGKLPEABJLO && !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		HBCOHJBMEIG((!flag) ? NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		BCDGMIEDNNA(HIEKCCGGOOI(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 1031f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(JPAHNGPHECO && flag5 && !flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format(" from deposited cards to normal cards", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		BBDNKKDCLBI(BPBBJDIANBD);
		FBAJJCLBNHF(BPBBJDIANBD && flag5, BPBBJDIANBD && flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	private void FGBPNIMBFHM(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		JINABAKLCLB(NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG));
		NOFPCDBPAHG(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: false);
		DPOBDDMIBEF.SetActive(flag);
		BIICOFLGGOC(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("ID_SILVERPACK", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		FBAJJCLBNHF(BPBBJDIANBD && flag, BPBBJDIANBD && flag);
	}

	public void PABCAEFODIF()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1140f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 6;
			tweenScale.style = (UITweener.Style)8;
		}
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

	private void CLNAPHNJDEL(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 1587f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.PingPong;
		}
	}

	private string HODBOCBJMJD(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	private void GIFEGPLEIDG(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float GFEAMPMFKLM, float HACGFBKEKAG, float NDGEHFPBGIM, bool ELEAKMKMEBG, bool JPAHNGPHECO, bool PGKLPEABJLO, bool BPBBJDIANBD = false)
	{
		bool flag = !JPAHNGPHECO || IDEBKDPMPGM == OEPAHDJLAKG;
		bool flag2 = ((!ELEAKMKMEBG) ? (GFEAMPMFKLM < IDEBKDPMPGM) : (IDEBKDPMPGM < GFEAMPMFKLM));
		bool flag3 = IDEBKDPMPGM == GFEAMPMFKLM;
		bool flag4 = !PGKLPEABJLO || !flag3;
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / NDGEHFPBGIM) : (NDGEHFPBGIM / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / NDGEHFPBGIM) : (NDGEHFPBGIM / BIJFBAABMKC));
		bool flag5 = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		float num = Mathf.Clamp01((!ELEAKMKMEBG) ? (GFEAMPMFKLM / NDGEHFPBGIM) : (NDGEHFPBGIM / GFEAMPMFKLM));
		HMMKJFFOEFN.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = ((!flag) ? Colours.blue : Colours.goldUpgrade);
		INLDGGAFKNA((!flag) ? NPLLLDBOFFG(OEPAHDJLAKG, ELEAKMKMEBG) : string.Empty);
		FCGGPMOJEMI(HIEKCCGGOOI(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = ((!flag) ? Color.white : Colours.goldUpgrade);
		HOGEHLBFNIC.gameObject.SetActive(flag4);
		KPOFBDOECON.gameObject.SetActive(flag4);
		if (flag4)
		{
			HOGEHLBFNIC.text = MEJMLNDFDBP.AKEMDPDJPLH(IDEBKDPMPGM - GFEAMPMFKLM, 327f);
			KPOFBDOECON.transform.localPosition = KPOFBDOECON.transform.localPosition.ReplaceX(KCDCGGKKMOM.transform.parent.localPosition.x + KCDCGGKKMOM.transform.localPosition.x + KCDCGGKKMOM.transform.localScale.x * num);
			Color color = ((!flag2) ? Colours.redWeaponStats : Colours.greenWeaponStats);
			KCDCGGKKMOM.color = color;
			PNBGMFFKJIP.color = color;
			HOGEHLBFNIC.color = color;
		}
		DPOBDDMIBEF.SetActive(!JPAHNGPHECO || !flag5 || flag);
		KIIOABOEJBN.gameObject.SetActive(flag);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? $"x{MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)}" : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		NFCFHPFBPBA(BPBBJDIANBD);
		KMOBEGCLCDO(BPBBJDIANBD && flag5, !BPBBJDIANBD || flag5);
		if (flag)
		{
			MBMIOELEAND.gameObject.SetActive(value: false);
		}
	}

	public void InitializeStat(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> guiStatistics = JMMJHCOKCGG.MGAGEKAAJOL.guiStatistics;
		Tuple<string, float[]> tuple = guiStatistics[EOABNODPOLD];
		bool flag = tuple.Value1 == "ID_SLOTUPGRADE_ROF" || tuple.Value1 == "ID_SLOTUPGRADE_HEAT";
		bool flag2 = tuple.Value1 == "ID_SLOTUPGRADE_POWER" || tuple.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float num = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[2] : LevelManager.instance.DamageFunction(tuple.Value2[2]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(JCDFMFBPAAB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 0f)
		{
			num2 = 1f;
		}
		if (flag && num == 0f)
		{
			num = 1f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(27f, HMMKJFFOEFN.transform.localPosition.y, 0f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_ATTACK"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				PJALMHPEHMN(num, flag);
			}
			else
			{
				GIANAHIMJHH(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = tuple2.Value1 == "ID_SLOTUPGRADE_POWER" || tuple2.Value1 == "ID_SLOTUPGRADE_DAMAGE";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || (flag2 && flag3);
		DCHJGFAIMMC(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
	}

	private void HBNBEHADDKO(string ECPOBELNKOO)
	{
		if (string.IsNullOrEmpty(ECPOBELNKOO))
		{
			CGNKNENMLPB.text = string.Empty;
			float y = CGNKNENMLPB.transform.localScale.y;
			float y2 = CKBELNDIMJG.transform.localScale.y;
			float num = 1972f;
			CGNKNENMLPB.transform.localScale = new Vector3(num, num, 1455f);
			CKBELNDIMJG.transform.localScale = new Vector3(num, num, 80f);
			MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y);
			MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y2);
			return;
		}
		float y3 = CGNKNENMLPB.transform.localScale.y;
		float y4 = CKBELNDIMJG.transform.localScale.y;
		UILabel cGNKNENMLPB = CGNKNENMLPB;
		object[] array = new object[1];
		array[1] = ECPOBELNKOO;
		cGNKNENMLPB.text = Localization.LocalizeFormat("ERROR WRONG DAILY REWARDS: ", array);
		float x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "ID_ACHIEVEMENTS" + CGNKNENMLPB.text).x;
		float num2 = Mathf.Floor(1650f / x);
		if (num2 < 373f)
		{
			CGNKNENMLPB.text = ECPOBELNKOO;
			x = CGNKNENMLPB.getSizeForString(CKBELNDIMJG.text + "shield_unhide" + CGNKNENMLPB.text).x;
			num2 = Mathf.Floor(321f / x);
		}
		if (num2 < 1981f)
		{
			Debug.LogError("ID_STAT_ALLTIMERUNS");
		}
		float num3 = Mathf.Clamp(num2, 1328f, 1112f);
		CGNKNENMLPB.transform.localScale = new Vector3(num3, num3, 268f);
		CKBELNDIMJG.transform.localScale = new Vector3(num3, num3, 1267f);
		MEJMLNDFDBP.DBAECLDBEHF(CGNKNENMLPB, y3);
		MEJMLNDFDBP.DBAECLDBEHF(CKBELNDIMJG, y4);
	}

	private void DKGKBNGNECH(float IDEBKDPMPGM, bool ELEAKMKMEBG)
	{
		HMMKJFFOEFN.color = Colours.goldUpgrade;
		OCMNNPMNOCB.fillAmount = 1654f;
		KCDCGGKKMOM.fillAmount = 1538f;
		KCDCGGKKMOM.color = Colours.goldUpgrade;
		GMCBBBAAGJO(string.Empty);
		HKOLFBCHGAJ(HODBOCBJMJD(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Colours.goldUpgrade;
		HOGEHLBFNIC.gameObject.SetActive(value: false);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(value: true);
		KIIOABOEJBN.gameObject.SetActive(value: false);
		AIOPMALGJJN(HMFNIBOFGMB: false, NABOFKMBMKH: true);
	}

	public void NKEFMIGONNI(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.ECAINKOHNLI();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "#Mission Rewards# Current Heroic Points: ") && tuple.Value1 == "Buy_VIP";
		bool flag2 = tuple.Value1 == "ID_STAT_WEAPONSPURCHASED" || tuple.Value1 == "Shoot";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[0] : LevelManager.instance.DamageFunction(tuple.Value2[1]));
		float num3 = ((!flag2) ? tuple.Value2[8] : LevelManager.instance.DamageFunction(tuple.Value2[4]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? EEBCFFJOOCE(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(EEBCFFJOOCE(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 1566f)
		{
			num2 = 1262f;
		}
		if (flag && num == 948f)
		{
			num = 314f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(1999f, HMMKJFFOEFN.transform.localPosition.y, 1109f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_GC_LOGIN_TUTORIAL_TEXT"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				DOJJCEMNNJM(num, flag);
			}
			else
			{
				AKKLAENONDG(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.guiStatistics[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "UK") && tuple2.Value1 == "warArenaCrown";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[0] : LevelManager.instance.DamageFunction(tuple2.Value2[1]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering && JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered && JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8;
		bool pGKLPEABJLO = !(tuple2.Value1 == tuple.Value1) && flag2 && flag3;
		ABPDEOIGCAH(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8);
	}

	private float CEFBMOEOGHH(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 878f : 82f);
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

	private string HIEKCCGGOOI(float IDEBKDPMPGM, bool GGFDGEKONBG)
	{
		return (!GGFDGEKONBG) ? MEJMLNDFDBP.MAGANIIGHON(IDEBKDPMPGM) : MEJMLNDFDBP.DLDMHFBIEEO(IDEBKDPMPGM);
	}

	public void JBIJFPEEFFL()
	{
		if (AHBIJGBFIKN)
		{
			TweenScale tweenScale = TweenScale.Begin(PNBGMFFKJIP.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1264f, NMFBHDFAAKL, DGAIKOFGBFD);
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = (UITweener.Style)7;
		}
	}

	private void BBDNKKDCLBI(bool BPBBJDIANBD)
	{
		if (BPBBJDIANBD)
		{
			TweenColor component = GMBDMEAAFPG.gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			GMBDMEAAFPG.color = Colours.greenDelivering;
		}
		else
		{
			GMBDMEAAFPG.color = Colours.blueUpgradeAnim1;
			TweenColor tweenColor = TweenColor.Begin(GMBDMEAAFPG.gameObject, 19f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Loop;
		}
	}

	public void OJPLLBPIHJK(WeaponLevelsSetup JMMJHCOKCGG, WeaponLevelsSetup MGNGHNNPOID, int EOABNODPOLD)
	{
		List<Tuple<string, float[]>> list = JMMJHCOKCGG.MGAGEKAAJOL.LNOHKLNBCGM();
		Tuple<string, float[]> tuple = list[EOABNODPOLD];
		bool flag = !(tuple.Value1 == "Remove Google Play Data") && tuple.Value1 == "ID_TUTORIAL_TAPON";
		bool flag2 = !(tuple.Value1 == "ID_USEREXISTSGOOGLEPLAYTEXT") && tuple.Value1 == "ID_MINIGUNHINT";
		float num = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num2 = ((!flag2) ? tuple.Value2[1] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		float num3 = ((!flag2) ? tuple.Value2[4] : LevelManager.instance.DamageFunction(tuple.Value2[0]));
		if (JMMJHCOKCGG.tryOutWeapon)
		{
			num3 = num;
		}
		float num4 = ((!flag2) ? FAKGADCPAJP(JMMJHCOKCGG, EOABNODPOLD, flag) : LevelManager.instance.DamageFunction(GDLOEKEODEB(JMMJHCOKCGG, EOABNODPOLD, flag)));
		AHBIJGBFIKN = num != num3;
		if (!flag && num2 == 1699f)
		{
			num2 = 1264f;
		}
		if (flag && num == 1658f)
		{
			num = 1377f;
		}
		HMMKJFFOEFN.transform.localPosition = new Vector3(932f, HMMKJFFOEFN.transform.localPosition.y, 953f);
		HMMKJFFOEFN.spriteName = GameVariables.EEPCPOGCNCJ[tuple.Value1];
		HMMKJFFOEFN.MakePixelPerfect();
		CKBELNDIMJG.text = ((!flag2) ? Localization.Localize(tuple.Value1) : Localization.Localize("ID_MINUTES"));
		if (JMMJHCOKCGG == MGNGHNNPOID || MGNGHNNPOID == null)
		{
			if (num == num2)
			{
				OEKNGOHCLLE(num, flag);
			}
			else
			{
				KAOEBOAFCME(num, num3, num2, num4, flag, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7);
			}
			return;
		}
		Tuple<string, float[]> tuple2 = MGNGHNNPOID.MGAGEKAAJOL.EKKFCKDPMNI()[EOABNODPOLD];
		bool flag3 = !(tuple2.Value1 == "ID_SALEPERCENTLINE") && tuple2.Value1 == "Automatic_Equip";
		float gFEAMPMFKLM = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		float hACGFBKEKAG = ((!flag2) ? tuple2.Value2[1] : LevelManager.instance.DamageFunction(tuple2.Value2[0]));
		bool jPAHNGPHECO = JMMJHCOKCGG.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered && JMMJHCOKCGG.weaponState != (WeaponLevelsSetup.JLANLLEABDC)7 && JMMJHCOKCGG.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering;
		bool pGKLPEABJLO = tuple2.Value1 == tuple.Value1 || !flag2 || flag3;
		HIAELNGAMGA(num, num3, num2, gFEAMPMFKLM, hACGFBKEKAG, num4, flag, jPAHNGPHECO, pGKLPEABJLO, JMMJHCOKCGG.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7);
	}

	private void KAOEBOAFCME(float IDEBKDPMPGM, float BIJFBAABMKC, float OEPAHDJLAKG, float HHJKDOGCBHK, bool ELEAKMKMEBG, bool BPBBJDIANBD = false)
	{
		float fillAmount = Mathf.Clamp01((!ELEAKMKMEBG) ? (IDEBKDPMPGM / HHJKDOGCBHK) : (HHJKDOGCBHK / IDEBKDPMPGM));
		float fillAmount2 = Mathf.Clamp01((!ELEAKMKMEBG) ? (BIJFBAABMKC / HHJKDOGCBHK) : (HHJKDOGCBHK / BIJFBAABMKC));
		bool flag = ((!ELEAKMKMEBG) ? (IDEBKDPMPGM < BIJFBAABMKC) : (BIJFBAABMKC < IDEBKDPMPGM));
		HMMKJFFOEFN.color = Colours.blue;
		OCMNNPMNOCB.fillAmount = fillAmount2;
		KCDCGGKKMOM.fillAmount = fillAmount;
		KCDCGGKKMOM.color = Colours.blue;
		BBDAJEMKKPE(DLHLNKCLMBE(OEPAHDJLAKG, ELEAKMKMEBG));
		HKOLFBCHGAJ(BNPIAOJABLC(IDEBKDPMPGM, ELEAKMKMEBG));
		PNBGMFFKJIP.color = Color.white;
		HOGEHLBFNIC.gameObject.SetActive(value: true);
		KPOFBDOECON.gameObject.SetActive(value: true);
		DPOBDDMIBEF.SetActive(flag);
		LOIKFBELLAJ(BPBBJDIANBD);
		KIIOABOEJBN.gameObject.SetActive(value: true);
		GMBDMEAAFPG.text = ((!ELEAKMKMEBG) ? string.Format("damage", MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM)) : MEJMLNDFDBP.MAGANIIGHON(BIJFBAABMKC - IDEBKDPMPGM));
		FBAJJCLBNHF(!BPBBJDIANBD || flag, BPBBJDIANBD && flag);
	}

	private float KCNGOMOACOM(WeaponLevelsSetup JMMJHCOKCGG, int EOABNODPOLD, bool GGFDGEKONBG)
	{
		float num = ((!GGFDGEKONBG) ? 636f : 1710f);
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

	private void NOFPCDBPAHG(string LJBKCKBPHEL)
	{
		TweenScale component = PNBGMFFKJIP.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		PNBGMFFKJIP.transform.localScale = new Vector3(1822f, 622f, 479f);
		PNBGMFFKJIP.transform.localPosition = PNBGMFFKJIP.transform.localPosition.ReplaceY(30f);
		PNBGMFFKJIP.text = LJBKCKBPHEL;
		MEJMLNDFDBP.COCBCFKJOJE(PNBGMFFKJIP, 1765f, 1742f, -8);
		float x = PNBGMFFKJIP.transform.localScale.x;
		NMFBHDFAAKL = new Vector3(x, x, 1918f);
		x = Mathf.Round(x * 4f);
		DGAIKOFGBFD = new Vector3(x, x, 1279f);
	}
}
