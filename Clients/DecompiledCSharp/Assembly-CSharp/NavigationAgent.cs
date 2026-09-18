using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class NavigationAgent : Core_BaseScript
{
	[SerializeField]
	private NavMeshAgent mAgent;

	[SerializeField]
	private NavigationHelperCapsule mHeplperCapsule;

	private GameObject mObstacle;

	private int mNavMeshLayerMask;

	private bool mIsObstacleAvoiding;

	private Vector3 mAvoidPosition;

	private Vector3 mDestination;

	private float mSpeed;

	private bool mIsStopped;

	public float forceMagnitudeTreshold = 0.0001f;

	public float avoidStopPlanarDistance = 0.35f;

	private bool mShouldNearAvoid;

	public Vector3 flyPos;

	public float mass = 1f;

	private int mCurPathIndex;

	private float mPathLength;

	private Vector3 targetPoint;

	private Vector3 vel;

	private WayPointPath mPath;

	private bool mAnimatingWayPoints;

	public int updateCount = 10;

	private float mUpdateStep;

	private GameObject mShouldNearAvoidObject;

	private GameObject mLastObstacle;

	private bool mIsCol;

	private float mInColTime;

	private Quaternion mFlyRot;

	private float mStayTime;

	private List<Vector3> mWarpCorners = new List<Vector3>();

	private bool mIsWarping;

	private float mWarpProgres;

	public Vector3 desiredVelocity
	{
		get
		{
			if (mAgent.desiredVelocity.sqrMagnitude > 0.05f)
			{
				return mAgent.desiredVelocity;
			}
			return Vector3.zero;
		}
	}

	public Vector3 direction
	{
		get
		{
			Vector3 result = default(Vector3);
			if (mAgent.path.corners.Length > 1)
			{
				result = mAgent.path.corners[1] - base.transform.position;
			}
			result.y = 0f;
			return result;
		}
	}

	public Vector3 velocity
	{
		get
		{
			if (mAgent.velocity.sqrMagnitude > 0.05f)
			{
				return mAgent.velocity;
			}
			return Vector3.zero;
		}
	}

	public float stoppingDistance
	{
		get
		{
			return mAgent.stoppingDistance;
		}
		set
		{
			mAgent.stoppingDistance = value;
		}
	}

	public Vector3 steeringTarget => mAgent.steeringTarget;

	public bool isObstacleAvoiding => mIsObstacleAvoiding;

	public GameObject obstacle => mObstacle;

	public Vector3 destnation => mDestination;

	public Vector3[] corners => mAgent.path.corners;

	public float speed
	{
		get
		{
			return mAgent.speed;
		}
		set
		{
			mAgent.speed = value;
			mSpeed = value;
		}
	}

	public float angularSpeed
	{
		get
		{
			return mAgent.angularSpeed;
		}
		set
		{
			mAgent.angularSpeed = value;
		}
	}

	public bool isStopped => mIsStopped;

	public int curentPathIndex
	{
		get
		{
			return mCurPathIndex;
		}
		set
		{
			mCurPathIndex = value;
		}
	}

	public bool animatingWayPoints => mAnimatingWayPoints;

	public Quaternion flyRot
	{
		set
		{
			mFlyRot = value;
		}
	}

	public float stayTime => mStayTime;

	public PositionTime current
	{
		get
		{
			if (mPath != null && mCurPathIndex < mPath.positions.Count)
			{
				return mPath.positions[mCurPathIndex];
			}
			return default(PositionTime);
		}
	}

	public NavMeshAgent navigationAgent => mAgent;

	public event Action PathEndReached;

	protected override void Awake()
	{
		mPath = base.gameObject.AddComponent<WayPointPath>();
		base.Awake();
		if (mAgent == null)
		{
			mAgent = GetComponent<NavMeshAgent>();
		}
		if (mHeplperCapsule == null)
		{
			mHeplperCapsule = GetComponentInChildren<NavigationHelperCapsule>();
		}
		PhysicsEventsListener component = mHeplperCapsule.GetComponent<PhysicsEventsListener>();
		component.onTriggerEnter = (Action<Collider>)Delegate.Combine(component.onTriggerEnter, new Action<Collider>(OnTriggerEnter));
		PhysicsEventsListener component2 = mHeplperCapsule.GetComponent<PhysicsEventsListener>();
		component2.onTriggerStay = (Action<Collider>)Delegate.Combine(component2.onTriggerStay, new Action<Collider>(OnTriggerStay));
		mHeplperCapsule.navigationAgent = this;
		mAgent.avoidancePriority = UnityEngine.Random.Range(0, 0);
		mNavMeshLayerMask = 1 << NavMesh.GetNavMeshLayerFromName("Walkable");
		mSpeed = mAgent.speed;
	}

	public void Fly(Vector3 toPos, float secondPointDelay = 0f, Quaternion? flyRotation = null)
	{
		mStayTime = 0f;
		mPath.Radius = 0.15f;
		NavMesh.SamplePosition(toPos, out var hit, 10f, 1);
		mPath.positions = new List<PositionTime>
		{
			new PositionTime(base.gameObject.transform.position + Vector3.up * 0.5f, 0f, slowDown: false),
			new PositionTime(hit.position + Vector3.up * 0.5f, secondPointDelay, secondPointDelay > 0f),
			new PositionTime(hit.position, 0f, slowDown: false)
		};
		flyPos = hit.position;
		SetWayPointPath(mPath);
		mFlyRot = Quaternion.LookRotation(hit.position - base.transform.position);
		if (flyRotation.HasValue)
		{
			mFlyRot = flyRotation.Value;
		}
	}

	private void OnTriggerStay(Collider obj)
	{
		mIsCol = true;
		mInColTime += 0.02f;
		if (!(mInColTime > 1f))
		{
			return;
		}
		mInColTime = 0f;
		if (!(Vector3.SqrMagnitude(base.transform.position - mDestination) > Mathf.Pow(mAgent.radius, 2f) * 1.5f))
		{
			return;
		}
		Vector3 vector = base.transform.InverseTransformPoint(obj.transform.position);
		float f = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		if (!(Mathf.Abs(f) < 90f))
		{
			return;
		}
		NavigationHelperCapsule component = obj.gameObject.GetComponent<NavigationHelperCapsule>();
		if (component != null)
		{
			float f2 = GeometryTools.AngleSigned(component.navigationAgent.desiredVelocity, mAgent.desiredVelocity, Vector3.up);
			if (Mathf.Abs(f2) > 45f)
			{
				mShouldNearAvoid = true;
				mShouldNearAvoidObject = obj.gameObject;
				Debug.Log("Near avoid !! " + obj.name);
			}
		}
		else
		{
			Debug.LogError("Bad object with NavigationHelperCapsule LAYER");
		}
	}

	private void OnTriggerEnter(Collider collider)
	{
		mInColTime = 0f;
	}

	public void Stop()
	{
		if (!isStopped)
		{
			mAgent.Stop();
			mIsObstacleAvoiding = false;
			mAvoidPosition = default(Vector3);
			mIsStopped = true;
		}
	}

	public void Pause()
	{
		if (mAgent.enabled)
		{
			mIsStopped = true;
			mAgent.Stop();
		}
	}

	public void Disable()
	{
		mAgent.enabled = false;
		mIsStopped = true;
	}

	public Vector3 Steer(Vector3 target, bool slowDown = false)
	{
		Vector3 vector = target - base.transform.position;
		if (slowDown && vector.sqrMagnitude < 1f)
		{
			vector *= mSpeed * Time.deltaTime;
		}
		else
		{
			vector.Normalize();
			vector *= mSpeed * Time.deltaTime;
		}
		Vector3 vector2 = vector - vel;
		return vector2 / mass;
	}

	public void SetWayPointPath(WayPointPath path)
	{
		mAnimatingWayPoints = true;
		mPath = path;
		mPathLength = path.count;
		curentPathIndex = 0;
		vel = Vector3.zero;
		targetPoint = mPath[0];
	}

	private void OnEnable()
	{
		mUpdateStep = 1f / (float)updateCount;
		StartCoroutine("UpdateNavigationIEnumerator");
	}

	private IEnumerator UpdateNavigationIEnumerator()
	{
		while (true)
		{
			yield return new WaitForSeconds(mUpdateStep);
			Updatenavigation();
		}
	}

	private void OnDisable()
	{
		StopCoroutine("UpdateNavigationIEnumerator");
	}

	protected void Update()
	{
		if (animatingWayPoints)
		{
			float num = Vector3.Distance(base.transform.position, targetPoint);
			if (num < mPath.Radius)
			{
				mStayTime = stayTime + Time.deltaTime;
				if (stayTime >= mPath.positions[curentPathIndex].time)
				{
					mStayTime = 0f;
					if ((float)curentPathIndex < mPathLength - 1f)
					{
						curentPathIndex++;
						targetPoint = mPath[curentPathIndex];
					}
					else if (num < 0.015f)
					{
						mAnimatingWayPoints = false;
						return;
					}
				}
			}
			if (!((float)curentPathIndex >= mPathLength))
			{
				vel += Steer(targetPoint, mPath.positions[curentPathIndex].slowDown && mStayTime > mPath.positions[curentPathIndex].time * 0.2f);
				if (vel.magnitude > forceMagnitudeTreshold)
				{
					base.transform.position += vel;
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, ComputeRot(vel), Time.deltaTime * 3f);
				}
				else
				{
					vel = Vector3.zero;
				}
			}
			return;
		}
		if (DebugSettings.debugAI)
		{
			if (mAgent.path != null)
			{
				for (int i = 1; i < mAgent.path.corners.Length; i++)
				{
					Vector3 end = mAgent.path.corners[i] + new Vector3(0f, 0.1f, 0f);
					Vector3 start = mAgent.path.corners[i - 1] + new Vector3(0f, 0.1f, 0f);
					CameraLineRenderer.DrawLine(start, end, (!mIsObstacleAvoiding) ? Color.red : Color.magenta);
				}
			}
			if (mDestination != Vector3.zero)
			{
				CameraLineRenderer.DrawLine(base.transform.position + new Vector3(0f, 0.15f, 0f), mDestination + new Vector3(0f, 0.15f, 0f), Color.green);
			}
			CameraLineRenderer.DrawCross(mAgent.steeringTarget, 0.15f, Color.black);
		}
		if (!mIsWarping)
		{
			return;
		}
		int num2 = (int)mWarpProgres;
		if (num2 < mWarpCorners.Count - 1)
		{
			Vector3 vector = mWarpCorners[num2];
			Vector3 vector2 = mWarpCorners[num2 + 1];
			float magnitude = (vector2 - vector).magnitude;
			mWarpProgres += Mathf.Clamp01(Time.deltaTime * speed / magnitude);
			base.transform.position = Vector3.Lerp(vector, vector2, mWarpProgres - (float)num2);
			if (magnitude > 0.1f)
			{
				base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(vector2 - vector), Time.deltaTime * 8f);
			}
		}
	}

	private Quaternion ComputeRot(Vector3 vel)
	{
		float num = Vector3.Angle(Vector3.up, vel);
		if (num < 70f || num > 110f)
		{
			return mFlyRot;
		}
		Vector3 forward = vel;
		forward.y = 0f;
		forward.Normalize();
		Vector3 v = Quaternion.LookRotation(forward) * Vector3.forward;
		v.y = 0f;
		Vector3 v2 = mFlyRot * Vector3.forward;
		v2.y = 0f;
		float angle = GeometryTools.AngleSigned(v, v2, Vector3.up);
		forward.y = -0.3f;
		return Quaternion.LookRotation(forward) * Quaternion.AngleAxis(angle, Vector3.up);
	}

	protected void Updatenavigation()
	{
		if (isStopped)
		{
			return;
		}
		if (mAgent.pathStatus == NavMeshPathStatus.PathComplete && (double)Vector3.Distance(mAgent.pathEndPosition, mAgent.destination) > 0.1 && mAgent.velocity.sqrMagnitude < 0.05f && !mAgent.pathPending)
		{
			Debug.Log("Agent get stucked !!! ");
			Vector3 destination = mAgent.destination;
			mAgent.Stop();
			mAgent.ResetPath();
			mAgent.SetDestination(destination);
			mAgent.Resume();
		}
		RaycastHit hit;
		bool flag = mHeplperCapsule.ShouldAvoid(out hit);
		if (mDestination != Vector3.zero && Vector3.SqrMagnitude(base.transform.position - mDestination) > Mathf.Pow(mAgent.radius, 2f) && (flag || mShouldNearAvoid))
		{
			bool flag2 = ((!mShouldNearAvoid) ? (hit.collider.gameObject == mObstacle) : (mObstacle == mShouldNearAvoidObject));
			if (mShouldNearAvoid)
			{
				flag2 = false;
			}
			GameObject gameObject = ((!mShouldNearAvoid) ? hit.collider.gameObject : mShouldNearAvoidObject);
			mShouldNearAvoid = false;
			if (!flag2)
			{
				NavigationHelperCapsule component = gameObject.GetComponent<NavigationHelperCapsule>();
				if (component.navigationAgent.velocity.sqrMagnitude < 0.05f)
				{
					if (component != null && component.navigationAgent.isObstacleAvoiding && component.navigationAgent.obstacle == mHeplperCapsule.gameObject)
					{
						mAgent.speed = mSpeed * 0.5f;
					}
					else
					{
						mObstacle = gameObject;
						mIsObstacleAvoiding = true;
						Vector3 avoidPosition2;
						if (CanAvoidRight(out var avoidPosition))
						{
							if (CanAvoidLeft(out avoidPosition2))
							{
								if ((mDestination - avoidPosition).sqrMagnitude < (mDestination - avoidPosition2).sqrMagnitude)
								{
									mAvoidPosition = avoidPosition;
									SetTemporaryDestination(mAvoidPosition);
								}
								else
								{
									mAvoidPosition = avoidPosition2;
									SetTemporaryDestination(mAvoidPosition);
								}
							}
							else
							{
								mAvoidPosition = avoidPosition;
								SetTemporaryDestination(mAvoidPosition);
							}
							Resume();
						}
						else if (CanAvoidLeft(out avoidPosition2))
						{
							mAvoidPosition = avoidPosition2;
							SetTemporaryDestination(mAvoidPosition);
							Resume();
						}
						else
						{
							Debug.Log("can not avoid");
							mIsObstacleAvoiding = false;
							mObstacle = null;
							mAgent.SetDestination(mDestination);
							Resume();
						}
					}
				}
			}
		}
		else
		{
			mAgent.speed = mSpeed;
		}
		if (mIsObstacleAvoiding)
		{
			Vector3 position = base.transform.position;
			position.y = 0f;
			Vector3 b = mAvoidPosition;
			b.y = 0f;
			float num = Vector3.Distance(position, b);
			mAgent.SetDestination(mAvoidPosition);
			if (num <= avoidStopPlanarDistance)
			{
				mLastObstacle = mObstacle;
				mObstacle = null;
				mIsObstacleAvoiding = false;
				mAgent.SetDestination(mDestination);
				mAgent.Resume();
			}
			else
			{
				mAgent.SetDestination(mAvoidPosition);
				mAgent.Resume();
			}
			if (mIsObstacleAvoiding && DebugSettings.debugAI)
			{
				CameraLineRenderer.DrawCross(mAvoidPosition, 0.3f, Color.magenta);
			}
		}
		else if (mDestination != Vector3.zero)
		{
			mAgent.SetDestination(mDestination);
			mAgent.Resume();
		}
	}

	private void SetTemporaryDestination(Vector3 destination)
	{
		mAgent.Stop(stopUpdates: true);
		mAgent.ResetPath();
		mAgent.SetDestination(destination);
	}

	public void SetDestination(Vector3 position)
	{
		Reset();
		mAgent.enabled = true;
		mAgent.SetDestination(position);
		mDestination = position;
		mLastObstacle = null;
		mIsWarping = false;
	}

	public void Resume()
	{
		mAgent.enabled = true;
		mAgent.Resume();
		mIsStopped = false;
		mLastObstacle = null;
	}

	private bool CanAvoidRight(out Vector3 avoidPosition)
	{
		avoidPosition = mObstacle.transform.position - Vector3.Cross(mObstacle.transform.position - base.transform.position, Vector3.up).normalized * mAgent.radius * 2f;
		bool flag = false;
		NavMeshHit hit;
		bool flag2 = NavMesh.Raycast(base.transform.position, avoidPosition, out hit, mNavMeshLayerMask);
		return !flag && !flag2;
	}

	private bool CanAvoidLeft(out Vector3 avoidPosition)
	{
		avoidPosition = mObstacle.transform.position + Vector3.Cross(mObstacle.transform.position - base.transform.position, Vector3.up).normalized * mAgent.radius * 2f;
		bool flag = false;
		NavMeshHit hit;
		bool flag2 = NavMesh.Raycast(base.transform.position, avoidPosition, out hit, mNavMeshLayerMask);
		return !flag && !flag2;
	}

	public void Reset()
	{
		mIsStopped = false;
		mObstacle = null;
		mAvoidPosition = default(Vector3);
		mDestination = default(Vector3);
		mIsObstacleAvoiding = false;
		mAnimatingWayPoints = false;
		mAgent.enabled = true;
	}

	public void Warp()
	{
		mIsStopped = true;
		mWarpProgres = 0f;
		mIsWarping = true;
		mWarpCorners.Clear();
		mWarpCorners.Add(base.transform.position);
		Vector3[] array = mAgent.path.corners;
		foreach (Vector3 item in array)
		{
			mWarpCorners.Add(item);
		}
		mWarpCorners.Add((!NavMesh.SamplePosition(destnation, out var hit, 5f, 1)) ? destnation : hit.position);
		mAgent.enabled = false;
	}

	private void OnDrawGizmos()
	{
		if (mIsObstacleAvoiding)
		{
			Gizmos.color = Color.magenta;
			Gizmos.DrawWireCube(mAvoidPosition, Vector3.one * 0.15f);
		}
	}
}
