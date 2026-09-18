using System;
using System.Collections.Generic;
using BestHTTP;
using UnityEngine;

public class SpecialOfferDialog : GuiElementSingle<SpecialOfferDialog>, IGuiDialog
{
	[Header("Content")]
	public GameObject closeButton;

	public UILabel title;

	[Header("Middle")]
	public UIDraggablePanel draggablePanel;

	public SpringPanel springPanel;

	public GameObject contentPart;

	public GameObject leftSpacer;

	public GameObject rightSpacer;

	public SpecialOfferRecord recordPrefab;

	public UITexture texture;

	[Header("-Sale")]
	public GameObject salePart;

	public AnimationCurve animationCurveSaleShow = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

	public AnimationCurve animationCurveSaleHide = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(1f, 1f, 1f, 0f));

	public UISprite saleBackground;

	public UILabel saleLabel;

	public UILabel sale;

	[Header("-Description")]
	public UISprite descriptionBackground;

	public UILabel description;

	[Header("Bottom")]
	public UISprite timeIcon;

	public UILabel timeLabel;

	public WinStreakCounter timeCounter;

	public BoxCollider bottomButton;

	public UILabel bottomButtonLabel;

	[Header("-Points")]
	public GameObject pointsPart;

	public UISprite pointPrefab;

	private OneOffer[] mOffers;

	private List<SpecialOfferRecord> mRecords = new List<SpecialOfferRecord>();

	private List<UISprite> mPoints = new List<UISprite>();

	private int mShowOffer;

	private int mIndex;

	private OneOffer mShownContent;

	private bool mShowSale = true;

	private float mRecordWidth = 1568f;

	private bool mDragging;

	private Vector3 mStartVector;

	private int mStartIndex;

	private Texture2D tempTexture;

	public void ShowDialog(OneOffer[] offers)
	{
		Singleton<EventTrackingManager>.instance.SpecialOffer("Dialog_Displayed");
		mOffers = offers;
		mShowOffer = 0;
		CheckOffers();
		if (mOffers.Length > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SpecialOfferDialog>.instance, 0f);
		}
	}

	public void ShowDialog(OneOffer[] offers, int index)
	{
		mOffers = offers;
		mShowOffer = index;
		CheckOffers();
		if (mOffers.Length > 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SpecialOfferDialog>.instance, 0f);
		}
	}

	public void ShowDialog()
	{
		mOffers = new OneOffer[3]
		{
			OneOffer.CreateTestOffer(),
			OneOffer.CreateTestOffer(1),
			OneOffer.CreateTestOffer(2)
		};
		mShowOffer = 0;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<SpecialOfferDialog>.instance, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(bottomButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ButtonClick));
		mRecords.Add(recordPrefab);
		mPoints.Add(pointPrefab);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ButtonClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (mOffers[mIndex].type != OffersDestination.CloseDialog)
		{
			Singleton<EventTrackingManager>.instance.SpecialOffer("Dialog_Clicked");
		}
		switch (mOffers[mIndex].type)
		{
		case OffersDestination.WarshopCardpacksOne:
		case OffersDestination.WarshopCardpacksFlat:
			GuiElementSingle<InappScreen>.instance.ShowCardPacks();
			break;
		case OffersDestination.WarshopLootboxesFlat:
			GuiElementSingle<InappScreen>.instance.ShowLootboxes();
			break;
		case OffersDestination.VIPFlat:
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
			break;
		case OffersDestination.ArmyScreenFlatBuy:
		case OffersDestination.ArmyScreenTypeFlatBuy:
		case OffersDestination.ArmyScreenFlatUpgrade:
		case OffersDestination.ArmyScreenTypeFlatUpgrade:
		case OffersDestination.ArmyScreenFlatUpgradeBuy:
		case OffersDestination.ArmyScreenTypeFlatUpgradeBuy:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			break;
		case OffersDestination.ArmyScreenUnitOneBuy:
		case OffersDestination.ArmyScreenUnitOneUpgrade:
		case OffersDestination.ArmyScreenUnitOneUpgradeBuy:
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.Unit(mOffers[mIndex].additionalInfo);
			if (levelBehaviour != null)
			{
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(levelBehaviour);
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			break;
		}
		case OffersDestination.WeaponScreenFlatBuy:
		case OffersDestination.WeaponScreenFlatUpgrade:
		case OffersDestination.WeaponScreenFlatUpgradeBuy:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			break;
		case OffersDestination.WeaponScreenSlotFlatBuy:
		case OffersDestination.WeaponScreenTypeFlatBuy:
		case OffersDestination.WeaponScreenSlotFlatUpgrade:
		case OffersDestination.WeaponScreenTypeFlatUpgrade:
		case OffersDestination.WeaponScreenSlotFlatUpgradeBuy:
		case OffersDestination.WeaponScreenTypeFlatUpgradeBuy:
		{
			WeaponCategory weaponCategory = MiscTools.ParseCategory(mOffers[mIndex].additionalInfo);
			if (weaponCategory != WeaponCategory.None)
			{
				int lastUnlockedWeapon = LevelManager.instance.GetLastUnlockedWeapon(weaponCategory, LevelManager.instance.currentLevel.index);
				WeaponLevelsSetup weapon = LevelManager.instance.weaponLevelsSetups[lastUnlockedWeapon];
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weapon);
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			break;
		}
		case OffersDestination.WeaponScreenWeaponOneBuy:
		case OffersDestination.WeaponScreenWeaponOneUpgrade:
		case OffersDestination.WeaponScreenWeaponOneUpgradeBuy:
		{
			WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(mOffers[mIndex].additionalInfo);
			if (weaponLevelsSetup != null)
			{
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponLevelsSetup);
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			break;
		}
		case OffersDestination.BuyInApp:
		{
			string additionalInfo = mOffers[mIndex].additionalInfo;
			if (!PlayerAnalytics.instance.IsPackBought(additionalInfo))
			{
				Debug.Log("Clicked buy on " + additionalInfo);
				Singleton<BeanstalkServerManager>.instance.BuyPack(additionalInfo, "Main_Menu_Offers_Bar");
			}
			break;
		}
		case OffersDestination.PrepareForBattle:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			break;
		case OffersDestination.PrepareForBattleGameModes:
			GuiScreenSingle<BattlePreparationScreen>.instance.OpenScreenWithGameModesOpen();
			break;
		case OffersDestination.CloseDialog:
			break;
		}
	}

	public override void InitGUIValues()
	{
		CheckOffers();
		if (mOffers.Length >= 1)
		{
			InitializeRecords();
			InitializePoints();
			draggablePanel.enabled = mOffers.Length > 1;
			springPanel.enabled = false;
			mShownContent = null;
			mShowSale = false;
			mIndex = mShowOffer;
			float num = mRecordWidth * (float)mIndex;
			draggablePanel.transform.localPosition = draggablePanel.transform.localPosition.ReplaceX(0f - num);
			UIPanel component = draggablePanel.gameObject.GetComponent<UIPanel>();
			if (component != null)
			{
				component.clipRange = component.clipRange.ReplaceX(num);
			}
			CenteringDone();
			if (!base.isFullyShowed)
			{
				AnimateLabels(mIndex, show: true, instant: true);
			}
			else
			{
				AnimateLabels(mIndex, show: false);
			}
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		HidePicture();
	}

	private void CheckOffers()
	{
		int num = 0;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (mOffers[i].type == OffersDestination.BuyInApp)
			{
				if (mOffers[i].deadline > currentTimestamp && !PlayerAnalytics.instance.IsPackBought(mOffers[i].additionalInfo))
				{
					num++;
				}
			}
			else if (mOffers[i].deadline > currentTimestamp)
			{
				num++;
			}
		}
		if (num == 0)
		{
			mOffers = new OneOffer[0];
			if (isShowed)
			{
				HideDialog();
			}
		}
		else
		{
			if (num >= mOffers.Length)
			{
				return;
			}
			OneOffer[] array = new OneOffer[num];
			int num2 = 0;
			for (int j = 0; j < mOffers.Length; j++)
			{
				if (mOffers[j].type == OffersDestination.BuyInApp)
				{
					if (mOffers[j].deadline > currentTimestamp && !PlayerAnalytics.instance.IsPackBought(mOffers[j].additionalInfo))
					{
						array[num2++] = mOffers[j];
					}
				}
				else if (mOffers[j].deadline > currentTimestamp)
				{
					array[num2++] = mOffers[j];
				}
			}
			mOffers = array;
		}
	}

	private void InitializeRecords()
	{
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (mRecords.Count <= i)
			{
				SpecialOfferRecord specialOfferRecord = UnityEngine.Object.Instantiate(recordPrefab);
				specialOfferRecord.transform.parent = contentPart.transform;
				specialOfferRecord.transform.localScale = Vector3.one;
				mRecords.Add(specialOfferRecord);
			}
			mRecords[i].gameObject.SetActive(value: true);
			mRecords[i].transform.localPosition = new Vector3(mRecordWidth * (float)i, 0f, 0f);
		}
		for (int j = mOffers.Length; j < mRecords.Count; j++)
		{
			mRecords[j].gameObject.SetActive(value: false);
		}
	}

	private void InitializePoints()
	{
		float num = -25 * mOffers.Length;
		if (mOffers.Length % 2 == 0)
		{
			num += 25f;
		}
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (mPoints.Count <= i)
			{
				UISprite uISprite = UnityEngine.Object.Instantiate(pointPrefab);
				uISprite.transform.parent = pointsPart.transform;
				uISprite.transform.localScale = pointPrefab.transform.localScale;
				mPoints.Add(uISprite);
			}
			mPoints[i].gameObject.SetActive(value: true);
			mPoints[i].transform.localPosition = new Vector3(num + 50f * (float)i, 0f, 0f);
		}
		for (int j = mOffers.Length; j < mPoints.Count; j++)
		{
			mPoints[j].gameObject.SetActive(value: false);
		}
	}

	private void ShowContent(int index)
	{
		if (mShownContent == null || !(mShownContent.id == mOffers[index].id))
		{
			mShownContent = mOffers[index];
			mShowSale = mOffers[index].discount > 0;
			title.text = mOffers[index].title;
			description.text = mOffers[index].description;
			bottomButtonLabel.text = mOffers[index].buttonTitle;
			if (mOffers[index].type == OffersDestination.BuyInApp)
			{
				Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(mOffers[index].additionalInfo);
				bottomButtonLabel.text = itemPrice.Value2;
			}
			sale.text = MiscTools.FormatNumberAsPercent(mOffers[index].discount);
			WinStreakCounter winStreakCounter = timeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(EndOffer));
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp > mOffers[index].deadline)
			{
				mShownContent = null;
				mShowSale = false;
				InitGUIValues();
			}
			else
			{
				WinStreakCounter winStreakCounter2 = timeCounter;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(EndOffer));
				timeCounter.StartCountingTo(mOffers[index].deadline);
			}
		}
	}

	private void EndOffer()
	{
		mShownContent = null;
		mShowSale = false;
		InitGUIValues();
	}

	private void AnimateLabels(int index, bool show, bool instant = false)
	{
		float num = ((mOffers[index].discount <= 0) ? 0f : 1f);
		float num2 = ((!string.IsNullOrEmpty(mOffers[index].description)) ? 0.1f : 0f);
		if (show)
		{
			ShowContent(index);
		}
		if (instant)
		{
			TweenAlpha component = title.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			title.alpha = ((!show) ? 0f : 1f);
			TweenScale component2 = salePart.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			salePart.transform.localScale = Vector3.one;
			component = saleBackground.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			saleBackground.alpha = ((!show || !mShowSale) ? 0f : num);
			component = sale.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			sale.alpha = ((!show || !mShowSale) ? 0f : num);
			component = saleLabel.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			saleLabel.alpha = ((!show || !mShowSale) ? 0f : num);
			component = descriptionBackground.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			descriptionBackground.alpha = ((!show) ? 0f : num2);
			component = description.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			description.alpha = ((!show) ? 0f : 1f);
			component = timeIcon.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			timeIcon.alpha = ((!show) ? 0f : 1f);
			component = timeLabel.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			timeLabel.alpha = ((!show) ? 0f : 1f);
			component = timeCounter.counterLabel.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			timeCounter.counterLabel.alpha = ((!show) ? 0f : 1f);
			component = bottomButtonLabel.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			bottomButtonLabel.alpha = ((!show) ? 0f : 1f);
			InstaAnimatePoints(index);
			return;
		}
		float duration = 0.2f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(title.gameObject, duration, (!show) ? 0f : 1f);
		if (show)
		{
			tweenAlpha.onFinished = null;
		}
		else
		{
			tweenAlpha.onFinished = delegate
			{
				AnimateLabels(index, show: true);
			};
		}
		TweenScale tweenScale = TweenScale.Begin(salePart, duration, (!show) ? new Vector3(0.5f, 0.5f, 1f) : Vector3.one);
		tweenScale.animationCurve = ((!show) ? animationCurveSaleHide : animationCurveSaleShow);
		TweenAlpha.Begin(saleBackground.gameObject, duration, (!show || !mShowSale) ? 0f : num);
		TweenAlpha.Begin(sale.gameObject, duration, (!show || !mShowSale) ? 0f : num);
		TweenAlpha.Begin(saleLabel.gameObject, duration, (!show || !mShowSale) ? 0f : num);
		TweenAlpha.Begin(descriptionBackground.gameObject, duration, (!show) ? 0f : num2);
		TweenAlpha.Begin(description.gameObject, duration, (!show) ? 0f : 1f);
		TweenAlpha.Begin(timeIcon.gameObject, duration, (!show) ? 0f : 1f);
		TweenAlpha.Begin(timeLabel.gameObject, duration, (!show) ? 0f : 1f);
		TweenAlpha.Begin(timeCounter.counterLabel.gameObject, duration, (!show) ? 0f : 1f);
		TweenAlpha.Begin(bottomButtonLabel.gameObject, duration, (!show) ? 0f : 1f);
		if (show)
		{
			AnimatePoint(index);
		}
		else
		{
			AnimatePoints();
		}
	}

	private void InstaAnimatePoints(int index)
	{
		for (int i = 0; i < mOffers.Length; i++)
		{
			TweenColor component = mPoints[i].gameObject.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			mPoints[i].color = ((i != index) ? Colours.grayMax : Colours.goldAssignment);
		}
	}

	public void AnimatePoints()
	{
		for (int i = 0; i < mOffers.Length; i++)
		{
			TweenColor.Begin(mPoints[i].gameObject, 0.2f, Colours.grayMax);
		}
	}

	public void AnimatePoint(int index)
	{
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (i == index)
			{
				TweenColor.Begin(mPoints[i].gameObject, 0.2f, Colours.goldAssignment);
			}
		}
	}

	private void ShowPictureForOffer(int index = -1)
	{
		if (mOffers.Length == 0)
		{
			texture.gameObject.SetActive(value: false);
			return;
		}
		int num = mIndex;
		mIndex = ((index != -1) ? index : GetActualIndex());
		int num2 = mIndex;
		if (num != num2)
		{
			HidePicture();
		}
		string urlBig = mOffers[mIndex].urlBig;
		if (!texture.gameObject.activeSelf)
		{
			DestroyTempTexture();
			tempTexture = OfferManager.LoadImage(small: false, mOffers[mIndex].id, Localization.instance.currentLanguage);
			if (tempTexture == null)
			{
				HTTPRequest hTTPRequest = new HTTPRequest(new Uri(urlBig), OnPictureDownload);
				hTTPRequest.Send();
			}
			else
			{
				SetupTexture(tempTexture);
			}
		}
	}

	private void HidePicture()
	{
		texture.gameObject.SetActive(value: false);
		DestroyTempTexture();
		UnityEngine.Object.Destroy(texture.mainTexture);
		texture.transform.parent = draggablePanel.transform;
	}

	private int GetActualIndex()
	{
		if (mOffers.Length == 0)
		{
			return 0;
		}
		int num = -1;
		float x = draggablePanel.transform.localPosition.x;
		string text = $"GetActualIndex()\nCurPosX: {x}";
		for (int i = 0; i < mOffers.Length; i++)
		{
			float num2 = (0f - mRecordWidth) * (float)i;
			text += $"\ni: {i} center: {num2}";
			if (Mathf.Abs(num2 - x) < mRecordWidth / 2f + 1f)
			{
				num = i;
				text += $"\nchosen index: {num}";
				break;
			}
		}
		if (num == -1)
		{
			num = mIndex;
			text += $"\nnot chosen, setting index: {mIndex}";
		}
		Debug.Log(text);
		return Mathf.Clamp(num, 0, mOffers.Length - 1);
	}

	private void OnPictureDownload(HTTPRequest request, HTTPResponse response)
	{
		if (response == null)
		{
			Debug.LogErrorFormat("Picture download error: {0}", request.Exception);
			return;
		}
		for (int i = 0; i < mOffers.Length; i++)
		{
			if (request.CurrentUri.AbsoluteUri == mOffers[i].urlBig)
			{
				OfferManager.SaveImage(small: false, mOffers[i].id, Localization.instance.currentLanguage, response.DataAsTexture2D);
				break;
			}
		}
		if (!(request.CurrentUri.AbsoluteUri != mOffers[mIndex].urlBig))
		{
			SetupTexture(response.DataAsTexture2D);
		}
	}

	private void SetupTexture(Texture2D newTex)
	{
		texture.transform.parent = mRecords[mIndex].transform;
		texture.transform.localPosition = new Vector3(0f, 0f, -2f);
		texture.gameObject.SetActive(value: true);
		texture.mainTexture = newTex;
	}

	public void DragStart()
	{
		mDragging = true;
		springPanel.enabled = false;
		mStartVector = draggablePanel.transform.localPosition;
		mStartIndex = GetActualIndex();
	}

	public void DragDone()
	{
		mDragging = false;
		float x = draggablePanel.transform.localPosition.x;
		int value = ((!(mStartVector.x < x)) ? (mStartIndex + 1) : (mStartIndex - 1));
		int num = Mathf.Clamp(value, 0, mOffers.Length - 1);
		if (mStartIndex != num)
		{
			ShowPictureForOffer(num);
			AnimateLabels(mIndex, show: false);
			float x2 = (0f - mRecordWidth) * (float)mIndex;
			if (springPanel.enabled)
			{
				springPanel.enabled = false;
			}
			SpringPanel.Begin(springPanel.gameObject, new Vector3(x2, 0f, -1f), 13f);
			SpringPanel obj = springPanel;
			obj.onFinished = (SpringPanel.OnFinished)Delegate.Remove(obj.onFinished, new SpringPanel.OnFinished(CenteringDone));
			SpringPanel obj2 = springPanel;
			obj2.onFinished = (SpringPanel.OnFinished)Delegate.Combine(obj2.onFinished, new SpringPanel.OnFinished(CenteringDone));
		}
	}

	private void CenteringDone()
	{
		SpringPanel obj = springPanel;
		obj.onFinished = (SpringPanel.OnFinished)Delegate.Remove(obj.onFinished, new SpringPanel.OnFinished(CenteringDone));
		ShowPictureForOffer();
	}

	private void DestroyTempTexture()
	{
		if (tempTexture != null)
		{
			UnityEngine.Object.Destroy(tempTexture);
			tempTexture = null;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (!mDragging && !springPanel.enabled)
		{
			float num = (0f - mRecordWidth) * (float)mIndex;
			float num2 = Mathf.Abs(draggablePanel.transform.localPosition.x - num);
			if (num2 > 1f)
			{
				SpringPanel.Begin(springPanel.gameObject, new Vector3(num, 0f, -1f), 13f);
				SpringPanel obj = springPanel;
				obj.onFinished = (SpringPanel.OnFinished)Delegate.Remove(obj.onFinished, new SpringPanel.OnFinished(CenteringDone));
				SpringPanel obj2 = springPanel;
				obj2.onFinished = (SpringPanel.OnFinished)Delegate.Combine(obj2.onFinished, new SpringPanel.OnFinished(CenteringDone));
			}
		}
		if (bottomButton.enabled != (!mDragging && !springPanel.enabled))
		{
			bottomButton.enabled = !mDragging && !springPanel.enabled;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton);
	}
}
