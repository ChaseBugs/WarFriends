using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraPlayerFollow : Core_BaseScript
{
	[Serializable]
	public class ThirdPersoncameraDefinition
	{
		public float distance = 3f;

		public float distanceScale = 1f;

		[FormerlySerializedAs("forwardScale")]
		public float forward;

		public float fwScale = 1f;

		public float height = 3f;

		public float scale = 1f;

		public float Distance
		{
			get
			{
				return distance * distanceScale;
			}
			set
			{
				distance = value;
			}
		}

		public float Height
		{
			get
			{
				return height * scale;
			}
			set
			{
				height = value;
			}
		}

		public float ForwardScale
		{
			get
			{
				return forward * scale * fwScale;
			}
			set
			{
				forward = value;
			}
		}
	}

	public float damping = 5f;

	public ThirdPersoncameraDefinition definition;

	public GyroController gyroController;

	public float maxShotRotation = 15f;

	private Quaternion q;

	public float rotationDamping = 10f;

	private Vector3 shootDir;

	public bool smoothRotation = true;

	public PlayerController target;

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
	}

	private void InstanceOnGameStarted()
	{
		target = PlayerController.currentPlayer;
	}

	protected void Update()
	{
		if (PlayerController.currentPlayer != null)
		{
			if (target == null)
			{
				target = PlayerController.currentPlayer;
			}
			q = Quaternion.identity;
			Vector3 position = default(Vector3);
			Quaternion rotation = default(Quaternion);
			GetRotPos(ref position, ref rotation);
			base.transform.position = Vector3.Lerp(base.transform.position, position, Time.deltaTime * damping);
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, rotation, Time.deltaTime * rotationDamping);
		}
	}

	public void GetRotPos(ref Vector3 position, ref Quaternion rotation)
	{
		if (PlayerController.currentPlayer != null)
		{
			if (target == null)
			{
				target = PlayerController.currentPlayer;
			}
			q = Quaternion.identity;
			Vector3 aimToMiddleOfMap = target.aimToMiddleOfMap;
			if (aimToMiddleOfMap != Vector3.zero)
			{
				q = Quaternion.LookRotation(aimToMiddleOfMap);
				float num = GeometryTools.AngleSigned(aimToMiddleOfMap, target.aimForward, Vector3.up);
				if (num > 15f)
				{
					q = Quaternion.LookRotation(Quaternion.AngleAxis(15f, -Vector3.up) * target.aimForward);
				}
				if (num < -15f)
				{
					q = Quaternion.LookRotation(Quaternion.AngleAxis(-15f, -Vector3.up) * target.aimForward);
				}
			}
			shootDir = aimToMiddleOfMap;
			Vector3 vector = new Vector3(0f, definition.Height, 0f - definition.Distance);
			vector = q * vector;
			vector = target.transform.position + vector;
			position = vector;
			Vector3 vector2 = Vector3.forward * definition.ForwardScale;
			vector2 = q * vector2;
			vector2 = target.transform.position + vector2;
			rotation = Quaternion.LookRotation(vector2 - position, target.transform.up);
		}
		else
		{
			Debug.LogError("camera not set");
		}
	}

	public void ForceSet()
	{
		Vector3 position = default(Vector3);
		Quaternion rotation = default(Quaternion);
		GetRotPos(ref position, ref rotation);
		base.transform.position = position;
		base.transform.rotation = rotation;
	}
}
