using Google2u;
using UnityEngine;

public class GoldDailyButtonRecord : GoldButtonRecord
{
	[Header("Daily Gold Additional")]
	public GameObject dailyActive;

	public UILabel description;

	public override void Initialize(InappScreen.InappDefinition inappDefinition)
	{
		mDefinition = inappDefinition;
		int amount = inappDefinition.amount;
		int sale = inappDefinition.sale;
		salePart.SetActive(sale > 0);
		if (sale > 0)
		{
			saleLabel.text = MiscTools.FormatNumberAsPercent(sale);
		}
		description.text = Localization.LocalizeFormat("ID_COLLECTGOLDEVERYDAYFORDAYS", MiscTools.RoundToInt((float)amount / 8f));
		ActualizeState();
	}

	public void ActualizeState()
	{
		bool flag = Singleton<BeanstalkServerManager>.instance.inAppDataManager.GetDailyInApp(Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold7daily1).NAME)?.isActive ?? false;
		dailyActive.SetActive(flag);
		if (flag)
		{
			salePart.SetActive(value: false);
		}
	}

	public override void ButtonClicked(GameObject go)
	{
		Debug.Log("Daily Gold Button click");
		GuiElementSingle<DailyGoldBoosterDialog>.instance.ShowDialog(mDefinition);
	}
}
