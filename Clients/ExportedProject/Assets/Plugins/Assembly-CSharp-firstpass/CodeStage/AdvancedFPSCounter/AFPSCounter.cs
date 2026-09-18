using System;
using System.Collections;
using CodeStage.AdvancedFPSCounter.CountersData;
using CodeStage.AdvancedFPSCounter.Labels;
using UnityEngine;

namespace CodeStage.AdvancedFPSCounter
{
[AddComponentMenu("")]
public class AFPSCounter : MonoBehaviour
{
	private const string CONTAINER_NAME = "Advanced FPS Counter";

	internal static string NEW_LINE = Environment.NewLine;

	private static AFPSCounter instance;

	public FPSCounterData fpsCounter = new FPSCounterData();

	public MemoryCounterData memoryCounter = new MemoryCounterData();

	public DeviceInfoCounterData deviceInfoCounter = new DeviceInfoCounterData();

	public KeyCode hotKey = KeyCode.BackQuote;

	public bool keepAlive = true;

	private bool obsoleteEnabled = true;

	[SerializeField]
	private AFPSCounterOperationMode operationMode = AFPSCounterOperationMode.Normal;

	[SerializeField]
	private bool forceFrameRate;

	[Range(-1f, 200f)]
	[SerializeField]
	private int forcedFrameRate = -1;

	[SerializeField]
	private Vector2 anchorsOffset = new Vector2(5f, 5f);

	[SerializeField]
	private Font labelsFont;

	[SerializeField]
	[Range(0f, 100f)]
	private int fontSize;

	[SerializeField]
	[Range(0f, 10f)]
	private float lineSpacing = 1f;

	internal DrawableLabel[] labels;

	private int anchorsCount;

	private int cachedVSync = -1;

	private int cachedFrameRate = -1;

	private int initialSceneIndex;

	private bool inited;

	public static AFPSCounter Instance
	{
		get
		{
			if (instance == null)
			{
				AFPSCounter aFPSCounter = (AFPSCounter)UnityEngine.Object.FindObjectOfType(typeof(AFPSCounter));
				if (aFPSCounter != null && aFPSCounter.IsPlacedCorrectly())
				{
					instance = aFPSCounter;
				}
				else
				{
					GameObject gameObject = new GameObject("Advanced FPS Counter");
					gameObject.AddComponent<AFPSCounter>();
				}
			}
			return instance;
		}
	}

	public AFPSCounterOperationMode OperationMode
	{
		get
		{
			return operationMode;
		}
		set
		{
			if (operationMode == value || !Application.isPlaying)
			{
				return;
			}
			operationMode = value;
			if (operationMode != AFPSCounterOperationMode.Disabled)
			{
				if (operationMode == AFPSCounterOperationMode.Background)
				{
					for (int i = 0; i < anchorsCount; i++)
					{
						labels[i].Clear();
					}
				}
				fpsCounter.UpdateValue();
				memoryCounter.UpdateValue();
				deviceInfoCounter.UpdateValue();
				OnEnable();
			}
			else
			{
				OnDisable();
			}
		}
	}

	[Obsolete("Use AFPSCounter.Instance.OperationMode instead of AFPSCounter.Instance.enabled!")]
	public new bool enabled
	{
		get
		{
			return obsoleteEnabled;
		}
		set
		{
			if (obsoleteEnabled != value && Application.isPlaying)
			{
				obsoleteEnabled = value;
				if (obsoleteEnabled)
				{
					operationMode = AFPSCounterOperationMode.Normal;
					OnEnable();
				}
				else
				{
					operationMode = AFPSCounterOperationMode.Disabled;
					OnDisable();
				}
			}
		}
	}

	public bool ForceFrameRate
	{
		get
		{
			return forceFrameRate;
		}
		set
		{
			if (forceFrameRate != value && Application.isPlaying)
			{
				forceFrameRate = value;
				if (operationMode != AFPSCounterOperationMode.Disabled)
				{
					RefreshForcedFrameRate();
				}
			}
		}
	}

	public int ForcedFrameRate
	{
		get
		{
			return forcedFrameRate;
		}
		set
		{
			if (forcedFrameRate != value && Application.isPlaying)
			{
				forcedFrameRate = value;
				if (operationMode != AFPSCounterOperationMode.Disabled)
				{
					RefreshForcedFrameRate();
				}
			}
		}
	}

	public Vector2 AnchorsOffset
	{
		get
		{
			return anchorsOffset;
		}
		set
		{
			if (anchorsOffset == value || !Application.isPlaying)
			{
				return;
			}
			anchorsOffset = value;
			if (operationMode != AFPSCounterOperationMode.Disabled && labels != null)
			{
				for (int i = 0; i < anchorsCount; i++)
				{
					labels[i].ChangeOffset(anchorsOffset);
				}
			}
		}
	}

