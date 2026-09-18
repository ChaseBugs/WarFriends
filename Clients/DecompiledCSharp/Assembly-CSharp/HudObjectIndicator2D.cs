using UnityEngine;

public class HudObjectIndicator2D : PoolableObject
{
	public Transform mTransform;

	public myFilledSprite sprite;

	public tk2dSprite border;

	public tk2dSprite transparentBG;

	public float progress
	{
		set
		{
			if (sprite != null)
			{
				sprite.fillFract = value;
			}
		}
	}

	public Color colour
	{
		set
		{
			if (sprite != null)
			{
				sprite.color = value;
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mTransform = base.transform;
	}

	public virtual void Hide()
	{
		if (base.gameObject != null)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void SetPosition(Vector3 position)
	{
		mTransform.position = position;
	}

	public void SetSprite(string spriteName)
	{
		if (sprite != null)
		{
			sprite.SetSprite(spriteName);
		}
	}
}
