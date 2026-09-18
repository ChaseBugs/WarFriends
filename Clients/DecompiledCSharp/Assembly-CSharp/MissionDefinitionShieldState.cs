using System;

[Serializable]
public class MissionDefinitionShieldState
{
	public float healthRatio = 1f;

	public float maxHealthRatio = 1f;

	public bool regenerate = true;

	public bool autoRepair = true;
}
