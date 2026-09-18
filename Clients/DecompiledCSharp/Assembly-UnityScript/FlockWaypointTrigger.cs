using System;
using UnityEngine;

[Serializable]
public class FlockWaypointTrigger : MonoBehaviour
{
	public float _timer;

	public FlockChild _flockChild;

	public FlockWaypointTrigger()
	{
		_timer = 1f;
	}

	public virtual void Start()
	{
		if (!_flockChild)
		{
			_flockChild = (FlockChild)transform.parent.GetComponent(typeof(FlockChild));
		}
		float num = UnityEngine.Random.Range(_timer, _timer * 3f);
		InvokeRepeating("Trigger", num, num);
	}

	public virtual void Trigger()
	{
		_flockChild.Wander(0f);
	}

	public virtual void Main()
	{
	}
}
