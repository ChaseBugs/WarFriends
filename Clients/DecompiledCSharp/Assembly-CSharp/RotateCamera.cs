using UnityEngine;

public class RotateCamera : Core_BaseScript
{
	public float rotationSpeed = -17f;

	public Transform target;

	public float distance = 5f;

	public float xSpeed = 120f;

	public float ySpeed = 120f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	public float interiaTtime = 2f;

	public float damping = 5f;

	private float mX;

	private float mY;

	private bool mIsHit;

	private float mXDiff;

	private float mYDiff;

	private bool mUnderInertia = true;

	public string colliderName = "rotateColliderName";

	private void CreateRotation()
	{
		mY = ClampAngle(mY, yMinLimit, yMaxLimit);
		Quaternion rotation = Quaternion.Euler(mY, mX, 0f);
		if (target != null)
		{
			target.rotation = Quaternion.Inverse(rotation);
		}
	}

	private void UpdateMouseRotation()
	{
		mXDiff = Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
		mYDiff = Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		mX += mXDiff;
		mY -= mYDiff;
		CreateRotation();
	}

	private void LerpRotation()
	{
		mXDiff = Mathf.Lerp(mXDiff, 0f, Time.deltaTime * damping);
		mYDiff = Mathf.Lerp(mYDiff, 0f, Time.deltaTime * damping);
		mX += mXDiff;
		mY -= mYDiff;
		CreateRotation();
	}

	private void LateUpdate()
	{
		if (mUnderInertia)
		{
			LerpRotation();
		}
		if (target != null && mIsHit)
		{
			UpdateMouseRotation();
		}
		if (Input.GetMouseButtonDown(0))
		{
			mIsHit = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == colliderName)
				{
					mIsHit = true;
					mUnderInertia = false;
				}
			}
		}
		if (mUnderInertia)
		{
			mX += Time.deltaTime * rotationSpeed;
			CreateRotation();
		}
		if (Input.GetMouseButtonUp(0))
		{
			mIsHit = false;
			mUnderInertia = true;
		}
	}

	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360f)
		{
			angle += 360f;
		}
		if (angle > 360f)
		{
			angle -= 360f;
		}
		return Mathf.Clamp(angle, min, max);
	}

	public void Reset()
	{
		mY = 0f;
		mX = 0f;
		mUnderInertia = true;
		CreateRotation();
	}
}
