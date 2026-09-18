using System;
using System.Collections.Generic;
using Prime31;
using UnityEngine;

public class FacebookService
{
	public class Friend
	{
		public long hashedId;

		public string name;

		public string id;
	}

	public List<Friend> facebookFriends;

	public Dictionary<long, Friend> friendsDictionary;

	private string mFacebookName;

	private long mFacebookId;

	private string mFacebookPassword;

	public bool initialized;

	public static event Action<Friend> FacebookFriendUpdated;

	public static event Action FacebookLoginFailedAfterTutorial;

	public FacebookService()
	{
		facebookFriends = new List<Friend>();
		friendsDictionary = new Dictionary<long, Friend>();
		mFacebookId = -1L;
		FacebookManager.sessionOpenedEvent += FacebookManagerOnSessionOpenedEvent;
		FacebookManager.loginFailedEvent += OnLoginFailedEvent;
		FacebookManager.shareDialogFailedEvent += OnShareDialogErrorEvent;
		FacebookManager.shareDialogSucceededEvent += OnShareDialogSucceededEvent;
		FacebookManager.fetchDeferredAppLinkFailedEvent += OnFetchDeferredAppLinkFailedEvent;
		FacebookManager.fetchDeferredAppLinkSucceededEvent += OnFetchDeferredAppLinkSucceededEvent;
	}

	private void OnFetchDeferredAppLinkSucceededEvent(Dictionary<string, object> dict)
	{
		Debug.Log("OnFetchDeferredAppLinkSucceededEvent");
		Utils.logObject(dict);
	}

	private void OnFetchDeferredAppLinkFailedEvent(P31Error error)
	{
		Debug.LogError("OnFetchDeferredAppLinkFailedEvent: " + error);
	}

	internal static void ClearTutorialEvent()
	{
		FacebookService.FacebookLoginFailedAfterTutorial = null;
	}

	private void OnShareDialogSucceededEvent(string dict)
	{
		Debug.Log("Facebook Service: share dialog succeeded. Obsah dict = " + dict);
	}

	private void OnShareDialogErrorEvent(P31Error reason)
	{
		Debug.Log("Facebook Service: Share dialog failed. Reason = " + reason.message);
	}

	~FacebookService()
	{
		FacebookManager.sessionOpenedEvent -= FacebookManagerOnSessionOpenedEvent;
		FacebookManager.loginFailedEvent -= OnLoginFailedEvent;
		FacebookManager.shareDialogFailedEvent -= OnShareDialogErrorEvent;
		FacebookManager.shareDialogSucceededEvent -= OnShareDialogSucceededEvent;
	}

