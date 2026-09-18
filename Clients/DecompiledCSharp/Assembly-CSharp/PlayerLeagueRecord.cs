using System;
using UnityEngine;

public class PlayerLeagueRecord : PoolableObject
{
	[Header("Core")]
	public UIButtonSetter widthSetter;

	[Header("Header Part")]
	public GameObject headerPart;

	public UISprite headerBackground;

	public UISprite headerLeagueIcon;

	public UITable headerTable;

	public UISprite headerMedalsIcon;

	public UILabel headerText;

	[Header("Reward Part")]
	public GameObject rewardPart;

	public UILabel goldRewardLabel;

	[Header("No Reward Part")]
	public GameObject noRewardPart;

	[Header("Player Part")]
	public GameObject playerPart;

	public UISprite playerBackground;

	public UISprite highlight;

	[Header("-Info Left")]
	public UILabel position;

	public PlayerIcon playerIcon;

	public GameObject playerIconButton;

	public UISprite playerCountry;

	public UISprite playerRankIcon;

	public UILabel playerRankNumber;

	public UITable playerNameTable;

	public UILabel playerName;

	public GameObject crownPart;

	public UISprite crownIcon;

	public GameObject playerOnline;

	public GameObject playerButton;

	public UILabel playerSquadName;

	public GameObject squadButton;

	[Header("-Info Right")]
	public UILabel armyPower;

	public UILabel weeklyMedals;

	private DatabasePlayer mPlayer;

