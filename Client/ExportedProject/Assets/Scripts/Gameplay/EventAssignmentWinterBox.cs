public class EventAssignmentWinterBox : EventAssignment
{
	public override string text => Localization.LocalizeFormat((base.totalValue != 1) ? "ID_COLLECTXCHRISTMASCRATES" : "ID_COLLECTONECHRISTMASCRATE", mAssignmentColorString, MEJMLNDFDBP.GMIPFLIEOHD(base.totalValue));

	private string mAssignmentColorString => Colours.stringWinterEventBlue;

	public override int Update()
	{
		return Singleton<BonusBoxManager>.instance.destroyedBoxes;
	}
}
