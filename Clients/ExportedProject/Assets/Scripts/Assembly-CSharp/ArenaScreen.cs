using System;
using UnityEngine;

public class ArenaScreen : GuiScreenSingle<ArenaScreen>
{
	public enum ArenaScreenMode
	{
		EnterArena,
		MainArena,
		EndArena
	}

	[Header("Main Content")]
	public ArenaScreenMainContent mainContent;

	[Header("Enter Content")]
	[SerializeField]
	private ArenaScreenEnterContent mEnterContent;

	[Header("Phases")]
	[SerializeField]
	private UILabel mPhase;

	[SerializeField]
	private UILabel mPhaseTime;

	[SerializeField]
	private ArenaPhaseContent mPhases;

	[SerializeField]
	[Header("Content Panels")]
	private UIPanel mWinPanel;

	[SerializeField]
	private ArenaRulesPanelResize mRulesPanel;

	[SerializeField]
	[Header("Overlay Panels")]
	private UIPanel mRulesOverlayPanel;

	[Header("Arena Name")]
	[SerializeField]
	private UILabel mArenaName;

	[SerializeField]
	[Header("Rules Button")]
	private UISprite mRulesHint;

	[SerializeField]
	private UILabel mRulesLabel;

	[SerializeField]
	[Header("Buttons")]
	private BoxCollider mArenaRulesButton;

	[SerializeField]
	private BoxCollider mArenaLogoButton;

	[SerializeField]
	[Header("Bottom Timer")]
	private UILabel mArenaTime;

	[Header("Atlases")]
	public UIAtlas mainMenuAtlas;

	public UIAtlas commonAtlas;

	[HideInInspector]
	public bool rulesShowed;

	[HideInInspector]
	public ArenaScreenMode arenaMode;

	[HideInInspector]
	public int yourHeroPosition;

	[HideInInspector]
	public bool shouldveEnded;

	private float mUpdateTime;

	private bool mShowDialogs;

	private bool mPreviousPhaseState;

	private bool mPulsatingArenaTimer;

	public bool haveWon => arenaMode == ArenaScreenMode.EndArena && Singleton<GameController>.instance.wonLastGame;

	public bool haveLost => arenaMode == ArenaScreenMode.EndArena && !Singleton<GameController>.instance.wonLastGame;

	public override bool dialogsEnabled => base.dialogsEnabled && mShowDialogs;

