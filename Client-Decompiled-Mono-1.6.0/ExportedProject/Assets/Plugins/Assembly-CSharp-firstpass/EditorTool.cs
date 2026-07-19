using Newtonsoft.Json;
using UnityEngine;

public class EditorTool : MonoBehaviour
{
	public static T Deserialize<T>(string v)
	{
		return JsonConvert.DeserializeObject<T>(v);
	}
}
