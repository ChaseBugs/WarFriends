using System;
using UnityEngine;

public class DollyZoom : MonoBehaviour
{
	public Transform target;

	private float initHeightAtDist;

	public bool dzEnabled;

	private float FrustumHeightAtDistance(float distance)
	{
		return 2f * distance * Mathf.Tan(GetComponent<Camera>().fieldOfView * 0.5f * ((float)Math.PI / 180f));
	}

	private float FOVForHeightAndDistance(float height, float distance)
	{
		return 2f * Mathf.Atan(height * 0.5f / distance) * 57.29578f;
	}

	private void StartDZ()
	{
		float distance = Vector3.Distance(base.transform.position, target.position);
		initHeightAtDist = FrustumHeightAtDistance(distance);
		dzEnabled = true;
	}

	private void StopDZ()
	{
		dzEnabled = false;
	}

	private void Start()
	{
		StartDZ();
	}

	private void Update()
	{
		if (dzEnabled)
		{
			float distance = Vector3.Distance(base.transform.position, target.position);
			GetComponent<Camera>().fieldOfView = FOVForHeightAndDistance(initHeightAtDist, distance);
		}
		base.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 5f);
	}
}
