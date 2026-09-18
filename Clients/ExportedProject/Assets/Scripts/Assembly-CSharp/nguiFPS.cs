using System.Collections;
using CodeStage.AdvancedFPSCounter;
using UnityEngine;

internal class nguiFPS : MonoBehaviour
{
	public float frequency = 0.1f;

	public int nbDecimal = 1;

	private Color color = Color.white;

	private UILabel label;

	public bool showVersion;

	private void Awake()
	{
		label = GetComponent<UILabel>();
		DebugSettings.instance.Changed += SettingsChanged;
	}

	private void SettingsChanged()
	{
		if (showVersion)
		{
			label.text = ((!DebugSettings.debugEnabled) ? string.Empty : ("(" + Singleton<CurrentBundleVersion>.instance.version + "r" + Singleton<CurrentBundleVersion>.instance.revision + ") " + Singleton<BeanstalkServerManager>.instance.GetEnvironmentName()));
		}
	}

	private void OnEnable()
	{
		if (showVersion)
		{
			label.text = ((!DebugSettings.debugEnabled) ? string.Empty : ("(" + Singleton<CurrentBundleVersion>.instance.version + "r" + Singleton<CurrentBundleVersion>.instance.revision + ") " + Singleton<BeanstalkServerManager>.instance.GetEnvironmentName()));
		}
		else
		{
			StartCoroutine(FPS());
		}
	}

	private void Update()
	{
		if (!showVersion)
		{
		}
	}

	private void UpdateDisplay()
	{
		if (!showVersion)
		{
			label.color = color;
			label.text = ((!DebugSettings.debugEnabled) ? string.Empty : AFPSCounter.Instance.fpsCounter.text.ToString());
		}
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
