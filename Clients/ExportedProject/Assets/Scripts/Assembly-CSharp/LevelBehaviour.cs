using System;
using System.Collections;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
[ExecuteInEditMode]
public abstract class LevelBehaviour : Core_BaseScript
{
	[Skip]
	public enum UnitType
	{
		Defender,
		AttackerExplosive,
		AttackerShooter,
		AttackerRusher
	}

	[Serializable]
	public class BotProperties
	{
		public int dangerCoeficient;

		public bool useExplosive;
	}

	[Header("Bot")]
	public BotProperties botProperties;

	[Header("Spawning")]
	public int maxGeneratedCount = 1;

	[Header("Name + Description")]
	public string unitDictionaryId;

	[HideInInspector]
	public string unitName;

	[HideInInspector]
	public string unitDescription;

	[HideInInspector]
	public string unitAbilityName;

	[HideInInspector]
	public string unitBuffName;

	[HideInInspector]
	public string unitElitePartsName;

	[Header("Type")]
	public UnitType unitType;

	[Header("Special Icon")]
	public string abilityIcon;

	[Header("Elite Icon")]
	public string eliteIcon;

	[Header("Army Screen Model Settings")]
	public Vector3 modelPosition;

	public Vector2 modelStartRotation;

	[Header("Card ID reference")]
	public string cardId;

	[Header("Slots")]
	public UpgradeSlots upgradeSlots;

	[Header("Settings")]
	public int guiOrder;

	public bool isSoldier = true;

	public bool isAir;

	public float prepareForBattleIconPositionY = 80f;

	[Header("Perks")]
	public PerkType perkType;

	public PerkAffects perkAffects;

	public int indexInLevelsManager;

	[SerializeField]
	private string modelPath;

	public GameObject unitModel { get; private set; }

	public string unitTypeName => GameVariables.unitType[unitType].Value1;

	public string unitTypeNameHUD => Localization.Localize(GameVariables.unitType[unitType].Value4);

	public string unitTypeIcon => GameVariables.unitType[unitType].Value2;

	public string unitTypeDescription => GameVariables.unitType[unitType].Value3;

	public int dangerCoef
	{
		get
		{
			if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null && upgradeSlots.armyUpgradesRow.DANGERCOEFICIENT > 0)
			{
				return upgradeSlots.armyUpgradesRow.DANGERCOEFICIENT;
			}
			return botProperties.dangerCoeficient;
		}
	}

	public int totalPower
	{
		get
		{
			if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null)
			{
				return upgradeSlots.totalPower;
			}
			return 0;
		}
	}

	public float coolDown
	{
		get
		{
			if (upgradeSlots != null && upgradeSlots.armyUpgradesRow != null)
			{
				return upgradeSlots.coolDown;
			}
			return 0f;
		}
	}

	public BehaviourDefinititon behaviourDefinition { get; set; }

	public LevelBehaviour unitNeededForPromotion
	{
		get
		{
			int num = upgradeSlots.actualTier + 1;
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.unitType == unitType && behaviour.upgradeSlots.startTier == num)
				{
					return behaviour;
				}
			}
			return null;
		}
	}

	public abstract BehaviourDefinititon baseBehaviourDefinititon { get; }

	public string GetAbilityDescriptionWithColours(string startingColour)
	{
		string text = Colours.stringWhite + upgradeSlots.upgradeSlotSpecial.abilityValue + startingColour;
		return Localization.LocalizeFormat(unitDictionaryId + "-ABILITYMAXDESC", text, upgradeSlots.upgradeSlotSpecial.abilityMaxValue, upgradeSlots.upgradeSlotSpecial.abilityStartValue);
	}

	public string GetBuffDescriptionWithColours(string startingColour)
	{
		string text = Colours.stringWhite + upgradeSlots.upgradeSlotElite.buffValue + startingColour;
		return Localization.LocalizeFormat(unitDictionaryId + "-BUFFMAXDESC", text, upgradeSlots.upgradeSlotElite.buffMaxValue, upgradeSlots.upgradeSlotElite.buffStartValue);
	}

	public virtual bool CanBeSpawned(Fractions f, int numberOfEnemies)
	{
		return true;
	}

	public virtual void Init(AIObject aiObject)
	{
	}

	protected virtual void Update()
	{
	}

	private void LoadModel()
	{
		if (unitModel == null && !string.IsNullOrEmpty(modelPath))
		{
			unitModel = Resources.Load<GameObject>(modelPath);
		}
	}

	public virtual IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades unitUpgrades, bool bought, bool mine, bool unloadWeapon = false)
	{
		if (bought)
		{
			LoadSounds();
			LoadModel();
		}
		if (mine)
		{
			yield return StartCoroutine(upgradeSlots.LoadMineVisualsCoroutine(unitUpgrades, bought));
		}
		else
		{
			yield return StartCoroutine(upgradeSlots.LoadOponentVisualsCoroutine(unitUpgrades, bought));
		}
	}

	public virtual IEnumerator PrepareVisualsForCardCoroutine(bool mine, bool opponent)
	{
		LoadSounds();
		if (mine)
		{
			yield return StartCoroutine(upgradeSlots.LoadMineVisualsCoroutineCards());
		}
		if (opponent)
		{
			yield return StartCoroutine(upgradeSlots.LoadOpponentVisualsCoroutineCards());
		}
	}

	public void Clear()
	{
		unitModel = null;
	}

	private void LoadSounds()
	{
		foreach (Sounds3DEnum unitSound in upgradeSlots.unitSounds)
		{
			Singleton<SoundsManager3D>.instance.UseSound(unitSound);
		}
	}

	public virtual void Copy(AIObject to)
	{
		to.behaviour = to.gameObject.AddComponent(this);
	}

	public virtual void ReSync()
	{
	}

	public virtual void Unload()
	{
		if (unitModel != null)
		{
			MeshFilter[] componentsInChildren = unitModel.GetComponentsInChildren<MeshFilter>(includeInactive: true);
			MeshFilter[] array = componentsInChildren;
			foreach (MeshFilter meshFilter in array)
			{
				Resources.UnloadAsset(meshFilter.sharedMesh);
			}
		}
		upgradeSlots.UnloadVisuals();
		unitModel = null;
	}

	public Perk MultipleCurrentPerkForUnit(LevelBehaviour behaviour, UnitUpgradeDefinition def, Perk currentPerk, PerkType type)
	{
		if (def.isEquipped && def.unitUpgrades.isElite && PerkAffectBehaviour(behaviour) && type == perkType)
		{
			return upgradeSlots.PerkImplementation(def, currentPerk);
		}
		return currentPerk;
	}

	private bool PerkAffectBehaviour(Behaviour behaviour)
	{
		return PerkUnitCategories.GetUnits(perkAffects).Contains(behaviour.GetType());
	}

	public void SetUpEliteIcon(UISprite eliteSprite, UISprite buffSprite, float multiplier = 0f)
	{
		eliteSprite.spriteName = eliteIcon;
		buffSprite.spriteName = ((perkType != PerkType.Buff) ? "game-elite-debuff1" : "game-elite-buff1");
		if (multiplier > 0f)
		{
			eliteSprite.MakePixelPerfect();
			eliteSprite.transform.localScale = eliteSprite.transform.localScale.MultiplyXY(multiplier);
			buffSprite.MakePixelPerfect();
			buffSprite.transform.localScale = buffSprite.transform.localScale.MultiplyXY(multiplier);
			float y = eliteSprite.transform.localPosition.y;
			buffSprite.transform.localPosition = buffSprite.transform.localPosition.ReplaceY(y - multiplier * 25f);
		}
	}
}
