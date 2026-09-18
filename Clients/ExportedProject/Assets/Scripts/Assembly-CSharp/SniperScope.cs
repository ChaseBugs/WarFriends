using System;
using System.Collections.Generic;
using UnityEngine;

public class SniperScope : Singleton<SniperScope>
{
	[Serializable]
	public class Scope
	{
		public Vector3 offset = new Vector3(30f, 30f, 0f);

		public GameObject scope;

		public Vector3 mStartScale;

		public float maxTopOffset = 30f;
	}

	public Camera touchCamera;

	public Vector3 offset = new Vector3(30f, 30f, 0f);

	private Renderer mTouchSpriteRenderer;

	private bool mShowed;

	private Vector3 mScale;

	private bool mIsSmallDisplay;

	private Scope mScope;

	public List<Scope> scopes;

	public bool showed => mShowed;

	public void SetScope(int scope)
	{
		foreach (Scope scope2 in scopes)
		{
			scope2.scope.SetActive(value: false);
		}
		scopes[scope].scope.SetActive(value: true);
		mTouchSpriteRenderer = scopes[scope].scope.GetComponent<Renderer>();
		offset = scopes[scope].offset;
		mScope = scopes[scope];
	}

	protected override void Awake()
	{
		base.Awake();
		touchCamera.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		mTouchSpriteRenderer = GetComponent<Renderer>();
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		mScale = base.transform.localScale;
		mIsSmallDisplay = ScreenManager.isSmallScreen;
		foreach (Scope scope in scopes)
		{
			scope.mStartScale = scope.scope.transform.localScale;
		}
		SetScope(0);
	}

	public void Show(float fov)
	{
		if (mIsSmallDisplay)
		{
			fov *= 0.57f;
		}
		if (!showed)
		{
			touchCamera.gameObject.SetActive(value: true);
			mScope.scope.transform.localScale = Vector3.zero;
			TweenScale.Begin(mScope.scope, 0.25f, Vector3.zero, mScope.mStartScale);
			TweenFOV.Begin(Singleton<SniperScope>.instance.touchCamera.gameObject, 0.1f, fov);
			base.gameObject.SetActive(value: true);
			mShowed = true;
		}
	}

	public void AnimFov(float fov)
	{
		if (mIsSmallDisplay)
		{
			fov *= 0.57f;
		}
		TweenFOV.Begin(touchCamera.gameObject, 0.5f, fov);
	}

	public void Show()
	{
		if (!showed)
		{
			mScope.scope.transform.localScale = mScope.mStartScale;
			touchCamera.gameObject.SetActive(value: true);
			touchCamera.Render();
			UpdatePosition();
			base.gameObject.SetActive(value: true);
			mShowed = true;
		}
	}

	public void Hide()
	{
		touchCamera.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
		mShowed = false;
	}

	protected void Update()
	{
		UpdatePosition();
	}

	private void UpdatePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
		Vector3 normalized = ray.direction.normalized;
		touchCamera.transform.position = Camera.main.transform.position;
		touchCamera.transform.rotation = Quaternion.LookRotation(normalized);
		Vector3 vector = HealthBarManager.instance.guiCamera.transform.position + new Vector3(0f, 0f, HealthBarManager.instance.guiCamera.nearClipPlane + 3f);
		Vector3 vector2 = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(Camera.main.WorldToNormalizedViewportPoint(point));
		vector2.z = vector.z;
		Vector3 vector3 = new Vector3(offset.x * (mScope.scope.transform.localScale.x / mScope.mStartScale.x), offset.y * (mScope.scope.transform.localScale.y / mScope.mStartScale.y), offset.z * (mScope.scope.transform.localScale.z / mScope.mStartScale.z));
		Vector3 mousePos = vector2;
		mousePos = ClampInScreenXY(HealthBarManager.instance.guiCamera, mousePos, vector3, mTouchSpriteRenderer.bounds);
		base.transform.position = mousePos;
	}

	public Vector3 ClampInScreenXY(Camera c, Vector3 mousePos, Vector3 offset, Bounds objectSize)
	{
		Vector3 vector = mousePos + offset;
		Vector3 result = vector;
		Vector3 vector2 = c.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector3 = c.ViewportToWorldPoint(new Vector2(1f, 0f));
		Vector3 vector4 = c.ViewportToWorldPoint(new Vector2(1f, 1f));
		if (vector.y - objectSize.extents.y < vector2.y)
		{
			result.y = vector2.y + objectSize.extents.y;
		}
		if (vector.y + objectSize.extents.y > vector4.y)
		{
			result.y = vector4.y - objectSize.extents.y;
			float num = vector.y - vector4.y + objectSize.extents.y;
			float value = num / objectSize.extents.y;
			value = Mathf.Clamp01(value);
			value = Mathf.Sin(value * (float)Math.PI * 0.5f);
			num = Mathf.Clamp(num, 0f, objectSize.extents.y + mScope.offset.x);
			num = value * mScope.maxTopOffset;
			vector.x -= num;
			result.x = vector.x;
		}
		if (vector.x - objectSize.extents.x < vector2.x)
		{
			result.x = vector2.x + objectSize.extents.x;
		}
		if (vector.x + objectSize.extents.x > vector3.x)
		{
			result.x = vector3.x - objectSize.extents.x;
		}
		return result;
	}

	private void InstanceOnGameEnded(GameController.GameEndReason gameEndReason)
	{
		touchCamera.gameObject.SetActive(value: false);
		touchCamera.depthTextureMode = DepthTextureMode.None;
		base.gameObject.SetActive(value: false);
	}

	private void InstanceOnGameStarted()
	{
		touchCamera.depthTextureMode = DepthTextureMode.None;
		touchCamera.gameObject.SetActive(value: false);
		base.gameObject.SetActive(value: false);
	}
}
