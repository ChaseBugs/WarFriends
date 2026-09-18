using System;
using System.Collections;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class ArmyScreen : GuiScreenSingle<ArmyScreen>
{
	[Header("Top Left")]
	public UIButton backButton;

	[Header("Left")]
	public ArmyLeftContent armyLeftContent;

	[Header("Center")]
	public CircleProgress circleCreator;

	public UISprite upgradeIcon;

	public UISprite upgradeGlow;

	public ParticleSystem upgradeParticles;

	[Header("Right")]
	public ArmyRightContent armyRightContent;

	[Header("Bottom Min/Max")]
	public BoxCollider minMaxPreviewCollider;

	public UILabel minLabel;

	public UILabel maxLabel;

	public UISprite minMaxSelected;

	[Header("Bottom Normal/Elite")]
	public BoxCollider normalElitePreviewCollider;

	public UILabel normalLabel;

	public UILabel eliteLabel;

	public UISprite normalEliteSelected;

	[Header("Bottom Army Icons List")]
	public ArmyUpgradeIcon armyIconPrefab;

	public ArmyTierRecord armyTierPrefab;

	public UITable bottomTable;

	public UIDraggablePanel draggablePanel;

	[Header("Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	public float upgradeDur = 0.05f;

	[HideInInspector]
	public ArmyUpgradeIcon selectedIcon;

	[HideInInspector]
	public List<ArmyUpgradeIcon> armyIcons = new List<ArmyUpgradeIcon>();

	private bool mIsFullyShowed;

	private bool mForceShow;

	private UpgradeSlots.State mArmyUnitState;

	private bool mIsAbilityUpgrading;

	private int mArmyUnitTier;

	private int mEliteLevel;

	private List<ArmyTierRecord> armyTiers = new List<ArmyTierRecord>();

	private bool mIsMax = true;

	private bool mIsElite;

	private RadicalRoutine mUpdate;

	public void SelectUnit(LevelBehaviour unit)
	{
		mForceShow = true;
		SavingLastSelected.instance.SaveLastUnit(unit);
	}

	protected override void InitControls()
	{
		InstantiateBottomIcons();
		Singleton<Wallet>.instance.ScrapsChanged += OnScrapsChanged;
		LevelManager.LevelUp += OnLevelUp;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<OfferManager>.instance.SalesChanged += OnSalesChanged;
		UIEventListener uIEventListener = UIEventListener.Get(minMaxPreviewCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MinMaxClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(normalElitePreviewCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NormalEliteClick));
		armyRightContent.InitControls();
		armyLeftContent.InitControls();
	}

	private void InstantiateBottomIcons()
	{
		armyIcons.Clear();
		armyTiers.Clear();
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots != null)
			{
				ArmyUpgradeIcon armyUpgradeIcon = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(armyIconPrefab, bottomTable.gameObject, "army upgrade icon") as ArmyUpgradeIcon;
				if (armyUpgradeIcon != null)
				{
					armyUpgradeIcon.Init(behaviour);
				}
				if (levelBehaviour == null && behaviour.upgradeSlots.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastUnit(behaviour);
					levelBehaviour = behaviour;
				}
				armyIcons.Add(armyUpgradeIcon);
			}
		}
		for (int i = 1; i <= 6; i++)
		{
			ArmyTierRecord armyTierRecord = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(armyTierPrefab, bottomTable.gameObject, string.Format("{0} Aa Tier {0}", i)) as ArmyTierRecord;
			if (armyTierRecord != null)
			{
				armyTierRecord.Initialize(i);
			}
			armyTiers.Add(armyTierRecord);
		}
	}

	private void RepositionBottomContent()
	{
		ShowHideTiersHeaders();
		BottomIconAndTierGraphicsForReposition(show: false);
		bottomTable.repositionNow = true;
		bottomTable.onReposition = delegate
		{
			bottomTable.onReposition = null;
			bottomTable.repositionNow = false;
			BottomIconAndTierGraphicsForReposition(show: true);
			if (selectedIcon != null)
			{
				Vector3 vec = selectedIcon.transform.localPosition + selectedIcon.transform.parent.localPosition;
				draggablePanel.AlignToCenter(vec, instant: true);
			}
		};
	}

	private void BottomIconAndTierGraphicsForReposition(bool show)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(show);
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.GUIForReposition(show);
		}
	}

	private void ShowHideTiersHeaders()
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < armyTiers.Count; i++)
		{
			list.Add(item: false);
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			int num = armyIcon.levelBehaviour.upgradeSlots.actualTier - 1;
			if (num < list.Count)
			{
				list[num] = true;
			}
		}
		for (int j = 0; j < armyTiers.Count; j++)
		{
			armyTiers[j].gameObject.SetActive(list[j]);
		}
	}

	private void OnScrapsChanged(long newValue, long difference)
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
		}
	}

	private void OnLevelUp()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			ShowUnit(selectedIcon.levelBehaviour);
		}
	}

	public void UpdateBottomGraphics()
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.UpdateGraphics();
		}
	}

	public void EquippedUnitsUpdate()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed)
		{
			switch (action)
			{
			case DatabaseAction.BuyUnitUpgrade:
			case DatabaseAction.InstantUnitUpgrade:
			case DatabaseAction.ActivateUnitUpgrade:
			case DatabaseAction.BuyUnit:
			case DatabaseAction.InstantBuyUnit:
			case DatabaseAction.ActivateUnit:
				UpdateGui(selectedIcon.levelBehaviour);
				break;
			}
		}
	}

	private void OnSalesChanged()
	{
		if (!isShowed)
		{
			return;
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.SetSale();
		}
		armyLeftContent.SetSaleAndPrize();
		armyRightContent.SetSaleAndPrize();
	}

	private void MinMaxClick(GameObject go)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.isLoadingPreview)
		{
			mIsMax = !mIsMax;
			SetMinMax(animate: true);
			UpgradeSlots.showMaxLevelWhenNotBought = mIsMax;
			Singleton<ArmyPreviewCamera>.instance.Refresh();
		}
	}

	private void NormalEliteClick(GameObject go)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.isLoadingPreview)
		{
			mIsElite = !mIsElite;
			SetNormalElite(animate: true);
			UpgradeSlots.showEliteUnitWhenBought = mIsElite;
			Singleton<ArmyPreviewCamera>.instance.Refresh();
		}
	}

	public override void InitGUIValues()
	{
		UpdateArmy();
		selectedIcon = null;
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.InitGuiValuesGraphics();
		}
		LevelBehaviour unit = ChooseUnitToShow();
		SelectAndCenterUnit(unit);
		RepositionBottomContent();
		Select();
		UpgradeSlots upgradeSlots = selectedIcon.levelBehaviour.upgradeSlots;
		mArmyUnitState = upgradeSlots.unitState;
		mIsAbilityUpgrading = mArmyUnitState == UpgradeSlots.State.Delivering && upgradeSlots.deliveringSlot.isSpecial;
		mArmyUnitTier = upgradeSlots.actualTier;
		mEliteLevel = upgradeSlots.upgradeSlotElite.boughtIndex;
		armyLeftContent.InitGUIValues();
		mIsMax = UpgradeSlots.showMaxLevelWhenNotBought;
		SetMinMax();
		mIsElite = UpgradeSlots.showEliteUnitWhenBought;
		SetNormalElite();
	}

	private void SelectAndCenterUnit(LevelBehaviour unit)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(isSelected: false);
		}
		int num = armyIcons.FindIndex((ArmyUpgradeIcon icon) => icon.levelBehaviour == unit);
		if (num == -1)
		{
			Debug.LogError("Should not happen - unit icon is not instantiated in bottom section.");
			selectedIcon = armyIcons[0];
		}
		selectedIcon = armyIcons[num];
		selectedIcon.SetHighlight(isSelected: true);
	}

	private LevelBehaviour ChooseUnitToShow()
	{
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		if (levelBehaviour == null)
		{
			Debug.Log("Last unit not choosen!!!!!");
			levelBehaviour = LevelManager.instance.behaviours[0];
		}
		if (mForceShow)
		{
			mForceShow = false;
			return levelBehaviour;
		}
		LevelBehaviour levelBehaviour2 = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour2 != null)
		{
			return levelBehaviour2;
		}
		LevelBehaviour unlockedUnitWithNotification = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
		if (unlockedUnitWithNotification != null)
		{
			return unlockedUnitWithNotification;
		}
		return levelBehaviour;
	}

	public void Select()
	{
		ShowUnit(selectedIcon.levelBehaviour);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mIsFullyShowed = false;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		mIsFullyShowed = true;
		DisplayModel();
		StartUpdate();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.Hide();
		selectedIcon.SetHighlight(isSelected: false);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		armyLeftContent.DoAfterHide();
		armyRightContent.DoAfterHide();
		StopUpdate();
	}

	private void DisplayModel()
	{
		if (mIsFullyShowed)
		{
			if (selectedIcon == null)
			{
				Debug.LogError("Choose icon in bottom before calling Display model.");
				return;
			}
			LevelBehaviour levelBehaviour = selectedIcon.levelBehaviour;
			Singleton<ArmyPreviewCamera>.instance.Display(levelBehaviour);
		}
	}

	public void ShowUnit(LevelBehaviour unit)
	{
		if (!unit.upgradeSlots.showed && unit.upgradeSlots.unlocked && !unit.upgradeSlots.borrowed)
		{
			WasShown(unit.upgradeSlots.GetSheetName());
		}
		unit.upgradeSlots.showed = true;
		SavingLastSelected.instance.SaveLastUnit(unit);
		DisplayModel();
		armyRightContent.SelectUnit(unit);
		armyLeftContent.SelectUnit(unit);
		UpdateGui(unit);
		mArmyUnitState = unit.upgradeSlots.unitState;
		mIsAbilityUpgrading = mArmyUnitState == UpgradeSlots.State.Delivering && unit.upgradeSlots.deliveringSlot.isSpecial;
		mArmyUnitTier = unit.upgradeSlots.actualTier;
		mEliteLevel = unit.upgradeSlots.upgradeSlotElite.boughtIndex;
	}

	public void UpdateGui(LevelBehaviour unit, bool changedUnit = true)
	{
		if (!changedUnit)
		{
			Refresh();
		}
		armyRightContent.UpdateRightContent(changedUnit);
		armyLeftContent.UpdateLeftContent(changedUnit);
		if (unit.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivering)
		{
			circleCreator.deliveringAnimation = true;
		}
		else
		{
			circleCreator.FillCircle(unit.upgradeSlots.upgradesProgress);
		}
		minMaxPreviewCollider.gameObject.SetActive(!unit.upgradeSlots.bought);
		normalElitePreviewCollider.gameObject.SetActive(unit.upgradeSlots.bought && unit.upgradeSlots.upgradeSlotElite.isUnlocked && !unit.upgradeSlots.upgradeSlotElite.isBought);
	}

	public void Refresh()
	{
		Singleton<ArmyPreviewCamera>.instance.Refresh();
	}

	public void PromoteUnitBottomIconAnimation(LevelBehaviour behaviour)
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			if (armyIcon.levelBehaviour == behaviour)
			{
				armyIcon.UpdateName();
				StartCoroutine(PromoteAnimator(armyIcon));
				break;
			}
		}
	}

	private IEnumerator PromoteAnimator(ArmyUpgradeIcon icon)
	{
		float scaleDownTime = 0.3f;
		float repositionTime = 0.7f;
		float scaleUpTime = 0.3f;
		float progress = 0f;
		List<Transform> tableItems = new List<Transform>();
		List<Vector3> oldPositions = new List<Vector3>();
		List<Vector3> newPositions = new List<Vector3>();
		foreach (Transform item in bottomTable.children)
		{
			tableItems.Add(item);
			oldPositions.Add(item.transform.localPosition);
		}
		progress = 0f;
		while (progress < 1f)
		{
			progress = Mathf.Clamp01(progress + TimeManager.deltaTimeWithoutPauses / scaleDownTime);
			float scale = 1f - progress;
			icon.transform.localScale = new Vector3(scale, scale, 1f);
			yield return 0;
		}
		icon.transform.localScale = Vector3.one;
		ShowHideTiersHeaders();
		BottomIconAndTierGraphicsForReposition(show: false);
		bottomTable.repositionNow = true;
		ArmyUpgradeIcon icon2 = default(ArmyUpgradeIcon);
		bottomTable.onReposition = delegate
		{
			bottomTable.onReposition = null;
			bottomTable.repositionNow = false;
			BottomIconAndTierGraphicsForReposition(show: true);
			foreach (Transform item3 in tableItems)
			{
				newPositions.Add(item3.transform.localPosition);
			}
			icon2.transform.localScale = new Vector3(0f, 0f, 1f);
			for (int j = 0; j < tableItems.Count; j++)
			{
				Transform transform = tableItems[j];
				transform.localPosition = oldPositions[j];
			}
		};
		while (bottomTable.repositionNow)
		{
			yield return 0;
		}
		int iconIndex = tableItems.IndexOf(icon.transform);
		Vector3 panelScrollDelta = newPositions[iconIndex] - oldPositions[iconIndex];
		progress = 0f;
		while (progress < 1f)
		{
			float oldProgress = progress;
			progress = Mathf.Clamp01(progress + TimeManager.deltaTimeWithoutPauses / repositionTime);
			for (int i = 0; i < tableItems.Count; i++)
			{
				Transform item2 = tableItems[i];
				item2.localPosition = Vector3.Lerp(oldPositions[i], newPositions[i], progress);
			}
			draggablePanel.MoveRelative(-panelScrollDelta * (progress - oldProgress));
			yield return 0;
		}
		progress = 0f;
		while (progress < 1f)
		{
			progress = Mathf.Clamp01(progress + TimeManager.deltaTimeWithoutPauses / scaleUpTime);
			float scale2 = progress;
			icon.transform.localScale = new Vector3(scale2, scale2, 1f);
			yield return 0;
		}
	}

	private void SetMinMax(bool animate = false)
	{
		Color color = ((!mIsMax) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!mIsMax) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(minMaxSelected.transform.localPosition.x) * ((!mIsMax) ? (-1f) : 1f);
		Vector3 vector = minMaxSelected.transform.localPosition.ReplaceX(val);
		if (animate)
		{
			minMaxPreviewCollider.enabled = false;
			float duration = 0.2f;
			TweenColor.Begin(minLabel.gameObject, duration, color);
			TweenColor.Begin(maxLabel.gameObject, duration, color2);
			TweenPosition.Begin(minMaxSelected.gameObject, duration, vector).onFinished = delegate
			{
				minMaxPreviewCollider.enabled = true;
			};
			return;
		}
		minMaxPreviewCollider.enabled = true;
		TweenColor component = minLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = maxLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = minMaxSelected.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		minLabel.color = color;
		maxLabel.color = color2;
		minMaxSelected.transform.localPosition = vector;
	}

	private void SetNormalElite(bool animate = false)
	{
		Color color = ((!mIsElite) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!mIsElite) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(normalEliteSelected.transform.localPosition.x) * ((!mIsElite) ? (-1f) : 1f);
		Vector3 vector = normalEliteSelected.transform.localPosition.ReplaceX(val);
		if (animate)
		{
			normalElitePreviewCollider.enabled = false;
			float duration = 0.2f;
			TweenColor.Begin(normalLabel.gameObject, duration, color);
			TweenColor.Begin(eliteLabel.gameObject, duration, color2);
			TweenPosition.Begin(normalEliteSelected.gameObject, duration, vector).onFinished = delegate
			{
				normalElitePreviewCollider.enabled = true;
			};
			return;
		}
		normalElitePreviewCollider.enabled = true;
		TweenColor component = normalLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = eliteLabel.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = normalEliteSelected.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		normalLabel.color = color;
		eliteLabel.color = color2;
		normalEliteSelected.transform.localPosition = vector;
	}

	protected override void Update()
	{
		base.Update();
		if (selectedIcon != null && selectedIcon.levelBehaviour != null)
		{
			UpgradeSlots upgradeSlots = selectedIcon.levelBehaviour.upgradeSlots;
			bool flag = mArmyUnitState != upgradeSlots.unitState;
			bool flag2 = mArmyUnitState == UpgradeSlots.State.Delivering && upgradeSlots.deliveringSlot.isSpecial != mIsAbilityUpgrading;
			bool flag3 = mArmyUnitTier != upgradeSlots.actualTier;
			bool flag4 = mEliteLevel != upgradeSlots.upgradeSlotElite.boughtIndex;
			if (flag || flag2 || flag3 || flag4)
			{
				mArmyUnitState = upgradeSlots.unitState;
				mIsAbilityUpgrading = mArmyUnitState == UpgradeSlots.State.Delivering && upgradeSlots.deliveringSlot.isSpecial;
				mArmyUnitTier = upgradeSlots.actualTier;
				mEliteLevel = upgradeSlots.upgradeSlotElite.boughtIndex;
				UpdateGui(selectedIcon.levelBehaviour, changedUnit: false);
			}
			if (flag4)
			{
				UpdateBottomGraphics();
			}
		}
	}

	private void StartUpdate()
	{
		StopUpdate();
		mUpdate = RadicalRoutine.Create(UpdateRoutine());
		StartCoroutine(RadicalRoutine.Run(mUpdate.enumerator));
	}

	private void StopUpdate()
	{
		if (mUpdate != null)
		{
			mUpdate.Cancel();
			mUpdate = null;
		}
	}

	private IEnumerator UpdateRoutine()
	{
		while (isShowed)
		{
			yield return new WaitForRealSeconds(0.333f);
			if (mArmyUnitState == UpgradeSlots.State.UnitDelivering)
			{
				armyRightContent.UpdateDeliveringTime((float)selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
			}
			if (mArmyUnitState == UpgradeSlots.State.Delivering)
			{
				armyLeftContent.UpdateDeliveringTime((float)selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
			}
		}
	}

	public void AnimateUpgrade()
	{
		upgradeParticles.Play();
		Singleton<ArmyPreviewCamera>.instance.StartFastRotation();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(upgradeGlow.gameObject, upgradeDur * 3.5f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		TweenAlpha.Begin(upgradeIcon.gameObject, upgradeDur * 1f, 0f, 0.3f).onFinished = delegate
		{
			TweenAlpha.Begin(upgradeIcon.gameObject, upgradeDur * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(upgradeIcon.gameObject, upgradeDur * 7f, 0f);
			};
		};
		TweenScale.Begin(upgradeIcon.gameObject, upgradeDur * 2f, new Vector3(48f, 56f, 1f), new Vector3(288f, 336f, 1f)).onFinished = delegate
		{
			TweenScale.Begin(upgradeIcon.gameObject, upgradeDur * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(upgradeIcon.gameObject, upgradeDur * 7f, Vector3.zero, Vector3.zero).onFinished = delegate
		{
			Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(upgradeIcon.gameObject, upgradeDur * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	public void UpdateArmy()
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.UpdateName();
		}
		RepositionBottomContent();
	}

	public void SendEquippedUnits()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (LevelBehaviour item in behaviours)
		{
			Dictionary<string, object> dictionary2 = null;
			if (item.upgradeSlots.wasEquipped)
			{
				dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("wasEquipped", item.upgradeSlots.wasEquipped);
			}
			if (item.upgradeSlots.equipped)
			{
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<string, object>();
				}
				dictionary2.Add("equipped", item.upgradeSlots.equipped);
			}
			if (dictionary2 != null)
			{
				dictionary.Add(item.upgradeSlots.GetSheetName(), dictionary2);
			}
		}
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		dictionary3.Add("armyPower", LevelManager.instance.armyPower);
		dictionary3.Add("equips", dictionary);
		Dictionary<string, object> value = dictionary3;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpdateEquippedUnits, JsonConvert.SerializeObject(value), 0, 0, string.Empty);
	}

	internal void BuyUnit(LevelBehaviour behaviour, int discount = 0)
	{
		if (!behaviour.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Name", behaviour.upgradeSlots.GetSheetName());
			dictionary.Add("Warbucks", behaviour.upgradeSlots.price);
			dictionary.Add("Gold", behaviour.upgradeSlots.priceGold);
			dictionary.Add("UnlockLevel", behaviour.upgradeSlots.unlockLevel.displayNumber);
			dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			dictionary.Add("discount", discount);
			string objData = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest(DatabaseAction.BuyUnit, objData, behaviour.upgradeSlots.price * (100 - discount) / 100, behaviour.upgradeSlots.priceGold * (100 - discount) / 100, behaviour.upgradeSlots.GetSheetName());
		}
		behaviour.upgradeSlots.Buy();
		if (behaviour.upgradeSlots.unitDeliveryTime == 0)
		{
			ActivateUnit(behaviour);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
		}
	}

	internal void InstantBuyUnit(LevelBehaviour behaviour)
	{
		if (!behaviour.upgradeSlots.isTutorialUnit)
		{
			float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.InstantBuyUnit, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"LevelName",
					behaviour.upgradeSlots.GetSheetName()
				},
				{
					"ExpectedPrice",
					behaviour.upgradeSlots.instantUnitDeliveryPrice
				},
				{ "GoldCoefficient", num },
				{ "GoldExpCoefficient", num2 }
			}), 0, behaviour.upgradeSlots.instantUnitDeliveryPrice, behaviour.upgradeSlots.GetSheetName());
		}
		behaviour.upgradeSlots.InstantBuyUnit();
		AfterUnitIsBought(behaviour);
	}

	internal void ActivateUnit(LevelBehaviour behaviour)
	{
		if (!behaviour.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ActivateUnit, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			} }), 0, 0, string.Empty);
		}
		behaviour.upgradeSlots.ActivateUnit();
		AfterUnitIsBought(behaviour);
	}

	public void AfterUnitIsBought(LevelBehaviour behaviour)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool flag = Singleton<ActiveUnitsManager>.instance.TryToEquip(behaviour);
		if (flag)
		{
			SendEquippedUnits();
		}
		if (isShowed)
		{
			if (!Singleton<GameController>.instance.isTutorial)
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int changeNumber = armyPowerX2 - armyPowerX;
				armyPowerAnimation.StartAnimation(changeNumber, armyPowerX2, 0.05f);
			}
			GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		}
		if (GuiElementSingle<RentalDialog>.instance.isShowed)
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int changeNumber2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.armyPowerAnimation.StartAnimation(changeNumber2, armyPowerX3, 0.05f);
		}
		if (isShowed && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.ShowActiveUnits();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			if (selectedIcon != null)
			{
				selectedIcon.TutorialAnimateIcon();
			}
			upgradeParticles.Play();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
	}

	internal void PromoteUnit(LevelBehaviour behaviour)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.PromoteUnit, JsonConvert.SerializeObject(new Dictionary<string, object> { 
		{
			"LevelName",
			behaviour.upgradeSlots.GetSheetName()
		} }), 0, 0, string.Empty);
		behaviour.upgradeSlots.PromoteUnit();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.PromoteUnit);
		PromoteUnitBottomIconAnimation(behaviour);
	}

	internal void UpgradeUnitUpgrade(LevelBehaviour behaviour, int discount = 0, bool isSpecial = false)
	{
		UpgradeSlot upgradeSlot = ((!isSpecial) ? behaviour.upgradeSlots.upgradeSlot : behaviour.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.upgradePrice * (100 - discount) / 100;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		upgradeSlot.BuyUpgrade();
		requestBuffer.AddRequest(DatabaseAction.BuyUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", upgradeSlot.boughtIndex },
			{
				"StartTime",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{
				"IsSpecial",
				(!isSpecial) ? "0" : "1"
			},
			{ "discount", discount },
			{ "DeliveryTime", upgradeSlot.deliveryTime }
		}), warbucks, 0, behaviour.upgradeSlots.GetSheetName());
	}

	internal void DeliverNowUnitUpgrade(LevelBehaviour behaviour, bool showAnimation)
	{
		UpgradeSlot deliveringSlot = behaviour.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			Debug.LogError("Current unit is not delivered at the moment!!!");
			return;
		}
		int instantBuyPrice = deliveringSlot.instantBuyPrice;
		int boughtIndex = deliveringSlot.boughtIndex;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		string parameterValue = ((!deliveringSlot.isSpecial) ? (behaviour.upgradeSlots.GetSheetName() + " " + boughtIndex) : (behaviour.upgradeSlots.GetSheetName() + " Special " + boughtIndex));
		Singleton<EventTrackingManager>.instance.RegisterGameItemDeliverEvent("Deliver_Upgrade_For_Army_Unit", "Army_Unit_ID", parameterValue, instantBuyPrice, behaviour.upgradeSlots.remainingDeliveringSeconds);
		deliveringSlot.InstantActivation();
		float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
		float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		requestBuffer.AddRequest(DatabaseAction.InstantUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{ "ExpectedPrice", instantBuyPrice },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			},
			{ "GoldCoefficient", num },
			{ "GoldExpCoefficient", num2 }
		}), 0, instantBuyPrice, behaviour.upgradeSlots.GetSheetName());
	}

	internal void ActivationUnitUpgrade(LevelBehaviour behaviour, bool showAnimation)
	{
		UpgradeSlot deliveringSlot = behaviour.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			Debug.LogError("Current unit is not delivering at the moment!!!");
			return;
		}
		int boughtIndex = deliveringSlot.boughtIndex;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		deliveringSlot.Activate();
		requestBuffer.AddRequest(DatabaseAction.ActivateUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			}
		}), 0, 0, string.Empty);
	}

	public void BuyUnitElite(LevelBehaviour behaviour)
	{
		UpgradeSlotElite upgradeSlotElite = behaviour.upgradeSlots.upgradeSlotElite;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpgradeEliteSlot, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			},
			{
				"BoughtIndex",
				behaviour.upgradeSlots.upgradeSlotElite.boughtIndex
			},
			{ "SpentWarbucks", 0 },
			{ "SpentParts", upgradePriceParts }
		}), 0, 0, string.Empty);
		behaviour.upgradeSlots.upgradeSlotElite.currentParts -= upgradePriceParts;
		upgradeSlotElite.BuyAndActivate();
	}

	public void UpgradeUnitElite(LevelBehaviour behaviour, int discount = 0)
	{
		UpgradeSlotElite upgradeSlotElite = behaviour.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.upgradePrice * (100 - discount) / 100;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpgradeEliteSlot, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				behaviour.upgradeSlots.GetSheetName()
			},
			{
				"BoughtIndex",
				behaviour.upgradeSlots.upgradeSlotElite.boughtIndex
			},
			{ "SpentWarbucks", num },
			{ "SpentParts", upgradePriceParts }
		}), 0, 0, string.Empty);
		behaviour.upgradeSlots.upgradeSlotElite.currentParts -= upgradePriceParts;
		upgradeSlotElite.BuyAndActivate();
	}

	internal void WasShown(string sheetName)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ArmyUnitWasShown, sheetName, 0, 0, string.Empty);
	}
}
