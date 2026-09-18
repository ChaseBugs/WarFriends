using System;
using UnityEngine;

public class LootboxButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool isBig;

	[Header("Sale Part")]
	public GameObject salePart;

	public UILabel saleLabel;

	[Header("Labels")]
	public UILabel amountLabel;

	[Header("Bottom Part")]
	public UITable priceTable;

	public UILabel priceLabel;

	[Header("Overlay")]
	public GameObject purchaseProtectionOverlay;

	public GameObject purchaseWaiting;

	[Header("-Sale")]
	public GameObject lootboxSalePart;

	public UILabel lootboxSaleLabel;

	public WinStreakCounter lootboxSaleTimeCounter;

	private InappScreen.InappDefinition mLootboxDefinition;

	private int mDiscount;

	public string id => (mLootboxDefinition == null) ? string.Empty : mLootboxDefinition.id;

	public int gold
	{
		get
		{
			if (mLootboxDefinition == null)
			{
				return 0;
			}
			return MiscTools.RoundToInt(mLootboxDefinition.price) * (100 - mDiscount) / 100;
		}
	}

	public int discount => mDiscount;

	public void InitControls()
	{
		priceTable.onReposition = delegate
		{
			float val = 0f - priceTable.padding.x - (priceLabel.transform.parent.transform.localPosition.x - priceTable.padding.x) / 2f;
			priceTable.transform.localPosition = priceTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void Initialize(InappScreen.InappDefinition lootboxDefinition)
	{
		mLootboxDefinition = lootboxDefinition;
		amountLabel.text = MiscTools.FormatBigNumber(mLootboxDefinition.amount);
		SetSaleAndPrize();
		InitializePurchaseProtection();
	}

	public void SetSaleAndPrize()
	{
		int sale = mLootboxDefinition.sale;
		int num = (mDiscount = Singleton<OfferManager>.instance.DiscountedLootbox());
		bool flag = sale > 0;
		bool flag2 = num > 0;
		if (flag)
		{
			saleLabel.text = Localization.LocalizeFormat((!isBig) ? "ID_FREEPERCENTLINE" : "ID_FREEPERCENT", sale);
			if (isBig)
			{
				MiscTools.SetUILabelRescale(saleLabel, 47f, 24f, 250);
			}
			else
			{
				MiscTools.SetUILabelRescale(saleLabel, 25f, 20f, 150);
			}
		}
		priceLabel.text = MiscTools.FormatBigNumber(gold);
		priceTable.repositionNow = true;
		salePart.SetActive(flag);
		lootboxSalePart.SetActive(flag2);
		if (flag2)
		{
			lootboxSaleLabel.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			lootboxSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedLootboxEndtime(), upperCaseCountdown: true);
			WinStreakCounter winStreakCounter = lootboxSaleTimeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetSaleAndPrize));
			WinStreakCounter winStreakCounter2 = lootboxSaleTimeCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SetSaleAndPrize));
		}
		else
		{
			lootboxSaleTimeCounter.StopCountingTo();
			WinStreakCounter winStreakCounter3 = lootboxSaleTimeCounter;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SetSaleAndPrize));
		}
	}

	public void InitializePurchaseProtection()
	{
		purchaseProtectionOverlay.SetActive(Singleton<PurchaseProtection>.instance.IsAnyLootboxPurchasing());
		purchaseWaiting.SetActive(Singleton<PurchaseProtection>.instance.IsLootboxPurchasing(id));
	}
}
