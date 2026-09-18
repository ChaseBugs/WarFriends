using UnityEngine;

[RequireComponent(typeof(NavigationAgent))]
public class NavigationTester : Core_BaseScript
{
	public Transform target;

	public bool setNewTarget;

	private NavigationAgent mNavigationAgent;

	protected override void Awake()
	{
		base.Awake();
		mNavigationAgent = GetComponent<NavigationAgent>();
	}

	protected void Update()
	{
		base.Awake();
		if (setNewTarget)
		{
			setNewTarget = false;
			mNavigationAgent.SetDestination(target.position);
		}
	}
}
