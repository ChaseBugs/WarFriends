using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

[ExecuteInEditMode]
public class SkillShotManager : Singleton<SkillShotManager>, IFraction, IGameMainEntity
{
	[Serializable]
	public class SkillShotItemDefinition
	{
		[SerializeField]
		public string dictionaryId;

		[SerializeField]
		public string menuName;

		[SerializeField]
		public SkillShot.SkillShotType skillShotType;

		[SerializeField]
		public string iconName;

		public SkillshotsRow row;

		public int points
		{
			get
			{
				if (Singleton<GameController>.instance.isMission)
				{
					return row.SCORESINGLE;
				}
				return row.SCOREMP;
			}
		}
	}

	public float longShotKillDistance = 4f;

	public float timeForCombo = 1f;

	public bool regenerate;

	private float mLastKillTime;

	private int mKillStreak;

	public List<SkillShotItemDefinition> skillShotItemDefinitions;

	public ObjectPool objectPool;

	public Fractions fraction
	{
		get
		{
			return Fractions.Allies;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public IFraction owner => this;

	public int power { get; set; }

	public bool isAlive { get; set; }

	public event Action SkillshotsChanged;

	public event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;

	public event Action<IGameMainEntity, Fractions, Fractions> FractionChanged;

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		objectPool = ObjectPool.GetPool("ObjectPool");
		foreach (SkillShotItemDefinition skillShotItemDefinition in skillShotItemDefinitions)
		{
			skillShotItemDefinition.menuName = Localization.Localize(skillShotItemDefinition.dictionaryId);
			skillShotItemDefinition.iconName = "game-skillshot-" + skillShotItemDefinition.skillShotType.ToString().ToLower();
		}
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
	}

	private void OnPlayerDataLoaded()
	{
		Skillshots component = GetComponent<Skillshots>();
		Singleton<RibbonManager>.instance.ribbons = new List<RibbonManager.RibbonItemDefinition>();
		foreach (SkillShotItemDefinition skillShotItemDefinition in skillShotItemDefinitions)
		{
			SkillshotsRow row = component.GetRow(skillShotItemDefinition.skillShotType.ToString());
			if (row != null)
			{
				skillShotItemDefinition.row = row;
				if (row.RIBBONCOUNT > 0)
				{
					Singleton<RibbonManager>.instance.ribbons.Add(new RibbonManager.RibbonItemDefinition
					{
						skillShotType = skillShotItemDefinition.skillShotType,
						name = Localization.Localize(skillShotItemDefinition.dictionaryId),
						description = Localization.LocalizeFormat(skillShotItemDefinition.dictionaryId + "_DESC", row.RIBBONCOUNT),
						amountOfSkillshots = row.RIBBONCOUNT,
						rewardMin = row.RIBBONREWARDMINWB,
						rewardMax = row.RIBBONREWARDMAXWB
					});
				}
			}
			else
			{
				Debug.LogError("Dont have excel row for skillshot: " + skillShotItemDefinition.skillShotType);
			}
		}
	}

	public void RecieveKill(ref SkillShot skillShot)
	{
		if (Time.time < mLastKillTime + timeForCombo)
		{
			mKillStreak++;
		}
		else
		{
			mKillStreak = 1;
		}
		mLastKillTime = Time.time;
		if (mKillStreak == 2)
		{
			skillShot.type |= SkillShot.SkillShotType.DoubleKill;
		}
		if (mKillStreak == 3)
		{
			skillShot.type |= SkillShot.SkillShotType.TrippleKill;
		}
		if (mKillStreak > 3)
		{
			skillShot.type |= SkillShot.SkillShotType.MultiKill;
		}
	}

	public void AddSkillshot(SkillShot skillShot, PlayerController playerController)
	{
		foreach (SkillShotItemDefinition skillShotItemDefinition in skillShotItemDefinitions)
		{
			if ((skillShot.type & skillShotItemDefinition.skillShotType) == skillShotItemDefinition.skillShotType)
			{
				Singleton<ScoreManager>.instance.AddSkillshot(skillShotItemDefinition, playerController);
			}
		}
		if (this.SkillshotsChanged != null)
		{
			this.SkillshotsChanged();
		}
	}

	public void GetItemDefinitions(SkillShot skillShot, ref List<SkillShotItemDefinition> definitions)
	{
		definitions.Clear();
		foreach (SkillShotItemDefinition skillShotItemDefinition in skillShotItemDefinitions)
		{
			if ((skillShot.type & skillShotItemDefinition.skillShotType) == skillShotItemDefinition.skillShotType)
			{
				definitions.Add(skillShotItemDefinition);
			}
		}
	}

	public SkillShotItemDefinition GetItemDefinition(SkillShot.SkillShotType skillShot)
	{
		foreach (SkillShotItemDefinition skillShotItemDefinition in skillShotItemDefinitions)
		{
			if (skillShotItemDefinition.skillShotType == skillShot)
			{
				return skillShotItemDefinition;
			}
		}
		return null;
	}

	public SkillShot.SkillShotType GetSkillshot(string name)
	{
		return (SkillShot.SkillShotType)(int)Enum.Parse(typeof(SkillShot.SkillShotType), name);
	}

	public SkillShotItemDefinition GetSkillshotDefinition(SkillShot.SkillShotType skillshot)
	{
		for (int i = 0; i < skillShotItemDefinitions.Count; i++)
		{
			if (skillShotItemDefinitions[i].skillShotType == skillshot)
			{
				return skillShotItemDefinitions[i];
			}
		}
		return skillShotItemDefinitions[0];
	}
}
