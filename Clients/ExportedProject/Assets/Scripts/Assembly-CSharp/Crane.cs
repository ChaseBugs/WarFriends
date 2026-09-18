using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crane : Core_BaseScript
{
	public List<DropPoint> dropPoints;

	public DropPoint startDropPoint;

	private DropPoint mDropPoint;

	private MagneticObject mMagneticObject;

	public List<MagneticObject> magneticObjects;

	public QuickRope2 rope;

	public Transform snapPoint;

	public float speed = 1f;

	public Transform craneHead;

	public Transform craneArm;

	private Vector3 mStartPos;

	private bool mAnimating;

	private Vector3 mFrom;

	private Vector3 mTo;

	private float mAnimTime;

	private float mT;

	private PhotonView mPhotonView;

	private float mStartTime;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		mStartPos = base.transform.position;
	}

	private void OnDestroy()
	{
		Singleton<GameController>.instance.GameStarted -= InstanceOnGameStarted;
	}

	private void InstanceOnGameStarted()
	{
		Singleton<GameController>.instance.GameStarted -= InstanceOnGameStarted;
		if (mPhotonView.isMine)
		{
			StartCrane(3f);
		}
	}

	private void StartCrane(float time)
	{
		PickDropPoint();
		PickMagneticObject();
		mStartTime = time;
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("StartCraneAnimationRPC", PhotonTargets.Others, time);
		}
	}

	[PunRPC]
	protected void StartCraneAnimationRPC(float time)
	{
		mStartTime = time;
	}

	protected override void Start()
	{
		base.Start();
		ConfigurableJoint component = rope.Joints[rope.Joints.Count - 2].GetComponent<ConfigurableJoint>();
		component.lowAngularXLimit = new SoftJointLimit
		{
			limit = -35f
		};
		component.highAngularXLimit = new SoftJointLimit
		{
			limit = 35f
		};
		foreach (GameObject joint in rope.Joints)
		{
			joint.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
		}
	}

	private void Update()
	{
		Vector3 forward = base.transform.position - craneHead.position;
		forward.y = 0f;
		craneHead.rotation = Quaternion.LookRotation(forward);
		Vector3 position = base.transform.position;
		position.y = mStartPos.y;
		Vector3 forward2 = position - craneArm.position;
		craneArm.rotation = Quaternion.LookRotation(forward2);
		if (PhotonNetwork.time > (double)mStartTime && mStartTime != 0f)
		{
			mStartTime = 0f;
			StartCoroutine(MoveObject());
		}
	}

	[PunRPC]
	private void PickMagneticObjectRPC(byte index)
	{
		mMagneticObject = magneticObjects[index];
		if (mMagneticObject.dropPoint != null)
		{
			mMagneticObject.dropPoint.droppedObject = null;
			mMagneticObject.dropPoint = null;
		}
	}

	private void PickMagneticObject()
	{
		List<MagneticObject> list = new List<MagneticObject>();
		foreach (MagneticObject magneticObject in magneticObjects)
		{
			list.Add(magneticObject);
		}
		mMagneticObject = list[Random.Range(0, list.Count)];
		int num = magneticObjects.IndexOf(mMagneticObject);
		if (mMagneticObject.dropPoint != null)
		{
			mMagneticObject.dropPoint.droppedObject = null;
			mMagneticObject.dropPoint = null;
		}
		mPhotonView.RPC("PickMagneticObjectRPC", PhotonTargets.Others, (byte)num);
	}

	[PunRPC]
	private void PickDropPointRPC(byte index)
	{
		mDropPoint = dropPoints[index];
	}

	private void PickDropPoint()
	{
		List<DropPoint> list = new List<DropPoint>();
		int num = 0;
		foreach (DropPoint dropPoint in dropPoints)
		{
			if (dropPoint.droppedObject != null && !dropPoint.startPoint)
			{
				num++;
			}
		}
		foreach (DropPoint dropPoint2 in dropPoints)
		{
			if (num == 0)
			{
				if (dropPoint2.droppedObject == null)
				{
					list.Add(dropPoint2);
				}
			}
			else if (dropPoint2.droppedObject == null && dropPoint2.startPoint)
			{
				list.Add(dropPoint2);
			}
		}
		mDropPoint = list[Random.Range(0, list.Count)];
		int num2 = dropPoints.IndexOf(mDropPoint);
		mPhotonView.RPC("PickDropPointRPC", PhotonTargets.Others, (byte)num2);
	}

	private IEnumerator MoveObject()
	{
		Vector3 from = base.transform.position;
		Vector3 to = mMagneticObject.snapPoint.transform.position;
		to.y = from.y;
		mAnimTime = Vector3.Distance(from, to) / speed;
		StartAnim(from, to);
		while (mAnimating)
		{
			yield return null;
		}
		from = base.transform.position;
		float d = Vector3.Distance(snapPoint.transform.position, mMagneticObject.snapPoint.transform.position);
		to = base.transform.position - d * Vector3.up;
		mAnimTime = Vector3.Distance(from, to) / speed;
		StartAnim(from, to);
		while (mAnimating)
		{
			yield return null;
		}
		from = base.transform.position;
		mMagneticObject.GetComponent<Rigidbody>().isKinematic = true;
		mMagneticObject.pinned = true;
		mMagneticObject.Pick(snapPoint);
		to = base.transform.position + d * Vector3.up;
		mAnimTime = Vector3.Distance(from, to) / speed;
		StartAnim(from, to);
		while (mAnimating)
		{
			yield return null;
		}
		mMagneticObject.IsUp();
		from = base.transform.position;
		to = mDropPoint.transform.position;
		to.y = from.y;
		StartAnim(from, to);
		while (mAnimating)
		{
			yield return null;
		}
		yield return new WaitForSeconds(2f);
		mMagneticObject.Drop(mDropPoint);
		yield return null;
		yield return new WaitForSeconds(2f);
		if (mPhotonView.isMine)
		{
			StartCrane(Random.Range(10, 15));
		}
	}

	private void StartAnim(Vector3 from, Vector3 to)
	{
		mAnimating = true;
		mFrom = from;
		mTo = to;
		mAnimTime = Vector3.Distance(from, to) / speed;
		mT = 0f;
	}

	private void FixedUpdate()
	{
		if (mAnimating)
		{
			mT += Time.fixedDeltaTime / mAnimTime;
			base.transform.position = Vector3.Lerp(mFrom, mTo, mT);
			if (mT >= 1f)
			{
				mAnimating = false;
			}
		}
		if (mMagneticObject != null && mMagneticObject.pinned)
		{
			mMagneticObject.transform.rotation = snapPoint.transform.rotation;
			mMagneticObject.transform.position = snapPoint.transform.position - snapPoint.transform.rotation * mMagneticObject.snapPoint.transform.localPosition;
		}
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}
