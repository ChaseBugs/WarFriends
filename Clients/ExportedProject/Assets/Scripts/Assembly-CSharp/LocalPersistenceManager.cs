using UnityEngine;

public class LocalPersistenceManager : MonoBehaviour
{
	private void Start()
	{
		Debug.LogWarning("Starting LocalPersistenceManager!");
	}

	public static string GetLocalFileHandle()
	{
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.chillingo.warfriends.android.gplay.localpersistencemanager.LocalPersistenceManager"))
		{
		return androidJavaClass.CallStatic<string>("getLocalFileHandleStr", new object[1] { "./warfriends" });
		}
}
}
