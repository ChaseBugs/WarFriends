namespace System.ComponentModel.Design.Serialization;

public struct MemberRelationship(object owner, MemberDescriptor member)
{
	public static readonly MemberRelationship Empty = default(MemberRelationship);

	private object _owner = owner;

	private MemberDescriptor _member = member;

	public bool IsEmpty => _owner == null;

	public object Owner => _owner;

	public MemberDescriptor Member => _member;

	public override int GetHashCode()
	{
		if (_owner != null && _member != null)
		{
			return _member.GetHashCode() ^ _owner.GetHashCode();
		}
		return base.GetHashCode();
	}

	public override bool Equals(object o)
	{
		if (o is MemberRelationship)
		{
			return (MemberRelationship)o == this;
		}
		return false;
	}

	public static bool operator ==(MemberRelationship left, MemberRelationship right)
	{
		if (left.Owner == right.Owner && left.Member == right.Member)
		{
			return true;
		}
		return false;
	}

	public static bool operator !=(MemberRelationship left, MemberRelationship right)
	{
		return !(left == right);
	}
}
