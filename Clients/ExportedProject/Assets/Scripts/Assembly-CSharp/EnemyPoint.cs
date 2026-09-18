using System;
using UnityEngine;

public class EnemyPoint : Core_BaseScript, IFraction
{
	[Flags]
	public enum EnemyPointType
	{
		Rusher = 1,
		Hiding = 2,
		Corner = 4,
		Car = 8,
		Helicopter = 0x10,
		Swat = 0x20,
		Tower = 0x40,
		Minigunner = 0x80,
		EngineerTurret = 0x100,
		EngineerRepair = 0x200,
		RusherSpare = 0x400,
		Gunslinger = 0x800,
		Mortar = 0x1000,
		Mech = 0x2000
	}

	public AIObject enemyAtPoint;

	public EnemyController.EnemyAIState switchState;

	private bool mIsFree = true;

	public int indexInEnemyPointArray;

	[SerializeField]
	private Fractions mFraction = Fractions.Enemies;

	public EnemyPointType enemyPointType { get; protected set; }

	public virtual Vector3 position => (!(base.transform != null)) ? Vector3.zero : base.transform.position;

	public virtual bool isFree
	{
		get
		{
			return mIsFree && enemyAtPoint == null;
		}
		set
		{
			mIsFree = value;
		}
	}

	public virtual Fractions fraction
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

	public virtual bool isActive => true;

	protected override void Awake()
	{
		base.Awake();
	}

	public virtual void GeneratePosition()
	{
	}

	public virtual bool IsEnemyPointReached(Vector3 enemyPos)
	{
		return position.PlanarDistance(enemyPos) < 0.04f;
	}
}
