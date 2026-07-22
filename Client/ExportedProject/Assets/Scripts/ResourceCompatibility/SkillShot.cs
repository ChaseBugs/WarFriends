using System;

public class SkillShot
{
	[Flags]
	public enum SkillShotType
	{
		None = 0,
		HeadShot = 1,
		Runner = 2,
		LongShot = 4,
		Covered = 8,
		OneHitKill = 0x10,
		DoubleKill = 0x20,
		TrippleKill = 0x40,
		MultiKill = 0x80,
		SlowMotionKill = 0x100,
		VehicleDestroyed = 0x200,
		RevengeKill = 0x800,
		Kill = 0x1000,
		ExplosiveKill = 0x2000,
		TankDestroyed = 0x4000,
		ArmyKill = 0x8000,
		EnemyPlayerHit = 0x10000,
		OnTheMove = 0x20000,
		EnviromentalKill = 0x40000,
		ArmyPlayerHit = 0x80000
	}

	public SkillShotType type;
}
