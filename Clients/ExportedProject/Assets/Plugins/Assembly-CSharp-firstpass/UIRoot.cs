using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/UI/Root")]
[ExecuteInEditMode]
public class UIRoot : MonoBehaviour
{
	public enum Scaling
	{
		PixelPerfect,
		FixedSize,
		FixedSizeOnMobiles,
		FixedWidth,
		FixedWidthShrinkOnly
	}

	private static List<UIRoot> mRoots = new List<UIRoot>();

	public Scaling scalingStyle = Scaling.FixedSize;

	[HideInInspector]
	public bool automatic;

	public int manualHeight = 720;

	public int manualWidth = 480;

	public int minimumHeight = 320;

	public int maximumHeight = 1536;

	private Transform mTrans;

	public bool runOnlyOnce;

	public static List<UIRoot> list => mRoots;

	public float activeWidth
	{
		get
		{
			Vector2 vector = new Vector2(Screen.width, Screen.height);
			return (vector * GetPixelSizeAdjustment(Screen.height, Screen.width)).x;
		}
	}

	public int activeHeight
	{
		get
		{
			int num = Mathf.Max(2, Screen.height);
			if (scalingStyle == Scaling.FixedSize)
			{
				return manualHeight;
			}
			if (scalingStyle == Scaling.FixedSizeOnMobiles)
			{
				return manualHeight;
			}
			if (scalingStyle == Scaling.FixedWidth)
			{
				float num2 = (float)manualHeight / (float)manualWidth / ((float)Screen.height / (float)Screen.width);
				return (int)((float)manualHeight / num2);
			}
			if (scalingStyle == Scaling.FixedWidthShrinkOnly)
			{
				float num3 = (float)manualHeight / (float)manualWidth / ((float)Screen.height / (float)Screen.width);
				if (num3 < 1f)
				{
					return (int)((float)manualHeight / num3);
				}
				return manualHeight;
			}
			if (num < minimumHeight)
			{
				return minimumHeight;
			}
			if (num > maximumHeight)
			{
				return maximumHeight;
			}
			return num;
		}
	}

	public float pixelSizeAdjustment => GetPixelSizeAdjustment(Screen.height, Screen.width);

	public float fontPixelSizeAdjustment => (float)Mathf.Min(1536, Screen.height) / (float)activeHeight * Localization.languageConstant;

	public static float GetPixelSizeAdjustment(GameObject go)
	{
		UIRoot uIRoot = NGUITools.FindInParents<UIRoot>(go);
		return (!(uIRoot != null)) ? 1f : uIRoot.pixelSizeAdjustment;
	}

	public float GetPixelSizeAdjustment(int height, int width)
	{
		height = Mathf.Max(2, height);
		if (scalingStyle == Scaling.FixedSize)
		{
			return (float)manualHeight / (float)height;
		}
		if (scalingStyle == Scaling.FixedSizeOnMobiles)
		{
			return (float)manualHeight / (float)height;
		}
		if (scalingStyle == Scaling.FixedWidth)
		{
			return (float)manualWidth / (float)width;
		}
		if (scalingStyle == Scaling.FixedWidthShrinkOnly)
		{
			float num = (float)manualHeight / (float)manualWidth / ((float)height / (float)width);
			float result = (float)manualWidth / (float)width;
			if (num > 1f)
			{
				float num2 = (float)width / num;
				result = (float)manualWidth / num2;
			}
			return result;
		}
		if (height < minimumHeight)
		{
			return (float)minimumHeight / (float)height;
		}
		if (height > maximumHeight)
		{
			return (float)maximumHeight / (float)height;
		}
		return 1f;
	}

	private void Awake()
	{
		mTrans = base.transform;
		mRoots.Add(this);
		if (automatic)
		{
			scalingStyle = Scaling.PixelPerfect;
			automatic = false;
		}
	}

	private void OnDestroy()
	{
		mRoots.Remove(this);
	}

	private void Start()
	{
		UIOrthoCamera componentInChildren = GetComponentInChildren<UIOrthoCamera>();
		if (componentInChildren != null)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogWarning("UIRoot should not be active at the same time as UIOrthoCamera. Disabling UIOrthoCamera.", componentInChildren);
			}
			Camera component = componentInChildren.gameObject.GetComponent<Camera>();
			componentInChildren.enabled = false;
			if (component != null)
			{
				component.orthographicSize = 1f;
			}
		}
		CalculateScale();
	}

	private void Update()
	{
		if (!runOnlyOnce)
		{
			CalculateScale();
		}
	}

	private void CalculateScale()
	{
		if (!(mTrans != null))
		{
			return;
		}
		float num = activeHeight;
		if (num > 0f)
		{
			float num2 = 2f / num;
			Vector3 localScale = mTrans.localScale;
			if (!(Mathf.Abs(localScale.x - num2) <= float.Epsilon) || !(Mathf.Abs(localScale.y - num2) <= float.Epsilon) || !(Mathf.Abs(localScale.z - num2) <= float.Epsilon))
			{
				mTrans.localScale = new Vector3(num2, num2, num2);
			}
		}
	}

	public static void Broadcast(string funcName)
	{
		int i = 0;
		for (int count = mRoots.Count; i < count; i++)
		{
			UIRoot uIRoot = mRoots[i];
			if (uIRoot != null)
			{
				uIRoot.BroadcastMessage(funcName, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public static void Broadcast(string funcName, object param)
	{
		if (param == null)
		{
			if (Debug.isDebugBuild)
			{
				Debug.LogError("SendMessage is bugged when you try to pass 'null' in the parameter field. It behaves as if no parameter was specified.");
			}
			return;
		}
		int i = 0;
		for (int count = mRoots.Count; i < count; i++)
		{
			UIRoot uIRoot = mRoots[i];
			if (uIRoot != null)
			{
				uIRoot.BroadcastMessage(funcName, param, SendMessageOptions.DontRequireReceiver);
			}
		}
	}
}
