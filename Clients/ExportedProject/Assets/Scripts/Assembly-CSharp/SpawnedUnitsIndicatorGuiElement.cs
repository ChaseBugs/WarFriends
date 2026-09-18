public class SpawnedUnitsIndicatorGuiElement : GuiElementSingle<SpawnedUnitsIndicatorGuiElement>
{
	public UnitIndicator unitIndicatorPrefab;

	private ObjectPool mPool;

	private float positionZ;

	public override void InitControls()
	{
		mPool = Singleton<GuiManager>.instance.objectPool;
		AIObject.AfterSpawned += OnAfterSpawned;
		positionZ = 0f;
	}

	public override void InitGUIValues()
	{
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || aiObject.fraction != Fractions.Allies)
		{
			return;
		}
		EnemyController enemyController = aiObject as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)mPool.InstantiateAsChild(unitIndicatorPrefab, base.gameObject, "Indicator " + enemyController.name);
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.armyDefinitions[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit armyDefinition in Singleton<SpawningManagerDeathMatch>.instance.armyDefinitions)
		{
			if (armyDefinition.behaviour == enemyController.preparedBehaviour)
			{
				armyUnit = armyDefinition;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, positionZ);
		positionZ += 2f;
	}
}
