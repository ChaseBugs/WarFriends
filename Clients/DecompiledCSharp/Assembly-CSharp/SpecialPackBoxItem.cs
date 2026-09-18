using UnityEngine;

public class SpecialPackBoxItem : Core_BaseScript
{
	private class PositionsAndSizes
	{
		public Vector3 boxPosition;

		public Vector3 backgroundScale;

		public Vector3 iconMoneyPosition;

		public Vector3 iconGoldScale;

		public Vector3 iconWBScale;

		public Vector3 iconVIPPosition;

		public Vector3 iconVIPScale;

		public Vector3 iconVisualPosition;

		public int iconVisualSpace;

		public int iconCamoSpace;

		public Vector3 iconPowerBandPosition;

		public int iconPowerBandSpace;

		public PositionsAndSizes(Vector3 boxPos, Vector3 bgScale, Vector3 iconMoneyPos, Vector3 iconGoldS, Vector3 iconWbS, Vector3 iconVIPPos, Vector3 iconVIPS, Vector3 iconVisualPos, int visualSpace, int camoSpace, Vector3 iconPowerBandPos, int powerBandSpace)
		{
			boxPosition = boxPos;
			backgroundScale = bgScale;
			iconMoneyPosition = iconMoneyPos;
			iconGoldScale = iconGoldS;
			iconWBScale = iconWbS;
			iconVIPPosition = iconVIPPos;
			iconVIPScale = iconVIPS;
			iconVisualPosition = iconVisualPos;
			iconVisualSpace = visualSpace;
			iconCamoSpace = camoSpace;
			iconPowerBandPosition = iconPowerBandPos;
			iconPowerBandSpace = powerBandSpace;
		}
	}

	[Header("Core")]
	public UIPanel[] allPanels;

	public UISprite background;

	[Header("-Labels")]
	public UILabel rightLabel;

	public GameObject bottomPart;

	public UISprite bottomBackground;

	public UILabel bottomLabel;

	[Header("-Free")]
	public GameObject freeSticker;

	[Header("-Icon (Gold, WB, VIP, Visual, PowerBand)")]
	public UISprite icon;

	[Header("-Power Band")]
	public GameObject powerBandPart;

	public UISprite powerBandMiniIcon;

	public UILabel powerBandValue;

	[Header("-Warcards")]
	public UIGrid warcardsGrid;

	public GameObject[] warcards;

	public UISprite[] warcardsBackgrounds;

	public UISprite[] warcardsQuestion;

	[Header("-Cardpacks")]
	public UIGrid cardpacksGrid;

	public GameObject[] cardpacks;

	public UISprite[] cardpacksBackgrounds;

	public UISprite[] cardpacksFrontWarcards;

	public UISprite[] cardpacksBackWarcards;

	[Header("-Atlas And Settings")]
	public UIAtlas menuMainAtlas;

	public UIAtlas visualAtlas;

	public UIAtlas commonAtlas;

	public UIAtlas unitAndWeaponAtlas;

	public bool isDynamicFont;

