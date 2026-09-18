using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class KillStreakBonusGrenades : KillStreakBonus
{
	private Grenade mGrenade;

	public int numberOfgrenades = 3;

	public int maxDistance = 3;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		if (base.ActivateBonus(killStreakBonusBox, player))
		{
			Singleton<KillStreakManager>.instance.StartCoroutine(SpawnGrenades(killStreakBonusBox, player));
			return true;
		}
		return false;
	}

	private IEnumerator SpawnGrenades(GameObject killStreakBonusBox, PlayerController player)
	{
		mGrenade = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		mGrenade.spawnPoint = killStreakBonusBox.transform;
		mGrenade.owner = player;
		List<GameShootableEntity> enemies = GameShootableEntity.GetOpponents(PlayerController.currentPlayer.fraction);
		GameObject killStreakBonusBox2 = default(GameObject);
		enemies.Sort(delegate(GameShootableEntity a, GameShootableEntity b)
		{
			float sqrMagnitude = (killStreakBonusBox2.transform.position - a.transform.position).sqrMagnitude;
			float sqrMagnitude2 = (killStreakBonusBox2.transform.position - b.transform.position).sqrMagnitude;
			return sqrMagnitude.CompareTo(sqrMagnitude2);
		});
		int min = Mathf.Min(numberOfgrenades, enemies.Count);
		yield return new WaitForSeconds(1f);
		int shots = 0;
		if (enemies.Count > 0)
		{
			for (int i = 0; i < min; i++)
			{
				if (i >= 0 && i < enemies.Count)
				{
					GameShootableEntity enemy = enemies[i];
					if (Vector3.Distance(enemy.transform.position, killStreakBonusBox.transform.position) < (float)maxDistance)
					{
						shots++;
						mGrenade.Fire(enemy.transform.position);
						yield return new WaitForSeconds(0.2f);
					}
				}
			}
		}
		for (int j = shots; j < numberOfgrenades; j++)
		{
			GrenadeAmmoSetup setup = (GrenadeAmmoSetup)mGrenade.ammoSetup;
			if ((bool)setup)
			{
				float explodeDamage = Mathf.Lerp(t: (float)player.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel, a: Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, b: Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE);
				setup.explodeDamageAmount = explodeDamage;
				setup.damageAmount = explodeDamage * 0.1f;
			}
			mGrenade.Fire(killStreakBonusBox.transform.position + new Vector3(Random.Range(-1.5f, 1.5f), 0f, Random.Range(-1.5f, 1.5f)));
			yield return new WaitForSeconds(0.2f);
		}
		yield return new WaitForSeconds(1f);
	}
}
