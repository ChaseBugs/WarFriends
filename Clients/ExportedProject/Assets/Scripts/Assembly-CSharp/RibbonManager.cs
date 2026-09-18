using System;
using System.Collections.Generic;

public class RibbonManager : Singleton<RibbonManager>
{
	[Serializable]
	public class RibbonItemDefinition
	{
		public string name;

		public string description;

		public SkillShot.SkillShotType skillShotType;

		public int amountOfSkillshots;

		public int rewardMin;

		public int rewardMax;

		public int counter;

		public string iconName => "game-ribbon-" + skillShotType.ToString().ToLower();

		public string iconBgName => iconName + "-bg";

		public int warbucks
		{
			get
			{
				int displayNumber = LevelManager.instance.currentLevel.displayNumber;
				int maxDisplayLevel = LevelManager.instance.maxDisplayLevel;
				float num = (float)rewardMin + (float)(rewardMax - rewardMin) / (float)(maxDisplayLevel - 3) * (float)(displayNumber - 3);
				return (int)Math.Round(num);
			}
		}
	}

	public List<RibbonItemDefinition> ribbons;

	public event Action RibbonsChanged;

	protected override void Awake()
	{
		base.Awake();
		Singleton<SkillShotManager>.instance.SkillshotsChanged += CheckForRibbons;
		Singleton<GameController>.instance.GameStarted += Restart;
	}

	private void Restart()
	{
		foreach (RibbonItemDefinition ribbon in ribbons)
		{
			ribbon.counter = 0;
		}
	}

	private void CheckForRibbons()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			return;
		}
		Dictionary<SkillShot.SkillShotType, int> skillShotCounts = Singleton<ScoreManager>.instance.skillShotCounts;
		bool flag = false;
		bool flag2 = RibbonGuiElement.events.Count == 0;
		foreach (RibbonItemDefinition ribbon in ribbons)
		{
			int num = (ribbon.counter + 1) * ribbon.amountOfSkillshots;
			if (skillShotCounts[ribbon.skillShotType] >= num)
			{
				ribbon.counter++;
				flag = true;
				RibbonGuiElement.events.Enqueue(ribbon);
			}
		}
		if (this.RibbonsChanged != null && flag && flag2)
		{
			this.RibbonsChanged();
		}
	}

	public Dictionary<RibbonItemDefinition, int> GetRibbons(Dictionary<SkillShot.SkillShotType, int> skillshots)
	{
		Dictionary<RibbonItemDefinition, int> dictionary = new Dictionary<RibbonItemDefinition, int>();
		if (skillshots != null)
		{
			foreach (RibbonItemDefinition ribbon in ribbons)
			{
				dictionary.Add(ribbon, 0);
				if (skillshots.ContainsKey(ribbon.skillShotType) && skillshots[ribbon.skillShotType] >= ribbon.amountOfSkillshots)
				{
					Dictionary<RibbonItemDefinition, int> dictionary3;
					Dictionary<RibbonItemDefinition, int> dictionary2 = (dictionary3 = dictionary);
					RibbonItemDefinition key2;
					RibbonItemDefinition key = (key2 = ribbon);
					int num = dictionary3[key2];
					dictionary2[key] = num + skillshots[ribbon.skillShotType] / ribbon.amountOfSkillshots;
				}
			}
		}
		return dictionary;
	}

	public int GetRibbonsWorth(Dictionary<RibbonItemDefinition, int> ribbonsDic)
	{
		int num = 0;
		foreach (KeyValuePair<RibbonItemDefinition, int> item in ribbonsDic)
		{
			num += item.Value * item.Key.warbucks;
		}
		return num;
	}

	public int GetWarBucksFromRibbons()
	{
		return GetRibbonsWorth(GetRibbons(Singleton<ScoreManager>.instance.skillShotCounts));
	}

	public int GetRibbonIndex(string name)
	{
		for (int i = 0; i < ribbons.Count; i++)
		{
			for (int j = 0; j < ribbons.Count; j++)
			{
				if (ribbons[i].skillShotType.ToString() == name)
				{
					return i;
				}
			}
		}
		return 0;
	}
}
