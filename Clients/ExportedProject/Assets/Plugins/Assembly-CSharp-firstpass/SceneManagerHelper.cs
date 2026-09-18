using UnityEngine;

public class SceneManagerHelper
{
	public static string ActiveSceneName => Application.loadedLevelName;

	public static int ActiveSceneBuildIndex => Application.loadedLevel;
}
