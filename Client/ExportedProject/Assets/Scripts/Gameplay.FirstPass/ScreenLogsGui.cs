using System;
using UnityEngine;

public sealed class ScreenLogsGui : Core_BaseScript
{
	private GUIStyle _labelHeaderStyle;

	private GUIStyle _labelMessageStyle;

	private GUIStyle _buttonSendStyle;

	private GUIStyle _buttonFilterStyle;

	private LogType[] _logTypes;

	private bool[] _logTypeFilter;

	public Logs logs;

	public Vector2 referenceResolution = new Vector2(1280f, 720f);

	public int maxLogEntryRenderedCount = 100;

	protected override void Awake()
	{
		base.Awake();
		_logTypes = (LogType[])Enum.GetValues(typeof(LogType));
		_logTypeFilter = new bool[_logTypes.Length];
		for (int i = 0; i < _logTypeFilter.Length; i++)
		{
			_logTypeFilter[i] = true;
		}
	}

	private void OnGUI()
	{
		Vector2 scale = new Vector2((float)Screen.width / referenceResolution.x, (float)Screen.height / referenceResolution.y);
		InitializeStyles(scale);
		GUI.skin.verticalScrollbar.fixedWidth = 60f * scale.x;
		GUI.skin.verticalScrollbarThumb.fixedWidth = 60f * scale.x;
		DrawQuad(logs.guiRect);
		GUILayout.BeginArea(logs.guiRect, logs.customGUIStyle);
		if (GUILayout.Button((!logs.logsSent) ? "Send logs to database" : ("LOGS SENT: " + logs.logId), _buttonSendStyle, GUILayout.Height(60f * scale.y)) && !logs.logsSent)
		{
			logs.SendLogs();
		}
		GUILayout.BeginHorizontal();
		for (int i = 0; i < _logTypes.Length; i++)
		{
			LogType logType = _logTypes[i];
			_logTypeFilter[(int)logType] = GUILayout.Toggle(_logTypeFilter[(int)logType], Enum.GetName(typeof(LogType), logType) + "s", _buttonFilterStyle, GUILayout.Height(30f * scale.y));
		}
		GUILayout.EndHorizontal();
		logs.scrollPos = GUILayout.BeginScrollView(logs.scrollPos);
		GUI.color = Color.white;
		int num = 0;
		foreach (Logs.LogEntry logEntry in logs.logEntries)
		{
			if (logs.logEntries.Count - ++num < maxLogEntryRenderedCount && _logTypeFilter[(int)logEntry.type])
			{
				GUI.contentColor = logs.GetColor(logEntry.type);
				GUILayout.Label(logEntry.output, _labelHeaderStyle);
				GUILayout.Label(logEntry.stack, _labelMessageStyle);
			}
		}
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	private void InitializeStyles(Vector2 scale)
	{
		if (_labelHeaderStyle == null)
		{
			int num = Mathf.RoundToInt(4f * scale.x);
			int top = Mathf.RoundToInt(3f * scale.x);
			_labelHeaderStyle = new GUIStyle(GUI.skin.label)
			{
				wordWrap = true,
				stretchHeight = false,
				margin = new RectOffset(num, num, num, num),
				padding = new RectOffset(0, 0, top, 0),
				fontSize = Mathf.RoundToInt(19f * scale.x),
				fontStyle = FontStyle.Bold
			};
		}
		if (_labelMessageStyle == null)
		{
			int num2 = Mathf.RoundToInt(4f * scale.x);
			int bottom = Mathf.RoundToInt(3f * scale.x);
			_labelMessageStyle = new GUIStyle(GUI.skin.label)
			{
				wordWrap = true,
				stretchHeight = false,
				margin = new RectOffset(num2, num2, num2, num2),
				padding = new RectOffset(0, 0, 0, bottom),
				fontSize = Mathf.RoundToInt(16f * scale.x),
				fontStyle = FontStyle.Normal
			};
		}
		if (_buttonSendStyle == null)
		{
			_buttonSendStyle = new GUIStyle(GUI.skin.button)
			{
				fontSize = Mathf.RoundToInt(28f * scale.x)
			};
		}
		if (_buttonFilterStyle == null)
		{
			_buttonFilterStyle = new GUIStyle(GUI.skin.button)
			{
				fontSize = Mathf.RoundToInt(16f * scale.x)
			};
		}
	}

	private void DrawQuad(Rect position)
	{
		GUI.skin.box.normal.background = logs.texture;
		GUI.Box(position, GUIContent.none);
	}
}
