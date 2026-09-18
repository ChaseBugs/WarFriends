using System;
using System.Collections.Generic;
using UnityEngine;

public class BigArenaButton : Core_BaseScript
{
	private enum RightPart
	{
		Rule,
		Hero
	}

	[Header("Core")]
	public BoxCollider arenaCollider;

	[Header("Left Part")]
	public UILabel arenaNameLabel;

	public UILabel arenaDescriptionLabel;

	[Header("- Rewards Part")]
	public GameObject rewardPart;

	public UISprite[] rewardsBackgrounds;

	public WarArenaSmallRewardRecord wararenaSmallRewardRecordPrefab;

	public UIPanel rewardPanel;

	public UIDraggablePanel rewardDraggablePanel;

	public UIPooledGrid rewardGrid;

	[Header("Right Part")]
	public GameObject ruleButton;

	public UISprite ruleButtonBackground;

	public UILabel ruleButtonLabel;

	public GameObject heroesButton;

	public UISprite heroesButtonBackground;

	public UILabel heroesButtonLabel;

	[Header("- Rule Part")]
	public GameObject rulePart;

	public ArenaRuleRecord arenaRuleRecordPrefab;

	public UIPanel rulePanel;

	public UIDraggablePanel ruleDraggablePanel;

	public UIPooledClassicTable ruleTable;

	[Header("- Hero Part")]
	public GameObject heroPart;

	public ArenaHeroRecord arenaHeroRecordPrefab;

	public UIPanel heroPanel;

	public UIDraggablePanel heroDraggablePanel;

	public UIPooledGrid heroGrid;

	public GameObject heroWaiting;

	public UILabel heroEmpty;

	public UIPanel yourRecordPanel;

	[Header("Bottom Part")]
	public UISprite arenaBottomBorder;

	[Header("- Locked Part")]
	public GameObject lockedPart;

	public UILabel lockedLabel;

	[Header("- Opened Part")]
	public GameObject openedPart;

	public UILabel timeLabel;

	public GameObject waitingPart;

	private bool mUpdateTime;

	private float mTimer;

	private List<WarArenaRule.WarArenaRuleGui> mGuiRules;

	private List<DatabasePlayerData> mHeroes;

	private List<WarArenaReward> mRewards;

	private RightPart mCurrentPart;

	private Color mButtonBlack = new Color(0f, 0f, 0f, 0.25f);

	private Color mButtonWhite = new Color(1f, 1f, 1f, 0.05f);

	private ArenaRuleRecord mRuleRecordForHeight;

	private ArenaHeroRecord mYourRecord;

