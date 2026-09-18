namespace TuneSDK;

public struct TuneItem(string name)
{
	public string name = name;

	public double? unitPrice = null;

	public int? quantity = null;

	public double? revenue = null;

	public string attribute1 = null;

	public string attribute2 = null;

	public string attribute3 = null;

	public string attribute4 = null;

	public string attribute5 = null;
}
