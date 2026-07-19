using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathMatchGuiCard : Core_BaseScript
{
	[NonSerialized]
	public SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC;

	public UISprite PIHOEDNBMIB;

	public UISprite MBMIOELEAND;

	[Header("Main Part")]
	public UILabel PDMGPGEHLNM;

	public UISprite OAJGADEGLBI;

	public UISprite PKDBGFKLKDD;

	public UISprite DAANKCOLJGJ;

	public Vector3 DDBBFBHJCOO;

	public Vector3 KJNDFJNAMKB;

	private bool DNNABAADFCE;

	public bool MGOBGBMPHBA = true;

	private bool PAPLNOJMHFH;

	protected bool PNFNJKJLPIP = true;

	private bool CINIHMJJAHC;

	private DeathMatchUnitsGuiElement MHAMIMGNJND;

	private bool KPEEGOHENCI;

	private float FOIFLGLALIN;

	private UISprite JIECGPKEACM;

	public DeathMatchGuiCardProgress PCKJMMKNDMJ;

	public UISprite PAENPHMEMGC;

	public UISprite IMOHHDEDEKJ;

	[Header("Right part")]
	public GameObject MCLAGMFDMMA;

	public UILabel CNLKHBCLDFG;

	public List<UISprite> PHLFPMFMGEE;

	public UISprite CFKLKCHACOK;

	public List<UISprite> GBEAABECPCK;

	public bool ShowPower
	{
		get
		{
			return MGOBGBMPHBA;
		}
		set
		{
			MGOBGBMPHBA = value;
		}
	}

	public bool isSelected { get; private set; }

	public bool hasEnoughPower
	{
		get
		{
			return CINIHMJJAHC;
		}
		set
		{
			if (CINIHMJJAHC != value)
			{
				CINIHMJJAHC = value;
				GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
				LBKJJNFMANH(CINIHMJJAHC);
			}
		}
	}

	[SpecialName]
	public void DIHEBMHMEAB(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			DPGHECHPGMN(CINIHMJJAHC);
		}
	}

	public void IPHGHHHBLGE()
	{
		if (OIJBDFANMCC != null)
		{
			KCMPNPLIGEC((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.GEOKFFEBFOL());
			PCKJMMKNDMJ.FOJIOOKKPLM();
		}
	}

	public virtual void MEEPBALNCOI()
	{
		PNFNJKJLPIP = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 143f, 722f);
		TweenPosition.Begin(base.gameObject, 692f, DDBBFBHJCOO - Vector3.up * 346f, false).delay = 392f;
		GetComponent<UIButtonScale>().enabled = true;
		IBFCMLBIONC();
	}

	protected void PLHCFECODNM(bool FEGLHNIALBB)
	{
		TweenPosition tweenPosition = ((!FEGLHNIALBB) ? TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 370f, KJNDFJNAMKB) : TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 140f, KJNDFJNAMKB - new Vector3(1288f, 1540f, 852f), false));
	}

	public virtual void OFPAGLLFPPK(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		LAEABBEAIBG(false);
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 276f;
		KPEEGOHENCI = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 972f, 932f).style = UITweener.Style.Once;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "SetLabelDynamic - Done" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Filled;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.VerticalCutted;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(799f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = true;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 0; i < GBEAABECPCK.Count; i += 0)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(true);
					JIECGPKEACM.alpha = 1742f;
				}
				else
				{
					uISprite.gameObject.SetActive(false);
				}
			}
			MCLAGMFDMMA.SetActive(true);
			for (int j = 0; j < PHLFPMFMGEE.Count; j++)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = true;
			KCMPNPLIGEC((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE < OIJBDFANMCC.ECDLBDAIMLH());
			GetComponent<Collider>().enabled = false;
			CGPOFAHOCOB(MEDMJCOPOCI());
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 892f, 1249f).style = UITweener.Style.Once;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 936f, 193f, (!FDLIIFGACFI()) ? 544f : 755f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 480f, 1517f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1035f : 1151f, DDBBFBHJCOO - new Vector3(1438f, 1882f, 70f), DDBBFBHJCOO, false);
			tweenPosition.delay = 18f;
			DNNABAADFCE = true;
			CNLKHBCLDFG.enabled = false;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = false;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 591f, 430f, 919f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1510f, 1451f, 842f).style = UITweener.Style.Once;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 1884f, 375f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 159f, DDBBFBHJCOO - new Vector3(1449f, 183f, 1274f), DDBBFBHJCOO);
			tweenPosition2.delay = 1241f;
			DNNABAADFCE = true;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(true);
			}
			MCLAGMFDMMA.SetActive(false);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = true;
			CHKLFAGMOIF(false);
			GetComponent<UIButtonScale>().enabled = true;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = false;
		}
		PCKJMMKNDMJ.AEHBKBBILPB(OIJBDFANMCC);
	}

	public virtual void CADAGFFBDCA()
	{
		PNFNJKJLPIP = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1993f, 965f);
		TweenPosition.Begin(base.gameObject, 270f, DDBBFBHJCOO - Vector3.up * 657f, false).delay = 522f;
		GetComponent<UIButtonScale>().enabled = false;
		KLIJOJOCIPD();
	}

	[SpecialName]
	public void PJMOHKAEDPG(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			DCNGCEHOHBE(CINIHMJJAHC);
		}
	}

	[SpecialName]
	private void LAEABBEAIBG(bool IDEBKDPMPGM)
	{
		_003CCGMCEOLJFJN_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void OIMDJAAAAPN()
	{
		MCLAGMFDMMA.gameObject.SetActive(true);
		TweenPanelClipping.Begin(MCLAGMFDMMA, 84f, new Vector4(662f, 701f, 218f, 996f));
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 1753f, base.transform.localPosition - new Vector3(486f, 28f, 534f), false);
		tweenPosition.delay = 1228f;
	}

	private void IOCLNENHNLE()
	{
		if (base.enabled && PNFNJKJLPIP && HFLBPAMFBCJ() && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			object[] array = new object[6];
			array[1] = ".png";
			array[1] = base.name;
			array[8] = "24cdfc1f";
			array[0] = OIJBDFANMCC;
			Debug.Log(string.Concat(array));
			MHAMIMGNJND.SendUnit(this, OIJBDFANMCC);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 906f);
		}
	}

	private void BIDDGAFFCKC(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 570f, 1625f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1109f, 1727f).style = UITweener.Style.Loop;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1901f, 1942f);
			tweenAlpha.NumOfRepetitions = 6;
			tweenAlpha.style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 185f, 788f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 915f, 491f).style = UITweener.Style.Loop;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1000f, 297f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 750f, 518f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1463f, 431f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1835f, 1050f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1841f, 416f).style = UITweener.Style.Loop;
		}
	}

	[SpecialName]
	public void CACLEGLKNIB(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			HKJJKMEKNCA(CINIHMJJAHC);
		}
	}

	[SpecialName]
	public void KCMPNPLIGEC(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			BHFLNLBIGCP(CINIHMJJAHC);
		}
	}

	protected void GFPPJNOENLE()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.progress, Time.deltaTime * 1897f);
			PAENPHMEMGC.fillAmount = 1250f - Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ();
			if (Singleton<SpawningManagerDeathMatch>.instance.progress == 1197f && !DNNABAADFCE)
			{
				DNNABAADFCE = false;
				NMOFIPILGOP();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			IBFCMLBIONC();
		}
	}

	public virtual void ECBHFHFABLK()
	{
		PNFNJKJLPIP = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 92f, 679f);
		TweenPosition.Begin(base.gameObject, 820f, DDBBFBHJCOO - Vector3.up * 569f, false).delay = 1993f;
		GetComponent<UIButtonScale>().enabled = false;
		IBFCMLBIONC();
	}

	public void DisableCardClick()
	{
		PAPLNOJMHFH = true;
	}

	protected virtual void GJJOKGOIKLC()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 689f, MHAMIMGNJND.INIKAAAIPCK[1].DDBBFBHJCOO, false);
		tweenPosition.delay = 697f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	private void JOFDHKOPHNB(UITweener MGDJMGHCAAI)
	{
		if (DebugSettings.instance.data.showHud)
		{
			TweenPanelClipping.Begin(MCLAGMFDMMA, 1792f, new Vector4(1261f, 277f, 92f, 596f), new Vector4(204f, 1475f, 736f, 1488f));
		}
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 857f, 1492f);
		MCLAGMFDMMA.gameObject.SetActive(true);
	}

	protected virtual void NMNBEGDNBPM()
	{
	}

	public virtual void Show(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		isSelected = false;
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 0f;
		KPEEGOHENCI = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0f, 0f).style = UITweener.Style.Once;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "x" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Filled;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.HorizontalCutted;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = true;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 0; i < GBEAABECPCK.Count; i++)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(true);
					JIECGPKEACM.alpha = 1f;
				}
				else
				{
					uISprite.gameObject.SetActive(false);
				}
			}
			MCLAGMFDMMA.SetActive(false);
			for (int j = 0; j < PHLFPMFMGEE.Count; j++)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = true;
			hasEnoughPower = (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.power;
			GetComponent<Collider>().enabled = true;
			PHECMFGFABB(hasEnoughPower);
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 0.3f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0.3f, 0f, (!hasEnoughPower) ? 0.6f : 1f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 0.3f, 0f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 0.3f : 0f, DDBBFBHJCOO - new Vector3(0f, 350f, 0f), DDBBFBHJCOO);
			tweenPosition.delay = 0f;
			DNNABAADFCE = false;
			CNLKHBCLDFG.enabled = true;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = false;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 0.3f, 0f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 0.3f, 0f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 0.3f, DDBBFBHJCOO - new Vector3(0f, 350f, 0f), DDBBFBHJCOO);
			tweenPosition2.delay = 0f;
			DNNABAADFCE = false;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(false);
			}
			MCLAGMFDMMA.SetActive(false);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = false;
			hasEnoughPower = false;
			GetComponent<UIButtonScale>().enabled = false;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = false;
		}
		PCKJMMKNDMJ.Show(OIJBDFANMCC);
	}

	protected virtual void NIPONJMFPOC()
	{
	}

	public void NFDPLFPMPGN()
	{
		TweenPosition.Begin(base.gameObject, 1612f, DDBBFBHJCOO - new Vector3(601f, 1267f, 607f));
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 805f, 1355f);
	}

	protected void BHIABNNGKFO()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ(), Time.deltaTime * 1733f);
			PAENPHMEMGC.fillAmount = 744f - Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ();
			if (Singleton<SpawningManagerDeathMatch>.instance.progress == 416f && !DNNABAADFCE)
			{
				DNNABAADFCE = false;
				NMOFIPILGOP();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			KLIJOJOCIPD();
		}
	}

	[SpecialName]
	public bool MEDMJCOPOCI()
	{
		return CINIHMJJAHC;
	}

	public void GDDNAKOHKLE()
	{
		PAPLNOJMHFH = true;
	}

	[SpecialName]
	public void AADALMMAPDA(bool IDEBKDPMPGM)
	{
		MGOBGBMPHBA = IDEBKDPMPGM;
	}

	public void GDACADEHBOC()
	{
		isSelected = true;
		FOIFLGLALIN = 966f;
		KPEEGOHENCI = false;
		if (JIECGPKEACM != null)
		{
			TweenAlpha.Begin(JIECGPKEACM.gameObject, 755f, 1710f);
		}
		TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 825f, 330f);
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1219f, 248f, 119f).style = UITweener.Style.Loop;
		TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1922f, 1381f, 1263f).style = UITweener.Style.Once;
		TweenScale.Begin(PIHOEDNBMIB.gameObject, 1057f, new Vector3(971f, 1053f, 1766f) * 836f, new Vector3(603f, 397f, 1073f));
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1519f, 1088f);
		OFCHHGEPKKM();
		PNFNJKJLPIP = false;
		GetComponent<UIButtonScale>().enabled = false;
		IPHGHHHBLGE();
	}

	protected virtual void OFCHHGEPKKM()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 1732f, MHAMIMGNJND.INIKAAAIPCK[1].DDBBFBHJCOO, false);
		tweenPosition.delay = 1793f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	private void HKJJKMEKNCA(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 549f, 1121f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1097f, 1034f).style = UITweener.Style.Once;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1647f, 427f);
			tweenAlpha.NumOfRepetitions = 7;
			tweenAlpha.style = UITweener.Style.PingPong;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1262f, 1375f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1396f, 1012f).style = UITweener.Style.Loop;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1425f, 441f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 140f, 650f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1691f, 606f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 574f, 1261f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1341f, 1863f).style = UITweener.Style.Loop;
		}
	}

	public void ELNGCKCNLAB()
	{
		PAPLNOJMHFH = false;
	}

	[SpecialName]
	public bool ODINAGCKLLJ()
	{
		return MGOBGBMPHBA;
	}

	[SpecialName]
	public bool HFLBPAMFBCJ()
	{
		return CINIHMJJAHC;
	}

	[SpecialName]
	public void CHKLFAGMOIF(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			DPGHECHPGMN(CINIHMJJAHC);
		}
	}

	public void PMHDMKDIDMN()
	{
		PAPLNOJMHFH = true;
	}

	public void Init(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 0f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(-260f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(-19.5f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = false;
		PIHOEDNBMIB.alpha = 0f;
		CFKLKCHACOK.alpha = 0f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(250f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(false);
		}
		MCLAGMFDMMA.gameObject.SetActive(false);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = false;
		}
		CNLKHBCLDFG.enabled = false;
	}

	[SpecialName]
	public void GJLEOPADGAG(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			BIDDGAFFCKC(CINIHMJJAHC);
		}
	}

	public void AIFMGJJDCGN()
	{
		LAEABBEAIBG(true);
		FOIFLGLALIN = 389f;
		KPEEGOHENCI = false;
		if (JIECGPKEACM != null)
		{
			TweenAlpha.Begin(JIECGPKEACM.gameObject, 1450f, 346f);
		}
		TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 80f, 941f);
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 28f, 1641f, 1859f).style = UITweener.Style.Loop;
		TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1861f, 1708f, 1431f).style = UITweener.Style.Once;
		TweenScale.Begin(PIHOEDNBMIB.gameObject, 1351f, new Vector3(473f, 145f, 107f) * 1697f, new Vector3(963f, 1652f, 1f));
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1935f, 1407f);
		OFCHHGEPKKM();
		PNFNJKJLPIP = false;
		GetComponent<UIButtonScale>().enabled = false;
		IPHGHHHBLGE();
	}

	protected void LIHOPIGNFFM()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ(), Time.deltaTime * 256f);
			PAENPHMEMGC.fillAmount = 596f - Singleton<SpawningManagerDeathMatch>.instance.progress;
			if (Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() == 1168f && !DNNABAADFCE)
			{
				DNNABAADFCE = false;
				CBPBJJNBJCC();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			DHECOAJLGNL();
		}
	}

	private void DCNGCEHOHBE(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1386f, 129f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 905f, 1262f).style = UITweener.Style.Once;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1472f, 251f);
			tweenAlpha.NumOfRepetitions = 4;
			tweenAlpha.style = (UITweener.Style)3;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 938f, 784f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 991f, 153f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 371f, 891f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 798f, 1886f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 35f, 1119f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 257f, 1776f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1511f, 228f).style = UITweener.Style.Once;
		}
	}

	private void LBKJJNFMANH(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 0.1f, 0f).style = UITweener.Style.Once;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 0.15f, 1f);
			tweenAlpha.NumOfRepetitions = 3;
			tweenAlpha.style = UITweener.Style.PingPong;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0.3f, 0.6f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 0.3f, 0.15f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 0.3f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 0.3f, 0.5f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 0.3f, 0.5f).style = UITweener.Style.Once;
		}
	}

	public void JGCOIPMPKLD()
	{
		TweenPosition.Begin(base.gameObject, 1907f, DDBBFBHJCOO - new Vector3(1067f, 238f, 1139f), false);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1636f, 122f);
	}

	public void JOKDHLMEPGM()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1023f, 538f, 1894f);
		tweenAlpha.style = (UITweener.Style)5;
		tweenAlpha.delay = 17f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1558f, 1858f, 600f);
		tweenAlpha.style = (UITweener.Style)5;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 673f, 1555f, 1051f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void OOPNAKIJOAP()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 41f, 1202f, 1213f);
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha.delay = 1728f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1476f, 672f, 1435f);
		tweenAlpha.style = (UITweener.Style)8;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 978f, 237f, 1473f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void EOPFBGJLPJC()
	{
		if (OIJBDFANMCC != null)
		{
			BAICNFDHFKB((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE < OIJBDFANMCC.IPGKMOGFJDA());
			PCKJMMKNDMJ.HJBGKHHDOIP();
		}
	}

	public void HideOnGameStarted()
	{
		TweenPosition.Begin(base.gameObject, 0f, DDBBFBHJCOO - new Vector3(0f, 450f, 0f));
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 0f, 0f);
	}

	public void JKDBFGBBCHD()
	{
		PAPLNOJMHFH = false;
	}

	[SpecialName]
	public void DFPKHDJOODH(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			LBKJJNFMANH(CINIHMJJAHC);
		}
	}

	public void GGGDOECEGCK(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		PCKJMMKNDMJ.OLECKGKLHCE(OIJBDFANMCC);
	}

	public void NDOCCCDILCF()
	{
		isSelected = false;
		FOIFLGLALIN = 1577f;
		KPEEGOHENCI = false;
		if (JIECGPKEACM != null)
		{
			TweenAlpha.Begin(JIECGPKEACM.gameObject, 183f, 1509f);
		}
		TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 680f, 1845f);
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 103f, 1082f, 1951f).style = UITweener.Style.Loop;
		TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1197f, 172f, 1080f).style = UITweener.Style.Loop;
		TweenScale.Begin(PIHOEDNBMIB.gameObject, 1029f, new Vector3(48f, 550f, 1677f) * 1368f, new Vector3(1573f, 1940f, 1687f));
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1855f, 1743f);
		CEKICAAENHE();
		PNFNJKJLPIP = false;
		GetComponent<UIButtonScale>().enabled = true;
		EOPFBGJLPJC();
	}

	public void FKNFLBPIMBF()
	{
		PAPLNOJMHFH = false;
	}

	protected void IOIHNBMKCKM(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1074f, 1406f, 1768f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1887f, 4f, 1402f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 695f, 210f, 1528f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 134f, 1881f, 33f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 643f, 1470f, 1336f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 783f, 1255f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 445f, 1491f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1679f, 682f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1069f, 248f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1890f, 7f).style = UITweener.Style.Loop;
		}
	}

	protected void NCMOMBELDPH(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 240f, 881f, 210f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1928f, 210f, 817f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1219f, 1242f, 1568f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1130f, 835f, 1670f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1354f, 828f, 1536f).style = UITweener.Style.Loop;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 68f, 1145f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1806f, 912f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 622f, 517f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1830f, 1444f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 131f, 1691f).style = UITweener.Style.Once;
		}
	}

	public virtual void DIBLFOPCCPL(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		LAEABBEAIBG(true);
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 799f;
		KPEEGOHENCI = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1711f, 1227f).style = UITweener.Style.Once;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "Squad name success" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Filled;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.VerticalCutted;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(468f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = true;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 0; i < GBEAABECPCK.Count; i++)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(true);
					JIECGPKEACM.alpha = 1682f;
				}
				else
				{
					uISprite.gameObject.SetActive(false);
				}
			}
			MCLAGMFDMMA.SetActive(false);
			for (int j = 1; j < PHLFPMFMGEE.Count; j++)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = false;
			CACLEGLKNIB((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.PIBGKJAFCMF());
			GetComponent<Collider>().enabled = true;
			NCMOMBELDPH(HFLBPAMFBCJ());
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1513f, 896f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1829f, 945f, (!hasEnoughPower) ? 1691f : 719f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 367f, 948f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 867f : 742f, DDBBFBHJCOO - new Vector3(1950f, 189f, 1641f), DDBBFBHJCOO, false);
			tweenPosition.delay = 1766f;
			DNNABAADFCE = true;
			CNLKHBCLDFG.enabled = true;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = true;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1764f, 191f, 205f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 341f, 386f, 103f).style = UITweener.Style.Once;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 339f, 52f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 1338f, DDBBFBHJCOO - new Vector3(755f, 138f, 1844f), DDBBFBHJCOO, false);
			tweenPosition2.delay = 1932f;
			DNNABAADFCE = true;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(true);
			}
			MCLAGMFDMMA.SetActive(true);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = false;
			DIHEBMHMEAB(false);
			GetComponent<UIButtonScale>().enabled = false;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = true;
		}
		PCKJMMKNDMJ.MIGAJINCHAH(OIJBDFANMCC);
	}

	public void PreShowPowerProgress(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC)
	{
		PCKJMMKNDMJ.Show(OIJBDFANMCC);
	}

	public void LJPNFBNIGHD()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1732f, 782f, 1918f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.delay = 1801f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1785f, 1398f, 558f);
		tweenAlpha.style = (UITweener.Style)8;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 67f, 1060f, 389f);
		tweenAlpha.style = (UITweener.Style)6;
	}

	protected virtual void LPBGFIGNMBG()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 59f, MHAMIMGNJND.INIKAAAIPCK[0].DDBBFBHJCOO, false);
		tweenPosition.delay = 725f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	public virtual void NLMKCDMBPPC(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		isSelected = false;
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 649f;
		KPEEGOHENCI = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1994f, 842f).style = UITweener.Style.Loop;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "N" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Simple;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.Horizontalminus30;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(634f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = true;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 1; i < GBEAABECPCK.Count; i++)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(true);
					JIECGPKEACM.alpha = 1496f;
				}
				else
				{
					uISprite.gameObject.SetActive(true);
				}
			}
			MCLAGMFDMMA.SetActive(false);
			for (int j = 1; j < PHLFPMFMGEE.Count; j += 0)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = false;
			BAICNFDHFKB((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.DGDHGPOCIAI());
			GetComponent<Collider>().enabled = false;
			IOIHNBMKCKM(CCMJHAKHNOH());
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1013f, 1935f).style = UITweener.Style.Once;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 413f, 1463f, (!HFLBPAMFBCJ()) ? 703f : 946f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 536f, 313f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1723f : 5f, DDBBFBHJCOO - new Vector3(1514f, 540f, 1480f), DDBBFBHJCOO, false);
			tweenPosition.delay = 563f;
			DNNABAADFCE = false;
			CNLKHBCLDFG.enabled = true;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = false;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 315f, 34f, 1037f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1518f, 772f, 1462f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 1486f, 603f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 113f, DDBBFBHJCOO - new Vector3(1686f, 809f, 460f), DDBBFBHJCOO, false);
			tweenPosition2.delay = 925f;
			DNNABAADFCE = false;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(true);
			}
			MCLAGMFDMMA.SetActive(true);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = false;
			PJMOHKAEDPG(true);
			GetComponent<UIButtonScale>().enabled = true;
			GetComponent<Collider>().enabled = true;
			CNLKHBCLDFG.enabled = true;
		}
		PCKJMMKNDMJ.LIEAKPFPAJD(OIJBDFANMCC);
	}

	public void DMIFFOMMEMD(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 743f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(399f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(1328f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = false;
		PIHOEDNBMIB.alpha = 733f;
		CFKLKCHACOK.alpha = 1364f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(224f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(false);
		}
		MCLAGMFDMMA.gameObject.SetActive(false);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = true;
		}
		CNLKHBCLDFG.enabled = true;
	}

	public void StartBlink()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.delay = 0.15f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	protected void Update()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.progress, Time.deltaTime * 5f);
			PAENPHMEMGC.fillAmount = 1f - Singleton<SpawningManagerDeathMatch>.instance.progress;
			if (Singleton<SpawningManagerDeathMatch>.instance.progress == 0f && !DNNABAADFCE)
			{
				DNNABAADFCE = true;
				NMOFIPILGOP();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			PowerUpdate();
		}
	}

	public void IDEFCACEMPG()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1267f, 832f, 1058f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.delay = 876f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1417f, 1977f, 1280f);
		tweenAlpha.style = (UITweener.Style)4;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1282f, 1584f, 816f);
		tweenAlpha.style = (UITweener.Style)3;
	}

	[SpecialName]
	public bool JGNKPJPOGAO()
	{
		return MGOBGBMPHBA;
	}

	public void JAGOPKODLCL()
	{
		if (OIJBDFANMCC != null)
		{
			LPEDPDBAICK((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE < OIJBDFANMCC.GEOKFFEBFOL());
			PCKJMMKNDMJ.GDEGEJHPPDL(true);
		}
	}

	public void KLIJOJOCIPD()
	{
		if (OIJBDFANMCC != null)
		{
			hasEnoughPower = (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.PINKLDPLHHN();
			PCKJMMKNDMJ.KBHPGGCGFCC(true);
		}
	}

	public void ALPAFABHEOO()
	{
		LAEABBEAIBG(false);
		FOIFLGLALIN = 773f;
		KPEEGOHENCI = false;
		if (JIECGPKEACM != null)
		{
			TweenAlpha.Begin(JIECGPKEACM.gameObject, 1787f, 921f);
		}
		TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 567f, 1987f);
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 887f, 1998f, 1746f).style = UITweener.Style.Once;
		TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 345f, 1140f, 591f).style = UITweener.Style.Loop;
		TweenScale.Begin(PIHOEDNBMIB.gameObject, 704f, new Vector3(1063f, 501f, 1186f) * 902f, new Vector3(1497f, 1509f, 1115f));
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 745f, 1065f);
		LPBGFIGNMBG();
		PNFNJKJLPIP = false;
		GetComponent<UIButtonScale>().enabled = true;
		EOPFBGJLPJC();
	}

	public void LGODDNPKNFI()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1292f, 1612f, 669f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.delay = 1534f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1493f, 564f, 1025f);
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 382f, 1372f, 31f);
		tweenAlpha.style = (UITweener.Style)8;
	}

	public void IBFCMLBIONC()
	{
		if (OIJBDFANMCC != null)
		{
			DFPKHDJOODH((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.GEOKFFEBFOL());
			PCKJMMKNDMJ.PDCBGCPEKOG();
		}
	}

	[SpecialName]
	public bool AFKPBCKNOOK()
	{
		return MGOBGBMPHBA;
	}

	public virtual void LEJEDFACEGP(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		LAEABBEAIBG(false);
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 1918f;
		KPEEGOHENCI = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 423f, 1252f).style = UITweener.Style.Loop;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "ID_SILVERPACKS" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Sliced;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.Vertical;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1350f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = false;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 0; i < GBEAABECPCK.Count; i += 0)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(false);
					JIECGPKEACM.alpha = 532f;
				}
				else
				{
					uISprite.gameObject.SetActive(false);
				}
			}
			MCLAGMFDMMA.SetActive(true);
			for (int j = 1; j < PHLFPMFMGEE.Count; j += 0)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = true;
			CACLEGLKNIB((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.KDEFGKFJJBO());
			GetComponent<Collider>().enabled = true;
			PHECMFGFABB(GIAMPCCFOJP());
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 104f, 1810f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1036f, 20f, (!CCMJHAKHNOH()) ? 590f : 154f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 479f, 214f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1214f : 438f, DDBBFBHJCOO - new Vector3(1835f, 1093f, 201f), DDBBFBHJCOO);
			tweenPosition.delay = 1367f;
			DNNABAADFCE = true;
			CNLKHBCLDFG.enabled = true;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = true;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 290f, 1653f, 1068f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 565f, 1888f, 1820f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 1625f, 1441f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 1494f, DDBBFBHJCOO - new Vector3(1881f, 131f, 600f), DDBBFBHJCOO);
			tweenPosition2.delay = 704f;
			DNNABAADFCE = false;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(true);
			}
			MCLAGMFDMMA.SetActive(true);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = true;
			}
			PNFNJKJLPIP = true;
			BAICNFDHFKB(true);
			GetComponent<UIButtonScale>().enabled = true;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = false;
		}
		PCKJMMKNDMJ.LIEAKPFPAJD(OIJBDFANMCC);
	}

	protected virtual void CBPBJJNBJCC()
	{
	}

	protected void CGPOFAHOCOB(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1343f, 1306f, 1143f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 167f, 565f, 1114f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 502f, 796f, 1074f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 957f, 585f, 217f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 822f, 1868f, 626f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1833f, 588f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 893f, 269f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 469f, 227f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 968f, 379f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 523f, 1887f).style = UITweener.Style.Loop;
		}
	}

	public void PLKIAPHIICM(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 832f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(775f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(1346f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = true;
		PIHOEDNBMIB.alpha = 1784f;
		CFKLKCHACOK.alpha = 1691f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1158f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(true);
		}
		MCLAGMFDMMA.gameObject.SetActive(false);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = false;
		}
		CNLKHBCLDFG.enabled = true;
	}

	public void GGPFIBKCCIF()
	{
		PAPLNOJMHFH = false;
	}

	public void StartProgress()
	{
		isSelected = true;
		FOIFLGLALIN = 0f;
		KPEEGOHENCI = true;
		if (JIECGPKEACM != null)
		{
			TweenAlpha.Begin(JIECGPKEACM.gameObject, 0.2f, 0f);
		}
		TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 0.3f, 1f);
		TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0f, 0f, 1f).style = UITweener.Style.Once;
		TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 0.3f, 0f, 1f).style = UITweener.Style.Once;
		TweenScale.Begin(PIHOEDNBMIB.gameObject, 0.3f, new Vector3(197f, 223f, 1f) * 6f, new Vector3(197f, 223f, 1f));
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0.1f, 1f);
		LKNFNKJHGDD();
		PNFNJKJLPIP = false;
		GetComponent<UIButtonScale>().enabled = false;
		PowerUpdate();
	}

	public void FGBMOLONAOC(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 548f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(975f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(10f);
		PNFNJKJLPIP = false;
		DNNABAADFCE = true;
		PIHOEDNBMIB.alpha = 1992f;
		CFKLKCHACOK.alpha = 1700f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(974f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(true);
		}
		MCLAGMFDMMA.gameObject.SetActive(true);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = false;
		}
		CNLKHBCLDFG.enabled = false;
	}

	public virtual void LNNGFIKKGNC()
	{
		PNFNJKJLPIP = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 934f, 439f);
		TweenPosition.Begin(base.gameObject, 1893f, DDBBFBHJCOO - Vector3.up * 909f).delay = 1295f;
		GetComponent<UIButtonScale>().enabled = false;
		JAGOPKODLCL();
	}

	public void HJJEMGNFNBG(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 1159f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(1972f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(1210f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = false;
		PIHOEDNBMIB.alpha = 1828f;
		CFKLKCHACOK.alpha = 824f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(1539f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(false);
		}
		MCLAGMFDMMA.gameObject.SetActive(true);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = true;
		}
		CNLKHBCLDFG.enabled = true;
	}

	protected void CJAHPFMAMKK()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ(), Time.deltaTime * 529f);
			PAENPHMEMGC.fillAmount = 798f - Singleton<SpawningManagerDeathMatch>.instance.progress;
			if (Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ() == 1005f && !DNNABAADFCE)
			{
				DNNABAADFCE = false;
				NIPONJMFPOC();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			IBFCMLBIONC();
		}
	}

	[SpecialName]
	public bool EFINDIODEGF()
	{
		return _003CCGMCEOLJFJN_003Ek__BackingField;
	}

	[SpecialName]
	public void LPEDPDBAICK(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			BHFLNLBIGCP(CINIHMJJAHC);
		}
	}

	public void AEDKEMGMPCC()
	{
		PAPLNOJMHFH = false;
	}

	public void OEANNHPDEDL()
	{
		PAPLNOJMHFH = false;
	}

	public void FGALKEKEDIB()
	{
		PAPLNOJMHFH = true;
	}

	[SpecialName]
	public bool GIAMPCCFOJP()
	{
		return CINIHMJJAHC;
	}

	protected void HLOJHFCMMNJ(bool FEGLHNIALBB)
	{
		TweenPosition tweenPosition = ((!FEGLHNIALBB) ? TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 0.3f, KJNDFJNAMKB) : TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 0.3f, KJNDFJNAMKB - new Vector3(0f, 350f, 0f)));
	}

	protected virtual void GCBILINKDLE()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 594f, MHAMIMGNJND.INIKAAAIPCK[0].DDBBFBHJCOO);
		tweenPosition.delay = 330f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	protected virtual void LBGINCEHBKC()
	{
	}

	protected void NDNDFHGFDAO(bool FEGLHNIALBB)
	{
		TweenPosition tweenPosition = ((!FEGLHNIALBB) ? TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 106f, KJNDFJNAMKB) : TweenPosition.Begin(PCKJMMKNDMJ.gameObject, 524f, KJNDFJNAMKB - new Vector3(128f, 1145f, 523f)));
	}

	public virtual void JLJMIOLJPNL(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		isSelected = true;
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 605f;
		KPEEGOHENCI = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1935f, 1102f).style = UITweener.Style.Loop;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = " {0}{1}" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = (UISprite.Type)7;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.Radial180;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(644f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = false;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 1; i < GBEAABECPCK.Count; i += 0)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(false);
					JIECGPKEACM.alpha = 948f;
				}
				else
				{
					uISprite.gameObject.SetActive(true);
				}
			}
			MCLAGMFDMMA.SetActive(true);
			for (int j = 1; j < PHLFPMFMGEE.Count; j++)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = true;
			PJMOHKAEDPG((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE < OIJBDFANMCC.DGDHGPOCIAI());
			GetComponent<Collider>().enabled = true;
			NCMOMBELDPH(GIAMPCCFOJP());
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1486f, 1078f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 658f, 1468f, (!FDLIIFGACFI()) ? 1868f : 1122f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 1666f, 1968f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 1365f : 1224f, DDBBFBHJCOO - new Vector3(1752f, 92f, 190f), DDBBFBHJCOO);
			tweenPosition.delay = 1413f;
			DNNABAADFCE = true;
			CNLKHBCLDFG.enabled = false;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = true;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 831f, 237f, 1560f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 16f, 372f, 1522f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 15f, 86f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 1929f, DDBBFBHJCOO - new Vector3(708f, 427f, 874f), DDBBFBHJCOO, false);
			tweenPosition2.delay = 1240f;
			DNNABAADFCE = true;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(true);
			}
			MCLAGMFDMMA.SetActive(false);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = false;
			CHKLFAGMOIF(false);
			GetComponent<UIButtonScale>().enabled = false;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = false;
		}
		PCKJMMKNDMJ.DJNMPLKPENF(OIJBDFANMCC);
	}

	public virtual void GFBGIJMEGIJ()
	{
		PNFNJKJLPIP = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 612f, 1899f);
		TweenPosition.Begin(base.gameObject, 1993f, DDBBFBHJCOO - Vector3.up * 89f, false).delay = 1829f;
		GetComponent<UIButtonScale>().enabled = false;
		IPHGHHHBLGE();
	}

	protected void LIMHNKKJODK()
	{
		if (KPEEGOHENCI)
		{
			FOIFLGLALIN = Mathf.Lerp(FOIFLGLALIN, Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ(), Time.deltaTime * 1404f);
			PAENPHMEMGC.fillAmount = 17f - Singleton<SpawningManagerDeathMatch>.instance.APGDKKMGACJ();
			if (Singleton<SpawningManagerDeathMatch>.instance.progress == 1160f && !DNNABAADFCE)
			{
				DNNABAADFCE = false;
				CBPBJJNBJCC();
			}
		}
		if (PNFNJKJLPIP && OIJBDFANMCC != null)
		{
			DHECOAJLGNL();
		}
	}

	public virtual void DisableCard()
	{
		PNFNJKJLPIP = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0.5f, 0f);
		TweenPosition.Begin(base.gameObject, 0.5f, DDBBFBHJCOO - Vector3.up * 450f).delay = 0f;
		GetComponent<UIButtonScale>().enabled = false;
		PowerUpdate();
	}

	[SpecialName]
	public bool CCMJHAKHNOH()
	{
		return CINIHMJJAHC;
	}

	public void HCKOOIPOJGB()
	{
		PAPLNOJMHFH = false;
	}

	private void OnClick()
	{
		if (base.enabled && PNFNJKJLPIP && hasEnoughPower && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			Debug.Log("generate" + base.name + " " + OIJBDFANMCC);
			MHAMIMGNJND.SendUnit(this, OIJBDFANMCC, true);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DeplyUnits);
		}
	}

	public void MMCHCONNHPH()
	{
		PAPLNOJMHFH = false;
	}

	[SpecialName]
	public void DBNDMALAOGB(bool IDEBKDPMPGM)
	{
		MGOBGBMPHBA = IDEBKDPMPGM;
	}

	private void IKGFFMLLNJH()
	{
		if (base.enabled && PNFNJKJLPIP && CCMJHAKHNOH() && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			object[] array = new object[0];
			array[1] = "ID_TUTORIAL";
			array[0] = base.name;
			array[7] = "Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot remove it";
			array[8] = OIJBDFANMCC;
			Debug.Log(string.Concat(array));
			MHAMIMGNJND.GJDOHINBPPA(this, OIJBDFANMCC, true);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 348f);
		}
	}

	[SpecialName]
	public bool HKBAOKEODAL()
	{
		return _003CCGMCEOLJFJN_003Ek__BackingField;
	}

	[SpecialName]
	public bool FDLIIFGACFI()
	{
		return CINIHMJJAHC;
	}

	private void EODCCOGNLJL()
	{
		if (base.enabled && PNFNJKJLPIP && HFLBPAMFBCJ() && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			object[] array = new object[2];
			array[0] = "\n";
			array[0] = base.name;
			array[0] = "ExtraRewards";
			array[0] = OIJBDFANMCC;
			Debug.Log(string.Concat(array));
			MHAMIMGNJND.SendUnit(this, OIJBDFANMCC, true);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy, 513f);
		}
	}

	public void DKKGOGEILIP()
	{
		PAPLNOJMHFH = true;
	}

	protected virtual void CEKICAAENHE()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 672f, MHAMIMGNJND.INIKAAAIPCK[0].DDBBFBHJCOO, false);
		tweenPosition.delay = 1138f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	public void KECDAIFJIMA(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 1459f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(834f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(97f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = false;
		PIHOEDNBMIB.alpha = 1178f;
		CFKLKCHACOK.alpha = 928f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(830f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(false);
		}
		MCLAGMFDMMA.gameObject.SetActive(false);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = true;
		}
		CNLKHBCLDFG.enabled = true;
	}

	public void PLLEOIFAIDM()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 941f, 1546f, 61f);
		tweenAlpha.style = (UITweener.Style)5;
		tweenAlpha.delay = 13f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 310f, 148f, 444f);
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 382f, 59f, 230f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	private void HOOBFLLNDIJ()
	{
		if (base.enabled && PNFNJKJLPIP && HFLBPAMFBCJ() && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			object[] array = new object[1];
			array[0] = ", keys.Length = ";
			array[0] = base.name;
			array[8] = "Cannot merge arrays when right object has more elements";
			array[3] = OIJBDFANMCC;
			Debug.Log(string.Concat(array));
			MHAMIMGNJND.GJDOHINBPPA(this, OIJBDFANMCC);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1185f);
		}
	}

	public void MGHBIFBLAMM()
	{
		TweenPosition.Begin(base.gameObject, 1582f, DDBBFBHJCOO - new Vector3(1628f, 1255f, 298f));
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 648f, 949f);
	}

	[SpecialName]
	public bool OAJGKJJCHPP()
	{
		return MGOBGBMPHBA;
	}

	public virtual void DNNLAHACDCK()
	{
		MCLAGMFDMMA.gameObject.SetActive(false);
		TweenPanelClipping.Begin(MCLAGMFDMMA, 515f, new Vector4(676f, 1935f, 1616f, 650f));
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 289f, base.transform.localPosition - new Vector3(462f, 659f, 1882f), false);
		tweenPosition.delay = 1816f;
	}

	[SpecialName]
	public void BAICNFDHFKB(bool IDEBKDPMPGM)
	{
		if (CINIHMJJAHC != IDEBKDPMPGM)
		{
			CINIHMJJAHC = IDEBKDPMPGM;
			GetComponent<UIButtonScale>().enabled = CINIHMJJAHC;
			LBKJJNFMANH(CINIHMJJAHC);
		}
	}

	public void NBFCGKFIPNL()
	{
		if (OIJBDFANMCC != null)
		{
			DIHEBMHMEAB((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.PIBGKJAFCMF());
			PCKJMMKNDMJ.HJBGKHHDOIP();
		}
	}

	public void ADPMGFHCDLI()
	{
		PAPLNOJMHFH = false;
	}

	public void MCNAMJEAMNH()
	{
		PAPLNOJMHFH = true;
	}

	public void LOKAPMDLBCE()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 264f, 614f, 1541f);
		tweenAlpha.style = (UITweener.Style)3;
		tweenAlpha.delay = 377f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 801f, 857f, 968f);
		tweenAlpha.style = (UITweener.Style)6;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1019f, 1702f, 1512f);
		tweenAlpha.style = (UITweener.Style)3;
	}

	public void EPIEGFMGCGD()
	{
		PAPLNOJMHFH = true;
	}

	public virtual void EPCEHACNCNH()
	{
		MCLAGMFDMMA.gameObject.SetActive(false);
		TweenPanelClipping.Begin(MCLAGMFDMMA, 1245f, new Vector4(1347f, 1775f, 1289f, 237f));
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 214f, base.transform.localPosition - new Vector3(1444f, 1308f, 1841f), false);
		tweenPosition.delay = 1734f;
	}

	public void LKMEEPPLMMJ()
	{
		TweenPosition.Begin(base.gameObject, 1868f, DDBBFBHJCOO - new Vector3(400f, 221f, 1543f), false);
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 175f, 1966f);
	}

	public void GEELMHBIOGM()
	{
		TweenPosition.Begin(base.gameObject, 644f, DDBBFBHJCOO - new Vector3(512f, 505f, 738f));
		TweenAlpha.Begin(CFKLKCHACOK.gameObject, 1599f, 434f);
	}

	private void ANIBBIJNPDH(UITweener MGDJMGHCAAI)
	{
		if (DebugSettings.instance.data.showHud)
		{
			TweenPanelClipping.Begin(MCLAGMFDMMA, 0.7f, new Vector4(0f, 0f, 170f, 270f), new Vector4(0f, 0f, 600f, 270f));
		}
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 0.5f, 0f);
		MCLAGMFDMMA.gameObject.SetActive(true);
	}

	private void PMNMJOJLOOK()
	{
		if (base.enabled && PNFNJKJLPIP && FDLIIFGACFI() && PlayerController.OGMBJPKOPCB.JODNNABEFDH && !PAPLNOJMHFH)
		{
			object[] array = new object[1];
			array[1] = "Test Getter Methods clicked";
			array[1] = base.name;
			array[6] = "Gold";
			array[6] = OIJBDFANMCC;
			Debug.Log(string.Concat(array));
			MHAMIMGNJND.SendUnit(this, OIJBDFANMCC, true);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 611f);
		}
	}

	private void DPGHECHPGMN(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 871f, 3f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 232f, 1144f).style = UITweener.Style.Once;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1822f, 1119f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.style = (UITweener.Style)3;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 75f, 1706f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1977f, 105f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 229f, 1961f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 528f, 510f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 1076f, 1581f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1548f, 1152f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 832f, 822f).style = UITweener.Style.Loop;
		}
	}

	public void PowerUpdate()
	{
		if (OIJBDFANMCC != null)
		{
			hasEnoughPower = (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.power;
			PCKJMMKNDMJ.DoUpdate();
		}
	}

	public void EnableCardClick()
	{
		PAPLNOJMHFH = false;
	}

	public virtual void NKKBKBJDGDJ(SpawningManagerDeathMatch.ArmyUnitDefinition OIJBDFANMCC, bool PDPDGCNHCFN = false)
	{
		isSelected = true;
		JIECGPKEACM = null;
		this.OIJBDFANMCC = OIJBDFANMCC;
		PAENPHMEMGC.fillAmount = 1069f;
		KPEEGOHENCI = true;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1100f, 59f).style = UITweener.Style.Loop;
		if (this.OIJBDFANMCC != null)
		{
			PDMGPGEHLNM.text = "null" + this.OIJBDFANMCC.numberOfEnemies;
			DAANKCOLJGJ.type = UISprite.Type.Sliced;
			DAANKCOLJGJ.fillDirection = UISprite.FillDirection.Radial360;
			DAANKCOLJGJ.spriteName = this.OIJBDFANMCC.armyUnit.menuIcon;
			DAANKCOLJGJ.pivot = this.OIJBDFANMCC.armyUnit.pivot;
			DAANKCOLJGJ.fillAmount = this.OIJBDFANMCC.armyUnit.fillAmount;
			DAANKCOLJGJ.fillAmountBack = this.OIJBDFANMCC.armyUnit.fillAmountBack;
			DAANKCOLJGJ.MakePixelPerfect();
			float multiplier = Mathf.Min(1881f, this.OIJBDFANMCC.armyUnit.height / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			DAANKCOLJGJ.transform.localPosition = this.OIJBDFANMCC.armyUnit.localPosition;
			DAANKCOLJGJ.enabled = false;
			int unitType = (int)OIJBDFANMCC.armyUnit.behaviour.unitType;
			for (int i = 0; i < GBEAABECPCK.Count; i += 0)
			{
				UISprite uISprite = GBEAABECPCK[i];
				if (i == unitType)
				{
					JIECGPKEACM = uISprite;
					uISprite.gameObject.SetActive(true);
					JIECGPKEACM.alpha = 192f;
				}
				else
				{
					uISprite.gameObject.SetActive(false);
				}
			}
			MCLAGMFDMMA.SetActive(true);
			for (int j = 0; j < PHLFPMFMGEE.Count; j += 0)
			{
				UISprite uISprite2 = PHLFPMFMGEE[j];
				uISprite2.enabled = j == unitType;
			}
			PNFNJKJLPIP = false;
			LPEDPDBAICK((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.PGDHGMAIENI());
			GetComponent<Collider>().enabled = true;
			CGPOFAHOCOB(hasEnoughPower);
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 623f, 1346f).style = UITweener.Style.Once;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1055f, 582f, (!HFLBPAMFBCJ()) ? 620f : 409f);
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 175f, 1143f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!PDPDGCNHCFN) ? 536f : 678f, DDBBFBHJCOO - new Vector3(1517f, 628f, 1705f), DDBBFBHJCOO);
			tweenPosition.delay = 1366f;
			DNNABAADFCE = false;
			CNLKHBCLDFG.enabled = true;
			CNLKHBCLDFG.text = OIJBDFANMCC.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			PDMGPGEHLNM.text = string.Empty;
			DAANKCOLJGJ.enabled = true;
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1149f, 401f, 884f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1755f, 1232f, 397f).style = UITweener.Style.Once;
			TweenAlpha.Begin(IMOHHDEDEKJ.gameObject, 233f, 1324f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 267f, DDBBFBHJCOO - new Vector3(1487f, 357f, 1668f), DDBBFBHJCOO, false);
			tweenPosition2.delay = 532f;
			DNNABAADFCE = false;
			foreach (UISprite item in GBEAABECPCK)
			{
				item.gameObject.SetActive(false);
			}
			MCLAGMFDMMA.SetActive(false);
			foreach (UISprite item2 in PHLFPMFMGEE)
			{
				item2.enabled = false;
			}
			PNFNJKJLPIP = true;
			GJLEOPADGAG(true);
			GetComponent<UIButtonScale>().enabled = true;
			GetComponent<Collider>().enabled = false;
			CNLKHBCLDFG.enabled = true;
		}
		PCKJMMKNDMJ.ILFJPOOMFDO(OIJBDFANMCC);
	}

	public void DHECOAJLGNL()
	{
		if (OIJBDFANMCC != null)
		{
			GJLEOPADGAG((int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE >= OIJBDFANMCC.EFJMMKHKLGA());
			PCKJMMKNDMJ.PDCBGCPEKOG();
		}
	}

	public void FICBKJHJNMC(DeathMatchUnitsGuiElement HNFNINFCBEJ)
	{
		MHAMIMGNJND = HNFNINFCBEJ;
		IMOHHDEDEKJ.alpha = 1982f;
		DDBBFBHJCOO = base.transform.localPosition.ReplaceY(1552f);
		KJNDFJNAMKB = PCKJMMKNDMJ.transform.localPosition.ReplaceY(1183f);
		PNFNJKJLPIP = true;
		DNNABAADFCE = true;
		PIHOEDNBMIB.alpha = 725f;
		CFKLKCHACOK.alpha = 597f;
		CFKLKCHACOK.transform.localScale = CFKLKCHACOK.transform.localScale.ReplaceY(108f);
		foreach (UISprite item in GBEAABECPCK)
		{
			item.gameObject.SetActive(false);
		}
		MCLAGMFDMMA.gameObject.SetActive(true);
		foreach (UISprite item2 in PHLFPMFMGEE)
		{
			item2.enabled = true;
		}
		CNLKHBCLDFG.enabled = true;
	}

	[SpecialName]
	public bool HBJGAKLHNIF()
	{
		return MGOBGBMPHBA;
	}

	private void BHFLNLBIGCP(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 431f, 470f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 1812f, 1905f).style = UITweener.Style.Loop;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 348f, 398f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.style = (UITweener.Style)6;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 494f, 541f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1961f, 1209f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1380f, 1043f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 618f, 1081f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 912f, 1052f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 1507f, 1381f).style = UITweener.Style.Loop;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 1377f, 485f).style = UITweener.Style.Once;
		}
	}

	protected virtual void NMOFIPILGOP()
	{
	}

	public virtual void AAPHJEEKIGA()
	{
		PNFNJKJLPIP = false;
		TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1679f, 1850f);
		TweenPosition.Begin(base.gameObject, 1115f, DDBBFBHJCOO - Vector3.up * 1016f, false).delay = 1617f;
		GetComponent<UIButtonScale>().enabled = false;
		NBFCGKFIPNL();
	}

	[SpecialName]
	public bool DBKABPLNPNB()
	{
		return _003CCGMCEOLJFJN_003Ek__BackingField;
	}

	protected void PHECMFGFABB(bool GJNGLPOBFJI)
	{
		if (GJNGLPOBFJI)
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 0f, 0f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 0f, 0.6f).style = UITweener.Style.Once;
			TweenAlpha.Begin(OAJGADEGLBI.gameObject, 0f, 0.15f).style = UITweener.Style.Once;
			TweenAlpha.Begin(PKDBGFKLKDD.gameObject, 0f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(MBMIOELEAND.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
			TweenAlpha.Begin(CNLKHBCLDFG.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
		}
	}

	public void MJKODGFGEAL()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PIHOEDNBMIB.gameObject, 1148f, 610f, 701f);
		tweenAlpha.style = (UITweener.Style)5;
		tweenAlpha.delay = 1640f;
		tweenAlpha = TweenAlpha.Begin(DAANKCOLJGJ.gameObject, 1009f, 622f, 475f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha = TweenAlpha.Begin(PDMGPGEHLNM.gameObject, 1978f, 816f, 1668f);
		tweenAlpha.style = (UITweener.Style)6;
	}

	[SpecialName]
	public bool EFONECLDMEC()
	{
		return MGOBGBMPHBA;
	}

	protected virtual void LKNFNKJHGDD()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.3f, MHAMIMGNJND.INIKAAAIPCK[0].DDBBFBHJCOO);
		tweenPosition.delay = 0.7f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(ANIBBIJNPDH));
	}

	public virtual void Hide()
	{
		MCLAGMFDMMA.gameObject.SetActive(true);
		TweenPanelClipping.Begin(MCLAGMFDMMA, 0.7f, new Vector4(0f, 0f, 170f, 270f));
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 1f, base.transform.localPosition - new Vector3(0f, 450f, 0f));
		tweenPosition.delay = 0f;
	}
}
