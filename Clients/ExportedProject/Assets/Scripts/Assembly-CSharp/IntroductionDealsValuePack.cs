using System;
using System.Collections;
using UnityEngine;

public class IntroductionDealsValuePack : IntroductionDealsItem
{
	[Header("Value Pack")]
	public Collider buttonCollider;

	public UILabel saleLabel;

	private bool mIsAvailable;

	public override void InitEvents()
	{
		base.InitEvents();
		buttonCollider.enabled = false;
		UIEventListener uIEventListener = UIEventListener.Get(buttonCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnButtonClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += DataLoaded;
	}

	private void OnButtonClick(GameObject go)
	{
		GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
	}

	private void DataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && action == DatabaseAction.BuyPack)
		{
			UpdateAvailable();
		}
	}

	public override void InitGuiValues()
	{
		base.InitGuiValues();
		float num = Singleton<GameVariables>.instance.SaleOfPack(CardPack.Value);
		saleLabel.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num * 100f));
		UpdateAvailable();
	}

	public override bool IsAvailable()
	{
		return !PlayerAnalytics.instance.data.IsPackBought(CardPack.Value);
	}

	public override IEnumerator Show(float time)
	{
		buttonCollider.enabled = true;
		return base.Show(time);
	}

	public override IEnumerator Hide(float time)
	{
		buttonCollider.enabled = false;
		return base.Hide(time);
	}

	private void UpdateAvailable()
	{
		mIsAvailable = IsAvailable();
		if (!mIsAvailable)
		{
			SetShowTimeEnd(0.5f);
			buttonCollider.enabled = false;
		}
	}
}
