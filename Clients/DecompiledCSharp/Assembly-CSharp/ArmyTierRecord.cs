using System.Collections.Generic;
using UnityEngine;

public class ArmyTierRecord : PoolableObject
{
	[Header("Look")]
	public UILabel tierName;

	public GameObject starsParent;

	public List<UISprite> stars;

	public void Initialize(int tierNumber)
	{
		tierName.text = string.Format("{0} {1}", Localization.Localize("ID_TIER"), tierNumber);
		starsParent.transform.localPosition = new Vector3(starsParent.transform.localPosition.x, -108f + tierName.relativeSize.x * tierName.transform.localScale.x + 28f, starsParent.transform.localPosition.z);
		for (int i = 0; i < stars.Count; i++)
		{
			stars[i].gameObject.SetActive(i < tierNumber);
		}
	}
}