	public Font LabelsFont
	{
		get
		{
			return labelsFont;
		}
		set
		{
			if (labelsFont == value || !Application.isPlaying)
			{
				return;
			}
			labelsFont = value;
			if (operationMode != AFPSCounterOperationMode.Disabled && labels != null)
			{
				for (int i = 0; i < anchorsCount; i++)
				{
					labels[i].ChangeFont(labelsFont);
				}
			}
		}
	}

	public int FontSize
	{
		get
		{
			return fontSize;
		}
		set
		{
			if (fontSize == value || !Application.isPlaying)
			{
				return;
			}
			fontSize = value;
			if (operationMode != AFPSCounterOperationMode.Disabled && labels != null)
			{
				for (int i = 0; i < anchorsCount; i++)
				{
					labels[i].ChangeFontSize(fontSize);
				}
			}
		}
	}

	public float LineSpacing
	{
		get
		{
			return lineSpacing;
		}
		set
		{
			if (Math.Abs(lineSpacing - value) < 0.001f || !Application.isPlaying)
			{
				return;
			}
			lineSpacing = value;
			if (operationMode != AFPSCounterOperationMode.Disabled && labels != null)
			{
				for (int i = 0; i < anchorsCount; i++)
				{
					labels[i].ChangeLineSpacing(lineSpacing);
				}
			}
		}
	}

	private AFPSCounter()
	{
	}

