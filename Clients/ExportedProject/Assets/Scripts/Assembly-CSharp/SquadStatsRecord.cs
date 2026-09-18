using System;
using UnityEngine;

public class SquadStatsRecord : PoolableObject
{
	[Header("Header Part")]
	public UILabel headerLabel;

	[Header("Statistic Part")]
	public GameObject statsPart;

	public UISprite iconStat;

	public UILabel statLabel;

	[Header("Player Part")]
	public GameObject playerPart;

	public PlayerIcon playerIcon;

	public GameObject playerIconButton;

	public UILabel playerLabel;

	public GameObject playerButton;

	public UILabel playerStatLabel;

	private DatabasePlayer mPlayer;

	public void InitializeSquadStat(SquadStatsContent.SquadStatInternal squadStat)
	{
		bool flag = squadStat.type == SquadStatsContent.SquadStatInternal.StatType.PlayerInt || squadStat.type == SquadStatsContent.SquadStatInternal.StatType.PlayerFloat || squadStat.type == SquadStatsContent.SquadStatInternal.StatType.PlayerPercent;
		statsPart.SetActive(!flag);
		playerPart.SetActive(flag);
		headerLabel.text = squadStat.title;
		MiscTools.SetUILabelRescale(headerLabel, (!flag) ? 37f : 30f, 20f, 500);
		mPlayer = ((!flag) ? null : squadStat.player);
		if (flag)
		{
			playerLabel.text = mPlayer.name;
			TweenColor.Begin(playerLabel.gameObject, 0f, Color.white);
			MiscTools.SetUILabelRescale(playerLabel, 37f, 26f);
			playerIcon.Reset();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
			playerStatLabel.color = squadStat.textColor;
			switch (squadStat.type)
			{
			case SquadStatsContent.SquadStatInternal.StatType.PlayerInt:
				playerStatLabel.text = ((squadStat.number >= 0) ? MiscTools.FormatBigNumber(squadStat.number) : "-");
				break;
			case SquadStatsContent.SquadStatInternal.StatType.PlayerFloat:
				playerStatLabel.text = ((!(squadStat.floatNumber < 0f)) ? MiscTools.FormatFloatNumberRoundOne(squadStat.floatNumber) : "-");
				break;
			case SquadStatsContent.SquadStatInternal.StatType.PlayerPercent:
				playerStatLabel.text = ((squadStat.number >= 0) ? MiscTools.FormatNumberAsPercent(squadStat.number) : "-");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
			UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
			UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
			UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		}
		else
		{
			iconStat.alpha = 0f;
			statLabel.color = squadStat.textColor;
			switch (squadStat.type)
			{
			case SquadStatsContent.SquadStatInternal.StatType.PictureInt:
			{
				iconStat.spriteName = squadStat.spriteName;
				iconStat.color = squadStat.spriteColor;
				iconStat.MakePixelPerfect();
				float multiplier = Mathf.Min(90f / iconStat.transform.localScale.x, 90f / iconStat.transform.localScale.y);
				iconStat.transform.localScale = iconStat.transform.localScale.MultiplyXY(multiplier);
				statLabel.text = ((squadStat.number >= 0) ? MiscTools.FormatBigNumber(squadStat.number) : "-");
				break;
			}
			case SquadStatsContent.SquadStatInternal.StatType.SimpleInt:
				statLabel.text = ((squadStat.number >= 0) ? MiscTools.FormatBigNumber(squadStat.number) : "-");
				break;
			case SquadStatsContent.SquadStatInternal.StatType.SimpleFloat:
				statLabel.text = ((!(squadStat.floatNumber < 0f)) ? MiscTools.FormatFloatNumberRoundOne(squadStat.floatNumber) : "-");
				break;
			case SquadStatsContent.SquadStatInternal.StatType.PlayerInt:
			case SquadStatsContent.SquadStatInternal.StatType.PlayerFloat:
			case SquadStatsContent.SquadStatInternal.StatType.PlayerPercent:
				break;
			}
		}
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(playerLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
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
		FreeTexture();
	}

	public void FreeTexture()
	{
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
		}
		mPlayer = null;
	}
}
