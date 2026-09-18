using Google2u;
using UnityEngine;

public class VIPButton : Core_BaseScript
{
	[Header("Core")]
	public bool oneLinePercent = true;

	public GameObject savePart;

	public UILabel savePercent;

	public UILabel timeDuration;

	public UITable goldTable;

	public GameObject goldTableLastItem;

	public UILabel goldPrize;

	[Header("-Sale")]
	public GameObject salePart;

	public UILabel salePercentLabel;

	public WinStreakCounter saleTimeCounter;

	[Header("-Overlay")]
	public GameObject purchaseProtectionOverlay;

	public GameObject purchaseWaiting;

	public GameObject bottomPartOverlay;

	private VIP.rowIds mRowId;

	public void FirstInitialize(VIP.rowIds rowId)
	{
		mRowId = rowId;
		int num = SavePercentVip(rowId);
		savePercent.text = Localization.LocalizeFormat((!oneLinePercent) ? "ID_SAVEPERCENT" : "ID_SAVEPERCENTLINE", num);
		if (oneLinePercent)
		{
			MiscTools.SetUILabelRescale(savePercent, 37f, 20f, 230);
		}
		else
		{
			MiscTools.SetUILabelRescale(savePercent, 30f, 20f, 160);
		}
		savePart.SetActive(num > 0);
		timeDuration.text = MiscTools.PrintableTimeVipConvert(Singleton<GameVariables>.instance.vip.GetRow(rowId).SECONDS);
		goldTable.onReposition = delegate
		{
			float val = 0f - goldTable.padding.x - (goldTableLastItem.transform.localPosition.x - goldTable.padding.x) / 2f;
			goldTable.transform.localPosition = goldTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitializeGUI()
	{
		int num = Singleton<OfferManager>.instance.DiscountedVIP();
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.vip.GetRow(mRowId).GOLD;
		salePart.SetActive(flag);
		if (flag)
		{
			num2 = num2 * (100 - num) / 100;
			salePercentLabel.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			saleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedVIPEndtime(), upperCaseCountdown: true);
			saleTimeCounter.winStreakTimer = delegate
			{
				salePart.SetActive(value: false);
				goldPrize.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.vip.GetRow(mRowId).GOLD);
				goldTable.repositionNow = true;
			};
		}
		else
		{
			saleTimeCounter.StopCountingTo();
			saleTimeCounter.winStreakTimer = null;
		}
		goldPrize.text = MiscTools.FormatBigNumber(num2);
		goldTable.repositionNow = true;
		InitializePurchaseProtection();
	}

	public void InitializePurchaseProtection()
	{
		purchaseProtectionOverlay.SetActive(Singleton<PurchaseProtection>.instance.IsAnyVIPPurchasing());
		purchaseWaiting.SetActive(Singleton<PurchaseProtection>.instance.IsVIPPurchasing(mRowId.ToString()));
		bottomPartOverlay.SetActive(salePart.activeSelf);
	}

	public void StopCounter()
	{
		saleTimeCounter.StopCountingTo();
		saleTimeCounter.winStreakTimer = null;
	}

	private int SavePercentVip(VIP.rowIds rowId)
	{
		int sECONDS = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).SECONDS;
		int gOLD = Singleton<GameVariables>.instance.vip.GetRow(VIP.rowIds.VIP_1).GOLD;
		int sECONDS2 = Singleton<GameVariables>.instance.vip.GetRow(rowId).SECONDS;
		int gOLD2 = Singleton<GameVariables>.instance.vip.GetRow(rowId).GOLD;
		float num = (float)gOLD * (float)sECONDS2 / (float)sECONDS;
		return Mathf.FloorToInt(100f * (1f - (float)gOLD2 / num));
	}
}
