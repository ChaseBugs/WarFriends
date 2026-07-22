using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class MapSelectionContent : Core_BaseScript
{
	[FormerlySerializedAs("GHPPCNBBHDK")]
	public float DNDHIFENDPJ = 0.6f;

	[FormerlySerializedAs("JOALHBEMEMC")]
	[Header("Selected Map")]
	public BoxCollider HELCLOMPMHK;

	[FormerlySerializedAs("BBJBEOINFHK")]
	public UISprite NMHCECNAPNP;

	[FormerlySerializedAs("HKJLOILOJKN")]
	public GameObject FPMPJBHLEAB;

	[FormerlySerializedAs("HGCECEECINE")]
	public UILabel ALJDGMPFDLN;

	[FormerlySerializedAs("LJJOCGALFPO")]
	public UISprite BNENBOPANIN;

	[FormerlySerializedAs("EFELINKOGNO")]
	public GameObject GBLODBJMAOL;

	[FormerlySerializedAs("OJDAHHANLLL")]
	public UISprite[] FMPBNPFOGLO;

	[FormerlySerializedAs("DKHFCOAPPBO")]
	public UISprite CFKLKCHACOK;

	[FormerlySerializedAs("AJFLPLCAOCN")]
	[Header("List")]
	public UISprite FOBPGOKHBBK;

	[FormerlySerializedAs("AGKFLOBEOCE")]
	public MapSelectionRecord[] EGICOCDAAIL;

	private MapSelectionRecord BKJBFNNOHLE;

	private bool GJCEOOKPHEM;

	private bool JCKOBELDCGD;

	private float GDADIFDNACN = 0.3f;

	public bool isOpened => GJCEOOKPHEM;

	public bool isAnimating => JCKOBELDCGD;

	[SpecialName]
	public bool JKNBOLDJKJH()
	{
		return JCKOBELDCGD;
	}

	[SpecialName]
	public bool FJHNEAKOIHL()
	{
		return GJCEOOKPHEM;
	}

	private void MNBANHEFEJB(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	private void LHKOENFILLP(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].DHIMNKLJBAK();
		}
	}

	private void AEHMAEKNOLC(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: true);
	}

	private void MHHAMFGLAIE(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
	}

	private void MMLGEIHCBFE()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		float val = 1666f + (float)EGICOCDAAIL.Length * 1363f + 95f;
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		FOBPGOKHBBK.alpha = 1305f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 962f, 96f, GDADIFDNACN);
		tweenAlpha.delay = 220f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(485f);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(568f), FOBPGOKHBBK.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = IFKBKDMNNNM;
		BNENBOPANIN.alpha = 574f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 247f, 86f, 523f);
		tweenAlpha.delay = 1059f;
		tweenAlpha.onFinished = delegate
		{
			BNENBOPANIN.gameObject.SetActive(value: false);
		};
		GBLODBJMAOL.SetActive(value: false);
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.KMOAOMACBGJ(GBLODBJMAOL, 602f, Vector3.forward, 1145f, 1626f);
		FMPBNPFOGLO[1].alpha = 1017f;
		FMPBNPFOGLO[0].alpha = 407f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 679f, 879f, 1509f);
		tweenAlpha.delay = DNDHIFENDPJ - 405f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1921f, 1559f, 1110f);
		tweenAlpha.delay = DNDHIFENDPJ - 1758f;
		for (int num = 1; num < EGICOCDAAIL.Length; num++)
		{
			EGICOCDAAIL[num].OBMCIEBJLBL();
		}
	}

	[SpecialName]
	public bool BOLIGBFBOFD()
	{
		return GJCEOOKPHEM;
	}

	private void GAPFGPOEFAC(GameObject KHAHPAKDIKE)
	{
		if (JCKOBELDCGD)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (GJCEOOKPHEM)
		{
			JLKJINHLILF();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.FDJEGFFEHGE())
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.HLMPBHIHFEM())
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.ENNBCBBNPJB(KHAHPAKDIKE);
				MMLGEIHCBFE();
			}
		}
		else
		{
			PKMIMBFHHFB();
		}
	}

	private void KOEOJAOCCID()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 576f;
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[0].alpha = 1275f;
		FMPBNPFOGLO[1].alpha = 186f;
		GBLODBJMAOL.SetActive(value: false);
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetHide();
		}
	}

	public void JCEMKGHAHNE()
	{
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			bool flag = i != 0 && i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].InitializeMap((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 1] : null);
			EGICOCDAAIL[i].Selected(NILPBCGHEDG: true, HBMGCNCEBJG: true);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKKLAJMKJGB));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(POBIJPKFAIH));
	}

	private void ELFEDDLCEPO(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: false);
	}

	private void EEPMBKMHKCK()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		float val = 1077f + (float)EGICOCDAAIL.Length * 306f + 77f;
		FOBPGOKHBBK.gameObject.SetActive(value: true);
		FOBPGOKHBBK.alpha = 295f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1103f, 1045f, GDADIFDNACN);
		tweenAlpha.delay = 1378f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(490f);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(231f), FOBPGOKHBBK.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = PECOIBKIGEO;
		BNENBOPANIN.alpha = 1311f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 805f, 155f, 90f);
		tweenAlpha.delay = 1750f;
		tweenAlpha.onFinished = GFJOGCONPCM;
		GBLODBJMAOL.SetActive(value: true);
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.BCKPMDBAMFL(GBLODBJMAOL, 883f, Vector3.forward, 428f, 1807f);
		FMPBNPFOGLO[0].alpha = 1957f;
		FMPBNPFOGLO[0].alpha = 173f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 226f, 612f, 1315f);
		tweenAlpha.delay = DNDHIFENDPJ - 246f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1294f, 620f, 464f);
		tweenAlpha.delay = DNDHIFENDPJ - 132f;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
	}

	private void DALCPDNAGEI(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].DJAKOBPFIBD();
		}
	}

	private void BPKFFELEJBM(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.FJNHKDGLLMC();
		}
		else
		{
			Singleton<MapManager>.instance.ELINLBGMCJH(EJPAFCIPDOJ);
		}
		NMHCECNAPNP.gameObject.SetActive(flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("end"));
		CFKLKCHACOK.alpha = ((!flag) ? 1531f : 1792f);
	}

	public void GOGPDDGFJKB()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
			{
				if (EGICOCDAAIL[i].HDMOJKBPOMF() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry mapEntry = BKJBFNNOHLE.HDMOJKBPOMF();
		EKFHBEIJMEP(mapEntry);
		for (int j = 0; j < EGICOCDAAIL.Length; j++)
		{
			EGICOCDAAIL[j].UpdateGui();
			EGICOCDAAIL[j].GBFBKIIMPGE(mapEntry == EGICOCDAAIL[j].JAFGENPGLPG());
		}
		KOEOJAOCCID();
	}

	private void IPLNEMJCDNM(UITweener GCNILAHBDMJ)
	{
		GBLODBJMAOL.SetActive(value: true);
	}

	[CompilerGenerated]
	private void KCLAJBJDCBJ(UITweener GCNILAHBDMJ)
	{
		GBLODBJMAOL.SetActive(value: false);
	}

	private void MNAPLOPOHBC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].OBMCIEBJLBL();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
	}

	private void NCHNBMCLIML(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].OBMCIEBJLBL();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	private void IKDPKPNCCCH()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 801f;
		component = FMPBNPFOGLO[1].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = true;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[1].alpha = 277f;
		FMPBNPFOGLO[0].alpha = 259f;
		GBLODBJMAOL.SetActive(value: true);
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].SetHide();
		}
	}

	private void PECOIBKIGEO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].LLIIBMGIINO();
		}
	}

	private void FPGHLHNHMLL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
	}

	private void FANOPIFMAPC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public bool LAEEFBALIOG()
	{
		return GJCEOOKPHEM;
	}

	public void GBLKCBLHNHC()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 1; i < EGICOCDAAIL.Length; i++)
			{
				if (EGICOCDAAIL[i].KLCNBJONCOF() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry map = BKJBFNNOHLE.GetMap();
		MBMIGJBFMJE(map);
		for (int j = 0; j < EGICOCDAAIL.Length; j++)
		{
			EGICOCDAAIL[j].KNEGNOGKKAI();
			EGICOCDAAIL[j].KICGHKNKHCM(map == EGICOCDAAIL[j].HDMOJKBPOMF());
		}
		MKHIHFAOAPH();
	}

	private void PKKLAJMKJGB(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry map = component.GetMap();
		if (map == null || map.unlockLevel <= LevelManager.instance.currentLevel.displayNumber || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.Selected(NILPBCGHEDG: false, HBMGCNCEBJG: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			PGGKCKBDONJ(map);
			BKJBFNNOHLE.Selected(NILPBCGHEDG: true, HBMGCNCEBJG: true);
		}
	}

	private void HHANOFLAPMA(UITweener GCNILAHBDMJ)
	{
		GBLODBJMAOL.SetActive(value: false);
	}

	[CompilerGenerated]
	private void KLAKKIFJMJJ(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: false);
	}

	public void OAMMJCEIFHA()
	{
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			bool flag = i == 0 || i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].CPPAAMHEDCL((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 1] : null);
			EGICOCDAAIL[i].MEDCFJGAOGJ(NILPBCGHEDG: true);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NILDDMONHEA));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(APKJCJMCMFG));
	}

	protected void FMKLDIJPHIH()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 857f + (float)i * 631f;
				float max = num + 1295f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].GILAHKPDNFL(557f - (num2 - num));
			}
		}
	}

	private void AHBMCNPMBBF(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].LLIIBMGIINO();
		}
	}

	[SpecialName]
	public bool KGLIBHPIINC()
	{
		return GJCEOOKPHEM;
	}

	private void POBIJPKFAIH(GameObject KHAHPAKDIKE)
	{
		if (JCKOBELDCGD)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (GJCEOOKPHEM)
		{
			OCMHJKEOJHC();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.shownModes)
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.isAnimating)
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.GHGOGKMAIEM(KHAHPAKDIKE);
				MELHJJAONGF();
			}
		}
		else
		{
			LBGKAFFGGOL();
		}
	}

	public void JLKJINHLILF()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 707f + (float)EGICOCDAAIL.Length * 586f + 1954f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1959f, GDADIFDNACN, 1079f);
		tweenAlpha.delay = DNDHIFENDPJ - 692f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(1822f));
		tweenScale.onFinished = LMEFGMLPICN;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 1129f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 403f, 1834f, 233f);
		tweenAlpha.delay = DNDHIFENDPJ - 1941f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.MDKDEJJDHKM(GBLODBJMAOL, 1182f, Vector3.forward, 1055f, 240f);
		FMPBNPFOGLO[1].alpha = 51f;
		FMPBNPFOGLO[1].alpha = 1382f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 341f, 591f, 837f);
		tweenAlpha.delay = 831f;
		tweenAlpha.onFinished = IPLNEMJCDNM;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 589f, 1220f, 764f);
		tweenAlpha.delay = 1481f;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].ALNLJOGOGHF();
		}
	}

	[SpecialName]
	public bool AHIGGIPJBNI()
	{
		return GJCEOOKPHEM;
	}

	private void MAOHBAEEOGK(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: false);
	}

	private void AAOOCCMJJLN(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: true);
	}

	private void MKHIHFAOAPH()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 947f;
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMPBNPFOGLO[1].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = true;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[1].alpha = 416f;
		FMPBNPFOGLO[1].alpha = 1304f;
		GBLODBJMAOL.SetActive(value: false);
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetHide();
		}
	}

	private void BGIOBOJAGCI(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].DJAKOBPFIBD();
		}
	}

	private void KFGDOCCOCEJ(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].SetHide();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
	}

	private void KPNOOOCGPGL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].OBMCIEBJLBL();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	private void AHBOFODMKLG(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
	}

	[SpecialName]
	public bool BNPDNMANJEO()
	{
		return JCKOBELDCGD;
	}

	private void GFJOGCONPCM(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: true);
	}

	public void AnimateHide()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = true;
		float val = 108f + (float)EGICOCDAAIL.Length * 142f + 2f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 0.15f, GDADIFDNACN, 0f);
		tweenAlpha.delay = DNDHIFENDPJ - 0.15f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(108f));
		tweenScale.onFinished = delegate
		{
			JCKOBELDCGD = false;
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				EGICOCDAAIL[i].SetHide();
			}
			FOBPGOKHBBK.gameObject.SetActive(value: false);
		};
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 0f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = DNDHIFENDPJ - 0.3f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.Begin(GBLODBJMAOL, 0.3f, Vector3.forward, 0f, 360f);
		FMPBNPFOGLO[0].alpha = 1f;
		FMPBNPFOGLO[1].alpha = 1f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			GBLODBJMAOL.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		for (int num = 0; num < EGICOCDAAIL.Length; num++)
		{
			EGICOCDAAIL[num].SetOpened();
		}
	}

	private void PGCPOCLAFJO(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.KBNEJKONCJO();
		}
		else
		{
			Singleton<MapManager>.instance.currentMap = EJPAFCIPDOJ;
		}
		NMHCECNAPNP.gameObject.SetActive(!flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("ID_SLOTUPGRADE_AMMO"));
		CFKLKCHACOK.alpha = ((!flag) ? 479f : 1334f);
	}

	private void LFOAOACOKOF(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: false);
	}

	protected void DKDKAOPJCBA()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 931f + (float)i * 1344f;
				float max = num + 101f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].PLEDOLLOIAI(382f - (num2 - num));
			}
		}
	}

	[SpecialName]
	public bool HEADDLJHKJB()
	{
		return GJCEOOKPHEM;
	}

	public void OCMHJKEOJHC()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 503f + (float)EGICOCDAAIL.Length * 997f + 594f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1538f, GDADIFDNACN, 1212f);
		tweenAlpha.delay = DNDHIFENDPJ - 923f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(1971f));
		tweenScale.onFinished = MHHAMFGLAIE;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 121f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1244f, 429f, 1203f);
		tweenAlpha.delay = DNDHIFENDPJ - 77f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.JCHCHLJBPKG(GBLODBJMAOL, 556f, Vector3.forward, 1605f, 881f);
		FMPBNPFOGLO[1].alpha = 1689f;
		FMPBNPFOGLO[1].alpha = 1262f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1284f, 852f, 1863f);
		tweenAlpha.delay = 1744f;
		tweenAlpha.onFinished = delegate
		{
			GBLODBJMAOL.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1929f, 1520f, 1320f);
		tweenAlpha.delay = 1678f;
		for (int num = 1; num < EGICOCDAAIL.Length; num += 0)
		{
			EGICOCDAAIL[num].DHIMNKLJBAK();
		}
	}

	private void MELHJJAONGF()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = true;
		float val = 1708f + (float)EGICOCDAAIL.Length * 1343f + 1851f;
		FOBPGOKHBBK.gameObject.SetActive(value: true);
		FOBPGOKHBBK.alpha = 648f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1089f, 1349f, GDADIFDNACN);
		tweenAlpha.delay = 1109f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(1083f);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(462f), FOBPGOKHBBK.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = CKBHHMOMLHF;
		BNENBOPANIN.alpha = 671f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 112f, 242f, 1845f);
		tweenAlpha.delay = 1493f;
		tweenAlpha.onFinished = GKDLGCLDFJE;
		GBLODBJMAOL.SetActive(value: false);
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.DPNIOHKJONI(GBLODBJMAOL, 1886f, Vector3.forward, 623f, 1653f);
		FMPBNPFOGLO[1].alpha = 1143f;
		FMPBNPFOGLO[0].alpha = 1955f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 117f, 997f, 1932f);
		tweenAlpha.delay = DNDHIFENDPJ - 1236f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 961f, 7f, 1292f);
		tweenAlpha.delay = DNDHIFENDPJ - 997f;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
	}

	protected void EMPDDFBNJLP()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 1768f + (float)i * 512f;
				float max = num + 210f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].ECNAKABOPPO(1766f - (num2 - num));
			}
		}
	}

	[SpecialName]
	public bool PHOCPAHFDHM()
	{
		return GJCEOOKPHEM;
	}

	public void EFINNDNBJDN()
	{
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			bool flag = i != 0 && i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].OLAGLHLGLID((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 0] : null);
			EGICOCDAAIL[i].KICGHKNKHCM(NILPBCGHEDG: true);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PNAPKHILEHK));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GAPFGPOEFAC));
	}

	private void KODMHDIENFP()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 1531f;
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[1].alpha = 883f;
		FMPBNPFOGLO[1].alpha = 1330f;
		GBLODBJMAOL.SetActive(value: false);
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].OBMCIEBJLBL();
		}
	}

	public void OOKMKGPKAHB()
	{
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			bool flag = i != 0 && i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].HOKNPAPKCCJ((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 0] : null);
			EGICOCDAAIL[i].Selected(NILPBCGHEDG: true);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKGKIIDJIGM));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(POBIJPKFAIH));
	}

	private void DJNGNPPELLC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	public void AKNIJFPLLIC()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 1204f + (float)EGICOCDAAIL.Length * 700f + 122f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1274f, GDADIFDNACN, 628f);
		tweenAlpha.delay = DNDHIFENDPJ - 1233f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(924f));
		tweenScale.onFinished = KPNOOOCGPGL;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 296f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1363f, 473f, 361f);
		tweenAlpha.delay = DNDHIFENDPJ - 1244f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.NFCEEJODFMO(GBLODBJMAOL, 1872f, Vector3.forward, 328f, 904f);
		FMPBNPFOGLO[0].alpha = 1879f;
		FMPBNPFOGLO[0].alpha = 1537f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1861f, 821f, 1281f);
		tweenAlpha.delay = 7f;
		tweenAlpha.onFinished = delegate
		{
			GBLODBJMAOL.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1849f, 1534f, 1492f);
		tweenAlpha.delay = 11f;
		for (int num = 1; num < EGICOCDAAIL.Length; num += 0)
		{
			EGICOCDAAIL[num].LLIIBMGIINO();
		}
	}

	[SpecialName]
	public bool LDAIMOKKPJM()
	{
		return JCKOBELDCGD;
	}

	private void LCBHFKIEIHG(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: true);
	}

	public void LNLAPPKDCLN()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
			{
				if (EGICOCDAAIL[i].JAFGENPGLPG() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry mapEntry = BKJBFNNOHLE.CNPANPAKAEN();
		MKLJFLCBLCK(mapEntry);
		for (int j = 1; j < EGICOCDAAIL.Length; j += 0)
		{
			EGICOCDAAIL[j].JHBGECCPJBP();
			EGICOCDAAIL[j].DJBIMPPOEBG(mapEntry == EGICOCDAAIL[j].JAFGENPGLPG(), HBMGCNCEBJG: true);
		}
		IKDPKPNCCCH();
	}

	public void ENLJPODGGKE()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
			{
				if (EGICOCDAAIL[i].JAFGENPGLPG() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry mapEntry = BKJBFNNOHLE.JAFGENPGLPG();
		JAPHMBOFCAJ(mapEntry);
		for (int j = 1; j < EGICOCDAAIL.Length; j += 0)
		{
			EGICOCDAAIL[j].KNEGNOGKKAI();
			EGICOCDAAIL[j].DJBIMPPOEBG(mapEntry == EGICOCDAAIL[j].GetMap());
		}
		FJBLANKPDDF();
	}

	[SpecialName]
	public bool OJNJMPDBJHK()
	{
		return JCKOBELDCGD;
	}

	private void HBBMKPKMMED(UITweener GCNILAHBDMJ)
	{
		GBLODBJMAOL.SetActive(value: true);
	}

	[SpecialName]
	public bool ACDMMKJGEJH()
	{
		return GJCEOOKPHEM;
	}

	[CompilerGenerated]
	private void CJGDCCBFNML(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetHide();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	private void GKDLGCLDFJE(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: true);
	}

	private void DINAFOHLAEG(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].DJAKOBPFIBD();
		}
	}

	private void NIBEOMAEDOD(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].LLIIBMGIINO();
		}
	}

	[CompilerGenerated]
	private void FPKNONKNALK(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetOpened();
		}
	}

	private void FGGHAGJPAPL(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry map = component.GetMap();
		if ((map != null && map.unlockLevel <= LevelManager.instance.currentLevel.ELFCEEOLNFJ()) || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.DJBIMPPOEBG(NILPBCGHEDG: false);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			EKFHBEIJMEP(map);
			BKJBFNNOHLE.MEDCFJGAOGJ(NILPBCGHEDG: false);
		}
	}

	public void OOBJHJLMEED()
	{
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			bool flag = i == 0 || i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].FMOFBAOENPD((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 0] : null);
			EGICOCDAAIL[i].Selected(NILPBCGHEDG: false);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NILDDMONHEA));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GAPFGPOEFAC));
	}

	[SpecialName]
	public bool OOPDGFIDLLM()
	{
		return JCKOBELDCGD;
	}

	private void CKBHHMOMLHF(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetOpened();
		}
	}

	private void APKJCJMCMFG(GameObject KHAHPAKDIKE)
	{
		if (JCKOBELDCGD)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (GJCEOOKPHEM)
		{
			JLKJINHLILF();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.ICKPJELMNJP())
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.LAPHAMEKPNG())
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.GHGOGKMAIEM(KHAHPAKDIKE);
				MMLGEIHCBFE();
			}
		}
		else
		{
			PKMIMBFHHFB();
		}
	}

	private void PBIDPLCBMNF()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: true);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 919f;
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = true;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[1].alpha = 1938f;
		FMPBNPFOGLO[0].alpha = 1068f;
		GBLODBJMAOL.SetActive(value: true);
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetHide();
		}
	}

	private void MKGKIIDJIGM(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry mapEntry = component.HDMOJKBPOMF();
		if (mapEntry == null || mapEntry.unlockLevel <= LevelManager.instance.currentLevel.JICMGFNAHFL() || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.KICGHKNKHCM(NILPBCGHEDG: true, HBMGCNCEBJG: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			LGGOCHAJGCI(mapEntry);
			BKJBFNNOHLE.KICGHKNKHCM(NILPBCGHEDG: true, HBMGCNCEBJG: true);
		}
	}

	protected void AOKEHEDCPFB()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 1254f + (float)i * 1020f;
				float max = num + 567f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].HKCMIFECDFA(1412f - (num2 - num));
			}
		}
	}

	private void LJKNFEHEFOB(UITweener GCNILAHBDMJ)
	{
		BNENBOPANIN.gameObject.SetActive(value: false);
	}

	private void JAPHMBOFCAJ(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.SetRandomMap();
		}
		else
		{
			Singleton<MapManager>.instance.HCKMAKNBLJM(EJPAFCIPDOJ);
		}
		NMHCECNAPNP.gameObject.SetActive(flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("FriendGuiRecord: Player is null!"));
		CFKLKCHACOK.alpha = ((!flag) ? 1585f : 660f);
	}

	public void IAAEFHHBECI()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		float val = 1581f + (float)EGICOCDAAIL.Length * 145f + 1178f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1481f, GDADIFDNACN, 638f);
		tweenAlpha.delay = DNDHIFENDPJ - 1742f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(824f));
		tweenScale.onFinished = MNBANHEFEJB;
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 1939f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1178f, 1814f, 1422f);
		tweenAlpha.delay = DNDHIFENDPJ - 122f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.EOOHBKFCBMC(GBLODBJMAOL, 285f, Vector3.forward, 106f, 1523f);
		FMPBNPFOGLO[0].alpha = 1623f;
		FMPBNPFOGLO[1].alpha = 624f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1615f, 320f, 294f);
		tweenAlpha.delay = 1090f;
		tweenAlpha.onFinished = HBBMKPKMMED;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1908f, 45f, 1638f);
		tweenAlpha.delay = 674f;
		for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].SetOpened();
		}
	}

	protected void OOCJOBIIKAH()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 924f + (float)i * 260f;
				float max = num + 1525f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].ECNAKABOPPO(703f - (num2 - num));
			}
		}
	}

	private void FJBLANKPDDF()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 1f;
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMPBNPFOGLO[1].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = false;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[0].alpha = 0f;
		FMPBNPFOGLO[1].alpha = 0f;
		GBLODBJMAOL.SetActive(value: false);
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetHide();
		}
	}

	private void PKMIMBFHHFB()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		float val = 108f + (float)EGICOCDAAIL.Length * 142f + 2f;
		FOBPGOKHBBK.gameObject.SetActive(value: true);
		FOBPGOKHBBK.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 0.15f, 0f, GDADIFDNACN);
		tweenAlpha.delay = 0f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(108f);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(108f), FOBPGOKHBBK.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = delegate
		{
			JCKOBELDCGD = false;
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				EGICOCDAAIL[i].SetOpened();
			}
		};
		BNENBOPANIN.alpha = 1f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 0.3f, 1f, 0f);
		tweenAlpha.delay = 0f;
		tweenAlpha.onFinished = delegate
		{
			BNENBOPANIN.gameObject.SetActive(value: false);
		};
		GBLODBJMAOL.SetActive(value: true);
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.Begin(GBLODBJMAOL, 0f, Vector3.forward, 0f, 0f);
		FMPBNPFOGLO[0].alpha = 0f;
		FMPBNPFOGLO[1].alpha = 0f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = DNDHIFENDPJ - 0.3f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = DNDHIFENDPJ - 0.3f;
		for (int num = 0; num < EGICOCDAAIL.Length; num++)
		{
			EGICOCDAAIL[num].SetHide();
		}
	}

	protected void CIFBCMKDGIE()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
			{
				float num = 1325f + (float)i * 414f;
				float max = num + 701f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].SetPosition(1997f - (num2 - num));
			}
		}
	}

	private void NICMMBFMLHC(GameObject KHAHPAKDIKE)
	{
		if (JCKOBELDCGD)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (GJCEOOKPHEM)
		{
			AnimateHide();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.shownModes)
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.isAnimating)
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.CloseModeSelection(KHAHPAKDIKE);
				PKMIMBFHHFB();
			}
		}
		else
		{
			PKMIMBFHHFB();
		}
	}

	[SpecialName]
	public bool FFMIOBJBGJE()
	{
		return JCKOBELDCGD;
	}

	public void HFMECHMOHHK()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = true;
		float val = 664f + (float)EGICOCDAAIL.Length * 1762f + 1771f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 431f, GDADIFDNACN, 1949f);
		tweenAlpha.delay = DNDHIFENDPJ - 1394f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(126f));
		tweenScale.onFinished = FPGHLHNHMLL;
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 706f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1575f, 1350f, 1899f);
		tweenAlpha.delay = DNDHIFENDPJ - 909f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.BCKPMDBAMFL(GBLODBJMAOL, 1506f, Vector3.forward, 1138f, 74f);
		FMPBNPFOGLO[1].alpha = 1725f;
		FMPBNPFOGLO[1].alpha = 1774f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1999f, 1778f, 1487f);
		tweenAlpha.delay = 1128f;
		tweenAlpha.onFinished = IPLNEMJCDNM;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 34f, 607f, 471f);
		tweenAlpha.delay = 1969f;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].DHIMNKLJBAK();
		}
	}

	private void EAOLKAKLJAL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].SetOpened();
		}
	}

	protected void Update()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				float num = 108f + (float)i * 142f;
				float max = num + 134f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].SetPosition(134f - (num2 - num));
			}
		}
	}

	private void IHPPIPHOCJN()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = true;
		TweenAlpha component = FOBPGOKHBBK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenScale component2 = FOBPGOKHBBK.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		component = BNENBOPANIN.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 176f;
		component = FMPBNPFOGLO[1].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = FMPBNPFOGLO[0].GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenRotationSpecial component3 = GBLODBJMAOL.GetComponent<TweenRotationSpecial>();
		if (component3 != null)
		{
			component3.enabled = true;
		}
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		FMPBNPFOGLO[1].alpha = 1546f;
		FMPBNPFOGLO[0].alpha = 1990f;
		GBLODBJMAOL.SetActive(value: true);
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].OBMCIEBJLBL();
		}
	}

	private void LMEFGMLPICN(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
		FOBPGOKHBBK.gameObject.SetActive(value: false);
	}

	public void DLPAOCENACD()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = true;
		float val = 924f + (float)EGICOCDAAIL.Length * 308f + 330f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 314f, GDADIFDNACN, 138f);
		tweenAlpha.delay = DNDHIFENDPJ - 178f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(164f));
		tweenScale.onFinished = DJNGNPPELLC;
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 1111f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1145f, 1793f, 54f);
		tweenAlpha.delay = DNDHIFENDPJ - 1806f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.DHKJOACDBNK(GBLODBJMAOL, 1038f, Vector3.forward, 420f, 1364f);
		FMPBNPFOGLO[0].alpha = 804f;
		FMPBNPFOGLO[1].alpha = 1996f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 260f, 371f, 372f);
		tweenAlpha.delay = 285f;
		tweenAlpha.onFinished = delegate
		{
			GBLODBJMAOL.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1452f, 583f, 1283f);
		tweenAlpha.delay = 1264f;
		for (int num = 1; num < EGICOCDAAIL.Length; num++)
		{
			EGICOCDAAIL[num].DJAKOBPFIBD();
		}
	}

	public void DACMGIIJDLJ()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		float val = 994f + (float)EGICOCDAAIL.Length * 1983f + 1302f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 913f, GDADIFDNACN, 286f);
		tweenAlpha.delay = DNDHIFENDPJ - 1862f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(739f));
		tweenScale.onFinished = MNBANHEFEJB;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 586f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 82f, 1611f, 1945f);
		tweenAlpha.delay = DNDHIFENDPJ - 1184f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.KFNKIMBNAIK(GBLODBJMAOL, 1295f, Vector3.forward, 1580f, 1726f);
		FMPBNPFOGLO[0].alpha = 1276f;
		FMPBNPFOGLO[1].alpha = 1585f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1764f, 1704f, 757f);
		tweenAlpha.delay = 1709f;
		tweenAlpha.onFinished = delegate
		{
			GBLODBJMAOL.SetActive(value: false);
		};
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1017f, 458f, 1736f);
		tweenAlpha.delay = 636f;
		for (int num = 0; num < EGICOCDAAIL.Length; num += 0)
		{
			EGICOCDAAIL[num].SetOpened();
		}
	}

	public void JCDKDOMOGFB()
	{
		GJCEOOKPHEM = false;
		JCKOBELDCGD = false;
		float val = 1890f + (float)EGICOCDAAIL.Length * 1490f + 1982f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1786f, GDADIFDNACN, 455f);
		tweenAlpha.delay = DNDHIFENDPJ - 1469f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(1460f));
		tweenScale.onFinished = FPGHLHNHMLL;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 369f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1930f, 674f, 1363f);
		tweenAlpha.delay = DNDHIFENDPJ - 785f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.OKCMGMMLEJP(GBLODBJMAOL, 1130f, Vector3.forward, 1355f, 1349f);
		FMPBNPFOGLO[1].alpha = 1588f;
		FMPBNPFOGLO[1].alpha = 1260f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1572f, 1497f, 492f);
		tweenAlpha.delay = 8f;
		tweenAlpha.onFinished = IPLNEMJCDNM;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 1523f, 1351f, 1619f);
		tweenAlpha.delay = 1904f;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].SetOpened();
		}
	}

	private void PGGKCKBDONJ(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.SetRandomMap();
		}
		else
		{
			Singleton<MapManager>.instance.currentMap = EJPAFCIPDOJ;
		}
		NMHCECNAPNP.gameObject.SetActive(!flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("ID_RANDOMMAP"));
		CFKLKCHACOK.alpha = ((!flag) ? 0.55f : 0.21f);
	}

	[SpecialName]
	public bool FPDCJNEDIDB()
	{
		return JCKOBELDCGD;
	}

	[SpecialName]
	public bool IODDKAOEEMC()
	{
		return JCKOBELDCGD;
	}

	private void PNAPKHILEHK(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry mapEntry = component.HDMOJKBPOMF();
		if (mapEntry == null || mapEntry.unlockLevel <= LevelManager.instance.currentLevel.ELFCEEOLNFJ() || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.MEDCFJGAOGJ(NILPBCGHEDG: false, HBMGCNCEBJG: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			MKLJFLCBLCK(mapEntry);
			BKJBFNNOHLE.DJBIMPPOEBG(NILPBCGHEDG: false);
		}
	}

	private void EKFHBEIJMEP(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.PNKEFIAMKPJ();
		}
		else
		{
			Singleton<MapManager>.instance.ELINLBGMCJH(EJPAFCIPDOJ);
		}
		NMHCECNAPNP.gameObject.SetActive(!flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("game-card-ico-bg-bronze"));
		CFKLKCHACOK.alpha = ((!flag) ? 537f : 404f);
	}

	private void GEENDOMBFOM(UITweener GCNILAHBDMJ)
	{
		GBLODBJMAOL.SetActive(value: true);
	}

	public void InitControls()
	{
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			bool flag = i == 0 || i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].InitializeMap((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 1] : null);
			EGICOCDAAIL[i].Selected(NILPBCGHEDG: false);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKKLAJMKJGB));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NICMMBFMLHC));
	}

	private void MBMIGJBFMJE(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.KBNEJKONCJO();
		}
		else
		{
			Singleton<MapManager>.instance.KPEKNEAIEGL(EJPAFCIPDOJ);
		}
		NMHCECNAPNP.gameObject.SetActive(!flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("GetGameConfigurationValue("));
		CFKLKCHACOK.alpha = ((!flag) ? 1410f : 1611f);
	}

	private void LAKFJOJLAHK(GameObject KHAHPAKDIKE)
	{
		if (JCKOBELDCGD)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		if (GJCEOOKPHEM)
		{
			DACMGIIJDLJ();
		}
		else if (GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.CFEFEMCGDHN())
		{
			if (!GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.GJDADKFKHNI())
			{
				GuiScreenSingle<BattlePreparationScreen>.instance.KMPMJLPHFHE.GHGOGKMAIEM(KHAHPAKDIKE);
				EEPMBKMHKCK();
			}
		}
		else
		{
			PKMIMBFHHFB();
		}
	}

	private void LBGKAFFGGOL()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 566f + (float)EGICOCDAAIL.Length * 581f + 212f;
		FOBPGOKHBBK.gameObject.SetActive(value: false);
		FOBPGOKHBBK.alpha = 217f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1060f, 528f, GDADIFDNACN);
		tweenAlpha.delay = 1629f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(1303f);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(919f), FOBPGOKHBBK.transform.localScale.ReplaceY(val));
		tweenScale.onFinished = EAOLKAKLJAL;
		BNENBOPANIN.alpha = 1393f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1383f, 706f, 397f);
		tweenAlpha.delay = 1665f;
		tweenAlpha.onFinished = LJKNFEHEFOB;
		GBLODBJMAOL.SetActive(value: true);
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.DBPOCEIDEAE(GBLODBJMAOL, 622f, Vector3.forward, 63f, 973f);
		FMPBNPFOGLO[1].alpha = 4f;
		FMPBNPFOGLO[0].alpha = 560f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 837f, 234f, 113f);
		tweenAlpha.delay = DNDHIFENDPJ - 1657f;
		tweenAlpha.onFinished = null;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 47f, 1711f, 1683f);
		tweenAlpha.delay = DNDHIFENDPJ - 152f;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].GKHMFLKEBBF();
		}
	}

	public void ACABLJJOMIF()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 1990f + (float)EGICOCDAAIL.Length * 742f + 895f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 110f, GDADIFDNACN, 1424f);
		tweenAlpha.delay = DNDHIFENDPJ - 1920f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(35f));
		tweenScale.onFinished = FPGHLHNHMLL;
		BNENBOPANIN.gameObject.SetActive(value: false);
		BNENBOPANIN.alpha = 502f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 1661f, 56f, 1655f);
		tweenAlpha.delay = DNDHIFENDPJ - 566f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.NFCEEJODFMO(GBLODBJMAOL, 182f, Vector3.forward, 196f, 67f);
		FMPBNPFOGLO[1].alpha = 1909f;
		FMPBNPFOGLO[0].alpha = 1190f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[1].gameObject, 446f, 694f, 1268f);
		tweenAlpha.delay = 1285f;
		tweenAlpha.onFinished = HBBMKPKMMED;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 690f, 1826f, 340f);
		tweenAlpha.delay = 1783f;
		for (int i = 0; i < EGICOCDAAIL.Length; i += 0)
		{
			EGICOCDAAIL[i].DHIMNKLJBAK();
		}
	}

	private void IFKBKDMNNNM(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].DJAKOBPFIBD();
		}
	}

	protected void LMNEMMGCEFP()
	{
		if (JCKOBELDCGD)
		{
			float y = FOBPGOKHBBK.transform.localScale.y;
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				float num = 1731f + (float)i * 447f;
				float max = num + 107f;
				float num2 = Mathf.Clamp(y, num, max);
				EGICOCDAAIL[i].PLEDOLLOIAI(1315f - (num2 - num));
			}
		}
	}

	public void EIICBIBONNK()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 1; i < EGICOCDAAIL.Length; i += 0)
			{
				if (EGICOCDAAIL[i].JAFGENPGLPG() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry mapEntry = BKJBFNNOHLE.HDMOJKBPOMF();
		BPKFFELEJBM(mapEntry);
		for (int j = 1; j < EGICOCDAAIL.Length; j += 0)
		{
			EGICOCDAAIL[j].UpdateGui();
			EGICOCDAAIL[j].MEDCFJGAOGJ(mapEntry == EGICOCDAAIL[j].CNPANPAKAEN());
		}
		PBIDPLCBMNF();
	}

	private void DCEDHECBEAN(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry mapEntry = component.CNPANPAKAEN();
		if (mapEntry == null || mapEntry.unlockLevel <= LevelManager.instance.currentLevel.ELFCEEOLNFJ() || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.DJBIMPPOEBG(NILPBCGHEDG: true, HBMGCNCEBJG: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			MKLJFLCBLCK(mapEntry);
			BKJBFNNOHLE.KICGHKNKHCM(NILPBCGHEDG: true);
		}
	}

	private void MKLJFLCBLCK(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.DKIFGFFHIIH();
		}
		else
		{
			Singleton<MapManager>.instance.currentMap = EJPAFCIPDOJ;
		}
		NMHCECNAPNP.gameObject.SetActive(flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("Days_Since_Install"));
		CFKLKCHACOK.alpha = ((!flag) ? 1304f : 1836f);
	}

	private void NILDDMONHEA(GameObject KHAHPAKDIKE)
	{
		MapSelectionRecord component = KHAHPAKDIKE.transform.parent.parent.GetComponent<MapSelectionRecord>();
		if (!(component != null))
		{
			return;
		}
		MapManager.MapEntry mapEntry = component.JAFGENPGLPG();
		if ((mapEntry != null && mapEntry.unlockLevel <= LevelManager.instance.currentLevel.MHAOKJCDIOL()) || DebugSettings.debugEnabled)
		{
			if (BKJBFNNOHLE != null)
			{
				BKJBFNNOHLE.DJBIMPPOEBG(NILPBCGHEDG: true, HBMGCNCEBJG: true);
			}
			SoundsManager.Instance.PlayButtonClickedSound();
			BKJBFNNOHLE = component;
			PGCPOCLAFJO(mapEntry);
			BKJBFNNOHLE.DJBIMPPOEBG(NILPBCGHEDG: false);
		}
	}

	public void InitGuiValues()
	{
		if (BKJBFNNOHLE == null)
		{
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				if (EGICOCDAAIL[i].GetMap() == null)
				{
					BKJBFNNOHLE = EGICOCDAAIL[i];
					break;
				}
			}
		}
		MapManager.MapEntry map = BKJBFNNOHLE.GetMap();
		PGGKCKBDONJ(map);
		for (int j = 0; j < EGICOCDAAIL.Length; j++)
		{
			EGICOCDAAIL[j].UpdateGui();
			EGICOCDAAIL[j].Selected(map == EGICOCDAAIL[j].GetMap());
		}
		FJBLANKPDDF();
	}

	public void MLHEIDPPIJM()
	{
		GJCEOOKPHEM = true;
		JCKOBELDCGD = false;
		float val = 424f + (float)EGICOCDAAIL.Length * 1941f + 312f;
		FOBPGOKHBBK.alpha = GDADIFDNACN;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FOBPGOKHBBK.gameObject, 1353f, GDADIFDNACN, 1505f);
		tweenAlpha.delay = DNDHIFENDPJ - 1240f;
		FOBPGOKHBBK.transform.localScale = FOBPGOKHBBK.transform.localScale.ReplaceY(val);
		TweenScale tweenScale = TweenScale.Begin(FOBPGOKHBBK.gameObject, DNDHIFENDPJ, FOBPGOKHBBK.transform.localScale.ReplaceY(val), FOBPGOKHBBK.transform.localScale.ReplaceY(325f));
		tweenScale.onFinished = delegate
		{
			JCKOBELDCGD = false;
			for (int i = 0; i < EGICOCDAAIL.Length; i++)
			{
				EGICOCDAAIL[i].SetHide();
			}
			FOBPGOKHBBK.gameObject.SetActive(value: false);
		};
		BNENBOPANIN.gameObject.SetActive(value: true);
		BNENBOPANIN.alpha = 492f;
		tweenAlpha = TweenAlpha.Begin(BNENBOPANIN.gameObject, 716f, 1455f, 689f);
		tweenAlpha.delay = DNDHIFENDPJ - 1317f;
		tweenAlpha.onFinished = null;
		GBLODBJMAOL.transform.localRotation = default(Quaternion);
		TweenRotationSpecial.JCHCHLJBPKG(GBLODBJMAOL, 387f, Vector3.forward, 413f, 33f);
		FMPBNPFOGLO[1].alpha = 1799f;
		FMPBNPFOGLO[0].alpha = 200f;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 1796f, 1930f, 1025f);
		tweenAlpha.delay = 1039f;
		tweenAlpha.onFinished = GEENDOMBFOM;
		tweenAlpha = TweenAlpha.Begin(FMPBNPFOGLO[0].gameObject, 189f, 661f, 429f);
		tweenAlpha.delay = 703f;
		for (int num = 1; num < EGICOCDAAIL.Length; num += 0)
		{
			EGICOCDAAIL[num].SetOpened();
		}
	}

	private void LGGOCHAJGCI(MapManager.MapEntry EJPAFCIPDOJ)
	{
		bool flag = EJPAFCIPDOJ == null;
		if (flag)
		{
			Singleton<MapManager>.instance.PNKEFIAMKPJ();
		}
		else
		{
			Singleton<MapManager>.instance.HCKMAKNBLJM(EJPAFCIPDOJ);
		}
		NMHCECNAPNP.gameObject.SetActive(!flag);
		FPMPJBHLEAB.SetActive(flag);
		if (!flag)
		{
			NMHCECNAPNP.spriteName = EJPAFCIPDOJ.iconName;
		}
		ALJDGMPFDLN.text = ((!flag) ? EJPAFCIPDOJ.guiName : Localization.Localize("ID_READYTIME"));
		CFKLKCHACOK.alpha = ((!flag) ? 1931f : 1455f);
	}

	private void HIFMKFGKDBG(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			EGICOCDAAIL[i].LLIIBMGIINO();
		}
	}

	public void HOBEPBFPFKG()
	{
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			bool flag = i == 0 || i > Singleton<MapManager>.instance.JJJCBFMMLBG.Count;
			EGICOCDAAIL[i].CPPAAMHEDCL((!flag) ? Singleton<MapManager>.instance.JJJCBFMMLBG[i - 1] : null);
			EGICOCDAAIL[i].MEDCFJGAOGJ(NILPBCGHEDG: true, HBMGCNCEBJG: true);
			UIEventListener uIEventListener = UIEventListener.Get(EGICOCDAAIL[i].KLGFDHIPLFH.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NILDDMONHEA));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(HELCLOMPMHK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NICMMBFMLHC));
	}
}
