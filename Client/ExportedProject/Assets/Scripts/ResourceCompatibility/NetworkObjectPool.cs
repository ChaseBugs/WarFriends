using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NetworkObjectPool : ObjectPool
{
	private sealed class EEGGPENPEBO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public NetworkObjectPool HNNCIECPFEJ;

		public IDCFPFCMKOG OCEFNKAAPCN;

		private Stopwatch LBDLCOMFFFD;

		private int GPDBFHPDPDO;

		private ObjectPoolEntry BHODLHANEIF;

		private Transform NKEONOEOEBI;

		private int ILFNEPOMPPM;

		private List<PoolableObject> BOHHKEJHIHL;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public EEGGPENPEBO(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private const int MEBMKAKMHBK = 0;

	private static int PMGLCIOKMHN;

	private PhotonView IBBJLFJLAFA;

	private List<int> FKFPBKAACHD;

	private bool JKIBDPPHJFJ;

	public static int AllocateNetworkId()
	{
		return 0;
	}

	private void OFHDBIBDFIL(int EMLGLDIPPDF, int ENHNNDPNPLK)
	{
	}

	public void SetupPhotonView(PoolableObject NJIAJGGMMKD, int NCNDABEOPDL, int EPNGMAHENPA)
	{
	}

	protected override void Awake()
	{
	}

	protected override void MCPNPNIMGHI()
	{
	}

	public override void InstantiatePooledObjects(IDCFPFCMKOG OPHHGCECLKI)
	{
	}

	public PoolableObject ReInstantiate(PoolableObject NJIAJGGMMKD, int MAPJCMPOCGL)
	{
		return null;
	}

	public PoolableObject ReInstantiate(int AKBOMMEMLHM, int MAPJCMPOCGL)
	{
		return null;
	}

	public PoolableObject ReInstantiate(PoolableObject NJIAJGGMMKD, int MAPJCMPOCGL, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	private int LOLBPNJAPPH(PoolableObject NJIAJGGMMKD)
	{
		return 0;
	}

	public PoolableObject InstantiateNetwork(PoolableObject NJIAJGGMMKD, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	[PunRPC]
	private void NetworkReInstantiate(int EMLGLDIPPDF, int MAPJCMPOCGL, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
	}

	public PoolableObject InstantiateNetwork(PoolableObject NJIAJGGMMKD)
	{
		return null;
	}

	[PunRPC]
	private void NetworkReInstantiate_1(int EMLGLDIPPDF, int MAPJCMPOCGL)
	{
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject MGLDPCLLNDA, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	public PoolableObject ReInstantiateNetwork(PoolableObject MGLDPCLLNDA)
	{
		return null;
	}

	public PoolableObject ReInstantiate(int AKBOMMEMLHM, int MAPJCMPOCGL, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	public PoolableObject ReInstantiate(int AKBOMMEMLHM, int MAPJCMPOCGL, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB, Vector3 OAJJJNKGJKL)
	{
		return null;
	}

	[PunRPC]
	private void NetworkInstantiate(int EPNGMAHENPA, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
	}

	public override PoolableObject Instantiate(int EPNGMAHENPA, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	private void JNOMPCCMIOK()
	{
	}

	private int LOIIONHLLKF(PoolableObject OEKEOADHEOB, PoolableObject EGMJAECMHBP)
	{
		return 0;
	}

	protected override IEnumerator AEBDIAFKCML(IDCFPFCMKOG OCEFNKAAPCN)
	{
		return null;
	}
}