	public void InitializeRecord(LeagueContent.LeagueRecord recordToShow, float width)
	{
		widthSetter.SetWidth(width);
		headerPart.SetActive(recordToShow.type == LeagueContent.Type.Header);
		rewardPart.SetActive(recordToShow.type == LeagueContent.Type.HeaderReward);
		noRewardPart.SetActive(recordToShow.type == LeagueContent.Type.HeaderNoReward);
		playerPart.SetActive(recordToShow.type == LeagueContent.Type.Player);
		mPlayer = ((recordToShow.type != LeagueContent.Type.Player) ? null : recordToShow.player);
		if (recordToShow.type == LeagueContent.Type.Player)
		{
			bool flag = mPlayer.id == GameLoginManager.currentPlayer.id;
			int num = (int)width - 812 + 41;
			highlight.color = Singleton<GameVariables>.instance.LeagueColorHighlight(recordToShow.colorType).ReplaceA((!flag) ? 0f : 1f);
			position.color = Singleton<GameVariables>.instance.LeagueColorPosition(recordToShow.colorType);
			playerBackground.color = Singleton<GameVariables>.instance.LeagueColorBackground(recordToShow.colorType);
			weeklyMedals.color = Singleton<GameVariables>.instance.LeagueColorMedals(recordToShow.colorType);
			position.text = MiscTools.FormatNumberToOrdinalPoint(recordToShow.position);
			playerIcon.Reset();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
			string text = GameVariables.CountryCodeSpriteName(mPlayer.country);
			bool flag2 = !string.IsNullOrEmpty(text);
			playerCountry.gameObject.SetActive(flag2);
			if (flag2)
			{
				playerCountry.spriteName = text;
			}
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(mPlayer.level);
			playerRankIcon.spriteName = levelDefinition.iconName;
			playerRankNumber.text = levelDefinition.displayString;
			bool flag3 = mPlayer.GetRealStatus() != PlayerStatus.Offline;
			playerOnline.SetActive(flag3);
			if (flag3)
			{
				num -= 41;
			}
			bool flag4 = mPlayer.warArenaCrown != WarArenaCrown.None;
			crownPart.SetActive(flag4);
			if (flag4)
			{
				num -= 40;
				crownIcon.spriteName = GameVariables.crownSprites[mPlayer.warArenaCrown];
				crownIcon.MakePixelPerfect();
				float multiplier = Mathf.Min(30f / crownIcon.transform.localScale.x, 40f / crownIcon.transform.localScale.y);
				crownIcon.transform.localScale = crownIcon.transform.localScale.MultiplyXY(multiplier);
			}
			playerName.text = mPlayer.name;
			TweenColor.Begin(playerName.gameObject, 0f, Color.white);
			MiscTools.SetUILabelRescale(playerName, 37f, 20f, num);
			playerNameTable.repositionNow = true;
			if (string.IsNullOrEmpty(mPlayer.squadName))
			{
				playerSquadName.text = string.Empty;
			}
			else
			{
				playerSquadName.text = mPlayer.squadName;
				UIEventListener uIEventListener = UIEventListener.Get(squadButton);
				uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowSquad));
				UIEventListener uIEventListener2 = UIEventListener.Get(squadButton);
				uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowSquad));
			}
			TweenColor.Begin(playerSquadName.gameObject, 0f, Color.white);
			armyPower.text = MiscTools.FormatBigNumber(mPlayer.armyPowerX10);
			weeklyMedals.text = MiscTools.FormatMedalsDifference(mPlayer.medalsBalance);
			UIEventListener uIEventListener3 = UIEventListener.Get(playerIconButton);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
			UIEventListener uIEventListener4 = UIEventListener.Get(playerIconButton);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
			UIEventListener uIEventListener5 = UIEventListener.Get(playerButton);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
			UIEventListener uIEventListener6 = UIEventListener.Get(playerButton);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		}
		else if (recordToShow.type == LeagueContent.Type.HeaderReward)
		{
			goldRewardLabel.text = MiscTools.FormatBigNumber(recordToShow.goldReward);
		}
		else
		{
			if (recordToShow.type == LeagueContent.Type.HeaderNoReward)
			{
				return;
			}
			headerLeagueIcon.spriteName = GameVariables.leagueNames[recordToShow.showLeague].Value2;
			if (recordToShow.colorType == LeagueType.Promote || recordToShow.colorType == LeagueType.Top)
			{
				if (recordToShow.position == 1)
				{
					bool flag5 = recordToShow.position < recordToShow.myPosition;
					string text2 = ((recordToShow.colorType != LeagueType.Top) ? Colours.stringGreenLeague : Colours.stringYellowLeague);
					headerMedalsIcon.gameObject.SetActive(flag5);
					headerText.text = ((!flag5) ? (text2 + Localization.Localize("ID_LEAGUETOPPOSITIONHINT")) : Localization.LocalizeFormat("ID_LEAGUEPROMOTEHINT", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals + 1), text2));
				}
				else if (recordToShow.position <= recordToShow.myPosition)
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT1", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals + 1), Colours.stringGreenLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
				else
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT2", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals - 1), Colours.stringGreenLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
			}
			else if (recordToShow.colorType == LeagueType.Demote)
			{
				headerMedalsIcon.gameObject.SetActive(value: true);
				if (recordToShow.position <= recordToShow.myPosition)
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUEDEMOTEHINT1", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals + 1), Colours.stringRedLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
				else
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUEDEMOTEHINT2", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals - 1), Colours.stringRedLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
			}
			else
			{
				headerMedalsIcon.gameObject.SetActive(value: true);
				if (recordToShow.position <= recordToShow.myPosition)
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT1", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals + 1), Colours.stringYellowLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
				else
				{
					headerText.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT2", MiscTools.FormatMedalsDifference(recordToShow.requiredMedals - 1), Colours.stringYellowLeague, GameVariables.leagueNames[recordToShow.hintLeague].Value1);
				}
			}
			headerBackground.color = Singleton<GameVariables>.instance.LeagueColorBackground(recordToShow.colorType);
			headerTable.repositionNow = true;
			headerTable.onReposition = delegate
			{
				float num2 = Mathf.Abs(headerText.transform.parent.transform.localPosition.x);
				headerTable.transform.localPosition = headerTable.transform.localPosition.ReplaceX(0f - num2 - 40f);
			};
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

	private void ShowSquad(GameObject go)
	{
		if (!string.IsNullOrEmpty(playerSquadName.text))
		{
			TweenColor tweenColor = TweenColor.Begin(playerSquadName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(playerSquadName.text);
		}
	}

	private void ShowPlayer(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			TweenColor tweenColor = TweenColor.Begin(playerName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (mPlayer.id.StartsWith("bot"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(mPlayer.name, DatabasePlayerInfo.CreateBot(mPlayer));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id);
			}
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mPlayer.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (mPlayer.id.StartsWith("bot"))
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(mPlayer.name, DatabasePlayerInfo.CreateBot(mPlayer));
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mPlayer.name, mPlayer.id);
			}
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
		UIEventListener uIEventListener3 = UIEventListener.Get(squadButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowSquad));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		FreeTexture();
	}
}
