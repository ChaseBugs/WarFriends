using System;
using System.Collections.Generic;
using War.Protocol;

/// <summary>
/// Applies host shield health to the existing cover objects in the recovered scene.
/// The cover index and faction must both agree before any visual state changes.
/// </summary>
public sealed class SelfHostedShieldPresenter
{
	private readonly Dictionary<int, Shield> shieldsByCover = new Dictionary<int, Shield>();
	private readonly Dictionary<int, int> fractionByCover = new Dictionary<int, int>();

	public SelfHostedShieldPresenter(MapDefinition map)
	{
		if (map == null || map.availablePoints == null)
			throw new InvalidOperationException("The self-hosted match has no cover map.");

		foreach (MapDefinition.DefendPosition position in map.availablePoints)
		{
			if (position == null || position.point == null || position.point.shield == null ||
				position.index < 0 || !Enum.IsDefined(typeof(Fractions), position.fraction) ||
				position.fraction == Fractions.None || shieldsByCover.ContainsKey(position.index))
				throw new InvalidOperationException("The scene has an invalid cover shield identity.");

			shieldsByCover.Add(position.index, position.point.shield);
			fractionByCover.Add(position.index, (int)position.fraction);
		}
	}

	public void Apply(MatchSnapshot snapshot)
	{
		if (snapshot == null || snapshot.Shields.Count == 0) return;
		if (snapshot.Shields.Count != shieldsByCover.Count)
			throw new InvalidOperationException("The host shield roster does not match the scene.");

		var seen = new HashSet<int>();
		foreach (BattleShieldState state in snapshot.Shields)
		{
			if (!seen.Add(state.CoverIndex) ||
				!shieldsByCover.ContainsKey(state.CoverIndex) ||
				fractionByCover[state.CoverIndex] != state.OwnerFraction)
				throw new InvalidOperationException("The host shield identity does not match the scene.");
		}

		foreach (BattleShieldState state in snapshot.Shields)
			shieldsByCover[state.CoverIndex].ApplySelfHostedState(
				state.Health, state.MaxHealth, state.Destroyed);
	}
}
