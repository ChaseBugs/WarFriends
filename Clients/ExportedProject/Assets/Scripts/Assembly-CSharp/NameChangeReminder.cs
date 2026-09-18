using UnityEngine;

public class NameChangeReminder : DatabaseMessage
{
	public NameChangeReminder()
		: base("NameChangeReminder", Type.NameChangeReminder)
	{
		Debug.Log("About to show Name Change Reminder");
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<NameChangeReminderDialog>.instance, 0f);
	}
}
