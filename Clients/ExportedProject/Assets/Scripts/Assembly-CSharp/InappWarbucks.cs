using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class InappWarbucks : Core_BaseScript
{
	[HideInInspector]
	public string warbucksPrefix = "warbucks";

	[HideInInspector]
	public List<InappScreen.InappDefinition> warbucksInAppDefinitions;

	[Header("Core")]
	public WarbucksButtonRecord[] smallButtons;

	public WarbucksButtonRecord bigButton;

	public UIPanel warbucksPanel;

	public UIDraggablePanel warbucksDraggablePanel;

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
			TweenAlpha.Begin(warbucksPanel.gameObject, (!instant) ? (GuiElementSingle<InappScreen>.instance.dur * 2f) : 0.01f, (!showTab) ? 0f : 1f).onFinished = delegate
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
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += CreateInappDefinitions;
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += InAppHandlerOnProductsLoaded;
		CreateInappDefinitions();
	}

	private void CreateInappDefinitions()
	{
		InApps inApps = Singleton<GameVariables>.instance.inApps;
		if (warbucksInAppDefinitions == null)
		{
			warbucksInAppDefinitions = new List<InappScreen.InappDefinition>();
		}
		else
		{
			warbucksInAppDefinitions.Clear();
		}
		for (int i = 0; i < inApps.Rows.Count; i++)
		{
			InAppsRow inAppsRow = inApps.Rows[i];
			if (inAppsRow.NAME.StartsWith(warbucksPrefix))
			{
				InappScreen.InappDefinition inappDefinition = InappScreen.InappDefinition.CreateInappDefinition(inAppsRow.NAME, inAppsRow.AMOUNT);
				inappDefinition.type = InappScreen.InAppType.Warbucks;
				warbucksInAppDefinitions.Add(inappDefinition);
			}
		}
		float num = float.MaxValue;
		for (int j = 0; j < warbucksInAppDefinitions.Count; j++)
		{
			float num2 = (float)warbucksInAppDefinitions[j].amount / warbucksInAppDefinitions[j].price;
			if (num2 < num)
			{
				num = num2;
			}
		}
		for (int k = 0; k < warbucksInAppDefinitions.Count; k++)
		{
			float num3 = (float)warbucksInAppDefinitions[k].amount / warbucksInAppDefinitions[k].price;
			float num4 = Mathf.Max(0f, num3 - num);
			warbucksInAppDefinitions[k].sale = MiscTools.RoundToInt(20f * num4 / num) * 5;
		}
	}

	private void InAppHandlerOnProductsLoaded()
	{
		if (!GuiElementSingle<InappScreen>.instance.isShowed)
		{
			return;
		}
		foreach (InappScreen.InappDefinition warbucksInAppDefinition in warbucksInAppDefinitions)
		{
			Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(warbucksInAppDefinition.id);
			warbucksInAppDefinition.price = itemPrice.Value1;
			warbucksInAppDefinition.formatedPrice = itemPrice.Value2;
		}
		InitGUIValues();
	}

	public void InitGUIValues()
	{
		int i;
		for (i = 0; i < smallButtons.Length; i++)
		{
			smallButtons[i].Initialize(warbucksInAppDefinitions[i]);
		}
		bigButton.Initialize(warbucksInAppDefinitions[i]);
		AlignPanel(instant: true);
	}

	private void AlignPanel(bool instant = false)
	{
		warbucksDraggablePanel.AlignToPos(instant);
	}

	public void DoAfterHide()
	{
	}

	public void InstantHideTab()
	{
		TweenAlpha component = warbucksPanel.GetComponent<TweenAlpha>();
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
