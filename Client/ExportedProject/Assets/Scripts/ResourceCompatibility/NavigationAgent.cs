using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAgent : Core_BaseScript
{
	private sealed class BNGNBBMKDGO : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public NavigationAgent HNNCIECPFEJ;

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
		public BNGNBBMKDGO(int HEIHBBOBLGF)
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

	[SerializeField]
	private NavMeshAgent mAgent;

	[SerializeField]
	private NavigationHelperCapsule mHeplperCapsule;

	[SerializeField]
	private float mSpeed;

	private GameObject IAOLDHPFEHE;

	private int FDDNPFGIJNA;

	private bool FOOHKGGFJGN;

	private Vector3 JNPAECGLLFB;

	private Vector3 NGOAADHGDLA;

	private bool NHKECFNGJIH;

	public float PBENNEJGJFJ;

	public float MEILEIDFBKD;

	private bool GEEOOOIFANH;

	public Vector3 BCKJLAMGLOI;

	public float MAEMNOFPHAO;

	private int PJHCBBBHDFM;

	private float LMLBEMIDIIL;

	private Vector3 JFLOPNJMBKM;

	private Vector3 DPJMGLEPACH;

	private WayPointPath GKKOOAAFLBK;

	private bool GOBFIDOHAAD;

	[CompilerGenerated]
	private Action PKJFENHODDI;

	public int GGMFGODHFHN;

	private float ENCKFDJJIII;

	private GameObject PLGLJNLOOLG;

	private GameObject PMJPFHOJAKF;

	private bool AFPNPPLALFF;

	private float CIMGJPAHFMJ;

	private Quaternion NMJPAHFNOEL;

	private float KJAEBIFPFLO;

	private List<Vector3> IFNIKMOKIKP;

	private bool IMINHHONPDM;

	private float FBFGGHHNBGG;

	public Vector3 desiredVelocity => default(Vector3);

	public Vector3 direction => default(Vector3);

	public Vector3 velocity => default(Vector3);

	public float stoppingDistance
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public Vector3 steeringTarget => default(Vector3);

	public bool isObstacleAvoiding => false;

	public GameObject obstacle => null;

	public Vector3 destnation => default(Vector3);

	public Vector3[] corners => null;

	public float speed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float angularSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool isStopped => false;

	public int curentPathIndex
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool animatingWayPoints => false;

	public Quaternion flyRot
	{
		set
		{
		}
	}

	public float stayTime => 0f;

	public MIMLJNGKJHH current => default(MIMLJNGKJHH);

	public NavMeshAgent navigationAgent => null;

	public event Action PathEndReached
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

	public void Fly(Vector3 BLPBCNLNCKP, float PLPCAKAMKEH = 0f, Quaternion? HLGEKPHPOCP = null)
	{
	}

	private void OnTriggerStay(Collider KIHIFIBOOIM)
	{
	}

	private void OnTriggerEnter(Collider NDPOHBKFEGC)
	{
	}

	public void Stop()
	{
	}

	public void Pause()
	{
	}

	public void Disable()
	{
	}

	public Vector3 Steer(Vector3 LGFMBOJMMMB, bool MEIIMKJEFOM = false)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public void SetWayPointPath(WayPointPath LDCKAOCPHOB)
	{
	}

	private void OnEnable()
	{
	}

	private IEnumerator COGJCODLBKE()
	{
		return null;
	}

	private void OnDisable()
	{
	}

	protected void Update()
	{
	}

	private Quaternion EGLGAGAABKM(Vector3 DPJMGLEPACH)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	protected void JMADDJDALKD()
	{
	}

	private void KLOIAHMACKK(Vector3 DCKANJMPEFG)
	{
	}

	public void SetDestination(Vector3 MPHCJEIMBEB)
	{
	}

	public void Resume()
	{
	}

	private bool KJHINGPPMIJ(out Vector3 AKMHGELMAPI)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		AKMHGELMAPI = default(Vector3);
		return false;
	}

	private bool BPPPMBOGPAC(out Vector3 AKMHGELMAPI)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		AKMHGELMAPI = default(Vector3);
		return false;
	}

	public void Reset()
	{
	}

	public void Warp()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
