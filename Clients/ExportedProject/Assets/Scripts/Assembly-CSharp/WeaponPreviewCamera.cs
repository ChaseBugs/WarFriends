using System;
using System.Collections;
using UnityEngine;

public class WeaponPreviewCamera : Singleton<WeaponPreviewCamera>
{
	public Transform weaponParent;

	public Transform target;

	public float distance = 5f;

	public float xSpeed = 120f;

	public float ySpeed = 120f;

	public float yMinLimit = -20f;

	public float yMaxLimit = 80f;

	public float interiaTtime = 2f;

	public float damping = 5f;

	private float mRotationSpeed = -17f;

	private Weapon3DModel mShowedWeaponPrefab;

	private Weapon3DModel mShowedWeaponInstance;

	private Camera mCamera;

	private float x;

	private float y;

	private bool mIsHit;

	private float xDiff;

	private float yDiff;

	private bool mUnderInertia = true;

	public static bool rotationEnabled = true;

	private bool mWeaponLoading;

	public event Action<bool> OnRotate;

	protected override void Start()
	{
		if ((bool)GetComponent<Rigidbody>())
		{
			GetComponent<Rigidbody>().freezeRotation = true;
		}
		if (target != null)
			distance = Vector3.Distance(base.transform.position, target.position);
	}

	protected override void Awake()
	{
		base.Awake();
		mCamera = GetComponent<Camera>();
		mCamera.enabled = false;
	}

	public void StartFastRotation()
	{
		mRotationSpeed = -720f;
	}

	public void DefaultRotation()
	{
		mRotationSpeed = -17f;
	}

	public Weapon3DModel DisplayeWeapon(string weaponprefab, string assetBundleName, Vector2 weaponDefaultRotation, Vector3 weaponDefaultPosition)
	{
		DefaultRotation();
		if (mShowedWeaponPrefab == null || weaponprefab != mShowedWeaponPrefab.name)
		{
			StartCoroutine(LoadModel(weaponprefab, assetBundleName, weaponDefaultRotation, weaponDefaultPosition));
		}
		if (mShowedWeaponInstance != null)
		{
			mShowedWeaponInstance.gameObject.SetActive(value: true);
		}
		mCamera.enabled = true;
		return null;
	}

	private IEnumerator LoadModel(string weaponprefab, string assetBundleName, Vector2 weaponDefaultRotation, Vector3 weaponDefaultPosition)
	{
		while (mWeaponLoading)
		{
			yield return null;
		}
		mWeaponLoading = true;
		if (mShowedWeaponInstance != null)
		{
			mShowedWeaponInstance.UnloadWeapon();
			UnityEngine.Object.Destroy(mShowedWeaponInstance.gameObject);
		}
		string bundleName = "weapons/" + assetBundleName;
		string path = bundleName + "/GUI_" + weaponprefab;
		GameObject modelxx = Resources.Load<GameObject>(path);
		mShowedWeaponInstance = UnityEngine.Object.Instantiate(mShowedWeaponPrefab = modelxx.GetComponent<Weapon3DModel>());
		mShowedWeaponInstance.Load();
		mShowedWeaponInstance.transform.parent = weaponParent;
		mShowedWeaponInstance.transform.localScale = new Vector3(1f, 1f, 1f);
		mShowedWeaponInstance.transform.localPosition = default(Vector3);
		mShowedWeaponInstance.transform.localRotation = Quaternion.identity;
		mShowedWeaponInstance.gameObject.layer = weaponParent.gameObject.layer;
		x = weaponDefaultRotation.x;
		y = weaponDefaultRotation.y;
		weaponParent.localPosition = weaponDefaultPosition;
		CreateRotation();
		mWeaponLoading = false;
	}

	public void UpdateRotation(float endX, float endY, float time)
	{
		StartCoroutine(RadicalRoutine.Run(AnimateWeapon(endX, endY, time)));
	}

	private IEnumerator AnimateWeapon(float endX, float endY, float length)
	{
		float time = 0f;
		float startX = GetAngleInRightValues(x);
		float startY = y;
		endX = GetAngleInRightValues(endX);
		while (time < length)
		{
			x = Mathf.Lerp(startX, endX, time / length);
			y = Mathf.Lerp(startY, endY, time / length);
			time += Time.deltaTime;
			CreateRotation();
			yield return null;
		}
		x = endX;
		y = endY;
		CreateRotation();
	}

	private float GetAngleInRightValues(float angle)
	{
		return angle - Mathf.Floor(angle / 360f) * 360f;
	}

	public void Hide()
	{
		mCamera.enabled = false;
		if (mShowedWeaponInstance != null)
		{
			mShowedWeaponInstance.UnloadWeapon();
			UnityEngine.Object.Destroy(mShowedWeaponInstance.gameObject);
		}
	}

	private void UpdateRotation()
	{
		xDiff = Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
		yDiff = Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
		x += xDiff;
		y -= yDiff;
		CreateRotation();
	}

	private void CreateRotation()
	{
		if (target == null)
			return;
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		Quaternion rotation = Quaternion.Euler(y, x, 0f);
		target.rotation = Quaternion.Inverse(rotation);
	}

	private void InertiaRotation()
	{
		xDiff = Mathf.Lerp(xDiff, 0f, Time.deltaTime * damping);
		yDiff = Mathf.Lerp(yDiff, 0f, Time.deltaTime * damping);
		x += xDiff;
		y -= yDiff;
		CreateRotation();
	}

	private void LateUpdate()
	{
		if (target == null)
		{
			mIsHit = false;
			return;
		}
		if (mUnderInertia)
		{
			InertiaRotation();
		}
		if ((bool)target && mIsHit)
		{
			UpdateRotation();
		}
		if (Input.GetMouseButtonDown(0) && rotationEnabled && UICamera.currentCamera != null)
		{
			mIsHit = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == "weaponPreviewCollider")
				{
					mIsHit = true;
					mUnderInertia = false;
					if (this.OnRotate != null)
					{
						this.OnRotate(obj: true);
					}
				}
			}
		}
		if (rotationEnabled && mUnderInertia)
		{
			x += Time.deltaTime * mRotationSpeed;
			CreateRotation();
		}
		if (Input.GetMouseButtonUp(0))
		{
			mIsHit = false;
			mUnderInertia = true;
			if (this.OnRotate != null)
			{
				this.OnRotate(obj: false);
			}
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

	public void Pause()
	{
		mCamera.enabled = false;
	}

	public void Resume()
	{
		mCamera.enabled = true;
	}
}
