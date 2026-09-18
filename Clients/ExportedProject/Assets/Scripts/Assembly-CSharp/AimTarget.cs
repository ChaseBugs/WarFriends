using System;
using UnityEngine;

public class AimTarget : Core_BaseScript
{
	private Vector3 mLastPosition;

	private Vector3 mVel;

	public GameObject targetCollider;

	public Vector3 offset;

	public bool isClickable;

	public int clickableLayer;

	public AimTarget referenceVelocityTarget;

	public bool isActive = true;

	public bool ignoreLayer;

	public Vector3 velocity
	{
		get
		{
			if (referenceVelocityTarget != null)
			{
				return referenceVelocityTarget.velocity;
			}
			return mVel;
		}
	}

	public Vector3 targetPosition => targetCollider.transform.position + offset;

	public event Action Clicked;

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.layer = TagsAndLayers.aimingHelpLayerNumber;
	}

	protected void Update()
	{
		mVel = (base.transform.position - mLastPosition) / Time.deltaTime;
		mLastPosition = base.transform.position;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		if (targetCollider != null)
		{
			Gizmos.DrawWireCube(targetCollider.transform.position + offset, Vector3.one * 0.1f);
		}
	}

	public void Click()
	{
		if (this.Clicked != null)
		{
			this.Clicked();
		}
	}
}
