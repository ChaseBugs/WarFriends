using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Language Selection")]
[RequireComponent(typeof(UIPopupList))]
public class LanguageSelection : MonoBehaviour
{
	private UIPopupList mList;

	private void OnLanguageSelection(string language)
	{
		if (Localization.instance != null)
		{
			Localization.instance.currentLanguage = language;
		}
	}
}
