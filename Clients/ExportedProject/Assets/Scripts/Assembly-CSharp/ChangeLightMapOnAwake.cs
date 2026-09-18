using UnityEngine;

[ExecuteInEditMode]
public class ChangeLightMapOnAwake : Core_BaseScript
{
	[Compact]
	public Vector4 lightMapScale = default(Vector4);

	public bool change;

	protected override void Awake()
	{
		base.Awake();
		ChangeScale();
	}

	private void ChangeScale()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (component != null)
		{
			component.lightmapScaleOffset = lightMapScale;
			component.realtimeLightmapScaleOffset = lightMapScale;
		}
	}

	protected void Update()
	{
		if (change)
		{
			change = false;
			ChangeScale();
		}
	}
}
