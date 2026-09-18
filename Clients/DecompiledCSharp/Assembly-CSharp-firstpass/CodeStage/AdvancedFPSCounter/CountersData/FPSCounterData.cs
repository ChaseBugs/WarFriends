using System;
using UnityEngine;

namespace CodeStage.AdvancedFPSCounter.CountersData;

[Serializable]
public class FPSCounterData : BaseCounterData
{
	private const string COROUTINE_NAME = "UpdateFPSCounter";

	private const string FPS_TEXT_START = "[{0}]FPS: ";

	private const string FPS_TEXT_END = "";

	private const string MIN_TEXT_START = "\n[{0}]MIN: ";

	private const string MIN_TEXT_END = " ";

	private const string MAX_TEXT_START = "[{0}]MAX: ";

	private const string MAX_TEXT_END = "";

	private const string AVG_TEXT_START = " [{0}]AVG: ";

	private const string AVG_TEXT_END = "";

	public int warningLevelValue = 30;

	public int criticalLevelValue = 10;

	public bool resetAverageOnNewScene;

	public bool resetMinMaxOnNewScene;

	[HideInInspector]
	public int lastValue;

	[HideInInspector]
	public int lastAverageValue;

	[HideInInspector]
	public int lastMinimumValue = -1;

	[HideInInspector]
	public int lastMaximumValue = -1;

	[SerializeField]
	[Range(0.1f, 10f)]
	private float updateInterval = 0.5f;

	[SerializeField]
	private bool showAverage = true;

	[SerializeField]
	[Range(0f, 100f)]
	private int averageFromSamples = 100;

	[SerializeField]
	private bool showMinMax = true;

	[SerializeField]
	private Color colorWarning = new Color32(236, 224, 88, byte.MaxValue);

	[SerializeField]
	private Color colorCritical = new Color32(249, 91, 91, byte.MaxValue);

	internal int newValue;

	private string colorCachedMin;

	private string colorCachedMax;

	private string colorCachedAvg;

	private string colorWarningCached;

	private string colorWarningCachedMin;

	private string colorWarningCachedMax;

	private string colorWarningCachedAvg;

	private string colorCriticalCached;

	private string colorCriticalCachedMin;

	private string colorCriticalCachedMax;

	private string colorCriticalCachedAvg;

	private bool inited;

	private int currentAverageSamples;

	private float currentAverageRaw;

	private float[] accumulatedAverageSamples;

	public float UpdateInterval
	{
		get
		{
			return updateInterval;
		}
		set
		{
			if (!(Math.Abs(updateInterval - value) < 0.001f) && Application.isPlaying)
			{
				updateInterval = value;
				if (enabled)
				{
					RestartCoroutine();
				}
			}
		}
	}

	public bool ShowAverage
	{
		get
		{
			return showAverage;
		}
		set
		{
			if (showAverage == value || !Application.isPlaying)
			{
				return;
			}
			showAverage = value;
			if (enabled)
			{
				if (!showAverage)
				{
					ResetAverage();
				}
				Refresh();
			}
		}
	}

	public int AverageFromSamples
	{
		get
		{
			return averageFromSamples;
		}
		set
		{
			if (averageFromSamples == value || !Application.isPlaying)
			{
				return;
			}
			averageFromSamples = value;
			if (!enabled)
			{
				return;
			}
			if (averageFromSamples > 0)
			{
				if (accumulatedAverageSamples == null)
				{
					accumulatedAverageSamples = new float[averageFromSamples];
				}
				else if (accumulatedAverageSamples.Length != averageFromSamples)
				{
					Array.Resize(ref accumulatedAverageSamples, averageFromSamples);
				}
			}
			else
			{
				accumulatedAverageSamples = null;
			}
			ResetAverage();
			Refresh();
		}
	}

	public bool ShowMinMax
	{
		get
		{
			return showMinMax;
		}
		set
		{
			if (showMinMax == value || !Application.isPlaying)
			{
				return;
			}
			showMinMax = value;
			if (enabled)
			{
				if (!showMinMax)
				{
					ResetMinMax();
				}
				Refresh();
			}
		}
	}

	public Color ColorWarning
	{
		get
		{
			return colorWarning;
		}
		set
		{
			if (!(colorWarning == value) && Application.isPlaying)
			{
				colorWarning = value;
				if (enabled)
				{
					CacheWarningColor();
					Refresh();
				}
			}
		}
	}

	public Color ColorCritical
	{
		get
		{
			return colorCritical;
		}
		set
		{
			if (!(colorCritical == value) && Application.isPlaying)
			{
				colorCritical = value;
				if (enabled)
				{
					CacheCriticalColor();
					Refresh();
				}
			}
		}
	}

	internal FPSCounterData()
	{
		color = new Color32(85, 218, 102, byte.MaxValue);
	}

	public void ResetAverage()
	{
		lastAverageValue = 0;
		currentAverageSamples = 0;
		currentAverageRaw = 0f;
		if (averageFromSamples > 0 && accumulatedAverageSamples != null)
		{
			Array.Clear(accumulatedAverageSamples, 0, accumulatedAverageSamples.Length);
		}
	}

	public void ResetMinMax()
	{
		lastMinimumValue = -1;
		lastMaximumValue = -1;
		UpdateValue(force: true);
		dirty = true;
	}

