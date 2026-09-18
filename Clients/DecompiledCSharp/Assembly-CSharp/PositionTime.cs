using UnityEngine;

public struct PositionTime(Vector3 position, float time, bool slowDown)
{
	public Vector3 position = position;

	public float time = time;

	public bool slowDown = slowDown;
}
