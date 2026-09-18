using System;
using Org.BouncyCastle.Utilities;

namespace Org.BouncyCastle.Asn1;

public class DerUnknownTag : Asn1Object
{
	private readonly bool isConstructed;

	private readonly int tag;

	private readonly byte[] data;

	public bool IsConstructed => isConstructed;

	public int Tag => tag;

	public DerUnknownTag(int tag, byte[] data)
		: this(isConstructed: false, tag, data)
	{
	}

	public DerUnknownTag(bool isConstructed, int tag, byte[] data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		this.isConstructed = isConstructed;
		this.tag = tag;
		this.data = data;
	}

	public byte[] GetData()
	{
		return data;
	}

	internal override void Encode(DerOutputStream derOut)
	{
		derOut.WriteEncoded(isConstructed ? 32 : 0, tag, data);
	}

	protected override bool Asn1Equals(Asn1Object asn1Object)
	{
		if (!(asn1Object is DerUnknownTag derUnknownTag))
		{
			return false;
		}
		if (isConstructed == derUnknownTag.isConstructed && tag == derUnknownTag.tag)
		{
			return Arrays.AreEqual(data, derUnknownTag.data);
		}
		return false;
	}

	protected override int Asn1GetHashCode()
	{
		return isConstructed.GetHashCode() ^ tag.GetHashCode() ^ Arrays.GetHashCode(data);
	}
}
