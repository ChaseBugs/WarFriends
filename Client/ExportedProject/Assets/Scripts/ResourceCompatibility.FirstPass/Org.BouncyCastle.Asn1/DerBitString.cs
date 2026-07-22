namespace Org.BouncyCastle.Asn1
{
	public class DerBitString : DerStringBase
	{
		private static readonly char[] table;

		private readonly byte[] data;

		private readonly int padBits;

		public int PadBits => 0;

		public int IntValue => 0;

		internal static int GetPadBits(int bitString)
		{
			return 0;
		}

		internal static byte[] GetBytes(int bitString)
		{
			return null;
		}

		public static DerBitString GetInstance(object obj)
		{
			return null;
		}

		public static DerBitString GetInstance(Asn1TaggedObject obj, bool isExplicit)
		{
			return null;
		}

		internal DerBitString(byte data, int padBits)
		{
		}

		public DerBitString(byte[] data, int padBits)
		{
		}

		public DerBitString(byte[] data)
		{
		}

		public DerBitString(Asn1Encodable obj)
		{
		}

		public byte[] GetBytes()
		{
			return null;
		}

		internal override void Encode(DerOutputStream derOut)
		{
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		public override string GetString()
		{
			return null;
		}

		internal static DerBitString FromAsn1Octets(byte[] octets)
		{
			return null;
		}
	}
}