	public void Dispose()
	{
		if (instance == this)
		{
			instance = null;
		}
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void Awake()
	{
		if (instance != null && instance.keepAlive)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		if (!IsPlacedCorrectly())
		{
			Debug.LogWarning("Advanced FPS Counter is placed in scene incorrectly and will be auto-destroyed! Please, use \"GameObject->Create Other->Code Stage->Advanced FPS Counter\" menu to correct this!");
			UnityEngine.Object.Destroy(this);
			return;
		}
		fpsCounter.Init(this);
		memoryCounter.Init(this);
		deviceInfoCounter.Init(this);
		instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		anchorsCount = Enum.GetNames(typeof(LabelAnchor)).Length;
		labels = new DrawableLabel[anchorsCount];
		for (int i = 0; i < anchorsCount; i++)
		{
			labels[i] = new DrawableLabel((LabelAnchor)i, anchorsOffset, labelsFont, fontSize, lineSpacing);
		}
	}

	private void Start()
	{
		inited = true;
	}

	private void Update()
	{
		if (inited && hotKey != KeyCode.None && Input.GetKeyDown(hotKey))
		{
			SwitchCounter();
		}
	}

	private void OnLevelWasLoaded(int index)
	{
		if (!inited)
		{
			return;
		}
		if (!keepAlive)
		{
			Dispose();
		}
		else if (fpsCounter.Enabled)
		{
			if (fpsCounter.ShowMinMax && fpsCounter.resetMinMaxOnNewScene)
			{
				fpsCounter.ResetMinMax();
			}
			if (fpsCounter.ShowAverage && fpsCounter.resetAverageOnNewScene)
			{
				fpsCounter.ResetAverage();
			}
		}
	}

	private void OnEnable()
	{
		if (operationMode != AFPSCounterOperationMode.Disabled)
		{
			ActivateCounters();
			Invoke("RefreshForcedFrameRate", 0.5f);
		}
	}

	private void OnDisable()
	{
		if (inited)
		{
			DeactivateCounters();
			if (IsInvoking("RefreshForcedFrameRate"))
			{
				CancelInvoke("RefreshForcedFrameRate");
			}
			RefreshForcedFrameRate(disabling: true);
			for (int i = 0; i < anchorsCount; i++)
			{
				labels[i].Clear();
			}
		}
	}

	private void OnDestroy()
	{
		if (!inited)
		{
			return;
		}
		fpsCounter.Dispose();
		memoryCounter.Dispose();
		deviceInfoCounter.Dispose();
		if (labels != null)
		{
			for (int i = 0; i < anchorsCount; i++)
			{
				labels[i].Dispose();
			}
			Array.Clear(labels, 0, anchorsCount);
			labels = null;
		}
		inited = false;
	}

	private bool IsPlacedCorrectly()
	{
		return base.gameObject.GetComponentsInChildren<Component>().Length == 2 && base.transform.childCount == 0 && base.transform.parent == null;
	}

	internal void MakeDrawableLabelDirty(LabelAnchor anchor)
	{
		if (operationMode == AFPSCounterOperationMode.Normal)
		{
			labels[(uint)anchor].dirty = true;
		}
	}

	internal void UpdateTexts()
	{
		if (operationMode != AFPSCounterOperationMode.Normal)
		{
			return;
		}
		bool flag = false;
		if (fpsCounter.Enabled)
		{
			DrawableLabel drawableLabel = labels[(uint)fpsCounter.Anchor];
			if (drawableLabel.newText.Length > 0)
			{
				drawableLabel.newText.Append(NEW_LINE);
			}
			drawableLabel.newText.Append(fpsCounter.text);
			drawableLabel.dirty |= fpsCounter.dirty;
			fpsCounter.dirty = false;
			flag = true;
		}
		if (memoryCounter.Enabled)
		{
			DrawableLabel drawableLabel2 = labels[(uint)memoryCounter.Anchor];
			if (drawableLabel2.newText.Length > 0)
			{
				drawableLabel2.newText.Append(NEW_LINE);
			}
			drawableLabel2.newText.Append(memoryCounter.text);
			drawableLabel2.dirty |= memoryCounter.dirty;
			memoryCounter.dirty = false;
			flag = true;
		}
		if (deviceInfoCounter.Enabled)
		{
			DrawableLabel drawableLabel3 = labels[(uint)deviceInfoCounter.Anchor];
			if (drawableLabel3.newText.Length > 0)
			{
				drawableLabel3.newText.Append(NEW_LINE);
			}
			drawableLabel3.newText.Append(deviceInfoCounter.text);
			drawableLabel3.dirty |= deviceInfoCounter.dirty;
			deviceInfoCounter.dirty = false;
			flag = true;
		}
		if (flag)
		{
			for (int i = 0; i < anchorsCount; i++)
			{
				labels[i].CheckAndUpdate();
			}
		}
		else
		{
			for (int j = 0; j < anchorsCount; j++)
			{
				labels[j].Clear();
			}
		}
	}

	private IEnumerator UpdateFPSCounter()
	{
		while (true)
		{
			float previousUpdateTime = Time.time;
			int previousUpdateFrames = Time.frameCount;
			yield return new WaitForSeconds(fpsCounter.UpdateInterval);
			float timeElapsed = Time.time - previousUpdateTime;
			int framesChanged = Time.frameCount - previousUpdateFrames;
			int fps = (int)((float)framesChanged / (timeElapsed / Time.timeScale));
			fpsCounter.newValue = fps;
			fpsCounter.UpdateValue(force: false);
			UpdateTexts();
		}
	}

	private IEnumerator UpdateMemoryCounter()
	{
		while (true)
		{
			memoryCounter.UpdateValue();
			UpdateTexts();
			yield return new WaitForSeconds(memoryCounter.UpdateInterval);
		}
	}

	private void SwitchCounter()
	{
		if (operationMode == AFPSCounterOperationMode.Disabled)
		{
			OperationMode = AFPSCounterOperationMode.Normal;
		}
		else if (operationMode == AFPSCounterOperationMode.Normal)
		{
			OperationMode = AFPSCounterOperationMode.Disabled;
		}
	}

	private void ActivateCounters()
	{
		fpsCounter.Activate();
		memoryCounter.Activate();
		deviceInfoCounter.Activate();
		if (fpsCounter.Enabled || memoryCounter.Enabled || deviceInfoCounter.Enabled)
		{
			UpdateTexts();
		}
	}

	private void DeactivateCounters()
	{
		if (!(instance == null))
		{
			fpsCounter.Deactivate();
			memoryCounter.Deactivate();
			deviceInfoCounter.Deactivate();
		}
	}

	private void RefreshForcedFrameRate()
	{
		RefreshForcedFrameRate(disabling: false);
	}

	private void RefreshForcedFrameRate(bool disabling)
	{
		if (forceFrameRate && !disabling)
		{
			if (cachedVSync == -1)
			{
				cachedVSync = QualitySettings.vSyncCount;
				cachedFrameRate = Application.targetFrameRate;
				QualitySettings.vSyncCount = 0;
			}
			Application.targetFrameRate = forcedFrameRate;
		}
		else if (cachedVSync != -1)
		{
			QualitySettings.vSyncCount = cachedVSync;
			Application.targetFrameRate = cachedFrameRate;
			cachedVSync = -1;
		}
	}

	internal static string Color32ToHex(Color32 color)
	{
		return color.r.ToString("x2") + color.g.ToString("x2") + color.b.ToString("x2") + color.a.ToString("x2");
	}

	internal static string Color32ToHex2(Color32 color)
	{
		return color.r.ToString("x2") + color.g.ToString("x2") + color.b.ToString("x2");
	}
}
}
