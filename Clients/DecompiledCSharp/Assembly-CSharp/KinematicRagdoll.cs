using System;
using UnityEngine;

public class KinematicRagdoll : MonoBehaviour
{
	private Rigidbody[] rigidbodies;

	private Transform[] rigidTransforms;

	private Vector3[] lastRigidPositions = new Vector3[1];

	private Vector3[] rigidVelocities = new Vector3[1];

	private Vector3[] rigidAngularVelocities = new Vector3[1];

	private Quaternion[] lastRigidRotations = new Quaternion[1];

	[Range(0f, 1f)]
	public float velocityLerp = 0.2f;

	[Range(0f, 1f)]
	public float keepAngularMomentum = 0.4f;

	[Range(0f, 240f)]
	public float angularDrag = 30f;

	[Range(0f, 4f)]
	public float drag = 0.5f;

	private float maxAngularVelocity = 100f;

	public bool useGravity = true;

	public bool ragdolled;

	private void Awake()
	{
		rigidbodies = GetComponentsInChildren<Rigidbody>();
		int newSize = rigidbodies.Length;
		Array.Resize(ref rigidTransforms, newSize);
		Array.Resize(ref lastRigidPositions, newSize);
		Array.Resize(ref rigidVelocities, newSize);
		Array.Resize(ref lastRigidRotations, newSize);
		Array.Resize(ref rigidAngularVelocities, newSize);
		newSize = 0;
		Rigidbody[] array = rigidbodies;
		foreach (Rigidbody rigidbody in array)
		{
			rigidTransforms[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 0;
		Transform[] array2 = rigidTransforms;
		foreach (Transform transform in array2)
		{
			ref Vector3 reference = ref lastRigidPositions[newSize];
			reference = transform.position;
			ref Quaternion reference2 = ref lastRigidRotations[newSize];
			reference2 = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = useGravity;
			transform.GetComponent<Rigidbody>().angularDrag = angularDrag;
			transform.GetComponent<Rigidbody>().drag = drag;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("There are no rigid body components on the ragdoll " + base.name);
		}
	}

	private void FixedUpdate()
	{
		if (!(velocityLerp > 0f) || ragdolled)
		{
			return;
		}
		int num = rigidTransforms.Length;
		for (int i = 0; i < num; i++)
		{
			ref Vector3 reference = ref rigidVelocities[i];
			reference = Vector3.Lerp(rigidVelocities[i], (rigidTransforms[i].position - lastRigidPositions[i]) / Time.fixedDeltaTime, velocityLerp);
			if (keepAngularMomentum > 0f)
			{
				(rigidTransforms[i].rotation * Quaternion.Inverse(lastRigidRotations[i])).ToAngleAxis(out var angle, out var axis);
				ref Vector3 reference2 = ref rigidAngularVelocities[i];
				reference2 = Vector3.Lerp(rigidAngularVelocities[i], axis.normalized * angle / Time.fixedDeltaTime, velocityLerp);
				if (float.IsNaN(rigidAngularVelocities[i].x) || float.IsNaN(rigidAngularVelocities[i].y) || float.IsNaN(rigidAngularVelocities[i].z))
				{
					ref Vector3 reference3 = ref rigidAngularVelocities[i];
					reference3 = Vector3.zero;
				}
				ref Quaternion reference4 = ref lastRigidRotations[i];
				reference4 = rigidTransforms[i].rotation;
			}
			ref Vector3 reference5 = ref lastRigidPositions[i];
			reference5 = rigidTransforms[i].position;
		}
	}

	public void GoRagdoll()
	{
		int num = 0;
		Transform[] array = rigidTransforms;
		foreach (Transform transform in array)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (velocityLerp > 0f)
			{
				component.velocity = rigidVelocities[num].ReplaceY(Mathf.Max(0.001f, component.velocity.y));
				if (keepAngularMomentum > 0f)
				{
					component.angularVelocity = rigidAngularVelocities[num] * keepAngularMomentum;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = angularDrag;
			component.drag = drag;
			num++;
		}
	}

	public void ResetRagdoll()
	{
		for (int i = 0; i < rigidTransforms.Length; i++)
		{
			Transform transform = rigidTransforms[i];
			ref Vector3 reference = ref lastRigidPositions[i];
			reference = transform.position;
			ref Quaternion reference2 = ref lastRigidRotations[i];
			reference2 = transform.rotation;
			ref Vector3 reference3 = ref rigidVelocities[i];
			reference3 = Vector3.zero;
			ref Vector3 reference4 = ref rigidAngularVelocities[i];
			reference4 = Vector3.zero;
		}
	}
}
