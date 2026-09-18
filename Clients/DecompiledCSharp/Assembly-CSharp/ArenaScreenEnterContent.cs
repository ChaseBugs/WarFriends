using System;
using System.Collections.Generic;
using UnityEngine;

public class ArenaScreenEnterContent : Core_BaseScript
{
	[Header("Rules Draggable")]
	[SerializeField]
	private UIDraggablePanel mDraggableRules;

	[SerializeField]
	private UIPooledClassicTable mRulesTable;

	[SerializeField]
	private ArenaRuleRecord mArenaRulePrefab;

	[SerializeField]
	[Header("Heroes Draggable")]
	private UILabel mArenaHeroesLabel;

	[SerializeField]
	private UILabel mArenaHeroesEmptyLabel;

	[SerializeField]
	private UIDraggablePanel mDraggableHeroes;

	[SerializeField]
	private UIPooledGrid mPooledHeroesGrid;

	[SerializeField]
	private ArenaHeroRecord mArenaHeroPrefab;

	[SerializeField]
	private GameObject mArenaHeroInfo;

	[SerializeField]
	private GameObject mHeroWaiting;

	[Header("Rewards Draggable")]
	[SerializeField]
	private UIDraggablePanel mDraggableRewards;

	[SerializeField]
	private UIPooledGrid mPooledRewardsGrid;

	[SerializeField]
	private WararenaRewardRecord mArenaRewardPrefab;

	[SerializeField]
	[Header("Enter Arena Look")]
	private UILabel mArenaDescription;

	[SerializeField]
	private GameObject mBottomLeftPartMain;

	[SerializeField]
	private GameObject mBottomPartMain;

	[SerializeField]
	private GameObject mBottomPartEnter;

	[SerializeField]
	private GameObject mShowRulesButton;

	[SerializeField]
	private GameObject mShowRulesLogoButton;

	[SerializeField]
	[Header("Heroes Your Best")]
	private GameObject mArenaHeroesContent;

	[SerializeField]
	[Header("Arena Enter Button")]
	private GameObject mEnterPricePart;

	[SerializeField]
	private UISprite mEnterBackground;

	[SerializeField]
	private UILabel mEnterPrice;

	[SerializeField]
	private UISprite mEnterBorder;

	[SerializeField]
	private UISprite mEnterLogo;

	[SerializeField]
	private UILabel mEnterLabel;

	[SerializeField]
	private GameObject mEnterArenaWaiting;

	[Header("Buttons")]
	[SerializeField]
	private BoxCollider mArenaEnterButton;

	[SerializeField]
	private UIPanel mArenaEnterButtonReflection;

	private List<WarArenaRule.WarArenaRuleGui> mGuiRules;

	private List<DatabasePlayerData> mHeroes;

	private List<WarArenaReward> mRewards;

	private ArenaHeroRecord mYourRecord;

	private ArenaRuleRecord mRuleRecordForHeight;

	private bool mPreviousArenaState;

