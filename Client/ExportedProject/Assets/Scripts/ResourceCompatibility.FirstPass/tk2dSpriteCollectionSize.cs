using System;

[Serializable]
public class tk2dSpriteCollectionSize
{
	public enum Type
	{
		Explicit,
		PixelsPerMeter
	}

	public Type type;

	public float orthoSize;

	public float pixelsPerMeter;

	public float width;

	public float height;

	public float OrthoSize => 0f;

	public float TargetHeight => 0f;

	public static tk2dSpriteCollectionSize Explicit(float orthoSize, float targetHeight)
	{
		return null;
	}

	public static tk2dSpriteCollectionSize PixelsPerMeter(float pixelsPerMeter)
	{
		return null;
	}

	public static tk2dSpriteCollectionSize ForResolution(float orthoSize, float width, float height)
	{
		return null;
	}

	public static tk2dSpriteCollectionSize ForTk2dCamera()
	{
		return null;
	}

	public static tk2dSpriteCollectionSize ForTk2dCamera(tk2dCamera camera)
	{
		return null;
	}

	public static tk2dSpriteCollectionSize Default()
	{
		return null;
	}

	public void CopyFromLegacy(bool useTk2dCamera, float orthoSize, float targetHeight)
	{
	}

	public void CopyFrom(tk2dSpriteCollectionSize source)
	{
	}
}
