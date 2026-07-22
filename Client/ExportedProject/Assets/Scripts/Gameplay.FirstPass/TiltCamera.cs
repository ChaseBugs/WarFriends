using UnityEngine;

public class TiltCamera : MonoBehaviour
{
	public bool tiltSteerActive = true;

	public float smooth = 10f;

	private float lerpingFactor;

	public float tiltSpeedX = 1f;

	public float tiltSpeedY = 1f;

	private Vector3 localPosition;

	private Vector3 betweenLerp;

	private float speedX;

	private float speedY;

	public float offsetX;

	public float offsetY;

	private Vector3 mStartPos;

	public float maxDistanceX = 1f;

	public float maxDistanceY = 0.1f;

	private bool CheckModel(string desiredModel, int minVersion)
	{
		string deviceModel = SystemInfo.deviceModel;
		if (deviceModel.StartsWith(desiredModel))
		{
			Debug.Log("Gyro: CheckModel" + desiredModel);
			string text = deviceModel.Replace(desiredModel, string.Empty);
			string[] array = text.Split(',');
			if (array.Length > 0)
			{
				int result = 0;
				int.TryParse(array[0], out result);
				Debug.Log($"Gyro: CheckModel version {result}");
				if (result >= minVersion)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void Start()
	{
		Input.gyro.enabled = tiltSteerActive;
		mStartPos = base.transform.position;
	}

	private void Update()
	{
		lerpingFactor = 1f / smooth;
		if (tiltSteerActive)
		{
			Vector3 position = base.transform.position;
			speedY = Input.gyro.rotationRateUnbiased.x * tiltSpeedX;
			speedX = Input.gyro.rotationRateUnbiased.y * tiltSpeedY;
			localPosition.y = (0f - speedY) * Mathf.Exp(2f) + offsetY;
			localPosition.x = speedX * Mathf.Exp(2f) + offsetX;
			localPosition.z = 0f;
			betweenLerp = Vector3.Lerp(position, position + localPosition, 0.1f);
			Vector3 vector = Vector3.Lerp(position, betweenLerp, lerpingFactor);
			Vector3 vector2 = vector - mStartPos;
			if (Mathf.Abs(vector2.x) > maxDistanceX)
			{
				vector2.x = ((!(vector2.x > 0f)) ? (0f - maxDistanceX) : maxDistanceX);
			}
			if (Mathf.Abs(vector2.y) > maxDistanceY)
			{
				vector2.y = ((!(vector2.y > 0f)) ? (0f - maxDistanceY) : maxDistanceY);
			}
			vector = mStartPos + vector2;
			base.transform.position = vector;
		}
		if (tiltSteerActive && !Input.gyro.enabled)
		{
			Input.gyro.enabled = true;
		}
		if (!tiltSteerActive && Input.gyro.enabled)
		{
			Input.gyro.enabled = false;
		}
	}
}
