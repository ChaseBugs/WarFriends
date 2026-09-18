using UnityEngine;

public class CountryIconButton : PoolableObject
{
	[Header("Core")]
	public UISprite countryIcon;

	public UISprite highlight;

	public BoxCollider iconCollider;

	[HideInInspector]
	public string countryCode;

	public void Initialize(string countryFlagSpriteName, string countryType)
	{
		countryIcon.spriteName = countryFlagSpriteName;
		countryCode = countryType;
		Highlight(setHighligth: false);
	}

	public void Highlight(bool setHighligth)
	{
		highlight.gameObject.SetActive(setHighligth);
		iconCollider.enabled = !setHighligth;
	}
}
