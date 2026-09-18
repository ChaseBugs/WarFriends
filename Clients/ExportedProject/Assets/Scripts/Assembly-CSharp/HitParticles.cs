using UnityEngine;

public class HitParticles : Core_BaseScript
{
	public enum ParticleType
	{
		Other,
		Blood
	}

	private Transform mSnapTransform;

	public ParticleType particleType;

	public ParticleSystem Play(HitParticleSystem hitParticleSystem, Transform transform1)
	{
		GetComponent<ParticleSystem>().Clear(withChildren: true);
		GetComponent<ParticleSystem>().Play();
		InvokeAfter(delegate
		{
			hitParticleSystem.spawnPool.Despawn(base.transform);
		}, GetComponent<ParticleSystem>().duration + GetComponent<ParticleSystem>().startLifetime + 0.5f);
		mSnapTransform = transform1;
		return GetComponent<ParticleSystem>();
	}

	protected void Update()
	{
		if (mSnapTransform != null)
		{
			base.transform.position = mSnapTransform.position;
		}
	}

	public ParticleSystem Play(HitParticleSystem hitParticleSystem)
	{
		GetComponent<ParticleSystem>().Clear(withChildren: true);
		GetComponent<ParticleSystem>().Play();
		InvokeAfter(delegate
		{
			hitParticleSystem.spawnPool.Despawn(base.transform);
		}, GetComponent<ParticleSystem>().duration + GetComponent<ParticleSystem>().startLifetime + 0.5f);
		mSnapTransform = null;
		return GetComponent<ParticleSystem>();
	}
}
