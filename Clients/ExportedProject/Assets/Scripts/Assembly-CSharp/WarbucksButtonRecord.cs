using UnityEngine;

public class WarbucksButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool isBig;

	[Header("Sale Part")]
	public GameObject salePart;

	public UILabel saleLabel;

	[Header("Icons")]
	public GameObject[] warbucksIcons;

	[Header("Labels")]
	public UILabel amountLabel;

	[Header("Bottom Part")]
	public UILabel priceLabel;

	private InappScreen.InappDefinition mDefinition;

	public void Initialize(InappScreen.InappDefinition inappDefinition)
	{
		mDefinition = inappDefinition;
		int amount = inappDefinition.amount;
		int sale = inappDefinition.sale;
		salePart.SetActive(sale > 0);
		if (sale > 0)
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
		amountLabel.text = MiscTools.FormatBigNumber(amount);
		priceLabel.text = inappDefinition.formatedPrice;
		MiscTools.SetUILabelRescale(priceLabel, 42f, 22f, 230);
		SetButtonIcons(amount);
	}

	public void ButtonClicked(GameObject go)
	{
		if (mDefinition != null)
		{
			Debug.Log("BUY: " + mDefinition.id);
			Singleton<BeanstalkServerManager>.instance.BuyInApp(mDefinition.id);
		}
	}

	private void SetButtonIcons(int amount)
	{
		if (!isBig)
		{
			int num = 0;
			if (amount > 500000)
			{
				num = 4;
			}
			else if (amount > 150000)
			{
				num = 3;
			}
			else if (amount > 70000)
			{
				num = 2;
			}
			else if (amount > 20000)
			{
				num = 1;
			}
			for (int i = 0; i < warbucksIcons.Length; i++)
			{
				warbucksIcons[i].SetActive(num == i);
			}
		}
	}
}
