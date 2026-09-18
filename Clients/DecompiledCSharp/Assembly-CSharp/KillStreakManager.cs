using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class KillStreakManager : Singleton<KillStreakManager>
{
	private class BonusActivation
	{
		public KillStreakBonusBox box;

		public double shotTime;

		public PlayerController player;
	}

	public List<KillStreakBonus> bonusesPrefabs;

	private Queue<int> alliesBonusses = new Queue<int>();

	private Queue<int> enemyBonusses = new Queue<int>();

	public KillStreakBonusBox killStreakBonusBoxPrefab;

	public BonusTakeDisplayer bonusTakeDisplayerPrefab;

	public KillStreakBonus boobyTrapBonus;

	public Tuple<bool, bool> canBoobyTrap;

	private PhotonView mPhotonView;

	private int mLastBonusIndex;

	public int numberOfDestroyedBoxesInLastGame;

	private Dictionary<int, BonusActivation> bonusesActivations = new Dictionary<int, BonusActivation>();

	public Crates crates { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		Singleton<GameController>.instance.BeforeGameStarted += InstanceOnBeforeGameStarted;
		Singleton<GameController>.instance.SceneFreed += InstanceOnSceneFreed;
		mPhotonView = GetComponent<PhotonView>();
		foreach (KillStreakBonus bonusesPrefab in bonusesPrefabs)
		{
			bonusesPrefab.Init();
		}
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += InstanceOnPlayerDataLoaded;
		canBoobyTrap = new Tuple<bool, bool>(val1: false, val2: false);
	}

	private void InstanceOnSceneFreed()
	{
		foreach (KillStreakBonus bonusesPrefab in bonusesPrefabs)
		{
			bonusesPrefab.SceneFreed();
		}
	}

	private void InstanceOnBeforeGameStarted()
	{
		foreach (KillStreakBonus bonusesPrefab in bonusesPrefabs)
		{
			bonusesPrefab.BeforeGameStarted();
		}
	}

	private void InstanceOnPlayerDataLoaded()
	{
		crates = GetComponent<Crates>();
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.playerBehindShieldRatio = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerBehindShieldConstant).FLOATVALUE;
				explosiveSetup.damageToPlayerCoeficient = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerDamageConstant).FLOATVALUE;
				explosiveSetup.damageToPlayerOvertimeCoeficient = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerDamageOvertimeConstant).FLOATVALUE;
			}
		}
	}

	private void InstanceOnGameStarted()
	{
		alliesBonusses.Clear();
		enemyBonusses.Clear();
		Tuple<bool, bool> tuple = canBoobyTrap;
		bool flag = false;
		canBoobyTrap.Value2 = flag;
		tuple.Value1 = flag;
		KillStreakBonus.activeBonusses = new List<KillStreakBonus>();
		numberOfDestroyedBoxesInLastGame = 0;
		bonusesActivations.Clear();
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(killStreakBonusBoxPrefab);
	}

	public void GenerateNewBonus(PlayerController owner)
	{
		InvokeAfter(delegate
		{
			SpawnBonus(owner);
		}, 1.5f);
	}

	public void EnqueueNewBonus(int index, Fractions fraction)
	{
		if (fraction == Fractions.Allies)
		{
			alliesBonusses.Enqueue(index);
		}
		else
		{
			enemyBonusses.Enqueue(index);
		}
	}

	private void SpawnBonus(PlayerController owner)
	{
		KillStreakBonus killStreakBonus = bonusesPrefabs[0];
		int i = -1;
		Queue<int> queue = ((owner.fraction != Fractions.Allies) ? enemyBonusses : alliesBonusses);
		if (queue.Count > 0)
		{
			i = queue.Dequeue();
		}
		if (i < 0)
		{
			i = 0;
			float num = 0f;
			for (int j = 0; j < bonusesPrefabs.Count; j++)
			{
				float num2 = ((j != mLastBonusIndex) ? bonusesPrefabs[j].GetBonusProbability(owner) : 0f);
				num += num2;
			}
			float num3 = Random.Range(0f, num);
			num = 0f;
			for (i = 0; i < bonusesPrefabs.Count; i++)
			{
				KillStreakBonus killStreakBonus2 = bonusesPrefabs[i];
				num += ((i != mLastBonusIndex) ? killStreakBonus2.GetBonusProbability(owner) : 0f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = bonusesPrefabs[i];
		}
		mLastBonusIndex = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			SpawnBonus(owner);
			return;
		}
		int num4 = Random.Range(int.MinValue, int.MaxValue);
		if (!(Singleton<MapManager>.instance.currentMapDef != null) || Singleton<MapManager>.instance.currentMapDef.spawnAreas == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.currentMapDef.spawnAreas[Random.Range(0, Singleton<MapManager>.instance.currentMapDef.spawnAreas.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.networkPool.Instantiate(killStreakBonusBoxPrefab, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = owner.fraction == PlayerController.currentPlayer.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			killStreakBonusBox.bonusToActivate = killStreakBonus3;
			killStreakBonusBox.owner = owner;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.redMat : killStreakBonusBox.blueMat);
			killStreakBonusBox.boxID = num4;
			mPhotonView.RPC("SpawnBonusNetwork", PhotonTargets.Others, (byte)killStreakBonusBox.indexInObjectPool, vector, i, (byte)owner.playerNetworkId, num4);
		}
	}

	[PunRPC]
	private void SpawnBonusNetwork(byte boxIndexInObjectPool, Vector3 position, int bonusIndex, byte playerID, int boxId)
	{
		KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)ObjectPoolDatabase.networkPool.ReInstantiate(killStreakBonusBoxPrefab, boxIndexInObjectPool, position, Quaternion.identity);
		if (killStreakBonusBox != null)
		{
			bool flag = PlayerController.players[playerID].fraction == PlayerController.currentPlayer.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			KillStreakBonus bonusToActivate = bonusesPrefabs[bonusIndex];
			killStreakBonusBox.owner = PlayerController.players[playerID];
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.redMat : killStreakBonusBox.blueMat);
			killStreakBonusBox.bonusToActivate = bonusToActivate;
			killStreakBonusBox.boxID = boxId;
		}
	}

	public void TestSpawnBonus()
	{
		SpawnBonus(PlayerController.currentPlayer);
	}

	public void ActivateBonus(KillStreakBonusBox box, PlayerController player)
	{
		bonusesActivations[box.boxID] = new BonusActivation
		{
			shotTime = PhotonNetwork.time,
			box = box,
			player = player
		};
		if (PhotonNetwork.room == null)
		{
			Debug.LogError("PhotonNetwork.room == null!");
			ActivateBonusResultRPC(box.boxID, res: true);
		}
		else if (PhotonNetwork.room.playerCount == 2)
		{
			mPhotonView.RPC("TryActivateBonusRPC", PhotonTargets.Others, box.boxID, PhotonNetwork.time);
		}
		else
		{
			ActivateBonusResultRPC(box.boxID, res: true);
		}
	}

	[PunRPC]
	private void ActivateBonusResultRPC(int id, bool res)
	{
		bonusesActivations[id].box.ActivateBonus(bonusesActivations[id].player, res);
	}

	[PunRPC]
	private void TryActivateBonusRPC(int boxID, double serverTime)
	{
		if (bonusesActivations.ContainsKey(boxID))
		{
			BonusActivation bonusActivation = bonusesActivations[boxID];
			mPhotonView.RPC("ActivateBonusResultRPC", PhotonTargets.Others, boxID, bonusActivation.shotTime > serverTime);
		}
		else
		{
			mPhotonView.RPC("ActivateBonusResultRPC", PhotonTargets.Others, boxID, true);
		}
	}

	public bool CanBoobyTrap(Fractions fraction)
	{
		return (fraction != Fractions.Allies) ? canBoobyTrap.Value2 : canBoobyTrap.Value1;
	}

	public void BoobyTrapSet(bool allowed, Fractions fraction)
	{
		if (fraction == Fractions.Allies)
		{
			canBoobyTrap.Value1 = allowed;
		}
		else
		{
			canBoobyTrap.Value2 = allowed;
		}
		byte b = 0;
		if (canBoobyTrap.Value1)
		{
			b++;
		}
		if (canBoobyTrap.Value2)
		{
			b += 2;
		}
		mPhotonView.RPC("BoobyTrapSetRPC", PhotonTargets.Others, b);
	}

	[PunRPC]
	private void BoobyTrapSetRPC(byte bits)
	{
		canBoobyTrap.Value1 = (bits & 1) > 0;
		canBoobyTrap.Value2 = (bits & 2) > 0;
	}
}
