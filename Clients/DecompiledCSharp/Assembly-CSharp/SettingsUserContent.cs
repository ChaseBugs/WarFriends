using System;
using Google2u;
using UnityEngine;

public class SettingsUserContent : Core_BaseScript
{
	[Header("Guest")]
	public GameObject userGuestPart;

	public UILabel guestPlayerNameLabel;

	public GameObject guestFacebookLoginButton;

	[Header("- Hints")]
	public GameObject guestHintFacebookRewardPart;

	public UILabel guestHintGetGoldLabel;

	public GameObject guestHintFacebookRewardClaimedPart;

	public GameObject guestGooglePlayLoginButton;

	[Header("- Change Country")]
	public GameObject guestChangeCountryButton;

	public UISprite guestCountryIcon;

	[Header("GameCenter")]
	public GameObject userGameCenterPart;

	public PlayerIcon gameCenterPlayerIcon;

	public UILabel gameCenterPlayerNameLabel;

	public GameObject gameCenterChangeNameButton;

	public GameObject gameCenterFacebookLoginButton;

	[Header("- Hints")]
	public GameObject gameCenterHintsForFacebookPart;

	public UITable gameCenterHint1Table;

	public UILabel gameCenterHint1GetGold;

	public UITable gameCenterHint2Table;

	[Header("- Change Country")]
	public GameObject gameCenterChangeCountryButton;

	public UISprite gameCenterCountryIcon;

	[Header("GooglePlay")]
	public GameObject userGooglePlayPart;

	public UILabel googlePlayPlayerNameLabel;

	public GameObject googlePlayChangeNameButton;

	public GameObject googlePlayLogoutButton;

	public GameObject googlePlayFacebookLoginButton;

	[Header("- Hints")]
	public GameObject googlePlayHintsForFacebookPart;

	public UITable googlePlayHint1Table;

	public UILabel googlePlayHint1GetGold;

	public UITable googlePlayHint2Table;

	[Header("- Change Country")]
	public GameObject googlePlayChangeCountryButton;

	public UISprite googlePlayCountryIcon;

	[Header("Facebook")]
	public GameObject userFacebookPart;

	public PlayerIcon facebookPlayerIcon;

	public UILabel facebookPlayerNameLabel;

	public GameObject facebookChangeNameButton;

	public UILabel facebookConnectedLabel;

	public GameObject facebookLogoutButton;

	[Header("- Relogin")]
	public UILabel facebookReloginNeededLabel;

	public GameObject facebookReloginButton;

	[Header("- Google Play Part")]
	public UISprite facebookGooglePlayLine;

	public GameObject facebookGooglePlayLoginButton;

	public UILabel facebookGooglePlayConnectedLabel;

	public GameObject facebookGooglePlayLogoutButton;

	[Header("- Change Country")]
	public GameObject facebookChangeCountryButton;

