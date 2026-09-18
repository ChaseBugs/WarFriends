using System;
using UnityEngine;

public class WelcomeBackSoldierDialog : GuiElementSingle<WelcomeBackSoldierDialog>, IGuiDialog
{
	public enum WelcomeBackRewardType
	{
		Gold,
		Cards,
		Warbucks,
		VIP
	}

	[Header("Box1")]
	public UISprite box1Ico;

	public UILabel box1Label;

	public GameObject box1CardsHolder;

	[Header("Box2")]
	public UISprite box2Ico;

	public UILabel box2Label;

	public GameObject box2CardsHolder;

	[Header("Bottom")]
	public UIButton buttonThanks;

	private bool mIsBox1;

	private WelcomeBackRewardType mBox1Type;

	private int mBox1Amount;

	private bool mIsBox2;

	private WelcomeBackRewardType mBox2Type;

	private int mBox2Amount;

	public void ShowDialog(Tuple<WelcomeBackRewardType, int> box1, Tuple<WelcomeBackRewardType, int> box2)
	{
		mIsBox1 = box1 != null;
		if (mIsBox1)
		{
			mBox1Type = box1.Value1;
			mBox1Amount = box1.Value2;
		}
		mIsBox2 = box2 != null;
		if (mIsBox2)
		{
			mBox2Type = box2.Value1;
			mBox2Amount = box2.Value2;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonThanks.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		box1Ico.transform.parent.gameObject.SetActive(mIsBox1);
		if (mIsBox1)
		{
			box1Label.text = GetBoxDescription(mBox1Type, mBox1Amount);
			MiscTools.SetUILabelRescale(box1Label, 41f, 20f, 200);
			SetIcon(box1Ico, mBox1Type, box1CardsHolder);
		}
		box2Ico.transform.parent.gameObject.SetActive(mIsBox2);
		if (mIsBox2)
		{
			box2Label.text = GetBoxDescription(mBox2Type, mBox2Amount);
			MiscTools.SetUILabelRescale(box2Label, 41f, 20f, 200);
			SetIcon(box2Ico, mBox2Type, box2CardsHolder);
		}
		if (box1Ico.transform.parent.gameObject.activeSelf && box2Ico.transform.parent.gameObject.activeSelf)
		{
			if (box1Label.transform.localScale.y < box2Label.transform.localScale.y)
			{
				box2Label.transform.localScale = box1Label.transform.localScale;
				box2Label.transform.localPosition = box1Label.transform.localPosition;
			}
			else if (box1Label.transform.localScale.y > box2Label.transform.localScale.y)
			{
				box1Label.transform.localScale = box2Label.transform.localScale;
				box1Label.transform.localPosition = box2Label.transform.localPosition;
			}
		}
	}

	private void SetIcon(UISprite sprite, WelcomeBackRewardType type, GameObject cardsHolder)
	{
		switch (type)
		{
		case WelcomeBackRewardType.Cards:
			sprite.enabled = false;
			cardsHolder.SetActive(value: true);
			break;
		case WelcomeBackRewardType.Gold:
			cardsHolder.SetActive(value: false);
			sprite.spriteName = "menu-gold";
			sprite.MakePixelPerfect();
			sprite.transform.localScale = sprite.transform.localScale.MultiplyXY(0.33f);
			break;
		case WelcomeBackRewardType.Warbucks:
			cardsHolder.SetActive(value: false);
			sprite.spriteName = "menu-warbucks";
			sprite.MakePixelPerfect();
			sprite.transform.localScale = sprite.transform.localScale.MultiplyXY(0.6f);
			break;
		case WelcomeBackRewardType.VIP:
			cardsHolder.SetActive(value: false);
			sprite.spriteName = "menu-hub-multiplayer-vipico";
			sprite.MakePixelPerfect();
			sprite.transform.localScale = sprite.transform.localScale.MultiplyXY(0.4f);
			sprite.transform.localPosition = sprite.transform.localPosition.AddY(3f);
			break;
		}
	}

	private string GetBoxDescription(WelcomeBackRewardType type, int ammount)
	{
		switch (type)
		{
		case WelcomeBackRewardType.Cards:
			return Localization.LocalizeFormat("ID_X_CARDS", Colours.stringYellow, ammount);
		case WelcomeBackRewardType.Gold:
			return $"{Colours.stringGoldOld}{MiscTools.FormatBigNumber(ammount)}";
		case WelcomeBackRewardType.Warbucks:
			return $"{Colours.stringGreenWarbucks}{MiscTools.FormatBigNumber(ammount)}";
		case WelcomeBackRewardType.VIP:
			ammount /= 86400;
			Debug.Log("Vip days = " + ammount);
			return Localization.LocalizeFormat((ammount <= 1) ? "ID_VIP_DAY" : "ID_VIP_DAYS", Colours.stringGoldTier, ammount);
		default:
			return string.Empty;
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(buttonThanks.gameObject);
	}
}
