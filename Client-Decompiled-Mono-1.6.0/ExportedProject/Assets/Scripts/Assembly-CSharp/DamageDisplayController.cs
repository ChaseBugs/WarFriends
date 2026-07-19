using UnityEngine;

public class DamageDisplayController : Core_BaseScript
{
	public Transform PMJDGAIKLIM;

	private void MHCAGLKFFBL(DestroyableObject ENCEFOOPBMK, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && playerController.isCurrentPlayer && KMJKKNFDFMM.EPDELOGPNAC != 471f)
		{
			DamageDisplayer damageDisplayer = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.JPJMPMDKMHK(Singleton<ObjectPoolDatabase>.instance.EMONHGIAHLD) as DamageDisplayer;
			if (damageDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
				damageDisplayer.transform.position = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				damageDisplayer.LCCEEAMLHDD(KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.NLJFIIEGHCK, KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal);
			}
		}
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += NJKBOAPNKHP;
	}

	private void OEGGCCAPENN(DestroyableObject ENCEFOOPBMK, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && playerController.isCurrentPlayer && KMJKKNFDFMM.EPDELOGPNAC != 1990f)
		{
			DamageDisplayer damageDisplayer = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.EMONHGIAHLD) as DamageDisplayer;
			if (damageDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
				damageDisplayer.transform.position = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				damageDisplayer.LCCEEAMLHDD(KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.NLJFIIEGHCK, KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion);
			}
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += OEGGCCAPENN;
	}

	private void GDDJNBKOPMH(DestroyableObject ENCEFOOPBMK, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && playerController.isCurrentPlayer && KMJKKNFDFMM.EPDELOGPNAC != 1296f)
		{
			DamageDisplayer damageDisplayer = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.HIIPCMJLGGD(Singleton<ObjectPoolDatabase>.instance.EMONHGIAHLD) as DamageDisplayer;
			if (damageDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
				damageDisplayer.transform.position = HealthBarManager.IPAFHDNJIJP().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				damageDisplayer.BBJADAJPJHH(KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.NLJFIIEGHCK, KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver);
			}
		}
	}

	private void NJKBOAPNKHP(DestroyableObject ENCEFOOPBMK, DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM)
	{
		PlayerController playerController = KMJKKNFDFMM.HNFNINFCBEJ as PlayerController;
		if (playerController != null && playerController.isCurrentPlayer && KMJKKNFDFMM.EPDELOGPNAC != float.MaxValue)
		{
			DamageDisplayer damageDisplayer = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.EMONHGIAHLD) as DamageDisplayer;
			if (damageDisplayer != null)
			{
				Vector3 point = Camera.main.WorldToNormalizedViewportPoint(PMJDGAIKLIM.transform.position);
				damageDisplayer.transform.position = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
				damageDisplayer.Show(KMJKKNFDFMM.EPDELOGPNAC, KMJKKNFDFMM.NLJFIIEGHCK, KMJKKNFDFMM.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Immortal);
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += NJKBOAPNKHP;
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += GDDJNBKOPMH;
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		DestroyableObject componentImplementing = GetComponentImplementing<DestroyableObject>();
		componentImplementing.OnDamage += MHCAGLKFFBL;
	}
}
