using System;
using UnityEngine;

[Serializable]
public class RopeAttachedObject
{
	public GameObject go;

	public RopeAttachmentJointType jointType;

	public int jointIndex;

	public Vector3 hingeAxis;

	public Joint jointRef;
}
