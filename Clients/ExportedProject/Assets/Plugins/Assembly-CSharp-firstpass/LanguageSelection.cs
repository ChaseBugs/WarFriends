using UnityEngine;

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
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