	private static PositionsAndSizes[][] mPositionsAndSizes = new PositionsAndSizes[5][]
	{
		new PositionsAndSizes[2]
		{
			new PositionsAndSizes(new Vector3(0f, 138f, 0f), new Vector3(736f, 260f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 80, 30, new Vector3(-232f, 0f, -0.5f), 90),
			new PositionsAndSizes(new Vector3(0f, -136f, 0f), new Vector3(736f, 260f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 80, 30, new Vector3(-232f, 0f, -0.5f), 90)
		},
		new PositionsAndSizes[3]
		{
			new PositionsAndSizes(new Vector3(0f, 179f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new PositionsAndSizes(new Vector3(0f, 1f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new PositionsAndSizes(new Vector3(0f, -177f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30)
		},
		new PositionsAndSizes[4]
		{
			new PositionsAndSizes(new Vector3(-186f, 138f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new PositionsAndSizes(new Vector3(186f, 138f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new PositionsAndSizes(new Vector3(-186f, -136f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new PositionsAndSizes(new Vector3(186f, -136f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120)
		},
		new PositionsAndSizes[5]
		{
			new PositionsAndSizes(new Vector3(0f, 179f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new PositionsAndSizes(new Vector3(-186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(-186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60)
		},
		new PositionsAndSizes[6]
		{
			new PositionsAndSizes(new Vector3(-186f, 179f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(186f, 179f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(-186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(-186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new PositionsAndSizes(new Vector3(186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60)
		}
	};

	public void Initialize(int order, int allBoxes, SpecialPackContent.Content content)
	{
		if (allBoxes < 2 || 6 < allBoxes)
		{
			Debug.LogError("WRONG NUMBER OF ALL BOXES " + allBoxes);
			allBoxes = Mathf.Clamp(allBoxes, 2, 6);
		}
		if (order < 1 || allBoxes < order)
		{
			Debug.LogError("WRONG NUMBER OF ORDER " + order + " BOXES " + allBoxes);
			order = Mathf.Clamp(order, 1, allBoxes);
		}
		int num = (int)mPositionsAndSizes[allBoxes - 2][order - 1].backgroundScale.x;
		int height = (int)mPositionsAndSizes[allBoxes - 2][order - 1].backgroundScale.y;
		int num2;
		switch (allBoxes)
		{
		case 5:
			num2 = ((order == 1) ? 1 : 0);
			break;
		default:
			num2 = 0;
			break;
		case 2:
		case 3:
			num2 = 1;
			break;
		}
		bool flag = (byte)num2 != 0;
		bool flag2 = false;
		bool flag3 = allBoxes == 2 || allBoxes == 4;
		base.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].boxPosition;
		background.transform.localScale = mPositionsAndSizes[allBoxes - 2][order - 1].backgroundScale;
		freeSticker.transform.localPosition = new Vector3(background.transform.localScale.x / 2f, background.transform.localScale.y / 2f, freeSticker.transform.localPosition.z);
		freeSticker.SetActive(content.type == SpecialPackContent.ContentType.Cardpack || content.type == SpecialPackContent.ContentType.Warcard || content.type == SpecialPackContent.ContentType.VIP || content.type == SpecialPackContent.ContentType.PowerBand);
		rightLabel.gameObject.SetActive(flag);
		bottomPart.SetActive(!flag);
		bottomPart.transform.localPosition = bottomPart.transform.localPosition.ReplaceY((!flag3) ? (-59f) : (-107f));
		powerBandPart.transform.localPosition = ((!flag) ? new Vector3(0f, 22f, 0f) : new Vector3(-186f, 0f, 0f));
		bottomBackground.transform.localScale = bottomBackground.transform.localScale.ReplaceX(num);
		icon.gameObject.SetActive(content.type == SpecialPackContent.ContentType.Warbucks || content.type == SpecialPackContent.ContentType.Gold || content.type == SpecialPackContent.ContentType.VIP || content.type == SpecialPackContent.ContentType.PowerBand || content.type == SpecialPackContent.ContentType.Customization || content.type == SpecialPackContent.ContentType.Unit || content.type == SpecialPackContent.ContentType.Weapon);
		warcardsGrid.gameObject.SetActive(content.type == SpecialPackContent.ContentType.Warcard);
		cardpacksGrid.gameObject.SetActive(content.type == SpecialPackContent.ContentType.Cardpack);
		powerBandPart.SetActive(content.type == SpecialPackContent.ContentType.PowerBand);
		switch (content.type)
		{
		case SpecialPackContent.ContentType.Warbucks:
			icon.atlas = menuMainAtlas;
			icon.spriteName = "menu-warbucks";
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconMoneyPosition;
			icon.transform.localScale = mPositionsAndSizes[allBoxes - 2][order - 1].iconWBScale;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			rightLabel.text = MiscTools.FormatBigNumber(content.amount);
			rightLabel.color = Colours.greenWarbucks;
			flag2 = true;
			bottomLabel.text = string.Format("{0} {1}", MiscTools.FormatBigNumber(content.amount), Localization.Localize("ID_WARBUCKS"));
			break;
		case SpecialPackContent.ContentType.Gold:
			icon.atlas = menuMainAtlas;
			icon.spriteName = "menu-gold";
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconMoneyPosition;
			icon.transform.localScale = mPositionsAndSizes[allBoxes - 2][order - 1].iconGoldScale;
			icon.transform.localRotation = Quaternion.AngleAxis(-180f, Vector3.up);
			rightLabel.text = MiscTools.FormatBigNumber(content.amount);
			rightLabel.color = Colours.goldOld;
			flag2 = true;
			bottomLabel.text = string.Format("{0} {1}", MiscTools.FormatBigNumber(content.amount), Localization.Localize("ID_GOLD"));
			break;
		case SpecialPackContent.ContentType.Warcard:
			SetUpWarcards(flag, content, num, flag3);
			break;
		case SpecialPackContent.ContentType.Cardpack:
			SetUpCardpacks(flag, content, num, flag3);
			break;
		case SpecialPackContent.ContentType.VIP:
			icon.atlas = menuMainAtlas;
			icon.spriteName = "menu-hub-multiplayer-vipico";
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconVIPPosition;
			icon.transform.localScale = mPositionsAndSizes[allBoxes - 2][order - 1].iconVIPScale;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			rightLabel.text = MiscTools.PrintableTimeVipConvert(content.amount);
			rightLabel.color = Colours.whiteVIP;
			flag2 = true;
			bottomLabel.text = string.Format("{0} {1}", MiscTools.PrintableTimeVipConvert(content.amount), Localization.Localize("ID_VIPTIME"));
			break;
		case SpecialPackContent.ContentType.PowerBand:
			icon.atlas = commonAtlas;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconPowerBandPosition;
			SetUpPowerBand(flag, content, num, height, mPositionsAndSizes[allBoxes - 2][order - 1].iconPowerBandSpace);
			break;
		case SpecialPackContent.ContentType.Customization:
			icon.atlas = visualAtlas;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconVisualPosition;
			SetUpCustomization(flag, content, num, height, mPositionsAndSizes[allBoxes - 2][order - 1].iconCamoSpace, mPositionsAndSizes[allBoxes - 2][order - 1].iconVisualSpace);
			break;
		case SpecialPackContent.ContentType.Unit:
			icon.atlas = unitAndWeaponAtlas;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconVisualPosition;
			SetUpUnit(flag, content, num, height, 20);
			break;
		case SpecialPackContent.ContentType.Weapon:
			icon.atlas = unitAndWeaponAtlas;
			icon.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			icon.transform.localPosition = mPositionsAndSizes[allBoxes - 2][order - 1].iconVisualPosition;
			SetUpWeapon(flag, content, num, height, 40);
			break;
		}
		if (flag)
		{
			if (rightLabel.text.Length > 0)
			{
				int width = Mathf.FloorToInt((!flag2) ? ((float)num / 2f - 20f) : ((float)num / 2f + 30f));
				float x = ((!flag2) ? 4f : (-46f));
				float defaultHeight = ((!isDynamicFont) ? 100f : 83f);
				float minHeight = ((!isDynamicFont) ? 21f : 17f);
				rightLabel.transform.localPosition = new Vector3(x, rightLabel.transform.localPosition.y, rightLabel.transform.localPosition.z);
				MiscTools.SetUILabelRescale(rightLabel, defaultHeight, minHeight, width);
			}
		}
		else
		{
			float defaultHeight2 = ((!isDynamicFont) ? 33f : 27f);
			float minHeight2 = ((!isDynamicFont) ? 21f : 17f);
			MiscTools.SetUILabelRescale(bottomLabel, defaultHeight2, minHeight2, Mathf.FloorToInt((float)num - 20f));
		}
	}

	public void OverrideTweenPanels(float duration, float toAlpha)
	{
		UIPanel[] array = allPanels;
		foreach (UIPanel uIPanel in array)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, duration, toAlpha);
			}
		}
	}

	public void OverrideTweenPanels(float duration, float fromAlpha, float toAlpha)
	{
		UIPanel[] array = allPanels;
		foreach (UIPanel uIPanel in array)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = fromAlpha;
				TweenAlpha.Begin(uIPanel.gameObject, duration, fromAlpha, toAlpha);
			}
		}
	}

	private void SetUpWarcards(bool isWideBox, SpecialPackContent.Content content, int width, bool isBigHeightBox)
	{
		int num = ((!isBigHeightBox) ? 110 : 144);
		float y = ((!isWideBox) ? 20f : 0f);
		float num2 = Mathf.Clamp(((float)width - (40f + (float)num)) / Mathf.Max(1f, content.amount - 1), 1f, (float)num / 4f);
		float num3 = ((content.amount % 2 != 1) ? (((float)(content.amount / 2) - 0.5f) * num2) : (Mathf.Floor(content.amount / 2) * num2));
		if (isWideBox)
		{
			rightLabel.text = string.Empty;
			rightLabel.color = Color.white;
		}
		else if (content.warcardType == CardManager.CardType.Bronze)
		{
			bottomLabel.text = ((content.amount != 1) ? string.Format("{0} {1}", MiscTools.FormatBigNumber(content.amount), Localization.Localize("ID_BRONZECARDS")) : Localization.Localize("ID_BRONZECARD"));
		}
		else if (content.warcardType == CardManager.CardType.Silver)
		{
			bottomLabel.text = ((content.amount != 1) ? string.Format("{0} {1}", MiscTools.FormatBigNumber(content.amount), Localization.Localize("ID_SILVERCARDS")) : Localization.Localize("ID_SILVERCARD"));
		}
		else if (content.warcardType == CardManager.CardType.Gold)
		{
			bottomLabel.text = ((content.amount != 1) ? string.Format("{0} {1}", MiscTools.FormatBigNumber(content.amount), Localization.Localize("ID_GOLDCARDS")) : Localization.Localize("ID_GOLDCARD"));
		}
		else
		{
			bottomLabel.text = string.Empty;
		}
		warcardsGrid.cellWidth = num2;
		warcardsGrid.repositionNow = true;
		warcardsGrid.transform.localPosition = new Vector3(0f - num3, y, -1f);
		for (int i = 0; i < warcards.Length; i++)
		{
			warcards[i].SetActive(content.amount > i);
			if (content.amount > i)
			{
				warcardsBackgrounds[i].spriteName = Card.CardBackground(content.warcardType);
				warcardsQuestion[i].color = ((content.warcardType == CardManager.CardType.Gold) ? Colours.questionGold : ((content.warcardType != CardManager.CardType.Silver) ? Colours.questionBronze : Colours.questionSilver));
				warcardsBackgrounds[i].transform.localScale = ((!isBigHeightBox) ? new Vector3(90f, 109f, 1f) : new Vector3(117f, 142f, 1f));
				warcardsQuestion[i].transform.localScale = ((!isBigHeightBox) ? new Vector3(39f, 59f, 1f) : new Vector3(51f, 77f, 1f));
			}
		}
	}

	private void SetUpCardpacks(bool isWideBox, SpecialPackContent.Content content, int width, bool isBigHeightBox)
	{
		int num = ((!isBigHeightBox) ? 38 : 49);
		int num2 = ((!isBigHeightBox) ? 89 : 116);
		float y = (isWideBox ? 0f : ((!isBigHeightBox) ? 6f : 18f));
		float num3 = Mathf.Clamp(((float)width - (40f + (float)num + (float)num2)) / Mathf.Max(1f, content.amount - 1), 1f, (float)(num2 + num) + 20f);
		float num4 = ((content.amount % 2 != 1) ? (((float)(content.amount / 2) - 0.5f) * num3) : (Mathf.Floor(content.amount / 2) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = CardManager.CardType.Bronze;
		CardManager.CardType cardRarity2 = CardManager.CardType.Silver;
		string text = string.Empty;
		if (content.cardpackType == CardPack.Bronze)
		{
			text = Localization.Localize((content.amount != 1) ? "ID_BRONZEPACKS" : "ID_BRONZEPACK");
			spriteName = "menu-cards-bronzepack";
			cardRarity = CardManager.CardType.Bronze;
			cardRarity2 = CardManager.CardType.Silver;
		}
		else if (content.cardpackType == CardPack.Silver)
		{
			text = Localization.Localize((content.amount != 1) ? "ID_SILVERPACKS" : "ID_SILVERPACK");
			spriteName = "menu-cards-silverpack";
			cardRarity = CardManager.CardType.Silver;
			cardRarity2 = CardManager.CardType.Bronze;
		}
		else if (content.cardpackType == CardPack.Gold)
		{
			text = Localization.Localize((content.amount != 1) ? "ID_GOLDPACKS" : "ID_GOLDPACK");
			spriteName = "menu-cards-goldpack";
			cardRarity = CardManager.CardType.Gold;
			cardRarity2 = CardManager.CardType.Silver;
		}
		if (isWideBox)
		{
			rightLabel.text = string.Empty;
			rightLabel.color = Color.white;
		}
		else
		{
			bottomLabel.text = ((content.amount != 1) ? $"{MiscTools.FormatBigNumber(content.amount)} {text}" : text);
		}
		cardpacksGrid.cellWidth = num3;
		cardpacksGrid.repositionNow = true;
		cardpacksGrid.transform.localPosition = new Vector3(0f - num4 + (float)num / 3f, y, cardpacksGrid.transform.localPosition.z);
		for (int i = 0; i < cardpacks.Length; i++)
		{
			cardpacks[i].SetActive(content.amount > i);
			if (content.amount > i)
			{
				cardpacksBackgrounds[i].spriteName = spriteName;
				cardpacksFrontWarcards[i].spriteName = Card.CardBackground(cardRarity);
				cardpacksBackWarcards[i].spriteName = Card.CardBackground(cardRarity2);
				cardpacksBackgrounds[i].transform.localScale = ((!isBigHeightBox) ? new Vector3(89f, 130f, 1f) : new Vector3(116f, 169f, 1f));
				cardpacksFrontWarcards[i].transform.localPosition = ((!isBigHeightBox) ? new Vector3(-16f, 5f, 0f) : new Vector3(-16f, 5f, 0f));
				cardpacksFrontWarcards[i].transform.localScale = ((!isBigHeightBox) ? new Vector3(83f, 100f, 1f) : new Vector3(108f, 130f, 1f));
				cardpacksBackWarcards[i].transform.localPosition = ((!isBigHeightBox) ? new Vector3(-34f, 3f, 0f) : new Vector3(-44f, 3f, 0f));
				cardpacksBackWarcards[i].transform.localScale = ((!isBigHeightBox) ? new Vector3(74f, 90f, 1f) : new Vector3(96f, 117f, 1f));
			}
		}
	}

	private void SetUpPowerBand(bool isWideBox, SpecialPackContent.Content content, int width, int height, int powerBandSpace)
	{
		bottomLabel.text = Localization.LocalizeFormat("ID_POWERBANDBOX", MiscTools.PrintableTimeVipConvert(content.amount));
		rightLabel.text = MiscTools.PrintableTimeVipConvert(content.amount);
		rightLabel.color = Color.white;
		PlayerVisual visual = content.visual;
		icon.spriteName = visual.icon;
		icon.MakePixelPerfect();
		float num = ((!isWideBox) ? ((float)(width - powerBandSpace)) : ((float)width / 2f - (float)powerBandSpace));
		float multiplier = Mathf.Min(num / icon.transform.localScale.x, (float)(height - powerBandSpace) / icon.transform.localScale.y);
		icon.transform.localPosition = icon.transform.localPosition.ReplaceZ(-0.5f);
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
		powerBandValue.text = visual.decalValueString;
		float x = powerBandValue.transform.localPosition.x + powerBandValue.relativeSize.x * powerBandValue.transform.localScale.x + 8f;
		powerBandMiniIcon.spriteName = visual.decalMiniIcon;
		powerBandMiniIcon.MakePixelPerfect();
		powerBandMiniIcon.color = visual.decalMiniIconColor;
		powerBandMiniIcon.transform.localPosition = new Vector3(x, powerBandValue.transform.localPosition.y, -0.5f);
	}

	private void SetUpCustomization(bool isWideBox, SpecialPackContent.Content content, int width, int height, int camosSpace, int visualSpace)
	{
		PlayerVisual visual = content.visual;
		bool flag = visual.owner.categoryNumber == 0;
		string text = ((!flag) ? visual.name.ToUpper() : Localization.LocalizeFormat("ID_NAMECHARACTER", visual.name.ToUpper()));
		float num = ((!flag) ? visualSpace : camosSpace);
		float num2 = ((!isWideBox) ? ((float)width - 20f - num) : ((float)width / 2f - num));
		float num3 = ((!flag) ? ((float)height - 20f - num) : ((float)height - num));
		bottomLabel.text = text;
		rightLabel.text = text;
		rightLabel.color = Color.white;
		icon.spriteName = visual.icon;
		icon.MakePixelPerfect();
		float num4 = Mathf.Min(num2 / icon.transform.localScale.x, num3 / icon.transform.localScale.y);
		icon.transform.localScale = new Vector3(num4 * icon.transform.localScale.x, num4 * icon.transform.localScale.y, 1f);
		float val = (flag ? (0f - (float)height / 2f + icon.transform.localScale.y / 2f) : ((!isWideBox) ? 20f : 0f));
		icon.transform.localPosition = icon.transform.localPosition.ReplaceY(val);
	}

	private void SetUpUnit(bool isWideBox, SpecialPackContent.Content content, int width, int height, int unitSpace)
	{
		LevelBehaviour unit = content.unit;
		bottomLabel.text = unit.unitName.ToUpper();
		rightLabel.text = unit.unitName.ToUpper();
		rightLabel.color = Color.white;
		icon.spriteName = unit.upgradeSlots.iconName;
		icon.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(width - unitSpace) / icon.transform.localScale.x, (float)(height + unitSpace) / icon.transform.localScale.y);
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
			float val = (icon.transform.localScale.y - (float)height) / 2f;
			icon.transform.localPosition = icon.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(width - unitSpace) / icon.transform.localScale.x, (float)(height - unitSpace) / icon.transform.localScale.y);
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier2);
			icon.transform.localPosition = icon.transform.localPosition.ReplaceY((float)unitSpace / 3f);
		}
	}

	private void SetUpWeapon(bool isWideBox, SpecialPackContent.Content content, int width, int height, int weaponSpace)
	{
		WeaponLevelsSetup weapon = content.weapon;
		if (weapon == null)
		{
			icon.spriteName = "whiteRectangle";
			icon.MakePixelPerfect();
			bottomLabel.text = "NULL";
			rightLabel.text = "NULL";
			rightLabel.color = Color.white;
		}
		else
		{
			bottomLabel.text = weapon.weaponName.ToUpper();
			rightLabel.text = weapon.weaponName.ToUpper();
			rightLabel.color = Color.white;
			icon.spriteName = weapon.playerWeapon.iconName;
			icon.MakePixelPerfect();
			float multiplier = Mathf.Min((float)(width - weaponSpace) / icon.transform.localScale.x, (float)(height - weaponSpace) / icon.transform.localScale.y);
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
			icon.transform.localPosition = icon.transform.localPosition.ReplaceY((float)weaponSpace / 3f);
		}
	}

	public void AlterShownCustomization(int order, int allBoxes)
	{
		if (allBoxes < 2 || 6 < allBoxes)
		{
			Debug.LogError("WRONG NUMBER OF ALL BOXES " + allBoxes);
			allBoxes = Mathf.Clamp(allBoxes, 2, 6);
		}
		if (order < 1 || allBoxes < order)
		{
			Debug.LogError("WRONG NUMBER OF ORDER " + order + " BOXES " + allBoxes);
			order = Mathf.Clamp(order, 1, allBoxes);
		}
		int num = (int)mPositionsAndSizes[allBoxes - 2][order - 1].backgroundScale.x;
		int num2 = (int)mPositionsAndSizes[allBoxes - 2][order - 1].backgroundScale.y;
		int num3;
		switch (allBoxes)
		{
		case 5:
			num3 = ((order == 1) ? 1 : 0);
			break;
		default:
			num3 = 0;
			break;
		case 2:
		case 3:
			num3 = 1;
			break;
		}
		bool flag = (byte)num3 != 0;
		int iconVisualSpace = mPositionsAndSizes[allBoxes - 2][order - 1].iconVisualSpace;
		float num4 = iconVisualSpace;
		float num5 = ((!flag) ? ((float)num - 20f - num4) : ((float)num / 2f - num4));
		float num6 = (float)num2 - 20f;
		icon.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / icon.transform.localScale.x, num6 / icon.transform.localScale.y);
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
		icon.transform.localPosition = icon.transform.localPosition.ReplaceY(0f);
	}
}
