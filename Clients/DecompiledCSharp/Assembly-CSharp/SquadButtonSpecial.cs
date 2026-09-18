using UnityEngine;

public class SquadButtonSpecial : SquadButton
{
	[Header("Special Part")]
	public UILabel membersLabel;

	public UITable onlineTable;

	public UILabel onlineNumber;

	private float mPadding = 14f;

	protected override float mInsideWidth => base.mInsideWidth + mPadding + membersLabel.relativeSize.x * membersLabel.transform.localScale.x;

	public void InitializeSpecial(string specialText, bool toHighlight = false, bool playAnimation = false)
	{
		membersLabel.text = specialText;
		float num = base.mInsideWidth;
		float num2 = membersLabel.relativeSize.x * membersLabel.transform.localScale.x;
		float val = 0f - mInsideWidth / 2f + num / 2f;
		float val2 = mInsideWidth / 2f - num2 / 2f;
		buttonName.transform.localPosition = buttonName.transform.localPosition.ReplaceX(val);
		membersLabel.transform.localPosition = membersLabel.transform.localPosition.ReplaceX(val2);
		onlineTable.transform.localPosition = onlineTable.transform.localPosition.ReplaceX(0f - mInsideWidth / 2f - onlineTable.padding.x);
		buttonSetter.SetWidth(mInsideWidth + mSpaceAround);
		if (playAnimation)
		{
			InstantAnimate(toHighlight);
		}
	}

	public void SetOnline(int currentlyOnline)
	{
		if (currentlyOnline > 0)
		{
			onlineNumber.text = MiscTools.FormatBigNumber(currentlyOnline);
		}
		onlineTable.repositionNow = true;
	}
}
