using UnityEngine;
using UnityEngine.Serialization;

public class ArmyUnitStatistics : Core_BaseScript
{
	[Header("Optional")]
	[FormerlySerializedAs("HPLMNOKBKPC")]
	public UISprite[] HGIGBAICOJA;

	[Header("Core")]
	[FormerlySerializedAs("CIMLFMEGBJC")]
	public UILabel HKNJKFBLECG;

	[FormerlySerializedAs("EDDFGFFLDLA")]
	public GameObject LOICCJDJHLJ;

	[FormerlySerializedAs("MPAIMGHLADO")]
	public UISprite IMFAHHGINPP;

	[FormerlySerializedAs("IDNMKJNMALD")]
	public UILabel NIKKFEOFHFP;

	[FormerlySerializedAs("CBGHMFDKKGC")]
	public UILabel KJKIMOFGPAC;

	private Vector3 JBJFBEGPAPL = new Vector3(75f, 75f, 1f);

	private Vector3 CNKJJOFJOCM = new Vector3(105f, 105f, 1f);

	public void GBEJKHIKFNI(string FPFCCDCGEHC)
	{
		for (int i = 1; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 0);
		}
		UISprite uISprite = HGIGBAICOJA[1];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void PIKPCOLEDAD(Color HAJDGBEPIJF)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Colours.grayMax;
		NIKKFEOFHFP.gameObject.SetActive(value: false);
		KJKIMOFGPAC.gameObject.SetActive(value: true);
		KJKIMOFGPAC.color = HAJDGBEPIJF;
	}

	public void OAMBDKHLJKI(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN, bool LPFLPCOLHPJ = false)
	{
		float num = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[0] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[1]));
		float num2 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[5] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[8]));
		float num4 = num3 - num;
		bool flag = num4 > 1105f;
		bool flag2 = num == num2;
		PCOLLELFIPE(MEJMLNDFDBP.MAGANIIGHON(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag2)
			{
				APPCLCIMDEA(Colours.blue);
			}
			else
			{
				LBMDADKIJJM((!flag) ? string.Empty : string.Format("weapon", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (JHFKBODINGN && flag)
			{
				OMPOPFMIDOE();
			}
			else
			{
				EMDNEOBGFEB();
			}
		}
	}

	public void FNAACFAMNPH(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[8];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1216f) : (num4 < 98f));
		bool flag3 = num == num2;
		ANNACHAFBAA(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				NONCNLCDIDD(Colours.greenArena);
			}
			else if (flag2)
			{
				IPGFFHGCICG(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				HOEAGOIGNPF(string.Empty);
			}
		}
	}

	public void GDKCIPGFLFJ(string FPFCCDCGEHC)
	{
		for (int i = 0; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 1);
		}
		UISprite uISprite = HGIGBAICOJA[1];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void JKJACEGKLBI(Color HAJDGBEPIJF)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Colours.grayMax;
		NIKKFEOFHFP.gameObject.SetActive(value: false);
		KJKIMOFGPAC.gameObject.SetActive(value: true);
		KJKIMOFGPAC.color = HAJDGBEPIJF;
	}

	private void EDOGAANBKJK(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(1597f, 924f, 779f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(17f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1256f, 549f, 28);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(454f);
	}

	private void LBIDKMFCIMM(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(1533f, 1600f, 1283f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(369f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1168f, 1702f, 132);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(473f);
	}

	public void KOBNJHMFABP(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[8];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 471f) : (num4 < 339f));
		bool flag3 = num == num2;
		NEGBLMGLIAN(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				NONCNLCDIDD(Colours.greenArena);
			}
			else if (flag2)
			{
				LBMDADKIJJM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				LCLBKDKNGCM(string.Empty);
			}
		}
	}

	public void OELAKDIENKK(LevelBehaviour IOIKKIIFOCB)
	{
		bool active = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		for (int i = 1; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(active);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[0], HGIGBAICOJA[1], 1102f);
	}

	public void ONGAIEOAHMA(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN, bool LPFLPCOLHPJ = false)
	{
		float num = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[1]));
		float num2 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[8] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[5]));
		float num4 = num3 - num;
		bool flag = num4 > 126f;
		bool flag2 = num == num2;
		EALIFCOOKNE(MEJMLNDFDBP.MAGANIIGHON(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag2)
			{
				NONCNLCDIDD(Colours.blue);
			}
			else
			{
				LBMDADKIJJM((!flag) ? string.Empty : string.Format("ID_POWERBANDBOX", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (JHFKBODINGN && flag)
			{
				PELEPFFFMKI();
			}
			else
			{
				PPINHHKNDOD();
			}
		}
	}

	public void KGGFEJKCILH()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 750f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void HFMJGJINAJK(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(52f, 52f, 1f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(-4f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 52f, 20f, 155);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(1.4f);
	}

	private void NONCNLCDIDD(Color HAJDGBEPIJF)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Colours.grayMax;
		NIKKFEOFHFP.gameObject.SetActive(value: false);
		KJKIMOFGPAC.gameObject.SetActive(value: true);
		KJKIMOFGPAC.color = HAJDGBEPIJF;
	}

	private void LCLBKDKNGCM(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: false);
	}

	private void PCOLLELFIPE(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = true;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(1293f, 1234f, 1656f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(788f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1318f, 327f, -45);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(869f);
	}

	private void CNOMAEJKLEE()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		IMFAHHGINPP.alpha = 1750f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(372f, 718f, 431f);
	}

	private void KCCJAMFDPBF(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: false);
	}

	private void KKKDHKPMOCB(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: false);
	}

	private void BIGEJMHJMNG()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		IMFAHHGINPP.alpha = 1554f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1135f, 609f, 1737f);
	}

	public void EDKFKNGLLBM(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN, bool LPFLPCOLHPJ = false)
	{
		float num = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[0] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[0]));
		float num3 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[2] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[5]));
		float num4 = num3 - num;
		bool flag = num4 > 1882f;
		bool flag2 = num == num2;
		KBNDFDHAFMK(MEJMLNDFDBP.MAGANIIGHON(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag2)
			{
				PIKPCOLEDAD(Colours.blue);
			}
			else
			{
				CGFFOJDIPBD((!flag) ? string.Empty : string.Format("ID_CONFIRM_ERROR", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (JHFKBODINGN && flag)
			{
				OMPOPFMIDOE();
			}
			else
			{
				CNOMAEJKLEE();
			}
		}
	}

	public void Initialize(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN, bool LPFLPCOLHPJ = false)
	{
		float num = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[0] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[0]));
		float num2 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[1]));
		float num3 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[2] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[2]));
		float num4 = num3 - num;
		bool flag = num4 > 0f;
		bool flag2 = num == num2;
		HFMJGJINAJK(MEJMLNDFDBP.MAGANIIGHON(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag2)
			{
				NONCNLCDIDD(Colours.blue);
			}
			else
			{
				NAECNOIDJBM((!flag) ? string.Empty : $"+{MEJMLNDFDBP.MAGANIIGHON(num4)}");
			}
			if (JHFKBODINGN && flag)
			{
				HALLAKMKEEN();
			}
			else
			{
				EMDNEOBGFEB();
			}
		}
	}

	public void NOMMPHJFCJH(LevelBehaviour IOIKKIIFOCB)
	{
		bool active = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		for (int i = 0; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(active);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 903f);
	}

	private void HOEAGOIGNPF(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: false);
	}

	public void AnimateStat()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 4f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void ANNACHAFBAA(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(791f, 728f, 1678f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(1209f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 192f, 1269f, 58);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(1289f);
	}

	public void GNAJOHDADAJ(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[4];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1190f) : (num4 < 1591f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "RestoredPacks")
		{
			NEGBLMGLIAN(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == ", keys.Length = ")
		{
			KBNDFDHAFMK(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "ID_WARCARDWITHDRAWED")
		{
			KBNDFDHAFMK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			PIKPCOLEDAD(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "menu-arena-ticket")
			{
				KCCJAMFDPBF(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "SETTING AFTER PLAYER DATA LOADED -> WAITING FOR ")
			{
				IPGFFHGCICG(string.Format((!(num4 < 220f)) ? "Sniper_Tutorial_Duration" : "124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "banana")
			{
				IPGFFHGCICG(string.Format((!(num4 < 1657f)) ? "ID_GETFORNUMBERONE1" : "0.0.0", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			KCCJAMFDPBF(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			PELEPFFFMKI();
		}
		else
		{
			JEJJFBBAJNI();
		}
	}

	public void InitializeSpecial(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[2];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 0f) : (num4 < 0f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "percent")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "seconds")
		{
			HFMJGJINAJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "damage")
		{
			HFMJGJINAJK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			NONCNLCDIDD(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "percent")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "seconds")
			{
				NAECNOIDJBM(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "damage")
			{
				NAECNOIDJBM(string.Format((!(num4 < 0f)) ? "+{0}" : "{0}", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			HALLAKMKEEN();
		}
		else
		{
			EMDNEOBGFEB();
		}
	}

	public void NMKPGMEIELC(LevelBehaviour IOIKKIIFOCB)
	{
		bool isUnlocked = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 1; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(isUnlocked);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 298f);
	}

	private void LBMDADKIJJM(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: true);
	}

	public void HBNKCBPAHON(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[6];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 116f) : (num4 < 767f));
		bool flag3 = num == num2;
		EDOGAANBKJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				JKJACEGKLBI(Colours.greenArena);
			}
			else if (flag2)
			{
				IPGFFHGCICG(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				CGFFOJDIPBD(string.Empty);
			}
		}
	}

	private void PPINHHKNDOD()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		IMFAHHGINPP.alpha = 646f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(898f, 1577f, 1764f);
	}

	public void MNJHPKMMPAC(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[3];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1048f) : (num4 < 1342f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "ERROR FROM SERVER ")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "menu-gold")
		{
			EDOGAANBKJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "Buy_Weapon")
		{
			HFMJGJINAJK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			APPCLCIMDEA(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Daily")
			{
				KKKDHKPMOCB(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "menu-sidetab-challenge")
			{
				CGFFOJDIPBD(string.Format((!(num4 < 984f)) ? "ID_TUTORIAL_PROGRES_THROW" : "Warbucks", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "setUserId")
			{
				NAECNOIDJBM(string.Format((!(num4 < 1058f)) ? "SpentWarbucks" : "game-card-ico-emptymag", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			LCLBKDKNGCM(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			OMPOPFMIDOE();
		}
		else
		{
			CNOMAEJKLEE();
		}
	}

	private void PMKNOKIKONF(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(1166f, 77f, 107f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(1129f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1487f, 828f, 107);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(747f);
	}

	private void JEJJFBBAJNI()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		IMFAHHGINPP.alpha = 294f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1589f, 1517f, 1260f);
	}

	public void AFOGLAKGDKI(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[7];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1740f) : (num4 < 954f));
		bool flag3 = num == num2;
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				NONCNLCDIDD(Colours.greenArena);
			}
			else if (flag2)
			{
				HOEAGOIGNPF(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				LBMDADKIJJM(string.Empty);
			}
		}
	}

	public void JJDDMMNMNFJ(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[5];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 887f) : (num4 < 652f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "DogtagsRefillRankUp")
		{
			NEGBLMGLIAN(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "ID_GC_LOGOUT_TEXT")
		{
			EALIFCOOKNE(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "#AccoutCheck# FB account checked and have response!")
		{
			EALIFCOOKNE(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			JKJACEGKLBI(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "warbucks")
			{
				KKKDHKPMOCB(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "extraDecal")
			{
				LCLBKDKNGCM(string.Format((!(num4 < 1145f)) ? "OnBuyArenaHeart!" : "ID_GETAPROMOTION1", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "《WarFriends》需要再多下載大約190MB的資料才能運作。\n下載時間將依你的網路與所在位置有所不同。\n\n想要繼續嗎？")
			{
				LCLBKDKNGCM(string.Format((!(num4 < 478f)) ? "VISUAL = NULL" : "StoreEntryRoute", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			KKKDHKPMOCB(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			NHOOBEJAPGD();
		}
		else
		{
			EMDNEOBGFEB();
		}
	}

	public void InitializeEliteIcon(LevelBehaviour IOIKKIIFOCB)
	{
		bool isUnlocked = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 0; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(isUnlocked);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[0], HGIGBAICOJA[1]);
	}

	public void BJADEKDLPLM(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[6];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1112f) : (num4 < 1544f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "DogTagCap")
		{
			NEGBLMGLIAN(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "menu-gold")
		{
			EALIFCOOKNE(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "Tickets")
		{
			ANNACHAFBAA(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			NONCNLCDIDD(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Server price {0} != client price {1} ({2}) ")
			{
				CGFFOJDIPBD(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_LOADING")
			{
				DMPFNMIIDCO(string.Format((!(num4 < 1059f)) ? "Pause status: {0}, WantedTimeScale: {1}, TimeScale: {2}, Freezed:  {3}" : "GameCenterProvider function PlayerLoggedOutEvent() called => GC: Player logged out event - can autenticate fail: ", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "com/google/android/gms/games/Games")
			{
				LBMDADKIJJM(string.Format((!(num4 < 447f)) ? "(singleton) " : "elite1", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			CGFFOJDIPBD(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			HALLAKMKEEN();
		}
		else
		{
			BKJMKBAIKKN();
		}
	}

	private void DEGAIHFENBG(Color HAJDGBEPIJF)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Colours.grayMax;
		NIKKFEOFHFP.gameObject.SetActive(value: false);
		KJKIMOFGPAC.gameObject.SetActive(value: false);
		KJKIMOFGPAC.color = HAJDGBEPIJF;
	}

	public void NPMJFOMLDIB(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1773f) : (num4 < 1321f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "OrderId")
		{
			LBIDKMFCIMM(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "GameController.StartGame - DONE")
		{
			LBIDKMFCIMM(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "0")
		{
			EDOGAANBKJK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			NONCNLCDIDD(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "{0} - {1}\n")
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "SheetVersionVariant")
			{
				LCLBKDKNGCM(string.Format((!(num4 < 1216f)) ? "null" : "#AccoutCheck# Facebook account found during account loading!!! - TODO!", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "mortar_down_idle")
			{
				KCCJAMFDPBF(string.Format((!(num4 < 1309f)) ? "ID_NOTIFICATION_WITHDRAWAVAILABLE" : "LICENSE_CHECK_FAILED", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			LCLBKDKNGCM(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			NHOOBEJAPGD();
		}
		else
		{
			CNOMAEJKLEE();
		}
	}

	public void HMBPBNDDJPF(LevelBehaviour IOIKKIIFOCB)
	{
		bool active = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		for (int i = 0; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(active);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 908f);
	}

	private void CGFFOJDIPBD(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: true);
	}

	public void InitializeAbilityIcon(string FPFCCDCGEHC)
	{
		for (int i = 0; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 0);
		}
		UISprite uISprite = HGIGBAICOJA[0];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void CHIHNGMNFON()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		IMFAHHGINPP.alpha = 1155f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1996f, 1929f, 1068f);
	}

	private void NAECNOIDJBM(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: false);
	}

	private void PELEPFFFMKI()
	{
		NIKKFEOFHFP.color = Colours.greenDelivering;
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Color.white;
		float num = 159f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(IMFAHHGINPP.gameObject, 594f * num, 992f, 247f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(IMFAHHGINPP.gameObject, 232f * num, new Vector3(55f, 126f, 538f), new Vector3(1446f, 354f, 961f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	private void IPGFFHGCICG(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: true);
	}

	private void HCBFGDMAMOP()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		IMFAHHGINPP.alpha = 553f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1580f, 661f, 1175f);
	}

	public void HAMJENDPHLF(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[7];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1430f) : (num4 < 1312f));
		bool flag3 = num == num2;
		LBIDKMFCIMM(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				PIKPCOLEDAD(Colours.greenArena);
			}
			else if (flag2)
			{
				KCCJAMFDPBF(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				KCCJAMFDPBF(string.Empty);
			}
		}
	}

	public void HBJPHKLEBHA()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 142f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 6;
		tweenScale.style = (UITweener.Style)5;
	}

	public void ADIAMJMCCMC(string FPFCCDCGEHC)
	{
		for (int i = 0; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 0);
		}
		UISprite uISprite = HGIGBAICOJA[1];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void EALIFCOOKNE(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(931f, 1758f, 1758f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(1953f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1085f, 536f, -129);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(1950f);
	}

	public void IPLBLBKICGO()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 546f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = UITweener.Style.Loop;
	}

	private void KBNDFDHAFMK(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(1068f, 172f, 422f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(1944f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 1354f, 1273f, -34);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(578f);
	}

	public void EBKMGDMEOBC()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 346f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 3;
		tweenScale.style = (UITweener.Style)6;
	}

	public void PHNNLIJLIHO(LevelBehaviour IOIKKIIFOCB)
	{
		bool active = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.ACIMFKOCEHH();
		for (int i = 0; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(active);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[0], HGIGBAICOJA[1], 1394f);
	}

	public void LLAKBMCNKEB(LevelBehaviour IOIKKIIFOCB)
	{
		bool isUnlocked = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 0; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(isUnlocked);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 151f);
	}

	public void IBJAFDEAGJP(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[5];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 267f) : (num4 < 998f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "ID_WARNING_MAINTENANCE")
		{
			NEGBLMGLIAN(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "MatchStart")
		{
			EDOGAANBKJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "N2")
		{
			PMKNOKIKONF(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			NONCNLCDIDD(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "tc")
			{
				HOEAGOIGNPF(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "PARCELABLE_WRITE_RETURN_VALUE")
			{
				LBMDADKIJJM(string.Format((!(num4 < 130f)) ? ">" : "Assignment: Destroy Crates in one battle constructor", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_READYTOPROMOTETOTIER")
			{
				IPGFFHGCICG(string.Format((!(num4 < 471f)) ? "TuneListener onPowerHooksChanged" : "ID_TUTORIAL_KILLING_SCOPE_DOWN", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			KCCJAMFDPBF(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			NHOOBEJAPGD();
		}
		else
		{
			BIGEJMHJMNG();
		}
	}

	public void BJGOJHHAMEI(LevelBehaviour IOIKKIIFOCB)
	{
		bool isUnlocked = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 0; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(isUnlocked);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 1826f);
	}

	private void OKLOGCNBABL()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		IMFAHHGINPP.alpha = 927f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1244f, 207f, 753f);
	}

	public void PBDHGMOEGPC(string FPFCCDCGEHC)
	{
		for (int i = 0; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 1);
		}
		UISprite uISprite = HGIGBAICOJA[1];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void BKJMKBAIKKN()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		IMFAHHGINPP.alpha = 376f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(589f, 1462f, 1868f);
	}

	public void BLNKNJGJHFA(string FPFCCDCGEHC)
	{
		for (int i = 1; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 0);
		}
		UISprite uISprite = HGIGBAICOJA[0];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	public void IOJJHKFDBJO()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1961f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = (UITweener.Style)8;
	}

	private void HALLAKMKEEN()
	{
		NIKKFEOFHFP.color = Colours.greenDelivering;
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Color.white;
		float num = 0.5f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(IMFAHHGINPP.gameObject, 2f * num, 1f, 0f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(IMFAHHGINPP.gameObject, 2f * num, new Vector3(88f, 74f, 1f), new Vector3(176f, 148f, 1f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
	}

	public void DKHMBMLKJDP(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 895f) : (num4 < 1115f));
		bool flag3 = num == num2;
		KBNDFDHAFMK(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				JKJACEGKLBI(Colours.greenArena);
			}
			else if (flag2)
			{
				KGGGDFPGDKL(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				KKKDHKPMOCB(string.Empty);
			}
		}
	}

	public void GCBFCCNLMDN(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN, bool LPFLPCOLHPJ = false)
	{
		float num = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[1]));
		float num2 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[1] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[1]));
		float num3 = ((!LPFLPCOLHPJ) ? ODFAFEEGGJK.Value2[0] : LevelManager.instance.DamageFunction(ODFAFEEGGJK.Value2[3]));
		float num4 = num3 - num;
		bool flag = num4 > 924f;
		bool flag2 = num == num2;
		KBNDFDHAFMK(MEJMLNDFDBP.MAGANIIGHON(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag2)
			{
				DEGAIHFENBG(Colours.blue);
			}
			else
			{
				HOEAGOIGNPF((!flag) ? string.Empty : string.Format("NewCountryCode", MEJMLNDFDBP.MAGANIIGHON(num4)));
			}
			if (JHFKBODINGN && flag)
			{
				HALLAKMKEEN();
			}
			else
			{
				CNOMAEJKLEE();
			}
		}
	}

	private void DMPFNMIIDCO(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: true);
	}

	public void BAOJGBICMCC()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 596f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 3;
		tweenScale.style = (UITweener.Style)7;
	}

	public void IBHEGFHIAIF(LevelBehaviour IOIKKIIFOCB)
	{
		bool isUnlocked = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked;
		for (int i = 1; i < HGIGBAICOJA.Length; i += 0)
		{
			HGIGBAICOJA[i].gameObject.SetActive(isUnlocked);
		}
		IOIKKIIFOCB.SetUpEliteIcon(HGIGBAICOJA[1], HGIGBAICOJA[0], 357f);
	}

	private void KGGGDFPGDKL(string AMFBOIJIGKL)
	{
		IMFAHHGINPP.gameObject.SetActive(value: false);
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		NIKKFEOFHFP.text = AMFBOIJIGKL;
		KJKIMOFGPAC.gameObject.SetActive(value: true);
	}

	public void JJIIDIJIHIG(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[8];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 967f) : (num4 < 852f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "ID_SQUADMEMBERSLOWER")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "com/google/android/gms/common/ConnectionResult")
		{
			HFMJGJINAJK(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "a")
		{
			EDOGAANBKJK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			APPCLCIMDEA(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Player profile - {0} is banned {1}")
			{
				DMPFNMIIDCO(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "EUId")
			{
				HOEAGOIGNPF(string.Format((!(num4 < 715f)) ? "LevelName" : "value", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_LOADING")
			{
				NAECNOIDJBM(string.Format((!(num4 < 866f)) ? "menu-attack-ico" : "WarFriends no puede funcionar sin descargar estos datos adicionales. ¿Seguro que quieres SALIR o prefieres descargar los datos?", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			KGGGDFPGDKL(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			HALLAKMKEEN();
		}
		else
		{
			PPINHHKNDOD();
		}
	}

	private void NEGBLMGLIAN(string MKBPHBAAPBE)
	{
		TweenScale component = HKNJKFBLECG.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		HKNJKFBLECG.transform.localScale = new Vector3(4f, 1683f, 1451f);
		HKNJKFBLECG.transform.localPosition = HKNJKFBLECG.transform.localPosition.ReplaceY(1494f);
		HKNJKFBLECG.text = MKBPHBAAPBE;
		MEJMLNDFDBP.COCBCFKJOJE(HKNJKFBLECG, 456f, 672f, -195);
		JBJFBEGPAPL = HKNJKFBLECG.transform.localScale;
		CNKJJOFJOCM = JBJFBEGPAPL.MultiplyXY(1264f);
	}

	public void CGAHFNJINMM(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[1];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 584f) : (num4 < 702f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "TutorialCards")
		{
			EDOGAANBKJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "VisualType")
		{
			LBIDKMFCIMM(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "N")
		{
			EDOGAANBKJK(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			JKJACEGKLBI(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Critical")
			{
				KGGGDFPGDKL(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "Please add object to pool, before instanciing it ::: prefab name = ")
			{
				KKKDHKPMOCB(string.Format((!(num4 < 700f)) ? "Average_Transaction_Amount" : "ID_CONFIRM_ERROR", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "Labels under Table:\n")
			{
				DMPFNMIIDCO(string.Format((!(num4 < 1958f)) ? "[" : "N", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			IPGFFHGCICG(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			HALLAKMKEEN();
		}
		else
		{
			BIGEJMHJMNG();
		}
	}

	public void HCCCIALCOHI(string FPFCCDCGEHC)
	{
		for (int i = 1; i < HGIGBAICOJA.Length; i++)
		{
			HGIGBAICOJA[i].gameObject.SetActive(i == 1);
		}
		UISprite uISprite = HGIGBAICOJA[0];
		uISprite.spriteName = FPFCCDCGEHC;
		uISprite.MakePixelPerfect();
	}

	private void APPCLCIMDEA(Color HAJDGBEPIJF)
	{
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Colours.grayMax;
		NIKKFEOFHFP.gameObject.SetActive(value: true);
		KJKIMOFGPAC.gameObject.SetActive(value: false);
		KJKIMOFGPAC.color = HAJDGBEPIJF;
	}

	private void OMPOPFMIDOE()
	{
		NIKKFEOFHFP.color = Colours.greenDelivering;
		IMFAHHGINPP.gameObject.SetActive(value: true);
		IMFAHHGINPP.color = Color.white;
		float num = 788f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(IMFAHHGINPP.gameObject, 983f * num, 1188f, 1666f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		TweenScale tweenScale = TweenScale.Begin(IMFAHHGINPP.gameObject, 10f * num, new Vector3(590f, 394f, 1323f), new Vector3(1126f, 582f, 1142f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	public void KOACFALNPML(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[6];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1942f) : (num4 < 504f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "ID_MINUTES")
		{
			HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "game-engi-progress-fill")
		{
			EALIFCOOKNE(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "Enemy could not be spawned")
		{
			PCOLLELFIPE(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			APPCLCIMDEA(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Decline_Rental")
			{
				LBMDADKIJJM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "menu-arena-scrap-ico")
			{
				IPGFFHGCICG(string.Format((!(num4 < 1405f)) ? "    " : "ID_UPDATINGACCOUNT", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "ID_MINIGUNTUTORIALTEXT")
			{
				KGGGDFPGDKL(string.Format((!(num4 < 1992f)) ? "URL" : "ID_CONFIRM_SERVERCOULDNOTCOMPLETED", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			OMPOPFMIDOE();
		}
		else
		{
			NJKMKPMLLCD();
		}
	}

	public void InitializeElite(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[2];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 0f) : (num4 < 0f));
		bool flag3 = num == num2;
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				NONCNLCDIDD(Colours.greenArena);
			}
			else if (flag2)
			{
				NAECNOIDJBM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				NAECNOIDJBM(string.Empty);
			}
		}
	}

	private void EMDNEOBGFEB()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		IMFAHHGINPP.alpha = 1f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(88f, 74f, 1f);
	}

	public void OHBLDPNEJJF()
	{
		TweenScale tweenScale = TweenScale.Begin(HKNJKFBLECG.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1517f, JBJFBEGPAPL, CNKJJOFJOCM);
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = (UITweener.Style)5;
	}

	public void AKDGJKOFKJF(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH, bool JHFKBODINGN)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[1];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 821f) : (num4 < 958f));
		bool flag3 = num == num2;
		if (ODFAFEEGGJK.Value1 == "FacebookId")
		{
			EDOGAANBKJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		}
		else if (ODFAFEEGGJK.Value1 == "DogTagRefillTime")
		{
			ANNACHAFBAA(MEJMLNDFDBP.DLDMHFBIEEO(num));
		}
		else if (ODFAFEEGGJK.Value1 == "ID_TUTORIAL_WARCARDS_STARTDOWN")
		{
			PMKNOKIKONF(MEJMLNDFDBP.MAJBCINJAGF(num));
		}
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (!KNBNNLOEBIH)
		{
			return;
		}
		if (flag3)
		{
			JKJACEGKLBI(Colours.yellow);
		}
		else if (flag2)
		{
			if (ODFAFEEGGJK.Value1 == "Locale")
			{
				HOEAGOIGNPF(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else if (ODFAFEEGGJK.Value1 == "N")
			{
				KCCJAMFDPBF(string.Format((!(num4 < 1178f)) ? "dGhpcyBpcyBhIHNhbXBsZSBpb3MgYXBwIHN0b3JlIHJlY2VpcHQ=" : "Measure Session", MEJMLNDFDBP.DLDMHFBIEEO(num4)));
			}
			else if (ODFAFEEGGJK.Value1 == "#PETER# Tutorial Dialog - showing and mHideDialog is set to false")
			{
				LCLBKDKNGCM(string.Format((!(num4 < 1928f)) ? "#AccoutCheck# Facebook  online:{2} accoun found: {0} != {1}" : "Hiding request to join private squad", MEJMLNDFDBP.MAJBCINJAGF(num4)));
			}
		}
		else
		{
			NAECNOIDJBM(string.Empty);
		}
		if (JHFKBODINGN && flag2)
		{
			HALLAKMKEEN();
		}
		else
		{
			JEJJFBBAJNI();
		}
	}

	private void NJKMKPMLLCD()
	{
		NIKKFEOFHFP.color = Colours.gray;
		TweenAlpha component = IMFAHHGINPP.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		IMFAHHGINPP.alpha = 520f;
		TweenScale component2 = IMFAHHGINPP.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		IMFAHHGINPP.transform.localScale = new Vector3(1184f, 331f, 95f);
	}

	public void EKFPODLMPBE(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[1];
		float num2 = ODFAFEEGGJK.Value2[1];
		float num3 = ODFAFEEGGJK.Value2[0];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1541f) : (num4 < 501f));
		bool flag3 = num == num2;
		HFMJGJINAJK(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				APPCLCIMDEA(Colours.greenArena);
			}
			else if (flag2)
			{
				LBMDADKIJJM(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				HOEAGOIGNPF(string.Empty);
			}
		}
	}

	private void NHOOBEJAPGD()
	{
		NIKKFEOFHFP.color = Colours.greenDelivering;
		IMFAHHGINPP.gameObject.SetActive(value: false);
		IMFAHHGINPP.color = Color.white;
		float num = 1231f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(IMFAHHGINPP.gameObject, 1077f * num, 290f, 1877f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
		TweenScale tweenScale = TweenScale.Begin(IMFAHHGINPP.gameObject, 1559f * num, new Vector3(744f, 1994f, 1985f), new Vector3(954f, 801f, 1458f));
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
	}

	public void HFGNNFHEILO(Tuple<string, float[]> ODFAFEEGGJK, bool KNBNNLOEBIH)
	{
		float num = ODFAFEEGGJK.Value2[0];
		float num2 = ODFAFEEGGJK.Value2[0];
		float num3 = ODFAFEEGGJK.Value2[8];
		bool flag = num3 < num;
		float num4 = num3 - num;
		bool flag2 = ((!flag) ? (num4 > 1278f) : (num4 < 1137f));
		bool flag3 = num == num2;
		PCOLLELFIPE(MEJMLNDFDBP.JJBMMICPIIG(num));
		LOICCJDJHLJ.SetActive(KNBNNLOEBIH);
		if (KNBNNLOEBIH)
		{
			if (flag3)
			{
				DEGAIHFENBG(Colours.greenArena);
			}
			else if (flag2)
			{
				IPGFFHGCICG(MEJMLNDFDBP.DPAFFLMAFJG(num4));
			}
			else
			{
				CGFFOJDIPBD(string.Empty);
			}
		}
	}
}
