using System;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

public class TimeAndProgressHudGuiElement : GuiElementSingle<TimeAndProgressHudGuiElement>
{
	[Header("TOP - Time")]
	[FormerlySerializedAs("KDNFDFNBJHI")]
	public GameObject OOJLGEIEFHM;

	[FormerlySerializedAs("ICCCFNFMIOC")]
	public UILabel GAJKKHFAOMM;

	[FormerlySerializedAs("GLAPBKIFKDD")]
	public UILabel PHKEBILIJBD;

	[FormerlySerializedAs("JCJAABIIOHH")]
	public UISprite AJDLNDFJENC;

	[Header("TOP RIGHT - Mission")]
	[FormerlySerializedAs("DOHENBLJFPK")]
	public GameObject NLEJNKICBCH;

	[FormerlySerializedAs("NANMGKCADIE")]
	[Header("- Mission Progress")]
	public UISprite BLKOBKDDPFD;

	[FormerlySerializedAs("PFODDBIMAOG")]
	public UISprite GFNBDFGKGLO;

	[FormerlySerializedAs("BBDCJIKDHAP")]
	public UISprite HAFGLGNMHKJ;

	[FormerlySerializedAs("CNHMIMJKDID")]
	public UILabel CBGPMHNDJFN;

	[Header("- Mission Time")]
	[FormerlySerializedAs("GEHLFOAJNDP")]
	public GameObject PMELPPOODNN;

	[FormerlySerializedAs("IFBLGENAMHK")]
	public UISprite GJPDBPHHGPI;

	[FormerlySerializedAs("EJIFBKBLCLH")]
	public UISprite FMCNMIJFEAE;

	[FormerlySerializedAs("NCAKGMGGMBI")]
	public UILabel KOFPHHPBOLI;

	[FormerlySerializedAs("NMCKEGMNNLE")]
	[Header("- Mission Waves")]
	public UIPanel PLBKANEHCED;

	[FormerlySerializedAs("GDHPMPDKFFF")]
	public GameObject[] IHBEOPKLBDI;

	[FormerlySerializedAs("LMLPEMJFHGH")]
	public UISprite[] JHIBKIBGGNN;

	[FormerlySerializedAs("NHIEOHDHBEM")]
	public UILabel[] HCDPHCDKFOO;

	[Header("- Mission Boss")]
	[FormerlySerializedAs("ODIDNBKDPIM")]
	public GameObject BPLMBLJHKAJ;

	[FormerlySerializedAs("KBNADBPKJIK")]
	public UISprite IEJDHJGPIPC;

	[FormerlySerializedAs("KCIDEGJIIIO")]
	public UISprite CPPOLKGIOOC;

	[Header("TOP RIGHT - Bootcamp")]
	[FormerlySerializedAs("PIELEFKHFAC")]
	public GameObject HCBNBFKKIJG;

	[FormerlySerializedAs("FEIHEBGHHLA")]
	public UILabel CDMGFGEBFFJ;

	private bool BLNGIEJFHLF;

	private bool LGCGIAFOJDI;

	private int FEBGFEGPIFF = 5;

	private StringBuilder IOFAKGOJDNI = new StringBuilder(8);

	private BOPAGEMBFGD FAKANJDDAOM;

	private float PHBPDHBMNIF;

	public void DOLACCKONKO(float KIPLNBEFPGN)
	{
		if (!Mathf.Approximately(KIPLNBEFPGN, PHBPDHBMNIF))
		{
			float fillAmount = GFNBDFGKGLO.fillAmount;
			PHBPDHBMNIF = KIPLNBEFPGN;
			TweenProgressBar.NNJONILFKMD(GFNBDFGKGLO.gameObject, 73f, new NHOGNBCNIEK(fillAmount), new NHOGNBCNIEK(KIPLNBEFPGN));
		}
	}

	private void LKAEJFOOPMB()
	{
		LGCGIAFOJDI = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 1609f, 1563f, 1481f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 1814f, 279f, 1511f);
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	public virtual void BAAOGDMJCLK()
	{
	}

	public void AnimateRedProgress(float KIPLNBEFPGN)
	{
		if (!Mathf.Approximately(KIPLNBEFPGN, PHBPDHBMNIF))
		{
			float fillAmount = GFNBDFGKGLO.fillAmount;
			PHBPDHBMNIF = KIPLNBEFPGN;
			TweenProgressBar.Begin(GFNBDFGKGLO.gameObject, 0.2f, new NHOGNBCNIEK(fillAmount), new NHOGNBCNIEK(KIPLNBEFPGN));
		}
	}