	internal override void Activate()
	{
		if (!enabled || inited)
		{
			return;
		}
		base.Activate();
		inited = true;
		lastValue = 0;
		if (main.OperationMode == AFPSCounterOperationMode.Normal)
		{
			if (colorCached == null)
			{
				CacheCurrentColor();
			}
			if (colorWarningCached == null)
			{
				CacheWarningColor();
			}
			if (colorCriticalCached == null)
			{
				CacheCriticalColor();
			}
			text.Append(colorCriticalCached).Append("0").Append(string.Empty);
			dirty = true;
		}
		main.StartCoroutine("UpdateFPSCounter");
	}

	internal override void Deactivate()
	{
		if (inited)
		{
			base.Deactivate();
			main.StopCoroutine("UpdateFPSCounter");
			ResetMinMax();
			ResetAverage();
			lastValue = 0;
			inited = false;
		}
	}

	internal override void UpdateValue(bool force)
	{
		if (!enabled)
		{
			return;
		}
		if (lastValue != newValue || force)
		{
			lastValue = newValue;
			dirty = true;
		}
		int num = 0;
		if (showAverage)
		{
			if (averageFromSamples == 0)
			{
				currentAverageSamples++;
				currentAverageRaw += ((float)lastValue - currentAverageRaw) / (float)currentAverageSamples;
			}
			else
			{
				if (accumulatedAverageSamples == null)
				{
					accumulatedAverageSamples = new float[averageFromSamples];
					ResetAverage();
				}
				accumulatedAverageSamples[currentAverageSamples % averageFromSamples] = lastValue;
				currentAverageSamples++;
				currentAverageRaw = GetAverageFromAccumulatedSamples();
			}
			num = Mathf.RoundToInt(currentAverageRaw);
			if (lastAverageValue != num || force)
			{
				lastAverageValue = num;
				dirty = true;
			}
		}
		if (showMinMax && dirty)
		{
			if (lastMinimumValue == -1)
			{
				lastMinimumValue = lastValue;
			}
			else if (lastValue < lastMinimumValue)
			{
				lastMinimumValue = lastValue;
				dirty = true;
			}
			if (lastMaximumValue == -1)
			{
				lastMaximumValue = lastValue;
			}
			else if (lastValue > lastMaximumValue)
			{
				lastMaximumValue = lastValue;
				dirty = true;
			}
		}
		if (dirty && main.OperationMode == AFPSCounterOperationMode.Normal)
		{
			string value = ((lastValue >= warningLevelValue) ? colorCached : ((lastValue > criticalLevelValue) ? colorWarningCached : colorCriticalCached));
			text.Length = 0;
			text.Append(value).Append(lastValue).Append(string.Empty);
			if (showAverage)
			{
				value = ((num >= warningLevelValue) ? colorCachedAvg : ((num > criticalLevelValue) ? colorWarningCachedAvg : colorCriticalCachedAvg));
				text.Append(value).Append(num).Append(string.Empty);
			}
			if (showMinMax)
			{
				value = ((lastMinimumValue >= warningLevelValue) ? colorCachedMin : ((lastMinimumValue > criticalLevelValue) ? colorWarningCachedMin : colorCriticalCachedMin));
				text.Append(value).Append(lastMinimumValue).Append(" ");
				value = ((lastMaximumValue >= warningLevelValue) ? colorCachedMax : ((lastMaximumValue > criticalLevelValue) ? colorWarningCachedMax : colorCriticalCachedMax));
				text.Append(value).Append(lastMaximumValue).Append(string.Empty);
			}
		}
	}

	protected override void CacheCurrentColor()
	{
		string arg = AFPSCounter.Color32ToHex2(color);
		colorCached = $"[{arg}]FPS: ";
		colorCachedMin = $"\n[{arg}]MIN: ";
		colorCachedMax = $"[{arg}]MAX: ";
		colorCachedAvg = $" [{arg}]AVG: ";
	}

	protected void CacheWarningColor()
	{
		string arg = AFPSCounter.Color32ToHex2(colorWarning);
		colorWarningCached = $"[{arg}]FPS: ";
		colorWarningCachedMin = $"\n[{arg}]MIN: ";
		colorWarningCachedMax = $"[{arg}]MAX: ";
		colorWarningCachedAvg = $" [{arg}]AVG: ";
	}

	protected void CacheCriticalColor()
	{
		string arg = AFPSCounter.Color32ToHex2(colorCritical);
		colorCriticalCached = $"[{arg}]FPS: ";
		colorCriticalCachedMin = $"\n[{arg}]MIN: ";
		colorCriticalCachedMax = $"[{arg}]MAX: ";
		colorCriticalCachedAvg = $" [{arg}]AVG: ";
	}

	private void RestartCoroutine()
	{
		main.StopCoroutine("UpdateFPSCounter");
		main.StartCoroutine("UpdateFPSCounter");
	}

	private float GetAverageFromAccumulatedSamples()
	{
		float num = 0f;
		for (int i = 0; i < averageFromSamples; i++)
		{
			num += accumulatedAverageSamples[i];
		}
		if (currentAverageSamples < averageFromSamples)
		{
			return num / (float)currentAverageSamples;
		}
		return num / (float)averageFromSamples;
	}
}
