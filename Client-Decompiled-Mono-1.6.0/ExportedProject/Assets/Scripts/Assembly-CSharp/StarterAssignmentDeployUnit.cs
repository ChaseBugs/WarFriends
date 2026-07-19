public class StarterAssignmentDeployUnit : StarterAssignment
{
	protected override int numberId
	{
		get
		{
			return 3;
		}
	}

	public override string text
	{
		get
		{
			return Localization.Localize("ID_STARTERASSIGNMENT" + numberId);
		}
	}

	public override string textProgress
	{
		get
		{
			int indexInLevelsManager = Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourSniper).Name].indexInLevelsManager;
			bool bought = LevelManager.instance.behaviours[indexInLevelsManager].upgradeSlots.bought;
			bool flag = StatsManager.instance.data.unitsDeployedSpecific.ContainsKey(indexInLevelsManager) && StatsManager.instance.data.unitsDeployedSpecific[indexInLevelsManager] > 0;
			int num = 0;
			if (bought)
			{
				num++;
			}
			if (flag)
			{
				num++;
			}
			return string.Format("({0}\u00a0/\u00a0{1})", num, 2);
		}
	}

	public override bool Evaluate()
	{
		int indexInLevelsManager = Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourSniper).Name].indexInLevelsManager;
		int num = (StatsManager.instance.data.unitsDeployedSpecific.ContainsKey(indexInLevelsManager) ? StatsManager.instance.data.unitsDeployedSpecific[indexInLevelsManager] : 0);
		if (!base.completed && num >= 1)
		{
			base.completed = true;
			return true;
		}
		return false;
	}
}
