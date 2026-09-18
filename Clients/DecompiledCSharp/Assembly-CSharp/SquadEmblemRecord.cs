using UnityEngine;

public class SquadEmblemRecord : PoolableObject
{
	[Header("Main Part")]
	public BoxCollider boxCollider;

	public UITexture squadIcon;

	public UISprite highlightSprite;

	[Header("Locked Part")]
	public GameObject lockedPart;

	public UILabel lockedLabel;

	[HideInInspector]
	public string squadIconName = string.Empty;

	public void Initialize(string spriteName, int squadDisplayLevel, int lockedLevel)
	{
		squadIconName = spriteName;
		Texture texture = Resources.Load<Texture>("SquadIcons/" + spriteName);
		if (texture == null)
		{
			Debug.LogError("Squad Emblem " + squadIconName + " is not present in resources using default");
			squadIconName = "menu-squad-1";
			texture = Resources.Load<Texture>("SquadIcons/" + squadIconName);
		}
		squadIcon.mainTexture = texture;
		squadIcon.MakePixelPerfect();
		bool flag = lockedLevel > squadDisplayLevel;
		lockedPart.SetActive(flag);
		if (flag)
		{
			lockedLabel.text = string.Format("{0} {1}", Localization.Localize("ID_SQUADRANK"), lockedLevel);
			float defaultHeight = ((!(Localization.instance.currentLanguage == "br")) ? 30f : 26f);
			MiscTools.SetUILabelRescale(lockedLabel, defaultHeight, 20f, 320);
		}
		bool flag2 = MiscTools.CompareSquadRanks(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 0;
		boxCollider.enabled = !lockedPart.activeSelf && flag2;
		Highlight(highlight: false);
	}

	public void Highlight(bool highlight)
	{
		highlightSprite.alpha = ((!highlight) ? 0f : 1f);
	}

	private void OnClick()
	{
		bool flag = MiscTools.CompareSquadRanks(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 0;
		if (!lockedPart.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.emblemContent.UseEmblemClick(this);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		squadIcon.mainTexture = null;
		squadIconName = string.Empty;
	}
}
