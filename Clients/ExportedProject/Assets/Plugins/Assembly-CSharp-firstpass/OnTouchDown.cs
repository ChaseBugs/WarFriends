using UnityEngine;

public class OnTouchDown : MonoBehaviour
{
	public static float TouchLength;

	private void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Began))
		{
			TouchLength = 0f;
		}
		if (Input.touchCount > 0 && Input.GetTouch(0).phase.Equals(TouchPhase.Moved))
		{
			TouchLength += Input.GetTouch(0).deltaPosition.magnitude;
		}
		RaycastHit raycastHit = default(RaycastHit);
		for (int i = 0; i < Input.touchCount; i++)
		{
			if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
			{
				GameObject intersection = GetIntersection(Input.GetTouch(i).position);
				if (intersection != null)
				{
					intersection.SendMessage("OnTouchDown");
					break;
				}
			}
		}
	}

	public static GameObject GetIntersection(Vector2 touchPosition)
	{
		Ray ray = Camera.main.ScreenPointToRay(touchPosition);
		float num = float.PositiveInfinity;
		GameObject result = null;
		RaycastHit[] array = Physics.RaycastAll(ray);
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit raycastHit = array2[i];
			if (raycastHit.transform.position.z < num)
			{
				num = raycastHit.transform.position.z;
				result = raycastHit.transform.gameObject;
			}
		}
		return result;
	}
}
