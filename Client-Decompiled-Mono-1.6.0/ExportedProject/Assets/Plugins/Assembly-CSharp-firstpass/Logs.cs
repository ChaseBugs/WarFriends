using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public sealed class Logs : Singleton<Logs>
{
	public sealed class LogEntry
	{
		public string output = string.Empty;

		public string stack = string.Empty;

		public LogType type;
	}

	private string mLogId = string.Empty;

	private bool mLogsSent;

	private Action mSendLogsAction;

	private Queue<LogEntry> mLogEntries;

	private Texture2D mTexture;

	private Rect mGuiRect = new Rect(0f, 0f, 250f, 300f);

	private ScreenLogsGui mScreenLogsGui;

	private Vector2 mScrollPos;

	private bool mIsIn;

	private bool mOldIsIn;

	private float mPressTime;

	private bool mShowed;

	[Header("General")]
	[FormerlySerializedAs("CustomGUIStyle")]
	public GUIStyle customGUIStyle;

	public Camera camera;

	[Tooltip("Log entry history size.")]
	public int maxLogEntryCount = 500;

	[Header("User Interaction")]
	public float cornerAreaScreenSizeNormalized = 0.15f;

	public float pressDuration = 0.5f;

	public string logId
	{
		get
		{
			return mLogId;
		}
		set
		{
			mLogId = value;
		}
	}

	public bool logsSent
	{
		get
		{
			return mLogsSent;
		}
		set
		{
			mLogsSent = value;
		}
	}

	public Action sendLogsAction
	{
		get
		{
			return mSendLogsAction;
		}
		set
		{
			mSendLogsAction = value;
		}
	}

	public Queue<LogEntry> logEntries
	{
		get
		{
			return mLogEntries;
		}
	}

	public Texture2D texture
	{
		get
		{
			return mTexture;
		}
	}

	public Rect guiRect
	{
		get
		{
			return mGuiRect;
		}
	}

	public Vector2 scrollPos
	{
		get
		{
			return mScrollPos;
		}
		set
		{
			mScrollPos = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		mLogEntries = new Queue<LogEntry>(maxLogEntryCount);
	}

	private void OnEnable()
	{
		Application.logMessageReceivedThreaded += HandleLog;
		if (mTexture == null)
		{
			mTexture = new Texture2D(1, 1);
			mTexture.SetPixel(0, 0, Colours.grayLog);
			mTexture.Apply();
		}
		InvokeAfterRealTime(delegate
		{
			mGuiRect = new Rect(0f, 0f, Screen.width, Screen.height);
		}, 1f);
		if (mScreenLogsGui == null)
		{
			mScreenLogsGui = base.gameObject.AddComponent<ScreenLogsGui>();
			mScreenLogsGui.enabled = false;
			mScreenLogsGui.logs = this;
		}
	}

	private void OnDisable()
	{
		Application.logMessageReceivedThreaded -= HandleLog;
	}

	private void HandleLog(string logString, string stackTrace, LogType logType)
	{
		if (mLogEntries.Count < maxLogEntryCount)
		{
			mLogEntries.Enqueue(new LogEntry
			{
				stack = stackTrace,
				output = logString,
				type = logType
			});
		}
		else
		{
			LogEntry logEntry = mLogEntries.Dequeue();
			logEntry.output = logString;
			logEntry.stack = stackTrace;
			logEntry.type = logType;
			mLogEntries.Enqueue(logEntry);
		}
	}

	private bool IsInCornerLeftBottom(Vector3 point)
	{
		return point.x < cornerAreaScreenSizeNormalized && point.y < cornerAreaScreenSizeNormalized;
	}

	private bool IsInCornerRightBottom(Vector3 point)
	{
		return point.x > 1f - cornerAreaScreenSizeNormalized && point.y < cornerAreaScreenSizeNormalized;
	}

	private void Update()
	{
		bool flag = false;
		bool flag2 = false;
		Touch[] touches = Input.touches;
		foreach (Touch touch in touches)
		{
			Vector2 vector = camera.ScreenToViewportPoint(touch.position);
			if (IsInCornerLeftBottom(vector))
			{
				flag = true;
			}
			if (IsInCornerRightBottom(vector))
			{
				flag2 = true;
			}
		}
		mIsIn = flag && flag2;
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.OSXPlayer)
		{
			mIsIn = Input.GetMouseButton(0) && IsInCornerLeftBottom(camera.ScreenToViewportPoint(Input.mousePosition));
		}
		if (mOldIsIn != mIsIn)
		{
			if (mIsIn)
			{
				Debug.Log("Pressed LOG");
				mPressTime = Time.realtimeSinceStartup;
			}
			else
			{
				mPressTime = 0f;
			}
		}
		if (mIsIn && mPressTime != 0f && Time.realtimeSinceStartup > mPressTime + pressDuration)
		{
			ShowHide();
			mPressTime = 0f;
		}
		mOldIsIn = mIsIn;
	}

	public Color GetColor(LogType type)
	{
		switch (type)
		{
		case LogType.Error:
			return Color.red;
		case LogType.Assert:
		case LogType.Log:
			return Color.white;
		case LogType.Warning:
			return Color.yellow;
		case LogType.Exception:
			return Color.red;
		default:
			throw new ArgumentOutOfRangeException("type");
		}
	}

	private void ShowHide()
	{
		mShowed = !mShowed;
		mScreenLogsGui.enabled = mShowed;
		if (mShowed)
		{
			mScrollPos = new Vector2(0f, 4.5464646E+10f);
			logsSent = false;
		}
	}

	public void SendLogs()
	{
		if (sendLogsAction != null)
		{
			sendLogsAction();
		}
	}
}
