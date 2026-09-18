using UnityEngine;

[ExecuteInEditMode]
public class PerformanceManager : Singleton<PerformanceManager>
{
	private Performance mPerformance;

	public static float iOSVersion => 8f;

	public Performance performance
	{
		get
		{
			return mPerformance;
		}
		set
		{
			Debug.Log("Setting performance to: " + value);
			mPerformance = value;
		}
	}

	public bool isHD => Screen.width > 1024 && Screen.height > 640;

	public bool isMetal => false;

	public bool enableBubbles => true;

	public static bool antialiasing
	{
		get
		{
			if (PlayerPrefs.HasKey("antialiasing"))
			{
				return PlayerPrefs.GetInt("antialiasing") > 0;
			}
			bool flag = false;
			PlayerPrefs.SetInt("antialiasing", flag ? 2 : 0);
			return flag;
		}
		set
		{
			PlayerPrefs.SetInt("antialiasing", value ? 2 : 0);
		}
	}

	private void GetPerformance()
	{
		mPerformance = Performance.Best;
		int systemMemorySize = SystemInfo.systemMemorySize;
		if (Screen.width > 1024 && Screen.height > 768 && (systemMemorySize < 32 || systemMemorySize > 1252))
		{
			mPerformance = Performance.Best;
		}
		else
		{
			mPerformance = Performance.Shitty;
		}
	}

	public void SetShadowsDistance(bool shortDistance)
	{
		QualitySettings.shadowDistance = ((!shortDistance) ? 14.5f : 8f);
	}

	protected override void Awake()
	{
		base.Awake();
		GetPerformance();
		int num = 0;
		if (mPerformance == Performance.Good)
		{
			num = 4;
		}
		if (mPerformance == Performance.Best)
		{
			num = 8;
		}
		if (Application.isPlaying)
		{
			if (DebugSettings.instance.alwaysShittyPerformance)
			{
				mPerformance = Performance.Shitty;
				Debug.Log("SETTING HalfResNoMs");
				QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
			}
			else
			{
				switch (mPerformance)
				{
				case Performance.Shitty:
					Debug.Log("SETTING HalfResNoMS");
					QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
					break;
				case Performance.Good:
				case Performance.Best:
					if (antialiasing)
					{
						Debug.Log("SETTING FullRes2xMS");
						QualitySettings.SetQualityLevel(0, applyExpensiveChanges: true);
					}
					else
					{
						Debug.Log("SETTING FullResNoMS");
						QualitySettings.SetQualityLevel(2, applyExpensiveChanges: true);
					}
					break;
				default:
					Debug.Log("SETTING HalfResNoMS");
					QualitySettings.SetQualityLevel(3, applyExpensiveChanges: true);
					break;
				}
			}
			int qualityLevel = QualitySettings.GetQualityLevel();
			Debug.LogWarningFormat("QUALITY LEVEL: {0} DPI: {1} System memory: {2} Graphics memory: {3}", qualityLevel, Screen.dpi, SystemInfo.systemMemorySize, SystemInfo.graphicsMemorySize);
		}
		Object.DontDestroyOnLoad(this);
	}
}
