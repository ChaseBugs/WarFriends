namespace _003CPrivateImplementationDetails_003E_007B21ACDBEE_002D8133_002D42AD_002DB130_002DBB0FBBA76D24_007DLOkWPANW
{
	public sealed class BigInteger
	{
		private readonly Org.BouncyCastle.Math.BigInteger value;

		public BigInteger(byte[] bytes)
		{
			value = new Org.BouncyCastle.Math.BigInteger(bytes);
		}

		private BigInteger(Org.BouncyCastle.Math.BigInteger value)
		{
			this.value = value;
		}

		public BigInteger ModPow(int exponent, BigInteger modulus)
		{
			return new BigInteger(value.ModPow(Org.BouncyCastle.Math.BigInteger.ValueOf(exponent), modulus.value));
		}

		public byte[] GetBytes()
		{
			return value.ToByteArrayUnsigned();
		}
	}
}
