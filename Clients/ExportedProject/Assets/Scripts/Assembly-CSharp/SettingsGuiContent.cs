using System;
using UnityEngine;

public class SettingsGuiContent : Core_BaseScript
{
	[Header("Core")]
	public SettingsButton opponentHealthBarsSettings;

	public SettingsButton myHealthBarsSetting;

	public SettingsButton showScopesSetting;

	public SettingsButton playerHealthBarSetting;

	public SettingsButton autoDeploySetting;

	public SettingsButton vibrationsSetting;

	private bool mHealthBarsOnOpponent
	{
		get
		{
			return DebugSettings.healthbarsOnOpponentUnits;
		}
		set
		{
			if (value != mHealthBarsOnOpponent)
			{
				DebugSettings.healthbarsOnOpponentUnits = value;
			}
		}
	}

	private bool mHealthBarsOnMy
	{
		get
		{
			return DebugSettings.healthbarsOnMyUnits;
		}
		set
		{
			if (value != mHealthBarsOnMy)
			{
				DebugSettings.healthbarsOnMyUnits = value;
			}
		}
	}

	private bool mShowPrimaryScopes
	{
		get
		{
			return DebugSettings.showPrimaryScopes;
		}
		set
		{
			if (value != mShowPrimaryScopes)
			{
				DebugSettings.showPrimaryScopes = value;
			}
		}
	}

	private bool mPlayerHealthbar
	{
		get
		{
			return DebugSettings.playerHealthbars;
		}
		set
		{
			if (value != mPlayerHealthbar)
			{
				DebugSettings.playerHealthbars = value;
			}
		}
	}

	private bool mAutoDeploy
	{
		get
		{
			return DebugSettings.autoDeploy;
		}
		set
		{
			if (value != mAutoDeploy)
			{
				DebugSettings.autoDeploy = value;
				if (value)
				{
					Singleton<EventTrackingManager>.instance.RegisterAutodeployOn();
				}
				else
				{
					Singleton<EventTrackingManager>.instance.RegisterAutodeployOff();
				}
			}
		}
	}

	private bool mVibrations
	{
		get
		{
			return DebugSettings.vibrations;
		}
		set
		{
			if (value != mVibrations)
			{
				DebugSettings.vibrations = value;
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(opponentHealthBarsSettings.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mHealthBarsOnOpponent = !mHealthBarsOnOpponent;
			opponentHealthBarsSettings.ButtonSetTo(mHealthBarsOnOpponent);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(myHealthBarsSetting.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mHealthBarsOnMy = !mHealthBarsOnMy;
			myHealthBarsSetting.ButtonSetTo(mHealthBarsOnMy);
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(showScopesSetting.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mShowPrimaryScopes = !mShowPrimaryScopes;
			showScopesSetting.ButtonSetTo(mShowPrimaryScopes);
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(playerHealthBarSetting.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mPlayerHealthbar = !mPlayerHealthbar;
			playerHealthBarSetting.ButtonSetTo(mPlayerHealthbar);
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(autoDeploySetting.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mAutoDeploy = !mAutoDeploy;
			autoDeploySetting.ButtonSetTo(mAutoDeploy);
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(vibrationsSetting.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			mVibrations = !mVibrations;
			vibrationsSetting.ButtonSetTo(mVibrations);
		});
	}

	public void InitGUIValues()
	{
		opponentHealthBarsSettings.ButtonSetTo(mHealthBarsOnOpponent, updateOnlyActiveObject: false);
		myHealthBarsSetting.ButtonSetTo(mHealthBarsOnMy, updateOnlyActiveObject: false);
		showScopesSetting.ButtonSetTo(mShowPrimaryScopes, updateOnlyActiveObject: false);
		playerHealthBarSetting.ButtonSetTo(mPlayerHealthbar, updateOnlyActiveObject: false);
		autoDeploySetting.ButtonSetTo(mAutoDeploy, updateOnlyActiveObject: false);
		vibrationsSetting.ButtonSetTo(mVibrations, updateOnlyActiveObject: false);
	}
}
