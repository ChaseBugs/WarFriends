using System;

namespace FuseMisc;

public static class FuseExtensions
{
	private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	public static long ToUnixTimestamp(this DateTime dateTime)
	{
		return (long)(dateTime - unixEpoch).TotalSeconds;
	}

	public static DateTime ToDateTime(this long timestamp)
	{
		return unixEpoch.AddSeconds(timestamp);
	}
}
