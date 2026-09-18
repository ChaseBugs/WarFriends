using UnityEngine;

public struct PositionTime
{
	public Vector3 position;

	public float time;

	public bool slowDown;

	public PositionTime(Vector3 position, float time, bool slowDown)
	{
		this.position = position;
		this.time = time;
		this.slowDown = slowDown;
	}
}
