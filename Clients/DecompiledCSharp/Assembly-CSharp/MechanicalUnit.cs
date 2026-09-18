using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MechanicalUnit<T> : AIObjectG<T> where T : LevelBehaviour
{
	[FormerlySerializedAs("vehicleVisuals")]
	public VehicleVisuals visuals;

	public VehicleEngine engine;

	public UnitModelLoader modelLoader;

	public override void UpdatePreview(bool inGame)
	{
		base.UpdatePreview(inGame);
		UpdateVisuals();
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		UpdateVisuals();
	}

	protected virtual void UpdateVisuals()
	{
		if (visuals == null)
		{
			return;
		}
		if (base.spawnedByCard)
		{
			if (base.currentBeh.upgradeSlots.cardVisuals != null)
			{
				visuals.SetVisuals(base.currentBeh.upgradeSlots.cardVisuals, fraction == PlayerController.currentPlayer.fraction);
			}
		}
		else
		{
			List<TechnologyVisualDefinition> currentVisuals = base.currentBeh.upgradeSlots.GetVisuals(unitUpgrades);
			visuals.SetVisuals(currentVisuals, isPrewiev || fraction == PlayerController.currentPlayer.fraction);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (modelLoader != null)
		{
			modelLoader.LoadModel(preparedBehaviour.unitModel);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (engine != null)
		{
			engine.StartEngine();
		}
	}

	protected override void OnKilled(DestroyableObject.DamageInfo arg3)
	{
		StopAllCoroutines();
		base.OnKilled(arg3);
		if (engine != null)
		{
			engine.OnDeath();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if ((bool)visuals)
		{
			visuals.NullTextures();
		}
		if (engine != null)
		{
			engine.OnDestroy();
		}
		if (modelLoader != null)
		{
			modelLoader.Reset();
		}
	}

	public override void GetAudioSources(List<AudioSource> list)
	{
		base.GetAudioSources(list);
		if (engine != null && engine.audioSource != null)
		{
			list.Add(engine.audioSource);
		}
	}
}
