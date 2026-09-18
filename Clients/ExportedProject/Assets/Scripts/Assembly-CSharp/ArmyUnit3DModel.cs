using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ArmyUnit3DModel : Core_BaseScript
{
	[Serializable]
	public class UpgradeSlot
	{
		public Transform slotPosition;

		public int slotID;
	}

	public Transform middle;

	public float scale = 1f;

	public List<UpgradeSlot> slots;
}
