using UnityEngine;

public class LockRotation : Core_BaseScript
{
	public bool lockY = true;

	protected void LateUpdate()
	{
		Vector3 eulerAngles = base.transform.rotation.eulerAngles;
		if (lockY)
		{
			eulerAngles.y = 0f;
		}
		base.transform.rotation = Quaternion.Euler(eulerAngles);
	}
}
