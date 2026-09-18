using System.Collections.Generic;
using UnityEngine;

public class HitParticleSystem : Singleton<HitParticleSystem>
{
	public SpawnPool normalSpawnPool;

	public SpawnPool metalSpawnPool;

	public List<HitParticles> allNormalHitParticlesPrefabs;

	public List<HitParticles> allMetalHitParticlesPrefabs;

	public Dictionary<string, int> particlesIndices;

	private SpawnPool mSpawnPool;

	private List<HitParticles> mAllHitParticlesPrefabs;

	public SpawnPool spawnPool => mSpawnPool;

	protected override void Awake()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance == Performance.Best)
		{
			mSpawnPool = metalSpawnPool;
			mAllHitParticlesPrefabs = allMetalHitParticlesPrefabs;
		}
		else
		{
			mSpawnPool = normalSpawnPool;
			mAllHitParticlesPrefabs = allNormalHitParticlesPrefabs;
		}
		mSpawnPool.gameObject.SetActive(value: true);
		particlesIndices = new Dictionary<string, int>();
		for (int i = 0; i < mAllHitParticlesPrefabs.Count; i++)
		{
			HitParticles hitParticles = mAllHitParticlesPrefabs[i];
			particlesIndices.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem PlayParticle(Vector3 position, Vector3 normal, int index)
	{
		if (mAllHitParticlesPrefabs[index].particleType == HitParticles.ParticleType.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = mSpawnPool.Spawn(mAllHitParticlesPrefabs[index].transform, position, Quaternion.LookRotation(normal)).GetComponent<HitParticles>();
		return component.Play(this);
	}

	public void PlayParticles(Vector3 position, Vector3 normal, params string[] names)
	{
		foreach (string text in names)
		{
			PlayParticle(position, normal, text);
		}
	}

	public ParticleSystem PlayParticle(Vector3 position, Vector3 normal, string name)
	{
		if (particlesIndices.TryGetValue(name, out var value))
		{
			return PlayParticle(position, normal, value);
		}
		Debug.LogError("Particle with name: " + name + "doesnt exist");
		return null;
	}

	public ParticleSystem PlayParticle(Transform transform, Vector3 normal, string name)
	{
		if (particlesIndices.TryGetValue(name, out var value))
		{
			return PlayParticle(transform, normal, value);
		}
		Debug.LogError("Particle with name: " + name + "doesnt exist");
		return null;
	}

	private ParticleSystem PlayParticle(Transform transform, Vector3 normal, int index)
	{
		HitParticles component = mSpawnPool.Spawn(mAllHitParticlesPrefabs[index].transform, transform.position, Quaternion.LookRotation(normal)).GetComponent<HitParticles>();
		return component.Play(this, transform);
	}

	public void HideAllParticles(HitParticles.ParticleType particlesType)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in mSpawnPool.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.particleType != particlesType)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				mSpawnPool.Despawn(item);
			}
		}
	}
}
