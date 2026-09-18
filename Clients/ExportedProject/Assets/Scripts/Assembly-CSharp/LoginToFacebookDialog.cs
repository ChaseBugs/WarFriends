using System;
using Google2u;
using UnityEngine;

public class LoginToFacebookDialog : GuiElementSingle<LoginToFacebookDialog>, IGuiDialog
{
	[Header("Dialog Content")]
	public GameObject facebookHints;

	public GameObject facebookHintsRewardClaimed;

	public UILabel goldReward;

	public UIButton notNow;

	public UIButton loginToFacebook;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(notNow.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(loginToFacebook.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool result)
				{
					if (result)
					{
						GameLoginManager.instance.AfterTutorialLoginToFacebook();
						HideDialog();
					}
				});
			}
		});
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
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
		facebookHints.SetActive(!flag);
		facebookHintsRewardClaimed.SetActive(flag);
		if (!flag)
		{
			int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
			goldReward.text = MiscTools.FormatBigNumber(num);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(notNow.gameObject);
	}
}
