namespace FuseMisc;

public struct Friend
{
	public string FuseId;

	public string AccountId;

	public string Alias;

	public bool Pending;

	public override string ToString()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject jSONObject2 = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject2.AddField("FuseId", FuseId);
		jSONObject2.AddField("AccountId", AccountId);
		jSONObject2.AddField("Alias", Alias);
		jSONObject2.AddField("Pending", Pending);
		jSONObject.AddField("Friend", jSONObject2);
		return jSONObject.ToString();
	}
}
