using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InappGold : Core_BaseScript
{
	[HideInInspector]
	public string goldPrefix = "gold";

	[HideInInspector]
	public List<InappScreen.InappDefinition> goldInAppDefinitions;

	[Header("Core")]
	public GoldButtonRecord[] smallButtons;

	public GoldButtonRecord bigButton;

	public GoldDailyButtonRecord bigButtonDaily;

	public UIPanel goldPanel;

	public UIDraggablePanel goldDraggablePanel;

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
			TweenAlpha.Begin(goldPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
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
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(smallButtons[i].ButtonClicked));
		}
		UIEventListener uIEventListener2 = UIEventListener.Get(bigButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(bigButton.ButtonClicked));
		UIEventListener uIEventListener3 = UIEventListener.Get(bigButtonDaily);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(bigButtonDaily.ButtonClicked));
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CreateInappDefinitions;
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += InAppHandlerOnProductsLoaded;
		CreateInappDefinitions();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += HandleDataLoaded;
	}

	private void CreateInappDefinitions()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		if (goldInAppDefinitions == null)
		{
			goldInAppDefinitions = new List<InappScreen.InappDefinition>();
		}
		else
		{
			goldInAppDefinitions.Clear();
		}
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			if (inAppsRow.NAME.StartsWith(goldPrefix))
			{
				InappScreen.InappDefinition inappDefinition = InappScreen.InappDefinition.CreateInappDefinition(inAppsRow.NAME, inAppsRow.AMOUNT);
				inappDefinition.type = InappScreen.InAppType.Gold;
				goldInAppDefinitions.Add(inappDefinition);
			}
		}
		float num = float.MaxValue;
		for (int j = 0; j < goldInAppDefinitions.Count; j++)
		{
			float num2 = (float)goldInAppDefinitions[j].amount / goldInAppDefinitions[j].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int k = 0; k < goldInAppDefinitions.Count; k++)
		{
			float num3 = (float)goldInAppDefinitions[k].amount / goldInAppDefinitions[k].price;
			if (goldInAppDefinitions[k].id.Contains("daily"))
			{
				float num4 = 1f - num / num3;
				goldInAppDefinitions[k].sale = MiscTools.RoundToInt(100f * num4);
			}
			else
			{
				float num5 = Mathf.Max(0f, num3 - num);
				goldInAppDefinitions[k].sale = MiscTools.RoundToInt(20f * num5 / num) * 5;
			}
		}
	}

	private void InAppHandlerOnProductsLoaded()
	{
		if (!GuiElementSingle<InappScreen>.instance.isShowed)
		{
			return;
		}
		foreach (InappScreen.InappDefinition goldInAppDefinition in goldInAppDefinitions)
		{
			Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(goldInAppDefinition.id);
			goldInAppDefinition.price = itemPrice.Value1;
			goldInAppDefinition.formatedPrice = itemPrice.Value2;
		}
		InitGUIValues();
	}

	private void HandleDataLoaded(DatabaseAction databaseAction)
	{
		if (GuiElementSingle<InappScreen>.instance.isShowed && databaseAction == DatabaseAction.BuyInApp)
		{
			bigButtonDaily.ActualizeState();
		}
	}

	public void InitGUIValues()
	{
		int i;
		for (i = 0; i < smallButtons.Length; i++)
		{
			smallButtons[i].Initialize(goldInAppDefinitions[i]);
		}
		bigButton.Initialize(goldInAppDefinitions[i]);
		i++;
		bigButtonDaily.Initialize(goldInAppDefinitions[i]);
		AlignPanel(instant: true);
	}

	private void AlignPanel(bool instant = false)
	{
		goldDraggablePanel.AlignToPos(instant);
	}

	public void DoAfterHide()
	{
	}

	public void InstantHideTab()
	{
		TweenAlpha component = goldPanel.GetComponent<TweenAlpha>();
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
