using UnityEngine;

public class AssignmentPauseRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite DAANKCOLJGJ;

	public UILabel OKMNFHNBMFA;

	public UISprite JCJKHLPLKLD;

	public GameObject KDNGNGHFMMG;

	public GameObject MHLOEKJPBIB;

	public UILabel GAJKKHFAOMM;

	[Header("-Reward")]
	public GameObject DOCLOEBEGIL;

	public UISprite MIINDLONJJH;

	public UILabel AAOJDLOBAJG;

	public UILabel LJJDAGJCDOM;

	[Header("-Done")]
	public GameObject ONIGBLFEACO;

	public UISprite GPPCDCLKJHC;

	public UILabel NIGMBGABEKF;

	public UILabel AMOKOLCBGHE;

	private Assignment MALGNFKAAME;

	private Assignment.MHNMOFPPKBN MMLIIEIJOJD;

	private readonly Vector3 ENMBGGKEAFH = new Vector3(56f, 37f, 1f);

	private readonly Vector3 ACFKJFHMLII = new Vector3(40f, 40f, 1f);

	private readonly Vector3 KDFBFOGMLCJ = new Vector3(35f, 47f, 1f);

	private void HEGHCHCLPHN()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "125 MENU WEAPON SCREEN TUTORIAL WEAPON EQUIPPED";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "FuseSDK";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "PlayerInfo";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void Initialize(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO.Assignment);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("{0} {1}", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.InProgress);
			ONIGBLFEACO.SetActive(currentState == Assignment.JLANLLEABDC.Done || currentState == Assignment.JLANLLEABDC.Finishing);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			IOOFEOPNIOJ();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO.Time);
			UpdateTime(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void DBHJHHHAIEB(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(flag);
	}

	public void KOEBOGHPHIA(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO.Assignment);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("ID_CONFIRM_ERROR", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.Finishing);
			ONIGBLFEACO.SetActive(currentState != (Assignment.JLANLLEABDC)5 && currentState == Assignment.JLANLLEABDC.InProgress);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			IOOFEOPNIOJ();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			EAHGFDMHMCA(AssignmentsManager.ADHPOEFKINO.Assignment);
			EKDGDAHOGMA(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void BKIDCOAKHEN()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "duplicate WB ";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)8)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "Player id: {0}, player userId {1}";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "ID_UPGRADEFORCHEAPER";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	private void HEIIGGLPFCJ(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(flag);
	}

	private void NPEIEOHBPAB()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "ID_CONFIRM_PLAYERNAMETAKEN";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)4)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "Exception when adding warcards reward for tutorial - adding default instead, msg = ";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "-";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void UpdateTime(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			GAJKKHFAOMM.text = Localization.LocalizeFormat("ID_NEWASSIGNMENTIN", Colours.stringBlue, text);
		}
	}

	private void IOOFEOPNIOJ()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "menu-gold";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Scraps)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "menu-arena-scrap-ico";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "menu-arena-ticket";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	private void OLKHHOLJBIH()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "-{0}";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Scraps)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "visuals: {0} {1} {2} {3}";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "FuseUnityPlugin ";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void BEBOOOMGIJH(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[0] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat("ID_VIPBENEFIT", array);
		}
	}

	private void NNLLNHANBFH()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "Type";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)7)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "ID_FEATURE_DAMAGE-DESCRIPTION";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "ID_RELOG_TO_WRONG_FB_DIALOG_TITLE";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void CONKDIBIPBH(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			HEIIGGLPFCJ(AssignmentsManager.ADHPOEFKINO.Time);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("Level1", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.Finishing);
			ONIGBLFEACO.SetActive(currentState == Assignment.JLANLLEABDC.Finishing || currentState == Assignment.JLANLLEABDC.Finishing);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			IOOFEOPNIOJ();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			NDLJOCDBNEP(AssignmentsManager.ADHPOEFKINO.Assignment);
			BEBOOOMGIJH(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void PKGEGDKPNBE()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "Input turned on completely: ";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)3)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = ", ";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "ID_CATEGORY_LOW_PL_MINIGUN";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void EKDGDAHOGMA(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[5];
			array[1] = Colours.stringBlue;
			array[1] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat("DogTagRefillTime", array);
		}
	}

	public void MFMJPBCIHEH(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			FACJNIMNAMD(AssignmentsManager.ADHPOEFKINO.Assignment);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("RETRYPERM", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.InProgress);
			ONIGBLFEACO.SetActive(currentState == (Assignment.JLANLLEABDC)8 || currentState == Assignment.JLANLLEABDC.Finishing);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			IOOFEOPNIOJ();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO.Time);
			BEBOOOMGIJH(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	public void DDECKJACMEH(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[0] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat(")", array);
		}
	}

	private void NDLJOCDBNEP(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(!flag);
	}

	private void EAHGFDMHMCA(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(flag);
	}

	public void DEIAFHLHAKB(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			GAJKKHFAOMM.text = Localization.LocalizeFormat("Exception during Load Event Assignment Config: ", Colours.stringBlue, text, null, null, null, null, null);
		}
	}

	public void ECOIBBHDFAM(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			GAJKKHFAOMM.text = Localization.LocalizeFormat("Unit \"{0}\" elite parts: {1}\n", Colours.stringBlue, text, null, null, null);
		}
	}

	public void LIMIFKFNNLA(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO.Assignment);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("Password", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.InProgress);
			ONIGBLFEACO.SetActive(currentState != Assignment.JLANLLEABDC.InProgress && currentState == Assignment.JLANLLEABDC.Finishing);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			HEGHCHCLPHN();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			EAHGFDMHMCA(AssignmentsManager.ADHPOEFKINO.Assignment);
			ECOIBBHDFAM(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	public void CMJIJGDEJPE(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[7];
			array[1] = Colours.stringBlue;
			array[0] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat("Assignment: Score points in one battle", array);
		}
	}

	private void HEMDMIPDOEA()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "Spend_Gold_On_Power_Bands";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)7)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "ID_TUTORIAL_UPGRADEWEAPON_2";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "remainingTimeForNextDogtag";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void JPBOGGKMAON(Assignment EFEIDBFDDBE)
	{
		MALGNFKAAME = EFEIDBFDDBE;
		if (EFEIDBFDDBE != null)
		{
			EAHGFDMHMCA(AssignmentsManager.ADHPOEFKINO.Assignment);
			Assignment.JLANLLEABDC currentState = EFEIDBFDDBE.currentState;
			float progress = EFEIDBFDDBE.GetProgress();
			int rewardAmount = EFEIDBFDDBE.rewardAmount;
			int rewardPoints = EFEIDBFDDBE.rewardPoints;
			DAANKCOLJGJ.spriteName = EFEIDBFDDBE.assignmentPicture;
			DAANKCOLJGJ.MakePixelPerfect();
			OKMNFHNBMFA.text = string.Format("-[^-]*$", (currentState != Assignment.JLANLLEABDC.InProgress) ? EFEIDBFDDBE.goldDescription : EFEIDBFDDBE.blueDescription, EFEIDBFDDBE.status);
			JCJKHLPLKLD.spriteName = ((currentState != Assignment.JLANLLEABDC.InProgress) ? AssignmentsManager.goldProgressBar : EFEIDBFDDBE.progressBarSpriteForProgress);
			JCJKHLPLKLD.fillAmount = progress;
			DOCLOEBEGIL.SetActive(currentState == Assignment.JLANLLEABDC.Finishing);
			ONIGBLFEACO.SetActive(currentState != (Assignment.JLANLLEABDC)8 && currentState == Assignment.JLANLLEABDC.InProgress);
			MMLIIEIJOJD = EFEIDBFDDBE.rewardType;
			IOOFEOPNIOJ();
			AAOJDLOBAJG.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			LJJDAGJCDOM.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
			NIGMBGABEKF.text = MEJMLNDFDBP.PHCBFODPDOD(rewardAmount);
			AMOKOLCBGHE.text = MEJMLNDFDBP.PHCBFODPDOD(rewardPoints);
		}
		else
		{
			MGGCLMIMCCA(AssignmentsManager.ADHPOEFKINO.Assignment);
			CMJIJGDEJPE(AssignmentsManager.instance.timeUntilMidnight);
		}
	}

	private void BJNDJJDJNBA()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "GameControllerCampaign.StartGame START";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)8)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "UnlockLevel";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "ArenaPoorConnection";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	private void DHNHMNLIKGG()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "{0}{1}[-] {2}/[-] {3}";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == (Assignment.MHNMOFPPKBN)8)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "defendPosition";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "LevelRewards";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	public void NMOEMGAMDBH(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[1] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat("https://", array);
		}
	}

	private void MGGCLMIMCCA(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(!flag);
	}

	private void KECFEJKBCLH(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(!flag);
	}

	public void BCEKMKLNDLB(int KBJEOEEOEFG)
	{
		if (MALGNFKAAME == null)
		{
			string text = MEJMLNDFDBP.CLPJABAILLN(KBJEOEEOEFG);
			UILabel gAJKKHFAOMM = GAJKKHFAOMM;
			object[] array = new object[7];
			array[1] = Colours.stringBlue;
			array[1] = text;
			gAJKKHFAOMM.text = Localization.LocalizeFormat("menu-cards-silverpack", array);
		}
	}

	private void IKCONPBGABK()
	{
		if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC = GPPCDCLKJHC;
			string spriteName = "Wrong_Weapon";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ENMBGGKEAFH;
			GPPCDCLKJHC.transform.localScale = ENMBGGKEAFH;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Tickets)
		{
			UISprite gPPCDCLKJHC2 = GPPCDCLKJHC;
			string spriteName = "HELMETS_CROWNSILVER";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC2.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = ACFKJFHMLII;
			GPPCDCLKJHC.transform.localScale = ACFKJFHMLII;
		}
		else if (MMLIIEIJOJD == Assignment.MHNMOFPPKBN.Gold)
		{
			UISprite gPPCDCLKJHC3 = GPPCDCLKJHC;
			string spriteName = "Conversion";
			MIINDLONJJH.spriteName = spriteName;
			gPPCDCLKJHC3.spriteName = spriteName;
			MIINDLONJJH.transform.localScale = KDFBFOGMLCJ;
			GPPCDCLKJHC.transform.localScale = KDFBFOGMLCJ;
		}
	}

	private void FACJNIMNAMD(AssignmentsManager.ADHPOEFKINO IGBEGIBGLKK)
	{
		bool flag = IGBEGIBGLKK == AssignmentsManager.ADHPOEFKINO.Assignment;
		KDNGNGHFMMG.SetActive(flag);
		MHLOEKJPBIB.SetActive(flag);
	}
}
