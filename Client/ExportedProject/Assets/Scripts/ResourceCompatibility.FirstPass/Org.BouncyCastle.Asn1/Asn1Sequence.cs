using System;
using System.Collections;

namespace Org.BouncyCastle.Asn1
{
	public abstract class Asn1Sequence : Asn1Object, IEnumerable
	{
		private class Asn1SequenceParserImpl : Asn1SequenceParser, IAsn1Convertible
		{
			private readonly Asn1Sequence outer;

			private readonly int max;

			private int index;

			public Asn1SequenceParserImpl(Asn1Sequence outer)
			{
			}

			public IAsn1Convertible ReadObject()
			{
				return null;
			}

			public Asn1Object ToAsn1Object()
			{
				return null;
			}
		}

		private readonly IList seq;

		public virtual Asn1SequenceParser Parser => null;

		public virtual Asn1Encodable Item => null;

		[Obsolete]
		public int Size => 0;

		public virtual int Count => 0;

		public static Asn1Sequence GetInstance(object obj)
		{
			return null;
		}

		public static Asn1Sequence GetInstance(Asn1TaggedObject obj, bool explicitly)
		{
			return null;
		}

		protected internal Asn1Sequence(int capacity)
		{
		}

		public virtual IEnumerator GetEnumerator()
		{
			return null;
		}

		[Obsolete]
		public IEnumerator GetObjects()
		{
			return null;
		}

		[Obsolete]
		public Asn1Encodable GetObjectAt(int index)
		{
			return null;
		}

		protected override int Asn1GetHashCode()
		{
			return 0;
		}

		protected override bool Asn1Equals(Asn1Object asn1Object)
		{
			return false;
		}

		private Asn1Encodable GetCurrent(IEnumerator e)
		{
			return null;
		}

		protected internal void AddObject(Asn1Encodable obj)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
