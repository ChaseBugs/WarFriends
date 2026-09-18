using System;
using UnityEngine;

public class DroneSteering : Core_BaseScript
{
	public float breakDistance = 1f;

	public float breakSpeed = 0.4f;

	public bool dir = true;

	public bool loop;

	private int mCurPathIndex;

	private int mPathLength;

	private Vector3 mSt;

	private float mStPom;

	private WayPoint mTargetPoint;

	private bool mUsingWayPoints;

	private Vector3 mVel;

	public float mass = 1f;

	public float multiplier = 1f;

	public WayPointPath path;

	public float speed = 0.8f;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	private float anglePom;

	public float cornerDelayTime = 0.1f;

	public float gizmoSize = 100f;

	public Transform lookTarget;

	private float mActual;

	private DestroyableObject mDestroyableObject;

	private Quaternion mHorizontal = Quaternion.identity;

	private PhotonView mPhotonView;

	private float mPointReachedTime;

	private Rigidbody mRigidBody;

	private Transform mTransform;

	private Quaternion mVertical = Quaternion.identity;

	private float mStayTime;

	public new bool enabled { get; set; }

	public event Action<WayPoint> ArrivedToWayPoint;

	protected override void Awake()
	{
		base.Awake();
		mTransform = base.transform;
		mRigidBody = GetComponent<Rigidbody>();
		mPhotonView = GetComponent<PhotonView>();
	}

	protected Ammo.ShotType GetShotType(GameShootableEntity.ShotTarget target)
	{
		if (target.type == GameShootableEntity.ShotTargetType.Shield)
		{
			return Ammo.ShotType.Shield;
		}
		return Ammo.ShotType.Real;
	}

	public void SetWayPoint(WayPoint point, MainGameEntity owner)
	{
		mPathLength = point.path.wayPoints.Count;
		mCurPathIndex = point.index;
		mTargetPoint = point;
		mUsingWayPoints = true;
		path = point.path;
		point.path.usedByEntity = owner;
	}

	private void FixedUpdate()
	{
		if (!mRigidBody.isKinematic)
		{
			mRigidBody.AddForce(Vector3.up * 8f + mVel / Time.deltaTime * 2f, ForceMode.Force);
		}
	}

	protected void Update()
	{
		if (mPhotonView.isMine)
		{
			if (!enabled || !mUsingWayPoints || !(Time.timeScale > 0.1f) || !(mTargetPoint != null) || !(path != null))
			{
				return;
			}
			if (Vector3.Distance(mTransform.position, mTargetPoint.transform.position) < path.Radius)
			{
				bool flag = true;
				if (mTargetPoint.stayTime > 0f)
				{
					if (mStayTime == 0f)
					{
						mPointReachedTime = Time.time;
						if (this.ArrivedToWayPoint != null)
						{
							this.ArrivedToWayPoint(mTargetPoint);
						}
					}
					mStayTime += Time.deltaTime;
					if (mStayTime < mTargetPoint.stayTime)
					{
						flag = false;
					}
				}
				else
				{
					mPointReachedTime = Time.time;
					if (this.ArrivedToWayPoint != null)
					{
						this.ArrivedToWayPoint(mTargetPoint);
					}
				}
				if (flag)
				{
					mStayTime = 0f;
					if (UnityEngine.Random.value < 0.1f)
					{
						dir = !dir;
					}
					if (mCurPathIndex < mPathLength - 1 && dir)
					{
						mCurPathIndex++;
						mTargetPoint = path.wayPoints[mCurPathIndex];
					}
					else if (mCurPathIndex != 0 && !dir)
					{
						mCurPathIndex--;
						mTargetPoint = path.wayPoints[mCurPathIndex];
					}
					else if (loop && dir)
					{
						mCurPathIndex = 0;
						mTargetPoint = path.wayPoints[mCurPathIndex];
					}
					else
					{
						if (!loop || dir)
						{
							mUsingWayPoints = false;
							return;
						}
						mCurPathIndex = mPathLength - 1;
						mTargetPoint = path.wayPoints[mCurPathIndex];
					}
				}
			}
			if (mCurPathIndex < mPathLength)
			{
				mSt = Steer(mTargetPoint.transform.position, bFinalPoint: true);
				mVel += mSt;
				mTransform.position += mVel;
				Vector3 axis = Vector3.Cross(Vector3.up, mVel);
				anglePom = Mathf.Lerp(anglePom, GeometryTools.AngleSigned(mSt, mVel, Vector3.up), Time.deltaTime * 5f);
				if ((anglePom > 0f && anglePom < 90f) || (anglePom < -270f && anglePom > -360f))
				{
					mStPom = mSt.magnitude / Time.deltaTime;
				}
				else
				{
					mStPom = (0f - mSt.magnitude) / Time.deltaTime;
				}
				if (lookTarget != null)
				{
					Vector3 forward = mTransform.position - lookTarget.position;
					forward.y = 0f;
					mVertical = Quaternion.Slerp(mVertical, Quaternion.LookRotation(forward), Time.deltaTime * 5f);
				}
				mHorizontal = Quaternion.Slerp(mHorizontal, Quaternion.AngleAxis(mStPom * multiplier / 60f, axis), Time.deltaTime);
				mTransform.rotation = mVertical * mHorizontal;
			}
		}
		else if (mRigidBody.isKinematic && Singleton<GameController>.instance.gameIsRunning)
		{
			mPhotonTransform.Update(mTransform);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(base.transform.position, base.transform.position + mVel * gizmoSize);
		Gizmos.color = Color.red;
		Gizmos.DrawLine(base.transform.position, base.transform.position + mSt * gizmoSize);
	}

	private Vector3 Steer(Vector3 target, bool bFinalPoint = false)
	{
		float deltaTime = Time.deltaTime;
		if (Time.time < mPointReachedTime + cornerDelayTime)
		{
			return default(Vector3);
		}
		Vector3 vector = target - mTransform.position;
		Vector3 normalized = vector.normalized;
		if (bFinalPoint && vector.magnitude < breakDistance)
		{
			float num = vector.magnitude / breakDistance;
			normalized *= breakSpeed * deltaTime * num;
		}
		else
		{
			normalized *= speed * deltaTime;
		}
		Vector3 vector2 = normalized - mVel;
		return vector2 / mass;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		mPhotonTransform.OnPhotonSerializeView(mTransform, stream, info);
	}

	public void Clear()
	{
		if (path != null)
		{
			path.usedByEntity = null;
			path = null;
		}
	}

	public void FallDown()
	{
		mRigidBody.isKinematic = false;
		enabled = false;
	}

	public void Init()
	{
		mRigidBody.isKinematic = true;
		enabled = true;
		mPhotonTransform.Reset();
	}
}
