using UnityEngine;

public class SquadCreateEmblemRecord : PoolableObject
{
	[Header("Core")]
	public UITexture squadIcon;

	public UISprite background;

	private string mEmblemName;

	public void Initialize(string spriteName)
	{
		Texture texture = Resources.Load<Texture>("SquadIcons/" + spriteName);
		if (texture == null)
		{
			Debug.LogError("Squad Emblem " + spriteName + " is not present in resources using default");
			spriteName = "menu-squad-1";
			texture = Resources.Load<Texture>("SquadIcons/" + spriteName);
		}
		mEmblemName = spriteName;
		squadIcon.mainTexture = texture;
		squadIcon.MakePixelPerfect();
		squadIcon.transform.localScale = squadIcon.transform.localScale.MultiplyXY(0.5f);
		SetHighlight(string.Empty);
	}

	public void SetHighlight(string highlightedSprite)
	{
		background.gameObject.SetActive(mEmblemName == highlightedSprite);
	}

	private void OnClick()
	{
		GuiScreenSingle<SquadCreateScreen>.instance.SelectEmblem(mEmblemName);
	}

	public override void DestroyPooled()
	{
		squadIcon.mainTexture = null;
		base.DestroyPooled();
	}
}