	public ArenaRuleRecord ruleRecordForHeight
	{
		get
		{
			if (mRuleRecordForHeight == null)
			{
				mRuleRecordForHeight = UnityEngine.Object.Instantiate(mArenaRulePrefab);
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
		GetArenaLeaderboardsRequest.Response = (Action)Delegate.Combine(GetArenaLeaderboardsRequest.Response, new Action(OnGetArenaLeaderboardsRequest));
		UIEventListener uIEventListener = UIEventListener.Get(mArenaEnterButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnArenaEnterClick));
		EnterArenaRequest.Response = (Action<bool>)Delegate.Combine(EnterArenaRequest.Response, new Action<bool>(OnEnterArenaResponse));
	}

	public void InitGUIValues()
	{
		InitButtonState();
		SetRulesVariables();
		GuiScreenSingle<ArenaScreen>.instance.rulesShowed = false;
		mRulesTable.MakeEmpty();
		mRulesTable.Initialize(mGuiRules.Count, InstantiateRule, FreeRule, GetRuleHeight, mDraggableRules);
		mArenaDescription.text = ((WarArena.instance.warArenaConfig == null) ? string.Empty : WarArena.instance.warArenaConfig.arenaDescription);
		mRewards = WarArena.instance.warArenaConfig.warArenaRewards;
		mPooledRewardsGrid.MakeEmpty();
		mPooledRewardsGrid.init(mRewards.Count, InstantiateReward, FreeReward, mDraggableRewards);
		InitializeHeroes();
	}

	public void SetEnterButton()
	{
		bool isOpened = WarArena.instance.isOpened;
		mArenaEnterButtonReflection.gameObject.SetActive(isOpened);
		mEnterPricePart.SetActive(isOpened);
		mArenaEnterButton.GetComponent<UIButtonScale>().enabled = isOpened;
		mEnterLabel.pivot = ((!isOpened) ? UIWidget.Pivot.Center : UIWidget.Pivot.Left);
		mEnterLabel.transform.localPosition = mEnterLabel.transform.localPosition.ReplaceX((!isOpened) ? 0f : (-380f));
		if (isOpened)
		{
			mEnterLabel.text = Localization.Localize("ID_ENTERARENA");
			MiscTools.SetUILabelRescale(mEnterLabel, 62f, 20f, 540);
		}
		else if (WarArena.instance.isExpired)
		{
			mEnterLabel.text = Localization.Localize("ID_ARENACLOSED");
			MiscTools.SetUILabelRescale(mEnterLabel, 62f, 20f, 700);
		}
		mEnterBackground.color = ((!isOpened) ? Colours.gray135 : Colours.white);
	}

	public void UpdateEnterButtonTitle()
	{
		bool isOpened = WarArena.instance.isOpened;
		mEnterLabel.text = WarArenaGui.CreateArenaButtonTimeText();
		MiscTools.SetUILabelRescale(mEnterLabel, 62f, 20f, (!isOpened) ? 700 : 540);
	}

	public void ShowEnterArena()
	{
		mBottomLeftPartMain.SetActive(value: false);
		mBottomPartMain.SetActive(value: false);
		mBottomPartEnter.SetActive(value: true);
		mShowRulesButton.SetActive(value: false);
		mShowRulesLogoButton.SetActive(value: false);
		mEnterArenaWaiting.SetActive(value: false);
		AlignDraggables();
	}

	public void AlignDraggables()
	{
		mDraggableRules.AlignToPos(instant: true);
		AlignDraggableHeroes();
		mDraggableRewards.AlignToPos(instant: true);
	}

	public void HideEnterArena()
	{
		mBottomLeftPartMain.SetActive(value: true);
		mBottomPartMain.SetActive(value: true);
		mShowRulesButton.SetActive(value: true);
		mShowRulesLogoButton.SetActive(value: true);
		mBottomPartEnter.gameObject.SetActive(value: false);
	}

	public void SetLabels()
	{
		if (WarArena.instance.wararenaTicketPrize > 0)
		{
			mEnterLogo.gameObject.SetActive(value: true);
			mEnterPrice.text = MiscTools.FormatBigNumber(WarArena.instance.wararenaTicketPrize);
			float val = 140f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + 15f + mEnterLogo.transform.localScale.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val);
			float val2 = mEnterBorder.transform.localPosition.x - 70f - mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x / 2f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val2);
			float val3 = mEnterPrice.transform.localPosition.x - 15f - (mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x + mEnterLogo.transform.localScale.x) / 2f;
			mEnterLogo.transform.localPosition = mEnterLogo.transform.localPosition.ReplaceX(val3);
		}
		else
		{
			mEnterLogo.gameObject.SetActive(value: false);
			mEnterPrice.text = Localization.Localize("ID_FREE");
			float val4 = 140f + mEnterPrice.transform.localScale.x * mEnterPrice.relativeSize.x;
			mEnterBorder.transform.localScale = mEnterBorder.transform.localScale.ReplaceX(val4);
			float val5 = mEnterBorder.transform.localPosition.x - mEnterBorder.transform.localScale.x / 2f;
			mEnterPrice.transform.localPosition = mEnterPrice.transform.localPosition.ReplaceX(val5);
		}
	}

	public void OnArenaEnterClick(GameObject go)
	{
		if (!WarArena.instance.isOpened)
		{
			return;
		}
		if (!WarArena.instance.isGoodPing)
		{
			WarningDialog.ShowBadConnection();
			return;
		}
		if (!WarArena.instance.SetupRules())
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(WarArenaGui.failSetupRules);
			return;
		}
		int wararenaTicketPrize = WarArena.instance.wararenaTicketPrize;
		if (!Singleton<Wallet>.instance.CanBuyTickets(wararenaTicketPrize))
		{
			GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(wararenaTicketPrize, BuyTicketType.EnterArena, delegate(bool bought)
			{
				if (bought)
				{
					GuiScreenSingle<ArenaScreen>.instance.ShowArena(transition: true);
				}
			});
		}
		else
		{
			mEnterArenaWaiting.SetActive(value: true);
			EnterArenaRequest.Send();
		}
	}

	private void OnEnterArenaResponse(bool canEnterArena)
	{
		mEnterArenaWaiting.SetActive(value: false);
		if (canEnterArena)
		{
			GuiScreenSingle<ArenaScreen>.instance.ShowArena(transition: true);
		}
	}

	private void OnGetArenaLeaderboardsRequest()
	{
		GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition = 0;
		if (GuiScreenSingle<ArenaScreen>.instance.isShowed)
		{
			mHeroWaiting.SetActive(value: false);
			mHeroes = Singleton<ServerResultsCache>.instance.GetArenaLeaderboard();
			bool flag = mHeroes == null || mHeroes.Count == 0;
			mArenaHeroInfo.SetActive(flag);
			if (!flag)
			{
				mPooledHeroesGrid.MakeEmpty();
				mPooledHeroesGrid.init(mHeroes.Count, InstantiateHero, HeroFree, mDraggableHeroes);
			}
			mDraggableHeroes.AlignToPos(instant: true);
			AlignDraggableHeroes();
		}
	}

	private void AlignDraggableHeroes()
	{
		Vector3 positionForIndex = mPooledHeroesGrid.getPositionForIndex(GuiScreenSingle<ArenaScreen>.instance.yourHeroPosition);
		mDraggableHeroes.AlignToCenter(positionForIndex + mPooledHeroesGrid.transform.localPosition, instant: true);
		mPooledHeroesGrid.PositionChanged();
	}

	private void SetRulesVariables()
	{
		mGuiRules = WarArenaGui.currentArenaGuiRules;
	}

	private void InitializeHeroes()
	{
		mArenaHeroesLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_BUTTONPREVIOUSHEROES" : "ID_ARENAHEROES");
		mArenaHeroesEmptyLabel.text = Localization.Localize((!WarArena.instance.isOpened) ? "ID_EMPTYARENAHEROESPREVIOUS" : "ID_EMPTYARENAHEROESCURRENT");
		mHeroes = null;
		mPooledHeroesGrid.MakeEmpty();
		mHeroWaiting.SetActive(value: true);
		mArenaHeroInfo.SetActive(value: false);
		if (mYourRecord == null)
		{
			mYourRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(mArenaHeroPrefab, mArenaHeroesContent, "Your Best") as ArenaHeroRecord;
			mYourRecord.transform.localPosition = Vector3.zero;
		}
		if (mYourRecord != null)
		{
			bool flag = WarArena.instance.data.flawless > 0;
			int winsNumber = ((!flag) ? WarArena.instance.data.topRun : WarArena.instance.data.flawless);
			mYourRecord.InitializeYou(flag, winsNumber, (int)ArenaRulesPanelResize.contentWidth);
		}
		GetArenaLeaderboardsRequest.SendRequest();
	}

	private Transform InstantiateHero(int index)
	{
		if (index >= 0 && index < mHeroes.Count)
		{
			ArenaHeroRecord arenaHeroRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(mArenaHeroPrefab, mPooledHeroesGrid.gameObject, $"Hero {index:D2}") as ArenaHeroRecord;
			if (arenaHeroRecord != null)
			{
				arenaHeroRecord.Initialize(index + 1, mHeroes[index], mHeroes.Count, (int)ArenaRulesPanelResize.contentWidth);
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

	private Transform InstantiateRule(int index)
	{
		if (index >= 0 && index < mGuiRules.Count)
		{
			ArenaRuleRecord arenaRuleRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(mArenaRulePrefab, mRulesTable.gameObject, $"Rule {index:D2}") as ArenaRuleRecord;
			if (arenaRuleRecord != null)
			{
				arenaRuleRecord.Initialize(mGuiRules[index], showStateIcon: true, 555, 83);
				return arenaRuleRecord.transform;
			}
		}
		return null;
	}

	private void FreeRule(Transform obj)
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

	private Transform InstantiateReward(int index)
	{
		if (index >= 0 && index < mRewards.Count)
		{
			WararenaRewardRecord wararenaRewardRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(mArenaRewardPrefab, mPooledRewardsGrid.gameObject, $"Reward {index:D2}") as WararenaRewardRecord;
			if (wararenaRewardRecord != null)
			{
				wararenaRewardRecord.Initialize(mRewards[index], WararenaRewardRecord.ClickBehaviour.OpenDialog);
				return wararenaRewardRecord.transform;
			}
		}
		return null;
	}

	private void FreeReward(Transform obj)
	{
		if (obj != null)
		{
			WararenaRewardRecord component = obj.GetComponent<WararenaRewardRecord>();
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
			ruleRecordForHeight.Initialize(mGuiRules[index], showStateIcon: false, 555, 83);
			return ruleRecordForHeight.background.transform.localScale.y;
		}
		return 0f;
	}

	public void ClearData()
	{
		mGuiRules.Clear();
		mHeroes = null;
		if (mYourRecord != null)
		{
			mYourRecord.DestroyPooled();
			mYourRecord = null;
		}
	}

	public void ResetGUI()
	{
		mRulesTable.MakeEmpty();
		mPooledHeroesGrid.MakeEmpty();
		mPooledRewardsGrid.MakeEmpty();
		mArenaHeroInfo.SetActive(value: false);
	}

	public void CheckAndChangeArenaState()
	{
		if (mPreviousArenaState != WarArena.instance.isOpened)
		{
			InitButtonState();
			InitializeHeroes();
		}
		if (WarArena.instance.isExpired && !GuiScreenSingle<ArenaScreen>.instance.shouldveEnded)
		{
			WarArena.instance.TryGetNewArena();
		}
	}

	private void InitButtonState()
	{
		mPreviousArenaState = WarArena.instance.isOpened;
		SetEnterButton();
		SetLabels();
	}
}
