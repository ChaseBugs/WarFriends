using System;
using UnityEngine;

[Serializable]
public class tk2dCameraSettings
{
	public enum ProjectionType
	{
		Orthographic,
		Perspective
	}

	public enum OrthographicType
	{
		PixelsPerMeter,
		OrthographicSize
	}

	public enum OrthographicOrigin
	{
		BottomLeft,
		Center
	}

	public ProjectionType projection;

	public float orthographicSize;

	public float orthographicPixelsPerMeter;

	public OrthographicOrigin orthographicOrigin;

	public OrthographicType orthographicType;

	public float fieldOfView;

	public Rect rect;
}
