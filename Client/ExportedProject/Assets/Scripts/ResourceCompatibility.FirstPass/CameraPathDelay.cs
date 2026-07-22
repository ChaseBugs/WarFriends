using UnityEngine;

public class CameraPathDelay : CameraPathPoint
{
	public float time;

	public float introStartEasePercentage;

	public AnimationCurve introCurve;

	public float outroEndEasePercentage;

	public AnimationCurve outroCurve;
}
