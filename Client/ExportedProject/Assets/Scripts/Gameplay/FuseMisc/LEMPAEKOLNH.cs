using System;

namespace FuseMisc
{
	public static class LEMPAEKOLNH
	{
		private static readonly DateTime JNIJKKJCNHI = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static long FJOPPAABFPB(this DateTime HBPNEAHAHAJ)
		{
			return (long)(HBPNEAHAHAJ - JNIJKKJCNHI).TotalSeconds;
		}

		public static DateTime JHHJCIOHPAD(this long ONKHFFGNNOE)
		{
			return JNIJKKJCNHI.AddSeconds(ONKHFFGNNOE);
		}
	}
}
