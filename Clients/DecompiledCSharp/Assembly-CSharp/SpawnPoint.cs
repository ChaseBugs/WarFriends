using System;
using UnityEngine;

public class SpawnPoint : Core_BaseScript, IFraction
{
	[Flags]
	public enum SpawnPointType
	{
		Normal = 1,
		Parachute = 2
	}

	public SpawnPointType spawnPointType;

	[SerializeField]
	private Fractions mFraction = Fractions.Enemies;

	public Fractions fraction
	{
		get
		{
			return mFraction;
		}
		set
		{
			mFraction = value;
		}
	}

	public IFraction owner => this;

	protected override void Awake()
	{
		base.Awake();
		spawnPointType = SpawnPointType.Normal;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(base.transform.position, 0.15f);
	}
}
