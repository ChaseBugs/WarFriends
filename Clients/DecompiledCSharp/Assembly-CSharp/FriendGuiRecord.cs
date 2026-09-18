using System;
using UnityEngine;

public class FriendGuiRecord : PoolableObject
{
	public BoxCollider boxCollider;

	[Header("Member Content")]
	public GameObject memberContent;

	[Header("-Player Info")]
	public PlayerIcon icon;

	public GameObject playerIconButton;

	public UISprite countryIcon;

	public UILabel nameLabel;

	public GameObject playerButton;

	public UILabel rankLabel;

	public UILabel squadName;

	public GameObject squadButton;

	public UISprite rankIcon;

	public UISprite crownIcon;

	[Header("-Online Status")]
	public UILabel onlineStatus;

	public UISprite onlineIcon;

	[Header("-Button")]
	public GameObject playButton;

	public UILabel playButtonLabel;

	public UISprite playButtonBorder;

	public UISprite playButtonDogTag;

	public UISprite playButtonExclamationMark;

	[Header("Invite Content")]
	public GameObject inviteContent;

	private bool mIsFacebookInvite;

	private DatabasePlayer mPlayer;

	private void OnClick()
	{
		if (mIsFacebookInvite)
		{
			GameLoginManager.instance.InviteFacebookFriends();
		}
		else if (mPlayer != null)
		{
			if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.Type.INVITE)
			{
				bool activeSelf = playButton.activeSelf;
				playButton.SetActive(value: false);
				if (activeSelf)
				{
					GuiElementSingle<SelectFriendsDialog>.instance.Select(mPlayer);
				}
				else
				{
					Debug.Log("Invite was already send, ignoring click.");
				}
			}
			else
			{
				GuiElementSingle<SelectFriendsDialog>.instance.Select(mPlayer);
			}
		}
		else
		{
			Debug.LogError("FriendGuiRecord: Player is null!");
		}
	}

	public void Initialize(DatabasePlayer player)
	{
		SetRecord();
		mPlayer = player;
		nameLabel.text = (string.IsNullOrEmpty(player.name) ? Localization.Localize("ID_ERRORNAME") : player.name);
		TweenColor.Begin(nameLabel.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(player.level);
		rankLabel.text = levelDefinition.displayString;
		rankIcon.spriteName = levelDefinition.iconName;
		squadName.text = ((!string.IsNullOrEmpty(player.squadName)) ? player.squadName : string.Empty);
		TweenColor.Begin(squadName.gameObject, 0f, Color.white);
		string text = GameVariables.CountryCodeSpriteName(player.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			countryIcon.spriteName = text;
		}
		bool flag2 = player.warArenaCrown != WarArenaCrown.None;
		crownIcon.gameObject.SetActive(flag2);
		if (flag2)
		{
			crownIcon.spriteName = GameVariables.crownSprites[player.warArenaCrown];
			crownIcon.MakePixelPerfect();
			float val = nameLabel.transform.localPosition.x + nameLabel.relativeSize.x * nameLabel.transform.localScale.x + 10f;
			crownIcon.transform.localPosition = crownIcon.transform.localPosition.ReplaceX(val);
		}
		icon.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(player);
		PlayerIsOnline(player.GetRealStatus());
		ChangeLook(GuiElementSingle<SelectFriendsDialog>.instance.currentType);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener5 = UIEventListener.Get(squadButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ShowSquad));
		UIEventListener uIEventListener6 = UIEventListener.Get(squadButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ShowSquad));
	}

	public void InitializeInvite()
	{
		SetInvite();
	}

	private void SetRecord()
	{
		mIsFacebookInvite = false;
		memberContent.SetActive(!mIsFacebookInvite);
		inviteContent.SetActive(mIsFacebookInvite);
		boxCollider.center = new Vector3(548f, 0f, -0.5f);
		boxCollider.size = new Vector3(360f, 130f, 1f);
	}

	private void SetInvite()
	{
		mIsFacebookInvite = true;
		memberContent.SetActive(!mIsFacebookInvite);
		inviteContent.SetActive(mIsFacebookInvite);
		boxCollider.center = new Vector3(0f, 0f, -0.5f);
		boxCollider.size = new Vector3(1440f, 130f, 1f);
	}

	private void PlayerIsOnline(PlayerStatus status)
	{
		bool active = true;
		if (GuiElementSingle<SelectFriendsDialog>.instance.currentType == SelectFriendsDialog.Type.INVITE)
		{
			active = !GuiElementSingle<SelectFriendsDialog>.instance.WasPlayerInvited(mPlayer);
		}
		onlineStatus.text = Localization.Localize(GameVariables.playerStatus[status].Value1);
		onlineStatus.color = GameVariables.playerStatus[status].Value2;
		onlineIcon.color = GameVariables.playerStatus[status].Value2;
		playButton.SetActive(active);
	}

	public void ChangeLook(SelectFriendsDialog.Type newType)
	{
		playButtonLabel.text = Localization.Localize((newType != SelectFriendsDialog.Type.INVITE) ? "ID_PLAY" : "ID_INVITE");
		playButtonLabel.pivot = ((newType != SelectFriendsDialog.Type.FIGHT) ? UIWidget.Pivot.Left : UIWidget.Pivot.Center);
		playButtonLabel.transform.localPosition = playButtonLabel.transform.localPosition.ReplaceX((newType != SelectFriendsDialog.Type.FIGHT) ? (-129f) : 0f);
		MiscTools.SetUILabelRescale(playButtonLabel, 47f, 20f, 200);
		playButtonBorder.gameObject.SetActive(newType != SelectFriendsDialog.Type.FIGHT);
		playButtonDogTag.gameObject.SetActive(newType == SelectFriendsDialog.Type.COOP);
		playButtonExclamationMark.gameObject.SetActive(newType == SelectFriendsDialog.Type.INVITE);
	}

	private void ShowSquad(GameObject go)
	{
		if (!string.IsNullOrEmpty(squadName.text))
		{
			TweenColor tweenColor = TweenColor.Begin(squadName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(squadName.text);
		}
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

	public void FreeTexture()
	{
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
			mPlayer = null;
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

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener3 = UIEventListener.Get(squadButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowSquad));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		FreeTexture();
	}
}
