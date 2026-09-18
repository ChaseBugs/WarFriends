using System;
using UnityEngine;

public class SquadWarEndMemberRecord : PoolableObject
{
	[Header("Header Part")]
	public GameObject headerPart;

	public UILabel positionsLabel;

	public UILabel goldRewardLabel;

	[Header("Player Part")]
	public GameObject playerPart;

	public UILabel position;

	public PlayerIcon playerIcon;

	public GameObject playerIconButton;

	public UILabel playerName;

	public GameObject playerButton;

	public UILabel squadPoints;

	public UISprite highlight;

	private DatabasePlayer mPlayer;

	public void Initialize(SquadWarsContent.SquadMemberInternal data)
	{
		headerPart.SetActive(data.isHeader);
		playerPart.SetActive(!data.isHeader);
		if (data.isHeader)
		{
			mPlayer = null;
			positionsLabel.text = Localization.LocalizeFormat("ID_POSITIONXY", Colours.stringBlue, data.positionString);
			goldRewardLabel.text = MiscTools.FormatBigNumber(data.reward);
			UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
			UIEventListener uIEventListener2 = UIEventListener.Get(playerButton);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
			return;
		}
		mPlayer = data.player;
		position.text = MiscTools.FormatNumberToOrdinalPoint(data.position);
		playerIcon.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
		playerName.text = mPlayer.name;
		TweenColor.Begin(playerName.gameObject, 0f, Color.white);
		MiscTools.SetUILabelRescale(playerName, 30f, 17f);
		squadPoints.text = MiscTools.FormatBigNumber(mPlayer.squadPoints);
		MiscTools.SetUILabelRescale(squadPoints, 37f, 20f, 84);
		highlight.alpha = ((!(mPlayer.id == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener3 = UIEventListener.Get(playerIconButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerIconButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener5 = UIEventListener.Get(playerButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener6 = UIEventListener.Get(playerButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id);
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
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
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
		}
		mPlayer = null;
	}
}
