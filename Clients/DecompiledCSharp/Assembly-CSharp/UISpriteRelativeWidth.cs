using UnityEngine;

[RequireComponent(typeof(UIWidget))]
public class UISpriteRelativeWidth : MonoBehaviour
{
	public int DesignWidth = 640;

	public int DesignHeight = 960;

	public bool ProportionalHeight;

	private void Start()
	{
		if (ProportionalHeight)
		{
			UISprite component = GetComponent<UISprite>();
			Rect rect = new Rect(component.GetAtlasSprite().outer);
			if (component.atlas.coordinates != UIAtlas.Coordinates.Pixels)
			{
				rect = NGUIMath.ConvertToPixels(rect, component.atlas.texture.width, component.atlas.texture.height, round: true);
			}
			Debug.Log("TEXTURE SIZE IS: " + rect.width + "x" + rect.height);
			float num = rect.height / rect.width;
			base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.x * num, 1f);
		}
	}

	private void Update()
	{
	}
}
