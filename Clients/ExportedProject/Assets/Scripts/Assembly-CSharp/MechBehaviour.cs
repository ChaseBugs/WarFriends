using System.Collections.Generic;
using UnityEngine;

public class MechBehaviour : LevelBehaviour
{
	public MechBehaviourDefinititon baseVehicleDefinititon;

	public VehicleBehaviourDefinititon vehicleDefinititon { get; set; }

	public override BehaviourDefinititon baseBehaviourDefinititon => baseVehicleDefinititon;

	public MechBehaviourDefinititon mechDefinition
	{
		get
		{
			return (MechBehaviourDefinititon)base.behaviourDefinition;
		}
		set
		{
			base.behaviourDefinition = value;
		}
	}

	public override void Unload()
	{
		if (base.unitModel != null)
		{
			List<string> list = new List<string>();
			SkinnedMeshRenderer[] componentsInChildren = base.unitModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
			SkinnedMeshRenderer[] array = componentsInChildren;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array)
			{
				Resources.UnloadAsset(skinnedMeshRenderer.sharedMesh);
			}
		}
		base.Unload();
	}
}
