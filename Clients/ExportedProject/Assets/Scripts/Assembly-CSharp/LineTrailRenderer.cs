using UnityEngine;

public class LineTrailRenderer : Core_BaseScript
{
	private const float lengtCoef = 1.3f;

	public float disapearTime = 1f;

	private float mDisappearTimeProgress;

	private float mDistance;

	private bool mIsReset = true;

	private Vector3 mLastPosition;

	private MeshFilter mMeshFilter;

	private Transform mReferenceCamera;

	private Vector3 mStartPosition;

	private Quaternion mStartRot;

	private Transform mTransform;

	private float mYScale;

	private float rot;

	public float trailLength = 1f;

	public void SetWidth(float w1)
	{
		mYScale = w1 / 0.1f;
	}

	protected override void Awake()
	{
		base.Awake();
		mIsReset = true;
		mTransform = base.transform;
		mReferenceCamera = Camera.main.transform;
		mMeshFilter = GetComponent<MeshFilter>();
	}

	public void SetSprite(string spriteName)
	{
		mMeshFilter.mesh = Singleton<BulletModels>.instance.GetMesh(spriteName);
	}

	protected void Update()
	{
		if (mIsReset)
		{
			mDisappearTimeProgress = 0f;
			mIsReset = false;
			mStartPosition = mTransform.position;
			mStartRot = mTransform.rotation;
			mTransform.localScale.ReplaceX(0f);
		}
		else if (mLastPosition != mTransform.position)
		{
			mDistance = Vector3.Distance(mTransform.position, mStartPosition);
			if (mDistance > trailLength)
			{
				Vector3 localScale = mTransform.localScale;
				localScale.x = trailLength * 1.3f;
				localScale.y = mYScale;
				mTransform.localScale = localScale;
			}
			else
			{
				float x = mDistance / trailLength * 1.3f * 0.7f;
				Vector3 localScale2 = mTransform.localScale;
				localScale2.x = x;
				localScale2.y = mYScale;
				mTransform.localScale = localScale2;
			}
		}
		else
		{
			mDisappearTimeProgress += Time.deltaTime / disapearTime;
			mDisappearTimeProgress = Mathf.Clamp01(mDisappearTimeProgress);
			float num = 1f - mDisappearTimeProgress;
			Vector3 localScale3 = mTransform.localScale;
			localScale3.x = num * 1.3f;
			localScale3.y = mYScale;
			mTransform.localScale = localScale3;
		}
		rot += Time.deltaTime * 200f;
		float angle = Vector3.Angle(mReferenceCamera.forward, mStartRot * Vector3.forward);
		Quaternion quaternion = Quaternion.AngleAxis(angle, mStartRot * Vector3.right);
		mTransform.rotation = quaternion * mStartRot;
		mLastPosition = mTransform.position;
	}

	public void Reset()
	{
		mIsReset = true;
		mDisappearTimeProgress = 0f;
		mTransform.localScale = new Vector3(0f, 0f, 1f);
	}
}
