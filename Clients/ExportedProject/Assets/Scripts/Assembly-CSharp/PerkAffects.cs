using System;

[Serializable]
public struct PerkAffects : IEquatable<PerkAffects>
{
	public PerkUnitCategory category;

	public PerkMechcategory mech;

	public PerkFlyCategory fly;

	public bool Equals(PerkAffects other)
	{
		return other.category == category && other.mech == mech && other.fly == fly;
	}
}
