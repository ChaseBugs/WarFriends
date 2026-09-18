using UnityEngine;

public static class TaskHelpers
{
	public static WaitForAnimation WaitForAnimation(this GameObject go, string name, float time = 1f)
	{
		return new WaitForAnimation(go, name, time, -1f);
	}

	public static WaitForAnimation WaitForAnimationWeight(this GameObject go, string name, float weight = 0f)
	{
		return new WaitForAnimation(go, name, 0f, weight);
	}
}
