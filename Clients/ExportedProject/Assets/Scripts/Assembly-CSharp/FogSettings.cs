using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class FogSettings : MonoBehaviour
{
	public bool fogEnabled;

	public Color fogColor;

	public float fogDensity;

	public FogMode fogMode;

	public float fogStartDistance;

	public float fogEndDistance;

	public bool distanceFog;

	public bool useRadialDistance;

	public bool heightFog;

	public float height;

	public float heightDensity;

	public float startDistance;

	private GlobalFog mGlobalFog;

	private void Start()
	{
		SetFogParameters();
	}

	[ContextMenu("Set Fog Parameters")]
	private void SetFogParameters()
	{
		mGlobalFog = Camera.main.GetComponent<GlobalFog>();
		if (mGlobalFog != null)
		{
			mGlobalFog.enabled = fogEnabled;
			mGlobalFog.fogColor = fogColor;
			mGlobalFog.fogDensity = fogDensity;
			mGlobalFog.fogEndDistance = fogEndDistance;
			mGlobalFog.fogMode = fogMode;
			mGlobalFog.fogStartDistance = fogStartDistance;
			mGlobalFog.distanceFog = distanceFog;
			mGlobalFog.useRadialDistance = useRadialDistance;
			mGlobalFog.heightFog = heightFog;
			mGlobalFog.height = height;
			mGlobalFog.heightDensity = heightDensity;
			mGlobalFog.startDistance = startDistance;
		}
	}

	private void OnDestroy()
	{
		if (mGlobalFog != null)
		{
			mGlobalFog.enabled = false;
			mGlobalFog = null;
		}
	}
}