	private void OnLoginFailedEvent(P31Error p31Error)
	{
		ConfirmDialog.ShowAlert(delegate(ConfirmDialog dialog, bool b)
		{
			Debug.Log("Shown facebook login failed dialog");
			if (b)
			{
				Debug.Log("Clicked on facebook login failed");
				if (FacebookService.FacebookLoginFailedAfterTutorial != null)
				{
					Debug.Log("Calling callback and setting it to null!!");
					FacebookService.FacebookLoginFailedAfterTutorial();
					FacebookService.FacebookLoginFailedAfterTutorial = null;
				}
				else
				{
					Debug.LogError("CLICKED OK BUT NO CALLBACK WAS SET UP!!");
				}
			}
		}, Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED"), Localization.Localize("ID_CONFIRM_FBLOGINCANCELLED_TEXT"));
		Debug.LogError("Facebook login failed: " + p31Error);
		if (IsLoggedToFacebook())
		{
			Debug.Log("facebook login failed, but still is logged in, logout manualy");
			FacebookAndroid.logout();
		}
	}

	private void FacebookManagerOnSessionOpenedEvent()
	{
		mFacebookName = string.Empty;
		mFacebookId = -1L;
		Debug.Log("FacebookManagerOnSessionOpenedEvent");
		Utils.logObject(FacebookAndroid.getSessionPermissions());
		Facebook.instance.getFriends(OnGetFriends);
		Facebook.instance.getMe(OnGetMe);
	}

	public void inviteFriends()
	{
		string appLink = Singleton<BeanstalkServerManager>.instance.appLink;
		FacebookAndroid.showAppInviteDialog(appLink);
	}

	public void RefreshFriends()
	{
		Facebook.instance.getFriends(OnGetFriends);
	}

	private void OnGetFriends(string s, FacebookFriendsResult facebookFriendsResult)
	{
		facebookFriends = new List<Friend>();
		if (facebookFriendsResult == null)
		{
			Debug.Log(string.Concat(GetType(), "null facebook friends"));
			return;
		}
		foreach (FacebookFriend datum in facebookFriendsResult.data)
		{
			Friend friend = new Friend();
			friend.hashedId = GetFbId(datum.id);
			friend.name = datum.name.Substring(0, Math.Min(25, datum.name.Length));
			friend.id = datum.id;
			Friend friend2 = friend;
			facebookFriends.Add(friend2);
			friendsDictionary[friend2.hashedId] = friend2;
		}
		facebookFriends.Sort((Friend a, Friend b) => string.Compare(a.name, b.name, StringComparison.InvariantCulture));
		int count = facebookFriends.Count;
		if (count > 20)
		{
			facebookFriends.RemoveRange(20, count - 20);
		}
		GameLoginManager.instance.OnFriendsLoaded();
	}

	private static long GetFbId(string id)
	{
		return MiscTools.SimpleHash(long.Parse(id));
	}

	public bool CheckFacebookAfterTutorial()
	{
		if (IsLoggedToFacebook())
		{
			if (mFacebookId != -1)
			{
				Singleton<BeanstalkServerManager>.instance.AddFacebookToCustomAccount(mFacebookId, mFacebookName, mFacebookPassword);
				return true;
			}
			return false;
		}
		return false;
	}

	private void OnGetMe(string s, FacebookMeResult facebookMeResult)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (facebookMeResult == null)
		{
			Debug.Log(string.Concat(GetType(), " null FacebookMeResult"));
			if (IsLoggedToFacebook())
			{
				Debug.Log("facebook get me data, but still is logged in, logout manualy");
				FacebookAndroid.logout();
			}
			if (currentPlayer != null && currentPlayer.facebookId != -1)
			{
				Debug.Log("Removing facebook from current player!!");
				Singleton<BeanstalkServerManager>.instance.RemoveFacebook();
			}
			else
			{
				Debug.LogError("NOT REMOVING FACEBOOK FROM CURRENTPLAYER");
			}
			return;
		}
		mFacebookName = facebookMeResult.name;
		mFacebookId = GetFbId(facebookMeResult.id);
		Debug.Log("GameLoginManager: Facebook Logged");
		mFacebookPassword = MiscTools.Md5(facebookMeResult.id);
		if (currentPlayer != null)
		{
			if (currentPlayer.facebookId == -1)
			{
				Debug.Log("GLM: Add FB to custom account");
				if (!Singleton<GameController>.instance.isTutorialInProgressOrPlaned)
				{
					Singleton<BeanstalkServerManager>.instance.AddFacebookToCustomAccount(mFacebookId, facebookMeResult.name, mFacebookPassword);
				}
			}
			else if (currentPlayer.facebookId == mFacebookId)
			{
				Debug.Log("relog OK");
			}
			else
			{
				Debug.Log("relog to different facebook");
				Singleton<BeanstalkServerManager>.instance.ExistFacebookAccount(mFacebookId, mFacebookPassword);
			}
		}
		else
		{
			Debug.LogError("GLM: current player is null while adding FB account!!");
		}
	}

	public void InitLibrary()
	{
		if (!initialized)
		{
			initialized = true;
			FacebookAndroid.init();
			Debug.Log("facebook init!!! " + IsLoggedToFacebook());
			if (IsLoggedToFacebook())
			{
				Debug.Log("FB: Calling On SessionOpenedEvent Manually");
				FacebookManagerOnSessionOpenedEvent();
			}
		}
	}

	public bool IsLoggedToFacebook()
	{
		return FacebookAndroid.isSessionValid();
	}

	public void LoginToFacebook()
	{
		string[] permissions = new string[1] { "user_friends" };
		Debug.Log("Game Login Manager: Login to FB");
		FacebookAndroid.loginWithReadPermissions(permissions);
	}

	public void LogoutFromFacebook(bool clientOnly)
	{
		FacebookAndroid.logout();
		mFacebookId = -1L;
		friendsDictionary.Clear();
		facebookFriends.Clear();
		if (!clientOnly)
		{
			GameLoginManager.instance.FacebookLogout();
		}
	}
}
