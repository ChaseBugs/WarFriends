using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class KillStreakGuiElement : GuiElementSingle<KillStreakGuiElement>
{
	[FormerlySerializedAs("MFJMJGANDFB")]
	public UISprite NGEKLKKFEHB;

	[FormerlySerializedAs("HAMMMHALMDL")]
	public UISprite LNLIOLLNCHJ;

	[FormerlySerializedAs("ALBMJCMCOIJ")]
	public UISprite CGFJJPPKCDF;

	[FormerlySerializedAs("DDGGKMPBECB")]
	public UISprite JJBBBIMPNNF;

	[FormerlySerializedAs("AOOKJCBKGNK")]
	public UILabel FDJELJHIMJC;

	[FormerlySerializedAs("PBMKMJOFOCL")]
	public UILabel HILCPHDHNOK;

	[FormerlySerializedAs("GFAOPIPEMIP")]
	public UISprite LNPPFPMBEGI;

	[FormerlySerializedAs("BADJNFBMBCI")]
	public UISprite CLBPACCJKPB;

	[FormerlySerializedAs("MOIGBJAGKOH")]
	public Color POHKAGIICGO;

	[FormerlySerializedAs("HNECIEDBPHJ")]
	public Color GDNFBKCMPDD;

	[FormerlySerializedAs("IMKKDHPIFLM")]
	public UISprite AHBJADFFMFN;

	[FormerlySerializedAs("DDDFFIMDGIC")]
	public UISprite OCFDCEJBECP;

	[FormerlySerializedAs("APPPCAHDGPA")]
	public GameObject GMBGALPLCHC;

	[FormerlySerializedAs("MOMMKNPBHIG")]
	public UIPanel JIIIODFEBOO;

	private TweenAnimator FNOMCHPCOHB;

	private bool CCOIEIOFBFL;

	private float AHIBFODJEEG;

	private bool NHEKOBJPBGE;

	[FormerlySerializedAs("EDGAKPMEILF")]
	public bool AFLBIONHLKM;

	[Header("Score Streak Animation")]
	[FormerlySerializedAs("IFCLNBMPEOP")]
	public float GONJIDADNEI = 0.1f;

	[FormerlySerializedAs("DGDHCJPHAGC")]
	public float PNAPOBMKMLM = 0.15f;

	[FormerlySerializedAs("DBDANHIDFFI")]
	public Vector3 OGLEJIPAKLG = new Vector3(-560f, -150f, 0f);

	[FormerlySerializedAs("PBAJGGCDGDC")]
	public Vector3 FJJPEOIMMNH = new Vector3(0f, -150f, 0f);

	[FormerlySerializedAs("HAGNCINIJJE")]
	public Vector3 IODPNJIAEAP = new Vector3(100f, 100f, 0f);

	[FormerlySerializedAs("KPPDPKOEJLA")]
	public Vector3 GOHJDMLKJBA = new Vector3(220f, 220f, 0f);

	[FormerlySerializedAs("LOEFLMPLAGK")]
	public float EELLEMIFAMO = 0.3f;

	[FormerlySerializedAs("NMOCDCLAHKA")]
	public float KFGIBCDINOL = 0.2f;

	[FormerlySerializedAs("EHGKMOPOIBH")]
	public float AIBMDCENBDE = 0.2f;

	[FormerlySerializedAs("JHAPFGEHNMA")]
	public Vector3 CNNCMAPABAO = new Vector3(1100f, 160.6f, 1f);

	[FormerlySerializedAs("CMIAFFNGNAH")]
	public Vector3 GFPBCHPOOKC = new Vector3(940f, 160.6f, 1f);

	[FormerlySerializedAs("JKELCEFAIKB")]
	public float EIFNCBDHBOG = 0.7f;

	[FormerlySerializedAs("FNALDKIAPOM")]
	public float JCHLBFOCMCI = 0.3f;

	[FormerlySerializedAs("HPMIJDNIOEA")]
	public Vector3 JBOHPPFBOEI = new Vector3(-470f, -149f, 0f);

	[FormerlySerializedAs("BDJBLIOJGPD")]
	public Vector3 MEMGNJPNFKL = new Vector3(-570f, -149f, 0f);

	[FormerlySerializedAs("GPKIIEKKIKH")]
	public float NPOEJHKCCLO = 0.1f;

	[FormerlySerializedAs("MLBFBHBFABF")]
	public float NDJIPJPDFNI = -50f;

	[FormerlySerializedAs("GAAGFLGKNGC")]
	public float DBANEIDNJJF = 50f;

	[FormerlySerializedAs("KLBHACBBDIM")]
	public float IGICDDJJAAE = 0.1f;

	[FormerlySerializedAs("OCAKMLGGKBE")]
	public float HNLMEFHHINK = 0.1f;

	[FormerlySerializedAs("KGEOCFHDAIM")]
	public float CNANCIDDHJI = 0.6f;

	[FormerlySerializedAs("KIOHEBEGCBD")]
	public float BLBIANFHAOF = 0.1f;

	[FormerlySerializedAs("CGDOFCEFKPN")]
	public float MMEIKOLDJNH = 0.4f;

	[FormerlySerializedAs("JMBPPECMLAO")]
	public float JENAOMBKNBP = 0.2f;

	[FormerlySerializedAs("KCNBDNPOGJB")]
	public float ICDKGNAFJAD = 1.4f;

	[FormerlySerializedAs("IPFABIDPFIL")]
	public float KJGHMLDFANG = 0.1f;

	[FormerlySerializedAs("IPKDNBNLFKG")]
	public float COLMGDEIDPF = 0.1f;

	[FormerlySerializedAs("MOECLDAHKGI")]
	public Vector3 LIIFLPDBEJB = new Vector3(50f, -160f, -50f);

	[FormerlySerializedAs("BHMNHGDFLKG")]
	public float JANBMBMIFDL = 50f;

	[FormerlySerializedAs("BNOJHDNMOBJ")]
	public Vector3 MAHNNHIJPJI = new Vector3(-450f, -150f, 0f);

	[FormerlySerializedAs("JADAFBLGMCD")]
	public float FIDGBEEMHLF = -50f;

	[FormerlySerializedAs("EBBNOOMJBDP")]
	public float FKGMFDDOPLC = 25f;

	[FormerlySerializedAs("GPJNEEEIIHH")]
	public float PKBFLLLNNGD = 0.7f;

	[FormerlySerializedAs("GBDJJNBBGHH")]
	public float CELCNBJLMIA = 0.05f;

	private void EHAEEAGIBKL()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = false;
			CIGIGJDJJKO();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1362f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)5;
			tweenColor.NumOfRepetitions = 3;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FBLOANIMAHG));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 26f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(1263f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.FJJPIMGNPHN(), Time.deltaTime * TimeManager.JIJLKEFLPGM(1002f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1435f;
	}

	public void MCEGBOFKMEG()
	{
		AFLBIONHLKM = true;
	}

	public void GFOFOIOHJLD()
	{
		AFLBIONHLKM = false;
	}

	private void KIDPAMAFLJB()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	public virtual void HEEANEFGCCJ()
	{
		NHEKOBJPBGE = false;
		AHIBFODJEEG = 902f;
		NGEKLKKFEHB.alpha = 913f;
		LNLIOLLNCHJ.alpha = 1005f;
		CGFJJPPKCDF.alpha = 1870f;
		JJBBBIMPNNF.alpha = 1859f;
		FDJELJHIMJC.alpha = 173f;
		HILCPHDHNOK.alpha = 1961f;
		LNPPFPMBEGI.alpha = 1149f;
		CLBPACCJKPB.alpha = 1455f;
	}

	[CompilerGenerated]
	private void NJCHIPOOKGB(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 0f;
		NHEKOBJPBGE = false;
	}

	private void EAKLDFIPDGI()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1598f, new Vector3(1378f, 1846f, 1375f));
		tweenScale.method = UITweener.Method.BounceIn;
		tweenScale.onFinished = OCGCFLDDEHK;
	}

	public void DAGBIIIJHNG()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.PHCCOHJPLKE();
			CCOIEIOFBFL = false;
		}
		AFLBIONHLKM = false;
	}

	public virtual void OOBJHJLMEED()
	{
	}

	public virtual void FFOEIHKGGPL()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		BLBGGKEONBC();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(LPFGCCABMKH));
		Singleton<GameController>.instance.CNPGMMPAGIE(MLIANAHDABK);
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
	}

	private void CEGFMCMPMAD()
	{
		GEDHDLDEPDG();
		FNOMCHPCOHB.ODIJFGCDJNH();
		CCOIEIOFBFL = true;
	}

	private void EEAKIKIIPEP(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 547f;
		NHEKOBJPBGE = true;
	}

	public virtual void PBLLMABJFDM()
	{
		NHEKOBJPBGE = false;
		AHIBFODJEEG = 854f;
		NGEKLKKFEHB.alpha = 1987f;
		LNLIOLLNCHJ.alpha = 50f;
		CGFJJPPKCDF.alpha = 1901f;
		JJBBBIMPNNF.alpha = 1199f;
		FDJELJHIMJC.alpha = 665f;
		HILCPHDHNOK.alpha = 805f;
		LNPPFPMBEGI.alpha = 259f;
		CLBPACCJKPB.alpha = 1408f;
	}

	public virtual void PHCLMMLOAKH()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		MDAMCJELEJI();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(BDKONKNFMFM));
		Singleton<GameController>.instance.GameEnded += CBDPIDOMDDI;
		Singleton<GameController>.instance.GameStarted += KIDPAMAFLJB;
	}

	private void CEFEPMPOBPL(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 1963f;
		NHEKOBJPBGE = false;
	}

	private void LDOFPCLKFIC()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void FHHAEKIFKAL(UITweener KPICOKPHMIC)
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1050f, new Vector3(89f, 948f, 1266f));
		tweenScale.method = UITweener.Method.EaseIn;
	}

	protected virtual void EBGBDDIADEJ()
	{
		base.Update();
		GGKHHKJCDDE();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.DGFGECMICOK()) ? 1234f : 1737f);
		}
	}

	private void OCGCFLDDEHK(UITweener KPICOKPHMIC)
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1693f, new Vector3(1797f, 1191f, 1311f));
		tweenScale.method = UITweener.Method.EaseIn;
	}

	private void FBOOFNDODAM()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = false;
			FAACPHINKGF();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 598f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)7;
			tweenColor.NumOfRepetitions = 5;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, (UITweener.OnFinished)delegate
			{
				AHIBFODJEEG = 0f;
				NHEKOBJPBGE = false;
			});
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 679f, Time.deltaTime * TimeManager.JIJLKEFLPGM(1152f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.FJJPIMGNPHN(), Time.deltaTime * TimeManager.GetTimeScaledSpeed(1056f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1209f;
	}

	protected virtual void FDPOJHLHGJO()
	{
		base.BOEMHLPLOGA();
		FBONAMCJOBK();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.PLCILPADKCA()) ? 679f : 216f);
		}
	}

	private void FBONAMCJOBK()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = true;
			CEGFMCMPMAD();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1687f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.Loop;
			tweenColor.NumOfRepetitions = 7;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FEBMNDBOBLE));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1647f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(1227f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.HENCANCBCBI(), Time.deltaTime * TimeManager.GetTimeScaledSpeed(778f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1803f;
	}

	private void BLPPFEEMHEP()
	{
		EAKLDFIPDGI();
		FNOMCHPCOHB.ODIJFGCDJNH();
		CCOIEIOFBFL = false;
	}

	[CompilerGenerated]
	private void KACOHEILLFE(UITweener KPICOKPHMIC)
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 0.2f, new Vector3(50f, 50f, 1f));
		tweenScale.method = UITweener.Method.EaseIn;
	}

	private void OGGGIDNOOMJ(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 1044f;
		NHEKOBJPBGE = false;
	}

	protected virtual void OPMNIHDAHAA()
	{
		base.BOEMHLPLOGA();
		GGKHHKJCDDE();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.DGFGECMICOK()) ? 734f : 1578f);
		}
	}

	private void FEBMNDBOBLE(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 264f;
		NHEKOBJPBGE = false;
	}

	protected override void Update()
	{
		base.Update();
		OFNMHNFHAON();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 1f : 0.3f);
		}
	}

	private void FFELNBEACBA()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void OFNMHNFHAON()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = true;
			EJPAJFMPGAB();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 0.2f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.PingPong;
			tweenColor.NumOfRepetitions = 6;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, (UITweener.OnFinished)delegate
			{
				AHIBFODJEEG = 0f;
				NHEKOBJPBGE = false;
			});
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 100f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(8f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.killStreakProgress, Time.deltaTime * TimeManager.GetTimeScaledSpeed(5f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 0.01f;
	}

	private void HEPPIEKMMGC()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1632f, new Vector3(298f, 1586f, 1007f));
		tweenScale.method = UITweener.Method.EaseInOut;
		tweenScale.onFinished = IEBDMPLANKA;
	}

	private void GHLAIHMFADF(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -73)
		{
			CCOIEIOFBFL = false;
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
	}

	private void FBLOANIMAHG(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 1986f;
		NHEKOBJPBGE = true;
	}

	public void Resume()
	{
		AFLBIONHLKM = false;
	}

	private void BDKONKNFMFM(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == -90)
		{
			CCOIEIOFBFL = false;
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
	}

	private void NCNOONBGPBJ()
	{
		HFPEGNPCFAK();
		FNOMCHPCOHB.ODIJFGCDJNH();
		CCOIEIOFBFL = true;
	}

	private void CIGIGJDJJKO()
	{
		HEPPIEKMMGC();
		FNOMCHPCOHB.OKEBGBENAJF();
		CCOIEIOFBFL = true;
	}

	private void CBDPIDOMDDI(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.DMAJACPHCGN();
		CCOIEIOFBFL = true;
	}

	private void LJADCKBCEKI(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.BCFMBKNMNBN();
		CCOIEIOFBFL = true;
	}

	protected virtual void HAMDMFGNIKD()
	{
		base.JMPDHKPOHEA();
		CCPLJMENBOF();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.showed) ? 853f : 630f);
		}
	}

	public virtual void GGOHGHHGLMP()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		JAGPBOLCFBE();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
		Singleton<GameController>.instance.GameEnded += HPGPKKKJHPL;
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
	}

	public virtual void KPHJFKCOIIF()
	{
	}

	public virtual void PLMOAGCCJEB()
	{
		NHEKOBJPBGE = true;
		AHIBFODJEEG = 988f;
		NGEKLKKFEHB.alpha = 1257f;
		LNLIOLLNCHJ.alpha = 1621f;
		CGFJJPPKCDF.alpha = 491f;
		JJBBBIMPNNF.alpha = 1742f;
		FDJELJHIMJC.alpha = 89f;
		HILCPHDHNOK.alpha = 422f;
		LNPPFPMBEGI.alpha = 1942f;
		CLBPACCJKPB.alpha = 1793f;
	}

	public virtual void LNNPGJPEEIP()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		PAOHHEKIDJF();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(GHLAIHMFADF));
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		Singleton<GameController>.instance.GameStarted += FFELNBEACBA;
	}

	protected virtual void BINACLIFPNC()
	{
		base.JMPDHKPOHEA();
		AAJAAABFBCJ();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.IMDEOPABKGK()) ? 949f : 1423f);
		}
	}

	private void FHLOHAEPIFD()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void KHDNLDGIKCA(UITweener MGDJMGHCAAI)
	{
		AHIBFODJEEG = 1165f;
		NHEKOBJPBGE = true;
	}

	private void AAPAHEOJHGO()
	{
		HFPEGNPCFAK();
		FNOMCHPCOHB.AGFMCNDAEEC();
		CCOIEIOFBFL = false;
	}

	public override void InitGUIValues()
	{
		NHEKOBJPBGE = false;
		AHIBFODJEEG = 0f;
		NGEKLKKFEHB.alpha = 0f;
		LNLIOLLNCHJ.alpha = 0f;
		CGFJJPPKCDF.alpha = 0f;
		JJBBBIMPNNF.alpha = 0f;
		FDJELJHIMJC.alpha = 0f;
		HILCPHDHNOK.alpha = 0f;
		LNPPFPMBEGI.alpha = 0f;
		CLBPACCJKPB.alpha = 0f;
	}

	private void HFPEGNPCFAK()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1357f, new Vector3(470f, 967f, 631f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = IEBDMPLANKA;
	}

	public virtual void BEECFBCBLEK()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		MDAMCJELEJI();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(LPFGCCABMKH));
		Singleton<GameController>.instance.GameEnded += BHJAKDONALE;
		Singleton<GameController>.instance.GameStarted += FHLOHAEPIFD;
	}

	private void BJICEFJGIDP()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = false;
			NCNOONBGPBJ();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1932f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.PingPong;
			tweenColor.NumOfRepetitions = 1;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FBLOANIMAHG));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1703f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(1861f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.JCNIABKCHGD(), Time.deltaTime * TimeManager.JIJLKEFLPGM(512f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1982f;
	}

	private void HFPFGHKIJKA()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = true;
			EJPAJFMPGAB();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1296f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)8;
			tweenColor.NumOfRepetitions = 0;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(KHDNLDGIKCA));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 12f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(938f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.HENCANCBCBI(), Time.deltaTime * TimeManager.GDNKNLEDMGG(1209f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1753f;
	}

	public virtual void HDMADLCPGEJ()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		MDAMCJELEJI();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(GHLAIHMFADF));
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		Singleton<GameController>.instance.GameStarted += FFELNBEACBA;
	}

	public void AKDDJMHNOEN()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.ABFBKGCIJBB();
			CCOIEIOFBFL = true;
		}
		AFLBIONHLKM = true;
	}

	private void AAJAAABFBCJ()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = false;
			FAACPHINKGF();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 548f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.Once;
			tweenColor.NumOfRepetitions = 4;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FEBMNDBOBLE));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1592f, Time.deltaTime * TimeManager.GDNKNLEDMGG(1973f, DLMKHPAJKDJ: false));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.FJJPIMGNPHN(), Time.deltaTime * TimeManager.GDNKNLEDMGG(99f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1176f;
	}

	public virtual void LBIJJNEOELO()
	{
	}

	private void ACMPPHPPFOI()
	{
		GEDHDLDEPDG();
		FNOMCHPCOHB.OKEBGBENAJF();
		CCOIEIOFBFL = false;
	}

	public void LDOEDBDDFMP()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.JEEKNFJCAMJ();
			CCOIEIOFBFL = true;
		}
		AFLBIONHLKM = true;
	}

	private void IEBDMPLANKA(UITweener KPICOKPHMIC)
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1893f, new Vector3(424f, 310f, 186f));
		tweenScale.method = UITweener.Method.Linear;
	}

	private void ILPFKFMEGNA()
	{
		OGLEJIPAKLG.x = 1454f + Singleton<GameVariables>.instance.multiplierXfromRatio * 1745f;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		FNOMCHPCOHB.AddTween(-38, TweenAnimator.MNAIKKJDPLK.Color, NGEKLKKFEHB.gameObject, 492f, 1509f, 41f, -1, 941f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 77;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		float pNAPOBMKMLM = PNAPOBMKMLM;
		object iIMDKHJAJGO = GOHJDMLKJBA;
		object oEIICEJPGKI = IODPNJIAEAP;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1185f, -1, oEIICEJPGKI, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = -137;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = HILCPHDHNOK.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = LIIFLPDBEJB;
		iIMDKHJAJGO = LIIFLPDBEJB.AddY(JANBMBMIFDL);
		fNOMCHPCOHB2.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 281f, 43, iIMDKHJAJGO, (UITweener.Method)8);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.TextCounter, LNLIOLLNCHJ.gameObject, GONJIDADNEI, 609f, 68f, -1, 1272f, (UITweener.Method)6, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = PNAPOBMKMLM;
		iIMDKHJAJGO = FJJPEOIMMNH;
		oEIICEJPGKI = OGLEJIPAKLG;
		fNOMCHPCOHB3.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 889f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = EELLEMIFAMO;
		oEIICEJPGKI = new Vector3(286f, 201f, 315f);
		iIMDKHJAJGO = new Vector3(101f, 1888f, 105f);
		fNOMCHPCOHB4.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 774f, -1, iIMDKHJAJGO, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = KFGIBCDINOL;
		iIMDKHJAJGO = CNNCMAPABAO;
		oEIICEJPGKI = CNNCMAPABAO.ReplaceX(1007f);
		fNOMCHPCOHB5.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 674f, 7, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Alpha;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = AIBMDCENBDE;
		oEIICEJPGKI = GFPBCHPOOKC;
		iIMDKHJAJGO = CNNCMAPABAO;
		fNOMCHPCOHB6.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 473f, 2, iIMDKHJAJGO, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(6, TweenAnimator.MNAIKKJDPLK.Scale, LNPPFPMBEGI.gameObject, EIFNCBDHBOG, 64f, 1296f, -1, 358f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNPPFPMBEGI.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		iIMDKHJAJGO = MEMGNJPNFKL;
		oEIICEJPGKI = JBOHPPFBOEI;
		fNOMCHPCOHB7.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 761f, 3, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LNPPFPMBEGI.gameObject, JCHLBFOCMCI, 76f, 58f, 4, 1553f, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Position, CLBPACCJKPB.gameObject, EIFNCBDHBOG, 971f, 241f, -1, 1803f, UITweener.Method.BounceIn);
		TweenAnimator fNOMCHPCOHB8 = FNOMCHPCOHB;
		iNFLHPGMEOB = -4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = CLBPACCJKPB.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		oEIICEJPGKI = MEMGNJPNFKL.ReplaceX(0f - MEMGNJPNFKL.x);
		iIMDKHJAJGO = JBOHPPFBOEI.ReplaceX(0f - JBOHPPFBOEI.x);
		fNOMCHPCOHB8.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1127f, 5, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(94, TweenAnimator.MNAIKKJDPLK.TextCounter, CLBPACCJKPB.gameObject, JCHLBFOCMCI, 499f, 949f, 7, 101f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-67, TweenAnimator.MNAIKKJDPLK.Scale, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 1502f, 261f, 0, 946f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB9 = FNOMCHPCOHB;
		iNFLHPGMEOB = -25;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = IGICDDJJAAE;
		iIMDKHJAJGO = FJJPEOIMMNH.AddY(NDJIPJPDFNI);
		oEIICEJPGKI = FJJPEOIMMNH;
		fNOMCHPCOHB9.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1091f, -38, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB10 = FNOMCHPCOHB;
		iNFLHPGMEOB = 47;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = HNLMEFHHINK;
		oEIICEJPGKI = FJJPEOIMMNH.AddY(DBANEIDNJJF);
		iIMDKHJAJGO = FJJPEOIMMNH;
		fNOMCHPCOHB10.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1889f, -98, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(25, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 1050f, 1558f, 37, 1162f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.BPEKAKFKCIG(-115, TweenAnimator.MNAIKKJDPLK.Position, FDJELJHIMJC.gameObject, CNANCIDDHJI, 71f, 711f, -1, 241f, (UITweener.Method)8);
		FNOMCHPCOHB.NFLKPCIHOPJ(112, TweenAnimator.MNAIKKJDPLK.Color, FDJELJHIMJC.gameObject, BLBIANFHAOF, 1377f, 681f, 37, 1115f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(115, TweenAnimator.MNAIKKJDPLK.Position, FDJELJHIMJC.gameObject, MMEIKOLDJNH, 809f, 1231f, 127, 698f);
		FNOMCHPCOHB.NFLKPCIHOPJ(-104, TweenAnimator.MNAIKKJDPLK.Rotation, FDJELJHIMJC.gameObject, JENAOMBKNBP, 705f, 1944f, 55, 737f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-125, TweenAnimator.MNAIKKJDPLK.Alpha, NGEKLKKFEHB.gameObject, JENAOMBKNBP, 211f, 375f, 12, 1358f, (UITweener.Method)8);
		FNOMCHPCOHB.FEHALDPLGDB(-15, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CGFJJPPKCDF.gameObject, ICDKGNAFJAD, 498f, 886f, -1, 147f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(121, TweenAnimator.MNAIKKJDPLK.Position, JJBBBIMPNNF.gameObject, ICDKGNAFJAD, 340f, 1367f, -1, 1234f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-59, TweenAnimator.MNAIKKJDPLK.Position, HILCPHDHNOK.gameObject, ICDKGNAFJAD, 986f, 782f, -1, 1505f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-100, TweenAnimator.MNAIKKJDPLK.Color, CGFJJPPKCDF.gameObject, KJGHMLDFANG, 1776f, 17f, 96, 1835f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-55, TweenAnimator.MNAIKKJDPLK.Rotation, JJBBBIMPNNF.gameObject, KJGHMLDFANG, 1535f, 105f, 54, 1267f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(96, TweenAnimator.MNAIKKJDPLK.Position, HILCPHDHNOK.gameObject, KJGHMLDFANG, 1799f, 327f, 67, 1119f, (UITweener.Method)8, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB11 = FNOMCHPCOHB;
		iNFLHPGMEOB = 43;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI.AddY(FKGMFDDOPLC);
		fNOMCHPCOHB11.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 350f, 49, oEIICEJPGKI, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB12 = FNOMCHPCOHB;
		iNFLHPGMEOB = -62;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = MAHNNHIJPJI;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		fNOMCHPCOHB12.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 114f, 86, iIMDKHJAJGO, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, PKBFLLLNNGD, 1089f, 967f, -43, 690f, (UITweener.Method)6);
		FNOMCHPCOHB.AddTween(58, TweenAnimator.MNAIKKJDPLK.Position, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1147f, 146f, -24, 1670f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(17, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 29f, 704f, -54, 1851f, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-70, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1797f, 1972f, 27, 414f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(48, TweenAnimator.MNAIKKJDPLK.Rotation, HILCPHDHNOK.gameObject, CELCNBJLMIA, 313f, 1385f, 60, 1841f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(108, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, HILCPHDHNOK.gameObject, CELCNBJLMIA, 72f, 1158f, -40, 1098f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(-32, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1201f, 404f, 42, 1490f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB13 = FNOMCHPCOHB;
		iNFLHPGMEOB = 121;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = CELCNBJLMIA;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI;
		fNOMCHPCOHB13.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 322f, -122, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-79, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, JJBBBIMPNNF.gameObject, CELCNBJLMIA, 342f, 448f, -49, 806f, (UITweener.Method)7);
	}

	private void MHKHHBAJLNK(UITweener KPICOKPHMIC)
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 378f, new Vector3(738f, 1710f, 21f));
		tweenScale.method = UITweener.Method.Linear;
	}

	public virtual void EDFMOCGKHHH()
	{
	}

	private void BKFEFHKLHML(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.FinishTweens();
		CCOIEIOFBFL = false;
	}

	public void HJJNAIHBHML()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.CPKDFIKMKLE();
			CCOIEIOFBFL = false;
		}
		AFLBIONHLKM = true;
	}

	protected virtual void GPLKEOAHFJI()
	{
		base.JMPDHKPOHEA();
		HFPFGHKIJKA();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.DGFGECMICOK()) ? 983f : 1369f);
		}
	}

	private void KKAHLDFBANB()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = false;
			EJPAJFMPGAB();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 449f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)8;
			tweenColor.NumOfRepetitions = 4;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(EEAKIKIIPEP));
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 673f, Time.deltaTime * TimeManager.GetTimeScaledSpeed(743f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.JCNIABKCHGD(), Time.deltaTime * TimeManager.GetTimeScaledSpeed(170f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1756f;
	}

	protected virtual void BPNLIABHCPN()
	{
		base.OGJGIMLMJBF();
		OFNMHNFHAON();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.IMDEOPABKGK()) ? 1505f : 1297f);
		}
	}

	private void JHDBHGCKPDM(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 36)
		{
			CCOIEIOFBFL = false;
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
	}

	private void KNJPNAODMIH()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void HPGPKKKJHPL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.FinishTweens();
		CCOIEIOFBFL = false;
	}

	private void BONJNGIPIGN()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void GGFPFAJNLJP()
	{
		CIMDONHHFAP();
		FNOMCHPCOHB.PlayTweens();
		CCOIEIOFBFL = true;
	}

	public void JPJPMKKJDPO()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.CPKDFIKMKLE();
			CCOIEIOFBFL = false;
		}
		AFLBIONHLKM = true;
	}

	public virtual void MHIFDHGPDCK()
	{
		NHEKOBJPBGE = false;
		AHIBFODJEEG = 803f;
		NGEKLKKFEHB.alpha = 1709f;
		LNLIOLLNCHJ.alpha = 1505f;
		CGFJJPPKCDF.alpha = 209f;
		JJBBBIMPNNF.alpha = 268f;
		FDJELJHIMJC.alpha = 1672f;
		HILCPHDHNOK.alpha = 1467f;
		LNPPFPMBEGI.alpha = 1861f;
		CLBPACCJKPB.alpha = 1196f;
	}

	private void PAOHHEKIDJF()
	{
		OGLEJIPAKLG.x = 1741f + Singleton<GameVariables>.instance.multiplierXfromRatio * 1195f;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		FNOMCHPCOHB.MNEFMODDFFK(37, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, NGEKLKKFEHB.gameObject, 900f, 1101f, 746f, -1, 1042f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = -122;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		GameObject nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		float pNAPOBMKMLM = PNAPOBMKMLM;
		object iIMDKHJAJGO = GOHJDMLKJBA;
		object oEIICEJPGKI = IODPNJIAEAP;
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1733f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 115;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = HILCPHDHNOK.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = LIIFLPDBEJB;
		iIMDKHJAJGO = LIIFLPDBEJB.AddY(JANBMBMIFDL);
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 749f, -106, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LNLIOLLNCHJ.gameObject, GONJIDADNEI, 406f, 1994f, -1, 1586f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = PNAPOBMKMLM;
		iIMDKHJAJGO = FJJPEOIMMNH;
		oEIICEJPGKI = OGLEJIPAKLG;
		fNOMCHPCOHB3.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1224f, -1, oEIICEJPGKI, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = EELLEMIFAMO;
		oEIICEJPGKI = new Vector3(451f, 1369f, 1424f);
		iIMDKHJAJGO = new Vector3(74f, 1220f, 1638f);
		fNOMCHPCOHB4.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1069f, -1, iIMDKHJAJGO, UITweener.Method.BounceOut);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.AlphaTk2d;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = KFGIBCDINOL;
		iIMDKHJAJGO = CNNCMAPABAO;
		oEIICEJPGKI = CNNCMAPABAO.ReplaceX(549f);
		fNOMCHPCOHB5.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1708f, 2, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = AIBMDCENBDE;
		oEIICEJPGKI = GFPBCHPOOKC;
		iIMDKHJAJGO = CNNCMAPABAO;
		fNOMCHPCOHB6.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1568f, 0, iIMDKHJAJGO, (UITweener.Method)8);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Scale, LNPPFPMBEGI.gameObject, EIFNCBDHBOG, 413f, 512f, -1, 715f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNPPFPMBEGI.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		iIMDKHJAJGO = MEMGNJPNFKL;
		oEIICEJPGKI = JBOHPPFBOEI;
		fNOMCHPCOHB7.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1696f, 5, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.TextCounter, LNPPFPMBEGI.gameObject, JCHLBFOCMCI, 1239f, 5f, 6, 1059f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Rotation, CLBPACCJKPB.gameObject, EIFNCBDHBOG, 1119f, 113f, -1, 375f, (UITweener.Method)6);
		TweenAnimator fNOMCHPCOHB8 = FNOMCHPCOHB;
		iNFLHPGMEOB = 73;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = CLBPACCJKPB.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		oEIICEJPGKI = MEMGNJPNFKL.ReplaceX(0f - MEMGNJPNFKL.x);
		iIMDKHJAJGO = JBOHPPFBOEI.ReplaceX(0f - JBOHPPFBOEI.x);
		fNOMCHPCOHB8.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1524f, 1, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(14, TweenAnimator.MNAIKKJDPLK.Color, CLBPACCJKPB.gameObject, JCHLBFOCMCI, 1241f, 543f, 1, 1506f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(86, TweenAnimator.MNAIKKJDPLK.Alpha, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 449f, 6f, 1, 716f);
		TweenAnimator fNOMCHPCOHB9 = FNOMCHPCOHB;
		iNFLHPGMEOB = -33;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = IGICDDJJAAE;
		iIMDKHJAJGO = FJJPEOIMMNH.AddY(NDJIPJPDFNI);
		oEIICEJPGKI = FJJPEOIMMNH;
		fNOMCHPCOHB9.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 400f, 118, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB10 = FNOMCHPCOHB;
		iNFLHPGMEOB = 70;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = HNLMEFHHINK;
		oEIICEJPGKI = FJJPEOIMMNH.AddY(DBANEIDNJJF);
		iIMDKHJAJGO = FJJPEOIMMNH;
		fNOMCHPCOHB10.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 779f, 109, iIMDKHJAJGO, UITweener.Method.EaseIn);
		FNOMCHPCOHB.NFLKPCIHOPJ(23, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 779f, 979f, 6, 606f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-5, TweenAnimator.MNAIKKJDPLK.Rotation, FDJELJHIMJC.gameObject, CNANCIDDHJI, 1125f, 1975f, -1, 1572f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-114, TweenAnimator.MNAIKKJDPLK.Scale, FDJELJHIMJC.gameObject, BLBIANFHAOF, 1536f, 1081f, -3, 401f, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(97, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, MMEIKOLDJNH, 453f, 818f, -87, 548f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-16, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FDJELJHIMJC.gameObject, JENAOMBKNBP, 1144f, 357f, -7, 548f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-21, TweenAnimator.MNAIKKJDPLK.Alpha, NGEKLKKFEHB.gameObject, JENAOMBKNBP, 387f, 808f, 112, 778f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.MNEFMODDFFK(47, TweenAnimator.MNAIKKJDPLK.Color, CGFJJPPKCDF.gameObject, ICDKGNAFJAD, 631f, 816f, -1, 519f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.MNEFMODDFFK(33, TweenAnimator.MNAIKKJDPLK.TextCounter, JJBBBIMPNNF.gameObject, ICDKGNAFJAD, 1976f, 417f, -1, 1742f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(21, TweenAnimator.MNAIKKJDPLK.Color, HILCPHDHNOK.gameObject, ICDKGNAFJAD, 32f, 239f, -1, 291f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Scale, CGFJJPPKCDF.gameObject, KJGHMLDFANG, 1042f, 859f, 31, 397f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(19, TweenAnimator.MNAIKKJDPLK.Color, JJBBBIMPNNF.gameObject, KJGHMLDFANG, 1843f, 334f, 86, 489f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(-63, TweenAnimator.MNAIKKJDPLK.Rotation, HILCPHDHNOK.gameObject, KJGHMLDFANG, 1627f, 343f, -88, 256f, (UITweener.Method)6, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB11 = FNOMCHPCOHB;
		iNFLHPGMEOB = 117;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI.AddY(FKGMFDDOPLC);
		fNOMCHPCOHB11.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 156f, 79, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB12 = FNOMCHPCOHB;
		iNFLHPGMEOB = -123;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = MAHNNHIJPJI;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		fNOMCHPCOHB12.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 567f, -65, iIMDKHJAJGO, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(107, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CGFJJPPKCDF.gameObject, PKBFLLLNNGD, 1351f, 1579f, -30, 416f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(51, TweenAnimator.MNAIKKJDPLK.Rotation, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 748f, 369f, 57, 1474f, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-56, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1784f, 1296f, -102, 939f, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-116, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1996f, 281f, -42, 225f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(120, TweenAnimator.MNAIKKJDPLK.Color, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1880f, 478f, 35, 1104f, UITweener.Method.BounceOut);
		FNOMCHPCOHB.FEHALDPLGDB(-95, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HILCPHDHNOK.gameObject, CELCNBJLMIA, 543f, 1117f, -34, 1584f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(118, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1676f, 366f, -87, 1173f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB13 = FNOMCHPCOHB;
		iNFLHPGMEOB = 103;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = CELCNBJLMIA;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI;
		fNOMCHPCOHB13.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1267f, 69, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(86, TweenAnimator.MNAIKKJDPLK.Scale, JJBBBIMPNNF.gameObject, CELCNBJLMIA, 1696f, 1833f, -97, 1381f, UITweener.Method.EaseOut, UITweener.Style.Loop);
	}

	private void GEDHDLDEPDG()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 170f, new Vector3(1989f, 1182f, 1819f));
		tweenScale.method = UITweener.Method.EaseInOut;
		tweenScale.onFinished = OCGCFLDDEHK;
	}

	private void PBDAPLLNLDA(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 37)
		{
			CCOIEIOFBFL = false;
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
	}

	private void GGKHHKJCDDE()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = true;
			BLPPFEEMHEP();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 179f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)6;
			tweenColor.NumOfRepetitions = 4;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FBLOANIMAHG));
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1876f, Time.deltaTime * TimeManager.GDNKNLEDMGG(1939f, DLMKHPAJKDJ: false));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.HENCANCBCBI(), Time.deltaTime * TimeManager.GDNKNLEDMGG(1210f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 776f;
	}

	private void ENPAJKPFANI()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = false;
			FAACPHINKGF();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1894f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.Once;
			tweenColor.NumOfRepetitions = 7;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, (UITweener.OnFinished)delegate
			{
				AHIBFODJEEG = 0f;
				NHEKOBJPBGE = false;
			});
			JIIIODFEBOO.gameObject.SetActive(value: false);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1164f, Time.deltaTime * TimeManager.JIJLKEFLPGM(271f, DLMKHPAJKDJ: false));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.killStreakProgress, Time.deltaTime * TimeManager.GDNKNLEDMGG(742f, DLMKHPAJKDJ: true));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1224f;
	}

	private void MKLKLIAGCOF()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = true;
			NHEKOBJPBGE = false;
			GGFPFAJNLJP();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 1253f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = (UITweener.Style)8;
			tweenColor.NumOfRepetitions = 5;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(EEAKIKIIPEP));
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1558f, Time.deltaTime * TimeManager.GDNKNLEDMGG(1350f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.JCNIABKCHGD(), Time.deltaTime * TimeManager.JIJLKEFLPGM(711f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 1566f;
	}

	private void BLBGGKEONBC()
	{
		OGLEJIPAKLG.x = 1635f + Singleton<GameVariables>.instance.multiplierXfromRatio * 1093f;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		FNOMCHPCOHB.NFLKPCIHOPJ(-43, TweenAnimator.MNAIKKJDPLK.Position, NGEKLKKFEHB.gameObject, 1157f, 1440f, 1949f, -1, 1227f, UITweener.Method.BounceOut);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 83;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		GameObject nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		float pNAPOBMKMLM = PNAPOBMKMLM;
		object iIMDKHJAJGO = GOHJDMLKJBA;
		object oEIICEJPGKI = IODPNJIAEAP;
		fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1429f, -1, oEIICEJPGKI, (UITweener.Method)7);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 29;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = HILCPHDHNOK.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = LIIFLPDBEJB;
		iIMDKHJAJGO = LIIFLPDBEJB.AddY(JANBMBMIFDL);
		fNOMCHPCOHB2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1227f, -106, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LNLIOLLNCHJ.gameObject, GONJIDADNEI, 1338f, 1710f, -1, 781f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = PNAPOBMKMLM;
		iIMDKHJAJGO = FJJPEOIMMNH;
		oEIICEJPGKI = OGLEJIPAKLG;
		fNOMCHPCOHB3.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 113f, -1, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = EELLEMIFAMO;
		oEIICEJPGKI = new Vector3(1882f, 318f, 1282f);
		iIMDKHJAJGO = new Vector3(1968f, 646f, 51f);
		fNOMCHPCOHB4.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 48f, -1, iIMDKHJAJGO, (UITweener.Method)6, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = KFGIBCDINOL;
		iIMDKHJAJGO = CNNCMAPABAO;
		oEIICEJPGKI = CNNCMAPABAO.ReplaceX(1848f);
		fNOMCHPCOHB5.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 243f, 1, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		iNFLHPGMEOB = 0;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = AIBMDCENBDE;
		oEIICEJPGKI = GFPBCHPOOKC;
		iIMDKHJAJGO = CNNCMAPABAO;
		fNOMCHPCOHB6.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1283f, 8, iIMDKHJAJGO, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(7, TweenAnimator.MNAIKKJDPLK.Position, LNPPFPMBEGI.gameObject, EIFNCBDHBOG, 1584f, 782f, -1, 1600f);
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNPPFPMBEGI.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		iIMDKHJAJGO = MEMGNJPNFKL;
		oEIICEJPGKI = JBOHPPFBOEI;
		fNOMCHPCOHB7.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 640f, 2, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Scale, LNPPFPMBEGI.gameObject, JCHLBFOCMCI, 1658f, 1010f, 5, 1386f, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Alpha, CLBPACCJKPB.gameObject, EIFNCBDHBOG, 572f, 1293f, -1, 957f, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB8 = FNOMCHPCOHB;
		iNFLHPGMEOB = 43;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = CLBPACCJKPB.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		oEIICEJPGKI = MEMGNJPNFKL.ReplaceX(0f - MEMGNJPNFKL.x);
		iIMDKHJAJGO = JBOHPPFBOEI.ReplaceX(0f - JBOHPPFBOEI.x);
		fNOMCHPCOHB8.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 6f, 7, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(-93, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CLBPACCJKPB.gameObject, JCHLBFOCMCI, 1878f, 837f, 4, 1055f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(66, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 711f, 580f, 1, 1001f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB9 = FNOMCHPCOHB;
		iNFLHPGMEOB = 124;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = IGICDDJJAAE;
		iIMDKHJAJGO = FJJPEOIMMNH.AddY(NDJIPJPDFNI);
		oEIICEJPGKI = FJJPEOIMMNH;
		fNOMCHPCOHB9.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 23f, -17, oEIICEJPGKI, UITweener.Method.BounceIn, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB10 = FNOMCHPCOHB;
		iNFLHPGMEOB = -72;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = HNLMEFHHINK;
		oEIICEJPGKI = FJJPEOIMMNH.AddY(DBANEIDNJJF);
		iIMDKHJAJGO = FJJPEOIMMNH;
		fNOMCHPCOHB10.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1636f, 33, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-105, TweenAnimator.MNAIKKJDPLK.Position, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 492f, 613f, -25, 1759f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(-70, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, FDJELJHIMJC.gameObject, CNANCIDDHJI, 517f, 933f, -1, 1862f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(21, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, BLBIANFHAOF, 1939f, 608f, -76, 1543f, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-84, TweenAnimator.MNAIKKJDPLK.Rotation, FDJELJHIMJC.gameObject, MMEIKOLDJNH, 249f, 262f, -16, 422f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-120, TweenAnimator.MNAIKKJDPLK.Color, FDJELJHIMJC.gameObject, JENAOMBKNBP, 1139f, 747f, -83, 1119f, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-95, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, NGEKLKKFEHB.gameObject, JENAOMBKNBP, 1727f, 40f, -38, 1025f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(127, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, ICDKGNAFJAD, 1760f, 831f, -1, 433f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(87, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, JJBBBIMPNNF.gameObject, ICDKGNAFJAD, 1854f, 1339f, -1, 1788f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.MNEFMODDFFK(121, TweenAnimator.MNAIKKJDPLK.Rotation, HILCPHDHNOK.gameObject, ICDKGNAFJAD, 1634f, 456f, -1, 218f, UITweener.Method.EaseOut, UITweener.Style.Loop);
		FNOMCHPCOHB.AddTween(70, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CGFJJPPKCDF.gameObject, KJGHMLDFANG, 1972f, 905f, 116, 1805f, (UITweener.Method)6, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(-23, TweenAnimator.MNAIKKJDPLK.TextCounter, JJBBBIMPNNF.gameObject, KJGHMLDFANG, 720f, 326f, 9, 1928f, (UITweener.Method)6, UITweener.Style.Once, 0);
		FNOMCHPCOHB.MNEFMODDFFK(62, TweenAnimator.MNAIKKJDPLK.Rotation, HILCPHDHNOK.gameObject, KJGHMLDFANG, 1313f, 1435f, -50, 899f, UITweener.Method.Linear, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB11 = FNOMCHPCOHB;
		iNFLHPGMEOB = -113;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI.AddY(FKGMFDDOPLC);
		fNOMCHPCOHB11.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1151f, 28, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB12 = FNOMCHPCOHB;
		iNFLHPGMEOB = 48;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = MAHNNHIJPJI;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		fNOMCHPCOHB12.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 172f, 85, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(96, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, CGFJJPPKCDF.gameObject, PKBFLLLNNGD, 1435f, 1671f, 53, 983f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.MNEFMODDFFK(92, TweenAnimator.MNAIKKJDPLK.Position, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1267f, 499f, -70, 837f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-103, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1839f, 230f, 6, 25f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(51, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 558f, 1754f, -125, 38f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-114, TweenAnimator.MNAIKKJDPLK.Rotation, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1340f, 912f, 89, 590f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-67, TweenAnimator.MNAIKKJDPLK.TextCounter, HILCPHDHNOK.gameObject, CELCNBJLMIA, 911f, 1673f, -20, 1280f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1815f, 802f, -70, 1246f, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB13 = FNOMCHPCOHB;
		iNFLHPGMEOB = -60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = CELCNBJLMIA;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI;
		fNOMCHPCOHB13.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1508f, -118, oEIICEJPGKI, UITweener.Method.BounceIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(96, TweenAnimator.MNAIKKJDPLK.Position, JJBBBIMPNNF.gameObject, CELCNBJLMIA, 1856f, 1350f, -83, 1579f, (UITweener.Method)7, UITweener.Style.Loop, 0);
	}

	private void LPFGCCABMKH(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 109)
		{
			CCOIEIOFBFL = false;
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
	}

	private void EJPAJFMPGAB()
	{
		CIMDONHHFAP();
		FNOMCHPCOHB.PlayTweens();
		CCOIEIOFBFL = true;
	}

	private void FJNKCKDKNJH()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 718f, new Vector3(611f, 1122f, 1106f));
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(OCFDCEJBECP.gameObject, 0.2f, new Vector3(50f, 50f, 1f));
			tweenScale2.method = UITweener.Method.EaseIn;
		};
	}

	public void JIOGHDFBILD()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.BCFMBKNMNBN();
			CCOIEIOFBFL = true;
		}
		AFLBIONHLKM = false;
	}

	private void JAGPBOLCFBE()
	{
		OGLEJIPAKLG.x = -1026f + Singleton<GameVariables>.instance.multiplierXfromRatio * 211f;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		FNOMCHPCOHB.AddTween(1000, TweenAnimator.MNAIKKJDPLK.Alpha, NGEKLKKFEHB.gameObject, 0f, 1f, 0f, -1, 1f);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 1001;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		float pNAPOBMKMLM = PNAPOBMKMLM;
		object iIMDKHJAJGO = GOHJDMLKJBA;
		object oEIICEJPGKI = IODPNJIAEAP;
		fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1002;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = HILCPHDHNOK.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = LIIFLPDBEJB;
		iIMDKHJAJGO = LIIFLPDBEJB.AddY(JANBMBMIFDL);
		fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, 20, iIMDKHJAJGO);
		FNOMCHPCOHB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Alpha, LNLIOLLNCHJ.gameObject, GONJIDADNEI, 1f, 0f, -1, 0f, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = PNAPOBMKMLM;
		iIMDKHJAJGO = FJJPEOIMMNH;
		oEIICEJPGKI = OGLEJIPAKLG;
		fNOMCHPCOHB3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseOut);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = EELLEMIFAMO;
		oEIICEJPGKI = new Vector3(0f, 0f, 1f);
		iIMDKHJAJGO = new Vector3(0f, 0f, 1f);
		fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 3;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = KFGIBCDINOL;
		iIMDKHJAJGO = CNNCMAPABAO;
		oEIICEJPGKI = CNNCMAPABAO.ReplaceX(0f);
		fNOMCHPCOHB5.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, 2, oEIICEJPGKI);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = AIBMDCENBDE;
		oEIICEJPGKI = GFPBCHPOOKC;
		iIMDKHJAJGO = CNNCMAPABAO;
		fNOMCHPCOHB6.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, 3, iIMDKHJAJGO);
		FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Alpha, LNPPFPMBEGI.gameObject, EIFNCBDHBOG, 0f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNPPFPMBEGI.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		iIMDKHJAJGO = MEMGNJPNFKL;
		oEIICEJPGKI = JBOHPPFBOEI;
		fNOMCHPCOHB7.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, 5, oEIICEJPGKI, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Alpha, LNPPFPMBEGI.gameObject, JCHLBFOCMCI, 0f, 0f, 5, 1f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Alpha, CLBPACCJKPB.gameObject, EIFNCBDHBOG, 0f, 0f, -1, 0f);
		TweenAnimator fNOMCHPCOHB8 = FNOMCHPCOHB;
		iNFLHPGMEOB = 9;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = CLBPACCJKPB.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		oEIICEJPGKI = MEMGNJPNFKL.ReplaceX(0f - MEMGNJPNFKL.x);
		iIMDKHJAJGO = JBOHPPFBOEI.ReplaceX(0f - JBOHPPFBOEI.x);
		fNOMCHPCOHB8.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, 8, iIMDKHJAJGO, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(10, TweenAnimator.MNAIKKJDPLK.Alpha, CLBPACCJKPB.gameObject, JCHLBFOCMCI, 0f, 0f, 8, 1f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.AddTween(11, TweenAnimator.MNAIKKJDPLK.Alpha, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 1f, 0f, 1, 1f);
		TweenAnimator fNOMCHPCOHB9 = FNOMCHPCOHB;
		iNFLHPGMEOB = 12;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = IGICDDJJAAE;
		iIMDKHJAJGO = FJJPEOIMMNH.AddY(NDJIPJPDFNI);
		oEIICEJPGKI = FJJPEOIMMNH;
		fNOMCHPCOHB9.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, 11, oEIICEJPGKI);
		TweenAnimator fNOMCHPCOHB10 = FNOMCHPCOHB;
		iNFLHPGMEOB = 13;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = HNLMEFHHINK;
		oEIICEJPGKI = FJJPEOIMMNH.AddY(DBANEIDNJJF);
		iIMDKHJAJGO = FJJPEOIMMNH;
		fNOMCHPCOHB10.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, 12, iIMDKHJAJGO);
		FNOMCHPCOHB.AddTween(14, TweenAnimator.MNAIKKJDPLK.Alpha, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 0f, 0f, 12, 1f);
		FNOMCHPCOHB.AddTween(15, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, CNANCIDDHJI, 0f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(16, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, BLBIANFHAOF, 1f, 0f, 15, 0f);
		FNOMCHPCOHB.AddTween(17, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, MMEIKOLDJNH, 1f, 0f, 16, 1f);
		FNOMCHPCOHB.AddTween(18, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, JENAOMBKNBP, 0f, 0f, 17, 1f);
		FNOMCHPCOHB.AddTween(19, TweenAnimator.MNAIKKJDPLK.Alpha, NGEKLKKFEHB.gameObject, JENAOMBKNBP, 0f, 0f, 17, 1f);
		FNOMCHPCOHB.AddTween(20, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, ICDKGNAFJAD, 0f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(21, TweenAnimator.MNAIKKJDPLK.Alpha, JJBBBIMPNNF.gameObject, ICDKGNAFJAD, 0f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(22, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, ICDKGNAFJAD, 0f, 0f, -1, 0f);
		FNOMCHPCOHB.AddTween(23, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, KJGHMLDFANG, 0.75f, 0f, 20, 0f);
		FNOMCHPCOHB.AddTween(24, TweenAnimator.MNAIKKJDPLK.Alpha, JJBBBIMPNNF.gameObject, KJGHMLDFANG, 1f, 0f, 20, 0f);
		FNOMCHPCOHB.AddTween(25, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, KJGHMLDFANG, 1f, 0f, 20, 0f);
		TweenAnimator fNOMCHPCOHB11 = FNOMCHPCOHB;
		iNFLHPGMEOB = 26;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI.AddY(FKGMFDDOPLC);
		fNOMCHPCOHB11.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, 20, oEIICEJPGKI);
		TweenAnimator fNOMCHPCOHB12 = FNOMCHPCOHB;
		iNFLHPGMEOB = 27;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = MAHNNHIJPJI;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		fNOMCHPCOHB12.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 0f, 26, iIMDKHJAJGO);
		FNOMCHPCOHB.AddTween(28, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, PKBFLLLNNGD, 0.75f, 0f, 20, 0.75f);
		FNOMCHPCOHB.AddTween(29, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 0f, 0f, 28, 0.75f);
		FNOMCHPCOHB.AddTween(30, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 0.75f, 0f, 29, 0f);
		FNOMCHPCOHB.AddTween(31, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 0f, 0f, 30, 0.75f);
		FNOMCHPCOHB.AddTween(32, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, CELCNBJLMIA, 0f, 0f, 28, 1f);
		FNOMCHPCOHB.AddTween(33, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1f, 0f, 32, 0f);
		FNOMCHPCOHB.AddTween(34, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, CELCNBJLMIA, 0f, 0f, 33, 1f);
		TweenAnimator fNOMCHPCOHB13 = FNOMCHPCOHB;
		iNFLHPGMEOB = 35;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = CELCNBJLMIA;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI;
		fNOMCHPCOHB13.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 0f, 31, oEIICEJPGKI);
		FNOMCHPCOHB.AddTween(36, TweenAnimator.MNAIKKJDPLK.Alpha, JJBBBIMPNNF.gameObject, CELCNBJLMIA, 0f, 0f, 31, 1f);
	}

	private void CIMDONHHFAP()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 0.1f, new Vector3(70f, 70f, 1f));
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(OCFDCEJBECP.gameObject, 0.2f, new Vector3(50f, 50f, 1f));
			tweenScale2.method = UITweener.Method.EaseIn;
		};
	}

	public void Stop()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.FinishTweens();
			CCOIEIOFBFL = false;
		}
		AFLBIONHLKM = true;
	}

	public override void InitEvents()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		JAGPBOLCFBE();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
	}

	public void ABBLPFHILBP()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.NDGCGHLLPMC();
			CCOIEIOFBFL = true;
		}
		AFLBIONHLKM = false;
	}

	public void DCFCBIMCFHB()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.DMAJACPHCGN();
			CCOIEIOFBFL = false;
		}
		AFLBIONHLKM = true;
	}

	public void GEIIFJNNGDD()
	{
		AFLBIONHLKM = false;
	}

	private void MDAMCJELEJI()
	{
		OGLEJIPAKLG.x = 1373f + Singleton<GameVariables>.instance.multiplierXfromRatio * 439f;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		FNOMCHPCOHB.NFLKPCIHOPJ(-46, TweenAnimator.MNAIKKJDPLK.Rotation, NGEKLKKFEHB.gameObject, 1816f, 1270f, 1567f, -1, 1696f, UITweener.Method.Linear);
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		int iNFLHPGMEOB = 32;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		GameObject nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		float pNAPOBMKMLM = PNAPOBMKMLM;
		object iIMDKHJAJGO = GOHJDMLKJBA;
		object oEIICEJPGKI = IODPNJIAEAP;
		fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 421f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
		iNFLHPGMEOB = -53;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = HILCPHDHNOK.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = LIIFLPDBEJB;
		iIMDKHJAJGO = LIIFLPDBEJB.AddY(JANBMBMIFDL);
		fNOMCHPCOHB2.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 197f, -115, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Position, LNLIOLLNCHJ.gameObject, GONJIDADNEI, 932f, 1829f, -1, 1315f, UITweener.Method.Linear, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
		iNFLHPGMEOB = 1;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = PNAPOBMKMLM;
		iIMDKHJAJGO = FJJPEOIMMNH;
		oEIICEJPGKI = OGLEJIPAKLG;
		fNOMCHPCOHB3.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 279f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = EELLEMIFAMO;
		oEIICEJPGKI = new Vector3(138f, 1057f, 1289f);
		iIMDKHJAJGO = new Vector3(1113f, 1168f, 1944f);
		fNOMCHPCOHB4.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1977f, -1, iIMDKHJAJGO, UITweener.Method.EaseInOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = KFGIBCDINOL;
		iIMDKHJAJGO = CNNCMAPABAO;
		oEIICEJPGKI = CNNCMAPABAO.ReplaceX(421f);
		fNOMCHPCOHB5.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1135f, 1, oEIICEJPGKI, (UITweener.Method)8, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounterSpecial;
		nIHOBEAHEKJ = NGEKLKKFEHB.gameObject;
		pNAPOBMKMLM = AIBMDCENBDE;
		oEIICEJPGKI = GFPBCHPOOKC;
		iIMDKHJAJGO = CNNCMAPABAO;
		fNOMCHPCOHB6.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1734f, 5, iIMDKHJAJGO, UITweener.Method.BounceOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, LNPPFPMBEGI.gameObject, EIFNCBDHBOG, 1154f, 1252f, -1, 1627f, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		iNFLHPGMEOB = 8;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNPPFPMBEGI.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		iIMDKHJAJGO = MEMGNJPNFKL;
		oEIICEJPGKI = JBOHPPFBOEI;
		fNOMCHPCOHB7.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 767f, 6, oEIICEJPGKI, UITweener.Method.EaseInOut, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Color, LNPPFPMBEGI.gameObject, JCHLBFOCMCI, 1855f, 1504f, 1, 216f, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(8, TweenAnimator.MNAIKKJDPLK.Position, CLBPACCJKPB.gameObject, EIFNCBDHBOG, 381f, 1115f, -1, 856f, (UITweener.Method)7, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB8 = FNOMCHPCOHB;
		iNFLHPGMEOB = 50;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = CLBPACCJKPB.gameObject;
		pNAPOBMKMLM = JCHLBFOCMCI;
		oEIICEJPGKI = MEMGNJPNFKL.ReplaceX(0f - MEMGNJPNFKL.x);
		iIMDKHJAJGO = JBOHPPFBOEI.ReplaceX(0f - JBOHPPFBOEI.x);
		fNOMCHPCOHB8.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 400f, 1, iIMDKHJAJGO, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.NFLKPCIHOPJ(-15, TweenAnimator.MNAIKKJDPLK.Scale, CLBPACCJKPB.gameObject, JCHLBFOCMCI, 1479f, 917f, 3, 116f, (UITweener.Method)7, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(-104, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 1353f, 84f, 0, 1625f, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		TweenAnimator fNOMCHPCOHB9 = FNOMCHPCOHB;
		iNFLHPGMEOB = -75;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = IGICDDJJAAE;
		iIMDKHJAJGO = FJJPEOIMMNH.AddY(NDJIPJPDFNI);
		oEIICEJPGKI = FJJPEOIMMNH;
		fNOMCHPCOHB9.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1213f, 117, oEIICEJPGKI, UITweener.Method.BounceIn);
		TweenAnimator fNOMCHPCOHB10 = FNOMCHPCOHB;
		iNFLHPGMEOB = 37;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = LNLIOLLNCHJ.gameObject;
		pNAPOBMKMLM = HNLMEFHHINK;
		oEIICEJPGKI = FJJPEOIMMNH.AddY(DBANEIDNJJF);
		iIMDKHJAJGO = FJJPEOIMMNH;
		fNOMCHPCOHB10.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 613f, -127, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
		FNOMCHPCOHB.FEHALDPLGDB(9, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, LNLIOLLNCHJ.gameObject, NPOEJHKCCLO, 1825f, 1010f, -112, 1893f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		FNOMCHPCOHB.BPEKAKFKCIG(84, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, FDJELJHIMJC.gameObject, CNANCIDDHJI, 262f, 1643f, -1, 1814f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.AddTween(56, TweenAnimator.MNAIKKJDPLK.Alpha, FDJELJHIMJC.gameObject, BLBIANFHAOF, 1800f, 1187f, -57, 1397f);
		FNOMCHPCOHB.FEHALDPLGDB(11, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, FDJELJHIMJC.gameObject, MMEIKOLDJNH, 1984f, 1766f, -49, 1675f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.MNEFMODDFFK(105, TweenAnimator.MNAIKKJDPLK.Color, FDJELJHIMJC.gameObject, JENAOMBKNBP, 1810f, 130f, -115, 75f, UITweener.Method.BounceIn, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-36, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, NGEKLKKFEHB.gameObject, JENAOMBKNBP, 1206f, 204f, 35, 1474f, (UITweener.Method)6);
		FNOMCHPCOHB.MNEFMODDFFK(-27, TweenAnimator.MNAIKKJDPLK.TextCounter, CGFJJPPKCDF.gameObject, ICDKGNAFJAD, 1398f, 1260f, -1, 1808f, (UITweener.Method)7);
		FNOMCHPCOHB.MNEFMODDFFK(-52, TweenAnimator.MNAIKKJDPLK.TextCounterSpecial, JJBBBIMPNNF.gameObject, ICDKGNAFJAD, 1677f, 1585f, -1, 983f, UITweener.Method.EaseOut);
		FNOMCHPCOHB.NFLKPCIHOPJ(124, TweenAnimator.MNAIKKJDPLK.Color, HILCPHDHNOK.gameObject, ICDKGNAFJAD, 192f, 164f, -1, 1637f, UITweener.Method.EaseIn);
		FNOMCHPCOHB.FEHALDPLGDB(-51, TweenAnimator.MNAIKKJDPLK.Alpha, CGFJJPPKCDF.gameObject, KJGHMLDFANG, 615f, 553f, 36, 142f, (UITweener.Method)7, UITweener.Style.Once, 0);
		FNOMCHPCOHB.AddTween(105, TweenAnimator.MNAIKKJDPLK.Color, JJBBBIMPNNF.gameObject, KJGHMLDFANG, 432f, 409f, 38, 481f);
		FNOMCHPCOHB.FEHALDPLGDB(112, TweenAnimator.MNAIKKJDPLK.Color, HILCPHDHNOK.gameObject, KJGHMLDFANG, 103f, 1132f, 100, 1026f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		TweenAnimator fNOMCHPCOHB11 = FNOMCHPCOHB;
		iNFLHPGMEOB = -11;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI.AddY(FKGMFDDOPLC);
		fNOMCHPCOHB11.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 106f, 56, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB12 = FNOMCHPCOHB;
		iNFLHPGMEOB = -60;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = KJGHMLDFANG;
		oEIICEJPGKI = MAHNNHIJPJI;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		fNOMCHPCOHB12.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, oEIICEJPGKI, 1208f, 1, iIMDKHJAJGO, UITweener.Method.EaseInOut, UITweener.Style.Loop);
		FNOMCHPCOHB.MNEFMODDFFK(-96, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, CGFJJPPKCDF.gameObject, PKBFLLLNNGD, 170f, 419f, 12, 1300f, UITweener.Method.BounceIn);
		FNOMCHPCOHB.BPEKAKFKCIG(64, TweenAnimator.MNAIKKJDPLK.Color, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 41f, 831f, 127, 395f, (UITweener.Method)8, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(116, TweenAnimator.MNAIKKJDPLK.Scale, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 664f, 1885f, -109, 135f, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
		FNOMCHPCOHB.BPEKAKFKCIG(-16, TweenAnimator.MNAIKKJDPLK.TextCounter, CGFJJPPKCDF.gameObject, CELCNBJLMIA, 1420f, 1215f, 43, 570f, UITweener.Method.BounceOut, UITweener.Style.Loop);
		FNOMCHPCOHB.FEHALDPLGDB(-6, TweenAnimator.MNAIKKJDPLK.Scale, HILCPHDHNOK.gameObject, CELCNBJLMIA, 208f, 1002f, 79, 899f, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-87, TweenAnimator.MNAIKKJDPLK.Alpha, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1436f, 60f, -46, 969f, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.NFLKPCIHOPJ(-68, TweenAnimator.MNAIKKJDPLK.Scale, HILCPHDHNOK.gameObject, CELCNBJLMIA, 1131f, 860f, 4, 7f, UITweener.Method.EaseIn, UITweener.Style.Loop);
		TweenAnimator fNOMCHPCOHB13 = FNOMCHPCOHB;
		iNFLHPGMEOB = -89;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
		nIHOBEAHEKJ = JJBBBIMPNNF.gameObject;
		pNAPOBMKMLM = CELCNBJLMIA;
		iIMDKHJAJGO = MAHNNHIJPJI.AddY(FIDGBEEMHLF);
		oEIICEJPGKI = MAHNNHIJPJI;
		fNOMCHPCOHB13.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, pNAPOBMKMLM, iIMDKHJAJGO, 1816f, 91, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
		FNOMCHPCOHB.MNEFMODDFFK(-53, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, JJBBBIMPNNF.gameObject, CELCNBJLMIA, 1961f, 1263f, 123, 534f, UITweener.Method.EaseOut, UITweener.Style.Loop);
	}

	private void CCPLJMENBOF()
	{
		if (Singleton<ScoreManager>.instance.KFPGCFFPIJK && !AFLBIONHLKM)
		{
			Singleton<ScoreManager>.instance.KFPGCFFPIJK = false;
			NHEKOBJPBGE = true;
			GGFPFAJNLJP();
			TweenColor tweenColor = TweenColor.Begin(AHBJADFFMFN.gameObject, 949f, POHKAGIICGO, GDNFBKCMPDD);
			tweenColor.style = UITweener.Style.Loop;
			tweenColor.NumOfRepetitions = 3;
			tweenColor.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenColor.onFinished, new UITweener.OnFinished(FBLOANIMAHG));
			JIIIODFEBOO.gameObject.SetActive(value: true);
		}
		if (NHEKOBJPBGE)
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, 1509f, Time.deltaTime * TimeManager.JIJLKEFLPGM(912f, DLMKHPAJKDJ: true));
		}
		else
		{
			AHIBFODJEEG = Mathf.Lerp(AHIBFODJEEG, Singleton<ScoreManager>.instance.JCNIABKCHGD(), Time.deltaTime * TimeManager.JIJLKEFLPGM(1422f, DLMKHPAJKDJ: false));
		}
		AHBJADFFMFN.fillAmount = AHIBFODJEEG * 749f;
	}

	private void FAACPHINKGF()
	{
		FJNKCKDKNJH();
		FNOMCHPCOHB.OKEBGBENAJF();
		CCOIEIOFBFL = true;
	}

	protected virtual void CJPFLJAAODD()
	{
		base.JMPDHKPOHEA();
		HFPFGHKIJKA();
		if (CCOIEIOFBFL)
		{
			JIIIODFEBOO.alpha1 = ((!Singleton<SniperScope>.instance.FPBJEDIJNFK()) ? 841f : 1864f);
		}
	}

	private void DNIDHNBDLNK()
	{
		GMBGALPLCHC.SetActive(Singleton<GameController>.instance.mainController.dropCreates);
	}

	private void CELOMKPICAN(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.FinishTweens();
		CCOIEIOFBFL = false;
	}

	private void MLIANAHDABK(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.NDGCGHLLPMC();
		CCOIEIOFBFL = false;
	}

	private void BHJAKDONALE(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.BCFMBKNMNBN();
		CCOIEIOFBFL = false;
	}

	public virtual void ODBBMGLGEKH()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		JAGPBOLCFBE();
		TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
		fNOMCHPCOHB.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
		Singleton<GameController>.instance.CNPGMMPAGIE(CELOMKPICAN);
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
	}

	private void NMNLICNHFLL()
	{
		HEPPIEKMMGC();
		FNOMCHPCOHB.PlayTweens();
		CCOIEIOFBFL = false;
	}

	public void LAOJPALPHMI()
	{
		if (CCOIEIOFBFL)
		{
			FNOMCHPCOHB.CPKDFIKMKLE();
			CCOIEIOFBFL = true;
		}
		AFLBIONHLKM = true;
	}

	public override void InitControls()
	{
	}

	private void JNINMCLPINC()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 1546f, new Vector3(225f, 243f, 1472f));
		tweenScale.method = UITweener.Method.BounceOut;
		tweenScale.onFinished = OCGCFLDDEHK;
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		FNOMCHPCOHB.FinishTweens();
		CCOIEIOFBFL = false;
	}

	private void NFIHEHEOEOE()
	{
		TweenScale tweenScale = TweenScale.Begin(OCFDCEJBECP.gameObject, 422f, new Vector3(1242f, 57f, 998f));
		tweenScale.method = UITweener.Method.EaseOut;
		tweenScale.onFinished = OCGCFLDDEHK;
	}
}
