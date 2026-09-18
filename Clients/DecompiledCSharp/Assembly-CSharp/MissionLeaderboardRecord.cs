using System;
using UnityEngine;

public class MissionLeaderboardRecord : PoolableObject
{
	[Header("Invite")]
	public GameObject invitePart;

	[Header("Content")]
	public GameObject contentPart;

	public UISprite background;

	public UILabel playerPosition;

	public PlayerIcon playerIcon;

	public GameObject playerIconButton;

	public UILabel playerName;

	public GameObject playerButton;

	public UILabel playerScore;

	private DatabasePlayer mPlayer;

	public void InitializeInvite()
	{
		contentPart.SetActive(value: false);
		invitePart.SetActive(value: true);
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			UIEventListener uIEventListener = UIEventListener.Get(invitePart);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate(GameObject go)
			{
				GuiElementSingle<MissionDialog>.instance.InviteFriendsButtonClick(go);
			});
		}
		else
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(invitePart);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate(GameObject go)
			{
				GuiElementSingle<MissionDialog>.instance.ConnectToFacebookButtonClick(go);
			});
		}
	}

	public void InitializePlayer(DatabasePlayerMissionLeaderboard missionLeaderboard, int missionScore, int position)
	{
		contentPart.SetActive(value: true);
		invitePart.SetActive(value: false);
		mPlayer = DatabasePlayer.CreateFromDatabasePlayerMissionLeaderboard(missionLeaderboard);
		playerPosition.text = MiscTools.FormatBigNumber(position);
		background.color = ((!(mPlayer.id == GameLoginManager.currentPlayer.id)) ? Colours.whiteLeaderBoard : Colours.blueLeaderboard);
		playerIcon.Reset();
		if (mPlayer.playerVisuals != null)
		{
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
		}
		SetPlayerName(mPlayer.name);
		playerScore.text = MiscTools.FormatBigNumber(missionScore);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
	}

	private void SetPlayerName(string newName)
	{
		playerName.text = newName;
		TweenColor.Begin(playerName.gameObject, 0f, Color.white);
		MiscTools.SetUILabelRescale(playerName, 30f, 25f);
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id);
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id);
		}
	}

	private void OnPlayerTextureCreated(string playerID, Texture2D playerTexture, bool useBackground)
	{
		if (mPlayer != null && mPlayer.id == playerID)
		{
			playerIcon.avatar = playerTexture;
			playerIcon.UpdateIcon();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener.Get(invitePart).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
		}
		mPlayer = null;
	}
}
