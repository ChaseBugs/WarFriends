using System;
using UnityEngine;

public class BuyHearthDialog : GuiElementSingle<BuyHearthDialog>, IGuiDialog
{
	[Header("Top")]
	public GameObject closeButton;

	[Header("Middle")]
	public UISprite leftHearth;

	public UISprite centerHearth;

	public UISprite rightHearth;

	public UILabel description;

	[Header("Bottom")]
	public GameObject bottomButton;

	public UILabel buttonLabel;

	public GameObject buttonIcon;

	public UILabel hearthCostLabel;

	public GameObject waitingOverlay;

	private int mTotalHearths;

	private int mHearthCost;

	public void ShowDialog()
	{
		mTotalHearths = WarArena.instance.warArenaConfig.lifeCount;
		mHearthCost = WarArena.instance.extraLiveCost;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(bottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuyClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.GetScrapsReward(showDialog: true);
			HideDialog();
		}
	}

	private void BuyClick(GameObject go)
	{
		if (Singleton<Wallet>.instance.CanBuyTickets(mHearthCost))
		{
			Singleton<BeanstalkServerManager>.instance.BuyArenaHearth();
			waitingOverlay.SetActive(value: false);
			return;
		}
		GuiElementSingle<BuyTicketsDialog>.instance.ShowDialog(mHearthCost, BuyTicketType.BuyHearth, delegate(bool bought)
		{
			if (!bought)
			{
				waitingOverlay.SetActive(value: false);
			}
		});
		waitingOverlay.SetActive(value: true);
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
		waitingOverlay.SetActive(value: false);
		leftHearth.gameObject.SetActive(mTotalHearths == 2 || mTotalHearths == 3);
		centerHearth.gameObject.SetActive(mTotalHearths == 1 || mTotalHearths == 3);
		rightHearth.gameObject.SetActive(mTotalHearths == 2 || mTotalHearths == 3);
		if (mTotalHearths == 1)
		{
			description.text = Localization.LocalizeFormat("ID_YOULOSTONETIMEBUTYOUARECLOSE", Colours.stringGreenArena);
		}
		else
		{
			description.text = Localization.LocalizeFormat("ID_YOULOSTXTIMESBUTYOUARECLOSE", mTotalHearths, Colours.stringGreenArena);
		}
		buttonLabel.text = Localization.Localize("ID_EXTRA");
		float val = 50f + buttonLabel.relativeSize.x * buttonLabel.transform.localScale.x + 46f;
		buttonIcon.transform.localPosition = buttonIcon.transform.localPosition.ReplaceX(val);
		hearthCostLabel.text = MiscTools.FormatBigNumber(mHearthCost);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(closeButton);
	}
}
