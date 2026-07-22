using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[ExecuteInEditMode]
public class ObjectPool : Core_BaseScript
{
	[Serializable]
	public class ObjectPoolEntry
	{
		[SerializeField]
		public string Name;

		[SerializeField]
		public PoolableObject Prefab;

		[SerializeField]
		public int Count;

		[SerializeField]
		public int CountTutorial;

		[SerializeField]
		public int CountMenu;

		[SerializeField]
		public int CountInit;

		[SerializeField]
		public bool limitInstances;

		[SerializeField]
		public int limitAmount;

		[SerializeField]
		public bool cullDespawned;

		[SerializeField]
		public int cullAbove;

		public int BAIECNMPKCB(IDCFPFCMKOG OPHHGCECLKI)
		{
			return 0;
		}
	}

	private sealed class MBHNJPLDBNJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public float GAMFJEOGHJD;

		public ObjectPool HNNCIECPFEJ;

		public PoolableObject KIHIFIBOOIM;

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
		public MBHNJPLDBNJ(int HEIHBBOBLGF)
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

	private sealed class EBDLDCADOBP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public ObjectPool HNNCIECPFEJ;

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
		public EBDLDCADOBP(int HEIHBBOBLGF)
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

	public static Dictionary<string, ObjectPool> BAFJHCHPIHI;

	public List<ObjectPoolEntry> KDJJCNCJODC;

	public List<bool> CEJFACNDJJN;

	public Dictionary<int, List<PoolableObject>> EKHMEKIFFGI;

	public Dictionary<int, LinkedList<int>> JBKMLOODOJH;

	public Dictionary<PoolableObject, int> KHFOMBDLODB;

	protected bool AOHCFPDGBIJ;

	private Coroutine DKACOEDOHEA;

	protected Action HMJFLOBHKOB;

	public void OnDestroy()
	{
	}

	public static ObjectPool GetPool(string JPFKCMCCNCK)
	{
		return null;
	}

	protected virtual void MCPNPNIMGHI()
	{
	}

	protected void CPHFMNLFNCO(int EMLGLDIPPDF, int JPIPAIOGHFE, int NLIEEABDPBC, int GBKNIKJGIEM)
	{
	}

	public virtual void InstantiatePooledObjects(IDCFPFCMKOG OPHHGCECLKI)
	{
	}

	protected override void Awake()
	{
	}

	public bool AreThereAvailableInstances(PoolableObject NJIAJGGMMKD)
	{
		return false;
	}

	public PoolableObject Instantiate(PoolableObject NJIAJGGMMKD)
	{
		return null;
	}

	public virtual PoolableObject Instantiate(PoolableObject NJIAJGGMMKD, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	public virtual PoolableObject Instantiate(int EPNGMAHENPA, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	public PoolableObject ReInstantiate(PoolableObject EDOODOMOKPN, Vector3 MPHCJEIMBEB, Quaternion KMPBJDNAEDB)
	{
		return null;
	}

	public PoolableObject InstantiateAsChild(PoolableObject NJIAJGGMMKD, Vector3 OCMCLBADBCB, Quaternion KMPBJDNAEDB, GameObject NNNBIABGOBM)
	{
		return null;
	}

	public PoolableObject InstantiateAsChild(PoolableObject NJIAJGGMMKD, GameObject NNNBIABGOBM, string LEGNKFCNBGA)
	{
		return null;
	}

	public int GetCountInPool(PoolableObject KIHIFIBOOIM)
	{
		return 0;
	}

	public bool FreeObject(PoolableObject KIHIFIBOOIM)
	{
		return false;
	}

	public void FreeObjectsWithPrefab(PoolableObject KIHIFIBOOIM)
	{
	}

	public void FreeWholePool()
	{
	}

	public List<PoolableObject> GetObjectsMadeOfPrefab(PoolableObject KIHIFIBOOIM)
	{
		return null;
	}

	private IEnumerator MLAHKGINPLG(PoolableObject KIHIFIBOOIM, float GAMFJEOGHJD)
	{
		return null;
	}

	public bool FreeObject(PoolableObject KIHIFIBOOIM, float GAMFJEOGHJD)
	{
		return false;
	}

	public PoolableObject ReInstantiate(PoolableObject EDOODOMOKPN)
	{
		return null;
	}

	public void InstantiatePooledObjectsAsync(IDCFPFCMKOG OCEFNKAAPCN, Action JNGNCKHOEPG)
	{
	}

	public void StopAsyncInstantiation()
	{
	}

	protected virtual IEnumerator AEBDIAFKCML(IDCFPFCMKOG OCEFNKAAPCN)
	{
		return null;
	}
}
