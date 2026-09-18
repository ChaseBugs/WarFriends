using System;
using UnityEngine;

public class GameCenterProvider : Singleton<GameCenterProvider>
{
	public bool canLogoutEventLikeLoginFailed;

	public bool isAuthenticated;

	public string gcName;

	public string gcId;

	public bool hasResponse;

	public event Action<bool> Authenticated;

	protected override void Awake()
	{
		base.Awake();
		hasResponse = false;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		InitEvents();
	}

	public void Authenticate(bool canShowLoginDialog = true)
	{
		Debug.Log("GameCenterManager: Authenticate called - canShowDialog:" + canShowLoginDialog);
		OnAuthenticatedFailure("Not in editor");
	}

	private void InitEvents()
	{
	}

	private void OnPlayerAuthenticationRequired()
	{
		hasResponse = true;
		Debug.Log("GameCenterProvider function OnPlayerAuthenticationRequired() called => Can GC login screen");
		PlayerLoggedOutEvent();
	}

	private void PlayerLoggedOutEvent()
	{
		hasResponse = true;
		Debug.LogError("GameCenterProvider function PlayerLoggedOutEvent() called => GC: Player logged out event - can autenticate fail: " + canLogoutEventLikeLoginFailed);
		if (canLogoutEventLikeLoginFailed)
		{
			isAuthenticated = false;
			gcId = string.Empty;
			gcName = string.Empty;
			if (this.Authenticated != null)
			{
				this.Authenticated(obj: false);
			}
		}
	}

	private void OnAuthenticated()
	{
		hasResponse = true;
		isAuthenticated = true;
		gcId = GetHashedId("123456789");
		gcName = "Slon";
		Debug.LogError("GameCenterProvider function OnAuthenticated() called => GC: Authenticated with " + gcName);
		if (this.Authenticated != null)
		{
			this.Authenticated(obj: true);
		}
	}

	private void OnAuthenticatedFailure(string error)
	{
		hasResponse = true;
		isAuthenticated = false;
		gcId = string.Empty;
		gcName = string.Empty;
		Debug.Log("GameCenterProvider function OnAuthenticatedFailure() called => GC: Authenticated failure " + error);
		if (this.Authenticated != null)
		{
			this.Authenticated(obj: false);
		}
	}

	private string GetHashedId(string playerId)
	{
		return MiscTools.Md5(playerId + "apple");
	}
}
