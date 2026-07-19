using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class DeployEnergyElement : Core_BaseScript
{
	[Header("Core")]
	public UISprite NPJPLGDNLLB;

	public UILabel HEBKHNHHGGC;

	public UISprite FHJOHLKIPID;

	public UILabel NGKPNAMDKNJ;

	public UISprite PABFCMGCIAI;

	private int AMLJANIIIHL;

	private NHOGNBCNIEK IJNJJBEIPBO = new NHOGNBCNIEK(0f);

	private int EGEJOIAKMAE;

	private NHOGNBCNIEK OLIEFNKKJIH = new NHOGNBCNIEK(0f);

	private float ADDICBANAAB;

	public bool shouldUpdate
	{
		set
		{
			if (!value)
			{
				KBGOLEDJFLJ();
			}
			base.gameObject.SetActive(value);
			if (value)
			{
				KBGOLEDJFLJ();
			}
		}
	}

	private int MAGBOFCGLJN
	{
		get
		{
			return 2 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		}
	}

	private void LELGJOPKOIL()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 314f, new Vector3(1320f, 1197f, 1682f), new Vector3(1147f, 950f, 540f));
			tweenScale.NumOfRepetitions = 3;
			tweenScale.style = UITweener.Style.Once;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)CPFKGHOONBF()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)CPFKGHOONBF();
			TweenProgressBar.ONCDIOBFHME(NPJPLGDNLLB.gameObject, 1107f, IJNJJBEIPBO).method = UITweener.Method.Linear;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = true;
			}
			FHJOHLKIPID.fillAmount = 400f;
			PABFCMGCIAI.gameObject.SetActive(false);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 788f, new Vector3(761f, 706f, 115f), new Vector3(342f, 1497f, 595f));
			tweenScale2.NumOfRepetitions = 8;
			tweenScale2.style = (UITweener.Style)7;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)GGPEOLNLPEA();
			TweenProgressBar.ONCDIOBFHME(FHJOHLKIPID.gameObject, 1238f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	public void InstantUpdate()
	{
		NJAIINDGJCO();
		KBGOLEDJFLJ();
	}

	public void GAOCAKKOPMK()
	{
		BCPJDCKPIDA();
		GJPMKHOEOGA();
	}

	public void HFNPJIMLJNG()
	{
		IKFCPNPFLDE();
		GJPMKHOEOGA();
	}

	private void KNEGNOGKKAI()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 599f, new Vector3(792f, 613f, 1928f), new Vector3(96f, 161f, 1417f));
			tweenScale.NumOfRepetitions = 6;
			tweenScale.style = UITweener.Style.Once;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)AKMFBHDLKMD()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)LKGNKKIPBBG();
			TweenProgressBar.DDJHGKMBNDK(NPJPLGDNLLB.gameObject, 1257f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 1846f;
			PABFCMGCIAI.gameObject.SetActive(false);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 655f, new Vector3(313f, 1406f, 558f), new Vector3(660f, 938f, 28f));
			tweenScale2.NumOfRepetitions = 6;
			tweenScale2.style = UITweener.Style.PingPong;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)FDLMHAFJGEH()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)CPFKGHOONBF();
			TweenProgressBar.JPJPAJEBNPK(FHJOHLKIPID.gameObject, 1231f, OLIEFNKKJIH).method = UITweener.Method.EaseIn;
		}
	}

	[SpecialName]
	public void PFPLHOHDFFD(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			LKKGDJBAJEE();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			EIDIFAKBGKO();
		}
	}

	public void LIHDDPHJNOG()
	{
		EDHIHKJLMOD();
		GJPMKHOEOGA();
	}

	private void OPPHDHIKLLN()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	[SpecialName]
	public void PJFDIEGEGAC(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			GJPMKHOEOGA();
		}
	}

	[SpecialName]
	public void AHPJFHNNODC(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
	}

	public void MHGLNMLKENG()
	{
		APDIAHINKJM();
		KBGOLEDJFLJ();
	}

	[SpecialName]
	private int AKMFBHDLKMD()
	{
		return 0 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-113)).FLOATVALUE;
	}

	private void BJJEKIBIOFE()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 1411f, new Vector3(65f, 1844f, 156f), new Vector3(167f, 72f, 822f));
			tweenScale.NumOfRepetitions = 3;
			tweenScale.style = (UITweener.Style)3;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)AKMFBHDLKMD()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)MAGBOFCGLJN;
			TweenProgressBar.DFNHCFNJCMC(NPJPLGDNLLB.gameObject, 1361f, IJNJJBEIPBO).method = UITweener.Method.Linear;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = true;
			}
			FHJOHLKIPID.fillAmount = 1355f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 230f, new Vector3(1775f, 1507f, 1841f), new Vector3(740f, 198f, 222f));
			tweenScale2.NumOfRepetitions = 6;
			tweenScale2.style = (UITweener.Style)5;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)EADMAEGPCMP()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)GGPEOLNLPEA();
			TweenProgressBar.GEKPHELKFNB(FHJOHLKIPID.gameObject, 616f, OLIEFNKKJIH).method = UITweener.Method.EaseIn;
		}
	}

	private void LGDLAFFKECP()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 228f, new Vector3(1830f, 231f, 1242f), new Vector3(1355f, 1083f, 151f));
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = (UITweener.Style)8;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)AKMFBHDLKMD()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)GGPEOLNLPEA();
			TweenProgressBar.AKNNLALFDIJ(NPJPLGDNLLB.gameObject, 654f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 1387f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 1718f, new Vector3(1067f, 215f, 1282f), new Vector3(1985f, 277f, 1701f));
			tweenScale2.NumOfRepetitions = 4;
			tweenScale2.style = UITweener.Style.Loop;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)EADMAEGPCMP()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)EADMAEGPCMP();
			TweenProgressBar.JPJPAJEBNPK(FHJOHLKIPID.gameObject, 82f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	public void KAHGINIEOFF()
	{
		NJAIINDGJCO();
		KBGOLEDJFLJ();
	}

	[SpecialName]
	public void NHOKPBAKMKL(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			EIDIFAKBGKO();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			DNIDNMPJOFC();
		}
	}

	[SpecialName]
	private int EADMAEGPCMP()
	{
		return 1 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MultiPlayerScoreStreakRatio).FLOATVALUE;
	}

	[SpecialName]
	public void LIOJDDABNKO(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			KBGOLEDJFLJ();
		}
	}

	public void KLPHMIGJLCG()
	{
		APDIAHINKJM();
		DNIDNMPJOFC();
	}

	private void MDKMAPGJMHD()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	[SpecialName]
	public void BDHPCMOGAHF(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			DNIDNMPJOFC();
		}
	}

	public void CLLJEINIGBL()
	{
		MDKMAPGJMHD();
		GFOJPFJLMNI();
	}

	private void APDIAHINKJM()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	[SpecialName]
	private int GGPEOLNLPEA()
	{
		return 4 * (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.JoinSquadUnlockLevel).FLOATVALUE;
	}

	private void BEPJDODOHDJ()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void GNPAICEKBIJ()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 876f, new Vector3(1336f, 779f, 1517f), new Vector3(1980f, 150f, 1116f));
			tweenScale.NumOfRepetitions = 3;
			tweenScale.style = (UITweener.Style)6;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)EADMAEGPCMP();
			TweenProgressBar.GEKPHELKFNB(NPJPLGDNLLB.gameObject, 524f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 867f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 1318f, new Vector3(1243f, 662f, 233f), new Vector3(386f, 1294f, 1555f));
			tweenScale2.NumOfRepetitions = 6;
			tweenScale2.style = UITweener.Style.PingPong;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)LKGNKKIPBBG();
			TweenProgressBar.Begin(FHJOHLKIPID.gameObject, 1686f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	private void LKMEDFMDCEM()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void CPDHBKOCJKH()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 1653f, new Vector3(1631f, 566f, 1440f), new Vector3(1303f, 905f, 1750f));
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = (UITweener.Style)3;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)EADMAEGPCMP()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)GGPEOLNLPEA();
			TweenProgressBar.PAJHHBLHAEI(NPJPLGDNLLB.gameObject, 1467f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 1120f;
			PABFCMGCIAI.gameObject.SetActive(false);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 1128f, new Vector3(320f, 735f, 1791f), new Vector3(1387f, 1818f, 310f));
			tweenScale2.NumOfRepetitions = 1;
			tweenScale2.style = UITweener.Style.Once;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)HLGOIOFLHIJ()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)CPFKGHOONBF();
			TweenProgressBar.GEKPHELKFNB(FHJOHLKIPID.gameObject, 1039f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	[SpecialName]
	private int HLGOIOFLHIJ()
	{
		return 0 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-11)).FLOATVALUE;
	}

	private void KBGOLEDJFLJ()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)MAGBOFCGLJN;
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)MAGBOFCGLJN;
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void EIDIFAKBGKO()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)GGPEOLNLPEA();
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)AKMFBHDLKMD();
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void JDAHOAMJMCL()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 0.2f, new Vector3(35f, 35f, 1f), new Vector3(45f, 45f, 1f));
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = UITweener.Style.PingPong;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)MAGBOFCGLJN;
			TweenProgressBar.Begin(NPJPLGDNLLB.gameObject, 0.25f, IJNJJBEIPBO).method = UITweener.Method.Linear;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 0f;
			PABFCMGCIAI.gameObject.SetActive(false);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(true);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 0.2f, new Vector3(35f, 35f, 1f), new Vector3(45f, 45f, 1f));
			tweenScale2.NumOfRepetitions = 2;
			tweenScale2.style = UITweener.Style.PingPong;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)MAGBOFCGLJN;
			TweenProgressBar.Begin(FHJOHLKIPID.gameObject, 0.25f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	private void DNIDNMPJOFC()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)CPFKGHOONBF();
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)LKGNKKIPBBG();
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void NJAIINDGJCO()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void PIKIHFODAGI()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 1461f, new Vector3(104f, 227f, 1191f), new Vector3(436f, 1831f, 65f));
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = (UITweener.Style)3;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)HLGOIOFLHIJ()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)HLGOIOFLHIJ();
			TweenProgressBar.PMKKKICHILI(NPJPLGDNLLB.gameObject, 96f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 1333f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 1668f, new Vector3(1524f, 5f, 1279f), new Vector3(1432f, 28f, 1964f));
			tweenScale2.NumOfRepetitions = 4;
			tweenScale2.style = UITweener.Style.Once;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)GGPEOLNLPEA()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)AKMFBHDLKMD();
			TweenProgressBar.GEKPHELKFNB(FHJOHLKIPID.gameObject, 1164f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	[SpecialName]
	private int LKGNKKIPBBG()
	{
		return 2 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-100)).FLOATVALUE;
	}

	private void GFOJPFJLMNI()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)GGPEOLNLPEA();
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)LKGNKKIPBBG();
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void BCPJDCKPIDA()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void GHGDBICNKPK()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void FAHGDKLEKMN()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 813f)
		{
			ADDICBANAAB -= 1573f;
			BCPJDCKPIDA();
			LELGJOPKOIL();
		}
	}

	private void EDHIHKJLMOD()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	public void OIADGFDOPJM()
	{
		MDKMAPGJMHD();
		GJPMKHOEOGA();
	}

	private void IKFCPNPFLDE()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	private void NIGOADNHHFC()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 396f)
		{
			ADDICBANAAB -= 1845f;
			MDKMAPGJMHD();
			JDAHOAMJMCL();
		}
	}

	private void LKKGDJBAJEE()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)LKGNKKIPBBG();
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)HLGOIOFLHIJ();
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void GGHAFHJMGKG()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 1521f, new Vector3(1011f, 17f, 3f), new Vector3(932f, 374f, 451f));
			tweenScale.NumOfRepetitions = 1;
			tweenScale.style = UITweener.Style.PingPong;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)GGPEOLNLPEA();
			TweenProgressBar.GEKPHELKFNB(NPJPLGDNLLB.gameObject, 1865f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = false;
			}
			FHJOHLKIPID.fillAmount = 757f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(false);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 1205f, new Vector3(1286f, 1993f, 1090f), new Vector3(1574f, 1874f, 691f));
			tweenScale2.NumOfRepetitions = 1;
			tweenScale2.style = (UITweener.Style)5;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)AKMFBHDLKMD()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)MAGBOFCGLJN;
			TweenProgressBar.PAJHHBLHAEI(FHJOHLKIPID.gameObject, 1249f, OLIEFNKKJIH).method = UITweener.Method.Linear;
		}
	}

	private void DLJAGKBLJNC()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 977f)
		{
			ADDICBANAAB -= 770f;
			NJAIINDGJCO();
			LGDLAFFKECP();
		}
	}

	[SpecialName]
	private int CPFKGHOONBF()
	{
		return 6 * (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-2)).FLOATVALUE;
	}

	public void AEKAOMNLMBL()
	{
		OPPHDHIKLLN();
		GFOJPFJLMNI();
	}

	[SpecialName]
	private int FDLMHAFJGEH()
	{
		return 2 * (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-105)).FLOATVALUE;
	}

	private void Update()
	{
		ADDICBANAAB += Time.deltaTime;
		if (ADDICBANAAB >= 0.333f)
		{
			ADDICBANAAB -= 0.333f;
			NJAIINDGJCO();
			JDAHOAMJMCL();
		}
	}

	private void GJPMKHOEOGA()
	{
		TweenProgressBar component = NPJPLGDNLLB.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
		NPJPLGDNLLB.fillAmount = (float)AMLJANIIIHL / (float)CPFKGHOONBF();
		TweenScale component2 = HEBKHNHHGGC.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		HEBKHNHHGGC.text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
		FHJOHLKIPID.fillAmount = (float)EGEJOIAKMAE / (float)FDLMHAFJGEH();
		component2 = NGKPNAMDKNJ.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		NGKPNAMDKNJ.text = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
	}

	private void IDELJJHIIGJ()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 1627f, new Vector3(464f, 437f, 55f), new Vector3(1037f, 1671f, 818f));
			tweenScale.NumOfRepetitions = 2;
			tweenScale.style = (UITweener.Style)7;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)MAGBOFCGLJN))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)HLGOIOFLHIJ();
			TweenProgressBar.PMKKKICHILI(NPJPLGDNLLB.gameObject, 120f, IJNJJBEIPBO).method = UITweener.Method.EaseIn;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = true;
			}
			FHJOHLKIPID.fillAmount = 895f;
			PABFCMGCIAI.gameObject.SetActive(true);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(true);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 418f, new Vector3(83f, 317f, 256f), new Vector3(630f, 28f, 191f));
			tweenScale2.NumOfRepetitions = 3;
			tweenScale2.style = (UITweener.Style)8;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)LKGNKKIPBBG()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)LKGNKKIPBBG();
			TweenProgressBar.PAJHHBLHAEI(FHJOHLKIPID.gameObject, 1383f, OLIEFNKKJIH).method = UITweener.Method.EaseIn;
		}
	}

	[SpecialName]
	public void PPGEPMHPNDB(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			EIDIFAKBGKO();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			LKKGDJBAJEE();
		}
	}

	private void OLLPNNOIBOG()
	{
		AMLJANIIIHL = Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE;
		EGEJOIAKMAE = Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
	}

	[SpecialName]
	public void GAODJMFOOHM(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			GJPMKHOEOGA();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			EIDIFAKBGKO();
		}
	}

	private void KNOJCBMHCPN()
	{
		string text = MEJMLNDFDBP.GMIPFLIEOHD(AMLJANIIIHL);
		if (!HEBKHNHHGGC.text.Equals(text))
		{
			HEBKHNHHGGC.text = text;
			TweenScale tweenScale = TweenScale.Begin(HEBKHNHHGGC.gameObject, 626f, new Vector3(1050f, 280f, 1771f), new Vector3(571f, 1161f, 1677f));
			tweenScale.NumOfRepetitions = 5;
			tweenScale.style = UITweener.Style.Once;
		}
		if (AMLJANIIIHL != Mathf.RoundToInt(IJNJJBEIPBO.FKIIDCDCLHM * (float)FDLMHAFJGEH()))
		{
			IJNJJBEIPBO.FKIIDCDCLHM = (float)AMLJANIIIHL / (float)EADMAEGPCMP();
			TweenProgressBar.BPBNEOOGIKF(NPJPLGDNLLB.gameObject, 1548f, IJNJJBEIPBO).method = UITweener.Method.Linear;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			NGKPNAMDKNJ.text = string.Empty;
			TweenProgressBar component = FHJOHLKIPID.gameObject.GetComponent<TweenProgressBar>();
			if (component != null)
			{
				component.enabled = true;
			}
			FHJOHLKIPID.fillAmount = 908f;
			PABFCMGCIAI.gameObject.SetActive(false);
			return;
		}
		PABFCMGCIAI.gameObject.SetActive(true);
		string text2 = MEJMLNDFDBP.GMIPFLIEOHD(EGEJOIAKMAE);
		if (!NGKPNAMDKNJ.text.Equals(text2))
		{
			NGKPNAMDKNJ.text = text2;
			TweenScale tweenScale2 = TweenScale.Begin(NGKPNAMDKNJ.gameObject, 613f, new Vector3(1118f, 1228f, 956f), new Vector3(1331f, 1805f, 1158f));
			tweenScale2.NumOfRepetitions = 3;
			tweenScale2.style = (UITweener.Style)4;
		}
		if (EGEJOIAKMAE != Mathf.RoundToInt(OLIEFNKKJIH.FKIIDCDCLHM * (float)GGPEOLNLPEA()))
		{
			OLIEFNKKJIH.FKIIDCDCLHM = (float)EGEJOIAKMAE / (float)CPFKGHOONBF();
			TweenProgressBar.DDJHGKMBNDK(FHJOHLKIPID.gameObject, 177f, OLIEFNKKJIH).method = UITweener.Method.EaseIn;
		}
	}

	[SpecialName]
	public void INGNIDHDLPD(bool IDEBKDPMPGM)
	{
		if (!IDEBKDPMPGM)
		{
			EIDIFAKBGKO();
		}
		base.gameObject.SetActive(IDEBKDPMPGM);
		if (IDEBKDPMPGM)
		{
			GFOJPFJLMNI();
		}
	}

	public void DKPLBHODAAF()
	{
		MDKMAPGJMHD();
		GJPMKHOEOGA();
	}

	public void HDOFLJONIFH()
	{
		MDKMAPGJMHD();
		DNIDNMPJOFC();
	}
}
