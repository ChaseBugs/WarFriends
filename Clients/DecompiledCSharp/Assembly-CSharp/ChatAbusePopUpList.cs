using System;
using UnityEngine;

public class ChatAbusePopUpList : Core_BaseScript
{
	[Header("List")]
	public UIPopupListSameSelect popUpList;

	[Header("Area For Click")]
	public BoxCollider boxCollider;

	[Header("Default Text")]
	public UILabel fakeLabel;

	private bool mCloseCheckRequired;

	private float mLastRealTime;

	public event Action<string, UILabel> OnSelect;

	public void ResetToDefault()
	{
		popUpList.enabled = false;
		popUpList.textLabel.enabled = false;
		EnableCollider(enabled: true);
		fakeLabel.gameObject.SetActive(value: true);
	}

	protected override void Awake()
	{
		base.Awake();
		ResetToDefault();
		UIEventListener uIEventListener = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(boxCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OnClicked));
		UIPopupListSameSelect uIPopupListSameSelect = popUpList;
		uIPopupListSameSelect.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Remove(uIPopupListSameSelect.onSelectionChange, new UIPopupList.OnSelectionChange(OnSelectionChanged));
		UIPopupListSameSelect uIPopupListSameSelect2 = popUpList;
		uIPopupListSameSelect2.onSelectionChange = (UIPopupList.OnSelectionChange)Delegate.Combine(uIPopupListSameSelect2.onSelectionChange, new UIPopupList.OnSelectionChange(OnSelectionChanged));
		UIPopupListSameSelect uIPopupListSameSelect3 = popUpList;
		uIPopupListSameSelect3.onSelectionSame = (UIPopupListSameSelect.OnSelectionSame)Delegate.Remove(uIPopupListSameSelect3.onSelectionSame, new UIPopupListSameSelect.OnSelectionSame(OnSelectionSame));
		UIPopupListSameSelect uIPopupListSameSelect4 = popUpList;
		uIPopupListSameSelect4.onSelectionSame = (UIPopupListSameSelect.OnSelectionSame)Delegate.Combine(uIPopupListSameSelect4.onSelectionSame, new UIPopupListSameSelect.OnSelectionSame(OnSelectionSame));
	}

	private void OnClicked(GameObject go)
	{
		mCloseCheckRequired = true;
		if (!popUpList.enabled)
		{
			popUpList.enabled = true;
		}
		popUpList.textLabel.enabled = false;
		EnableCollider(enabled: false);
		fakeLabel.gameObject.SetActive(value: false);
	}

	private void OnSelectionChanged(string s)
	{
		if (this.OnSelect != null)
		{
			this.OnSelect(s, popUpList.textLabel);
		}
	}

	private void OnSelectionSame(string s)
	{
		if (this.OnSelect != null)
		{
			this.OnSelect(s, popUpList.textLabel);
		}
	}

	protected void Update()
	{
		if (popUpList.isOpen && mCloseCheckRequired)
		{
			mLastRealTime = Time.realtimeSinceStartup;
		}
		if (!popUpList.isOpen && mCloseCheckRequired && Time.realtimeSinceStartup - mLastRealTime > 0.2f)
		{
			mCloseCheckRequired = false;
			popUpList.textLabel.enabled = true;
			EnableCollider(enabled: true);
		}
		if (popUpList.isOpen)
		{
			EnableCollider(enabled: false);
		}
	}

	private void EnableCollider(bool enabled)
	{
		boxCollider.enabled = enabled;
	}
}
