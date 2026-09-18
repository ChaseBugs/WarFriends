using UnityEngine;

public class HeadSizeSetter : MonoBehaviour
{
	public Transform headTransform;

	private Vector3 mBaseScaleHead;

	private float mScaleF = 1f;

	private SoldierAnimationController mAnimationControler;

	public float scaleF
	{
		get
		{
			return mScaleF;
		}
		set
		{
			if (mScaleF != value)
			{
				mScaleF = value;
				base.enabled = true;
			}
		}
	}

	private void Awake()
	{
		mBaseScaleHead = headTransform.localScale;
		mAnimationControler = GetComponentInChildren<SoldierAnimationController>();
	}

	private void LateUpdate()
	{
		Vector3 vector = mBaseScaleHead * mScaleF;
		if (vector != headTransform.localScale)
		{
			headTransform.localScale = vector;
		}
		if (mAnimationControler.IsPlaying())
		{
			headTransform.Translate(-0.12f * (mScaleF - 1f), 0f, 0f, Space.Self);
		}
		if (mScaleF == 1f)
		{
			base.enabled = false;
		}
	}
}
