using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine;

public class GooglePlayGameService : Singleton<GooglePlayGameService>
{
	private bool mLoginInProgress;

	private bool mCheckLogout;

	public bool isLoggedIn => PlayGamesPlatform.Instance.IsAuthenticated();

	public event Action<bool> LoggedIn;

	public event Action<bool> LoggedInFromInit;

	public event Action LoggedOut;

	public event Action LoggedOutExternaly;

	public void Init()
	{
		PlayGamesPlatform.Activate();
		PlayGamesClientConfiguration configuration = new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(InvitationDelegate).WithMatchDelegate(MatchDelegate).Build();
		PlayGamesPlatform.InitializeInstance(configuration);
		Debug.Log("GPGS: Silent login attempt.");
		PlayGamesPlatform.Instance.Authenticate(OnAuthenticateFromInit, silent: true);
	}

	private void MatchDelegate(TurnBasedMatch match, bool shouldAutoLaunch)
	{
	}

	private void InvitationDelegate(Invitation invitation, bool shouldAutoAccept)
	{
	}

	private void OnAuthenticateFromInit(bool success)
	{
		Debug.Log("GPGS: Logged In (init), Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
		if (this.LoggedInFromInit != null)
		{
			this.LoggedInFromInit(success);
		}
	}

	private void OnAuthenticate(bool success)
	{
		mLoginInProgress = false;
		Debug.Log("GPGS: Logged In (user action), Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
		if (this.LoggedIn != null)
		{
			this.LoggedIn(success);
		}
	}

	public void LogIn()
	{
		if (mLoginInProgress)
		{
			Debug.LogWarning("GPGS: Log In - already in progress.");
		}
		else if (isLoggedIn)
		{
			if (this.LoggedIn != null)
			{
				this.LoggedIn(obj: true);
			}
		}
		else
		{
			Debug.Log("GPGS: Log In");
			mLoginInProgress = true;
			PlayGamesPlatform.Instance.Authenticate(OnAuthenticate);
		}
	}

	public void LogOut()
	{
		if (PlayGamesPlatform.Instance.IsAuthenticated())
		{
			PlayGamesPlatform.Instance.SignOut();
			Debug.Log("GPGS: Logged Out, Logged: " + PlayGamesPlatform.Instance.IsAuthenticated());
			if (this.LoggedOut != null)
			{
				this.LoggedOut();
			}
		}
		else
		{
			Debug.LogWarning("GPGS: Logged Out called when player isn\t authenticated.");
		}
	}

	public void ShowAchievementsUI()
	{
		mCheckLogout = isLoggedIn && GameLoginManager.instance.data.currentPlayer.isGooglePlayConnected;
		Social.ShowAchievementsUI();
	}

	public void ReportAchievement(string achievementID, double progress, Action<bool> callback)
	{
		if (isLoggedIn)
		{
			Social.ReportProgress(achievementID, progress, callback);
		}
		else
		{
			callback(obj: false);
		}
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		if (!pauseStatus && mCheckLogout)
		{
			mCheckLogout = false;
			if (!isLoggedIn && this.LoggedOutExternaly != null)
			{
				this.LoggedOutExternaly();
			}
		}
	}
}
