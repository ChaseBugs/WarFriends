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
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnTriggerExit(Collider other)
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}
}
