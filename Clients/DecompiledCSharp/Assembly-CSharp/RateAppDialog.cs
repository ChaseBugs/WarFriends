using System;
using Google2u;
using UnityEngine;

public class RateAppDialog : GuiElementSingle<RateAppDialog>, IGuiDialog
{
	[Header("Content")]
	[SerializeField]
	private UILabel mRateAppText;

	[Header("Buttons")]
	[SerializeField]
	private GameObject mButtonCancel;

	[SerializeField]
	private GameObject mButtonRateNow;

	[SerializeField]
	private UILabel mLonelyLabel;

	[SerializeField]
	private UITable mTable;

	[SerializeField]
	private UILabel mGoldRewardNumber;

	[Header("Buttons")]
	[SerializeField]
	private SettingsNotificationButton mDontAskAgainCheckbox;

	private int mRandom = 1;

	private bool mAfterUpdate;

	private int mCount;

	private bool mCheckbox;

	private string mVariant => mRandom.ToString();

	private string mTranslationId => string.Format("{0}{1}", (!mAfterUpdate) ? string.Empty : "U", mRandom);

	private string mUser => (!mAfterUpdate) ? "_New_User" : "_Existing_User";

	public void ShowDialog(bool afterUpdate, int count)
	{
		mAfterUpdate = afterUpdate;
		mCount = count;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CancelClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(mButtonRateNow);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(RateClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(mDontAskAgainCheckbox.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OnCheckboxClick));
		UITable uITable = mTable;
		uITable.onReposition = (UITable.OnReposition)Delegate.Combine(uITable.onReposition, (UITable.OnReposition)delegate
		{
			float val = 0f - mTable.padding.x - (mGoldRewardNumber.transform.parent.transform.localPosition.x - mTable.padding.x) / 2f;
			mTable.transform.localPosition = mTable.transform.localPosition.ReplaceX(val);
		});
	}

	private void CancelClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			if (mCheckbox)
			{
				DialogManager.instance.NoMoreRateAppInThisVersion();
				Singleton<EventTrackingManager>.instance.RegisterStarRating($"Ignore_Text_{mVariant}{mUser}_Dont_Ask_Again", mCount);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterStarRating($"Ignore_Text_{mVariant}{mUser}", mCount);
			}
			HideDialog();
		}
	}

	private void RateClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterStarRating($"Rate_Text_{mVariant}{mUser}", mCount);
			Application.OpenURL(GameVariables.GooglePlayMarketURL);
			DialogManager.instance.GameWasRated();
			HideDialog();
		}
	}

	private void OnCheckboxClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			mCheckbox = !mCheckbox;
			mDontAskAgainCheckbox.SetHighlight(mCheckbox);
		}
	}

	public override void InitGUIValues()
	{
		mRandom = (mAfterUpdate ? 1 : UnityEngine.Random.Range(1, 5));
		mRateAppText.text = Localization.Localize("ID_RATEAPPTEXT" + mTranslationId);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.RateAppReward).FLOATVALUE;
		mLonelyLabel.gameObject.SetActive(num <= 0);
		mTable.gameObject.SetActive(num > 0);
		if (num > 0)
		{
			mGoldRewardNumber.text = MiscTools.FormatBigNumber(num);
			mTable.repositionNow = true;
		}
		mCheckbox = false;
		mDontAskAgainCheckbox.SetHighlight(mCheckbox);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CancelClick(mButtonCancel.gameObject);
	}
}
