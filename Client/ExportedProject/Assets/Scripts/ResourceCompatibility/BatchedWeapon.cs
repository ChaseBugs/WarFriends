using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BatchedWeapon : Core_BaseScript
{
	public Weapon AEBEOCBIBFI;

	public float IOJFENBEHBP;

	private BitVector32 DJHJLBFHPDL;

	private byte JDGMPEJGHID;

	private PhotonView IBBJLFJLAFA;

	private bool DGAANGIGNIB;

	private int MLFCLICJKMG;

	private Ammo.BICKHONNMCG FGKGKPHFHEL;

	private Vector3[] MMDPBCIHKOP;

	[CompilerGenerated]
	private bool _003CHKADIBAHCGC_003Ek__BackingField;

	[CompilerGenerated]
	private Action FMJHDOAGKIM;

	[CompilerGenerated]
	private Action<Vector3> PIADHBOIGMB;

	public bool shooting
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public event Action ShootEnded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action<Vector3> Shooted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	public void ShootBatch(GameShootableEntity.ShotTarget LGFMBOJMMMB, Vector3 MPHCJEIMBEB, int JPNOFLJNGNF, float GJJNJIIKPDI, Ammo.BICKHONNMCG HIMACIIHLDE)
	{
	}

	public void ShootBatch(GameShootableEntity.ShotTarget LGFMBOJMMMB, Vector3[] KENOCHBLNPN, int JPNOFLJNGNF, float GJJNJIIKPDI, Ammo.BICKHONNMCG HIMACIIHLDE)
	{
	}

	public void ShootBatchToPosition(PlayerController JFFNCLJBGLM, Vector3 MPHCJEIMBEB, int JPNOFLJNGNF, float GJJNJIIKPDI, Ammo.BICKHONNMCG HIMACIIHLDE)
	{
	}

	[PunRPC]
	private void ShootBatchRPC(Vector3[] KENOCHBLNPN, int JJPNIPKHCGJ, bool AOJPIEBGENE, byte HIMACIIHLDE, byte JPNOFLJNGNF)
	{
	}

	protected void Update()
	{
	}

	private void KLLJKOEGIIG(Vector3 MPHCJEIMBEB, bool HKGICFLDIHH)
	{
	}

	public void Reset()
	{
	}
}
