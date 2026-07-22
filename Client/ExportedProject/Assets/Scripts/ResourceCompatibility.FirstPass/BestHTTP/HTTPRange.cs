namespace BestHTTP
{
	public sealed class HTTPRange
	{
		public int FirstBytePos { get; private set; }

		public int LastBytePos { get; private set; }

		public int ContentLength { get; private set; }

		public bool IsValid { get; private set; }

		internal HTTPRange()
		{
		}

		internal HTTPRange(int contentLength)
		{
		}

		internal HTTPRange(int fbp, int lbp, int contentLength)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
