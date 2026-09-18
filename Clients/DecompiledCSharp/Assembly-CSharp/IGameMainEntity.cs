using System;

public interface IGameMainEntity : IFraction
{
	int power { get; set; }

	bool isAlive { get; set; }

	event Action<IGameMainEntity, DestroyableObject.DamageInfo> Killed;
}
