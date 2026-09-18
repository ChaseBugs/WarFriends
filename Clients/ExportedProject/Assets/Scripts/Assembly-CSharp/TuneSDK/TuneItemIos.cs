namespace TuneSDK
{
internal struct TuneItemIos
{
	public string name;

	public double unitPrice;

	public int quantity;

	public double revenue;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	public TuneItemIos(string name)
	{
		this.name = name;
		unitPrice = 0.0;
		quantity = 0;
		revenue = 0.0;
		attribute1 = null;
		attribute2 = null;
		attribute3 = null;
		attribute4 = null;
		attribute5 = null;
	}

	public TuneItemIos(TuneItem tuneItem)
	{
		name = tuneItem.name;
		double? num = tuneItem.unitPrice;
		unitPrice = ((!num.HasValue) ? 0.0 : num.Value);
		int? num2 = tuneItem.quantity;
		quantity = (num2.HasValue ? num2.Value : 0);
		double? num3 = tuneItem.revenue;
		revenue = ((!num3.HasValue) ? 0.0 : num3.Value);
		attribute1 = tuneItem.attribute1;
		attribute2 = tuneItem.attribute2;
		attribute3 = tuneItem.attribute3;
		attribute4 = tuneItem.attribute4;
		attribute5 = tuneItem.attribute5;
	}
}
}
