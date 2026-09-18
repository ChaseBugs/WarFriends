using System;
using UnityEngine;

public class LeaderboardRecord : PoolableObject
{
	[Header("Both")]
	public UIButtonSetter widthSetter;

	public UISprite highlight;

	public UILabel positionLabel;

	public UILabel medalsLabel;

	[Header("Player Part")]
	public GameObject playerPart;

	public PlayerIcon playerIcon;

	public GameObject playerIconButton;

	public UISprite countryFlag;

	public UILabel playerName;

	public GameObject playerButton;

	public UISprite crownIcon;

	public UISprite rankIcon;

	public UILabel rankNumber;

	public UILabel playerSquadName;

	public GameObject playerSquadButton;

	public UILabel armyPowerValue;

	public UISprite playerLeagueIcon;

	public UILabel playerLeagueName;

	[Header("Squad Part")]
	public GameObject squadButton;

	public GameObject squadPart;

	public UITexture squadIconTexture;

	public UILabel squadName;

	public UILabel squadRank;

	public UILabel squadMembers;

	private DatabasePlayer mPlayer;

	private DatabasePlayerData mPlayerData;

	public void InitializePlayer(DatabasePlayerData player, int pos, float width)
	{
		mPlayerData = player;
		mPlayer = DatabasePlayer.CreateFromDatabasePlayerData(player);
		widthSetter.SetWidth(width);
		if (pos < 1)
		{
			positionLabel.text = "?";
		}
		else if (pos > 100)
		{
			positionLabel.text = "100+.";
		}
		else
		{
			positionLabel.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		}
		playerPart.SetActive(value: true);
		squadPart.SetActive(value: false);
		playerIcon.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(mPlayer);
		string text = GameVariables.CountryCodeSpriteName(player.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryFlag.gameObject.SetActive(flag);
		if (flag)
		{
			countryFlag.spriteName = text;
		}
		playerName.text = player.name;
		TweenColor.Begin(playerName.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(player.level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankNumber.text = levelDefinition.displayString;
		bool flag2 = player.warArenaCrown != WarArenaCrown.None;
		crownIcon.gameObject.SetActive(flag2);
		if (flag2)
		{
			crownIcon.spriteName = GameVariables.crownSprites[player.warArenaCrown];
			crownIcon.MakePixelPerfect();
			float x = playerName.transform.localPosition.x;
			x += playerName.relativeSize.x * playerName.transform.localScale.x;
			x += 10f + crownIcon.transform.localScale.x / 2f;
			crownIcon.transform.localPosition = crownIcon.transform.localPosition.ReplaceX(x);
		}
		playerSquadName.text = ((!string.IsNullOrEmpty(player.squadId)) ? player.squadId : string.Empty);
		TweenColor.Begin(playerSquadName.gameObject, 0f, Color.white);
		armyPowerValue.text = MiscTools.FormatBigNumber(player.armyPowerX10);
		MiscTools.SetUILabelRescale(armyPowerValue, 37f, 28f, 100);
		if (player.isInBeginnersLeague)
		{
			int beginnersLeague = player.beginnersLeague;
			playerLeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.transform.localScale = playerLeagueIcon.transform.localScale.MultiplyXY(0.8f);
			playerLeagueIcon.alpha = 1f;
			playerLeagueName.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
		}
		else
		{
			League leagueTier = player.leagueTier;
			bool isInLeague = player.isInLeague;
			playerLeagueIcon.spriteName = GameVariables.leagueNames[leagueTier].Value2;
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.transform.localScale = playerLeagueIcon.transform.localScale.MultiplyXY(0.8f);
			playerLeagueIcon.alpha = ((!isInLeague) ? 0.5f : 1f);
			playerLeagueName.text = ((!isInLeague) ? Localization.Localize("ID_NA") : GameVariables.leagueNames[leagueTier].Value1);
		}
		medalsLabel.text = MiscTools.FormatBigNumber(player.skill);
		highlight.alpha = ((!(player.id == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener5 = UIEventListener.Get(playerSquadButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ShowPlayerSquad));
		UIEventListener uIEventListener6 = UIEventListener.Get(playerSquadButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ShowPlayerSquad));
	}

	public void InitializePlayer(DatabasePlayer player, int pos, float width)
	{
		mPlayerData = null;
		mPlayer = player;
		widthSetter.SetWidth(width);
		if (pos < 1)
		{
			positionLabel.text = "?";
		}
		else if (pos > 100)
		{
			positionLabel.text = "100+.";
		}
		else
		{
			positionLabel.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		}
		playerPart.SetActive(value: true);
		squadPart.SetActive(value: false);
		playerIcon.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(player);
		string text = GameVariables.CountryCodeSpriteName(player.country);
		bool flag = !string.IsNullOrEmpty(text);
		countryFlag.gameObject.SetActive(flag);
		if (flag)
		{
			countryFlag.spriteName = text;
		}
		playerName.text = player.name;
		TweenColor.Begin(playerName.gameObject, 0f, Color.white);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(player.level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankNumber.text = levelDefinition.displayString;
		bool flag2 = player.warArenaCrown != WarArenaCrown.None;
		crownIcon.gameObject.SetActive(flag2);
		if (flag2)
		{
			crownIcon.spriteName = GameVariables.crownSprites[player.warArenaCrown];
			crownIcon.MakePixelPerfect();
			float x = playerName.transform.localPosition.x;
			x += playerName.relativeSize.x * playerName.transform.localScale.x;
			x += 10f + crownIcon.transform.localScale.x / 2f;
			crownIcon.transform.localPosition = crownIcon.transform.localPosition.ReplaceX(x);
		}
		playerSquadName.text = ((!string.IsNullOrEmpty(player.squadName)) ? player.squadName : string.Empty);
		TweenColor.Begin(playerSquadName.gameObject, 0f, Color.white);
		armyPowerValue.text = MiscTools.FormatBigNumber(player.armyPowerX10);
		MiscTools.SetUILabelRescale(armyPowerValue, 37f, 28f, 100);
		if (player.isInBeginnersLeague)
		{
			int beginnersLeague = player.beginnersLeague;
			playerLeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.transform.localScale = playerLeagueIcon.transform.localScale.MultiplyXY(0.8f);
			playerLeagueIcon.alpha = 1f;
			playerLeagueName.text = Singleton<GameVariables>.instance.BeginnersLeagueName(beginnersLeague);
		}
		else
		{
			League leagueTier = player.leagueTier;
			bool isInLeague = player.isInLeague;
			playerLeagueIcon.spriteName = GameVariables.leagueNames[leagueTier].Value2;
			playerLeagueIcon.MakePixelPerfect();
			playerLeagueIcon.transform.localScale = playerLeagueIcon.transform.localScale.MultiplyXY(0.8f);
			playerLeagueIcon.alpha = ((!isInLeague) ? 0.5f : 1f);
			playerLeagueName.text = ((!isInLeague) ? Localization.Localize("ID_NA") : GameVariables.leagueNames[leagueTier].Value1);
		}
		medalsLabel.text = MiscTools.FormatBigNumber(player.skill);
		highlight.alpha = ((!(player.id == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(playerIconButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener2 = UIEventListener.Get(playerIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowPlayerIcon));
		UIEventListener uIEventListener3 = UIEventListener.Get(playerButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayer));
		UIEventListener uIEventListener5 = UIEventListener.Get(playerSquadButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ShowPlayerSquad));
		UIEventListener uIEventListener6 = UIEventListener.Get(playerSquadButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ShowPlayerSquad));
	}

	public void UpdateSquadNameForPlayer()
	{
		if (mPlayer != null)
		{
			if (mPlayerData != null)
			{
				mPlayer.squadName = mPlayerData.squadId;
			}
			playerSquadName.text = ((!string.IsNullOrEmpty(mPlayer.squadName)) ? mPlayer.squadName : string.Empty);
		}
	}

	public void InitializeSquad(DatabaseSquad squad, int pos, float width)
	{
		mPlayer = null;
		mPlayerData = null;
		widthSetter.SetWidth(width);
		if (pos < 1)
		{
			positionLabel.text = "?";
		}
		else if (pos > 100)
		{
			positionLabel.text = "100+.";
		}
		else
		{
			positionLabel.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		}
		playerPart.SetActive(value: false);
		squadPart.SetActive(value: true);
		squadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + squad.icon);
		squadIconTexture.MakePixelPerfect();
		squadIconTexture.transform.localScale = squadIconTexture.transform.localScale.MultiplyXY(0.5f);
		squadName.text = squad.name;
		TweenColor.Begin(squadName.gameObject, 0f, Color.white);
		squadRank.text = squad.rank.ToString();
		squadMembers.text = Localization.LocalizeFormat("ID_NUMMEMBERS", squad.size);
		medalsLabel.text = MiscTools.FormatBigNumber(squad.skill);
		highlight.alpha = ((!(squad.name == GameLoginManager.currentPlayer.squadName)) ? 0f : 1f);
		UIEventListener uIEventListener = UIEventListener.Get(squadButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowSquad));
		UIEventListener uIEventListener2 = UIEventListener.Get(squadButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowSquad));
	}

	private void ShowSquad(GameObject go)
	{
		if (squadPart.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(squadName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(squadName.text);
		}
	}

	private void ShowPlayerSquad(GameObject go)
	{
		if (playerPart.activeSelf && !string.IsNullOrEmpty(playerSquadName.text))
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
		UIEventListener uIEventListener3 = UIEventListener.Get(squadButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ShowSquad));
		UIEventListener uIEventListener4 = UIEventListener.Get(playerSquadButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ShowPlayerSquad));
		squadIconTexture.mainTexture = null;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		if (mPlayer != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mPlayer.id);
		}
		mPlayer = null;
	}
}
