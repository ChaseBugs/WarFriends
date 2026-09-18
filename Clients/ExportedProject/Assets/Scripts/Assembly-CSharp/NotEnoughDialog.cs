using System;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughDialog : GuiElementSingle<NotEnoughDialog>, IGuiDialog
{
	public enum Type
	{
		BUY,
		UPGRADE,
		TRAIN,
		DELIVER,
		UPGRADESPECIAL,
		TRAINSPECIAL,
		DELIVERSPECIAL,
		TRAINELITE,
		UPGRADEELITE
	}

	[Header("Content")]
	public UILabel header;

	public UILabel description;

	public GameObject warbucks;

	public GameObject gold;

	[Header("Buttons")]
	public UILabel buttonLabel;

	public UIButton close;

	public UIButton buttonGet;

	private bool mIsWarbucks;

	private int mNumber;

	private string mItem;

	private Type mType;

	private static Dictionary<Type, string> mText = new Dictionary<Type, string>
	{
		{
			Type.BUY,
			"ID_YOUNEEDMONEYTOBUY"
		},
		{
			Type.UPGRADE,
			"ID_YOUNEEDMONEYTOUPGRADE"
		},
		{
			Type.TRAIN,
			"ID_YOUNEEDMONEYTOTRAIN"
		},
		{
			Type.DELIVER,
			"ID_YOUNEEDMONEYTODELIVER"
		},
		{
			Type.UPGRADESPECIAL,
			"ID_YOUNEEDMONEYTOUPGRADESPECIAL"
		},
		{
			Type.TRAINSPECIAL,
			"ID_YOUNEEDMONEYTOTRAINSPECIAL"
		},
		{
			Type.DELIVERSPECIAL,
			"ID_YOUNEEDMONEYTODELIVERSPECIAL"
		},
		{
			Type.TRAINELITE,
			"ID_YOUNEEDMONEYTOTRAINELITE"
		},
		{
			Type.UPGRADEELITE,
			"ID_YOUNEEDMONEYTOUPGRADEELITE"
		}
	};

	public void ShowWarbucks(int number, string item, Type type = Type.BUY)
	{
		mIsWarbucks = true;
		mNumber = number;
		mItem = item;
		mType = type;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowGold(int number, string item, Type type = Type.BUY)
	{
		mIsWarbucks = false;
		mNumber = number;
		mItem = item;
		mType = type;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(close.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonGet.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ButtonGetClick));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			GuiElementSingle<InappScreen>.instance.routeToStore = string.Empty;
			HideDialog();
		}
	}

	private void ButtonGetClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			if (mIsWarbucks)
			{
				GuiElementSingle<InappScreen>.instance.ShowWarshopWarbucks();
			}
			else
			{
				GuiElementSingle<InappScreen>.instance.ShowWarshopGold();
			}
		}
	}

	public override void InitGUIValues()
	{
		warbucks.SetActive(mIsWarbucks);
		gold.SetActive(!mIsWarbucks);
		header.text = Localization.Localize((!mIsWarbucks) ? "ID_NOTENOUGHGOLD" : "ID_NOTENOUGHWARBUCKS");
		MiscTools.SetUILabelRescale(header, 74f, 50f, 1180);
		buttonLabel.text = Localization.Localize((!mIsWarbucks) ? "ID_GETSOMEGOLD" : "ID_GETSOMEWARBUCKS");
		description.text = Localization.LocalizeFormat(mText[mType], (!mIsWarbucks) ? Colours.stringGoldOld : Colours.stringGreenWarbucks, MiscTools.FormatBigNumber(mNumber), Localization.Localize((!mIsWarbucks) ? "ID_GOLD" : "ID_WARBUCKS").ToUpperInvariant(), Colours.stringWhite, Colours.stringBlue, mItem);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(close.gameObject);
	}
}
