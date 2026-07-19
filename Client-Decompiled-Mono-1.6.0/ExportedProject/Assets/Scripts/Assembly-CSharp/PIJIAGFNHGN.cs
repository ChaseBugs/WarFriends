public abstract class PIJIAGFNHGN : StarterAssignment
{
	public override string text
	{
		get
		{
			return Localization.Localize("ID_STARTERASSIGNMENT6");
		}
	}

	public override string textProgress
	{
		get
		{
			int num = ((DailyMissionsManager.instance.data.heroicPoints > 0) ? 1 : 0);
			return string.Format("({0}\u00a0/\u00a0{1})", num, 1);
		}
	}

	public override bool Evaluate()
	{
		bool flag = DailyMissionsManager.instance.data.heroicPoints > 0;
		if (!base.completed && flag)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
