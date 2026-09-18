using System;

public interface IKillableEntity : IFraction
{
	int power { get; set; }

	bool isAlive { get; set; }

	event Action<IGameMainEntity, DestroyableObject, DestroyableObject.DamageInfo> Killed;

	event Action<IGameMainEntity, Fractions, Fractions> FractionChanged;
}
