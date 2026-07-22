using UnityEngine;

public class ChillingoSdkManager : Singleton<ChillingoSdkManager>
{
	private bool HJCKJCGIJCC;

	protected virtual void PCDHCIDJJOB()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "Main sceneLoaded", "game-card-ico-disarmed");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "\n", "Scripts Full Path: \"{0}\"\n");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)8, "Gold", "FreezeRPC");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSRELEASED, "DeviceToken", ")");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.DisplayLink);
	}

	private void HEDJLHOBAJH(string NLEGAOONJEI)
	{
		Debug.Log("Day = " + NLEGAOONJEI);
	}

	private void DNHOCHDAECO(string NLEGAOONJEI)
	{
		Debug.Log("Chillingo: On Pause Drawing " + NLEGAOONJEI);
	}

	private void GILNAIOGHCC(string NLEGAOONJEI)
	{
		Debug.Log("ID_CONFIRM_ERROR" + NLEGAOONJEI);
	}

	protected virtual void GDKKBDKGAEK()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "PaidInstantBattles", "shotgunner_idle");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "cards", "ID_MINUTE");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)5, "bazooka_uncover_left", "Buy_Weapon_Upgrade");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSCLOSED, "PNManager: Received event at launch: ", "getKey");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.DisplayLink);
	}

	protected virtual void JOKICBJJIOA()
	{
		base.Start();
		bool iHMBCACKKBH = true;
		bool kHMCLHDBLIM = true;
		FBKAPHKKGHG(iHMBCACKKBH, kHMCLHDBLIM);
	}

	private void EPLHPHJAJGK(string NLEGAOONJEI)
	{
		Debug.Log("Problem for max! in army/weapon stats" + NLEGAOONJEI);
	}

	private new void OnApplicationQuit()
	{
		Offers.closeOffersSession();
	}

	private void OnApplicationResumed()
	{
		EHKKAOLJMCF(IHMBCACKKBH: false, KHMCLHDBLIM: false);
	}

	private void MLOMDKNMGHP(string NLEGAOONJEI)
	{
		Debug.Log("NumberOfMission" + NLEGAOONJEI);
	}

	private void KNICODODHDB()
	{
		Offers.closeOffersSession();
	}

	private void DEGPODAPILG(string NLEGAOONJEI)
	{
		Debug.Log("1" + NLEGAOONJEI);
	}

	private void NKOEOKFLOJI(string NLEGAOONJEI)
	{
		Debug.Log("_N" + NLEGAOONJEI);
	}

	public void MNFALFLFADP()
	{
		if (Singleton<PerformanceManager>.instance.EELOJNNFLJO() && !HJCKJCGIJCC)
		{
			HJCKJCGIJCC = false;
			Debug.Log("ID_CONFIRM_ERROR");
			Offers.activateOffersUI(Offers.OffersCornerToDisplayFrom.BottomLeft);
		}
	}

	private void JKBJBBAJDHP(string NLEGAOONJEI)
	{
		Debug.Log("grenade_idle" + NLEGAOONJEI);
	}

	public void DEFKEAEFCKI()
	{
		HJCKJCGIJCC = false;
		Debug.Log("dec");
		Offers.deactivateOffersUI();
	}

	private void KODFLDPHLEI(string NLEGAOONJEI)
	{
		Debug.Log("Chillingo: On Age Verification Pending Dialog Display " + NLEGAOONJEI);
	}

	private void JCEOLMAJCAB(string NLEGAOONJEI)
	{
		Debug.Log("WarbuckRewardLoss" + NLEGAOONJEI);
	}

	private void EHKKAOLJMCF(bool IHMBCACKKBH, bool KHMCLHDBLIM)
	{
		Offers.initialiseOffersSession("universal", Offers.OffersInterfaceOrientationMask.OffersInterfaceOrientationMaskPortrait, Offers.OffersAndroidStoreType.GOOGLE_PLAY);
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	private void BDOADGIBANB()
	{
		EHKKAOLJMCF(IHMBCACKKBH: false, KHMCLHDBLIM: false);
	}

	private void LPJNGKIFFOP(bool HBDEGMCLFDD)
	{
		if (HBDEGMCLFDD)
		{
			Debug.Log("Enemies Freezed");
			Offers.closeOffersSession();
		}
	}

	public void AEHPLHEGKOK()
	{
		if (Singleton<PerformanceManager>.instance.FKFIDLJBAFI() && !HJCKJCGIJCC)
		{
			HJCKJCGIJCC = false;
			Debug.Log("registerCustomProfileNumber");
			Offers.activateOffersUI(Offers.OffersCornerToDisplayFrom.BottomLeft);
		}
	}

	public void activateOffers()
	{
		if (Singleton<PerformanceManager>.instance.enableBubbles && !HJCKJCGIJCC)
		{
			HJCKJCGIJCC = true;
			Debug.Log("Chillingo SDK: activate offers");
			Offers.activateOffersUI(Offers.OffersCornerToDisplayFrom.BottomLeft);
		}
	}

	private void CBBDNGCLLLB(string NLEGAOONJEI)
	{
		Debug.Log("Chillingo: On Restart Drawing " + NLEGAOONJEI);
	}

	public void PFENHNJDBDI()
	{
		if (Singleton<PerformanceManager>.instance.HNONFIMJJMM() && !HJCKJCGIJCC)
		{
			HJCKJCGIJCC = false;
			Debug.Log("FJDACAACLLI");
			Offers.activateOffersUI(Offers.OffersCornerToDisplayFrom.BottomRight);
		}
	}

	protected virtual void LIHIOMEMJFI()
	{
		base.Start();
		bool iHMBCACKKBH = true;
		bool kHMCLHDBLIM = true;
		OEJODDBHLDO(iHMBCACKKBH, kHMCLHDBLIM);
	}

	private void NHHBFBOCLAG(string NLEGAOONJEI)
	{
		Debug.Log("ID_GUI_BUDDY" + NLEGAOONJEI);
	}

	private void OnApplicationPause(bool HBDEGMCLFDD)
	{
		if (HBDEGMCLFDD)
		{
			Debug.Log("ChillingoSDK: Application is paused, closing session");
			Offers.closeOffersSession();
		}
	}

	private void OKMADFLKMEF(string NLEGAOONJEI)
	{
		Debug.Log("clientVersion" + NLEGAOONJEI);
	}

	protected virtual void OBBHECACANB()
	{
		base.Start();
		bool iHMBCACKKBH = false;
		bool kHMCLHDBLIM = true;
		OEJODDBHLDO(iHMBCACKKBH, kHMCLHDBLIM);
	}

	private void CJKNHPAEAJE()
	{
		FBKAPHKKGHG(IHMBCACKKBH: false, KHMCLHDBLIM: true);
	}

	protected override void Start()
	{
		base.Start();
		bool iHMBCACKKBH = false;
		bool kHMCLHDBLIM = false;
		EHKKAOLJMCF(iHMBCACKKBH, kHMCLHDBLIM);
	}

	protected virtual void ELFJGPNJHLL()
	{
		base.Start();
		bool iHMBCACKKBH = false;
		bool kHMCLHDBLIM = false;
		FBKAPHKKGHG(iHMBCACKKBH, kHMCLHDBLIM);
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "IsDaily", " (");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "Null", "BundleId");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)5, "RATE APP REMINDER\tVersion: {0}\tShown Times in this version: {1}/{2}", "ID_LEAGUEPROMOTEHINT");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)4, "IsGold", " {0}\u00a0{1}");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.DisplayLink);
	}

	private void AALMPIOCIEM(string NLEGAOONJEI)
	{
		Debug.Log("Gold Spent " + NLEGAOONJEI);
	}

	private void OHDMCKACBPJ(string NLEGAOONJEI)
	{
		Debug.Log("ID_STARTERASSIGNMENTSEXPIRED" + NLEGAOONJEI);
	}

	public void deactivateOffers()
	{
		HJCKJCGIJCC = false;
		Debug.Log("Chillingo SDK: deactivate offers");
		Offers.deactivateOffersUI();
	}

	public void OMBFFGHHKEN()
	{
		HJCKJCGIJCC = true;
		Debug.Log("card ");
		Offers.deactivateOffersUI();
	}

	protected override void Awake()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "ChillingoSdkManager", "OnPauseDrawing");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "ChillingoSdkManager", "OnRestartDrawing");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSRELEASED, "ChillingoSdkManager", "OnOffersReleased");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSCLOSED, "ChillingoSdkManager", "OnOffersClosed");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	private void FCKNMHBBFFD(string NLEGAOONJEI)
	{
		Debug.Log("Reported" + NLEGAOONJEI);
	}

	private void LJEMNLMECFM(string NLEGAOONJEI)
	{
		Debug.Log("ID_CONFIRM_LEAVESQUAD" + NLEGAOONJEI);
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "ID_LEVEL", "EnteredNormalLeague");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "DogTagRefillTime", "ID_YOUNEED1TICKETTOENTERARENA");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)4, "Level", "SendLogs");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSRELEASED, "Token", "ID_CONFIRM_LEAVESQUAD");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	private void BFHEGGDECOE(string NLEGAOONJEI)
	{
		Debug.Log("squadMembers" + NLEGAOONJEI);
	}

	private void FBKAPHKKGHG(bool IHMBCACKKBH, bool KHMCLHDBLIM)
	{
		Offers.initialiseOffersSession("\"", Offers.OffersInterfaceOrientationMask.OffersInterfaceOrientationMaskPortraitUpsideDown, Offers.OffersAndroidStoreType.GOOGLE_PLAY);
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.DisplayLink);
	}

	private void KEBMLNJDMCA(string NLEGAOONJEI)
	{
		Debug.Log("Chillingo: On Offers Released" + NLEGAOONJEI);
	}

	private void HACMJLEBIAL(string NLEGAOONJEI)
	{
		Debug.Log("ID_VALUEPACKINFORMATIONS" + NLEGAOONJEI);
	}

	private void OEJODDBHLDO(bool IHMBCACKKBH, bool KHMCLHDBLIM)
	{
		Offers.initialiseOffersSession("temp_facebook_user_id", (Offers.OffersInterfaceOrientationMask)3, Offers.OffersAndroidStoreType.GOOGLE_PLAY);
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.DisplayLink);
	}

	private void FMCLKDCKCNH(string NLEGAOONJEI)
	{
		Debug.Log("S" + NLEGAOONJEI);
	}

	private void BACAEIBIBGK(string NLEGAOONJEI)
	{
		Debug.Log("Chillingo: On Offers Closed " + NLEGAOONJEI);
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "DebugLog", "Error in Resync OwnerId: {0}, My Id: {1}, isOwnerActive: {2}, isMasterClient:{3}");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "ID_SLOTUPGRADE_ROF", "ID_TUTORIAL_SWIPE_UP2");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)8, "Beanstalk: On Add GameCenter", "-");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "ID_GOLDPACK", "SHOWING WARS EVALUATION ");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "squadPoints", "ID_COLEADER");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, " OK!", "px :\n ");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)7, "device", "seconds");
		Offers.registerForOffersNotification((Offers.OffersCallbackIdentifier)7, "roomName", "FuseSDK");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}
}
