using System.Collections.Generic;
using UnityEngine;

public class ObjectPerformanceActivatorEx : Core_BaseScript
{
	public Performance minPerformance;

	public Performance maxPerformance = Performance.Best;

	[Tooltip("Objects which should be activated or deactivated based on performance criteria. If this list is empty the logic is aplied to this gameobject.")]
	public List<GameObject> gameObjects;

	protected override void Awake()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance >= minPerformance && Singleton<PerformanceManager>.instance.performance <= maxPerformance;
		if (gameObjects.Count > 0)
		{
			for (int i = 0; i < gameObjects.Count; i++)
			{
				gameObjects[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}
}
