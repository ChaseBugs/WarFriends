using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class WeaponScreen : GuiScreenSingle<WeaponScreen>
{
	[Header("Left")]
	public WeaponLeftContent weaponLeftContent;

	[Header("Center")]
	public CircleProgress circleCreator;

	public UISprite upgradeIcon;

	public UISprite upgradeGlow;

	public ParticleSystem upgradeParticles;

	[Header("Right")]
	public WeaponRightContent weaponRightContent;

	[Header("Bottom Weapon List")]
	public WeaponGuiRecord weaponRecordPrefab;

	public NameGuiRecord nameRecordPrefab;

	public UIDraggablePanel draggablePanel;

	public UITable weaponTable;

	[Header("Buttons")]
	public UIGridStretchWidth categoriesGrid;

	public WeaponEquipSlotButton weaponCategoryButtonPrefab;

	[Header("Back Button Tutorial")]
	public UIButton backButton;

	[Header("Animation")]
	public ArmyPowerAnimation armyPowerAnimation;

	public float upgradeDur = 0.05f;

	[HideInInspector]
	public WeaponGuiRecord selectedIcon;

	[HideInInspector]
	public List<WeaponGuiRecord> weaponIcons;

	[HideInInspector]
	public List<WeaponEquipSlotButton> weaponCategoryButtons;

	private List<NameGuiRecord> mCategoryNamesIcons;

	private ObjectPool mPool;

	private bool mIsFullyShowed;

	private bool mForceShow;

	private float mTimer;

	private WeaponLevelsSetup.State mWeaponState;

	private Dictionary<WeaponCategory, string> mCategoryPrefix = new Dictionary<WeaponCategory, string>
	{
		{
			WeaponCategory.AssaultRifle,
			"01"
		},
		{
			WeaponCategory.SMG,
			"02"
		},
		{
			WeaponCategory.LMG,
			"03"
		},
		{
			WeaponCategory.Minigun,
			"04"
		},
		{
			WeaponCategory.SniperRifle,
			"05"
		},
		{
			WeaponCategory.Shotgun,
			"06"
		},
		{
			WeaponCategory.Grenade,
			"07"
		},
		{
			WeaponCategory.GrenadeLauncher,
			"08"
		},
		{
			WeaponCategory.RocketLauncher,
			"09"
		},
		{
			WeaponCategory.Pistol,
			"10"
		}
	};

	public WeaponCategory selectedCategory
	{
		get
		{
			if (selectedIcon == null)
			{
				return WeaponCategory.Primary;
			}
			return selectedIcon.weaponSetup.weaponCategory;
		}
	}

	public void SelectWeapon(WeaponLevelsSetup weapon)
	{
		mForceShow = true;
		SavingLastSelected.instance.SaveLastWeapon(weapon);
	}

	protected override void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		weaponCategoryButtons = new List<WeaponEquipSlotButton>();
		int count = PlayerInventory.instance.inventorySlots.Count;
		for (int i = 0; i < count; i++)
		{
			WeaponEquipSlotButton weaponEquipSlotButton = UnityEngine.Object.Instantiate(weaponCategoryButtonPrefab);
			weaponEquipSlotButton.gameObject.name = $"{i} {PlayerInventory.instance.inventorySlots[i].category} Button";
			weaponEquipSlotButton.transform.parent = categoriesGrid.transform;
			weaponEquipSlotButton.transform.localScale = Vector3.one;
			weaponEquipSlotButton.transform.localPosition = new Vector3(weaponEquipSlotButton.transform.localPosition.x, weaponEquipSlotButton.transform.localPosition.y, 0f);
			weaponEquipSlotButton.Initialize(PlayerInventory.instance.inventorySlots[i], count);
			weaponCategoryButtons.Add(weaponEquipSlotButton);
		}
		categoriesGrid.columns = count;
		categoriesGrid.Reposition();
		GameLoginManager.instance.PlayerLogOut += ResetScreenForOtherUpgrade;
		LevelManager.LevelUp += OnLevelUp;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<NotificationManager>.instance.WeaponDelivered += delegate
		{
			if (isShowed)
			{
				UpdateNotificationsInCategories();
			}
		};
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				UpdateSalesInCategories();
				foreach (WeaponGuiRecord weaponIcon in weaponIcons)
				{
					weaponIcon.SetSale();
				}
				weaponLeftContent.SetSaleAndPrize();
				weaponRightContent.SetSaleAndPrize();
			}
		};
		weaponRightContent.InitControls();
		weaponLeftContent.InitControls();
	}

	private void ResetScreenForOtherUpgrade()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.SetEquiped(isEquiped: false);
		}
	}

	private void OnLevelUp()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			ShowWeapon(selectedIcon.weaponSetup);
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		switch (action)
		{
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
			UpdateGui(selectedIcon.weaponSetup);
			break;
		}
	}

	public override void InitGUIValues()
	{
		WeaponLevelsSetup weaponLevelsSetup = ChooseWeaponToShow();
		SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
		SelectAndCenterWeapon(weaponLevelsSetup);
		Select();
	}

	private WeaponLevelsSetup ChooseWeaponToShow()
	{
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		if (weaponLevelsSetup == null)
		{
			Debug.Log("Last weapon not choosen!!!!!");
			weaponLevelsSetup = LevelManager.instance.weaponLevelsSetups[0];
		}
		if (mForceShow)
		{
			mForceShow = false;
			return weaponLevelsSetup;
		}
		WeaponLevelsSetup weaponLevelsSetup2 = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup2 != null)
		{
			return weaponLevelsSetup2;
		}
		WeaponLevelsSetup unlockedWeaponWithNotification = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
		if (unlockedWeaponWithNotification != null)
		{
			return unlockedWeaponWithNotification;
		}
		return weaponLevelsSetup;
	}

	private void SelectAndCenterWeapon(WeaponLevelsSetup weapon)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(isSelected: false);
		}
		PlayerInventory.InventorySlot inventorySlot = null;
		foreach (PlayerInventory.InventorySlot inventorySlot2 in PlayerInventory.instance.inventorySlots)
		{
			if ((inventorySlot2.category & weapon.weaponCategory) == weapon.weaponCategory)
			{
				inventorySlot = inventorySlot2;
			}
		}
		WeaponCategory categories = inventorySlot?.category ?? weapon.weaponCategory;
		InstantiateBottomWeapons(categories);
		int num = weaponIcons.FindIndex((WeaponGuiRecord icon) => icon.weaponSetup == weapon);
		if (num == -1)
		{
			selectedIcon = weaponIcons[0];
		}
		else
		{
			selectedIcon = weaponIcons[num];
		}
		selectedIcon.SetHighlight(isSelected: true);
		ShowCorrectBottom();
		RepositBottomContent();
	}

	private void InstantiateBottomWeapons(WeaponCategory categories)
	{
		if (weaponIcons == null)
		{
			weaponIcons = new List<WeaponGuiRecord>();
		}
		else
		{
			weaponIcons.Clear();
		}
		if (mCategoryNamesIcons == null)
		{
			mCategoryNamesIcons = new List<NameGuiRecord>();
		}
		else
		{
			mCategoryNamesIcons.Clear();
		}
		mPool.FreeObjectsWithPrefab(weaponRecordPrefab);
		mPool.FreeObjectsWithPrefab(nameRecordPrefab);
		if (MiscTools.IsPowerOfTwo((int)categories))
		{
			InstantiateCategoryWeapons(categories, mCategoryPrefix[categories]);
			return;
		}
		foreach (int value in Enum.GetValues(typeof(WeaponCategory)))
		{
			if (mCategoryPrefix.ContainsKey((WeaponCategory)value) && MiscTools.IsPowerOfTwo(value) && ((uint)value & (uint)categories) == (uint)value)
			{
				InstantiateCategoryWeapons((WeaponCategory)value, mCategoryPrefix[(WeaponCategory)value]);
			}
		}
	}

	private void InstantiateCategoryWeapons(WeaponCategory category, string prefix)
	{
		List<WeaponLevelsSetup> list = new List<WeaponLevelsSetup>();
		foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
		{
			if (weaponLevelsSetup3.weaponCategory == category && weaponLevelsSetup3.canBeShownInScreen)
			{
				list.Add(weaponLevelsSetup3);
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeapon();
		PlayerInventory.InventorySlot inventorySlot = null;
		foreach (PlayerInventory.InventorySlot inventorySlot2 in PlayerInventory.instance.inventorySlots)
		{
			if (category == (category & inventorySlot2.category))
			{
				inventorySlot = inventorySlot2;
			}
		}
		NameGuiRecord nameGuiRecord = mPool.InstantiateAsChild(nameRecordPrefab, Vector3.zero, Quaternion.identity, weaponTable.gameObject) as NameGuiRecord;
		if (nameGuiRecord != null)
		{
			nameGuiRecord.name = $"{prefix} 00 {category.ToString()}";
			nameGuiRecord.InitializeName(category);
			mCategoryNamesIcons.Add(nameGuiRecord);
		}
		for (int i = 0; i < list.Count; i++)
		{
			WeaponLevelsSetup weaponLevelsSetup2 = list[i];
			WeaponGuiRecord weaponGuiRecord = mPool.InstantiateAsChild(weaponRecordPrefab, Vector3.zero, Quaternion.identity, weaponTable.gameObject) as WeaponGuiRecord;
			if (!(weaponGuiRecord == null))
			{
				weaponGuiRecord.name = string.Format("{0} {1} {2} {3}", prefix, (1 + weaponLevelsSetup2.unlockLevelIndex).ToString("D2"), weaponLevelsSetup2.guiOrder.ToString("D2"), weaponLevelsSetup2.weaponName);
				weaponGuiRecord.Init(weaponLevelsSetup2);
				if (weaponLevelsSetup2 == inventorySlot.weaponLevelsSetup)
				{
					weaponGuiRecord.SetEquiped(isEquiped: true);
				}
				if (weaponLevelsSetup == null && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup2);
					weaponLevelsSetup = weaponLevelsSetup2;
				}
				weaponIcons.Add(weaponGuiRecord);
			}
		}
	}

	private void RepositBottomContent()
	{
		BottomIconAndNameGraphicsForReposition(show: false);
		weaponTable.repositionNow = true;
		weaponTable.onReposition = delegate
		{
			weaponTable.onReposition = null;
			weaponTable.repositionNow = false;
			BottomIconAndNameGraphicsForReposition(show: true);
			Vector3 zero = Vector3.zero;
			Transform parent = selectedIcon.transform;
			for (int i = 0; i < 2; i++)
			{
				zero += parent.localPosition;
				parent = parent.parent;
			}
			draggablePanel.AlignToCenter(zero, instant: true);
		};
	}

	private void BottomIconAndNameGraphicsForReposition(bool show)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(show);
		}
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.GUIForReposition(show);
		}
		foreach (NameGuiRecord mCategoryNamesIcon in mCategoryNamesIcons)
		{
			mCategoryNamesIcon.GUIForReposition(show);
		}
	}

	private void ShowCorrectBottom()
	{
		WeaponCategory weaponCategory = selectedIcon.weaponSetup.weaponCategory;
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Highlight(weaponCategory);
		}
	}

	public void Select()
	{
		ShowWeapon(selectedIcon.weaponSetup);
		UpdateNotificationsInCategories();
		UpdateSalesInCategories();
	}

	public void UpdateNotificationsInCategories()
	{
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Notification();
		}
	}

	public void UpdateSalesInCategories()
	{
		foreach (WeaponEquipSlotButton weaponCategoryButton in weaponCategoryButtons)
		{
			weaponCategoryButton.Sale();
		}
		foreach (NameGuiRecord mCategoryNamesIcon in mCategoryNamesIcons)
		{
			mCategoryNamesIcon.Sale();
		}
	}

	public void WeaponCategoryButtonClick(WeaponCategory category)
	{
		Debug.Log("Clicked on category " + category);
		int num = 0;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & category) == category)
			{
				num = i;
			}
		}
		WeaponEquipSlotButton weaponEquipSlotButton = weaponCategoryButtons[num];
		WeaponLevelsSetup weaponLevelsSetup = SavingLastSelected.instance.GetLastWeaponForIndex(num);
		if (weaponLevelsSetup == null || weaponLevelsSetup.weaponCategory != (weaponLevelsSetup.weaponCategory & weaponEquipSlotButton.WeaponCategoryOfButton()))
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup2 in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup2.weaponCategory == (weaponLevelsSetup2.weaponCategory & weaponEquipSlotButton.WeaponCategoryOfButton()) && weaponLevelsSetup2.unlockLevelIndex == 0)
				{
					weaponLevelsSetup = weaponLevelsSetup2;
					SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
					break;
				}
			}
			if (weaponLevelsSetup == null)
			{
				foreach (WeaponLevelsSetup weaponLevelsSetup3 in LevelManager.instance.weaponLevelsSetups)
				{
					if (weaponLevelsSetup3.weaponCategory == (weaponLevelsSetup3.weaponCategory & weaponEquipSlotButton.WeaponCategoryOfButton()))
					{
						weaponLevelsSetup = weaponLevelsSetup3;
						SavingLastSelected.instance.SaveLastWeapon(weaponLevelsSetup);
						break;
					}
				}
			}
		}
		SelectAndCenterWeapon(weaponLevelsSetup);
		Select();
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
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<WeaponPreviewCamera>.instance.Hide();
		selectedIcon.SetHighlight(isSelected: false);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mPool.FreeObjectsWithPrefab(weaponRecordPrefab);
		mPool.FreeObjectsWithPrefab(nameRecordPrefab);
		weaponLeftContent.DoAfterHide();
		weaponRightContent.DoAfterHide();
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
			WeaponLevelsSetup weaponSetup = selectedIcon.weaponSetup;
			Singleton<WeaponPreviewCamera>.instance.DisplayeWeapon(weaponSetup.weaponModelPrefabName, weaponSetup.assetBundleName, weaponSetup.defaultRotation, weaponSetup.defaultPosition);
		}
	}

	public void UpdateBottomGraphics()
	{
		foreach (WeaponGuiRecord weaponIcon in weaponIcons)
		{
			weaponIcon.UpdateGraphics();
		}
	}

	public void UpdateBottomIcon()
	{
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.UpdateGraphics();
	}

	public void ShowWeapon(WeaponLevelsSetup weapon)
	{
		if (!weapon.showed && weapon.unlocked && !weapon.tryOutWeapon)
		{
			WasShown(weapon.GetSheetName());
		}
		weapon.showed = true;
		SavingLastSelected.instance.SaveLastWeapon(weapon);
		DisplayModel();
		weaponRightContent.SelectWeapon(weapon);
		weaponLeftContent.SelectWeapon(weapon);
		UpdateGui(weapon);
		mWeaponState = weapon.weaponState;
	}

	public void UpdateGui(WeaponLevelsSetup weapon, bool changedWeapon = true)
	{
		Refresh();
		weaponRightContent.UpdateRightContent(changedWeapon);
		weaponLeftContent.UpdateLeftContent(changedWeapon);
		UpdateNotificationsInCategories();
		UpdateSalesInCategories();
		UpdateBottomIcon();
		if (weapon.weaponState == WeaponLevelsSetup.State.WeaponDelivering)
		{
			circleCreator.deliveringAnimation = true;
		}
		else
		{
			circleCreator.FillCircle(weapon.upgradesProgress);
		}
	}

	public void Refresh()
	{
	}

	protected override void Update()
	{
		base.Update();
		if (selectedIcon != null && selectedIcon.weaponSetup != null)
		{
			if (mWeaponState != selectedIcon.weaponSetup.weaponState)
			{
				Debug.Log($"Weapon state changed from \"{mWeaponState.ToString().ToUpper()}\" to \"{selectedIcon.weaponSetup.weaponState.ToString().ToUpper()}\"");
				mWeaponState = selectedIcon.weaponSetup.weaponState;
				UpdateGui(selectedIcon.weaponSetup, changedWeapon: false);
			}
			mTimer += Time.deltaTime;
			if (mTimer >= 0.333f)
			{
				mTimer -= 0.333f;
				UpdateProgressAndTexts();
			}
		}
	}

	private void UpdateProgressAndTexts()
	{
		if (mWeaponState == WeaponLevelsSetup.State.WeaponDelivering)
		{
			weaponRightContent.UpdateDeliveringTime((float)selectedIcon.weaponSetup.remainingDeliveringSeconds, selectedIcon.weaponSetup.progressDelivering);
		}
		if (mWeaponState == WeaponLevelsSetup.State.Delivering)
		{
			weaponLeftContent.UpdateDeliveringTime((float)selectedIcon.weaponSetup.remainingDeliveringSeconds, selectedIcon.weaponSetup.progressDelivering);
		}
	}

	public void AnimateUpgrade()
	{
		upgradeParticles.Play();
		Singleton<WeaponPreviewCamera>.instance.StartFastRotation();
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
			Singleton<WeaponPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(upgradeIcon.gameObject, upgradeDur * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	internal void BuyWeapon(WeaponLevelsSetup setup, int discount = 0)
	{
		if (!setup.isTutorialWeapon)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Name", setup.GetSheetName());
			dictionary.Add("Warbucks", setup.price);
			dictionary.Add("Gold", setup.priceGold);
			dictionary.Add("UnlockLevel", setup.unlockLevel.displayNumber);
			dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			dictionary.Add("discount", discount);
			string objData = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest(DatabaseAction.BuyWeapon, objData, setup.price * (100 - discount) / 100, setup.priceGold * (100 - discount) / 100, setup.GetSheetName());
		}
		setup.Buy();
		if (setup.weaponDeliveryTime == 0)
		{
			ActivateWeapon(setup);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
		}
	}

	internal void InstantBuyWeapon(WeaponLevelsSetup setup)
	{
		if (!setup.isTutorialWeapon)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
			requestBuffer.AddRequest(DatabaseAction.InstantBuyWeapon, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"LevelName",
					setup.GetSheetName()
				},
				{ "ExpectedPrice", setup.instantWeaponDeliveryPrice },
				{ "GoldCoefficient", num },
				{ "GoldExpCoefficient", num2 }
			}), 0, setup.instantWeaponDeliveryPrice, setup.GetSheetName());
		}
		setup.InstantBuyWeapon();
		AfterWeaponIsBought(setup);
	}

	internal void ActivateWeapon(WeaponLevelsSetup setup)
	{
		if (!setup.isTutorialWeapon)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ActivateWeapon, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"LevelName",
				setup.GetSheetName()
			} }), 0, 0, string.Empty);
		}
		setup.ActivateWeapon();
		AfterWeaponIsBought(setup);
	}

	public void AfterWeaponIsBought(WeaponLevelsSetup setup, bool rentalWeaponBought = false)
	{
		int playerInvetorySlotIndex = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & setup.weaponCategory) == setup.weaponCategory)
			{
				playerInvetorySlotIndex = i;
			}
		}
		EquipWeapon(setup, playerInvetorySlotIndex, !rentalWeaponBought);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Buy);
		if (setup.weaponCategory == WeaponCategory.RocketLauncher)
		{
			int num = LevelManager.instance.NumberOfBought(WeaponCategory.RocketLauncher);
			if (num == 1)
			{
				Singleton<MessageManager>.instance.AddMessage(new WeaponTutorialDialogMessage(setup));
			}
		}
	}

	internal void UpgradeWeaponUpgrade(WeaponLevelsSetup setup, int discount = 0)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		setup.upgradeSlots.BuyUpgrade();
		requestBuffer.AddRequest(DatabaseAction.BuyWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				setup.GetSheetName()
			},
			{
				"BoughtIndex",
				setup.upgradeSlots.boughtIndex
			},
			{
				"StartTime",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{ "discount", discount },
			{
				"DeliveryTime",
				setup.upgradeSlots.deliveryTime
			}
		}), setup.upgradeSlots.upgradePrice * (100 - discount) / 100, 0, setup.GetSheetName());
	}

	internal void DeliverNowWeaponUpgrade(WeaponLevelsSetup setup, bool showAnimation)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		int instantBuyPrice = setup.upgradeSlots.instantBuyPrice;
		int boughtIndex = setup.upgradeSlots.boughtIndex;
		Singleton<EventTrackingManager>.instance.RegisterGameItemDeliverEvent("Deliver_Upgrade_For_Weapon", "Weapon_ID", setup.GetSheetName() + " " + setup.upgradeSlots.boughtIndex, setup.upgradeSlots.instantBuyPrice, setup.remainingDeliveringSeconds);
		setup.upgradeSlots.InstantActivation();
		float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
		float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		requestBuffer.AddRequest(DatabaseAction.InstantWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				setup.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{ "ExpectedPrice", instantBuyPrice },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			},
			{ "GoldCoefficient", num },
			{ "GoldExpCoefficient", num2 }
		}), 0, instantBuyPrice, setup.GetSheetName());
	}

	internal void ActivationWeaponUpgrade(WeaponLevelsSetup setup, bool showAnimation)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		int boughtIndex = setup.upgradeSlots.boughtIndex;
		setup.upgradeSlots.Activate();
		requestBuffer.AddRequest(DatabaseAction.ActivateWeaponUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				setup.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			}
		}), 0, 0, string.Empty);
	}

	public void WasShown(string sheetName)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.WeaponWasShown, sheetName, 0, 0, string.Empty);
	}

	public void EquipWeapon(WeaponLevelsSetup setup, int playerInvetorySlotIndex, bool updateGUI = true)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		PlayerInventory.instance.inventorySlots[playerInvetorySlotIndex].weaponIndex = setup.indexInLevelManager;
		PlayerController.currentPlayer.playerProperties.weapons = PlayerInventory.instance.equippedWeapons;
		if (!Singleton<GameController>.instance.isTutorial)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.EquipWeapon, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"Index",
					setup.indexInLevelManager.ToString()
				},
				{
					"Name",
					setup.GetSheetName()
				},
				{ "SlotIndex", playerInvetorySlotIndex },
				{
					"ArmyPower",
					LevelManager.instance.armyPower
				}
			}), 0, 0, string.Empty);
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.EquipWeapon);
		if (updateGUI && GuiScreenSingle<WeaponScreen>.instance.isShowed)
		{
			weaponRightContent.ShowEquipAnimation();
			weaponLeftContent.UpdateContentAfterEquip();
			if (!Singleton<GameController>.instance.isTutorial)
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int changeNumber = armyPowerX2 - armyPowerX;
				armyPowerAnimation.StartAnimation(changeNumber, armyPowerX2, 0.05f);
			}
			{
				foreach (WeaponGuiRecord weaponIcon in GuiScreenSingle<WeaponScreen>.instance.weaponIcons)
				{
					weaponIcon.SetEquiped(setup == weaponIcon.weaponSetup);
				}
				return;
			}
		}
		if (!updateGUI && GuiElementSingle<RentalDialog>.instance.isShowed)
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int changeNumber2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.armyPowerAnimation.StartAnimation(changeNumber2, armyPowerX3, 0.05f);
		}
	}
}
