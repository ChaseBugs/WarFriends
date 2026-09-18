using UnityEngine;

public class ChillingoSdkManager : Singleton<ChillingoSdkManager>
{
	private bool mOffersShown;

	protected override void Awake()
	{
		base.Awake();
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.PAUSEDRAWING, "ChillingoSdkManager", "OnPauseDrawing");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.RESTARTDRAWING, "ChillingoSdkManager", "OnRestartDrawing");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSRELEASED, "ChillingoSdkManager", "OnOffersReleased");
		Offers.registerForOffersNotification(Offers.OffersCallbackIdentifier.OFFERSCLOSED, "ChillingoSdkManager", "OnOffersClosed");
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	private void OnPauseDrawing(string str)
	{
		Debug.Log("Chillingo: On Pause Drawing " + str);
	}

	private void OnRestartDrawing(string str)
	{
		Debug.Log("Chillingo: On Restart Drawing " + str);
	}

	private void OnOffersReleased(string str)
	{
		Debug.Log("Chillingo: On Offers Released" + str);
	}

	private void OnOffersClosed(string str)
	{
		Debug.Log("Chillingo: On Offers Closed " + str);
	}

	private void OnAgeVerificationPendingDialogDisplay(string str)
	{
		Debug.Log("Chillingo: On Age Verification Pending Dialog Display " + str);
	}

	protected override void Start()
	{
		base.Start();
		bool preCOPPA = false;
		bool useCustomSkin = false;
		Init(preCOPPA, useCustomSkin);
	}

	private void Init(bool preCOPPA, bool useCustomSkin)
	{
		Offers.initialiseOffersSession("universal", Offers.OffersInterfaceOrientationMask.OffersInterfaceOrientationMaskPortrait, Offers.OffersAndroidStoreType.GOOGLE_PLAY);
		Offers.setOffersUpdateMethod(Offers.OffersUIUpdateMethod.Timer);
	}

	public void activateOffers()
	{
		if (Singleton<PerformanceManager>.instance.enableBubbles && !mOffersShown)
		{
			mOffersShown = true;
			Debug.Log("Chillingo SDK: activate offers");
			Offers.activateOffersUI(Offers.OffersCornerToDisplayFrom.BottomLeft);
		}
	}

	public void deactivateOffers()
	{
		mOffersShown = false;
		Debug.Log("Chillingo SDK: deactivate offers");
		Offers.deactivateOffersUI();
	}

	private void OnApplicationQuit()
	{
		Offers.closeOffersSession();
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus)
		{
			Debug.Log("ChillingoSDK: Application is paused, closing session");
			Offers.closeOffersSession();
		}
	}

	private void OnApplicationResumed()
	{
		Init(preCOPPA: false, useCustomSkin: false);
	}
}
