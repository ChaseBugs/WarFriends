using UnityEngine;

public class GameStartScreen : GuiScreenSingle<GameStartScreen>
{
	[Header("Player 1 Part (Left)")]
	public GameObject left;

	public PlayerIcon player1Icon;

	public UISprite player1CountryIcon;

	public UISprite player1RankIcon;

	public UILabel player1Rank;

	public UITable player1Table;

	public UISprite player1VIPIcon;

	public UISprite player1LeagueIcon;

	public UISprite player1CrownIcon;

	[Header("-Power Band Part")]
	public GameObject player1PowerBandPart;

	public UISprite player1PowerBandIcon;

	public UILabel player1PowerBandValue;

	public UISprite player1PowerBandMiniIcon;

	[Header("Middle")]
	public GameObject middle;

	[Header("Player 2 Part (Right)")]
	public GameObject right;

	public PlayerIcon player2Icon;

	public UISprite player2CountryIcon;

	public UISprite player2RankIcon;

	public UILabel player2Rank;

	public UITable player2Table;

	public UISprite player2VIPIcon;

	public UISprite player2LeagueIcon;

	public UISprite player2CrownIcon;

	[Header("-Power Band Part")]
	public GameObject player2PowerBandPart;

	public UISprite player2PowerBandIcon;

	public UILabel player2PowerBandValue;

	public UISprite player2PowerBandMiniIcon;

	protected override void InitControls()
	{
		Singleton<GameCamera>.instance.AnimationFinished += InstanceOnAnimationFinished;
		Singleton<GameCamera>.instance.AnimationOnPlayerStop += InstanceOnAnimationOnPlayerStop;
		player1Table.onReposition = OnPlayer1TableReposition;
		player2Table.onReposition = OnPlayer2TableReposition;
	}

	private void InstanceOnAnimationOnPlayerStop()
	{
		TweenAlpha.Begin(left, 0.2f, 1f);
		TweenScale.Begin(left, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.StartGamePhotoSound);
		InvokeAfterRealTime(delegate
		{
			TweenAlpha.Begin(middle, 0.2f, 1f);
			TweenScale.Begin(middle, 0.2f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.StartGameVsSound);
		}, 1f);
	}

