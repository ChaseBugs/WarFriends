using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Logs : Singleton<Logs>
{
	public class LogEntry
	{
		public string output = string.Empty;

		public string stack = string.Empty;

		public LogType type;
	}

	public readonly Queue<LogEntry> logs = new Queue<LogEntry>();

	public GUIStyle CustomGUIStyle;

	public Rect guiRect = new Rect(0f, 0f, 250f, 300f);

	private StringBuilder mBuilder = new StringBuilder();

	private bool mIsIn;

	private bool mOldIsIn;

	private float mPressTime;

	private bool mShowed;

	public Vector2 scrollPos;

	public GUISkin sk;

	public Texture2D texture;

	public Camera camera;

	private ScreenLogsGui mScreenLogsGui;

	public Action SendLogsAction;

	public bool logsSent;

	public string logId = string.Empty;

	private bool isIn
	{
		get
		{
			return mIsIn;
		}
		set
		{
			mIsIn = value;
		}
	}

	private void OnEnable()
	{
		Application.logMessageReceived += HandleLog;
		texture = new Texture2D(1, 1);
		texture.SetPixel(0, 0, Colours.grayLog);
		texture.Apply();
		InvokeAfterRealTime(delegate
		{
			guiRect = new Rect(0f, 0f, Screen.width, Screen.height);
		}, 1f);
		mScreenLogsGui = base.gameObject.AddComponent<ScreenLogsGui>();
		mScreenLogsGui.enabled = false;
		mScreenLogsGui.logs = this;
	}

	private void OnDisable()
	{
		Application.RegisterLogCallback(null);
	}

	private void HandleLog(string logString, string stackTrace, LogType logType)
	{
		if (logs.Count < 500)
		{
			logs.Enqueue(new LogEntry
			{
				stack = stackTrace,
				output = logString,
				type = logType
			});
		}
		else
		{
			LogEntry logEntry = logs.Dequeue();
			logEntry.output = logString;
			logEntry.stack = stackTrace;
			logEntry.type = logType;
			logs.Enqueue(logEntry);
		}
	}

	private bool isInCornerLeftBottom(Vector3 point)
	{
		return point.x < 0.1f && (double)point.y < 0.1;
	}

	private bool isInCornerRightBottom(Vector3 point)
	{
		return point.x > 0.9f && (double)point.y < 0.1;
	}

	private Vector2 ScreenToWieport(Vector3 pos)
	{
		Vector3 mousePosition = Input.mousePosition;
		Vector2 zero = Vector2.zero;
		zero.x = mousePosition.x / (float)Screen.width;
		zero.y = mousePosition.y / (float)Screen.height;
		return zero;
	}

	protected void Update()
	{
		bool flag = false;
		bool flag2 = false;
		Touch[] touches = Input.touches;
		foreach (Touch touch in touches)
		{
			Vector2 vector = camera.ScreenToViewportPoint(touch.position);
			if (isInCornerLeftBottom(vector))
			{
				flag = true;
			}
			if (isInCornerRightBottom(vector))
			{
				flag2 = true;
			}
		}
		isIn = flag && flag2;
		if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXPlayer)
		{
			isIn = Input.GetMouseButton(0) && isInCornerLeftBottom(camera.ScreenToViewportPoint(Input.mousePosition));
		}
		if (mOldIsIn != isIn)
		{
			if (isIn)
			{
				Debug.Log("Pressed LOG");
				mPressTime = Time.realtimeSinceStartup;
			}
			else
			{
				mPressTime = 0f;
			}
		}
		if (isIn && Time.realtimeSinceStartup > mPressTime + 0.5f && mPressTime != 0f)
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
			case LogType.Exception:
				return Color.red;
			case LogType.Warning:
				return Color.yellow;
			default:
				return Color.white;
		}
	}

	private void ShowHide()
	{
		mShowed = !mShowed;
		mScreenLogsGui.enabled = mShowed;
		if (mShowed)
		{
			scrollPos = new Vector2(0f, 4.5464646E+10f);
			logsSent = false;
		}
	}

	public void SendLogs()
	{
		if (SendLogsAction != null)
		{
			SendLogsAction();
		}
	}
}
