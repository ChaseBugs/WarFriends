using UnityEngine;

public class GoldButtonRecord : Core_BaseScript
{
	[Header("Settings")]
	public bool isBig;

	[Header("Sale Part")]
	public GameObject salePart;

	public UILabel saleLabel;

	[Header("Icons")]
	public GameObject[] goldIcons;

	[Header("Labels")]
	public UILabel amountLabel;

	[Header("Bottom Part")]
	public UILabel priceLabel;

	protected InappScreen.InappDefinition mDefinition;

	public virtual void Initialize(InappScreen.InappDefinition inappDefinition)
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

	public virtual void ButtonClicked(GameObject go)
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
			if (amount > 1300)
			{
				num = 4;
			}
			else if (amount > 600)
			{
				num = 3;
			}
			else if (amount > 300)
			{
				num = 2;
			}
			else if (amount > 100)
			{
				num = 1;
			}
			for (int i = 0; i < goldIcons.Length; i++)
			{
				goldIcons[i].SetActive(num == i);
			}
		}
	}
}
