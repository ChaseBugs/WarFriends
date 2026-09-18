using System;
using System.Collections.Generic;
using UnityEngine;

public class LeagueDialog : GuiElementSingle<LeagueDialog>, IGuiDialog
{
	private enum Type
	{
		EnteredNormalLeague,
		EnteredNormalLeagueFirstTime,
		EnteredBeginnersLeague,
		FinishedBeginnerLeagues
	}

	[Header("Core")]
	public UILabel titleLabel;

	[Header("Normal League")]
	public GameObject normalLeaguePart;

	public UILabel normalLeagueTopText;

	public UITexture normalLeagueLeagueTexture;

	public UILabel normalLeagueRewardHeader;

	public UISprite normalLeagueRewardLeftWing;

	public UISprite normalLeagueRewardRightWing;

	public UILabel normalLeagueRewardWarbucks;

	public UILabel normalLeagueRewardSquadPoints;

	[Header("Normal League First Time")]
	public GameObject normalLeagueFirstTimePart;

	public UILabel normalLeagueFirstTimeTopText;

	public LeagueArcGuiElement normalLeagueFirstTimeLeagueArc;

	public UITable normalLeagueFirstTimeFirstHintTable;

	public UILabel normalLeagueFirstTimeSecondLine;

	public UILabel normalLeagueFirstTimeThirdLine;

	public UILabel normalLeagueFirstTimeRewardHeader;

	public UISprite normalLeagueFirstTimeRewardLeftWing;

	public UISprite normalLeagueFirstTimeRewardRightWing;

	public UILabel normalLeagueFirstTimeRewardWarbucks;

	public UILabel normalLeagueFirstTimeRewardSquadPoints;

	[Header("Beginners League")]
	public GameObject beginnersLeaguePart;

	public UILabel beginnersLeagueTopText;

	public UITexture beginnersLeagueLeagueTexture;

	public UITable beginnersLeagueHintTable;

	public UITable beginnersLeagueFirstLineTable;

	public UILabel[] beginnersLeagueLongHintLabels;

	public UILabel beginnersLeagueProgressHint;

	public UISprite beginnersLeagueProgressBar;

	public UISprite beginnersLeagueProgressMedalsIcon;

	public UILabel beginnersLeagueProgressLabel;

	public UISprite beginnersLeagueProgressLeagueIcon;

	[Header("Finished Beginners League")]
	public GameObject finishedBeginnersLeaguePart;

	public UITexture[] finishedBeginnersLeagueLeagueIcons;

	public UISprite finishedBeginnersLeagueIcon;

	public UILabel finishedBeginnersLabel;

	[Header("Bottom")]
	public GameObject bottomButton;

	public UILabel bottomButtonLabel;

	private Type mCurrentType;

	private League mLeague;

	private int mBeginnnersLeague;

	private Dictionary<Type, string> mTitleName = new Dictionary<Type, string>
	{
		{
			Type.EnteredNormalLeague,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			Type.EnteredNormalLeagueFirstTime,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			Type.EnteredBeginnersLeague,
			"ID_YOUVEENTEREDALEAGUE"
		},
		{
			Type.FinishedBeginnerLeagues,
			"ID_CONGRATULATIONSROOKIE"
		}
	};

