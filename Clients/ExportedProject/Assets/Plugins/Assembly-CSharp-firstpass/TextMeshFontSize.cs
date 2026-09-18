using UnityEngine;

public class TextMeshFontSize : Core_BaseScript
{
	[SerializeField]
	private TextMesh mTextMesh;

	protected override void Awake()
	{
		base.Awake();
		if (mTextMesh != null)
		{
			mTextMesh.fontSize = (int)(UIRoot.list[0].fontPixelSizeAdjustment * (float)mTextMesh.fontSize);
			mTextMesh.characterSize /= UIRoot.list[0].fontPixelSizeAdjustment;
		}
		Object.Destroy(this);
	}
}
