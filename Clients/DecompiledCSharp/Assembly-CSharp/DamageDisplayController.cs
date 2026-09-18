using UnityEngine;

public class DamageDisplayController : Core_BaseScript
{
	public Transform mPosition;

	protected override void Awake()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += DestroyableObjectOnDamage;
	}

	private void DestroyableObjectOnDamage(DestroyableObject obj, DestroyableObject.DamageInfo info)
	{
		PlayerController playerController = info.owner as PlayerController;
		if (playerController != null && playerController.isCurrentPlayer && info.damageAmount != float.MaxValue)
		{
			DamageDisplayer damageDisplayer = Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.damageDisplayer) as DamageDisplayer;
			if (damageDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(mPosition.transform.position);
				damageDisplayer.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
				damageDisplayer.Show(info.damageAmount, info.isCritical, info.type == DestroyableObject.DamageType.Immortal);
			}
		}
	}
}
