using System;
using UnityEngine;

public class MemberSelectRecord : PoolableObject
{
	[Header("Player Info")]
	public PlayerIcon icon;

	public GameObject playerIconButton;

	public UISprite countryIcon;

	public UILabel nameLabel;

	public GameObject playerButton;

	public UILabel rankLabel;

	public UILabel squadName;

	public UISprite rankIcon;

	[Header("Buttons")]
	public UIButton promoteToLeader;

	private DatabasePlayer mPlayer;

	public void Initialize(DatabasePlayer player)
	{
		mPlayer = player;
		nameLabel.text = (string.IsNullOrEmpty(player.name) ? Localization.Localize("ID_ERRORNAME") : player.name);
		TweenColor.Begin(nameLabel.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(player.level);
		rankLabel.text = levelDefinition.displayString;
		rankIcon.spriteName = levelDefinition.iconName;
		squadName.text = ((!string.IsNullOrEmpty(player.squadName)) ? player.squadName : string.Empty);
		string text = GameVariables.CountryCodeSpriteName(player.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			countryIcon.spriteName = text;
		}
		icon.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(player);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(nameLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
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
			icon.avatar = playerTexture;
			icon.UpdateIcon();
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		UIEventListener.Get(promoteToLeader.gameObject).onClick = delegate
		{
			if (mPlayer != null)
			{
				GuiElementSingle<SelectSquadLeaderDialog>.instance.Select(mPlayer);
			}
		};
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener.Get(promoteToLeader.gameObject).onClick = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
		}
		mPlayer = null;
	}
}
