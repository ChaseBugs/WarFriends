using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class KillStreakBonus : Core_BaseScript
{
	public static List<KillStreakBonus> activeBonusses = new List<KillStreakBonus>();

	public string dictionaryTranslationId;

	[Multiline]
	[SerializeField]
	protected string bonusName = "Bonus Name";

	public string iconName;

	public string bgSuffix = string.Empty;

	public virtual string fullName
	{
		get
		{
			return bonusName;
		}
		set
		{
			bonusName = value;
		}
	}

	public virtual bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		return true;
	}

	public virtual float GetBonusProbability(PlayerController owner)
	{
		CratesRow row = Singleton<KillStreakManager>.instance.crates.GetRow(base.name);
		if (row == null)
		{
			return 0f;
		}
		if (Singleton<GameController>.instance.isWarArena)
		{
			return row.PROBABILITYARENA;
		}
		return row.PROBABILITY;
	}

	public void Init()
	{
		bonusName = Localization.Localize(dictionaryTranslationId);
	}

	public virtual void BeforeGameStarted()
	{
	}

	public virtual void SceneFreed()
	{
	}
}
