using System;
using UnityEngine;

public class MagneticObject : Core_BaseScript
{
	public DropPoint dropPoint;

	public PhysicsEventsListener frontCollider;

	private bool mOnGround = true;

	public bool pinned;

	public Transform snapPoint;

	private PhotonView mPhotonView;

	public void Pick(Transform point)
	{
		GetComponent<NavMeshObstacle>().enabled = false;
		base.transform.rotation = point.transform.rotation;
		base.transform.position = snapPoint.transform.position - base.transform.rotation * snapPoint.transform.localPosition;
	}

	protected override void Awake()
	{
		base.Awake();
		PhysicsEventsListener physicsEventsListener = frontCollider;
		physicsEventsListener.onTriggerEnter = (Action<Collider>)Delegate.Combine(physicsEventsListener.onTriggerEnter, new Action<Collider>(OnBottomTriggerEnter));
		mPhotonView = GetComponent<PhotonView>();
	}

	private void OnBottomTriggerEnter(Collider obj)
	{
		if (!mOnGround && TagsAndLayers.IsDestroyableObject(obj.GetComponent<Collider>().gameObject))
		{
			DestroyableObject component = obj.GetComponent<Collider>().gameObject.GetComponent<DestroyableObject>();
			if (component != null && component.destroyableByBonusBox)
			{
				component.DoDamage(new DestroyableObject.DamageInfo
				{
					damageAmount = float.MaxValue,
					force = Vector3.zero,
					isNetwork = false,
					owner = null,
					type = DestroyableObject.DamageType.Basic,
					ignoreImmortality = true
				});
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (TagsAndLayers.IsStatic(collision.collider.gameObject))
		{
			mOnGround = true;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			InvokeAfter(OnGround, 0.4f);
		}
	}

	private void OnGround()
	{
		GetComponent<NavMeshObstacle>().enabled = true;
		GetComponent<Rigidbody>().isKinematic = true;
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Sync", PhotonTargets.Others, base.transform.position, base.transform.rotation);
		}
	}

	[PunRPC]
	private void Sync(Vector3 pos, Quaternion rot)
	{
		base.transform.position = pos;
		base.transform.rotation = rot;
	}

	public void Drop(DropPoint dropPoint1)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		pinned = false;
		dropPoint1.droppedObject = this;
		dropPoint = dropPoint1;
		GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)80;
	}

	public void IsUp()
	{
		mOnGround = false;
	}
}
