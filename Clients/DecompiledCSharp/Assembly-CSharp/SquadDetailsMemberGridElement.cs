using System;
using UnityEngine;

public class SquadDetailsMemberGridElement : PoolableObject
{
	[Header("Left")]
	public UISprite highlight;

	public UILabel position;

	public PlayerIcon avatar;

	public GameObject playerIconButton;

	public UISprite countryIcon;

	public UISprite rankIcon;

	public UILabel rankNumber;

	public UITable nickTable;

	public UILabel nickLabel;

	public UISprite crownIcon;

	public GameObject playerOnline;

	public GameObject playerButton;

	public UILabel squadFunction;

	[Header("Right")]
	public UILabel reputationPointsLabel;

	public UILabel squadPointsLabel;

	public UILabel armyPowerLabel;

	public UISprite leagueIcon;

	public UILabel medalsLabel;

	private DatabasePlayer mSquadMember;

	public void InitializeMember(DatabasePlayer squadMember, int pos)
	{
		mSquadMember = squadMember;
		highlight.gameObject.SetActive(squadMember.id == GameLoginManager.currentPlayer.id);
		avatar.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += OnPlayerTextureCreated;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(squadMember);
		position.text = MiscTools.FormatNumberToOrdinalPoint(pos);
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(squadMember.level);
		rankIcon.spriteName = levelDefinition.iconName;
		rankIcon.MakePixelPerfect();
		float multiplier = 50f / rankIcon.transform.localScale.x;
		rankIcon.transform.localScale = rankIcon.transform.localScale.MultiplyXY(multiplier);
		rankNumber.text = levelDefinition.displayString;
		int num = 311;
		WarArenaCrown warArenaCrown = squadMember.warArenaCrown;
		bool flag = warArenaCrown != WarArenaCrown.None;
		crownIcon.transform.parent.gameObject.SetActive(flag);
		if (flag)
		{
			num -= 40;
			crownIcon.spriteName = GameVariables.crownSprites[warArenaCrown];
			crownIcon.MakePixelPerfect();
			multiplier = Math.Min(30f / crownIcon.transform.localScale.x, 30f / crownIcon.transform.localScale.y);
			crownIcon.transform.localScale = crownIcon.transform.localScale.MultiplyXY(multiplier);
		}
		bool flag2 = squadMember.GetRealStatus() != PlayerStatus.Offline;
		playerOnline.SetActive(flag2);
		if (flag2)
		{
			num -= 41;
		}
		nickLabel.text = squadMember.name;
		TweenColor.Begin(nickLabel.gameObject, 0f, Color.white);
		MiscTools.SetUILabelRescale(nickLabel, 33f, 20f, num);
		nickTable.repositionNow = true;
		string text = GameVariables.CountryCodeSpriteName(squadMember.country);
		bool flag3 = !string.IsNullOrEmpty(text);
		countryIcon.gameObject.SetActive(flag3);
		if (flag3)
		{
			countryIcon.spriteName = text;
		}
		squadFunction.text = Localization.Localize(GameVariables.squadFunctions[squadMember.squadRank]);
		reputationPointsLabel.text = MiscTools.FormatBigNumber(mSquadMember.reputation);
		squadPointsLabel.text = MiscTools.FormatBigNumber(mSquadMember.squadPoints);
		armyPowerLabel.text = MiscTools.FormatBigNumber(mSquadMember.armyPowerX10);
		if (mSquadMember.isInBeginnersLeague)
		{
			leagueIcon.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(mSquadMember.beginnersLeague);
			leagueIcon.alpha = 1f;
		}
		else
		{
			bool flag4 = !mSquadMember.isInLeague;
			League leagueTier = mSquadMember.leagueTier;
			leagueIcon.spriteName = GameVariables.leagueNames[leagueTier].Value2;
			leagueIcon.alpha = ((!flag4) ? 1f : 0.5f);
		}
		leagueIcon.MakePixelPerfect();
		leagueIcon.transform.localScale = leagueIcon.transform.localScale.MultiplyXY(0.5f);
		medalsLabel.text = MiscTools.FormatBigNumber(mSquadMember.skill);
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
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			TweenColor tweenColor = TweenColor.Begin(nickLabel.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id, turnOffDragBackground: false);
		}
	}

	private void ShowPlayerIcon(GameObject go)
	{
		if (!string.IsNullOrEmpty(mSquadMember.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(mSquadMember.name, mSquadMember.id, turnOffDragBackground: false);
		}
	}

	private void OnPlayerTextureCreated(string playerID, Texture2D playerTexture, bool useBackground)
	{
		if (mSquadMember != null && mSquadMember.id == playerID)
		{
			avatar.avatar = playerTexture;
			avatar.UpdateIcon();
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
		if (mSquadMember != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(mSquadMember.id);
		}
		mSquadMember = null;
	}
}
