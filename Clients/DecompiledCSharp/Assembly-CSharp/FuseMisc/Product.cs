namespace FuseMisc;

public struct Product
{
	public string ProductId;

	public float Price;

	public string PriceLocale;

	public override string ToString()
	{
		JSONObject jSONObject = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject jSONObject2 = new JSONObject(JSONObject.Type.OBJECT);
		jSONObject2.AddField("ProductId", ProductId);
		jSONObject2.AddField("Price", Price);
		jSONObject2.AddField("PriceLocale", PriceLocale);
		jSONObject.AddField("Product", jSONObject2);
		return jSONObject.ToString();
	}
}
