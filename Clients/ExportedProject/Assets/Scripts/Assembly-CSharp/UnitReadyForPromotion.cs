using UnityEngine;

public class UnitReadyForPromotion : DatabaseMessage
{
	private LevelBehaviour mUnit;

	public UnitReadyForPromotion(LevelBehaviour unit)
		: base($"UnitReadyForPromotion {unit.unitName} {unit.upgradeSlots.actualTier}", Type.UnitReadyForPromotion)
	{
		mUnit = unit;
		Debug.Log("About to show Unit Ready For Promotion - " + mUnit.unitName);
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<UnitReadyForPromotionDialog>.instance.ShowDialog(mUnit);
	}

	public override bool CanShow()
	{
		return base.CanShow() && !GuiElementSingle<ChatGuiElement>.instance.isRightPartDisplayed;
	}
}
