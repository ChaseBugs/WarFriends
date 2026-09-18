using System;
using Google2u;
using UnityEngine;

public class BuyVIPDialog : GuiElementSingle<BuyVIPDialog>, IGuiDialog
{
	[Header("Header")]
	public UILabel headerTitle;

	public UISprite ornamentsL;

	public UISprite ornamentsR;

	[Header("-Buttons")]
	public UIButton backButton;

	public UIButton closeButton;

	[Header("-Expiration Table")]
	public GameObject vipProgressBar;

	public UITable expireInTable;

	public WinStreakCounter counterVIPActive;

	[Header("Locked Warcards")]
	public BenefitsPart benefitsPart;

	[Header("Bottom VIP Buttons")]
	public VIPButton[] vipButtons;

	private bool mUpdatingProgressBar;

	private bool mNotFullyShowed;

	public void ShowScreen()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 0f);
	}

	public void ShowExpired()
	{
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<BuyVIPDialog>.instance, 0f);
	}

	public override void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed && action == DatabaseAction.BuyVip)
			{
				InitGUIValues();
			}
		};
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(vipButtons[0].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_1);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(vipButtons[1].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_2);
			}
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(vipButtons[2].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_3);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(vipButtons[3].gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				BuyVip(VIP.rowIds.VIP_4);
			}
		});
		vipButtons[0].FirstInitialize(VIP.rowIds.VIP_1);
		vipButtons[1].FirstInitialize(VIP.rowIds.VIP_2);
		vipButtons[2].FirstInitialize(VIP.rowIds.VIP_3);
		vipButtons[3].FirstInitialize(VIP.rowIds.VIP_4);
		Singleton<OfferManager>.instance.SalesChanged += delegate
		{
			if (isShowed)
			{
				InitializeGUIButtons();
			}
		};
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		expireInTable.onReposition = delegate
		{
			float num = counterVIPActive.counterLabel.transform.localPosition.x + counterVIPActive.counterLabel.relativeSize.x * counterVIPActive.counterLabel.transform.localScale.x;
			float val = 0f - expireInTable.padding.x - (num - expireInTable.padding.x) / 2f;
			expireInTable.transform.localPosition = expireInTable.transform.localPosition.ReplaceX(val);
		};
		mUpdatingProgressBar = false;
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ChangeHeader(bool isVIPActive)
	{
		headerTitle.text = ((!isVIPActive) ? Localization.Localize("ID_BECOMEAVIP") : Localization.Localize("ID_PROLONGYOURVIP"));
		MiscTools.SetUILabelRescale(headerTitle, 94f, 47f, 960);
		float num = headerTitle.relativeSize.x * headerTitle.transform.localScale.x;
		float num2 = 50f;
		Vector3 localPosition = ornamentsR.transform.localPosition;
		localPosition.x = headerTitle.transform.localPosition.x + num * 0.5f + num2;
		ornamentsL.transform.localPosition = -localPosition;
		ornamentsR.transform.localPosition = localPosition;
		vipProgressBar.SetActive(isVIPActive);
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
		if (isShowed && action == DatabaseAction.BuyVip)
		{
			InitializeGUIButtons();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (isShowed)
		{
			InitializeGUIButtons();
		}
	}

	public override void InitGUIValues()
	{
		ChangeHeader(Singleton<VipManager>.instance.IsVipActive());
		InitializeGUIButtons();
		if (Singleton<VipManager>.instance.IsVipActive())
		{
			if (!mUpdatingProgressBar)
			{
				mUpdatingProgressBar = true;
				UpdateProgressBar();
				CounterManager counterManager = Singleton<CounterManager>.instance;
				counterManager.updateCounterBySecond = (Action)Delegate.Combine(counterManager.updateCounterBySecond, new Action(UpdateProgressBar));
			}
			counterVIPActive.StartCountingTo(Singleton<VipManager>.instance.vipExpiration);
			counterVIPActive.winStreakTimer = delegate
			{
				ChangeHeader(Singleton<VipManager>.instance.IsVipActive());
			};
		}
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

	private void UpdateProgressBar()
	{
		int vipStart = Singleton<VipManager>.instance.vipStart;
		int vipExpiration = Singleton<VipManager>.instance.vipExpiration;
		int currentTimestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		float fillAmount = ((vipExpiration != vipStart) ? Mathf.Clamp01((float)(vipExpiration - currentTimestamp) / (float)(vipExpiration - vipStart)) : 0f);
		counterVIPActive.timerBar.fillAmount = fillAmount;
		expireInTable.repositionNow = true;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mUpdatingProgressBar)
		{
			mUpdatingProgressBar = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.updateCounterBySecond = (Action)Delegate.Remove(counterManager.updateCounterBySecond, new Action(UpdateProgressBar));
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		vipButtons[0].StopCounter();
		vipButtons[1].StopCounter();
		vipButtons[2].StopCounter();
		vipButtons[3].StopCounter();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(backButton.gameObject);
	}
}
