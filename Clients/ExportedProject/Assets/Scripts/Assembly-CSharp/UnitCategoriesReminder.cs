using UnityEngine;

public class UnitCategoriesReminder : DatabaseMessage
{
	public UnitCategoriesReminder()
		: base("UnitCategoriesReminder", Type.UnitCategoriesReminder)
	{
		Debug.Log("About to show unit categories reminder");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<ArmyCategoriesDialog>.instance.ShowDialog(reminderType: true);
	}
}
