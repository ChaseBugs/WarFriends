public class DailyAssignmentsReminder : DatabaseMessage
{
	private int mIndex;

	public DailyAssignmentsReminder()
		: base("DailyAssignmentsReminder", Type.SquadLeft)
	{
		messageId += Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	public DailyAssignmentsReminder(int showDialogIndex)
		: base("DailyAssignmentsReminder", Type.SquadLeft)
	{
		messageId += Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		mIndex = showDialogIndex;
	}

	public override void Show()
	{
		base.Show();
		if (mIndex == 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<StarterAssignmentDialog>.instance, 0f);
		}
		else if (mIndex == 2)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyAssignmentsDialog>.instance, 0f);
		}
		else if (StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<StarterAssignmentDialog>.instance, 0f);
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DailyAssignmentsDialog>.instance, 0f);
		}
	}
}
