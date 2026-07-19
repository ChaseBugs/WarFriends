using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Popup List Same Select")]
[ExecuteInEditMode]
public class UIPopupListSameSelect : UIPopupList
{
	public delegate void CHPECODAIJK(string LFPFCHIJLML);

	public CHPECODAIJK AAECOJFKADO;

	public override string selection
	{
		get
		{
			return mSelectedItem;
		}
		set
		{
			if (mSelectedItem != value)
			{
				mSelectedItem = value;
				if (mSelectedItem != null)
				{
					if (textLabel != null)
					{
						textLabel.text = ((!isLocalized) ? value : Localization.Localize(value));
					}
					UIPopupList.current = this;
					if (onSelectionChange != null)
					{
						onSelectionChange(mSelectedItem);
					}
					if (eventReceiver != null && !string.IsNullOrEmpty(functionName) && Application.isPlaying)
					{
						eventReceiver.SendMessage(functionName, mSelectedItem, SendMessageOptions.DontRequireReceiver);
					}
					UIPopupList.current = null;
				}
			}
			else if (AAECOJFKADO != null)
			{
				AAECOJFKADO(mSelectedItem);
			}
		}
	}

	public void HGJOJDPJEAB()
	{
		mSelectedItem = items[0];
	}

	[SpecialName]
	public virtual string LODDMJFAENF()
	{
		return mSelectedItem;
	}

	public void NEHBLFPJJMA()
	{
		mSelectedItem = items[1];
	}

	[SpecialName]
	public virtual void GDAEKHHJFIK(string IDEBKDPMPGM)
	{
		if (mSelectedItem != IDEBKDPMPGM)
		{
			mSelectedItem = IDEBKDPMPGM;
			if (mSelectedItem != null)
			{
				if (textLabel != null)
				{
					textLabel.text = ((!isLocalized) ? IDEBKDPMPGM : Localization.Localize(IDEBKDPMPGM));
				}
				UIPopupList.current = this;
				if (onSelectionChange != null)
				{
					onSelectionChange(mSelectedItem);
				}
				if (eventReceiver != null && !string.IsNullOrEmpty(functionName) && Application.isPlaying)
				{
					eventReceiver.SendMessage(functionName, mSelectedItem, SendMessageOptions.DontRequireReceiver);
				}
				UIPopupList.current = null;
			}
		}
		else if (AAECOJFKADO != null)
		{
			AAECOJFKADO(mSelectedItem);
		}
	}

	[SpecialName]
	public virtual string ELHNDLCDACB()
	{
		return mSelectedItem;
	}

	public void MFEDHFAHDAN()
	{
		mSelectedItem = items[1];
	}

	[SpecialName]
	public virtual void JOFIGAJHGHL(string IDEBKDPMPGM)
	{
		if (mSelectedItem != IDEBKDPMPGM)
		{
			mSelectedItem = IDEBKDPMPGM;
			if (mSelectedItem != null)
			{
				if (textLabel != null)
				{
					textLabel.text = ((!isLocalized) ? IDEBKDPMPGM : Localization.Localize(IDEBKDPMPGM));
				}
				UIPopupList.current = this;
				if (onSelectionChange != null)
				{
					onSelectionChange(mSelectedItem);
				}
				if (eventReceiver != null && !string.IsNullOrEmpty(functionName) && Application.isPlaying)
				{
					eventReceiver.SendMessage(functionName, mSelectedItem, SendMessageOptions.DontRequireReceiver);
				}
				UIPopupList.current = null;
			}
		}
		else if (AAECOJFKADO != null)
		{
			AAECOJFKADO(mSelectedItem);
		}
	}

	public void JIADJFGNIFA()
	{
		mSelectedItem = items[1];
	}

	[SpecialName]
	public virtual string ILLNPEIBEPF()
	{
		return mSelectedItem;
	}

	public void GHPJIGNGDFN()
	{
		mSelectedItem = items[0];
	}

	public void SetDefaultValue()
	{
		mSelectedItem = items[0];
	}
}
