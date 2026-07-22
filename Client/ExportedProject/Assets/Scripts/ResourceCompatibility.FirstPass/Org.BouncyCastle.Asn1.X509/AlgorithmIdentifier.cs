namespace Org.BouncyCastle.Asn1.X509
{
	public class AlgorithmIdentifier : Asn1Encodable
	{
		private readonly DerObjectIdentifier objectID;

		private readonly Asn1Encodable parameters;

		private readonly bool parametersDefined;

		public virtual DerObjectIdentifier ObjectID => null;

		public Asn1Encodable Parameters => null;

		public static AlgorithmIdentifier GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		public static AlgorithmIdentifier GetInstance(object obj)
		{
			return null;
		}

		public AlgorithmIdentifier(DerObjectIdentifier objectID)
		{
		}

		public AlgorithmIdentifier(string objectID)
		{
		}

		public AlgorithmIdentifier(DerObjectIdentifier objectID, Asn1Encodable parameters)
		{
		}

		internal AlgorithmIdentifier(Asn1Sequence seq)
		{
		}

		public override Asn1Object ToAsn1Object()
		{
			return null;
		}
	}
}
