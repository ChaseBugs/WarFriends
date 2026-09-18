using System;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCountryDialog : GuiElementSingle<ChangeCountryDialog>, IGuiDialog
{
	[Header("Core")]
	public UIButton closeButton;

	public CountryIconButton countryIconButtonPrefab;

	public UIGrid countryGrid;

	public List<CountryIconButton> countryFlags;

	[HideInInspector]
	public CountryIconButton selectedIcon;

	private CountryIconButton noCountry;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		for (int i = 0; i < GameVariables.countryCodes.Count + 1; i++)
		{
			CountryIconButton countryIconButton = Singleton<GuiManager>.instance.objectPool.InstantiateAsChild(countryIconButtonPrefab, countryGrid.gameObject, i.ToString("'Country 'D2")) as CountryIconButton;
			if (countryIconButton != null)
			{
				countryFlags.Add(countryIconButton);
			}
		}
		countryGrid.repositionNow = true;
		int num = 0;
		foreach (KeyValuePair<string, string> countryCode in GameVariables.countryCodes)
		{
			countryFlags[num].Initialize(countryCode.Value, countryCode.Key);
			UIEventListener uIEventListener2 = UIEventListener.Get(countryFlags[num].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CountryFlagChange));
			num++;
		}
		noCountry = countryFlags[countryFlags.Count - 1];
		noCountry.Initialize("country-noflag", GameLoginManager.currentPlayer.country);
		UIEventListener uIEventListener3 = UIEventListener.Get(noCountry.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CountryFlagChange));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (selectedIcon != null && GameLoginManager.currentPlayer.country != selectedIcon.countryCode)
			{
				Debug.Log($"Changed country to {selectedIcon.countryCode} from {GameLoginManager.currentPlayer.country}.");
				GameLoginManager.currentPlayer.country = selectedIcon.countryCode;
				Singleton<BeanstalkServerManager>.instance.ChangePlayerCountry(selectedIcon.countryCode);
			}
			HideDialog();
		}
	}

	private void CountryFlagChange(GameObject go)
	{
		CountryIconButton component = go.GetComponent<CountryIconButton>();
		if (!(component == null))
		{
			if (selectedIcon != null)
			{
				selectedIcon.Highlight(setHighligth: false);
			}
			selectedIcon = component;
			selectedIcon.Highlight(setHighligth: true);
		}
	}

	public override void InitGUIValues()
	{
		string country = GameLoginManager.currentPlayer.country;
		int num = countryFlags.FindIndex((CountryIconButton countryIconButton) => countryIconButton.countryCode == country);
		bool flag = num >= 0;
		noCountry.gameObject.SetActive(!flag);
		if (selectedIcon != null)
		{
			selectedIcon.Highlight(setHighligth: false);
		}
		if (flag)
		{
			selectedIcon = countryFlags[num];
		}
		else
		{
			noCountry.Initialize("country-noflag", GameLoginManager.currentPlayer.country);
			selectedIcon = noCountry;
		}
		selectedIcon.Highlight(setHighligth: true);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		GuiElementSingle<SettingsDialog>.instance.userContent.InitGUIValues();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
