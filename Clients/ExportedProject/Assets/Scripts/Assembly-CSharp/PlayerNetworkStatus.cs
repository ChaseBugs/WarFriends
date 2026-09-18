using System;
using UnityEngine;

public class PlayerNetworkStatus
{
	public enum ConnectionState
	{
		Connected,
		Disconnected
	}

	public enum MatchState
	{
		ConnectingToPhoton,
		Connected,
		CardsChosen,
		GameLoading,
		LoadingFinished,
		Playing,
		GameFinished,
		Rematch
	}

	private ConnectionState mConnectionState;

	private ConnectionState mPreviousConnectionState;

	private MatchState mMatchState;

	private bool mStartAnimationFinished;

	private bool mConnectionOff;

	public PlayerController owner { get; private set; }

	public bool connectionOff
	{
		get
		{
			bool flag = owner.isCurrentPlayer && CachedApplicationInternetReachability.internetReachability == NetworkReachability.NotReachable;
			if (flag != mConnectionOff)
			{
				mConnectionOff = flag;
				Debug.Log($"Internet off: {flag} {DateTime.UtcNow}");
			}
			return flag;
		}
	}

	public bool disconected => connectionOff || connectionState == ConnectionState.Disconnected;

	public bool startAnimationFinished
	{
		get
		{
			return mStartAnimationFinished;
		}
		set
		{
			mStartAnimationFinished = value;
		}
	}

	public int stateCounter { get; set; }

	public bool active { get; set; }

	public bool canRematch => mConnectionState == ConnectionState.Connected && matchState >= MatchState.GameFinished;

	public int reconnectsCount { get; private set; }

	public int pausesCount { get; set; }

	public MatchState matchState
	{
		get
		{
			return mMatchState;
		}
		set
		{
			mMatchState = value;
			Debug.Log($"Player match state {mMatchState} to player {owner.name}");
			if (PlayerNetworkStatus.MatchStateChanged != null)
			{
				PlayerNetworkStatus.MatchStateChanged(mMatchState, owner);
			}
		}
	}

	public ConnectionState connectionState
	{
		get
		{
			return mConnectionState;
		}
		set
		{
			if (mConnectionState != value)
			{
				mPreviousConnectionState = mConnectionState;
				mConnectionState = value;
				Debug.Log($"Player connectionState {mConnectionState} to player {owner.name}");
				if (value == ConnectionState.Disconnected)
				{
					reconnectsCount++;
				}
			}
		}
	}

	public static event Action<MatchState, PlayerController> MatchStateChanged;

	public PlayerNetworkStatus(PlayerController owner)
	{
		this.owner = owner;
	}

	public void Reset()
	{
		matchState = MatchState.ConnectingToPhoton;
		mConnectionState = ConnectionState.Connected;
		mPreviousConnectionState = ConnectionState.Connected;
		startAnimationFinished = false;
		stateCounter = 0;
		active = true;
		reconnectsCount = 0;
		pausesCount = 0;
		mConnectionOff = false;
	}

	public bool SetState(MatchState state, int stateCounter)
	{
		if (stateCounter > this.stateCounter)
		{
			this.stateCounter = stateCounter;
			matchState = state;
			return true;
		}
		Debug.LogError($"Error setting match state {state} to player {owner.name}");
		return false;
	}

	public void IncreaseDisconnects()
	{
		reconnectsCount++;
	}
}
