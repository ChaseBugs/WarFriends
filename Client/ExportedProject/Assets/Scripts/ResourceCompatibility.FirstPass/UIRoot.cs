using System.Collections.Generic;
using UnityEngine;

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

	private static List<UIRoot> mRoots;

	public Scaling scalingStyle;

	[HideInInspector]
	public bool automatic;

	public int manualHeight;

	public int manualWidth;

	public int minimumHeight;

	public int maximumHeight;

	private Transform mTrans;

	public bool runOnlyOnce;

	public static List<UIRoot> list => null;

	public float activeWidth => 0f;

	public int activeHeight => 0;

	public float pixelSizeAdjustment => 0f;

	public float fontPixelSizeAdjustment => 0f;

	public static float GetPixelSizeAdjustment(GameObject go)
	{
		return 0f;
	}

	public float GetPixelSizeAdjustment(int height, int width)
	{
		return 0f;
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void CalculateScale()
	{
	}

	public static void Broadcast(string funcName)
	{
	}

	public static void Broadcast(string funcName, object param)
	{
	}
}
