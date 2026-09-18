using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class Explosion
{
	public class ExplosionInfo
	{
		public Vector3 position;

		public float explodeDamage;

		public float damageAmount;

		public float deadRadius = 1.1f;

		public float hurtRadius = 1.8f;

		public Vector3 exposionCoef = new Vector3(1.6f, 3f, 1.6f);

		public float additionalUpForce = 5f;

		public IFraction owner;

		public Weapon weapon;

		public float playerBehindShieldRatio = 1f;

		public float playerRadiusCoef = 1f;

		public bool isNetworkCopy;

		public ExplosionType type = ExplosionType.Big;

		public bool isFake;
	}

	public enum ExplosionType
	{
		Small,
		Big,
		Medium,
		Barel,
		Molotov
	}

	public static LinkedList<Tuple<Vector3, float, float, bool>> explosions = new LinkedList<Tuple<Vector3, float, float, bool>>();

	public static void Explode(ExplosionInfo i)
	{
		AddExplosion(i.position, i.deadRadius, i.hurtRadius);
		Singleton<HitParticleSystem>.instance.PlayParticle(i.position + 0.2f * Vector3.up, Vector3.up, 3);
		i.exposionCoef *= 2f;
		i.additionalUpForce *= 1.5f;
		PlayEffects(i.type, i.position);
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		bool flag = false;
		Collider[] array = Physics.OverlapSphere(i.position, i.hurtRadius, TagsAndLayers.destroyableObjectsMask);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			float num = Vector3.Distance(component.transform.position, i.position);
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (destroyableObjectpart != null && destroyableObjectpart.ownerDestroyableObject != null && list.Contains(destroyableObjectpart.ownerDestroyableObject))
				{
					continue;
				}
				list.Add(destroyableObjectpart.ownerDestroyableObject);
			}
			if (num < i.deadRadius)
			{
				Vector3 normalized = (collider.transform.position - i.position).normalized;
				float num2 = (i.deadRadius - num) / i.deadRadius;
				Vector2 vector = new Vector2(normalized.x, normalized.z);
				vector.x *= i.exposionCoef.x + Random.Range((0f - i.exposionCoef.x) * 0.1f, i.exposionCoef.x * 0.1f) + 0.2f * num2 * i.exposionCoef.x;
				vector.y *= i.exposionCoef.z + Random.Range((0f - i.exposionCoef.z) * 0.1f, i.exposionCoef.z * 0.1f) + 0.2f * num2 * i.exposionCoef.y;
				normalized.x = vector.x;
				normalized.z = vector.y;
				normalized.y = i.additionalUpForce + num2 * i.exposionCoef.y + Random.Range((0f - i.exposionCoef.y) * 0.1f, i.exposionCoef.y * 0.1f);
				component.Explode(normalized, i.explodeDamage, i.weapon, i.owner, i.isNetworkCopy);
				Collider obj = collider;
				component.InvokeAfter(delegate
				{
					Singleton<HitParticleSystem>.instance.PlayParticle(obj.transform.position, Vector3.up, 4);
				}, Random.Range(0.1f, 0.3f));
			}
			else
			{
				float num3 = Mathf.Clamp01(1f - (Vector3.Distance(collider.transform.position, i.position) - i.deadRadius) / (i.hurtRadius - i.deadRadius));
				float damage = Mathf.Lerp(i.damageAmount, i.explodeDamage, num3 * num3);
				component.Shiver(damage, (collider.transform.position - i.position).normalized * 5f, i.weapon, i.owner, i.isNetworkCopy);
			}
		}
	}

	private static void AddExplosion(Vector3 pos, float size1, float size2, bool isPlayer = false)
	{
		if (explosions.Count < 4)
		{
			explosions.AddLast(new LinkedListNode<Tuple<Vector3, float, float, bool>>(new Tuple<Vector3, float, float, bool>(pos, size1, size2, isPlayer)));
			return;
		}
		LinkedListNode<Tuple<Vector3, float, float, bool>> first = explosions.First;
		explosions.RemoveFirst();
		first.Value.Value1 = pos;
		first.Value.Value2 = size1;
		first.Value.Value3 = size2;
		first.Value.Value4 = isPlayer;
		explosions.AddLast(first);
	}

	public static void MissileExplode(ExplosionInfo i)
	{
		AddExplosion(i.position, i.deadRadius, i.hurtRadius);
		i.exposionCoef *= 2f;
		i.additionalUpForce *= 1.5f;
		PlayEffects(i.type, i.position);
		Collider[] array = Physics.OverlapSphere(i.position, i.hurtRadius, TagsAndLayers.destroyableObjectsMask);
		bool flag = false;
		if (i.isFake)
		{
			return;
		}
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		List<Collider> list2 = new List<Collider>(5);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			if (component is Shield && component.healthRatio > 0.01f)
			{
				flag = true;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (destroyableObjectpart.ownerDestroyableObject != null)
				{
					int num = list.IndexOf(destroyableObjectpart.ownerDestroyableObject);
					if (num >= 0)
					{
						float num2 = Vector3.Distance(collider.ClosestPointOnBounds(i.position), i.position);
						float num3 = Vector3.Distance(list2[num].ClosestPointOnBounds(i.position), i.position);
						if (num2 < num3)
						{
							list2[num] = collider;
						}
						continue;
					}
				}
				list.Add(destroyableObjectpart.ownerDestroyableObject);
				list2.Add(collider);
			}
			else
			{
				list.Add(component);
				list2.Add(collider);
			}
		}
		for (int k = 0; k < list.Count; k++)
		{
			DestroyableObject destroyableObject = list[k];
			Vector3 a = list2[k].ClosestPointOnBounds(i.position);
			float num4 = Vector3.Distance(a, i.position);
			float num5 = 1f;
			float num6 = 1f;
			if (destroyableObject is DestroyableObjectPlayer)
			{
				num6 = i.playerRadiusCoef;
				AddExplosion(i.position, i.deadRadius, i.hurtRadius, isPlayer: true);
			}
			if (destroyableObject is DestroyableObjectPlayer && flag)
			{
				num5 *= i.playerBehindShieldRatio;
			}
			if (destroyableObject is Shield)
			{
				num5 *= (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ShieldExplosionCoef).FLOATVALUE;
			}
			if (num4 < i.deadRadius * num6)
			{
				Vector3 normalized = (destroyableObject.transform.position - i.position).normalized;
				float num7 = (i.deadRadius - num4) / i.deadRadius;
				Vector2 vector = new Vector2(normalized.x, normalized.z);
				vector.x *= i.exposionCoef.x + Random.Range((0f - i.exposionCoef.x) * 0.1f, i.exposionCoef.x * 0.1f) + 0.2f * num7 * i.exposionCoef.x;
				vector.y *= i.exposionCoef.z + Random.Range((0f - i.exposionCoef.z) * 0.1f, i.exposionCoef.z * 0.1f) + 0.2f * num7 * i.exposionCoef.y;
				normalized.x = vector.x;
				normalized.z = vector.y;
				normalized.y = i.additionalUpForce + num7 * i.exposionCoef.y + Random.Range((0f - i.exposionCoef.y) * 0.1f, i.exposionCoef.y * 0.1f);
				destroyableObject.Explode(normalized, i.explodeDamage * num5, i.weapon, i.owner, i.isNetworkCopy);
				DestroyableObject obj = destroyableObject;
				if (Vector3.Distance(i.position, obj.transform.position) <= 1f)
				{
					destroyableObject.InvokeAfter(delegate
					{
						Singleton<HitParticleSystem>.instance.PlayParticle(obj.transform.position, Vector3.up, 4);
					}, Random.Range(0.1f, 0.3f));
				}
			}
			else if (num4 <= i.hurtRadius * num6)
			{
				float num8 = Mathf.Clamp01(1f - (Vector3.Distance(destroyableObject.transform.position, i.position) - i.deadRadius) / (i.hurtRadius - i.deadRadius));
				float num9 = Mathf.Lerp(i.damageAmount, i.explodeDamage, num8 * num8);
				destroyableObject.Shiver(num9 * num5, (destroyableObject.transform.position - i.position).normalized * 5f, i.weapon, i.owner, i.isNetworkCopy);
			}
		}
	}

	public static void PlayEffects(ExplosionType explosionType, Vector3 position)
	{
		Sounds3DEnum soundEnum = Sounds3DEnum.ExplosionMedium;
		int index = 3;
		switch (explosionType)
		{
		case ExplosionType.Big:
			soundEnum = Sounds3DEnum.ExplosionBig;
			index = 4;
			break;
		case ExplosionType.Small:
			soundEnum = Sounds3DEnum.ExplosionSmall;
			index = 3;
			break;
		case ExplosionType.Barel:
			soundEnum = Sounds3DEnum.ExplosionBarel;
			index = 3;
			break;
		case ExplosionType.Molotov:
			soundEnum = Sounds3DEnum.ExplosionMolotov;
			index = 3;
			break;
		}
		Singleton<SoundsManager3D>.instance.Play(position, soundEnum);
		Singleton<HitParticleSystem>.instance.PlayParticle(position + 0.2f * Vector3.up, Vector3.up, index);
	}
}
