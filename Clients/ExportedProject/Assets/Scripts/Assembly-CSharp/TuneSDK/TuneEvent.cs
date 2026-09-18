using System;

namespace TuneSDK
{
public struct TuneEvent
{
	public string name;

	public double? revenue;

	public string currencyCode;

	public string advertiserRefId;

	public TuneItem[] eventItems;

	public int? transactionState;

	public string receipt;

	public string receiptSignature;

	public string contentType;

	public string contentId;

	public int? level;

	public int? quantity;

	public string searchString;

	public double? rating;

	public DateTime? date1;

	public DateTime? date2;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	private TuneEvent(int dummy1, int dummy2) : this()
	{
	}

	public TuneEvent(string name)
		: this(0, 0)
	{
		this.name = name;
	}
}
}
