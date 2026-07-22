using System;
using UnityEngine;

[Serializable]
public class tk2dCameraResolutionOverride
{
	public enum MatchByType
	{
		Resolution,
		AspectRatio,
		Wildcard
	}

	public enum AutoScaleMode
	{
		None,
		FitWidth,
		FitHeight,
		FitVisible,
		StretchToFit,
		ClosestMultipleOfTwo,
		PixelPerfect
	}

	public enum FitMode
	{
		Constant,
		Center
	}

	public string name;

	public MatchByType matchBy;

	public int width;

	public int height;

	public float aspectRatioNumerator;

	public float aspectRatioDenominator;

	public float scale;

	public Vector2 offsetPixels;

	public AutoScaleMode autoScaleMode;

	public FitMode fitMode;

	public static tk2dCameraResolutionOverride DefaultOverride => null;

	public bool Match(int pixelWidth, int pixelHeight)
	{
		return false;
	}

	public void Upgrade(int version)
	{
	}
}