	public ArenaRuleRecord ruleRecordForHeight
	{
		get
		{
			if (mRuleRecordForHeight == null)
			{
				mRuleRecordForHeight = UnityEngine.Object.Instantiate(arenaRuleRecordPrefab);
				mRuleRecordForHeight.transform.parent = base.transform;
				mRuleRecordForHeight.name = "Rule Record For Height";
				mRuleRecordForHeight.transform.localPosition = new Vector3(0f, -3f * (float)UIRoot.list[0].activeHeight, 0f);
				mRuleRecordForHeight.transform.localScale = Vector3.one;
			}
			return mRuleRecordForHeight;
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(arenaCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenArenaClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(ruleButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(RuleButtonClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(heroesButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HeroButtonClick));
		WarArena.instance.WarArenaDataChanged += UpdateWarArenaLook;
		WarArena.instance.WarArenaExpired += UpdateWarArenaLook;
		WarArena.instance.WarArenaStarter += UpdateWarArenaLook;
		GetArenaLeaderboardsRequest.Response = (Action)Delegate.Combine(GetArenaLeaderboardsRequest.Response, new Action(OnGetArenaLeaderboardRequest));
		int num = Mathf.FloorToInt(UIRoot.list[0].activeWidth - 1336f);
		if (num % 2 == 1)
		{
			num--;
		}
		UISprite[] array = rewardsBackgrounds;
		foreach (UISprite uISprite in array)
		{
			uISprite.transform.localScale = uISprite.transform.localScale.ReplaceX(num);
		}
		rewardPanel.clipRange = rewardPanel.clipRange.ReplaceZ(num - 10);
		rewardPart.transform.localPosition = rewardPart.transform.localPosition.ReplaceX(50 + num / 2);
	}

	private void OpenArenaClick(GameObject go)
	{
		if (LevelManager.instance.isWarArenaLocked)
		{
			GuiElementSingle<ArenaUnlockedDialog>.instance.ShowDialog();
		}
		else
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowWarArena(WarArena.instance.isArenaTicketBought ? ArenaScreen.ArenaScreenMode.MainArena : ArenaScreen.ArenaScreenMode.EnterArena);
		}
	}

	private void RuleButtonClick(GameObject go)
	{
		if (mCurrentPart != RightPart.Rule)
		{
			mCurrentPart = RightPart.Rule;
			TweenColor.Begin(ruleButtonLabel.gameObject, 0.3f, Color.white, Colours.greenArena);
			TweenColor.Begin(ruleButtonBackground.gameObject, 0.3f, mButtonWhite, mButtonBlack);
			TweenColor.Begin(heroesButtonLabel.gameObject, 0.3f, Colours.greenArena, Color.white);
			TweenColor.Begin(heroesButtonBackground.gameObject, 0.3f, mButtonBlack, mButtonWhite);
			rulePart.SetActive(value: true);
			rulePanel.alpha1 = 0f;
			ShowRules();
			TweenAlpha.Begin(rulePanel.gameObject, 0.3f, 0f, 1f).onFinished = null;
			TweenAlpha.Begin(heroPanel.gameObject, 0.3f, 1f, 0f).onFinished = delegate
			{
				heroPart.SetActive(value: false);
			};
			TweenAlpha.Begin(yourRecordPanel.gameObject, 0.3f, 1f, 0f);
		}
	}

	private void HeroButtonClick(GameObject go)
	{
		if (mCurrentPart != RightPart.Hero)
		{
			mCurrentPart = RightPart.Hero;
			TweenColor.Begin(heroesButtonLabel.gameObject, 0.3f, Color.white, Colours.greenArena);
			TweenColor.Begin(heroesButtonBackground.gameObject, 0.3f, mButtonWhite, mButtonBlack);
			TweenColor.Begin(ruleButtonLabel.gameObject, 0.3f, Colours.greenArena, Color.white);
			TweenColor.Begin(ruleButtonBackground.gameObject, 0.3f, mButtonBlack, mButtonWhite);
			heroPart.SetActive(value: true);
			heroPanel.alpha1 = 0f;
			ShowHeroes();
			TweenAlpha.Begin(heroPanel.gameObject, 0.3f, 0f, 1f).onFinished = null;
			TweenAlpha.Begin(yourRecordPanel.gameObject, 0.3f, 0f, 1f);
			TweenAlpha.Begin(rulePanel.gameObject, 0.3f, 1f, 0f).onFinished = delegate
			{
				rulePart.SetActive(value: false);
			};
		}
	}

	private void UpdateWarArenaLook()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	private void OnGetArenaLeaderboardRequest()
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.isShowed)
		{
			HeroesLoaded(Singleton<ServerResultsCache>.instance.GetArenaLeaderboard());
		}
	}

