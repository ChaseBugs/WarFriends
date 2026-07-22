using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class tk2dCamera : MonoBehaviour
{
	private static int CURRENT_VERSION;

	public int version;

	[SerializeField]
	private tk2dCameraSettings cameraSettings;

	public tk2dCameraResolutionOverride[] resolutionOverride;

	[SerializeField]
	private tk2dCamera inheritSettings;

	public int nativeResolutionWidth;

	public int nativeResolutionHeight;

	[SerializeField]
	private Camera _unityCamera;

	private static tk2dCamera inst;

	private static List<tk2dCamera> allCameras;

	public bool viewportClippingEnabled;

	public Vector4 viewportRegion;

	private Vector2 _targetResolution;

	[SerializeField]
	private float zoomFactor;

	[HideInInspector]
	public bool forceResolutionInEditor;

	private bool useGameWindowResolutionInEditor;

	[HideInInspector]
	public Vector2 forceResolution;

	private Vector2 gameWindowResolution;

	private Rect _screenExtents;

	private Rect _nativeScreenExtents;

	private Rect unitRect;

	private tk2dCamera _settingsRoot;

	public tk2dCameraSettings CameraSettings => null;

	public tk2dCameraResolutionOverride CurrentResolutionOverride => null;

	public tk2dCamera InheritConfig
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private Camera UnityCamera => null;

	public static tk2dCamera Instance => null;

	public Rect ScreenExtents => default(Rect);

	public Rect NativeScreenExtents => default(Rect);

	public Vector2 TargetResolution => default(Vector2);

	public Vector2 NativeResolution => default(Vector2);

	[Obsolete]
	public Vector2 ScreenOffset => default(Vector2);

	[Obsolete]
	public Vector2 resolution => default(Vector2);

	[Obsolete]
	public Vector2 ScreenResolution => default(Vector2);

	[Obsolete]
	public Vector2 ScaledResolution => default(Vector2);

	public float ZoomFactor
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	[Obsolete]
	public float zoomScale => 0f;

	public Camera ScreenCamera => null;

	public tk2dCamera SettingsRoot => null;

	public static tk2dCamera CameraForLayer(int layer)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnPreCull()
	{
	}

	public float GetSizeAtDistance(float distance)
	{
		return 0f;
	}

	public Matrix4x4 OrthoOffCenter(Vector2 scale, float left, float right, float bottom, float top, float near, float far)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Matrix4x4);
	}

	private Vector2 GetScaleForOverride(tk2dCamera settings, tk2dCameraResolutionOverride currentOverride, float width, float height)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	private Vector2 GetOffsetForOverride(tk2dCamera settings, tk2dCameraResolutionOverride currentOverride, Vector2 scale, float width, float height)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	private Matrix4x4 GetProjectionMatrixForOverride(tk2dCamera settings, tk2dCameraResolutionOverride currentOverride, float pixelWidth, float pixelHeight, bool halfTexelOffset, out Rect screenExtents, out Rect unscaledScreenExtents)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		screenExtents = default(Rect);
		unscaledScreenExtents = default(Rect);
		return default(Matrix4x4);
	}

	private Vector2 GetScreenPixelDimensions(tk2dCamera settings)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector2);
	}

	private void Upgrade()
	{
	}

	public void UpdateCameraMatrix()
	{
	}
}
