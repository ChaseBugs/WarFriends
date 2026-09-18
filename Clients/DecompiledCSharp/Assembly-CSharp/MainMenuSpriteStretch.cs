using UnityEngine;

public class MainMenuSpriteStretch : Core_BaseScript
{
	public Vector2 defaultScreenSize = new Vector2(1920f, 1440f);

	public Vector2 defaultPictureSize = new Vector2(1920f, 1312f);

	public UISprite mainSprite;

	private bool mInitialized;

	protected override void Awake()
	{
		base.Awake();
		if (!mInitialized)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		mInitialized = true;
		bool flag = base.transform.localRotation == Quaternion.Euler(0f, 0f, 90f) || base.transform.localRotation == Quaternion.Euler(0f, 0f, 270f);
		mainSprite.MakePixelPerfect();
		float x = mainSprite.transform.localScale.x;
		float y = mainSprite.transform.localScale.y;
		Vector2 vector = new Vector2((!flag) ? x : y, (!flag) ? y : x);
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		float a = 1f;
		float b = 1f;
		if (activeWidth > vector.x)
		{
			a = activeWidth * (defaultPictureSize.x / defaultScreenSize.x) / vector.x;
		}
		if (num > vector.y)
		{
			b = num * (defaultPictureSize.y / defaultScreenSize.y) / vector.y;
		}
		float num2 = Mathf.Max(a, b);
		Vector2 vector2 = vector * num2;
		mainSprite.transform.localScale = new Vector3((!flag) ? vector2.x : vector2.y, (!flag) ? vector2.y : vector2.x, mainSprite.transform.localScale.z);
	}
}
