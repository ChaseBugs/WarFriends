using System.Collections;
using UnityEngine;

public class KillStreakBonusTurret : KillStreakBonus
{
	public override void BeforeGameStarted()
	{
		base.BeforeGameStarted();
		Singleton<KillStreakManager>.instance.StartCoroutine(LoadAssets());
	}

	private IEnumerator LoadAssets()
	{
		foreach (TechnologyVisualDefinition technologyVisualDefinition in Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour.upgradeSlots.cardVisuals)
		{
			yield return Singleton<KillStreakManager>.instance.StartCoroutine(technologyVisualDefinition.LoadMineAsync());
			yield return Singleton<KillStreakManager>.instance.StartCoroutine(technologyVisualDefinition.LoadOpponentAsync());
		}
	}

	public override void SceneFreed()
	{
		base.SceneFreed();
		foreach (TechnologyVisualDefinition cardVisual in Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour.upgradeSlots.cardVisuals)
		{
			cardVisual.NullMine();
			cardVisual.NullOpponent();
		}
	}

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		if (base.ActivateBonus(killStreakBonusBox, player))
		{
			float progress = (float)player.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
			Plane plane = new Plane(Vector3.up, PlayerController.currentPlayer.currentPlayerPoint.point.transform.position);
			Ray ray = new Ray(killStreakBonusBox.transform.position, Vector3.down);
			Vector3 sourcePosition = killStreakBonusBox.transform.position;
			if (plane.Raycast(ray, out var enter))
			{
				sourcePosition = ray.GetPoint(enter);
			}
			NavMesh.SamplePosition(sourcePosition, out var hit, 20f, 1);
			Vector3 position = hit.position;
			SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour, 1, progress, player.fraction, position, spawnEnabled: false);
			return true;
		}
		return false;
	}
}