	public void AfterAnimation()
	{
		mShowDialogs = true;
		if (shouldveEnded)
		{
			shouldveEnded = false;
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.TryGetNewArena();
			}
			ValuesChanged();
		}
	}

	public void ShowWarArena(ArenaScreenMode mode)
	{
		arenaMode = mode;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
	}

	protected override void InitControls()
	{
		mEnterContent.InitControls();
		mainContent.InitControls();
		mRulesPanel.Rescale();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ShowRules));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ShowRules));
		WarArena.instance.WarArenaDataChanged += ValuesChanged;
		WarArena.instance.WarArenaStarter += ValuesChanged;
	}

	public override void InitGUIValues()
	{
		if (arenaMode != ArenaScreenMode.EndArena)
		{
			shouldveEnded = false;
		}
		mPhases.SetPhases(WarArena.instance.warArenaConfig.playWindows.Count);
		if (WarArena.instance.warArenaConfig.currentWindow != null)
		{
			mPreviousPhaseState = WarArena.instance.warArenaConfig.currentWindow.isActive;
			mPhases.ActivePhase(WarArena.instance.warArenaConfig.currentWindow.windowIndex + 1);
		}
		else
		{
			mPreviousPhaseState = false;
			mPhases.ActivePhase(0);
		}
		base.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		SetLabels();
		mUpdateTime = 0f;
		mainContent.InitGUIValues();
		mEnterContent.InitGUIValues();
		mShowDialogs = arenaMode != ArenaScreenMode.EndArena;
		switch (arenaMode)
		{
		case ArenaScreenMode.EnterArena:
			ShowEnterArena();
			break;
		case ArenaScreenMode.MainArena:
		case ArenaScreenMode.EndArena:
			ShowArena(transition: false);
			break;
		default:
			ShowEnterArena();
			break;
		}
	}

	private void ShowEnterArena()
	{
		mWinPanel.gameObject.SetActive(value: false);
		mEnterContent.ShowEnterArena();
	}

	public void ShowArena(bool transition)
	{
		mEnterContent.HideEnterArena();
		mWinPanel.gameObject.SetActive(value: true);
		if (transition)
		{
			AnimatePanels(0.4f, 1f, 0f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(value: false);
			mRulesOverlayPanel.gameObject.SetActive(value: false);
		}
		mainContent.ShowMainArena();
	}

	public void ValuesChanged()
	{
		if (isShowed && mShowDialogs)
		{
			Debug.Log("New Arena");
			arenaMode = ArenaScreenMode.EnterArena;
			ClearData();
			ResetGUI();
			mRulesOverlayPanel.gameObject.SetActive(value: true);
			mRulesPanel.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		else
		{
			shouldveEnded = true;
		}
	}

	private void ShowRules(GameObject go)
	{
		rulesShowed = !rulesShowed;
		AnimateRulesFade();
		if (rulesShowed)
		{
			mainContent.HideBoxesHints();
		}
	}

	private void AnimateRulesFade()
	{
		if (rulesShowed)
		{
			mRulesPanel.gameObject.SetActive(rulesShowed);
			mRulesOverlayPanel.gameObject.SetActive(rulesShowed);
			mEnterContent.AlignDraggables();
		}
		AnimatePanels(0.4f, (!rulesShowed) ? 1f : 0f, (!rulesShowed) ? 0f : 1f);
		mRulesHint.spriteName = ((!rulesShowed) ? "menu-info-ico" : "menu-info-close-ico");
		mRulesLabel.text = Localization.Localize((!rulesShowed) ? "ID_ARENARULES" : "ID_CLOSE");
		if (!rulesShowed)
		{
			mRulesPanel.gameObject.SetActive(rulesShowed);
			mRulesOverlayPanel.gameObject.SetActive(rulesShowed);
		}
	}

	private void SetLabels()
	{
		mArenaName.text = ((WarArena.instance.warArenaConfig == null) ? string.Empty : WarArena.instance.warArenaConfig.arenaName);
		mPhase.text = ((WarArena.instance.warArenaConfig == null) ? string.Empty : Localization.LocalizeFormat("ID_PHASEXOFY", WarArena.instance.phaseNumber, Colours.stringGray, WarArena.instance.warArenaConfig.playWindows.Count));
	}

	private void ClearData()
	{
		mEnterContent.ClearData();
		mainContent.ClearData();
		mPhases.ResetPhases();
	}

	private void ResetGUI()
	{
		mEnterContent.ResetGUI();
		AnimatePanels(0f, 0f, 1f);
		if (rulesShowed)
		{
			ShowRules(base.gameObject);
		}
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(value: true);
		mRulesPanel.gameObject.SetActive(value: true);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		mainContent.DoAfterShowUp();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		mainContent.DoBeforeHide();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		ClearData();
		ResetGUI();
	}

	private void UpdateBattleButtonTitle()
	{
		if (WarArenaGui.ShouldArenaBattleButtonUpdate())
		{
			mainContent.UpdateBattleButtonTitle();
		}
	}

	private void UpdateEnterButtonTitle()
	{
		if (WarArenaGui.ShouldArenaEnterButtonUpdate())
		{
			mEnterContent.UpdateEnterButtonTitle();
		}
	}

	private void CheckAndChangeArenaState()
	{
		mEnterContent.CheckAndChangeArenaState();
		if (WarArena.instance.warArenaConfig.currentWindow != null && mPreviousPhaseState != WarArena.instance.warArenaConfig.currentWindow.isActive)
		{
			mPreviousPhaseState = WarArena.instance.warArenaConfig.currentWindow.isActive;
			mPhases.ActivePhase(WarArena.instance.warArenaConfig.currentWindow.windowIndex + 1);
			mainContent.SetBattleButton();
			SetLabels();
		}
		if (WarArena.instance.warArenaConfig.currentWindow == null)
		{
			mPreviousPhaseState = false;
			mPhases.ActivePhase(0);
			mainContent.SetBattleButton();
		}
	}

	private void AnimatePanels(float time, float fromRules, float toRules)
	{
		Vector3 rulesPos = mRulesPanel.transform.localPosition;
		if (fromRules < 0.5f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, time * 2f / 3f, rulesPos.ReplaceY(-20f), rulesPos.ReplaceY(10f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(mRulesPanel.gameObject, time / 3f, rulesPos.ReplaceY(0f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
			};
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, time, fromRules, toRules);
		if (time > 0f)
		{
			tweenAlpha.onFinished = delegate
			{
				if (fromRules > 0.5f)
				{
					mRulesOverlayPanel.gameObject.SetActive(value: false);
					mRulesPanel.gameObject.SetActive(value: false);
				}
			};
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(value: true);
			mRulesPanel.gameObject.SetActive(value: true);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, time, toRules, fromRules);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, time, fromRules, toRules);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel2 in componentsInChildren2)
		{
			TweenAlpha.Begin(uIPanel2.gameObject, time, toRules, fromRules);
		}
	}

	protected override void Update()
	{
		base.Update();
		mUpdateTime += Time.deltaTime;
		if (mUpdateTime > 0.333f)
		{
			mUpdateTime = 0f;
			if (base.isFullyShowed)
			{
				mArenaTime.text = WarArenaGui.CreateArenaEventTimeText();
				AnimateArenaTimer();
				mPhaseTime.text = WarArenaGui.CreateArenaWindowTimeText();
				UpdateBattleButtonTitle();
				UpdateEnterButtonTitle();
				CheckAndChangeArenaState();
			}
		}
	}

	private void AnimateArenaTimer()
	{
		bool flag = WarArenaGui.ShouldArenaEventTimerPulsate();
		if (mPulsatingArenaTimer != flag)
		{
			mPulsatingArenaTimer = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 0.4f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = UITweener.Style.PingPong;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 0.05f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 1;
				tweenColor2.style = UITweener.Style.Once;
			}
		}
	}
}
