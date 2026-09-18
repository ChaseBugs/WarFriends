using System.Collections.Generic;

public class DestroyableObjectMultipleParts : DestroyableObject
{
	public DestroyableObjectpart[] parts;

	protected override void Awake()
	{
		base.Awake();
		parts = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 0; i < parts.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = parts[i];
			if (destroyableObjectpart.ownerDestroyableObject != null && destroyableObjectpart.ownerDestroyableObject != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.ownerDestroyableObject = this;
			destroyableObjectpart.shotParticleNames = shotParticleNames;
			destroyableObjectpart.shotHitSound = shotHitSound;
			destroyableObjectpart.playMainHitParticle = playMainHitParticle;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.shotCoeficient = shotCoeficient;
			destroyableObjectpart.index = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] array = parts;
		parts = new DestroyableObjectpart[array.Length - list.Count];
		int num = 0;
		foreach (DestroyableObjectpart destroyableObjectpart2 in array)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				parts[num] = destroyableObjectpart2;
				num++;
			}
		}
		array = null;
	}

	public override bool DoDamage(DamageInfo info, DestroyableObject obj)
	{
		return base.DoDamage(info, obj);
	}

	public void ResetWeights()
	{
		if (parts != null)
		{
			for (int i = 0; i < parts.Length; i++)
			{
				parts[i].ResetWeight();
			}
		}
	}

	public override void ChangeLayer(Fractions fraction, bool isFlying)
	{
		base.ChangeLayer(fraction, isFlying);
		DestroyableObjectpart[] array = parts;
		foreach (DestroyableObjectpart destroyableObjectpart in array)
		{
			destroyableObjectpart.ChangeLayer(fraction, isFlying);
		}
	}
}
