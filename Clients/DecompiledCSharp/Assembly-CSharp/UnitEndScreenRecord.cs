using UnityEngine;

public class UnitEndScreenRecord : PoolableObject
{
	[Header("Unit EndScreen")]
	public UIPanel unitPanel;

	public UISprite unitIcon;

	public UILabel unitName;

	public UILabel unitLevel;

	public UIPanel tierPanel;

	public UISprite[] tierIcons;

	public GameObject earlyUnlockPart;

	internal void Initialize(int index, int level, int tier = 0, bool isEarlyUnlock = false)
	{
		unitPanel.isFreezed = false;
		tierPanel.isFreezed = false;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[index];
		unitLevel.text = ((level != 0) ? string.Format("{0} {1}", Localization.Localize("ID_LEVEL"), level) : string.Empty);
		unitName.text = levelBehaviour.unitName.ToUpper();
		MiscTools.SetUILabelRescale(unitName, 25f, 20f, 290);
		unitIcon.spriteName = levelBehaviour.upgradeSlots.iconName;
		unitIcon.MakePixelPerfect();
		for (int i = 0; i < tierIcons.Length; i++)
		{
			tierIcons[i].gameObject.SetActive(i < tier);
		}
		earlyUnlockPart.SetActive(isEarlyUnlock);
		if (unitIcon.transform.localScale.y > 300f)
		{
			unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(200f / unitIcon.transform.localScale.y);
		}
		Vector3 localPosition = new Vector3(0f, 0f, unitIcon.transform.localPosition.z);
		if (unitIcon.transform.localScale.y > 200f)
		{
			localPosition.y = (unitIcon.transform.localScale.y - 200f) / 2f;
		}
		unitIcon.transform.localPosition = localPosition;
	}
}