	private void LDOFPCLKFIC()
	{
		GEKIMGFKNHC();
		DCIHNOPCKCD();
		KJBCKCALHBE();
		HCBNBFKKIJG.SetActive(Singleton<GameController>.instance.isTutorial);
		if (Singleton<GameController>.instance.isTutorial)
		{
			CDMGFGEBFFJ.transform.localPosition = CDMGFGEBFFJ.transform.localPosition.ReplaceX(0f - UIHelper.safeAreaSize);
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				CDMGFGEBFFJ.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 1, 3);
			}
			else if (Singleton<GameController>.instance.isTutorialStage2)
			{
				CDMGFGEBFFJ.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 2, 3);
			}
			else if (Singleton<GameController>.instance.isTutorialStage3)
			{
				CDMGFGEBFFJ.text = Localization.LocalizeFormat("ID_TUTORIAL_PHASE", 3, 3);
			}
		}
		GAJKKHFAOMM.text = string.Empty;
		FEBGFEGPIFF = 5;
		if (Singleton<GameController>.instance.isMission)
		{
			DailyMission currentMission = DailyMissionsManager.instance.currentMission;
			FAKANJDDAOM = currentMission.GetGUIController();
			FAKANJDDAOM.BFENONOEFBF();
		}
	}

	private void PLGLEIHDBON()
	{
		LGCGIAFOJDI = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 243f, 343f, 764f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 1;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 1316f, 1342f, 1144f);
		tweenAlpha2.style = UITweener.Style.Loop;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	public override void InitControls()
	{
		float num = (UIHelper.activeWidthFull / 2f - 140f) / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
		float num2 = num - 12f;
		float num3 = num - 64f + 7f;
		float num4 = num3 - 24f;
		BLKOBKDDPFD.transform.localScale = BLKOBKDDPFD.transform.localScale.ReplaceX(num);
		GFNBDFGKGLO.transform.localScale = GFNBDFGKGLO.transform.localScale.ReplaceX(num2);
		GFNBDFGKGLO.mFillSlopePixels = 470f / num2;
		GFNBDFGKGLO.fillAmount = 0f;
		HAFGLGNMHKJ.transform.localScale = HAFGLGNMHKJ.transform.localScale.ReplaceX(num2);
		HAFGLGNMHKJ.mFillSlopePixels = 540f / num2;
		HAFGLGNMHKJ.fillAmount = 0f;
		CBGPMHNDJFN.transform.localPosition = CBGPMHNDJFN.transform.localPosition.ReplaceX(-0.5f * num);
		GJPDBPHHGPI.transform.localScale = GJPDBPHHGPI.transform.localScale.ReplaceX(num3);
		FMCNMIJFEAE.transform.localScale = FMCNMIJFEAE.transform.localScale.ReplaceX(num4);
		FMCNMIJFEAE.mFillSlopePixels = 240f / num4;
		FMCNMIJFEAE.fillAmount = 0f;
		KOFPHHPBOLI.transform.localPosition = KOFPHHPBOLI.transform.localPosition.ReplaceX(-0.5f * num);
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
		Singleton<GameController>.instance.GameEnded += GOCFEOEJFMA;
		Singleton<MatchManager>.instance.OverTimeStarted += HNGKNPEOMHA;
		BILIFMOOBOM();
	}

	private void JEDOMLJCFPP()
	{
		if (!LGCGIAFOJDI)
		{
			LGCGIAFOJDI = true;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 0.5f, 0f, 0.8f);
			tweenAlpha.style = UITweener.Style.PingPong;
			tweenAlpha.NumOfRepetitions = 0;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 0f, 0f, 1f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void HNDGGHFPGOP()
	{
		LGCGIAFOJDI = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 1840f, 1992f, 1121f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 1;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 765f, 1886f, 805f);
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	public void ODDDHDKMJEE(float PAENPHMEMGC)
	{
		FMCNMIJFEAE.fillAmount = PAENPHMEMGC;
	}

	public void SetWaves(int AGECNIAPGGE)
	{
		for (int i = 0; i < 3; i++)
		{
			int num = i + 1;
			UISprite uISprite = JHIBKIBGGNN[i];
			TweenAlpha component = uISprite.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			component = HCDPHCDKFOO[i].GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			uISprite.alpha = ((num <= AGECNIAPGGE) ? 1f : 0.5f);
			HCDPHCDKFOO[i].alpha = ((num <= AGECNIAPGGE) ? 1f : 0.5f);
			uISprite.spriteName = ((num >= AGECNIAPGGE) ? "game-missions-red-mission-ico" : "game-missions-blue-mission-ico");
			float val = ONJCBFJGFIO(num, AGECNIAPGGE);
			GameObject gameObject = IHBEOPKLBDI[i];
			TweenPosition component2 = gameObject.GetComponent<TweenPosition>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			gameObject.transform.localPosition = gameObject.transform.localPosition.ReplaceX(val);
		}
	}

	protected virtual void JMHFNCOODKH()
	{
		if (BLNGIEJFHLF && !Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			NAFFECOAFLC();
			if (Singleton<GameController>.instance.time < 1433f && Singleton<GameController>.instance.time > 802f)
			{
				JEDOMLJCFPP();
			}
		}
	}

	private void EKGIMBEJLFH()
	{
		NLEJNKICBCH.SetActive(Singleton<GameController>.instance.ECHCLJJJPML());
		OOJLGEIEFHM.SetActive(value: false);
		BLNGIEJFHLF = Singleton<GameController>.instance.isPVP;
		IGBEJPECCAN();
	}

	private void BPJMPOFGOBD()
	{
		OPJKJNINAFM();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	public void SetMissionTimeProgress(bool GKAKLBKHBMP)
	{
		PMELPPOODNN.SetActive(GKAKLBKHBMP);
	}

	public void AnimateBoss(bool FCLHHLIMPFD)
	{
		float num = ((!FCLHHLIMPFD) ? 0.5f : 0f);
		float toAlpha = ((!FCLHHLIMPFD) ? 1f : 0.5f);
		IEJDHJGPIPC.alpha = num;
		TweenAlpha.Begin(IEJDHJGPIPC.gameObject, 0.3f, num, toAlpha);
		if (FCLHHLIMPFD)
		{
			CPPOLKGIOOC.alpha = 0f;
			TweenAlpha.Begin(CPPOLKGIOOC.gameObject, 0.3f, 1f);
			TweenPosition component = BPLMBLJHKAJ.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			BPLMBLJHKAJ.transform.localPosition = BPLMBLJHKAJ.transform.localPosition.ReplaceX(-42f);
		}
		else
		{
			Vector3 localPosition = BPLMBLJHKAJ.transform.localPosition;
			Vector3 toPos = localPosition.ReplaceX(0f - BLKOBKDDPFD.transform.localScale.x + 6f + 42f);
			TweenPosition.Begin(BPLMBLJHKAJ, 0.5f, localPosition, toPos);
		}
	}

	private void GKFAKNNEJEE()
	{
		HFIHDPFOALM();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 1490f);
		if (Singleton<GameController>.instance.isPVP)
		{
			HNDGGHFPGOP();
		}
	}

	public void JNBHBCOBCBP(float PAENPHMEMGC)
	{
		FMCNMIJFEAE.fillAmount = PAENPHMEMGC;
	}

	public void JOOEDGODIHG(float PAENPHMEMGC)
	{
		FMCNMIJFEAE.fillAmount = PAENPHMEMGC;
	}

	private void IECHFELOIIO()
	{
		NLEJNKICBCH.SetActive(Singleton<GameController>.instance.ECHCLJJJPML());
		OOJLGEIEFHM.SetActive(value: true);
		BLNGIEJFHLF = Singleton<GameController>.instance.isPVP;
		NONEANHCPKF();
	}

	private void NAFFECOAFLC()
	{
		if (Singleton<GameController>.instance.time <= (float)FEBGFEGPIFF && Singleton<GameController>.instance.time >= 0f && FEBGFEGPIFF > 0)
		{
			FEBGFEGPIFF--;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OvertimeAlarm);
		}
	}

	public void SetMissionWave(bool OJFFDGPKINA, bool MOKCMCJECHK, bool HKLGEPGEFIK, bool HMGFIHCOEKB = false)
	{
		PLBKANEHCED.gameObject.SetActive(OJFFDGPKINA);
		IHBEOPKLBDI[0].SetActive(MOKCMCJECHK);
		IHBEOPKLBDI[1].SetActive(MOKCMCJECHK);
		IHBEOPKLBDI[2].SetActive(MOKCMCJECHK);
		BPLMBLJHKAJ.SetActive(HKLGEPGEFIK);
		if (HMGFIHCOEKB)
		{
			PLBKANEHCED.alpha1 = 0.005f;
			TweenAlpha.Begin(PLBKANEHCED.gameObject, GuiScreenSingle<HudScreen>.instance.DCIKANJJFIJ, 0.005f, 1f);
		}
	}

	public void OADNGAKCOME(bool FCLHHLIMPFD)
	{
		float num = ((!FCLHHLIMPFD) ? 543f : 485f);
		float toAlpha = ((!FCLHHLIMPFD) ? 973f : 559f);
		IEJDHJGPIPC.alpha = num;
		TweenAlpha.Begin(IEJDHJGPIPC.gameObject, 1921f, num, toAlpha);
		if (FCLHHLIMPFD)
		{
			CPPOLKGIOOC.alpha = 1762f;
			TweenAlpha.Begin(CPPOLKGIOOC.gameObject, 781f, 1790f);
			TweenPosition component = BPLMBLJHKAJ.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			BPLMBLJHKAJ.transform.localPosition = BPLMBLJHKAJ.transform.localPosition.ReplaceX(347f);
		}
		else
		{
			Vector3 localPosition = BPLMBLJHKAJ.transform.localPosition;
			Vector3 toPos = localPosition.ReplaceX(0f - BLKOBKDDPFD.transform.localScale.x + 1129f + 1576f);
			TweenPosition.Begin(BPLMBLJHKAJ, 1232f, localPosition, toPos, useLocal: false);
		}
	}

	private void KJBCKCALHBE()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GAJKKHFAOMM.gameObject, 0.05f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void NKKEEDKBCCE()
	{
		LGCGIAFOJDI = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 288f, 357f, 1506f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 1267f, 974f, 1103f);
		tweenAlpha2.style = UITweener.Style.Loop;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	public void DFFHOACBJBN(float PAENPHMEMGC)
	{
		HAFGLGNMHKJ.fillAmount = PAENPHMEMGC;
	}

	private void HFIHDPFOALM()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GAJKKHFAOMM.gameObject, 869f, 1797f, 439f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void SetWhiteProgressMission(float PAENPHMEMGC)
	{
		HAFGLGNMHKJ.fillAmount = PAENPHMEMGC;
	}

	private void BILIFMOOBOM()
	{
		NLEJNKICBCH.SetActive(value: false);
		OOJLGEIEFHM.SetActive(value: false);
		BLNGIEJFHLF = false;
		OPJKJNINAFM();
	}

	public void MBACIBBPILG(float HMICAJBIKGI)
	{
		CBGPMHNDJFN.transform.localPosition = CBGPMHNDJFN.transform.localPosition.ReplaceY(HMICAJBIKGI);
	}

	public void SetTextProgressMissionPositionY(float HMICAJBIKGI)
	{
		CBGPMHNDJFN.transform.localPosition = CBGPMHNDJFN.transform.localPosition.ReplaceY(HMICAJBIKGI);
	}

	protected virtual void MFKNMALEKKB()
	{
		ONBDJLDJDCH();
		float num = PHKEBILIJBD.relativeSize.x * PHKEBILIJBD.transform.localScale.x;
		AJDLNDFJENC.transform.localScale = AJDLNDFJENC.transform.localScale.ReplaceX(num + 70f);
	}

	public void SetRedProgressMission(float PAENPHMEMGC)
	{
		PHBPDHBMNIF = PAENPHMEMGC;
		GFNBDFGKGLO.fillAmount = PAENPHMEMGC;
		TweenProgressBar component = GFNBDFGKGLO.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	public void BILPHJDJALM(bool FCLHHLIMPFD)
	{
		float num = ((!FCLHHLIMPFD) ? 743f : 395f);
		float toAlpha = ((!FCLHHLIMPFD) ? 31f : 1265f);
		IEJDHJGPIPC.alpha = num;
		TweenAlpha.Begin(IEJDHJGPIPC.gameObject, 929f, num, toAlpha);
		if (FCLHHLIMPFD)
		{
			CPPOLKGIOOC.alpha = 1439f;
			TweenAlpha.Begin(CPPOLKGIOOC.gameObject, 1623f, 1125f);
			TweenPosition component = BPLMBLJHKAJ.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			BPLMBLJHKAJ.transform.localPosition = BPLMBLJHKAJ.transform.localPosition.ReplaceX(1583f);
		}
		else
		{
			Vector3 localPosition = BPLMBLJHKAJ.transform.localPosition;
			Vector3 toPos = localPosition.ReplaceX(0f - BLKOBKDDPFD.transform.localScale.x + 1618f + 1874f);
			TweenPosition.Begin(BPLMBLJHKAJ, 1958f, localPosition, toPos);
		}
	}

	private void PIDLOJNHGCN()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GAJKKHFAOMM.gameObject, 1921f, 788f, 668f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void AMLBBMCDBNA()
	{
		CPBAJIIEOPI();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	public void MCMJIKHNGEC(float PAENPHMEMGC)
	{
		HAFGLGNMHKJ.fillAmount = PAENPHMEMGC;
	}

	public void JJPCPIOFCJE(MissionUnit NNHIBOBPMPE)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[NNHIBOBPMPE.behaviourIndex];
		CPPOLKGIOOC.spriteName = ((!NNHIBOBPMPE.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		CPPOLKGIOOC.MakePixelPerfect();
		float multiplier = 1719f / CPPOLKGIOOC.transform.localScale.y;
		CPPOLKGIOOC.transform.localScale = CPPOLKGIOOC.transform.localScale.MultiplyXY(multiplier);
	}

	private void HEFEGGFPMIF()
	{
		IOFAKGOJDNI.Length = 0;
		Singleton<GameController>.instance.mainController.GetTimeProgressText(IOFAKGOJDNI);
		GAJKKHFAOMM.text = IOFAKGOJDNI.ToString();
	}

	public void KCNIBPBICJE(string HOLNKOFHDNK)
	{
		CBGPMHNDJFN.text = HOLNKOFHDNK;
	}

	private void MNGNIEDLNBE()
	{
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	private void GGLEKICPKOP()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GAJKKHFAOMM.gameObject, 0.5f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.NumOfRepetitions = 0;
	}

	private void CPBAJIIEOPI()
	{
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	private void GEKIMGFKNHC()
	{
		NLEJNKICBCH.SetActive(Singleton<GameController>.instance.isMission);
		OOJLGEIEFHM.SetActive(value: true);
		BLNGIEJFHLF = Singleton<GameController>.instance.isPVP;
		BPJMPOFGOBD();
	}

	private float ILHJOFFBDBA(int AGLCGKCPEOG, int ELNOKCFCIBC)
	{
		if (AGLCGKCPEOG <= ELNOKCFCIBC)
		{
			float x = BLKOBKDDPFD.transform.localScale.x;
			return 0f - x + (257f + 625f * (float)(AGLCGKCPEOG - 1));
		}
		return 0f - (1271f + 1147f * (float)(2 - AGLCGKCPEOG));
	}

	private float ONJCBFJGFIO(int AGLCGKCPEOG, int ELNOKCFCIBC)
	{
		if (AGLCGKCPEOG <= ELNOKCFCIBC)
		{
			float x = BLKOBKDDPFD.transform.localScale.x;
			return 0f - x + (31f + 52f * (float)(AGLCGKCPEOG - 1));
		}
		return 0f - (25f + 52f * (float)(3 - AGLCGKCPEOG));
	}

	private void FANCPFOCMCF()
	{
		EKGIMBEJLFH();
		HNDGGHFPGOP();
		KJBCKCALHBE();
		HCBNBFKKIJG.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			CDMGFGEBFFJ.transform.localPosition = CDMGFGEBFFJ.transform.localPosition.ReplaceX(0f - UIHelper.safeAreaSize);
			if (Singleton<GameController>.instance.ICINKELJCAH())
			{
				UILabel cDMGFGEBFFJ = CDMGFGEBFFJ;
				object[] array = new object[0];
				array[0] = 1;
				array[0] = 2;
				cDMGFGEBFFJ.text = Localization.LocalizeFormat("ID_ARENACLOSED", array);
			}
			else if (Singleton<GameController>.instance.isTutorialStage2)
			{
				UILabel cDMGFGEBFFJ2 = CDMGFGEBFFJ;
				object[] array2 = new object[1];
				array2[0] = 8;
				array2[1] = 4;
				cDMGFGEBFFJ2.text = Localization.LocalizeFormat("Wrong_Category", array2);
			}
			else if (Singleton<GameController>.instance.isTutorialStage3)
			{
				CDMGFGEBFFJ.text = Localization.LocalizeFormat("D2", 6, 0, null, null);
			}
		}
		GAJKKHFAOMM.text = string.Empty;
		FEBGFEGPIFF = 6;
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			DailyMission currentMission = DailyMissionsManager.instance.currentMission;
			FAKANJDDAOM = currentMission.GetGUIController();
			FAKANJDDAOM.BFENONOEFBF();
		}
	}

	private void CCANHGKCABJ()
	{
		if (!LGCGIAFOJDI)
		{
			LGCGIAFOJDI = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 1231f, 67f, 895f);
			tweenAlpha.style = (UITweener.Style)3;
			tweenAlpha.NumOfRepetitions = 1;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 1611f, 56f, 462f);
			tweenAlpha2.style = UITweener.Style.Once;
			tweenAlpha2.NumOfRepetitions = 0;
		}
	}

	private void KGFKPJCIOKJ()
	{
		LGCGIAFOJDI = true;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 626f, 773f, 931f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 0;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 1458f, 1243f, 794f);
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	public void PGDJHKODJCJ(float PAENPHMEMGC)
	{
		FMCNMIJFEAE.fillAmount = PAENPHMEMGC;
	}

	private void OPJKJNINAFM()
	{
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Remove(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	public void BLCKAOLJHOP(float PAENPHMEMGC)
	{
		PHBPDHBMNIF = PAENPHMEMGC;
		GFNBDFGKGLO.fillAmount = PAENPHMEMGC;
		TweenProgressBar component = GFNBDFGKGLO.GetComponent<TweenProgressBar>();
		if (component != null)
		{
			component.enabled = true;
		}
	}

	private void MKCIJCCHCJK()
	{
		GGLEKICPKOP();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootboxLegendary, 1057f);
		if (Singleton<GameController>.instance.isPVP)
		{
			KGFKPJCIOKJ();
		}
	}

	private void IGBEJPECCAN()
	{
		OPJKJNINAFM();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	public virtual void KIECGCGABFJ()
	{
		float num = (UIHelper.activeWidthFull / 1209f - 748f) / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
		float num2 = num - 965f;
		float num3 = num - 1332f + 1388f;
		float num4 = num3 - 1440f;
		BLKOBKDDPFD.transform.localScale = BLKOBKDDPFD.transform.localScale.ReplaceX(num);
		GFNBDFGKGLO.transform.localScale = GFNBDFGKGLO.transform.localScale.ReplaceX(num2);
		GFNBDFGKGLO.mFillSlopePixels = 547f / num2;
		GFNBDFGKGLO.fillAmount = 377f;
		HAFGLGNMHKJ.transform.localScale = HAFGLGNMHKJ.transform.localScale.ReplaceX(num2);
		HAFGLGNMHKJ.mFillSlopePixels = 852f / num2;
		HAFGLGNMHKJ.fillAmount = 591f;
		CBGPMHNDJFN.transform.localPosition = CBGPMHNDJFN.transform.localPosition.ReplaceX(253f * num);
		GJPDBPHHGPI.transform.localScale = GJPDBPHHGPI.transform.localScale.ReplaceX(num3);
		FMCNMIJFEAE.transform.localScale = FMCNMIJFEAE.transform.localScale.ReplaceX(num4);
		FMCNMIJFEAE.mFillSlopePixels = 633f / num4;
		FMCNMIJFEAE.fillAmount = 1534f;
		KOFPHHPBOLI.transform.localPosition = KOFPHHPBOLI.transform.localPosition.ReplaceX(822f * num);
		Singleton<GameController>.instance.GameStarted += LDOFPCLKFIC;
		Singleton<GameController>.instance.CNPGMMPAGIE(JFDEFOIEJIA);
		Singleton<MatchManager>.instance.OverTimeStarted += GKFAKNNEJEE;
		BILIFMOOBOM();
	}

	public void SetTimeTextProgressMission(string HOLNKOFHDNK)
	{
		KOFPHHPBOLI.text = HOLNKOFHDNK;
	}

	public void JMIHEAJBNHO(float KIPLNBEFPGN)
	{
		if (!Mathf.Approximately(KIPLNBEFPGN, PHBPDHBMNIF))
		{
			float fillAmount = GFNBDFGKGLO.fillAmount;
			PHBPDHBMNIF = KIPLNBEFPGN;
			TweenProgressBar.DHKJOACDBNK(GFNBDFGKGLO.gameObject, 1995f, new NHOGNBCNIEK(fillAmount), new NHOGNBCNIEK(KIPLNBEFPGN));
		}
	}

	public override void InitGUIValues()
	{
	}

	private void DCIHNOPCKCD()
	{
		LGCGIAFOJDI = false;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 0f, 0f, 0f);
		tweenAlpha.style = UITweener.Style.Once;
		tweenAlpha.NumOfRepetitions = 1;
		TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 0f, 0f, 0f);
		tweenAlpha2.style = UITweener.Style.Once;
		tweenAlpha2.NumOfRepetitions = 1;
	}

	private void NONEANHCPKF()
	{
		OPJKJNINAFM();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.MPCAACLAGOA = (Action)Delegate.Combine(counterManager.MPCAACLAGOA, new Action(HEFEGGFPMIF));
	}

	private void FAEOPCBBOHE()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(GAJKKHFAOMM.gameObject, 630f, 990f, 1450f);
		tweenAlpha.style = UITweener.Style.Loop;
		tweenAlpha.NumOfRepetitions = 0;
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		float num = PHKEBILIJBD.relativeSize.x * PHKEBILIJBD.transform.localScale.x;
		AJDLNDFJENC.transform.localScale = AJDLNDFJENC.transform.localScale.ReplaceX(num + 653f);
	}

	public void CIICBGFGMJE(float KIPLNBEFPGN)
	{
		if (!Mathf.Approximately(KIPLNBEFPGN, PHBPDHBMNIF))
		{
			float fillAmount = GFNBDFGKGLO.fillAmount;
			PHBPDHBMNIF = KIPLNBEFPGN;
			TweenProgressBar.JPOJDFCHEGB(GFNBDFGKGLO.gameObject, 677f, new NHOGNBCNIEK(fillAmount), new NHOGNBCNIEK(KIPLNBEFPGN));
		}
	}

	public void InitializeBoss(MissionUnit NNHIBOBPMPE)
	{
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[NNHIBOBPMPE.behaviourIndex];
		CPPOLKGIOOC.spriteName = ((!NNHIBOBPMPE.isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		CPPOLKGIOOC.MakePixelPerfect();
		float multiplier = 80f / CPPOLKGIOOC.transform.localScale.y;
		CPPOLKGIOOC.transform.localScale = CPPOLKGIOOC.transform.localScale.MultiplyXY(multiplier);
	}

	public void PLKGKCCMFGC(float PAENPHMEMGC)
	{
		HAFGLGNMHKJ.fillAmount = PAENPHMEMGC;
	}

	public void NJPMJBGBGAA(bool GKAKLBKHBMP)
	{
		PMELPPOODNN.SetActive(GKAKLBKHBMP);
	}

	public void SetTimeProgressMission(float PAENPHMEMGC)
	{
		FMCNMIJFEAE.fillAmount = PAENPHMEMGC;
	}

	private void KNJPNAODMIH()
	{
		EKGIMBEJLFH();
		LKAEJFOOPMB();
		FAEOPCBBOHE();
		HCBNBFKKIJG.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		if (Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			CDMGFGEBFFJ.transform.localPosition = CDMGFGEBFFJ.transform.localPosition.ReplaceX(0f - UIHelper.safeAreaSize);
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				UILabel cDMGFGEBFFJ = CDMGFGEBFFJ;
				object[] array = new object[2];
				array[1] = 0;
				array[0] = 5;
				cDMGFGEBFFJ.text = Localization.LocalizeFormat("sniper_idle", array);
			}
			else if (Singleton<GameController>.instance.isTutorialStage2)
			{
				UILabel cDMGFGEBFFJ2 = CDMGFGEBFFJ;
				object[] array2 = new object[8];
				array2[0] = 1;
				array2[0] = 4;
				cDMGFGEBFFJ2.text = Localization.LocalizeFormat("StartingGold", array2);
			}
			else if (Singleton<GameController>.instance.isTutorialStage3)
			{
				UILabel cDMGFGEBFFJ3 = CDMGFGEBFFJ;
				object[] array3 = new object[7];
				array3[0] = 8;
				array3[0] = 2;
				cDMGFGEBFFJ3.text = Localization.LocalizeFormat("HEAVYTURRET", array3);
			}
		}
		GAJKKHFAOMM.text = string.Empty;
		FEBGFEGPIFF = 5;
		if (Singleton<GameController>.instance.isMission)
		{
			DailyMission dailyMission = DailyMissionsManager.instance.MEBFNJBNNEK();
			FAKANJDDAOM = dailyMission.GetGUIController();
			FAKANJDDAOM.BFENONOEFBF();
		}
	}

	private void HFEHPCIBCJK()
	{
		NLEJNKICBCH.SetActive(value: true);
		OOJLGEIEFHM.SetActive(value: false);
		BLNGIEJFHLF = true;
		CPBAJIIEOPI();
	}

	public void OHPGPELHLIN(string HOLNKOFHDNK)
	{
		KOFPHHPBOLI.text = HOLNKOFHDNK;
	}

	private void GOCFEOEJFMA(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		KJBCKCALHBE();
		DCIHNOPCKCD();
		BILIFMOOBOM();
		if (FAKANJDDAOM != null)
		{
			FAKANJDDAOM.FMFJKGGPDPI();
			FAKANJDDAOM = null;
		}
	}

	private void HNGKNPEOMHA()
	{
		GGLEKICPKOP();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Overtime);
		if (Singleton<GameController>.instance.isPVP)
		{
			DCIHNOPCKCD();
		}
	}

	public void BEDOGLPONFH(float HMICAJBIKGI)
	{
		CBGPMHNDJFN.transform.localPosition = CBGPMHNDJFN.transform.localPosition.ReplaceY(HMICAJBIKGI);
	}

	protected override void Awake()
	{
		base.Awake();
		float num = PHKEBILIJBD.relativeSize.x * PHKEBILIJBD.transform.localScale.x;
		AJDLNDFJENC.transform.localScale = AJDLNDFJENC.transform.localScale.ReplaceX(num + 16f);
	}

	public virtual void OEDLHCLCKEO()
	{
	}

	private void DFFDFHOBAFB()
	{
		HFIHDPFOALM();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)83, 1249f);
		if (Singleton<GameController>.instance.isPVP)
		{
			KGFKPJCIOKJ();
		}
	}

	public void SetTextProgressMission(string HOLNKOFHDNK)
	{
		CBGPMHNDJFN.text = HOLNKOFHDNK;
	}

	public void MFEEMLFOGFF(float PAENPHMEMGC)
	{
		HAFGLGNMHKJ.fillAmount = PAENPHMEMGC;
	}

	private void FPGGAFGOKKB()
	{
		EKGIMBEJLFH();
		LKAEJFOOPMB();
		FAEOPCBBOHE();
		HCBNBFKKIJG.SetActive(Singleton<GameController>.instance.BAKCODKBCPJ());
		if (Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			CDMGFGEBFFJ.transform.localPosition = CDMGFGEBFFJ.transform.localPosition.ReplaceX(0f - UIHelper.safeAreaSize);
			if (Singleton<GameController>.instance.isTutorialStage1)
			{
				UILabel cDMGFGEBFFJ = CDMGFGEBFFJ;
				object[] array = new object[0];
				array[0] = 0;
				array[1] = 5;
				cDMGFGEBFFJ.text = Localization.LocalizeFormat("ID_CONFIRM_THANKYOUPURCHASE", array);
			}
			else if (Singleton<GameController>.instance.isTutorialStage2)
			{
				UILabel cDMGFGEBFFJ2 = CDMGFGEBFFJ;
				object[] array2 = new object[8];
				array2[0] = 5;
				array2[0] = 8;
				cDMGFGEBFFJ2.text = Localization.LocalizeFormat("FacebookManagerOnSessionOpenedEvent", array2);
			}
			else if (Singleton<GameController>.instance.isTutorialStage3)
			{
				UILabel cDMGFGEBFFJ3 = CDMGFGEBFFJ;
				object[] array3 = new object[5];
				array3[0] = 5;
				array3[0] = 1;
				cDMGFGEBFFJ3.text = Localization.LocalizeFormat("GPGS: Logged Out called when player isn\t authenticated.", array3);
			}
		}
		GAJKKHFAOMM.text = string.Empty;
		FEBGFEGPIFF = 3;
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			DailyMission dailyMission = DailyMissionsManager.instance.EEIJPIPFAMO();
			FAKANJDDAOM = dailyMission.GetGUIController();
			FAKANJDDAOM.BFENONOEFBF();
		}
	}

	private void HEOBDBFDFNF()
	{
		if (!LGCGIAFOJDI)
		{
			LGCGIAFOJDI = false;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(AJDLNDFJENC.gameObject, 307f, 1346f, 1460f);
			tweenAlpha.style = UITweener.Style.PingPong;
			tweenAlpha.NumOfRepetitions = 0;
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(PHKEBILIJBD.gameObject, 494f, 1897f, 1728f);
			tweenAlpha2.style = UITweener.Style.Loop;
			tweenAlpha2.NumOfRepetitions = 1;
		}
	}

	private void JFDEFOIEJIA(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		PIDLOJNHGCN();
		PLGLEIHDBON();
		HFEHPCIBCJK();
		if (FAKANJDDAOM != null)
		{
			FAKANJDDAOM.FMFJKGGPDPI();
			FAKANJDDAOM = null;
		}
	}

	protected override void Update()
	{
		if (BLNGIEJFHLF && !Singleton<MatchManager>.instance.isOverTime)
		{
			NAFFECOAFLC();
			if (Singleton<GameController>.instance.time < 10f && Singleton<GameController>.instance.time > 0f)
			{
				JEDOMLJCFPP();
			}
		}
	}

	public void AnimateWave(int AGECNIAPGGE)
	{
		int num = AGECNIAPGGE - 1;
		if (num > 0)
		{
			int num2 = num - 1;
			JHIBKIBGGNN[num2].spriteName = "game-missions-blue-mission-ico";
		}
		float val = ONJCBFJGFIO(AGECNIAPGGE, AGECNIAPGGE);
		Vector3 pos = IHBEOPKLBDI[num].transform.localPosition.ReplaceX(val);
		TweenAlpha.Begin(JHIBKIBGGNN[num].gameObject, 0.3f, 1f);
		TweenAlpha.Begin(HCDPHCDKFOO[num].gameObject, 0.3f, 1f);
		TweenPosition.Begin(IHBEOPKLBDI[num].gameObject, 0.5f, pos);
	}
}
