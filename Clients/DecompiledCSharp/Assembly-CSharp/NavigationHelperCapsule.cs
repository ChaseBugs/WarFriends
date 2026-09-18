using UnityEngine;

[RequireComponent(typeof(PhysicsEventsListener))]
public class NavigationHelperCapsule : Core_BaseScript
{
	public int navigationHelperCapsuleLayerNumber;

	private CapsuleCollider mCapsuleCollider;

	private float mRayCastDistance = 0.37f;

	public NavigationAgent navigationAgent;

	private Ray mRay;

	private int mMask;

	private Vector3 frontRayCastPos => base.transform.position + navigationAgent.direction.normalized * (mCapsuleCollider.radius + 0.01f);

	protected override void Awake()
	{
		base.Awake();
		mCapsuleCollider = GetComponent<CapsuleCollider>();
		base.gameObject.layer = navigationHelperCapsuleLayerNumber;
	}

	protected void Update()
	{
		if (DebugSettings.debugAI)
		{
			CameraLineRenderer.DrawSphere(frontRayCastPos + navigationAgent.direction.normalized * mRayCastDistance, mCapsuleCollider.radius * 0.8f, (!navigationAgent.isObstacleAvoiding) ? Color.cyan : Color.magenta);
			CameraLineRenderer.DrawCross(base.transform.position + navigationAgent.direction.normalized * (mRayCastDistance + mCapsuleCollider.radius), 0.2f, Color.red);
			CameraLineRenderer.DrawLine(base.transform.position, base.transform.position + navigationAgent.direction.normalized * (mRayCastDistance + mCapsuleCollider.radius), Color.green);
		}
	}

	public bool ShouldAvoid(out RaycastHit hit)
	{
		mRay = new Ray(base.transform.position, navigationAgent.direction);
		mMask = 1 << navigationHelperCapsuleLayerNumber;
		if (Physics.Raycast(mRay, out hit, mRayCastDistance + mCapsuleCollider.radius, mMask) && hit.collider.gameObject != base.gameObject)
		{
			if (DebugSettings.debugAI)
			{
				CameraLineRenderer.DrawCross(base.transform.position + new Vector3(0f, 0.4f, 0f), 0.25f, Color.red);
			}
			Vector3 vector = navigationAgent.destnation - base.transform.position;
			vector.y = 0f;
			Vector3 vector2 = hit.collider.gameObject.transform.position - base.transform.position;
			vector2.y = 0f;
			if (vector.sqrMagnitude < vector2.sqrMagnitude)
			{
				return false;
			}
			return true;
		}
		return false;
	}
}
