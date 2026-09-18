using UnityEngine;

public class ScreenLogsGui : Core_BaseScript
{
	public Logs logs;

	public void OnGUI()
	{
		GUI.skin.verticalScrollbar.fixedWidth = (float)Screen.width * 0.04f;
		GUI.skin.verticalScrollbarThumb.fixedWidth = (float)Screen.width * 0.04f;
		GUI.skin.label.wordWrap = true;
		DrawQuad(logs.guiRect, Colours.grayLog);
		GUILayout.BeginArea(logs.guiRect, logs.CustomGUIStyle);
		if (GUILayout.Button((!logs.logsSent) ? "Send logs to database" : ("LOGS SENT: " + logs.logId), GUILayout.Height((float)Screen.height * 0.04f)) && !logs.logsSent)
		{
			logs.SendLogs();
		}
		logs.scrollPos = GUILayout.BeginScrollView(logs.scrollPos);
		GUI.color = Color.white;
		GUILayout.Label("LOGS");
		int num = 0;
		foreach (Logs.LogEntry log in logs.logs)
		{
			num++;
			if (logs.logs.Count - num < 100)
			{
				GUI.contentColor = logs.GetColor(log.type);
				GUI.skin.label.fontStyle = FontStyle.Bold;
				GUI.skin.label.fontSize = 15;
				GUI.skin.label.stretchHeight = true;
				GUILayout.Label(log.output);
				GUI.skin.label.fontSize = 13;
				GUI.skin.label.fontStyle = FontStyle.Normal;
				GUILayout.Label(log.stack);
			}
		}
		GUILayout.EndScrollView();
		GUILayout.EndArea();
	}

	private void DrawQuad(Rect position, Color color)
	{
		GUI.skin.box.normal.background = logs.texture;
		GUI.Box(position, GUIContent.none);
	}
}
