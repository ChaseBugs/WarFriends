using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyPoint : Core_BaseScript, IBFMOMDLFEP
{
	[Flags]
	public enum JMLFBBNOMMH
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
		Mech = 0x2000,
		Havoc = 0x4000,
		Replica = 0x8000
	}

	public AIObject HIKBHDMADCK;

	public bool NILADEGIKGF;

	[CompilerGenerated]
	private JMLFBBNOMMH _003CFJKABMELCBO_003Ek__BackingField;

	public EnemyController.KMEPKJIDDIH ODOFPDCADDF;

	private bool CFFBNDJPJOB;

	public int JEOEDDAOHLH;

	[SerializeField]
	private HPHFGNJPDKN mFraction;

	public JMLFBBNOMMH enemyPointType
	{
		[CompilerGenerated]
		get
		{
			return default(JMLFBBNOMMH);
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public virtual Vector3 position => default(Vector3);

	public virtual bool isFree
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public virtual HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public IBFMOMDLFEP owner => null;

	public virtual bool isActive => false;

	protected override void Awake()
	{
	}

	public virtual void GeneratePosition()
	{
	}

	public virtual bool IsEnemyPointReached(Vector3 JFOCKCBCNFC)
	{
		return false;
	}

	public float Distance(Vector3 JFOCKCBCNFC)
	{
		return 0f;
	}
}
