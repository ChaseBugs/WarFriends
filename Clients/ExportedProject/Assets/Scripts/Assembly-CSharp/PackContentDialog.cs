using System;
using UnityEngine;

public class PackContentDialog : GuiElementSingle<PackContentDialog>, IGuiDialog
{
	public enum Type
	{
		ValuePack,
		ElitePack
	}

	[Header("Top")]
	public GameObject backButton;

	public GameObject closeButton;

	public UILabel title;

	[Header("Elite Pack Hex")]
	public GameObject elitePackPart;

	public UIGrid elitePackTopGrid;

	public HexRecord[] elitePackTopHexes;

	public UIGrid elitePackCenterGrid;

	public HexPackRecord[] elitePackHexRecords;

	public ParticleSystem magentaParticles;

	[Header("Center")]
	public UIPositionSetter leftHeightSetter;

	public UIGrid contentGrid;

	public PackContentRecord[] records;

	public ParticleSystem goldParticles;

	[Header("Bottom")]
	public UIPositionSetter bottomHeightSetter;

	public UISprite bottomBackground;

	public UISprite eliteBottomBackground;

	public UILabel description;

	public GameObject timePart;

	public UILabel offerEndsLabel;

	public WinStreakCounter timeCounter;

	[Header("-Buy Button")]
	public GameObject buyButton;

	public UISprite buyBackground;

	public UILabel buyButtonLabel;

	public UILabel actualPrize;

	[Header("-Save Part")]
	public GameObject savePart;

	public UISprite compareBackground;

	public UISprite eliteRightBackground;

	public UILabel savePercent;

	public UILabel previousLabelName;

	public UILabel previousPrize;

	public StrikethroughPrize strikethrough;

	[Header("Atlas References")]
	public UIAtlas menuMainAtlas;

	public UIAtlas mainBigAtlas;

	public UIAtlas visualAtlas;

	[Header("Animation")]
	public float interval = 0.5f;

	public float duration = 0.3f;

	public float lowAlpha = 0.2f;

	public float highAlpha = 0.5f;

	public float lowBlackAlpha = 0.125f;

	public float highBlackAlpha = 0.5f;

	private bool mShownOffers;

	private bool mAfterGame;

	private int mAnimationIndex;

	private float mTime;

	private float mLastAnimationTime;

	private Type mCurrentType;

	public SpecialPackContent mCurrentPack;

