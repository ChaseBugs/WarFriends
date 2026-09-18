using System;

namespace Amazon.MobileAnalytics.Model;

public class Session
{
	private long? _duration;

	private string _id;

	private DateTime? _startTimestamp;

	private DateTime? _stopTimestamp;

	public long Duration
	{
		get
		{
			return _duration.GetValueOrDefault();
		}
		set
		{
			_duration = value;
		}
	}

	public string Id
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
		}
	}

	public DateTime StartTimestamp
	{
		get
		{
			return _startTimestamp.GetValueOrDefault();
		}
		set
		{
			_startTimestamp = value;
		}
	}

	public DateTime StopTimestamp
	{
		get
		{
			return _stopTimestamp.GetValueOrDefault();
		}
		set
		{
			_stopTimestamp = value;
		}
	}

	internal bool IsSetDuration()
	{
		return _duration.HasValue;
	}

	internal bool IsSetId()
	{
		return _id != null;
	}

	internal bool IsSetStartTimestamp()
	{
		return _startTimestamp.HasValue;
	}

	internal bool IsSetStopTimestamp()
	{
		return _stopTimestamp.HasValue;
	}
}
