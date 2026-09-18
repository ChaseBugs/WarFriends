using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Popup List Same Select")]
public class UIPopupListSameSelect : UIPopupList
{
	public delegate void OnSelectionSame(string item);

	public OnSelectionSame onSelectionSame;

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
			else if (onSelectionSame != null)
			{
				onSelectionSame(mSelectedItem);
			}
		}
	}

	public void SetDefaultValue()
	{
		mSelectedItem = items[0];
	}
}