	public void ShowDialog(SpecialPackContent packToShow, bool afterGame = false)
	{
		mCurrentPack = packToShow;
		mAfterGame = afterGame;
		if (mCurrentPack.packId == Singleton<GameVariables>.instance.PackId(CardPack.Value))
		{
			mCurrentType = Type.ValuePack;
		}
		else
		{
			mCurrentType = Type.ElitePack;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(buyButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BuyPack));
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += OnProductsLoaded;
		InitializeBottom();
		InitializeElitePackSizes();
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void BuyPack(GameObject go)
	{
		if (base.isFullyShowed)
		{
			string location = string.Empty;
			if (mAfterGame)
			{
				location = "Battle_End_Dialog";
			}
			else if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<MainScreen>.instance)
			{
				location = "Main_Menu_Offers_Bar";
			}
			else if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardMenuScreen>.instance)
			{
				location = "WarCards_Screen";
			}
			string packId = ((mCurrentPack != null) ? mCurrentPack.packId : Singleton<GameVariables>.instance.PackId(CardPack.Value));
			Singleton<BeanstalkServerManager>.instance.BuyPack(packId, location);
			if (GuiScreenSingle<CardMenuScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.SetStarterOrValuePack();
			}
			HideDialog();
		}
	}

	private void OnProductsLoaded()
	{
		if (isShowed)
		{
			if (mCurrentType == Type.ValuePack)
			{
				InitializeValuePack();
			}
			else
			{
				InitializeElitePack();
			}
		}
	}

	public override void InitGUIValues()
	{
		mAnimationIndex = 0;
		mTime = 0f;
		mLastAnimationTime = mTime - 1f;
		if (mCurrentType == Type.ValuePack)
		{
			InitializeValuePack();
		}
		else
		{
			InitializeElitePack();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mShownOffers = GuiScreenSingle<EndScreen>.instance.isShowed;
		if (mShownOffers)
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mShownOffers)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
	}

	private void InitializeValuePack()
	{
		contentGrid.gameObject.SetActive(value: true);
		goldParticles.gameObject.SetActive(value: true);
		elitePackPart.gameObject.SetActive(value: false);
		bottomBackground.gameObject.SetActive(value: true);
		eliteBottomBackground.gameObject.SetActive(value: false);
		eliteRightBackground.gameObject.SetActive(value: false);
		SetColors();
		SetSizes(5);
		title.text = Localization.Localize("ID_VALUEPACK");
		int num = 0;
		int seconds = 0;
		for (int i = 0; i < mCurrentPack.contentOfPack.Length; i++)
		{
			if (mCurrentPack.contentOfPack[i].type == SpecialPackContent.ContentType.Gold)
			{
				num = mCurrentPack.contentOfPack[i].amount;
			}
			if (mCurrentPack.contentOfPack[i].type == SpecialPackContent.ContentType.VIP)
			{
				seconds = mCurrentPack.contentOfPack[i].amount;
			}
		}
		records[0].InitializeTexts(Localization.Localize("ID_PERMANENTUNLOCK"), Localization.Localize("ID_EXTRAWARCARDSLOT"));
		records[0].InitializeIcon("menu-packs-cardslot-ico", mainBigAtlas, 300f, -1f);
		records[0].StopAnimation();
		records[0].ShowFree(showFree: false);
		records[1].InitializeTexts(Localization.Localize("ID_EXCLUSIVECHARACTER"), Localization.Localize("ID_ALIEN"));
		records[1].InitializeIcon("menu-camos-alien", visualAtlas, 266f, -2f);
		records[1].StopAnimation();
		records[1].ShowFree(showFree: false);
		records[2].InitializeTexts(Localization.Localize("ID_EXCLUSIVEHELMET"), Localization.Localize("ID_SKULL"));
		records[2].InitializeIcon("menu-helmets-reaper", visualAtlas, 260f, -2f);
		records[2].StopAnimation();
		records[2].ShowFree(showFree: false);
		records[3].InitializeTexts(Localization.Localize("ID_INSTANTRICHIES"), Localization.LocalizeFormat("ID_PACKXGOLD", MiscTools.FormatBigNumber(num)));
		records[3].InitializeIcon("menu-gold", menuMainAtlas, 184f, 0f, rotate: true);
		records[3].StopAnimation();
		records[3].ShowFree(showFree: true);
		records[4].InitializeTexts(Localization.Localize("ID_VIPBENEFIT"), Localization.LocalizeFormat("ID_TIMEOFVIP", MiscTools.PrintableTimeVipConvert(seconds)));
		records[4].InitializeIcon("menu-hub-multiplayer-vipico", menuMainAtlas, 232f, 0f);
		records[4].StopAnimation();
		records[4].ShowFree(showFree: true);
		goldParticles.Play();
		string value = Singleton<GameVariables>.instance.PriceOfPack(CardPack.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(CardPack.Value).Value2;
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Value);
		bool flag = num2 > 0f;
		description.text = Localization.Localize("ID_VALUEPACKDESCRIPTION");
		buyButtonLabel.text = Localization.Localize("ID_BUYVALUEPACK");
		MiscTools.SetUILabelRescale(buyButtonLabel, 57f, 20f, 600);
		actualPrize.text = value;
		description.transform.localPosition = description.transform.localPosition.ReplaceY(4f);
		savePart.transform.localPosition = savePart.transform.localPosition.ReplaceXY(-60f, -69f);
		buyButton.transform.localPosition = buyButton.transform.localPosition.ReplaceX(-584f);
		savePart.SetActive(flag);
		if (flag)
		{
			savePercent.text = Localization.LocalizeFormat("ID_SAVEPERCENTLINE", MiscTools.FormatFloatNumberAsPercentWithoutCharacter(num2));
			SetPreviousPrizeText(value2);
		}
		bool flag2 = mCurrentPack.finishAt > 0;
		timePart.SetActive(flag2);
		if (flag2)
		{
			WinStreakCounter winStreakCounter = timeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(TimeOut));
			WinStreakCounter winStreakCounter2 = timeCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(TimeOut));
			timeCounter.StartCountingTo(mCurrentPack.finishAt);
		}
	}

	private void InitializeElitePack()
	{
		contentGrid.gameObject.SetActive(value: false);
		goldParticles.gameObject.SetActive(value: false);
		elitePackPart.gameObject.SetActive(value: true);
		bottomBackground.gameObject.SetActive(value: false);
		eliteBottomBackground.gameObject.SetActive(value: true);
		eliteRightBackground.gameObject.SetActive(value: true);
		SetColors();
		title.text = mCurrentPack.name;
		WeaponLevelsSetup weapon = null;
		LevelBehaviour unit = null;
		int seconds = 0;
		int amount = 0;
		for (int i = 0; i < mCurrentPack.contentOfPack.Length; i++)
		{
			if (mCurrentPack.contentOfPack[i].unit != null)
			{
				unit = mCurrentPack.contentOfPack[i].unit;
			}
			if (mCurrentPack.contentOfPack[i].weapon != null)
			{
				weapon = mCurrentPack.contentOfPack[i].weapon;
			}
			if (mCurrentPack.contentOfPack[i].type == SpecialPackContent.ContentType.Gold)
			{
				amount = mCurrentPack.contentOfPack[i].amount;
			}
			if (mCurrentPack.contentOfPack[i].type == SpecialPackContent.ContentType.VIP)
			{
				seconds = mCurrentPack.contentOfPack[i].amount;
			}
		}
		elitePackHexRecords[0].InitializeUnit(unit);
		elitePackHexRecords[0].StopAnimation();
		elitePackHexRecords[1].InitializeWeapon(weapon);
		elitePackHexRecords[1].StopAnimation();
		elitePackHexRecords[2].InitializeVip(seconds);
		elitePackHexRecords[2].StopAnimation();
		elitePackHexRecords[3].InitializeGold(amount);
		elitePackHexRecords[3].StopAnimation();
		magentaParticles.Play();
		string currentPrize = mCurrentPack.currentPrize;
		string realPrize = mCurrentPack.realPrize;
		float sale = mCurrentPack.sale;
		bool flag = sale > 0f;
		bool flag2 = mCurrentPack.packId.StartsWith("veteranpack");
		description.text = Localization.Localize("ID_ELITEPACKDESCRIPTION");
		buyButtonLabel.text = Localization.Localize((!flag2) ? "ID_BUYELITEPACK" : "ID_BUYVETERANPACK");
		MiscTools.SetUILabelRescale(buyButtonLabel, 57f, 20f, 600);
		actualPrize.text = currentPrize;
		description.transform.localPosition = description.transform.localPosition.ReplaceY(42f);
		savePart.transform.localPosition = savePart.transform.localPosition.ReplaceXY(-37f, -81f);
		buyButton.transform.localPosition = buyButton.transform.localPosition.ReplaceX(-561f);
		savePart.SetActive(flag);
		if (flag)
		{
			savePercent.text = Localization.LocalizeFormat("ID_SAVEPERCENTLINE", MiscTools.FormatFloatNumberAsPercentWithoutCharacter(sale));
			SetPreviousPrizeText(realPrize);
		}
		bool flag3 = mCurrentPack.finishAt > 0;
		timePart.SetActive(flag3);
		if (flag3)
		{
			WinStreakCounter winStreakCounter = timeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(TimeOut));
			WinStreakCounter winStreakCounter2 = timeCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(TimeOut));
			timeCounter.StartCountingTo(mCurrentPack.finishAt);
		}
	}

	protected override void Update()
	{
		base.Update();
		if (mCurrentType == Type.ValuePack)
		{
			ValuePackAnimationUpdate();
		}
		else if (mCurrentType == Type.ElitePack)
		{
			ElitePackAnimationUpdate();
		}
	}

	private void ValuePackAnimationUpdate()
	{
		mTime += Time.deltaTime;
		if (mTime - mLastAnimationTime >= interval)
		{
			mLastAnimationTime = mTime;
			if (mAnimationIndex >= records.Length || !records[mAnimationIndex].gameObject.activeSelf)
			{
				mAnimationIndex = 0;
			}
			records[mAnimationIndex].StartAnimation();
			mAnimationIndex++;
		}
	}

	private void ElitePackAnimationUpdate()
	{
		mTime += Time.deltaTime;
		if (mTime - mLastAnimationTime >= interval)
		{
			mLastAnimationTime = mTime;
			if (mAnimationIndex >= elitePackHexRecords.Length)
			{
				mAnimationIndex = 0;
			}
			elitePackHexRecords[mAnimationIndex].StartAnimation();
			mAnimationIndex++;
		}
	}

	private void TimeOut()
	{
		WinStreakCounter winStreakCounter = timeCounter;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(TimeOut));
		timeCounter.counterLabel.text = Localization.Localize("ID_ENDED");
	}

	private void SetSizes(int count)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = activeWidth / (float)count;
		int num2 = count / 2;
		float val = ((count % 2 != 1) ? (((float)(-num2) + 0.5f) * num) : ((float)(-num2) * num));
		for (int i = 0; i < records.Length; i++)
		{
			bool isLast = i + 1 == count;
			records[i].gameObject.SetActive(i < count);
			records[i].InitializeSize(num, isLast);
		}
		contentGrid.cellWidth = num;
		contentGrid.transform.localPosition = contentGrid.transform.localPosition.ReplaceX(val);
		contentGrid.repositionNow = true;
	}

	private void InitializeBottom()
	{
		float num = 274f;
		float num2 = 300f;
		float num3 = 720f;
		float num4 = 850f;
		float num5 = 1.3333334f;
		float num6 = 1.7777778f;
		float num7 = Mathf.Clamp(UIRoot.list[0].activeWidth / (float)UIRoot.list[0].activeHeight, num5, num6);
		float num8 = (num7 - num6) / (num5 - num6);
		float val = num + num8 * (num2 - num);
		float num9 = num4 + num8 * (num3 - num4);
		bottomBackground.transform.localScale = bottomBackground.transform.localScale.ReplaceY(val);
		description.lineWidth = (int)num9;
		offerEndsLabel.text = Localization.Localize("ID_OFFERENDSIN");
		timeCounter.transform.localPosition = timeCounter.transform.localPosition.ReplaceX(offerEndsLabel.relativeSize.x * offerEndsLabel.transform.localScale.x + 18f);
	}

	private void InitializeElitePackSizes()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = 40f;
		float num2 = 14f;
		float num3 = (activeWidth - (2f * num + 3f * num2)) / 4f;
		int activeHeight = UIRoot.list[0].activeHeight;
		float num4 = (float)activeHeight / 2f;
		float computeHeight = leftHeightSetter.computeHeight;
		float num5 = 210f;
		float height = num4 - (computeHeight + 565f - num5 + 126f) + 1f;
		float num6 = computeHeight + num5;
		float num7 = 46f;
		float num8 = 174f;
		float num9 = 0f - num4 + bottomHeightSetter.computeHeight + num7 + num8 / 2f;
		float height2 = num6 - num9;
		for (int i = 0; i < elitePackTopHexes.Length; i++)
		{
			elitePackTopHexes[i].Initialize(num3, height);
		}
		elitePackTopGrid.cellWidth = num3 + num2;
		for (int j = 0; j < elitePackHexRecords.Length; j++)
		{
			elitePackHexRecords[j].InitializeSize(num3, height2);
		}
		elitePackCenterGrid.transform.localPosition = elitePackCenterGrid.transform.localPosition.ReplaceX(num + num3 / 2f);
		elitePackCenterGrid.cellWidth = num3 + num2;
	}

	private void SetColors()
	{
		title.color = ((mCurrentType != Type.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
		buyBackground.spriteName = ((mCurrentType != Type.ElitePack) ? "menu-valuepack-buybutton" : "menu-elitepack-buybutton");
		previousPrize.color = ((mCurrentType != Type.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
		eliteRightBackground.alpha = ((mCurrentType != Type.ElitePack) ? 1f : 0.375f);
		timeCounter.counterLabel.color = ((mCurrentType != Type.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
	}

	private void SetPreviousPrizeText(string previousPrizeString)
	{
		previousPrize.text = previousPrizeString;
		strikethrough.SetUpStrikeThrought();
		int num = (int)(previousPrize.relativeSize.x * previousPrize.transform.localScale.x);
		previousLabelName.text = Localization.Localize("ID_REGULARPRIZE");
		MiscTools.SetUILabelRescale(previousLabelName, 37f, 20f, 500 - num);
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
