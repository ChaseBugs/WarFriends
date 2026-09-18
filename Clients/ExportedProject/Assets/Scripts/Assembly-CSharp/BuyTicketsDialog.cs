using System;
using System.Collections.Generic;
using UnityEngine;

public class BuyTicketsDialog : GuiElementSingle<BuyTicketsDialog>, IGuiDialog
{
	[Header("Core")]
	public GameObject dialogCenter;

	public UISprite background;

	[Header("Top")]
	public GameObject closeButton;

	[Header("Midlle")]
	public UILabel hintText;

	public UILabel neededTickets;

	public GameObject hintPart;

	[Header("Bottom")]
	public GameObject bottomPart;

	public GameObject buyTicketsButton;

	public UILabel buyTicketsLabel;

	public UILabel goldLabel;

	public GameObject waitingOverlay;

	private Action<bool> BoughtTickets;

	private long mRequiredTickets;

	private long mCurrentTickets;

	private int mGoldCost;

	private BuyTicketType mBuyType;

	public void ShowDialog(long requiredTickets, BuyTicketType type, Action<bool> boughtTickets = null)
	{
		mRequiredTickets = requiredTickets;
		mCurrentTickets = Singleton<Wallet>.instance.tickets;
		mGoldCost = MiscTools.ConvertTicketsIntoGold(mRequiredTickets - mCurrentTickets);
		BoughtTickets = boughtTickets;
		mBuyType = type;
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyTicketsDialog>.instance, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(buyTicketsButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyTicketsClick));
		EnterArenaRequest.Response = (Action<bool>)Delegate.Combine(EnterArenaRequest.Response, new Action<bool>(OnServerResponse));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (BoughtTickets != null)
			{
				BoughtTickets(obj: false);
			}
			HideDialog();
		}
	}

	private void BuyTicketsClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(mGoldCost))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(mGoldCost, Localization.Localize("ID_ARENATICKETSSMALL"));
			return;
		}
		waitingOverlay.SetActive(value: true);
		if (mBuyType == BuyTicketType.BuyHearth)
		{
			Singleton<BeanstalkServerManager>.instance.SendServerRequest(DatabaseAction.BuyArenaHearth, new List<Tuple<string, string>>
			{
				new Tuple<string, string>("UsedGolds", mGoldCost.ToString())
			});
		}
		else if (mBuyType == BuyTicketType.EnterArena)
		{
			EnterArenaRequest.Send(mGoldCost);
		}
	}

	private void OnServerResponse(bool canEnterArena)
	{
		waitingOverlay.SetActive(value: false);
		if (BoughtTickets != null)
		{
			BoughtTickets(canEnterArena);
		}
		HideDialog();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (base.isFullyShowed && action == DatabaseAction.BuyArenaHearth)
		{
			waitingOverlay.SetActive(value: false);
			HideDialog();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (base.isFullyShowed && action == DatabaseAction.BuyArenaHearth)
		{
			waitingOverlay.SetActive(value: false);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		Rescale();
		waitingOverlay.SetActive(value: false);
		long num = mRequiredTickets - mCurrentTickets;
		if (num == 1)
		{
			hintText.text = Localization.LocalizeFormat((mBuyType != BuyTicketType.EnterArena) ? "ID_YOUNEED1TICKETFOREXTRAHEART" : "ID_YOUNEED1TICKETTOENTERARENA", Colours.stringGreenArena);
			buyTicketsLabel.text = Localization.Localize("ID_ONETICKET");
		}
		else
		{
			hintText.text = Localization.LocalizeFormat((mBuyType != BuyTicketType.EnterArena) ? "ID_YOUNEEDXTICKETSFOREXTRAHEART" : "ID_YOUNEEDXTICKETSTOENTERARENA", Colours.stringGreenArena, num);
			buyTicketsLabel.text = Localization.LocalizeFormat("ID_XTICKETS", num);
		}
		neededTickets.text = $"{Colours.stringGreenArena}{MiscTools.FormatBigNumber(mCurrentTickets)}[-] / {MiscTools.FormatBigNumber(mRequiredTickets)}";
		goldLabel.text = MiscTools.FormatBigNumber(mGoldCost);
	}

	private void Rescale()
	{
		bool flag = mBuyType == BuyTicketType.BuyHearth;
		dialogCenter.transform.localPosition = dialogCenter.transform.localPosition.ReplaceY((!flag) ? (-76f) : (-182f));
		background.transform.localScale = background.transform.localScale.ReplaceY((!flag) ? 980f : 692f);
		hintPart.SetActive(!flag);
		bottomPart.transform.localPosition = bottomPart.transform.localPosition.ReplaceY((!flag) ? (-376f) : (-98f));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		BoughtTickets = null;
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
