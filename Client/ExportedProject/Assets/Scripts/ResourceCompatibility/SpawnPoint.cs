using System;
using UnityEngine;

public class SpawnPoint : Core_BaseScript, IBFMOMDLFEP
{
	[Flags]
	public enum MPKDDOPKKHJ
	{
		Normal = 1,
		Parachute = 2
	}

	public MPKDDOPKKHJ GGAAAKAJIED;

	[SerializeField]
	private HPHFGNJPDKN mFraction;

	public HPHFGNJPDKN fraction
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

	protected override void Awake()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
