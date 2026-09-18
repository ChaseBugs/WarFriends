using System;
using System.Collections.Generic;
using UnityEngine;

public class Train : Core_BaseScript
{
	[Serializable]
	public class TrainLoad
	{
		public Mesh mesh;

		public Mesh collider;
	}

	public Transform startPosition;

	public Transform endPosition;

	public float speed = 5f;

	public PhysicsEventsListener frontCollider;

	public PhysicsEventsListener trainTrigger;

	private float mCarveCubeMovementOffset = 4f;

	private bool mIsAnimating;

	private float mStartMovementTime;

	private PhotonView mPhotonView;

	private double mStartAnimTime;

	public List<TrainLoad> loads;

	public List<GameObject> carriages;

	private bool mReverse;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		PhysicsEventsListener physicsEventsListener = frontCollider;
		physicsEventsListener.onTriggerEnter = (Action<Collider>)Delegate.Combine(physicsEventsListener.onTriggerEnter, new Action<Collider>(OnFrontTriggerEnter));
		PhysicsEventsListener physicsEventsListener2 = trainTrigger;
		physicsEventsListener2.onTriggerEnter = (Action<Collider>)Delegate.Combine(physicsEventsListener2.onTriggerEnter, new Action<Collider>(OnTrainTriggerEnter));
		PhysicsEventsListener physicsEventsListener3 = trainTrigger;
		physicsEventsListener3.onTriggerExit = (Action<Collider>)Delegate.Combine(physicsEventsListener3.onTriggerExit, new Action<Collider>(OnTrainTriggerExit));
		mStartMovementTime = Time.time + (float)UnityEngine.Random.Range(15, 120);
		mStartAnimTime = 0.0;
	}

	protected override void Start()
	{
		base.Start();
	}

	public void StartAnimation()
	{
		mIsAnimating = true;
		mStartAnimTime = PhotonNetwork.time + 3.0;
		mReverse = UnityEngine.Random.value > 0.5f;
		int num = UnityEngine.Random.Range(2, 6);
		byte[] array = new byte[num];
		for (int i = 0; i < carriages.Count; i++)
		{
			if (i < num)
			{
				int num2 = UnityEngine.Random.Range(0, loads.Count);
				array[i] = (byte)num2;
			}
		}
		SetUpTrain(array);
		mPhotonView.RPC("StartMovementAtTimeRPC", PhotonTargets.Others, mStartAnimTime, array, mReverse);
	}

	private void SetUpTrain(byte[] array)
	{
		for (int i = 0; i < carriages.Count; i++)
		{
			if (i < array.Length)
			{
				byte index = array[i];
				carriages[i].gameObject.transform.parent.gameObject.SetActive(value: true);
				MeshFilter component = carriages[i].GetComponent<MeshFilter>();
				MeshCollider component2 = carriages[i].GetComponent<MeshCollider>();
				component.mesh = loads[index].mesh;
				component2.sharedMesh = loads[index].collider;
			}
			else
			{
				carriages[i].gameObject.transform.parent.gameObject.SetActive(value: false);
			}
		}
		BoxCollider component3 = trainTrigger.GetComponent<BoxCollider>();
		Vector3 size = component3.size;
		Vector3 center = component3.center;
		size.z = (float)(array.Length + 1) * 2.565354f;
		center.z = (float)(array.Length + 1) * 2.565354f * 0.5f;
		component3.center = center;
		component3.size = size;
	}

	private void StarMOvement()
	{
		float num = Vector3.Distance(startPosition.transform.position, endPosition.transform.position);
		Vector3 vector = ((!mReverse) ? startPosition.position : endPosition.position);
		Vector3 vector2 = ((!mReverse) ? endPosition.position : startPosition.position);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num / speed, vector, vector2, useLocal: false);
		base.gameObject.transform.rotation = Quaternion.LookRotation(vector - vector2);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(OnFinished));
		tweenPosition.ignoreTimeScale = false;
		mIsAnimating = true;
	}

	[PunRPC]
	private void StartMovementAtTimeRPC(double time, byte[] array, bool reverse)
	{
		SetUpTrain(array);
		mStartAnimTime = time;
		mReverse = reverse;
	}

	protected void Update()
	{
		if (mPhotonView.isMine)
		{
			if (DebugSettings.debugEnabled && Input.GetKeyDown(KeyCode.Alpha1))
			{
				StartAnimation();
			}
			if (Time.time > mStartMovementTime && !mIsAnimating)
			{
				StartAnimation();
			}
		}
		if (mStartAnimTime != 0.0 && PhotonNetwork.time > mStartAnimTime)
		{
			mStartAnimTime = 0.0;
			StarMOvement();
		}
	}

	private void OnFrontTriggerEnter(Collider collider1)
	{
		if (mPhotonView.isMine && TagsAndLayers.IsDestroyableObject(collider1.gameObject))
		{
			DestroyableObject component = collider1.gameObject.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.DoDamage(new DestroyableObject.DamageInfo
				{
					damageAmount = 1000f,
					force = Vector3.zero,
					isNetwork = false,
					owner = null,
					type = DestroyableObject.DamageType.Basic
				});
			}
		}
	}

	private void OnTrainTriggerEnter(Collider obj)
	{
		if (!mPhotonView.isMine || !TagsAndLayers.IsDestroyableObject(obj.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = obj.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (!(destroyableObjectpart != null))
		{
			return;
		}
		DestroyableObjectMultipleParts ownerDestroyableObject = destroyableObjectpart.ownerDestroyableObject;
		if (ownerDestroyableObject != null)
		{
			EnemyController component = ownerDestroyableObject.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Wait(2f);
			}
		}
	}

	private void OnTrainTriggerExit(Collider obj)
	{
		if (!mPhotonView.isMine || !TagsAndLayers.IsDestroyableObject(obj.gameObject))
		{
			return;
		}
		DestroyableObjectpart destroyableObjectpart = obj.gameObject.GetComponent<DestroyableObject>() as DestroyableObjectpart;
		if (destroyableObjectpart != null)
		{
			DestroyableObjectMultipleParts ownerDestroyableObject = destroyableObjectpart.ownerDestroyableObject;
			EnemyController component = ownerDestroyableObject.GetComponent<EnemyController>();
			if (component != null)
			{
				component.Resume();
			}
		}
	}

	private void OnFinished(UITweener tween)
	{
		mIsAnimating = false;
		mStartMovementTime = Time.time + (float)UnityEngine.Random.Range(10, 60);
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
	}
}
