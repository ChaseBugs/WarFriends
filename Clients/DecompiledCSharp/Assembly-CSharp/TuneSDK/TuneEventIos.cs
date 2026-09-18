using System;

namespace TuneSDK;

internal struct TuneEventIos
{
	public string name;

	public string revenue;

	public string currencyCode;

	public string advertiserRefId;

	public string transactionState;

	public string contentType;

	public string contentId;

	public string level;

	public string quantity;

	public string searchString;

	public string rating;

	public string date1;

	public string date2;

	public string attribute1;

	public string attribute2;

	public string attribute3;

	public string attribute4;

	public string attribute5;

	private TuneEventIos(int dummy1, int dummy2)
	{
		name = null;
		revenue = null;
		currencyCode = null;
		advertiserRefId = null;
		transactionState = null;
		contentType = null;
		contentId = null;
		level = null;
		quantity = null;
		searchString = null;
		rating = null;
		date1 = null;
		date2 = null;
		attribute1 = null;
		attribute2 = null;
		attribute3 = null;
		attribute4 = null;
		attribute5 = null;
	}

	public TuneEventIos(string name)
	{
		this = new TuneEventIos(0, 0);
		this.name = name;
	}

	public TuneEventIos(TuneEvent tuneEvent)
	{
		name = tuneEvent.name;
		advertiserRefId = tuneEvent.advertiserRefId;
		attribute1 = tuneEvent.attribute1;
		attribute2 = tuneEvent.attribute2;
		attribute3 = tuneEvent.attribute3;
		attribute4 = tuneEvent.attribute4;
		attribute5 = tuneEvent.attribute5;
		contentId = ((tuneEvent.contentId != null) ? tuneEvent.contentId.ToString() : null);
		contentType = tuneEvent.contentType;
		currencyCode = tuneEvent.currencyCode;
		int? num = tuneEvent.level;
		level = (num.HasValue ? tuneEvent.level.ToString() : null);
		int? num2 = tuneEvent.quantity;
		quantity = (num2.HasValue ? tuneEvent.quantity.ToString() : null);
		double? num3 = tuneEvent.rating;
		rating = (num3.HasValue ? tuneEvent.rating.ToString() : null);
		double? num4 = tuneEvent.revenue;
		revenue = (num4.HasValue ? tuneEvent.revenue.ToString() : null);
		searchString = tuneEvent.searchString;
		int? num5 = tuneEvent.transactionState;
		transactionState = (num5.HasValue ? tuneEvent.transactionState.ToString() : null);
		date1 = null;
		date2 = null;
		DateTime dateTime = new DateTime(1970, 1, 1);
		if (tuneEvent.date1.HasValue)
		{
			TimeSpan timeSpan = new TimeSpan(tuneEvent.date1.Value.Ticks);
			double totalMilliseconds = timeSpan.TotalMilliseconds;
			date1 = (totalMilliseconds - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
		}
		if (tuneEvent.date2.HasValue)
		{
			TimeSpan timeSpan2 = new TimeSpan(tuneEvent.date2.Value.Ticks);
			double totalMilliseconds2 = timeSpan2.TotalMilliseconds;
			date2 = (totalMilliseconds2 - new TimeSpan(dateTime.Ticks).TotalMilliseconds).ToString();
		}
	}
}
