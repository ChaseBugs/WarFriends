using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InappLootboxes : Core_BaseScript
{
	[HideInInspector]
	public List<InappScreen.InappDefinition> lootboxesDefinitions;

	[Header("Core")]
	public UIPanel lootboxPanel;

	public UIDraggablePanel lootboxDraggablePanel;

	public UIPanel[] otherPanels;

	[Header("Buttons")]
	public LootboxButtonRecord[] smallButtons;

	public LootboxButtonRecord bigButton;

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
			TweenAlpha.Begin(lootboxPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
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
		for (int i = 0; i < smallButtons.Length; i++)
		{
			UIEventListener uIEventListener = UIEventListener.Get(smallButtons[i]);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LootboxClick));
			smallButtons[i].InitControls();
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(bigButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LootboxClick));
		bigButton.InitControls();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CreateLootboxDefinitions;
		Singleton<OfferManager>.instance.SalesChanged += OnSalesChanged;
		CreateLootboxDefinitions();
	}

	private void LootboxClick(GameObject go)
	{
		LootboxButtonRecord component = go.GetComponent<LootboxButtonRecord>();
		if (component != null)
		{
			int gold = component.gold;
			int discount = component.discount;
			if (Singleton<Wallet>.instance.CanBuyGold(gold))
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BuyVIP);
				Singleton<PurchaseProtection>.instance.BuyingLootboxes(component.id);
				InitializePurchaseProtection();
				Singleton<BeanstalkServerManager>.instance.BuyLootboxes(component.id, gold, discount);
			}
			else
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(gold, Localization.Localize("ID_LOOTBOXES"));
			}
		}
		else
		{
			Debug.LogError("Unkown Lootbox Button " + go.name);
		}
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf && action == DatabaseAction.BuyLootboxes)
		{
			InitializePurchaseProtection();
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && base.gameObject.activeSelf)
		{
			InitializePurchaseProtection();
		}
	}

	private void CreateLootboxDefinitions()
	{
		Lootboxes lootboxes = Singleton<GameVariables>.instance.lootboxes;
		if (lootboxesDefinitions == null)
		{
			lootboxesDefinitions = new List<InappScreen.InappDefinition>();
		}
		else
		{
			lootboxesDefinitions.Clear();
		}
		for (int i = 0; i < lootboxes.Rows.Count; i++)
		{
			LootboxesRow lootboxesRow = lootboxes.Rows[i];
			lootboxesDefinitions.Add(InappScreen.InappDefinition.CreateLootboxDefinition(lootboxesRow.NAME, lootboxesRow.COUNT, lootboxesRow.GOLD));
		}
		float num = float.MaxValue;
		for (int j = 0; j < lootboxesDefinitions.Count; j++)
		{
			float num2 = (float)lootboxesDefinitions[j].amount / lootboxesDefinitions[j].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int k = 0; k < lootboxesDefinitions.Count; k++)
		{
			float num3 = (float)lootboxesDefinitions[k].amount / lootboxesDefinitions[k].price;
			float num4 = Mathf.Max(0f, num3 - num);
			lootboxesDefinitions[k].sale = MiscTools.RoundToInt(20f * num4 / num) * 5;
		}
	}

	private void OnSalesChanged()
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed)
		{
			SetSaleAndPrize();
		}
	}

	public void InitGUIValues()
	{
		for (int i = 0; i < smallButtons.Length; i++)
		{
			smallButtons[i].Initialize(lootboxesDefinitions[i]);
		}
		bigButton.Initialize(lootboxesDefinitions[smallButtons.Length]);
		SetSaleAndPrize();
		AlignPanel(instant: true);
	}

	private void AlignPanel(bool instant = false)
	{
		lootboxDraggablePanel.AlignToPos(instant);
	}

	private void SetSaleAndPrize()
	{
		for (int i = 0; i < smallButtons.Length; i++)
		{
			smallButtons[i].SetSaleAndPrize();
		}
		bigButton.SetSaleAndPrize();
	}

	private void InitializePurchaseProtection()
	{
		for (int i = 0; i < smallButtons.Length; i++)
		{
			smallButtons[i].InitializePurchaseProtection();
		}
		bigButton.InitializePurchaseProtection();
	}

	public void DoAfterHide()
	{
	}

	public void InstantHideTab()
	{
		TweenAlpha component = lootboxPanel.GetComponent<TweenAlpha>();
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
