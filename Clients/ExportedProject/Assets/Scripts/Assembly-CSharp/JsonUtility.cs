using Newtonsoft.Json;

public static class JsonUtility
{
	public static T FromJson<T>(string str)
	{
		return JsonConvert.DeserializeObject<T>(str);
	}
}
