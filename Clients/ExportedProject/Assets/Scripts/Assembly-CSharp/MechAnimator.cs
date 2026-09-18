using System;
using UnityEngine;

public class MechAnimator : MonoBehaviour
{
	public AudioSource mechSource;

	[SerializeField]
	private Animation mAnimation;

	[SerializeField]
	private Transform mRoot;

	[SerializeField]
	private Transform mUpperBody;

	private Quaternion absoluteRotation;

	private Quaternion local;

	private bool mKeepAimed;

	private PhotonView mPhotonView;

	public Action Aimed;

	private Quaternion mWantedRootRotation;

	public float strafeSpeed = 1f;

	private bool mStopShoot;

	private void Awake()
	{
		mPhotonView = GetComponent<PhotonView>();
	}

	private void Start()
	{
	}

	[PunRPC]
	public void Walk()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Walk", PhotonTargets.Others);
		}
		mAnimation.CrossFade("walk_cycle");
		StarWalkSound();
	}

	[PunRPC]
	public void Shoot()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Shoot", PhotonTargets.Others);
		}
		mAnimation.CrossFade("fire");
	}

	[PunRPC]
	public void StopShoot()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("StopShoot", PhotonTargets.Others);
		}
		mStopShoot = true;
	}

	[PunRPC]
	public void Idle()
	{
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Idle", PhotonTargets.Others);
		}
		mAnimation.CrossFade("idle");
		StopWalkSound();
	}

	[PunRPC]
	public void Strafe(bool left)
	{
		string animation = ((!left) ? "strafing_right" : "strafing_left");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = strafeSpeed;
		if (mPhotonView.isMine)
		{
			mPhotonView.RPC("Strafe", PhotonTargets.Others, left);
		}
		StarWalkSound();
	}

	public void PreviewIdle()
	{
		mAnimation.CrossFade("idle", 0f);
	}

	public void LookAt(Vector3 position, bool keepAimed)
	{
		absoluteRotation = Quaternion.LookRotation(position - mRoot.transform.parent.position);
		local = Quaternion.Inverse(mRoot.transform.parent.rotation) * absoluteRotation;
		mKeepAimed = keepAimed;
		if (mKeepAimed)
		{
			return;
		}
		TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 1f, local);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			if (Aimed != null)
			{
				Aimed();
			}
		});
	}

	public void Reset()
	{
		mAnimation["fire"].layer = 4;
		mAnimation["fire"].blendMode = AnimationBlendMode.Blend;
		mAnimation["fire"].wrapMode = WrapMode.Loop;
		mAnimation["fire"].AddMixingTransform(mUpperBody);
		local = Quaternion.identity;
		mKeepAimed = false;
		TweenRotation.Begin(mRoot.gameObject, 0f, local);
		mWantedRootRotation = Quaternion.identity;
		mStopShoot = false;
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(mRoot.localRotation);
		}
		else
		{
			mWantedRootRotation = (Quaternion)stream.ReceiveNext();
		}
	}

	private void Update()
	{
		if (mKeepAimed)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * absoluteRotation;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 8f);
			mRoot.localRotation = localRotation2;
		}
		if (!mPhotonView.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, mWantedRootRotation, Time.deltaTime * 8f);
		}
		if (mStopShoot)
		{
			float weight = mAnimation["fire"].weight;
			weight -= Time.deltaTime * 3f;
			if (weight <= 0f)
			{
				weight = 0f;
				mAnimation["fire"].enabled = false;
				mStopShoot = false;
			}
			mAnimation["fire"].weight = weight;
		}
		if (Time.timeScale < 0.01f != mechSource.mute)
		{
			mechSource.mute = Time.timeScale < 0.01f;
		}
	}

	private void StarWalkSound()
	{
		mechSource.loop = true;
		Singleton<SoundsManager3D>.instance.Play(mechSource, Sounds3DEnum.MechSound);
	}

	public void StopWalkSound()
	{
		mechSource.Stop();
		mechSource.loop = false;
	}
}
