using System;
using UnityEngine;

public class PhysicsEventsListener : MonoBehaviour
{
	public Action<Collider> onTriggerStay;

	public Action<Collider> onTriggerEnter;

	public Action<Collider> onTriggerExit;

	public Action<Collision> onCollisionEnter;

	private void OnTriggerStay(Collider other)
	{
		if (onTriggerStay != null)
		{
			onTriggerStay(other);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (onTriggerEnter != null)
		{
			onTriggerEnter(other);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (onTriggerExit != null)
		{
			onTriggerExit(other);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (onCollisionEnter != null)
		{
			onCollisionEnter(collision);
		}
	}
}
