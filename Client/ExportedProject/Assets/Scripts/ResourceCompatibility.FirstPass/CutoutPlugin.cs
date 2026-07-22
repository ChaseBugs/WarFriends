using System;
using System.Collections.Generic;
using UnityEngine;

public class CutoutPlugin : MonoBehaviour
{
	public static CutoutPlugin instance;

	private float w;

	private float h;

	private List<Rect> rects;

	private float computedSafeBorder;

	public Action cutoutChanged;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void parseRect(string rect)
	{
	}

	private void ComputeBounds()
	{
	}

	private void ParseData(string data)
	{
	}

	private void CutoutChanged(string data)
	{
	}

	public float GetSafeBorderScale()
	{
		return 0f;
	}

	public float GetSafeWidthScale()
	{
		return 0f;
	}
}