	public void ShowEnterToNormalLeague(League newLeague, bool firstTime)
	{
		mCurrentType = (firstTime ? Type.EnteredNormalLeagueFirstTime : Type.EnteredNormalLeague);
		mLeague = newLeague;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowEnterToBeginnersLeague(int beginnersLeague)
	{
		mCurrentType = Type.EnteredBeginnersLeague;
		mBeginnnersLeague = beginnersLeague;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowFinishedBeginnersLeague(League newLeague)
	{
		mCurrentType = Type.FinishedBeginnerLeagues;
		mLeague = newLeague;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bottomButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UITable uITable = beginnersLeagueFirstLineTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnLineReposition));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnLineReposition()
	{
		beginnersLeagueHintTable.repositionNow = true;
	}

	public override void InitGUIValues()
	{
		normalLeaguePart.SetActive(mCurrentType == Type.EnteredNormalLeague);
		normalLeagueFirstTimePart.SetActive(mCurrentType == Type.EnteredNormalLeagueFirstTime);
		beginnersLeaguePart.SetActive(mCurrentType == Type.EnteredBeginnersLeague);
		finishedBeginnersLeaguePart.SetActive(mCurrentType == Type.FinishedBeginnerLeagues);
		titleLabel.text = Localization.Localize(mTitleName[mCurrentType]);
		MiscTools.SetUILabelRescale(titleLabel, 87f, 42f, 1340);
		bottomButtonLabel.text = Localization.Localize((mCurrentType != Type.FinishedBeginnerLeagues) ? "ID_AWESOME" : "ID_CONTINUE");
		switch (mCurrentType)
		{
		case Type.EnteredNormalLeague:
		{
			normalLeagueTopText.text = Localization.LocalizeFormat("ID_CONGRATULATIONSPLACEDINLEAGUE", Colours.stringBlue, GameVariables.leagueNames[mLeague].Value1, Colours.stringWhite);
			normalLeagueLeagueTexture.mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mLeague].Value2);
			float num5 = normalLeagueRewardHeader.relativeSize.x * normalLeagueRewardHeader.transform.localScale.x;
			float val3 = (714f - (num5 + 40f)) / 2f;
			normalLeagueRewardLeftWing.transform.localScale = normalLeagueRewardLeftWing.transform.localScale.ReplaceX(val3);
			normalLeagueRewardRightWing.transform.localScale = normalLeagueRewardRightWing.transform.localScale.ReplaceX(val3);
			normalLeagueRewardWarbucks.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(mLeague));
			normalLeagueRewardSquadPoints.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(mLeague));
			break;
		}
		case Type.EnteredNormalLeagueFirstTime:
		{
			normalLeagueFirstTimeTopText.text = Localization.LocalizeFormat("ID_CONGRATULATIONSMOVEDTO", GameVariables.leagueNames[mLeague].Value1);
			normalLeagueFirstTimeLeagueArc.SetTutorialLook();
			normalLeagueFirstTimeFirstHintTable.repositionNow = true;
			normalLeagueFirstTimeSecondLine.text = Localization.LocalizeFormat("ID_TONORMALLEAGUEHINT2", MiscTools.FormatFloatNumberAsPercent(Singleton<GameVariables>.instance.LeagueGoUpPercent(mLeague)));
			normalLeagueFirstTimeThirdLine.text = Localization.Localize((mLeague >= League.Silver3) ? "ID_TONORMALLEAGUEHINT3SILVER" : "ID_TONORMALLEAGUEHINT3BRONZE");
			float num4 = normalLeagueFirstTimeRewardHeader.relativeSize.x * normalLeagueFirstTimeRewardHeader.transform.localScale.x;
			float val2 = (714f - (num4 + 40f)) / 2f;
			normalLeagueFirstTimeRewardLeftWing.transform.localScale = normalLeagueFirstTimeRewardLeftWing.transform.localScale.ReplaceX(val2);
			normalLeagueFirstTimeRewardRightWing.transform.localScale = normalLeagueFirstTimeRewardRightWing.transform.localScale.ReplaceX(val2);
			normalLeagueFirstTimeRewardWarbucks.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsWarbucksBonusLeague(mLeague));
			normalLeagueFirstTimeRewardSquadPoints.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.MedalsSquadPointsBonusLeague(mLeague));
			break;
		}
		case Type.EnteredBeginnersLeague:
		{
			string text = Singleton<GameVariables>.instance.BeginnersLeagueIcon(mBeginnnersLeague);
			string spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(mBeginnnersLeague + 1);
			string text2 = Singleton<GameVariables>.instance.BeginnersLeagueName(mBeginnnersLeague);
			string text3 = Singleton<GameVariables>.instance.BeginnersLeagueName(mBeginnnersLeague + 1);
			int medalsBalance = GameLoginManager.currentPlayer.medalsBalance;
			int num = Singleton<GameVariables>.instance.BeginnersLeagueMaxMedals(mBeginnnersLeague);
			float fillAmount = (float)medalsBalance / (float)num;
			beginnersLeagueTopText.text = Localization.LocalizeFormat("ID_CONGRATULATIONSPLACEDINLEAGUE", Colours.stringBlue, text2, Colours.stringWhite);
			MiscTools.SetUILabelRescale(beginnersLeagueTopText, 47f, 20f, 1340);
			string currentLanguage = Localization.instance.currentLanguage;
			if (currentLanguage == "ru" || currentLanguage == "fr")
			{
				for (int i = 0; i < beginnersLeagueLongHintLabels.Length; i++)
				{
					beginnersLeagueLongHintLabels[i].transform.localScale = new Vector3(26f, 26f, 1f);
				}
			}
			beginnersLeagueFirstLineTable.repositionNow = true;
			beginnersLeagueLeagueTexture.mainTexture = Resources.Load<Texture>("Medals/" + text);
			beginnersLeagueProgressHint.text = Localization.LocalizeFormat("ID_XMEDALSTOADVANCETOY", MiscTools.FormatBigNumber(num), text3);
			MiscTools.SetUILabelRescale(beginnersLeagueProgressHint, 37f, 20f, 650);
			beginnersLeagueProgressBar.fillAmount = fillAmount;
			beginnersLeagueProgressLabel.text = $"{medalsBalance} [9A9999]/[0BBCFF] {num}";
			float num2 = beginnersLeagueProgressMedalsIcon.transform.localScale.x / 2f;
			float num3 = beginnersLeagueProgressLabel.relativeSize.x * beginnersLeagueProgressLabel.transform.localScale.x / 2f;
			float val = -1f * (num2 + 18f + num3);
			beginnersLeagueProgressMedalsIcon.transform.localPosition = beginnersLeagueProgressMedalsIcon.transform.localPosition.ReplaceX(val);
			beginnersLeagueProgressLeagueIcon.spriteName = spriteName;
			break;
		}
		case Type.FinishedBeginnerLeagues:
			finishedBeginnersLeagueLeagueIcons[0].mainTexture = Resources.Load<Texture>("Medals/" + Singleton<GameVariables>.instance.BeginnersLeagueIcon(3));
			finishedBeginnersLeagueLeagueIcons[1].mainTexture = Resources.Load<Texture>("Medals/" + GameVariables.leagueNames[mLeague].Value2);
			finishedBeginnersLeagueIcon.spriteName = GameVariables.leagueNames[mLeague].Value2;
			finishedBeginnersLabel.text = Localization.LocalizeFormat("ID_PLAYBATTLETOENTERBRONZELEAGUE", GameVariables.leagueNames[mLeague].Value1);
			break;
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		beginnersLeagueLeagueTexture.mainTexture = null;
		normalLeagueLeagueTexture.mainTexture = null;
		finishedBeginnersLeagueLeagueIcons[0].mainTexture = null;
		finishedBeginnersLeagueLeagueIcons[1].mainTexture = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(bottomButton);
	}
}
