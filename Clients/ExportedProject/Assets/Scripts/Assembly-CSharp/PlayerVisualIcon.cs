using UnityEngine;

public class PlayerVisualIcon : Core_BaseScript
{
	[Header("Core")]
	public UISprite background;

	public UISprite highlight;

	public UISprite icon;

	public UISprite powerBandIcon;

	[Header("-Packs")]
	public GameObject packs;

	[Header("-Parts")]
	public UILabel partsProgress;

	public GameObject partsPart;

	public UISprite partsBackground;

	public UILabel partsRarity;

	public UISprite partsLocked;

	[Header("-Arena")]
	public GameObject arenaPart;

	public UISprite arenaLocked;

	[Header("-Equiped")]
	public UISprite equipedIcon;

	[Header("---Locked")]
	public GameObject locked;

	public UILabel lockedRank;

	[Header("---Not Bought")]
	public GameObject notBought;

	public UISprite buyGoldIcon;

	public UISprite buyWbIcon;

	[Header("---Power Band Info")]
	public GameObject powerBandInfo;

	public UILabel powerBandValue;

	public UISprite powerBandMiniIcon;

	[Header("---Rented")]
	public UILabel rentedLabel;

	[Header("-Sale")]
	public GameObject salePart;

	[Header("-Notification")]
	public GameObject notification;

	private PlayerVisual mVisual;

	public PlayerVisual visual => mVisual;

	public void Initialize(PlayerVisual visual)
	{
		mVisual = visual;
		bool purchasableInShop = visual.purchasableInShop;
		bool isFromArena = visual.isFromArena;
		int num = 2;
		if (purchasableInShop)
		{
			num = ((visual.numberOfPartsMax > 0) ? 3 : 0);
		}
		else if (isFromArena)
		{
			num = 1;
		}
		int num2 = 2;
		if (visual.isBought)
		{
			num2 = 0;
		}
		else if (visual.numberOfParts > 0)
		{
			num2 = 1;
		}
		base.gameObject.name = $"{num} {num2} {(int)visual.rarity} {visual.id}";
		powerBandIcon.gameObject.SetActive(value: false);
		locked.SetActive(value: false);
		notBought.SetActive(value: false);
		rentedLabel.gameObject.SetActive(value: false);
		powerBandInfo.SetActive(value: false);
		arenaPart.SetActive(value: false);
		icon.gameObject.SetActive(value: true);
		icon.spriteName = visual.icon;
		icon.MakePixelPerfect();
		if (icon.transform.localScale.y > 200f)
		{
			icon.transform.localPosition = icon.transform.localPosition.ReplaceY((icon.transform.localScale.y - 200f) / 2f);
		}
		partsProgress.color = GameVariables.rarityColours[visual.rarity];
		partsBackground.color = partsProgress.color.ReplaceA(0.5f);
		partsRarity.text = ((!visual.isDefault || visual.owner.categoryNumber <= 0) ? visual.rarityName : string.Empty);
		MiscTools.SetUILabelRescale(partsRarity, 30f, 20f, 212);
		SetHighlight(isSelected: false);
		SetEquipped();
		InitGuiValuesGraphics();
	}

	public void InitGuiValuesGraphics()
	{
		UpdateGraphics();
	}

	private void Update()
	{
		if (visual != null && visual.isFromArena && !arenaLocked.gameObject.activeSelf)
		{
			arenaLocked.gameObject.SetActive(!visual.isBought);
		}
	}

	public void SetHighlight(bool isSelected)
	{
		highlight.gameObject.SetActive(isSelected);
	}

	internal void SetEquipped()
	{
		bool isEquipped = mVisual.isEquipped;
		background.color = (isEquipped ? Colours.blueEquipped : ((!mVisual.purchasableInShop && !mVisual.isFromArena) ? Color.yellow : Color.white));
		equipedIcon.alpha = ((!isEquipped) ? 0f : 1f);
	}

	internal void ShowHideNotification()
	{
		notification.SetActive(Singleton<NotificationManager>.instance.NotificationForVisual(mVisual));
	}

	internal void UpdateGraphics()
	{
		bool isBought = mVisual.isBought;
		bool purchasableInShop = mVisual.purchasableInShop;
		bool isFromArena = mVisual.isFromArena;
		bool flag = !isBought && mVisual.numberOfParts > 0;
		bool flag2 = mVisual.isDefault && mVisual.owner.categoryNumber > 0;
		partsPart.SetActive(purchasableInShop && !flag2);
		partsLocked.gameObject.SetActive(!isBought);
		partsRarity.transform.localPosition = partsRarity.transform.localPosition.ReplaceX((!isBought) ? 24f : 0f);
		partsProgress.gameObject.SetActive(flag);
		if (flag)
		{
			partsProgress.text = $"{visual.numberOfParts}{Colours.stringGrayParts}/{Colours.stringWhite}{visual.numberOfPartsMax}";
		}
		packs.SetActive(!isBought && !purchasableInShop && !isFromArena);
		ShowHideNotification();
		SetSale();
		arenaPart.SetActive(isFromArena);
		arenaLocked.gameObject.SetActive(!isBought);
	}

	public void SetSale()
	{
		salePart.SetActive(value: false);
	}

	private void OnClick()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<CamosScreen>.instance.Select(this);
		ShowHideNotification();
	}
}
