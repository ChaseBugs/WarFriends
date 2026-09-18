using System;
using System.Collections;
using UnityEngine;

public class SettingsGeneralContent : Core_BaseScript
{
	[Header("Top")]
	public UISlider musicSlider;

	public BoxCollider musicCollider;

	public UISlider sfxSlider;

	public BoxCollider soundEffectsCollider;

	public BoxCollider underSliders;

	[Header("Middle")]
	public GameObject restorePurchasesButton;

	public GameObject languageButton;

	public GameObject creditsButton;

	public GameObject privacyButton;

	public GameObject googlePlayAchievmentsButton;

	[Header("Bottom")]
	public GameObject eaButton;

	public GameObject bugButton;

	public GameObject wikiButton;

	public GameObject mobcrushButton;

	public UILabel clientVersion;

	public UILabel playerID;

	public UILabel configsVersion;

	private RadicalRoutine mCountdown;

	private GameObject mLastClickedGameObject;

	public void InitControls()
	{
		UISlider uISlider = musicSlider;
		uISlider.onValueChange = (UISlider.OnValueChange)Delegate.Combine(uISlider.onValueChange, (UISlider.OnValueChange)delegate(float val)
		{
			SoundsManager.Instance.musicVolume = val;
		});
		UISlider uISlider2 = sfxSlider;
		uISlider2.onValueChange = (UISlider.OnValueChange)Delegate.Combine(uISlider2.onValueChange, (UISlider.OnValueChange)delegate(float val)
		{
			SoundsManager.Instance.soundsVolume = val;
		});
		UIEventListener uIEventListener = UIEventListener.Get(musicSlider.gameObject);
		uIEventListener.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uIEventListener.onPress, new UIEventListener.BoolDelegate(OnMusicPress));
		UIEventListener uIEventListener2 = UIEventListener.Get(sfxSlider.gameObject);
		uIEventListener2.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uIEventListener2.onPress, new UIEventListener.BoolDelegate(OnEffectPress));
		UIEventListener uIEventListener3 = UIEventListener.Get(underSliders.gameObject);
		uIEventListener3.onPress = (UIEventListener.BoolDelegate)Delegate.Combine(uIEventListener3.onPress, new UIEventListener.BoolDelegate(OnUnderPress));
		UIEventListener uIEventListener4 = UIEventListener.Get(restorePurchasesButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<BeanstalkServerManager>.instance.RestoreTransactions();
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(languageButton.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LanguageDialog>.instance, 0f);
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(creditsButton.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<CreditsDialog>.instance, 0f);
		});
		UIEventListener uIEventListener7 = UIEventListener.Get(privacyButton.gameObject);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<PrivacyDialog>.instance, 0f);
		});
		UIEventListener uIEventListener8 = UIEventListener.Get(googlePlayAchievmentsButton);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(GooglePlayAchievementsClick));
		UIEventListener uIEventListener9 = UIEventListener.Get(eaButton.gameObject);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Application.OpenURL("http://www.about-fun.com/warfriends-answershq");
		});
		UIEventListener uIEventListener10 = UIEventListener.Get(bugButton.gameObject);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Application.OpenURL("http://www.about-fun.com/warfriends-reportissue");
		});
		UIEventListener uIEventListener11 = UIEventListener.Get(wikiButton.gameObject);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Application.OpenURL("http://www.about-fun.com/warfriends-wiki");
		});
		UIEventListener uIEventListener12 = UIEventListener.Get(mobcrushButton.gameObject);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Application.OpenURL("http://www.about-fun.com/warfriends-mobcrush");
		});
	}

	private void OnMusicPress(GameObject go, bool clicked)
	{
		if (clicked)
		{
			soundEffectsCollider.enabled = false;
			StopCoutdown();
		}
		else
		{
			StartCoutdown();
			mLastClickedGameObject = go;
		}
	}

	private void OnEffectPress(GameObject go, bool clicked)
	{
		if (clicked)
		{
			musicCollider.enabled = false;
			StopCoutdown();
		}
		else
		{
			StartCoutdown();
			mLastClickedGameObject = go;
		}
	}

	private void OnUnderPress(GameObject go, bool clicked)
	{
		if (clicked)
		{
			if (mLastClickedGameObject != go)
			{
				StopCoutdown();
			}
		}
		else
		{
			StartCoutdown();
			mLastClickedGameObject = go;
		}
	}

	private void GooglePlayAchievementsClick(GameObject go)
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Singleton<GooglePlayGameService>.instance.ShowAchievementsUI();
		}
		else
		{
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	public void InitGUIValues()
	{
		musicSlider.sliderValue = SoundsManager.Instance.musicVolume;
		sfxSlider.sliderValue = SoundsManager.Instance.soundsVolume;
		soundEffectsCollider.enabled = true;
		musicCollider.enabled = true;
		clientVersion.text = string.Format("{0} {1}", Localization.Localize("ID_VERSION"), Singleton<CurrentBundleVersion>.instance.version);
		playerID.text = Localization.LocalizeFormat("ID_PLAYERIDNUMBER", GameLoginManager.currentPlayer.id);
		configsVersion.text = Localization.LocalizeFormat("ID_CONFIGURATIONSVERSION", Singleton<CurrentBundleVersion>.instance.shortVersion, GameConfigurationManager.instance.data.sheetConfiguration);
	}

	public void DoBeforeHide()
	{
		StopCoutdown();
	}

	public void StartCoutdown()
	{
		StopCoutdown();
		mCountdown = RadicalRoutine.Create(Countdown());
		StartCoroutine(RadicalRoutine.Run(mCountdown.enumerator));
	}

	private void StopCoutdown()
	{
		if (mCountdown != null)
		{
			mCountdown.Cancel();
			mCountdown = null;
		}
	}

	private IEnumerator Countdown()
	{
		yield return new WaitForRealSeconds(0.4f);
		soundEffectsCollider.enabled = true;
		musicCollider.enabled = true;
	}
}
