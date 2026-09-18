using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyContent : Core_BaseScript
{
	[Header("List of Content")]
	public UITable table;

	public UIDraggablePanel panelEnemy;

	public GameObject topSpacer;

	[Header("Enemy Info")]
	public PlayerIcon enemy;

	public GameObject enemyIconButton;

	public UISprite enemyBackground;

	public UISprite enemyCountry;

	public UISprite enemyLeague;

	[Header("-Animations")]
	public GameObject winStamps;

	public UISprite leftWing;

	public UISprite rightWing;

	public UISprite topRibbon;

	public GameObject loseStamp;

	public UISprite kiaStamp;

	[Header("-Top Info")]
	public UISprite enemyRankIcon;

	public UILabel enemyRank;

	public UITable enemyNameAndVipTable;

	public UILabel enemyName;

	public UISprite enemyCrown;

	public BoxCollider playerButton;

	public UISprite enemyVip;

	public BoxCollider enemyReportButton;

	public GameObject enemyReportButtonDisabled;

	public UILabel enemyReportButtonLabel;

	[Header("-Bottom Info")]
	public UILabel enemyMedals;

	public UILabel enemyArmyPower;

	public UISprite enemyPowerBand;

	public UITable enemyTablePowerBand;

	public UILabel enemyPowerBandValue;

	public UISprite enemyPowerBandIcon;

	public UILabel enemyPowerBandNA;

	[Header("List of Enemy Units")]
	public UILabel enemyUnits;

	public UIGrid unitGrid;

	public UnitEndScreenRecord unitEndScreenRecordPrefab;

	[Header("List of Enemy Cards")]
	public UILabel enemyCards;

	public UIGrid cardsGrid;

	public CardRecord cardRecordPrefab;

	private bool mAllReposited;

	private List<TweenAnimator> mAnimator = new List<TweenAnimator>();

	private TweenAnimator mAnimatorWin;

	private TweenAnimator mAnimatorLose;

	private TweenAnimator mAnimatorUnits;

	private TweenAnimator mAnimatorCards;

	private List<CardRecord> mCardsToAnimate;

	private List<UnitEndScreenRecord> mUnitsToAnimate;

	private ObjectPool mPool;

	private string enemyPlayerId;

	public List<TweenAnimator> Animator => mAnimator;

	public void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		mCardsToAnimate = new List<CardRecord>();
		mUnitsToAnimate = new List<UnitEndScreenRecord>();
		InitAnimators();
		float num = (float)UIRoot.list[0].activeHeight / 2f;
		float num2 = 720f - num;
		topSpacer.transform.localPosition = topSpacer.transform.localPosition.ReplaceY(280f - num2);
		UIEventListener uIEventListener = UIEventListener.Get(playerButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			TweenColor tweenColor = TweenColor.Begin(enemyName.gameObject, GameVariables.durationOfNameButtonColor, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.playerProperties.isBot)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(enemyName.text, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(enemyName.text, enemyPlayerId);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(enemyIconButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (Singleton<GameController>.instance.opponent.playerProperties.isBot)
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowBotDialog(enemyName.text, Singleton<GameController>.instance.opponent.playerProperties.databaseInfoBot);
			}
			else
			{
				GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(enemyName.text, enemyPlayerId);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(enemyReportButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (Singleton<GameController>.instance.opponent.playerProperties.isBot)
			{
				ReportUserDialog.ShowBotReportDialog(Singleton<GameController>.instance.opponent.playerBot.botConfig.NUMBER);
			}
			else
			{
				ReportUserDialog.ShowReportDialog(enemyPlayerId);
			}
		});
	}

	private void InitAnimators()
	{
		TweenAnimator tweenAnimator = base.gameObject.AddComponent<TweenAnimator>();
		tweenAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		tweenAnimator.AddTween(from: Color.black, id: 1, tweenType: TweenAnimator.TweenType.Color, tweenTarget: enemyBackground.gameObject, time: 0.4f, to: Color.black, delay: 0.5f);
		mAnimatorWin = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorWin.allTweens = new List<TweenAnimator.TweenRecord>();
		InitAnimationWin();
		mAnimatorLose = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorLose.allTweens = new List<TweenAnimator.TweenRecord>();
		InitAnimationLose();
		mAnimatorUnits = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorUnits.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimatorCards = base.gameObject.AddComponent<TweenAnimator>();
		mAnimatorCards.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.Add(tweenAnimator);
		mAnimator.Add(mAnimatorWin);
		mAnimator.Add(mAnimatorUnits);
		mAnimator.Add(mAnimatorCards);
	}

	private void InitAnimationWin()
	{
		float time = 0.4f;
		float num = 45f;
		float num2 = 20f;
		float num3 = 153f;
		Vector3 vector = new Vector3(num3 * -1f, 0f, 0f);
		Vector3 vector2 = vector.ReplaceX((num3 + num2) * -1f);
		Vector3 vector3 = vector.ReplaceX(num * -1f);
		Vector3 vector4 = new Vector3(num3, 0f, 0f);
		Vector3 vector5 = vector4.ReplaceX(num3 + num2);
		Vector3 vector6 = vector4.ReplaceX(num);
		float val = 45f;
		float num4 = 15f;
		float num5 = 167f;
		Vector3 vector7 = new Vector3(0f, num5, 0f);
		Vector3 vector8 = vector7.ReplaceY(num5 + num4);
		Vector3 vector9 = vector7.ReplaceY(val);
		mAnimatorWin.AddTween(1, TweenAnimator.TweenType.Alpha, leftWing.gameObject, time, 1f, 0f, -1, 0f);
		mAnimatorWin.AddTween(2, TweenAnimator.TweenType.Alpha, rightWing.gameObject, time, 1f, 0f, -1, 0f);
		mAnimatorWin.AddTween(3, TweenAnimator.TweenType.Alpha, topRibbon.gameObject, time, 1f, 0f, -1, 0f);
		TweenAnimator tweenAnimator = mAnimatorWin;
		object obj = vector3;
		tweenAnimator.AddTween(4, TweenAnimator.TweenType.Position, leftWing.gameObject, time, vector2, 0f, 1, obj);
		TweenAnimator tweenAnimator2 = mAnimatorWin;
		obj = vector6;
		tweenAnimator2.AddTween(5, TweenAnimator.TweenType.Position, rightWing.gameObject, time, vector5, 0f, 1, obj);
		TweenAnimator tweenAnimator3 = mAnimatorWin;
		obj = vector9;
		tweenAnimator3.AddTween(6, TweenAnimator.TweenType.Position, topRibbon.gameObject, time, vector8, 0f, 1, obj);
		mAnimatorWin.AddTween(7, TweenAnimator.TweenType.Position, leftWing.gameObject, time, vector, 0f, 6);
		mAnimatorWin.AddTween(8, TweenAnimator.TweenType.Position, rightWing.gameObject, time, vector4, 0f, 6);
		mAnimatorWin.AddTween(9, TweenAnimator.TweenType.Position, topRibbon.gameObject, time, vector7, 0f, 6);
	}

	private void InitAnimationLose()
	{
		float time = 0.3f;
		Vector3 localScale = kiaStamp.transform.localScale;
		Vector3 vector = localScale.MultiplyXY(10f);
		Vector3 vector2 = localScale;
		Transform parent = loseStamp.transform.parent;
		float num = 10f;
		int num2 = 3;
		mAnimatorLose.allTweens.Clear();
		mAnimatorLose.AddTween(1, TweenAnimator.TweenType.Alpha, kiaStamp.gameObject, 0.25f, 1f, 0f, -1, 0f);
		TweenAnimator tweenAnimator = mAnimatorLose;
		object obj = vector;
		tweenAnimator.AddTween(2, TweenAnimator.TweenType.Scale, kiaStamp.gameObject, time, vector2, 0f, 1, obj);
		time = 0.1f;
		int playAfterIdFinished;
		while (num > 2f)
		{
			TweenAnimator tweenAnimator2 = mAnimatorLose;
			playAfterIdFinished = num2 - 1;
			tweenAnimator2.AddTween(num2, TweenAnimator.TweenType.Rotation, parent.gameObject, time, Quaternion.Euler(0f, 0f, num), 0f, playAfterIdFinished, null, UITweener.Method.Linear);
			TweenAnimator tweenAnimator3 = mAnimatorLose;
			playAfterIdFinished = num2;
			tweenAnimator3.AddTween(num2 + 1, TweenAnimator.TweenType.Rotation, parent.gameObject, time, Quaternion.Euler(0f, 0f, -1f * num), 0f, playAfterIdFinished, null, UITweener.Method.Linear);
			num2 += 2;
			num *= 0.3f;
		}
		TweenAnimator tweenAnimator4 = mAnimatorLose;
		playAfterIdFinished = num2 - 1;
		tweenAnimator4.AddTween(num2, TweenAnimator.TweenType.Rotation, parent.gameObject, 0.15f, Quaternion.Euler(0f, 0f, 0f), 0f, playAfterIdFinished, null, UITweener.Method.Linear);
		mAnimatorLose.TweenFinished = delegate(int tweenId)
		{
			if (tweenId == 1)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.KilledInAction);
			}
		};
	}

	public void InitGuiValues()
	{
		mAllReposited = false;
		EnableReportButton();
		InitializeEnemy();
		InitializeUnitsAndCards();
	}

	public void AnimateShow(float fadeInTime)
	{
		CreateUnitsAnimation();
		CreateCardsAnimation();
	}

	private void InitializeEnemy()
	{
		DisableWinLoseRibbon();
		enemyCards.alpha = 0f;
		enemyUnits.alpha = 0f;
		enemyBackground.color = Color.black.ReplaceA(0f);
		switch (Singleton<GameController>.instance.gameEndReason)
		{
		case GameController.GameEndReason.Win:
		case GameController.GameEndReason.WinByForfeit:
			mAnimator[0].allTweens[0].to = Color.black;
			mAnimator[1] = mAnimatorLose;
			break;
		case GameController.GameEndReason.Killed:
		case GameController.GameEndReason.Forfeit:
			mAnimator[0].allTweens[0].to = Colours.yellowGold;
			mAnimator[1] = mAnimatorWin;
			break;
		}
		Debug.Log($"Opponent player properties:\nfbId: {Singleton<GameController>.instance.opponent.playerProperties.facebookID}\nleague: {Singleton<GameController>.instance.opponent.playerProperties.league}\nbeginners league: {Singleton<GameController>.instance.opponent.playerProperties.beginnersLeague}\nlevel: {Singleton<GameController>.instance.opponent.playerProperties.level}\nname: {Singleton<GameController>.instance.opponent.playerProperties.name}\nvip: {Singleton<GameController>.instance.opponent.playerProperties.isVip}\nmedals: {Singleton<GameController>.instance.opponent.playerProperties.medals}\nAP: {Singleton<GameController>.instance.opponent.playerProperties.armyPower}\nvisual: {Singleton<GameController>.instance.opponent.playerProperties.playerVisuals[3]}");
		enemy.avatar = Singleton<ArmyPreviewCamera>.instance.player2Texture;
		string text = GameVariables.CountryCodeSpriteName(Singleton<GameController>.instance.opponent.playerProperties.country);
		bool flag = !string.IsNullOrEmpty(text) && (!Singleton<GameController>.instance.isCampaignBot || !Singleton<GameController>.instance.isCoopBot);
		enemyCountry.gameObject.SetActive(flag);
		if (flag)
		{
			enemyCountry.spriteName = text;
		}
		int matchMadeGames = Singleton<GameController>.instance.opponent.playerProperties.matchMadeGames;
		League league = Singleton<GameController>.instance.opponent.playerProperties.league;
		int beginnersLeague = Singleton<GameController>.instance.opponent.playerProperties.beginnersLeague;
		enemyLeague.gameObject.SetActive(league != League.NoLeague || beginnersLeague > 0);
		if (matchMadeGames <= 1)
		{
			enemyLeague.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(1);
			enemyLeague.MakePixelPerfect();
			enemyLeague.alpha = ((matchMadeGames >= 1) ? 1f : 0.7f);
		}
		else if (beginnersLeague > 0)
		{
			enemyLeague.spriteName = Singleton<GameVariables>.instance.BeginnersLeagueIcon(beginnersLeague);
			enemyLeague.MakePixelPerfect();
			enemyLeague.alpha = 1f;
		}
		else if (league != League.NoLeague)
		{
			enemyLeague.spriteName = GameVariables.leagueNames[league].Value2;
			enemyLeague.MakePixelPerfect();
			enemyLeague.alpha = ((!Singleton<GameController>.instance.opponent.playerProperties.isInLeague) ? 0.7f : 1f);
		}
		LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition(Singleton<GameController>.instance.opponent.playerProperties.level);
		enemyRankIcon.spriteName = levelDefinition.iconName;
		enemyRank.text = levelDefinition.displayString;
		enemyName.text = Singleton<GameController>.instance.opponent.playerProperties.name;
		float x = enemyName.relativeSize.x;
		playerButton.center = new Vector3(x / 2f, 0.1f, -1f);
		playerButton.size = new Vector3(x + 0.4f, 1.5f, 1f);
		TweenColor.Begin(enemyName.gameObject, 0f, Color.white);
		enemyPlayerId = Singleton<GameController>.instance.opponent.playerProperties.playerID;
		WarArenaCrown warArenaCrown = Singleton<GameController>.instance.opponent.playerProperties.warArenaCrown;
		bool flag2 = warArenaCrown != WarArenaCrown.None;
		enemyCrown.transform.parent.gameObject.SetActive(flag2);
		if (flag2)
		{
			enemyCrown.spriteName = GameVariables.crownSprites[warArenaCrown];
			enemyCrown.MakePixelPerfect();
		}
		bool isVip = Singleton<GameController>.instance.opponent.playerProperties.isVip;
		enemyVip.alpha = ((!isVip) ? 0f : 1f);
		int num = 649;
		if (flag2)
		{
			num -= 53;
		}
		if (isVip)
		{
			num -= 136;
		}
		MiscTools.SetUILabelRescale(enemyName, 47f, 20f, num);
		enemyNameAndVipTable.repositionNow = true;
		enemyMedals.text = MiscTools.FormatBigNumber(Singleton<GameController>.instance.opponent.playerProperties.medals);
		enemyArmyPower.text = MiscTools.FormatBigNumber(Singleton<GameController>.instance.opponent.playerProperties.armyPowerX10);
		PlayerVisual playerVisual = CamosManager.instance.playerVisualCategories[3][Singleton<GameController>.instance.opponent.playerProperties.playerVisuals[3]];
		if (!playerVisual.isEmptyPowerBand)
		{
			enemyPowerBandNA.alpha = 0f;
			enemyPowerBand.spriteName = playerVisual.icon;
			enemyPowerBand.MakePixelPerfect();
			enemyPowerBand.transform.localScale = enemyPowerBand.transform.localScale.MultiplyXY(0.33f);
			enemyPowerBand.alpha = 1f;
			enemyPowerBandValue.text = playerVisual.decalValueString;
			enemyPowerBandValue.alpha = 1f;
			enemyPowerBandIcon.spriteName = playerVisual.decalMiniIcon;
			enemyPowerBandIcon.MakePixelPerfect();
			enemyPowerBandIcon.color = playerVisual.decalMiniIconColor;
			enemyTablePowerBand.repositionNow = true;
		}
		else
		{
			enemyPowerBand.alpha = 0f;
			enemyPowerBandValue.alpha = 0f;
			enemyPowerBandIcon.alpha = 0f;
			enemyPowerBandNA.alpha = 1f;
		}
	}

	private void InitializeUnitsAndCards()
	{
		mPool.FreeObjectsWithPrefab(unitEndScreenRecordPrefab);
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.DestroyPooled();
		}
		mCardsToAnimate.Clear();
		List<UnitUpgradeDefinition> upgrades = Singleton<GameController>.instance.opponent.playerProperties.upgrades;
		mUnitsToAnimate.Clear();
		string text = string.Empty;
		for (int i = 0; i < upgrades.Count; i++)
		{
			if (mUnitsToAnimate.Count >= 9)
			{
				break;
			}
			text += $"{LevelManager.instance.behaviours[i].unitName} {upgrades[i]}\t\t";
			UnitUpgradeDefinition unitUpgradeDefinition = upgrades[i];
			if (unitUpgradeDefinition.isEquipped)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				string text2 = string.Format("Enemy Unit {0} {1}", levelBehaviour.upgradeSlots.unlockLevel.displayNumber.ToString("D2"), levelBehaviour.unitName);
				UnitEndScreenRecord unitEndScreenRecord = (UnitEndScreenRecord)mPool.InstantiateAsChild(unitEndScreenRecordPrefab, unitGrid.gameObject, text2);
				if (unitEndScreenRecord != null)
				{
					bool isEarlyUnlock = levelBehaviour.upgradeSlots.unlockLevel.displayNumber > Singleton<GameController>.instance.opponent.playerProperties.level;
					unitEndScreenRecord.Initialize(i, levelBehaviour.upgradeSlots.GetActualLevelForIndex(unitUpgradeDefinition.unitUpgrades.slotUpgradeindex), unitUpgradeDefinition.tier, isEarlyUnlock);
					mUnitsToAnimate.Add(unitEndScreenRecord);
				}
			}
		}
		Debug.Log("Enemy units:\n" + text);
		if (mUnitsToAnimate.Count == 0)
		{
			Debug.LogError("Enemy has no army");
		}
		else
		{
			mUnitsToAnimate.Sort((UnitEndScreenRecord unit1, UnitEndScreenRecord unit2) => string.Compare(unit1.gameObject.name, unit2.gameObject.name, StringComparison.Ordinal));
		}
		unitGrid.repositionNow = true;
		UIGrid uIGrid = unitGrid;
		uIGrid.onReposition = (UIGrid.OnReposition)Delegate.Combine(uIGrid.onReposition, new UIGrid.OnReposition(OnUnitGridReposition));
		List<Card> list = CardManager.instance.enemyCards;
		string text3 = "*************** Enemy Played Cards *************\n";
		for (int num = 0; num < list.Count; num++)
		{
			if (!(list[num] == null))
			{
				text3 += $"{list[num].cardName} \t\t";
				Card card = list[num];
				CardRecord cardRecord = (CardRecord)mPool.InstantiateAsChild(cardRecordPrefab, cardsGrid.gameObject, $"Enemy Card {num} {card.cardName}");
				if (cardRecord != null)
				{
					cardRecord.Initialize(card);
					mCardsToAnimate.Add(cardRecord);
				}
			}
		}
		enemyCards.transform.parent.gameObject.SetActive(mCardsToAnimate.Count > 0);
		Debug.Log(text3 + "\n***********************************************");
		cardsGrid.repositionNow = true;
		UIGrid uIGrid2 = cardsGrid;
		uIGrid2.onReposition = (UIGrid.OnReposition)Delegate.Remove(uIGrid2.onReposition, new UIGrid.OnReposition(OnCardGridReposition));
		UIGrid uIGrid3 = cardsGrid;
		uIGrid3.onReposition = (UIGrid.OnReposition)Delegate.Combine(uIGrid3.onReposition, new UIGrid.OnReposition(OnCardGridReposition));
	}

	private void CreateUnitsAnimation()
	{
		mAnimatorUnits.allTweens.Clear();
		float num = 0f;
		int num2 = 1;
		int num3 = 2;
		mAnimatorUnits.AddTween(num2, TweenAnimator.TweenType.Alpha, enemyUnits.gameObject, 0.5f, 1f, 0f, -1, 0f);
		foreach (UnitEndScreenRecord item in mUnitsToAnimate)
		{
			TweenAlpha.Begin(item.unitPanel.gameObject, 0f, 0f);
			TweenAlpha.Begin(item.tierPanel.gameObject, 0f, 0f);
			item.unitPanel.alpha1 = 0f;
			item.tierPanel.alpha1 = 0f;
			mAnimatorUnits.AddTween(num3, TweenAnimator.TweenType.Alpha, item.unitPanel.gameObject, 0.4f, 1f, num, num2);
			num3++;
			mAnimatorUnits.AddTween(num3, TweenAnimator.TweenType.Alpha, item.tierPanel.gameObject, 0.4f, 1f, num, num2);
			num += 0.3f;
			num3++;
		}
		mAnimator[2] = mAnimatorUnits;
	}

	private void CreateCardsAnimation()
	{
		mAnimatorCards.allTweens.Clear();
		if (mCardsToAnimate.Count > 0)
		{
			float num = 0f;
			int num2 = 1;
			int num3 = 2;
			mAnimatorCards.AddTween(num2, TweenAnimator.TweenType.Alpha, enemyCards.gameObject, 0.5f, 1f, 0f, -1, 0f);
			foreach (CardRecord item in mCardsToAnimate)
			{
				TweenAlpha.Begin(item.cardPanel.gameObject, 0f, 0f);
				item.cardPanel.alpha1 = 0f;
				mAnimatorCards.AddTween(num3, TweenAnimator.TweenType.Alpha, item.gameObject, 0.5f, 1f, num, num2, 0f);
				num += 0.3f;
				num3++;
			}
			mAnimatorCards.GenerateTweens();
		}
		mAnimator[3] = mAnimatorCards;
	}

	private void DisableWinLoseRibbon()
	{
		leftWing.alpha = 0f;
		rightWing.alpha = 0f;
		topRibbon.alpha = 0f;
		winStamps.SetActive(value: false);
		kiaStamp.alpha = 0f;
		loseStamp.SetActive(value: false);
	}

	private void EnableWinLoseRibbon()
	{
		winStamps.SetActive(value: true);
		leftWing.alpha = 0f;
		rightWing.alpha = 0f;
		topRibbon.alpha = 0f;
		loseStamp.SetActive(value: true);
		kiaStamp.alpha = 0f;
	}

	private void OnUnitGridReposition()
	{
		UIGrid uIGrid = unitGrid;
		uIGrid.onReposition = (UIGrid.OnReposition)Delegate.Remove(uIGrid.onReposition, new UIGrid.OnReposition(OnUnitGridReposition));
		if (mAllReposited)
		{
			table.repositionNow = true;
			UITable uITable = table;
			uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnTableReposition));
		}
		mAllReposited = true;
	}

	private void OnCardGridReposition()
	{
		UIGrid uIGrid = cardsGrid;
		uIGrid.onReposition = (UIGrid.OnReposition)Delegate.Remove(uIGrid.onReposition, new UIGrid.OnReposition(OnCardGridReposition));
		if (mAllReposited)
		{
			table.repositionNow = true;
			UITable uITable = table;
			uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, new UITable.OnReposition(OnTableReposition));
		}
		mAllReposited = true;
	}

	private void OnTableReposition()
	{
		UITable uITable = table;
		uITable.onReposition = (UITable.OnReposition)Delegate.Remove(uITable.onReposition, new UITable.OnReposition(OnTableReposition));
		panelEnemy.AlignToPos(instant: true);
		EnableWinLoseRibbon();
	}

	public void EnableReportButton()
	{
		enemyReportButton.enabled = true;
		enemyReportButtonDisabled.SetActive(value: false);
		enemyReportButtonLabel.color = Color.white;
	}

	public void DisableReportButton()
	{
		enemyReportButton.enabled = false;
		enemyReportButtonDisabled.SetActive(value: true);
		enemyReportButtonLabel.color = Colours.grayButton;
	}

	public void SetCardsAvailable()
	{
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.SetAvailable();
		}
	}

	internal void FinishAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.FinishTweens();
		}
	}

	internal void ResetAnimation()
	{
		foreach (TweenAnimator item in mAnimator)
		{
			item.ResetTweens();
		}
	}

	public void DoAfterHide()
	{
		mPool.FreeObjectsWithPrefab(unitEndScreenRecordPrefab);
		foreach (CardRecord item in mCardsToAnimate)
		{
			item.DestroyPooled();
		}
		mCardsToAnimate.Clear();
	}
}
