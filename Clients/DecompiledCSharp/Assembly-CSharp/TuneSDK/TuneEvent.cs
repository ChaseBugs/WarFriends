using System;

namespace TuneSDK;

public struct TuneEvent
{
	public string name = null;

	public double? revenue = null;

	public string currencyCode = null;

	public string advertiserRefId = null;

	public TuneItem[] eventItems = null;

	public int? transactionState = null;

	public string receipt = null;

	public string receiptSignature = null;

	public string contentType = null;

	public string contentId = null;

	public int? level = null;

	public int? quantity = null;

	public string searchString = null;

	public double? rating = null;

	public DateTime? date1 = null;

	public DateTime? date2 = null;

	public string attribute1 = null;

	public string attribute2 = null;

	public string attribute3 = null;

	public string attribute4 = null;

	public string attribute5 = null;

	private TuneEvent(int dummy1, int dummy2)
	{
	}

	public TuneEvent(string name)
		: this(0, 0)
	{
		this.name = name;
	}
}
