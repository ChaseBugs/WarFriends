using System;
using UnityEngine;

public class InappCardPacks : Core_BaseScript
{
	[Header("Core")]
	public UIPanel warcardPacksPanel;

	public UIDraggablePanel warcardPacksDraggablePanel;

	public UIPanel[] otherPanels;

	[Header("Buttons")]
	public WarcardpackButtonRecord goldPackButton;

	public WarcardpackButtonRecord silverPackButton;

	public WarcardpackButtonRecord bronzePackButton;

	[Header("-Animation")]
	public CardMenuOwerlay owerlay;

	private int mClickTime;

	public void Animate(bool showTab, bool instant)
	{
		if (showTab && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			AnimateOtherPanels(instant, showTab);
			TweenAlpha.Begin(warcardPacksPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
				else
				{
					AlignPanel();
				}
			};
		}
		else if (!showTab)
		{
			InstantHideTab();
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bronzePackButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(WarCardPackClick));
		bronzePackButton.InitControls(CardPack.Bronze);
		UIEventListener uIEventListener2 = UIEventListener.Get(silverPackButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(WarCardPackClick));
		silverPackButton.InitControls(CardPack.Silver);
		UIEventListener uIEventListener3 = UIEventListener.Get(goldPackButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(WarCardPackClick));
		goldPackButton.InitControls(CardPack.Gold);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed)
			{
				SetSaleAndPrize();
			}
		};
	}

	private void WarCardPackClick(GameObject go)
	{
		WarcardpackButtonRecord component = go.GetComponent<WarcardpackButtonRecord>();
		if (component == null)
		{
			return;
		}
		CardPack warcardPack = component.warcardPack;
		Debug.Log(warcardPack.ToString() + " Button Clicked in InAppPurchase");
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(warcardPack);
		int num2 = Singleton<GameVariables>.instance.CardPackGold(warcardPack);
		int num3 = Singleton<OfferManager>.instance.DiscountedCardpack(warcardPack);
		num = num * (100 - num3) / 100;
		num2 = num2 * (100 - num3) / 100;
		if (!Singleton<Wallet>.instance.CanBuyW(num))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, Localization.Localize(warcardPack.ToString().ToUpper() + "PACK"));
			GuiElementSingle<InappScreen>.instance.routeToStore = "WarCards";
		}
		else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, Localization.Localize(warcardPack.ToString().ToUpper() + "PACK"));
			GuiElementSingle<InappScreen>.instance.routeToStore = "WarCards";
		}
		else if (mClickTime + 2 <= Singleton<BeanstalkServerManager>.instance.currentTimestamp)
		{
			mClickTime = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num > 0)
			{
				Singleton<Wallet>.instance.WarBucksSpentFake(num);
			}
			if (num2 > 0)
			{
				Singleton<Wallet>.instance.GoldSpentFake(num2);
			}
			owerlay.StartShowAnimation(CardManager.instance.BuyCardPack(warcardPack, num, num2, num3), 0.5f);
		}
	}

	public void InitGUIValues()
	{
		owerlay.ResetDraw();
		SetSaleAndPrize();
		AlignPanel(instant: true);
	}

	private void SetSaleAndPrize()
	{
		bronzePackButton.SetSaleAndPrize();
		silverPackButton.SetSaleAndPrize();
		goldPackButton.SetSaleAndPrize();
	}

	private void AlignPanel(bool instant = false)
	{
		warcardPacksDraggablePanel.AlignToPos(instant);
	}

	public void DoAfterHide()
	{
		bronzePackButton.DoAfterHide();
		silverPackButton.DoAfterHide();
		goldPackButton.DoAfterHide();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = warcardPacksPanel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void AnimateOtherPanels(bool instant, bool show)
	{
		if (otherPanels == null)
		{
			return;
		}
		for (int i = 0; i < otherPanels.Length; i++)
		{
			if (!(otherPanels[i] == null) && otherPanels[i].gameObject.activeSelf)
			{
				TweenAlpha.Begin(otherPanels[i].gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!show) ? 0f : 1f);
			}
		}
	}
}