	private void InstanceOnAnimationFinished()
	{
		TweenAlpha.Begin(right, 0.25f, 1f);
		TweenScale.Begin(right, 0.25f, new Vector3(3.5f, 3.5f, 1f), Vector3.one);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.StartGamePhotoSound);
		InvokeAfterRealTime(delegate
		{
			TweenAlpha.Begin(right, 0.2f, 0f);
			TweenAlpha.Begin(middle, 0.2f, 0f);
			TweenAlpha.Begin(left, 0.2f, 0f);
		}, 1.5f);
	}

	private void OnPlayer1TableReposition()
	{
		Transform parent = player1Icon.nameLabel.transform.parent;
		if (player1CrownIcon.gameObject.activeSelf)
		{
			parent = player1CrownIcon.transform.parent;
		}
		float num = 0f - player1Table.padding.x - (parent.localPosition.x - player1Table.padding.x) / 2f;
		float num2 = UIRoot.list[0].activeWidth / 2f - 600f - 20f;
		if (num2 < Mathf.Abs(num))
		{
			num = 0f - num2;
		}
		player1Table.transform.localPosition = player1Table.transform.localPosition.ReplaceX(num);
	}

	private void OnPlayer2TableReposition()
	{
		Transform parent = player2Icon.nameLabel.transform.parent;
		if (player2CrownIcon.gameObject.activeSelf)
		{
			parent = player2CrownIcon.transform.parent;
		}
		float num = (parent.localPosition.x - player2Table.padding.x) / 2f;
		float num2 = 0f - player2Table.padding.x - num;
		float num3 = UIRoot.list[0].activeWidth / 2f - 600f - 20f;
		if (num3 < Mathf.Abs(num))
		{
			num2 = num2 - num + num3;
		}
		player2Table.transform.localPosition = player2Table.transform.localPosition.ReplaceX(num2);
	}

	public override void InitGUIValues()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			InitializeTutorialStart();
		}
		else if (Singleton<GameController>.instance.isMission)
		{
			InitializeMissionStart();
		}
		else if (Singleton<GameController>.instance.isWarArena)
		{
			InitializeArenaStart();
		}
		else
		{
			InitializeStart();
		}
	}

	private void InitializeStart()
	{
		player1Icon.avatar = Singleton<GameController>.instance.opponent.playerProperties.texture;
		InitializePlayer1Level(Singleton<GameController>.instance.opponent.playerProperties.level);
		InitializePlayer1(Singleton<GameController>.instance.opponent.playerProperties.isVip, Singleton<GameController>.instance.opponent.playerProperties.name, Singleton<GameController>.instance.opponent.playerProperties.warArenaCrown);
		InitializePlayer1CountryIcon(Singleton<GameController>.instance.opponent.playerProperties.country);
		InitializePlayer1LeagueIcon(Singleton<GameController>.instance.opponent.playerProperties.matchMadeGames, Singleton<GameController>.instance.opponent.playerProperties.league, Singleton<GameController>.instance.opponent.playerProperties.beginnersLeague, Singleton<GameController>.instance.opponent.playerProperties.isInLeague);
		string id = Singleton<GameController>.instance.opponent.playerProperties.playerVisuals[3];
		InitializePlayer1PowerBand(CamosManager.instance.playerVisualCategories[3][id]);
		player2Icon.avatar = PlayerController.currentPlayer.playerProperties.texture;
		InitializePlayer2Level(PlayerController.currentPlayer.playerProperties.level);
		InitializePlayer2(PlayerController.currentPlayer.playerProperties.isVip, PlayerController.currentPlayer.playerProperties.name, PlayerController.currentPlayer.playerProperties.warArenaCrown);
		InitializePlayer2CountryIcon(PlayerController.currentPlayer.playerProperties.country);
		InitializePlayer2LeagueIcon(PlayerController.currentPlayer.playerProperties.matchMadeGames, PlayerController.currentPlayer.playerProperties.league, PlayerController.currentPlayer.playerProperties.beginnersLeague, PlayerController.currentPlayer.playerProperties.isInLeague);
		string id2 = PlayerController.currentPlayer.playerProperties.playerVisuals[3];
		InitializePlayer2PowerBand(CamosManager.instance.playerVisualCategories[3][id2]);
	}

	private void InitializeTutorialStart()
	{
		player1Icon.avatar = Singleton<GameController>.instance.opponent.playerProperties.texture;
		InitializePlayer1Level(Singleton<GameController>.instance.opponent.playerProperties.level);
		InitializePlayer1(isVip: false, Singleton<GameController>.instance.opponent.playerProperties.name, WarArenaCrown.None);
		InitializePlayer1CountryIcon(Singleton<GameController>.instance.opponent.playerProperties.country);
		InitializePlayer1LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		string id = Singleton<GameController>.instance.opponent.playerProperties.playerVisuals[3];
		InitializePlayer1PowerBand(CamosManager.instance.playerVisualCategories[3][id]);
		player2Icon.avatar = PlayerController.currentPlayer.playerProperties.texture;
		InitializePlayer2Level(PlayerController.currentPlayer.playerProperties.level);
		InitializePlayer2(PlayerController.currentPlayer.playerProperties.isVip, PlayerController.currentPlayer.playerProperties.name, PlayerController.currentPlayer.playerProperties.warArenaCrown);
		InitializePlayer2CountryIcon(PlayerController.currentPlayer.playerProperties.country);
		InitializePlayer2LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		string id2 = PlayerController.currentPlayer.playerProperties.playerVisuals[3];
		InitializePlayer2PowerBand(CamosManager.instance.playerVisualCategories[3][id2]);
	}

	private void InitializeMissionStart()
	{
		player1Icon.avatar = Singleton<GameController>.instance.opponent.playerProperties.texture;
		InitializePlayer1Level(Singleton<GameController>.instance.opponent.playerProperties.level);
		InitializePlayer1(isVip: false, Singleton<GameController>.instance.opponent.playerProperties.name, WarArenaCrown.None);
		InitializePlayer1CountryIcon(null);
		InitializePlayer1LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		string id = Singleton<GameController>.instance.opponent.playerProperties.playerVisuals[3];
		InitializePlayer1PowerBand(CamosManager.instance.playerVisualCategories[3][id]);
		player2Icon.avatar = PlayerController.currentPlayer.playerProperties.texture;
		InitializePlayer2Level(PlayerController.currentPlayer.playerProperties.level);
		InitializePlayer2(PlayerController.currentPlayer.playerProperties.isVip, PlayerController.currentPlayer.playerProperties.name, PlayerController.currentPlayer.playerProperties.warArenaCrown);
		InitializePlayer2CountryIcon(PlayerController.currentPlayer.playerProperties.country);
		InitializePlayer2LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		string id2 = PlayerController.currentPlayer.playerProperties.playerVisuals[3];
		InitializePlayer2PowerBand(CamosManager.instance.playerVisualCategories[3][id2]);
	}

	private void InitializeArenaStart()
	{
		player1Icon.avatar = Singleton<GameController>.instance.opponent.playerProperties.texture;
		InitializePlayer1Level(0);
		InitializePlayer1(isVip: false, Singleton<GameController>.instance.opponent.playerProperties.name, Singleton<GameController>.instance.opponent.playerProperties.warArenaCrown);
		InitializePlayer1CountryIcon(Singleton<GameController>.instance.opponent.playerProperties.country);
		InitializePlayer1LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		InitializePlayer1PowerBand(null);
		player2Icon.avatar = PlayerController.currentPlayer.playerProperties.texture;
		InitializePlayer2Level(0);
		InitializePlayer2(isVip: false, PlayerController.currentPlayer.playerProperties.name, PlayerController.currentPlayer.playerProperties.warArenaCrown);
		InitializePlayer2CountryIcon(PlayerController.currentPlayer.playerProperties.country);
		InitializePlayer2LeagueIcon(1, League.NoLeague, 0, isInLeague: false);
		InitializePlayer2PowerBand(null);
	}

	private void InitializePlayer1Level(int level)
	{
		bool flag = level > 0;
		player1RankIcon.gameObject.SetActive(flag);
		if (flag)
		{
			int level2 = level - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level2);
			player1Rank.text = levelDefinition.displayString;
			player1RankIcon.spriteName = levelDefinition.iconName;
		}
		else
		{
			player1Rank.text = string.Empty;
		}
	}

	private void InitializePlayer1(bool isVip, string playerName, WarArenaCrown crownType)
	{
		player1VIPIcon.gameObject.SetActive(isVip);
		bool flag = crownType != WarArenaCrown.None;
		player1CrownIcon.gameObject.SetActive(flag);
		if (flag)
		{
			player1CrownIcon.spriteName = GameVariables.crownSprites[crownType];
			player1CrownIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(60f / player1CrownIcon.transform.localScale.x, 60f / player1CrownIcon.transform.localScale.y);
			player1CrownIcon.transform.localScale = player1CrownIcon.transform.localScale.MultiplyXY(multiplier);
		}
		player1Icon.SetName(playerName);
		MiscTools.SetUILabelRescale(player1Icon.nameLabel, 66f, 50f, 720);
		player1Table.repositionNow = true;
	}

	private void InitializePlayer1CountryIcon(string country)
	{
		bool flag = !string.IsNullOrEmpty(country);
		player1CountryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			player1CountryIcon.spriteName = GameVariables.CountryCodeSpriteName(country);
		}
	}

	private void InitializePlayer1LeagueIcon(int matchMadeBattles, League league, int beginnersLeague, bool isInLeague)
	{
		if (matchMadeBattles < 1)
		{
			player1LeagueIcon.gameObject.SetActive(value: true);
			player1LeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			player1LeagueIcon.MakePixelPerfect();
			player1LeagueIcon.alpha = 0.7f;
		}
		else if (beginnersLeague > 0)
		{
			player1LeagueIcon.gameObject.SetActive(value: true);
			player1LeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			player1LeagueIcon.MakePixelPerfect();
			player1LeagueIcon.alpha = 1f;
		}
		else if (league != League.NoLeague)
		{
			player1LeagueIcon.gameObject.SetActive(value: true);
			player1LeagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
			player1LeagueIcon.MakePixelPerfect();
			player1LeagueIcon.alpha = ((!isInLeague) ? 0.7f : 1f);
		}
		else
		{
			player1LeagueIcon.gameObject.SetActive(value: false);
		}
	}

	private void InitializePlayer1PowerBand(PlayerVisual powerBand)
	{
		bool flag = powerBand != null && !powerBand.isEmptyPowerBand;
		player1PowerBandPart.SetActive(flag);
		if (flag)
		{
			player1PowerBandIcon.spriteName = powerBand.icon;
			player1PowerBandIcon.MakePixelPerfect();
			player1PowerBandValue.text = powerBand.decalValueString;
			player1PowerBandMiniIcon.spriteName = powerBand.decalMiniIcon;
			player1PowerBandMiniIcon.MakePixelPerfect();
			player1PowerBandMiniIcon.color = powerBand.decalMiniIconColor;
			player1PowerBandMiniIcon.alpha = 0f;
		}
	}

	private void InitializePlayer2Level(int level)
	{
		bool flag = level > 0;
		player2RankIcon.gameObject.SetActive(flag);
		if (flag)
		{
			int level2 = level - 1;
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(level2);
			player2Rank.text = levelDefinition.displayString;
			player2RankIcon.spriteName = levelDefinition.iconName;
		}
		else
		{
			player2Rank.text = string.Empty;
		}
	}

	private void InitializePlayer2(bool isVip, string playerName, WarArenaCrown crownType)
	{
		player2VIPIcon.gameObject.SetActive(isVip);
		bool flag = crownType != WarArenaCrown.None;
		player2CrownIcon.gameObject.SetActive(flag);
		if (flag)
		{
			player2CrownIcon.spriteName = GameVariables.crownSprites[crownType];
			player2CrownIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(60f / player2CrownIcon.transform.localScale.x, 60f / player2CrownIcon.transform.localScale.y);
			player2CrownIcon.transform.localScale = player2CrownIcon.transform.localScale.MultiplyXY(multiplier);
		}
		player2Icon.SetName(playerName);
		MiscTools.SetUILabelRescale(player2Icon.nameLabel, 66f, 50f, 720);
		player2Table.repositionNow = true;
	}

	private void InitializePlayer2CountryIcon(string country)
	{
		bool flag = !string.IsNullOrEmpty(country);
		player2CountryIcon.gameObject.SetActive(flag);
		if (flag)
		{
			player2CountryIcon.spriteName = GameVariables.CountryCodeSpriteName(country);
		}
	}

	private void InitializePlayer2LeagueIcon(int matchMadeBattles, League league, int beginnersLeague, bool isInLeague)
	{
		if (matchMadeBattles < 1)
		{
			player2LeagueIcon.gameObject.SetActive(value: true);
			player2LeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			player2LeagueIcon.MakePixelPerfect();
			player2LeagueIcon.alpha = 0.7f;
		}
		else if (beginnersLeague > 0)
		{
			player2LeagueIcon.gameObject.SetActive(value: true);
			player2LeagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			player2LeagueIcon.MakePixelPerfect();
			player2LeagueIcon.alpha = 1f;
		}
		else if (league != League.NoLeague)
		{
			player2LeagueIcon.gameObject.SetActive(value: true);
			player2LeagueIcon.spriteName = GameVariables.leagueNames[league].Value2;
			player2LeagueIcon.MakePixelPerfect();
			player2LeagueIcon.alpha = ((!isInLeague) ? 0.7f : 1f);
		}
		else
		{
			player2LeagueIcon.gameObject.SetActive(value: false);
		}
	}

	private void InitializePlayer2PowerBand(PlayerVisual powerBand)
	{
		bool flag = powerBand != null && !powerBand.isEmptyPowerBand;
		player2PowerBandPart.SetActive(flag);
		if (flag)
		{
			player2PowerBandIcon.spriteName = powerBand.icon;
			player2PowerBandIcon.MakePixelPerfect();
			player2PowerBandValue.text = powerBand.decalValueString;
			player2PowerBandMiniIcon.spriteName = powerBand.decalMiniIcon;
			player2PowerBandMiniIcon.MakePixelPerfect();
			player2PowerBandMiniIcon.color = powerBand.decalMiniIconColor;
			player2PowerBandMiniIcon.alpha = 0f;
		}
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		TweenAlpha.Begin(left, 0f, 0f);
		TweenAlpha.Begin(middle, 0f, 0f);
		TweenAlpha.Begin(right, 0f, 0f);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
	}

	public override void OnBack()
	{
	}
}
