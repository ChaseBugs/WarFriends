using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public abstract class LevelBehaviour : Core_BaseScript
{
	public enum UnitType
	{
		Defender,
		AttackerExplosive,
		AttackerShooter,
		AttackerRusher
	}

	public enum Purchaseable
	{
		Shop,
		Loyalty,
		Skip
	}

	public enum HybridType
	{
		None,
		DefenderExplosive,
		RusherDefender,
		ShooterDefender,
		ExplosiveShooter,
		ExplosiveRusher
	}

	[Serializable]
	public class BotProperties
	{
		public int dangerCoeficient;

		public bool useExplosive;
	}

	public BotProperties botProperties;

	public int maxGeneratedCount;

	public string unitDictionaryId;

	public UnitType unitType;

	public HybridType hybridType;

	public string abilityIcon;

	public string eliteIcon;

	public Vector3 modelPosition;

	public Vector2 modelStartRotation;

	public string cardId;

	public UpgradeSlots upgradeSlots;

	public int guiOrder;

	public bool isSoldier;

	public bool isAir;

	public float prepareForBattleIconPositionY;

	public PKJGPADMMML perkType;

	public PerkAffects perkAffects;

	public int indexInLevelsManager;

	public int indexInLevelBehaviourManager;

	public bool IsEliteBaseDifferent;

	[SerializeField]
	private string modelPath;

	[SerializeField]
	private string eliteModelPath;

	public Purchaseable unitPurchaseable => default(Purchaseable);

	public GameObject unitModel { get; private set; }

	public GameObject eliteUnitModel { get; private set; }

	public string unitTypeName => null;

	public string unitTypeNameHUD => null;

	public string unitTypeIcon => null;

	public string unitTypeDescription => null;

	public int priceGold => 0;

	public int priceLoyalty => 0;

	public int dangerCoef => 0;

	public int totalPower => 0;

	public float coolDown => 0f;

	public BehaviourDefinititon behaviourDefinition { get; set; }

	public bool hasCardVariant => false;

	public bool hasInvaderVariant => false;

	public string unitName { get; set; }

	public string unitDescription { get; set; }

	public string unitAbilityName { get; set; }

	public string unitBuffName { get; set; }

	public string unitElitePartsName { get; set; }

	public LevelBehaviour unitNeededForPromotion => null;

	public abstract BehaviourDefinititon baseBehaviourDefinititon { get; }

	public virtual string GetAbilityDescriptionWithColours(string startingColour)
	{
		return null;
	}

	public string GetBuffDescriptionWithColours(string startingColour)
	{
		return null;
	}

	public virtual bool CanBeSpawned(HPHFGNJPDKN f, int numberOfEnemies)
	{
		return false;
	}

	public virtual void Init(AIObject aiObject)
	{
	}

	public virtual void PresetOnStart()
	{
	}

	protected virtual void Update()
	{
	}

	private void LoadModel()
	{
	}

	public virtual IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades unitUpgrades, bool bought, bool mine, bool unloadWeapon = false)
	{
		return null;
	}

	public virtual IEnumerator PrepareVisualsForCardCoroutine(bool mine, bool opponent)
	{
		return null;
	}

	public void Clear()
	{
	}

	private void LoadSounds()
	{
	}

	public virtual void Copy(AIObject to)
	{
	}

	public virtual void ReSync()
	{
	}

	public virtual void Unload()
	{
	}

	public virtual void DestroyBehaviour()
	{
	}

	public FEPKHDHDKII MultipleCurrentPerkForUnit(LevelBehaviour behaviour, UnitUpgradeDefinition def, FEPKHDHDKII currentPerk, PKJGPADMMML type)
	{
		return null;
	}

	private bool PerkAffectBehaviour(Behaviour behaviour)
	{
		return false;
	}

	public void SetUpEliteIcon(UISprite eliteSprite, UISprite buffSprite, float multiplier = 0f)
	{
	}

	public virtual MissionUnit GetMissionConfig(List<MissionUnit> configUnits)
	{
		return null;
	}
}
