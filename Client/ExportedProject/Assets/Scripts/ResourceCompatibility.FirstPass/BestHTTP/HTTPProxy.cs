using System;
using BestHTTP.Authentication;

namespace BestHTTP
{
	public sealed class HTTPProxy
	{
		public Uri Address { get; set; }

		public Credentials Credentials { get; set; }

		public bool IsTransparent { get; set; }

		public bool SendWholeUri { get; set; }

		public bool NonTransparentForHTTPS { get; set; }

		public HTTPProxy(Uri address)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent, bool sendWholeUri)
		{
		}

		public HTTPProxy(Uri address, Credentials credentials, bool isTransparent, bool sendWholeUri, bool nonTransparentForHTTPS)
		{
		}
	}
}
