using System;
using Google2u;
using UnityEngine;

public class InappVIP : Core_BaseScript
{
	[Header("Benefits")]
	public BenefitsPart benefitsPart;

	[Header("VIP Buttons")]
	public VIPButton[] vipButtons;

	[Header("Panels")]
	public UIPanel vipPanel;

	public UIPanel[] otherPanels;

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
			TweenAlpha.Begin(vipPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
			{
				if (!showTab)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
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
		UIEventListener uIEventListener = UIEventListener.Get(vipButtons[0].gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed && GuiElementSingle<InappScreen>.instance.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_1);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(vipButtons[1].gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed && GuiElementSingle<InappScreen>.instance.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_2);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(vipButtons[2].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed && GuiElementSingle<InappScreen>.instance.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_3);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(vipButtons[3].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed && GuiElementSingle<InappScreen>.instance.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_4);
			}
		});
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (GuiElementSingle<InappScreen>.instance.isShowed)
			{
				InitializeGUIButtons();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		vipButtons[0].FirstInitialize(VIP.rowIds.VIP_1);
		vipButtons[1].FirstInitialize(VIP.rowIds.VIP_2);
		vipButtons[2].FirstInitialize(VIP.rowIds.VIP_3);
		vipButtons[3].FirstInitialize(VIP.rowIds.VIP_4);
	}

	private void BuyVip(VIP.rowIds row)
	{
		int discount = Singleton<OfferManager>.instance.DiscountedVIP();
		int cost = Singleton<GameVariables>.instance.vip.GetRow(row).GOLD * (100 - discount) / 100;
		string id = Singleton<GameVariables>.instance.vip.GetRow(row).NAME;
		if (!Singleton<Wallet>.instance.CanBuyGold(cost))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(cost, Localization.Localize("ID_VIPSTATUS"));
			GuiElementSingle<InappScreen>.instance.routeToStore = "VIP";
			return;
		}
		GuiElementSingle<VIPConfirmDialog>.instance.ShowDialog(row, delegate(bool buyClicked)
		{
			if (buyClicked)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BuyVIP);
				Singleton<PurchaseProtection>.instance.BuyingVIP(row.ToString());
				InitializePurchaseProtection();
				Singleton<BeanstalkServerManager>.instance.BuyVip(cost, id, discount);
			}
		});
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf && action == DatabaseAction.BuyVip)
		{
			InitializeGUIButtons();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			InitializeGUIButtons();
		}
	}

	public void InitGUIValues()
	{
		InitializeGUIButtons();
		benefitsPart.Initialize();
	}

	private void InitializeGUIButtons()
	{
		vipButtons[0].InitializeGUI();
		vipButtons[1].InitializeGUI();
		vipButtons[2].InitializeGUI();
		vipButtons[3].InitializeGUI();
	}

	private void InitializePurchaseProtection()
	{
		for (int i = 0; i < vipButtons.Length; i++)
		{
			vipButtons[i].InitializePurchaseProtection();
		}
	}

	public void DoAfterHide()
	{
		vipButtons[0].StopCounter();
		vipButtons[1].StopCounter();
		vipButtons[2].StopCounter();
		vipButtons[3].StopCounter();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = vipPanel.GetComponent<TweenAlpha>();
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
