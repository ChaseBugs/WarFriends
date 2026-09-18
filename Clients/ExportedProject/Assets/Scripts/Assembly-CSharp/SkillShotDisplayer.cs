using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShotDisplayer : PoolableObject
{
	private List<SkillShotManager.SkillShotItemDefinition> res = new List<SkillShotManager.SkillShotItemDefinition>();

	private List<SkillShotDisplayerItem> mSkillShotDisplayerItems;

	private int mPower;

	public bool isPlaying { get; private set; }

	public void PlayDeath(int power, SkillShot skillShot)
	{
		if (DebugSettings.instance.data.showHud)
		{
			isPlaying = true;
			Singleton<SkillShotManager>.instance.GetItemDefinitions(skillShot, ref res);
			mPower = power;
			StartCoroutine(Show());
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		isPlaying = false;
	}

	private IEnumerator Show()
	{
		Vector3 pos = new Vector3(6f, 6.5f, 0f);
		mSkillShotDisplayerItems = new List<SkillShotDisplayerItem>();
		pos += 0.5f * Vector3.up;
		bool showDeployIcon = false;
		foreach (SkillShotManager.SkillShotItemDefinition skillShotItemDefinition in res)
		{
			if (skillShotItemDefinition.skillShotType == SkillShot.SkillShotType.Kill)
			{
				showDeployIcon = true;
			}
			if (skillShotItemDefinition.skillShotType == SkillShot.SkillShotType.ArmyKill)
			{
				showDeployIcon = true;
			}
		}
		if (showDeployIcon & (mPower > 0))
		{
			DeathMatchUnitsGuiElement.instance.DeployEnergyIconAnimation(base.transform.position, mPower);
		}
		foreach (SkillShotManager.SkillShotItemDefinition skillShotItemDefinition2 in res)
		{
			pos += 6f * Vector3.up;
			SkillShotDisplayerItem obj = Singleton<SkillShotManager>.instance.objectPool.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayerItem, pos, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
			if (obj != null)
			{
				obj.Play(skillShotItemDefinition2);
				mSkillShotDisplayerItems.Add(obj);
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LabelShowGame);
			}
			yield return new WaitForSeconds(TimeManager.GetTimeScaledInterval(0.15f, ignoreTimeScale: true));
		}
		yield return new WaitForSeconds(3f);
		isPlaying = false;
		DestroyPooled();
	}

	public override void DestroyPooled()
	{
		if (!isPlaying)
		{
			base.DestroyPooled();
		}
	}

	public void PlayCritical()
	{
		Vector3 localPostion = new Vector3(6f, -3f, 0f);
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.objectPool.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayerItem, localPostion, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayCritical();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.Critical);
	}

	public void PlayBoxStolen(bool wasStolen)
	{
		Vector3 localPostion = new Vector3(6f, -6f, 0f);
		if (!wasStolen)
		{
			localPostion.y = 22f;
		}
		SkillShotDisplayerItem skillShotDisplayerItem = Singleton<SkillShotManager>.instance.objectPool.InstantiateAsChild(Singleton<ObjectPoolDatabase>.instance.skillShotDisplayerItem, localPostion, Quaternion.identity, base.gameObject) as SkillShotDisplayerItem;
		if (skillShotDisplayerItem != null)
		{
			skillShotDisplayerItem.PlayBoxStolen(wasStolen);
		}
	}
}
