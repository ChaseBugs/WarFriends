using System;
using Google2u;
using UnityEngine;

public class RandomCardRecord : PoolableObject
{
	[Header("GUI")]
	public UIButton buyButton;

	public UILabel priceLabel;

	public UILabel headerLabel;

	public UILabel buttonLabel;

	public void InitButton(string headerText, int price, string buttonText, Action<GameObject> action)
	{
		headerLabel.text = headerText;
		priceLabel.text = MiscTools.FormatBigNumber(price);
		buttonLabel.text = buttonText;
		UIEventListener uIEventListener = UIEventListener.Get(buyButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate(GameObject go)
		{
			action(go);
		});
	}

	public void Init(string headerText, string buttonText)
	{
		headerLabel.text = headerText;
		priceLabel.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		buttonLabel.text = buttonText;
		UIEventListener uIEventListener = UIEventListener.Get(buyButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	private void OnClick(GameObject go)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS);
		if (!Singleton<Wallet>.instance.CanBuyW(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.routeToStore = "WarCards";
		}
		else
		{
			Singleton<Wallet>.instance.WarBucksSpentFake(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}
}