	public void InitGuiValues()
	{
		bool showWarArenaPromoLocked = LevelManager.instance.showWarArenaPromoLocked;
		bool isWarArenaLocked = LevelManager.instance.isWarArenaLocked;
		bool isExpired = WarArena.instance.isExpired;
		if (WarArena.instance.isExpired)
		{
			WarArena.instance.TryGetNewArena();
		}
		mUpdateTime = !isWarArenaLocked;
		arenaCollider.enabled = showWarArenaPromoLocked || (!isWarArenaLocked && !isExpired);
		lockedPart.SetActive(isWarArenaLocked);
		openedPart.SetActive(!isWarArenaLocked);
		arenaBottomBorder.alpha = ((!isWarArenaLocked) ? 1f : 0.5f);
		if (isWarArenaLocked)
		{
			lockedLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), MiscTools.FormatBigNumber(LevelManager.instance.warArenaUnlockLevel));
		}
		waitingPart.SetActive(isExpired);
		arenaNameLabel.text = ((!isExpired) ? WarArena.instance.warArenaConfig.arenaName : string.Empty);
		arenaDescriptionLabel.text = ((!isExpired) ? WarArena.instance.warArenaConfig.arenaDescription : string.Empty);
		mCurrentPart = RightPart.Rule;
		rulePart.SetActive(value: true);
		heroPart.SetActive(value: false);
		ruleButtonLabel.color = Colours.greenArena;
		ruleButtonBackground.color = mButtonBlack;
		heroesButtonLabel.color = Color.white;
		heroesButtonBackground.color = mButtonWhite;
		heroesButtonLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_BUTTONPREVIOUSHEROES" : "ID_BUTTONHEROES");
		heroEmpty.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_NOHEROESINPREVIOUSARENA" : "ID_NOHEROESINCURRENTARENA");
	}

	public void ShowArenaButton()
	{
		if (mCurrentPart == RightPart.Rule)
		{
			ShowRules();
		}
		else
		{
			ShowHeroes();
		}
		ShowRewards();
	}

	public void DoAfterHide()
	{
		mGuiRules = null;
		mHeroes = null;
		mRewards = null;
		ruleTable.MakeEmpty();
		heroGrid.MakeEmpty();
		rewardGrid.MakeEmpty();
		if (mYourRecord != null)
		{
			mYourRecord.DestroyPooled();
			mYourRecord = null;
		}
	}

	private void ShowRewards()
	{
		mRewards = ((WarArena.instance.warArenaConfig != null) ? WarArena.instance.warArenaConfig.warArenaRewards : new List<WarArenaReward>());
		rewardGrid.MakeEmpty();
		rewardGrid.init(mRewards.Count, RewardInstantiate, RewardFree, rewardDraggablePanel);
		rewardDraggablePanel.AlignToPos(instant: true);
	}

	private Transform RewardInstantiate(int index)
	{
		if (index >= 0 && index < mRewards.Count)
		{
			WarArenaSmallRewardRecord warArenaSmallRewardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(wararenaSmallRewardRecordPrefab, rewardGrid.gameObject, $"Reward {index:D2}") as WarArenaSmallRewardRecord;
			if (warArenaSmallRewardRecord != null)
			{
				warArenaSmallRewardRecord.Initialize(mRewards[index]);
				return warArenaSmallRewardRecord.transform;
			}
		}
		return null;
	}

	private void RewardFree(Transform obj)
	{
		if (obj != null)
		{
			WarArenaSmallRewardRecord component = obj.GetComponent<WarArenaSmallRewardRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void ShowRules()
	{
		mGuiRules = WarArenaGui.currentArenaGuiRules;
		ruleTable.MakeEmpty();
		ruleTable.Initialize(mGuiRules.Count, RuleInstantiate, RuleFree, GetRuleHeight, ruleDraggablePanel);
		ruleDraggablePanel.AlignToPos(instant: true);
	}

	private Transform RuleInstantiate(int index)
	{
		if (index >= 0 && index < mGuiRules.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(arenaRuleRecordPrefab, ruleTable.gameObject, $"Rule {index:D2}") as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.Initialize(mGuiRules[index], showStateIcon: false, 560, 70);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	private void RuleFree(Transform obj)
	{
		if (obj != null)
		{
			ArenaRuleRecord component = obj.GetComponent<ArenaRuleRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private float GetRuleHeight(int index)
	{
		if (index >= 0 && index < mGuiRules.Count)
		{
			ruleRecordForHeight.Initialize(mGuiRules[index], showStateIcon: false, 560, 70);
			return ruleRecordForHeight.background.transform.localScale.y;
		}
		return 0f;
	}

	private void ShowHeroes()
	{
		heroGrid.MakeEmpty();
		heroEmpty.gameObject.SetActive(value: false);
		heroWaiting.SetActive(value: true);
		if (mYourRecord == null)
		{
			mYourRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(arenaHeroRecordPrefab, heroPart, "Your Best") as ArenaHeroRecord;
			mYourRecord.transform.localPosition = new Vector3(0f, -406f, 0f);
		}
		if (mYourRecord != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int winsNumber = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			mYourRecord.InitializeYou(flag, winsNumber, 528);
		}
		GetArenaLeaderboardsRequest.SendRequest();
	}

	private void HeroesLoaded(List<DatabasePlayerData> players)
	{
		mHeroes = players;
		heroWaiting.SetActive(value: false);
		heroEmpty.gameObject.SetActive(mHeroes.Count == 0);
		if (mHeroes.Count > 0)
		{
			heroGrid.MakeEmpty();
			heroGrid.init(mHeroes.Count, InstantiateHero, HeroFree, heroDraggablePanel);
			heroDraggablePanel.AlignToPos(instant: true);
		}
	}

	private Transform InstantiateHero(int index)
	{
		if (index >= 0 && index < mHeroes.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(arenaHeroRecordPrefab, heroGrid.gameObject, $"Hero {index:D2}") as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.Initialize(index + 1, mHeroes[index], 528);
				return arenaHeroRecord.transform;
			}
		}
		return null;
	}

	private void HeroFree(Transform obj)
	{
		if (obj != null)
		{
			ArenaHeroRecord component = obj.GetComponent<ArenaHeroRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private void Update()
	{
		if (!mUpdateTime)
		{
			return;
		}
		mTimer += Time.deltaTime;
		if (mTimer > 0.333f)
		{
			mTimer -= 0.333f;
			bool isExpired = WarArena.instance.isExpired;
			timeLabel.text = ((!isExpired) ? WarArenaGui.CreateArenaTimeTextWithColour(Colours.stringBlack) : string.Empty);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.TryGetNewArena();
			}
		}
	}
}
