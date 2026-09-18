using UnityEngine;

public class GyroController : MonoBehaviour
{
	private bool gyroEnabled = true;

	private Quaternion cameraBase = Quaternion.identity;

	private Quaternion calibration = Quaternion.identity;

	private Quaternion baseOrientation = Quaternion.Euler(90f, 0f, 0f);

	private Quaternion referanceRotation = Quaternion.identity;

	public Quaternion Rotation;

	protected void Start()
	{
		Singleton<GameController>.instance.GameStarted += InstanceOnGameStarted;
	}

	private void InstanceOnGameStarted()
	{
	}

	public void AttachGyro()
	{
		gyroEnabled = true;
		UpdateCalibration(onlyHorizontal: true);
		RecalculateReferenceRotation();
	}

	private void DetachGyro()
	{
		gyroEnabled = false;
	}

	private void UpdateCalibration(bool onlyHorizontal)
	{
		if (onlyHorizontal)
		{
			Vector3 vector = Input.gyro.attitude * -Vector3.forward;
			vector.z = 0f;
			if (vector == Vector3.zero)
			{
				calibration = Quaternion.identity;
			}
			else
			{
				calibration = Quaternion.FromToRotation(Vector3.up, vector);
			}
		}
		else
		{
			calibration = Input.gyro.attitude;
		}
	}

	private static Quaternion ConvertRotation(Quaternion q)
	{
		return new Quaternion(q.x, q.y, 0f - q.z, 0f - q.w);
	}

	private void ResetBaseOrientation()
	{
	}

	private void RecalculateReferenceRotation()
	{
		referanceRotation = Quaternion.Inverse(baseOrientation) * Quaternion.Inverse(calibration);
	}
}
