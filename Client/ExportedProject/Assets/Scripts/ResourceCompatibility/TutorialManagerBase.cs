using System.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting;

public class TutorialManagerBase : InGameSerializedObjectGeneric<TutorialManagerBase.TutorialData>
{
	[Preserve]
	public class TutorialData
	{
		public bool started;

		public bool overtimeShowed;

		public int gold;

		public int wb;
	}

	public List<PoolableObject> bulletsPrefabs;

	public GrenadeAmmoBase grenade;

	private bool mHasEnergyForAll;

	private float mNextSpawnTime;

	protected PlayerBotTutorial mPlayerBotTutorial;

	protected bool mSpawn2;

	private bool mSpawnCheck;

	protected bool mWaitForSpawn;

	protected bool mShowDeployHint;

	private float m_NextSpawnTimePause;

	public PoolableObject missile;

	private List<PoolableObject> soldiers;

	protected bool isNearEnd;

	public virtual bool autoDeployEnabled => false;

	public bool isTutorialRunning { get; protected set; }

	public bool isTutorialNearEnd => false;

	public virtual void FinishTutorial()
	{
	}

	public virtual void StartTutorial(bool isContinue)
	{
	}

	protected void SetPlayerDefaultWeapons(bool enableRifle = false, bool enableSniper = false, bool enableGrenade = false)
	{
	}

	protected void FreezeEnemies()
	{
	}

	protected void StartTapAnimationOnSoldiersToDeploy()
	{
	}

	protected void StartTapAnimationOnSoldiersToDeploy(LevelBehaviour.UnitType type)
	{
	}

	protected void UnfreezeEnemies()
	{
	}

	protected virtual void AfterSpawned(AIObject aiObject)
	{
	}

	protected IEnumerator SpawnCheckWithPause(float time)
	{
		return null;
	}

	protected IEnumerator SpawnCheck(float time = 13f)
	{
		return null;
	}
}
