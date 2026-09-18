using System;
using Google2u;
using UnityEngine;

public class MainScreenSocial : Core_BaseScript
{
	[Header("Facebook Connect & Invite")]
	public GameObject facebookButton;

	public GameObject facebookConnectPart;

	public UITable facebookConnectTable;

	public UILabel facebookConnectReward;

	public GameObject facebookClaimedReward;

	public GameObject facebookInvitePart;

	[Header("Grid")]
	public UIGrid grid;

	[Header("-Facebook Like")]
	public GameObject facebookLikeButton;

	public UILabel facebookRewardLabel;

	[Header("-Twitter Follow")]
	public GameObject twitterFollowButton;

	public UILabel twitterRewardLabel;

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (action)
			{
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.CreateGcAccount:
			case DatabaseAction.RemoveFacebook:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				UpdateFacebookConnectButton();
				break;
			case DatabaseAction.AddOneTimeReward:
				InitGUIValues();
				break;
			}
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			if (action == DatabaseAction.AddOneTimeReward)
			{
				InitGUIValues();
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(facebookLikeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FacebookLikeClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(twitterFollowButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(TwitterFollowClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(facebookButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FacebookClick));
		Tweetmanager.RequestFinish += OnRequestFinish;
		Tweetmanager.TweetFinished += OnRequestFinish;
		PlayerAnalytics.instance.AddedOneTimeReward += OnAddOneTimeReward;
	}

	private void OnAddOneTimeReward(string rewardId)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && rewardId == Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY)
		{
			InitGUIValues();
		}
	}

	private void FacebookLikeClick(GameObject go)
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
		Singleton<BeanstalkServerManager>.instance.AddOneTimeReward(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLike))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("FB_Like");
		}
		InitGUIValues();
	}

	private void TwitterFollowClick(GameObject go)
	{
		Singleton<Tweetmanager>.instance.FollowAs();
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("TW_Follow");
		}
		InitGUIValues();
	}

	private void FacebookClick(GameObject go)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("FB_Connect");
		}
	}

	private void OnRequestFinish()
	{
		InitGUIValues();
	}

	public void InitGUIValues()
	{
		UpdateFacebookConnectButton();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			facebookLikeButton.SetActive(value: false);
			twitterFollowButton.SetActive(value: false);
			return;
		}
		facebookLikeButton.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLike));
		facebookRewardLabel.text = MiscTools.FormatFloatNumberSigned(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).FLOATVALUE);
		twitterFollowButton.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow));
		twitterRewardLabel.text = MiscTools.FormatFloatNumberSigned(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE);
		grid.repositionNow = true;
	}

	private void UpdateFacebookConnectButton()
	{
		facebookConnectPart.SetActive(!GameLoginManager.currentPlayer.isFacebookConnected);
		facebookInvitePart.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
			facebookConnectTable.gameObject.SetActive(!flag);
			facebookClaimedReward.SetActive(flag);
			if (!flag)
			{
				facebookConnectReward.text = MiscTools.FormatFloatNumberSigned(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE);
				facebookConnectTable.repositionNow = true;
			}
		}
	}
}
