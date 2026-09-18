using System;
using UnityEngine;

public class SquadWarsRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter widthSetter;

	[Header("Header Part")]
	public GameObject headerPart;

	public UISprite headerBackground;

	public UITable table;

	public UILabel rewardLabel;

	public UISprite goldIcon;

	public UILabel goldReward;

	public UILabel actionAndDivision;

	public UISprite[] arrows;

	[Header("Squad Record")]
	public GameObject recordPart;

	public UISprite recordBackground;

	public GameObject squadButton;

	public UILabel positionLabel;

	public UITexture squadIconTexture;

	public UILabel squadName;

	public UILabel squadMembers;

	public UILabel squadPoints;

	public UISprite squadPointsBox;

	public UISprite highlight;

	public void Initialize(SquadWarsContent.SquadWarsInternal data, float width)
	{
		headerPart.SetActive(!data.isRecord);
		recordPart.SetActive(data.isRecord);
		widthSetter.SetWidth(width);
		if (data.isRecord)
		{
			recordBackground.color = BackgroundColor(data.type);
			positionLabel.color = PositionColor(data.type);
			squadPointsBox.color = positionLabel.color;
			highlight.color = HighlightColor(data.type).ReplaceA((!(data.squadName == GameLoginManager.currentPlayer.squadName)) ? 0f : 1f);
			positionLabel.text = MiscTools.FormatNumberToOrdinalPoint(data.position);
			squadIconTexture.mainTexture = Resources.Load<Texture>("SquadIcons/" + data.squadIcon);
			squadIconTexture.MakePixelPerfect();
			squadIconTexture.transform.localScale = squadIconTexture.transform.localScale.MultiplyXY(0.5f);
			squadName.text = data.squadName;
			TweenColor.Begin(squadName.gameObject, 0f, Color.white);
			MiscTools.SetUILabelRescale(squadName, 37f, 23f);
			squadMembers.text = Localization.LocalizeFormat("ID_NUMMEMBERS", data.squadSize);
			squadPoints.text = MiscTools.FormatBigNumber(data.squadPoints);
			UIEventListener uIEventListener = UIEventListener.Get(squadButton);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowSquad));
			UIEventListener uIEventListener2 = UIEventListener.Get(squadButton);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowSquad));
			return;
		}
		headerBackground.color = BackgroundColor(data.type);
		bool flag = data.goldReward > 0;
		table.repositionNow = true;
		rewardLabel.text = Localization.Localize((!flag) ? "ID_NOREWARD" : "ID_REWARD");
		rewardLabel.color = ((!flag) ? Colours.grayButton : Colours.goldWar);
		goldIcon.alpha = ((!flag) ? 0f : 1f);
		goldReward.alpha = ((!flag) ? 0f : 1f);
		goldReward.text = MiscTools.FormatBigNumber(data.goldReward);
		string key = ((data.headerAction > 0) ? "ID_PROMOTETODIVISION" : ((data.headerAction >= 0) ? "ID_STAYINDIVISION" : "ID_DEMOTETODIVISION"));
		int num = ((data.headerAction > 0) ? (data.headerDivision + 1) : ((data.headerAction >= 0) ? data.headerDivision : (data.headerDivision - 1)));
		actionAndDivision.text = string.Format("{0} {1}{2} {3}", Localization.Localize(key), Colours.stringGoldWar, Localization.Localize("ID_DIVISION"), 9 - num);
		actionAndDivision.transform.localPosition = actionAndDivision.transform.localPosition.ReplaceX(-44f - (float)(num - 1) * 13.7f);
		for (int i = 0; i < arrows.Length; i++)
		{
			arrows[i].gameObject.SetActive(i < num);
		}
	}

	private void ShowSquad(GameObject go)
	{
		if (recordPart.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(squadName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(squadName.text);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		squadIconTexture.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(squadButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowSquad));
	}

	private Color BackgroundColor(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenSquadWar;
			case LeagueType.Demote:
				return Colours.redSquadWar;
			default:
				return Color.white;
		}
	}

	private Color PositionColor(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenSquadWar;
			case LeagueType.Demote:
				return Colours.redSquadWar;
			default:
				return Colours.goldSquadWar;
		}
	}

	private Color HighlightColor(LeagueType type)
	{
		switch (type)
		{
			case LeagueType.Promote:
				return Colours.greenSquadWar;
			case LeagueType.Demote:
				return Colours.redSquadWar;
			default:
				return Colours.blue;
		}
	}
}
