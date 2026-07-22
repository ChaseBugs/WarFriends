using UnityEngine;

public class QuickRope2Helper
{
	public static bool HasMoved(ref Vector3 prevPoint, Vector3 curPoint)
	{
		bool flag = Vector3.Distance(curPoint, prevPoint) >= 0.01f;
		if (flag)
		{
			prevPoint = curPoint;
		}
		return flag;
	}
}
