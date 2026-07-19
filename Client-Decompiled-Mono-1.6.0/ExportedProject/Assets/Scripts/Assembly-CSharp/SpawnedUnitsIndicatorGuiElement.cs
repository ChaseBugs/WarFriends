public class SpawnedUnitsIndicatorGuiElement : GuiElementSingle<SpawnedUnitsIndicatorGuiElement>
{
	public UnitIndicator BKOBMOHOPKH;

	private ObjectPool IHFILHIAGLG;

	private float NBCFDNMKCOC;

	public virtual void ILCKGHGDDJA()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += ILBGMCGEBIE;
		NBCFDNMKCOC = 1998f;
	}

	private void GNECKMGIIKC(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != GHPGNELIDBM.Allies)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.AAIBNGPFKGF(BKOBMOHOPKH, base.gameObject, string.Format("ID_MISSION_BOSSINCOMING_HUD", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[1];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 497f;
	}

	public virtual void LMNNNHJKMFP()
	{
	}

	public virtual void AAPGEAEKKGF()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += IHENONLPMMG;
		NBCFDNMKCOC = 1807f;
	}

	public virtual void GOMEJLFFKJM()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += AHNGHFCAKHK;
		NBCFDNMKCOC = 1267f;
	}

	public virtual void HHLOGFGGHHD()
	{
	}

	private void KCJENHADCHH(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.ICINKELJCAH() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)3)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.LCLKFGNHCOF(BKOBMOHOPKH, base.gameObject, string.Format("game-card-ico-stroke", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.ACPFCAMFEAJ(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1396f;
	}

	private void LBDALMLDEAD(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != (GHPGNELIDBM)7)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.OKEAAILFPIG(BKOBMOHOPKH, base.gameObject, string.Format("UseOnGetPlayerData", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[1];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.ACPFCAMFEAJ(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1146f;
	}

	public virtual void OILPJONILBG()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += CCJFOLFOKFJ;
		NBCFDNMKCOC = 315f;
	}

	private void IHENONLPMMG(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.OJHIKLMNHNE() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)6)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.AAIBNGPFKGF(BKOBMOHOPKH, base.gameObject, string.Format("ID_DELIVERNOW", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1738f;
	}

	public virtual void NINGMLNMLLP()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += GNECKMGIIKC;
		NBCFDNMKCOC = 1020f;
	}

	private void HACPCPLJIMD(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != GHPGNELIDBM.None)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.OKEAAILFPIG(BKOBMOHOPKH, base.gameObject, string.Format("elite1", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 997f;
	}

	private void CCJFOLFOKFJ(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.ICINKELJCAH() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)7)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.LCLKFGNHCOF(BKOBMOHOPKH, base.gameObject, string.Format("Rank", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 116f;
	}

	private void AHFCAFGNJEI(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.ICINKELJCAH() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)8)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.AAIBNGPFKGF(BKOBMOHOPKH, base.gameObject, string.Format("PARCELABLE_WRITE_RETURN_VALUE", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[1];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 839f;
	}

	public virtual void EMGHCAHOJNC()
	{
	}

	public virtual void DFLGLEJIPCO()
	{
	}

	public virtual void NAHMANAGNNO()
	{
	}

	public override void InitGUIValues()
	{
	}

	public virtual void PGJDLKDMCHN()
	{
	}

	public virtual void AIIIDDDAPGB()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += BGCPJNHDLFM;
		NBCFDNMKCOC = 179f;
	}

	public virtual void KPMLFMMINEP()
	{
	}

	public override void InitControls()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		AIObject.AfterSpawned += NMBIPNICPOO;
		NBCFDNMKCOC = 0f;
	}

	private void BGCPJNHDLFM(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != (GHPGNELIDBM)5)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.AAIBNGPFKGF(BKOBMOHOPKH, base.gameObject, string.Format("#AccoutCheck# possibly change GC during tutorial", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1202f;
	}

	private void NMBIPNICPOO(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != GHPGNELIDBM.Allies)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.InstantiateAsChild(BKOBMOHOPKH, base.gameObject, string.Format("Indicator {0}", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 2f;
	}

	public virtual void PBLLMABJFDM()
	{
	}

	public virtual void BAAOGDMJCLK()
	{
	}

	private void AHNGHFCAKHK(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.ICINKELJCAH() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)4)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.AAIBNGPFKGF(BKOBMOHOPKH, base.gameObject, string.Format("Prefabs", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.ACPFCAMFEAJ(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1394f;
	}

	public virtual void NAOJCFMFLLA()
	{
	}

	private void EKLPOFAMLJK(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != GHPGNELIDBM.Enemies)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.OKEAAILFPIG(BKOBMOHOPKH, base.gameObject, string.Format("ID_TUTORIAL_SWIPE_UP", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[1];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.ACPFCAMFEAJ(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 1802f;
	}

	public virtual void OFCCACPEBHD()
	{
	}

	private void ILBGMCGEBIE(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.isTutorialStage1 || KLHPCPKJGOC.fraction != (GHPGNELIDBM)5)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.LCLKFGNHCOF(BKOBMOHOPKH, base.gameObject, string.Format("D2", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[1];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.InitAndShow(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 510f;
	}

	private void IHKPEBIILCB(AIObject KLHPCPKJGOC)
	{
		if (!Singleton<GameController>.instance.OJHIKLMNHNE() || KLHPCPKJGOC.fraction != (GHPGNELIDBM)6)
		{
			return;
		}
		EnemyController enemyController = KLHPCPKJGOC as EnemyController;
		if (!(enemyController != null))
		{
			return;
		}
		UnitIndicator unitIndicator = (UnitIndicator)IHFILHIAGLG.InstantiateAsChild(BKOBMOHOPKH, base.gameObject, string.Format("AdWillClose()", enemyController.name));
		SpawningManagerDeathMatch.ArmyUnit armyUnit = Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG[0];
		foreach (SpawningManagerDeathMatch.ArmyUnit item in Singleton<SpawningManagerDeathMatch>.instance.HCEDGKDKKIG)
		{
			if (item.behaviour == enemyController.IAJJBAJOGDM)
			{
				armyUnit = item;
			}
		}
		unitIndicator.ACPFCAMFEAJ(armyUnit.menuIcon, enemyController, NBCFDNMKCOC);
		NBCFDNMKCOC += 990f;
	}
}
