using System;
using Google2u;
using UnityEngine;

public class DailyGoldBoosterDialog : GuiElementSingle<DailyGoldBoosterDialog>, IGuiDialog
{
	[Header("Close Button")]
	public GameObject closeButton;

	[Header("Left")]
	public UILabel percentSave;

	public UILabel description;

	[Header("Right")]
	public GameObject buyBoosterPart;

	public UILabel hint;

	public UILabel prize;

	public GameObject buyBoosterButton;

	public GameObject boughtBoosterPart;

	public GoldBoosterRecord[] goldRecords;

	private InappScreen.InappDefinition mInappDefinition;

	public void ShowDialog(InappScreen.InappDefinition inappDefinition)
	{
		mInappDefinition = inappDefinition;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(buyBoosterButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyBooster));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void BuyBooster(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.BuyInApp(mInappDefinition.id);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		InAppDataManager.InAppInfo dailyInApp = Singleton<BeanstalkServerManager>.instance.inAppDataManager.GetDailyInApp(Singleton<GameVariables>.instance.inApps.GetRow(InApps.rowIds.gold7daily1).NAME);
		bool flag = dailyInApp?.isActive ?? false;
		int sale = mInappDefinition.sale;
		int num = MiscTools.RoundToInt((float)mInappDefinition.amount / 8f);
		percentSave.text = MiscTools.FormatNumberAsPercent(sale);
		description.text = Localization.LocalizeFormat("ID_COLLECTGOLDEVERYDAYFORDAYSBREAK", num);
		MiscTools.SetUILabelRescale(description, 57f, 20f, 320);
		buyBoosterPart.SetActive(!flag);
		boughtBoosterPart.SetActive(flag);
		if (flag)
		{
			for (int i = 0; i < goldRecords.Length; i++)
			{
				goldRecords[i].Initialize(i == 0 || dailyInApp.days.ContainsKey(i.ToString()));
			}
		}
		else
		{
			string formatedPrice = mInappDefinition.formatedPrice;
			hint.text = Localization.LocalizeFormat("ID_DAILYGOLDBOOSTERHINT1", num, sale);
			prize.text = formatedPrice;
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
