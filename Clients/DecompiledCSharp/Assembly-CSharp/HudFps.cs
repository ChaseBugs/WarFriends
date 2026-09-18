using System.Collections;
using UnityEngine;

internal class HudFps : MonoBehaviour
{
	private UILabel label;

	private void Awake()
	{
		label = GetComponent<UILabel>();
		DebugSettings.instance.Changed += SettingsChanged;
	}

	private void SettingsChanged()
	{
	}

	private void OnEnable()
	{
		StartCoroutine(FPS());
		label.text = string.Empty;
	}

	private void UpdateDisplay()
	{
	}

	private IEnumerator FPS()
	{
		while (true)
		{
			UpdateDisplay();
			yield return new WaitForSeconds(0.333f);
		}
	}
}
