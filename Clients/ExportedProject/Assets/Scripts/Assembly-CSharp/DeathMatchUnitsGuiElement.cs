using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatchUnitsGuiElement : GuiElement
{
	[Header("Deploy Energy")]
	public DeployEnergyElement deployEnergyElement;

	[Header("Deploy Energy animation")]
	public UISprite[] deployEnergyIcons;

	public float deployIconShowDur = 0.7f;

	public float dur = 0.1f;

	public float iconsDelay = 0.02f;

	[Header("Core")]
	public List<DeathMatchGuiCard> guiCards;

	[Header("Tutorial")]
	public GameObject hintText;

	public UILabel hinTutorialText;

	[Header("Auto Deploy")]
	public GameObject progressHandle;

	public GameObject autoDeployPanel;

	public UISprite autoDeployProgress;

	public UILabel autoDeployLabel;

	private bool mIsShowingCards;

	private int mShowingCardIndex = -1;

	private float mNextShowUpdateTime;

	protected readonly List<SpawningManagerDeathMatch.ArmyUnitDefinition> mUnits = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();

	private Vector3 mProgressesInitPos;

	private Vector3 mAutoDeployInitPos;

	private bool mIsFirstShowCards;

	private bool mCanAutoDeploy;

	public static DeathMatchUnitsGuiElement instance { get; protected set; }

	protected virtual float mAnimDelay => 0.25f;

	protected virtual bool isActive => Singleton<GameController>.instance.mainController.spawningType == SpawningType.Classic;

	public event Action onSendUnit;

	protected new void Awake()
	{
		ShowHintText(show: false);
		base.Awake();
		mProgressesInitPos = progressHandle.transform.localPosition;
		mAutoDeployInitPos = autoDeployPanel.transform.localPosition;
	}

	public void Enable()
	{
		GameStarted();
		base.gameObject.SetActive(value: true);
		ShowCards();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<SpawningManagerDeathMatch>.instance.ArmyChanged += InstanceOnArmyChanged;
		Singleton<SpawningManagerDeathMatch>.instance.RandomArmySent += InstanceOnRandomArmySent;
		SpawningManagerDeathMatch spawningManagerDeathMatch = Singleton<SpawningManagerDeathMatch>.instance;
		spawningManagerDeathMatch.UnitWasPregenerated = (Action<SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(spawningManagerDeathMatch.UnitWasPregenerated, new Action<SpawningManagerDeathMatch.ArmyUnitDefinition>(UnitWasPregenerated));
		Singleton<GameController>.instance.GameStarted += GameStarted;
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			guiCard.Init(this);
		}
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}

	protected override void Update()
	{
		base.Update();
		if (mUnits.Count == 3)
		{
			int num = 0;
			for (int i = 0; i < mUnits.Count; i++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = mUnits[i];
				if (armyUnitDefinition != null)
				{
					if (armyUnitDefinition.power > (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft && num != armyUnitDefinition.power)
					{
						float num2 = (float)((int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft - num) / (float)(armyUnitDefinition.power - num);
						break;
					}
					num = armyUnitDefinition.power;
				}
			}
			for (int j = 0; j < mUnits.Count; j++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition2 = mUnits[j];
				if (armyUnitDefinition2 != null)
				{
					num = armyUnitDefinition2.power;
				}
			}
		}
		if (mIsShowingCards && Time.unscaledTime > mNextShowUpdateTime)
		{
			mNextShowUpdateTime = Time.unscaledTime + mAnimDelay;
			mShowingCardIndex++;
			SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition3 = mUnits[mShowingCardIndex];
			guiCards[mShowingCardIndex].Show(armyUnitDefinition3);
			if (mShowingCardIndex == 2)
			{
				mIsShowingCards = false;
			}
		}
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployProgress > 0.05f && !mCanAutoDeploy && mShowingCardIndex > 1 && (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled))
		{
			mCanAutoDeploy = true;
			TweenPosition.Begin(autoDeployPanel, 0.5f, mAutoDeployInitPos).delay = 0f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(autoDeployPanel, 0.5f, 1f).delay = 0f;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(autoDeployLabel.gameObject, 0f, 1f);
			tweenAlpha.style = UITweener.Style.Once;
		}
		autoDeployProgress.fillAmount = Singleton<SpawningManagerDeathMatch>.instance.autoDeployProgress;
	}

	private void InstanceOnArmyChanged()
	{
		if (isActive)
		{
			ShowCards();
		}
	}

	private void UnitWasPregenerated(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition)
	{
		if (!isActive)
		{
			return;
		}
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			if (guiCard.armyUnitDefinition == armyUnitDefinition)
			{
				guiCard.StartBlink();
				break;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(autoDeployLabel.gameObject, 0.3f, 0f, 1f);
			tweenAlpha.style = UITweener.Style.PingPong;
		}
	}

	private void InstanceOnRandomArmySent(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition)
	{
		if (!isActive)
		{
			return;
		}
		bool flag = false;
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			if (guiCard.armyUnitDefinition == armyUnitDefinition && !flag)
			{
				guiCard.StartProgress();
				flag = true;
			}
			else
			{
				guiCard.DisableCard();
			}
		}
		HideProgress();
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled)
		{
			TweenPosition.Begin(autoDeployPanel, 0.5f, mAutoDeployInitPos - Vector3.up * 450f).delay = 0f;
			TweenAlpha.Begin(autoDeployPanel, 0.5f, 0f).delay = 0f;
		}
		mCanAutoDeploy = false;
	}

	protected virtual void HideProgress()
	{
		TweenPosition.Begin(progressHandle, 0.5f, mProgressesInitPos - Vector3.up * 450f).delay = 0f;
	}

	private void GameStarted()
	{
		base.gameObject.SetActive(Singleton<GameController>.instance.mainController.canDeployUnits);
		base.enabled = isActive;
		if (isActive)
		{
			instance = this;
			foreach (DeathMatchGuiCard guiCard in guiCards)
			{
				guiCard.enabled = true;
				guiCard.HideOnGameStarted();
			}
			mIsShowingCards = false;
			mCanAutoDeploy = false;
			deployEnergyElement.shouldUpdate = Singleton<GameController>.instance.mainController.canDeployUnits;
			mIsFirstShowCards = true;
			ShowHintText(show: false);
			TweenPosition.Begin(progressHandle, 0f, mProgressesInitPos - Vector3.up * 450f).delay = 0f;
			TweenPosition.Begin(autoDeployPanel, 0f, mAutoDeployInitPos - Vector3.up * 450f).delay = 0f;
			if (DebugSettings.instance.data.showHud)
			{
				TweenAlpha.Begin(autoDeployPanel, 0f, 1f).delay = 0f;
			}
			return;
		}
		foreach (DeathMatchGuiCard guiCard2 in guiCards)
		{
			guiCard2.enabled = false;
		}
	}

	public void ShowHintText(bool show, bool flashEnergy = true)
	{
		hintText.SetActive(show);
		if (show)
		{
			TweenAlpha.Begin(hintText, 0.5f, 1f);
			hinTutorialText.text = Localization.Localize("ID_TUTORIAL_UNITSDEPLOYMENT");
			MiscTools.SetUILabelRescale(hinTutorialText, 60f, 30f, 460);
		}
	}

	public void ShowKillHelp(bool show)
	{
		hintText.SetActive(show);
		if (show)
		{
			TweenAlpha.Begin(hintText, 0.5f, 1f);
			hinTutorialText.text = Localization.Localize("ID_TUTORIAL_KILLENEMYUNITS");
			MiscTools.SetUILabelRescale(hinTutorialText, 56f, 28f, 460);
		}
		else
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(hintText, 0.5f, 0f);
			tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
			{
				hintText.SetActive(value: false);
			});
		}
	}

	public void HideCards()
	{
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			if (guiCard.isSelected)
			{
				guiCard.Hide();
			}
		}
	}

	protected virtual void FillAndSortUnits()
	{
		List<SpawningManagerDeathMatch.ArmyUnitDefinition> currentArmyUnitDefinitions = Singleton<SpawningManagerDeathMatch>.instance.currentArmyUnitDefinitions;
		mUnits.Clear();
		mUnits.AddRange(currentArmyUnitDefinitions);
		mUnits.Sort(delegate(SpawningManagerDeathMatch.ArmyUnitDefinition a, SpawningManagerDeathMatch.ArmyUnitDefinition b)
		{
			if (a == null)
			{
				return 1;
			}
			return (b == null) ? (-1) : a.power.CompareTo(b.power);
		});
	}

	private void ShowCards()
	{
		FillAndSortUnits();
		HideCards();
		if (mIsFirstShowCards)
		{
			for (int i = 0; i < mUnits.Count; i++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition = mUnits[i];
				guiCards[i].Show(armyUnitDefinition, instant: true);
			}
			mIsFirstShowCards = false;
			TweenPosition.Begin(progressHandle, 0f, mProgressesInitPos).delay = 0f;
			if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || (Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled && Singleton<SpawningManagerDeathMatch>.instance.powerForSemiDeploy))
			{
				TweenPosition.Begin(autoDeployPanel, 0f, mAutoDeployInitPos).delay = 0f;
				if (DebugSettings.instance.data.showHud)
				{
					TweenAlpha.Begin(autoDeployPanel, 0f, 1f).delay = 0f;
				}
			}
			mShowingCardIndex = 2;
			return;
		}
		mIsShowingCards = true;
		mShowingCardIndex = -1;
		mNextShowUpdateTime = Time.unscaledTime + 1f;
		TweenPosition.Begin(progressHandle, 0.5f, mProgressesInitPos).delay = 0.8f;
		if (Singleton<GameController>.instance.mainController.spawningType == SpawningType.Classic)
		{
			for (int j = 0; j < mUnits.Count; j++)
			{
				SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition2 = mUnits[j];
				guiCards[j].PreShowPowerProgress(armyUnitDefinition2);
			}
		}
	}

	public void TutorialSetCards()
	{
		base.gameObject.SetActive(value: true);
		mIsShowingCards = false;
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			guiCard.HideOnGameStarted();
		}
	}

	public void SendUnit(DeathMatchGuiCard card, SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition, bool clicked = false)
	{
		if (mIsShowingCards)
		{
			return;
		}
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			if (card == guiCard)
			{
				guiCard.StartProgress();
			}
			else
			{
				guiCard.DisableCard();
			}
		}
		if (this.onSendUnit != null)
		{
			this.onSendUnit();
		}
		Singleton<SpawningManagerDeathMatch>.instance.SendUnit(armyUnitDefinition, PlayerController.currentPlayer.fraction, useEnergy: true, clicked);
		HideProgress();
		if (Singleton<SpawningManagerDeathMatch>.instance.autoDeployEnabled || Singleton<SpawningManagerDeathMatch>.instance.semiAutoDeployEnabled)
		{
			TweenPosition.Begin(autoDeployPanel, 0.5f, mAutoDeployInitPos - Vector3.up * 450f).delay = 0f;
			TweenAlpha.Begin(autoDeployPanel, 0.5f, 0f).delay = 0f;
			mCanAutoDeploy = false;
		}
	}

	public void EnableCardClick()
	{
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			guiCard.EnableCardClick();
		}
	}

	public void DisableCardClick()
	{
		foreach (DeathMatchGuiCard guiCard in guiCards)
		{
			guiCard.DisableCardClick();
		}
	}

	public void DeployEnergyIconAnimation(Vector3 worldPosition, int deployEnergy)
	{
		if (!base.gameObject.activeInHierarchy)
		{
			return;
		}
		List<UISprite> list = new List<UISprite>();
		for (int i = 0; i < deployEnergyIcons.Length; i++)
		{
			if (!deployEnergyIcons[i].gameObject.activeSelf)
			{
				list.Add(deployEnergyIcons[i]);
				if (list.Count == deployEnergy)
				{
					break;
				}
			}
		}
		if (list.Count != 0)
		{
			list[0].transform.position = deployEnergyElement.myEnergyBar.transform.position;
			Vector3 endPosition = list[0].transform.localPosition.ReplaceZ(0f);
			Vector3 point = HealthBarManager.instance.guiCamera.WorldToViewportPoint(worldPosition);
			point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
			list[0].transform.position = point;
			point = list[0].transform.localPosition.ReplaceZ(0f);
			list[0].transform.localPosition = point;
			for (int j = 0; j < list.Count; j++)
			{
				AnimateDeployEnergy(list[j], point, endPosition, j + 1 == list.Count, (float)j * iconsDelay);
			}
		}
	}

	public void AnimateDeployEnergy(UISprite sprite, Vector3 startPosition, Vector3 endPosition, bool isLast, float delay)
	{
		sprite.gameObject.SetActive(value: true);
		sprite.alpha = 0f;
		sprite.transform.localPosition = startPosition;
		TrailRenderer trailRenderer = sprite.gameObject.GetComponent<TrailRenderer>();
		if (trailRenderer != null && isLast)
		{
			trailRenderer.enabled = true;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(sprite.gameObject, deployIconShowDur, 0f, 1f);
		tweenAlpha.delay = delay;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha.Begin(sprite.gameObject, 3f * dur, 1f, 1f).onFinished = delegate
			{
				TweenAlpha.Begin(sprite.gameObject, dur, 1f, 0f).onFinished = null;
				if (trailRenderer != null)
				{
					trailRenderer.enabled = false;
				}
			};
			TweenPosition.Begin(sprite.gameObject, 4f * dur, startPosition, endPosition).onFinished = delegate
			{
				sprite.gameObject.SetActive(value: false);
			};
		};
	}
}