	public UISprite facebookCountryIcon;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(guestFacebookLoginButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FacebookLoginClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(gameCenterFacebookLoginButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FacebookLoginClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(googlePlayFacebookLoginButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FacebookLoginClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(facebookLogoutButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FacebookLogoutClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(facebookReloginButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FacebookRelogClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(facebookChangeNameButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(RenameClick));
		UIEventListener uIEventListener7 = UIEventListener.Get(gameCenterChangeNameButton);
		uIEventListener7.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener7.onClick, new UIEventListener.VoidDelegate(RenameClick));
		UIEventListener uIEventListener8 = UIEventListener.Get(googlePlayChangeNameButton);
		uIEventListener8.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener8.onClick, new UIEventListener.VoidDelegate(RenameClick));
		UIEventListener uIEventListener9 = UIEventListener.Get(guestChangeCountryButton);
		uIEventListener9.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener9.onClick, new UIEventListener.VoidDelegate(ChangeCountryClick));
		UIEventListener uIEventListener10 = UIEventListener.Get(gameCenterChangeCountryButton);
		uIEventListener10.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener10.onClick, new UIEventListener.VoidDelegate(ChangeCountryClick));
		UIEventListener uIEventListener11 = UIEventListener.Get(googlePlayChangeCountryButton);
		uIEventListener11.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener11.onClick, new UIEventListener.VoidDelegate(ChangeCountryClick));
		UIEventListener uIEventListener12 = UIEventListener.Get(facebookChangeCountryButton);
		uIEventListener12.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener12.onClick, new UIEventListener.VoidDelegate(ChangeCountryClick));
		UIEventListener uIEventListener13 = UIEventListener.Get(guestGooglePlayLoginButton);
		uIEventListener13.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener13.onClick, new UIEventListener.VoidDelegate(GooglePlayLoginClick));
		UIEventListener uIEventListener14 = UIEventListener.Get(facebookGooglePlayLoginButton);
		uIEventListener14.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener14.onClick, new UIEventListener.VoidDelegate(GooglePlayLoginClick));
		UIEventListener uIEventListener15 = UIEventListener.Get(googlePlayLogoutButton);
		uIEventListener15.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener15.onClick, new UIEventListener.VoidDelegate(GooglePlayLogoutClick));
		UIEventListener uIEventListener16 = UIEventListener.Get(facebookGooglePlayLogoutButton);
		uIEventListener16.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener16.onClick, new UIEventListener.VoidDelegate(GooglePlayLogoutClick));
	}

	private void FacebookLoginClick(GameObject go)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToFacebook();
		}
	}

	private void FacebookLogoutClick(GameObject go)
	{
		GameLoginManager.instance.LogoutFromFacebook(clientOnly: false);
	}

	private void FacebookRelogClick(GameObject go)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.RelogToFacebook();
		}
	}

	private void RenameClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<RenameDialog>.instance, 0f);
	}

	private void ChangeCountryClick(GameObject go)
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ChangeCountryDialog>.instance, 0f);
	}

	private void GooglePlayLoginClick(GameObject go)
	{
		if (GuiElementSingle<SettingsDialog>.instance.isFullyShowed && !GameLoginManager.currentPlayer.isGooglePlayConnected)
		{
			GuiElementSingle<SettingsDialog>.instance.HideDialog();
			GameLoginManager.instance.LoginToGoogle();
		}
	}

	private void GooglePlayLogoutClick(GameObject go)
	{
		GameLoginManager.instance.LogoutFromGooglePlay(clientOnly: false);
	}

	public void InitGUIValues()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string spriteName = GameVariables.CountryCodeSpriteName(currentPlayer.country);
		userGuestPart.SetActive(value: false);
		userFacebookPart.SetActive(value: false);
		userGameCenterPart.SetActive(value: false);
		userGooglePlayPart.SetActive(value: false);
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
		if (!currentPlayer.isFacebookConnected && !currentPlayer.isGameCenterConnected && !currentPlayer.isGooglePlayConnected)
		{
			userGuestPart.SetActive(value: true);
			guestPlayerNameLabel.text = string.Format("{0} {1}", Localization.Localize("ID_GUESTACCOUNT"), currentPlayer.name);
			guestHintFacebookRewardPart.SetActive(!flag);
			guestHintFacebookRewardClaimedPart.SetActive(flag);
			guestCountryIcon.spriteName = spriteName;
			if (!flag)
			{
				guestHintGetGoldLabel.text = MiscTools.FormatBigNumber(num);
			}
		}
		if (currentPlayer.isFacebookConnected)
		{
			userFacebookPart.SetActive(value: true);
			Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.currentPlayer, useBackground: false);
			facebookPlayerIcon.avatar = Singleton<ArmyPreviewCamera>.instance.player1Texture;
			facebookPlayerNameLabel.text = currentPlayer.name;
			facebookCountryIcon.spriteName = spriteName;
			facebookConnectedLabel.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			facebookLogoutButton.gameObject.SetActive(GameLoginManager.instance.IsLoggedToFacebook);
			facebookReloginNeededLabel.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			facebookReloginButton.gameObject.SetActive(!GameLoginManager.instance.IsLoggedToFacebook);
			facebookGooglePlayLine.gameObject.SetActive(value: true);
			facebookGooglePlayLoginButton.gameObject.SetActive(!currentPlayer.isGooglePlayConnected);
			facebookGooglePlayConnectedLabel.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
			facebookGooglePlayLogoutButton.gameObject.SetActive(currentPlayer.isGooglePlayConnected);
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGameCenterConnected)
		{
			userGameCenterPart.SetActive(value: true);
			gameCenterPlayerIcon.avatar = Singleton<ArmyPreviewCamera>.instance.player1Texture;
			gameCenterPlayerNameLabel.text = currentPlayer.name;
			gameCenterHintsForFacebookPart.SetActive(!flag);
			gameCenterCountryIcon.spriteName = spriteName;
			if (!flag)
			{
				gameCenterHint1Table.repositionNow = true;
				gameCenterHint1GetGold.text = MiscTools.FormatBigNumber(num);
				gameCenterHint2Table.repositionNow = true;
			}
		}
		if (!currentPlayer.isFacebookConnected && currentPlayer.isGooglePlayConnected)
		{
			userGooglePlayPart.SetActive(value: true);
			googlePlayPlayerNameLabel.text = currentPlayer.name;
			googlePlayHintsForFacebookPart.SetActive(!flag);
			googlePlayCountryIcon.spriteName = spriteName;
			if (!flag)
			{
				googlePlayHint1Table.repositionNow = true;
				googlePlayHint1GetGold.text = MiscTools.FormatBigNumber(num);
				googlePlayHint2Table.repositionNow = true;
			}
		}
	}

	public void DoAfterHide()
	{
		facebookPlayerIcon.Reset();
		gameCenterPlayerIcon.Reset();
	}
}
