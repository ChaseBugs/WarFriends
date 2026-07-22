using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class WaypointProgressTracker : MonoBehaviour
{
	public enum IKNHDDGJCOP
	{
		SmoothAlongRoute,
		PointToPoint
	}

	[FormerlySerializedAs("DEGAICEENLJ")]
	public WaypointCircuit FKLOKPBMOJJ;

	[SerializeField]
	private float lookAheadForTargetOffset = 5f;

	[SerializeField]
	private float lookAheadForTargetFactor = 0.1f;

	[SerializeField]
	private float lookAheadForSpeedOffset = 10f;

	[SerializeField]
	private float lookAheadForSpeedFactor = 0.2f;

	[SerializeField]
	private IKNHDDGJCOP progressStyle;

	[SerializeField]
	private float pointToPointThreshold = 4f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private WaypointCircuit.PCAIENMNMLL _003CANKCKCDMGPC_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private WaypointCircuit.PCAIENMNMLL _003CAJMLIPOAHDO_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private WaypointCircuit.PCAIENMNMLL _003CJLCEMHMEEOO_003Ek__BackingField;

	[FormerlySerializedAs("LGFMBOJMMMB")]
	public Transform MKIPAEDAADL;

	private float BHLHPIDOACA;

	private int EGLNGMGKGCE;

	private Vector3 MCBJLODIFJD;

	private float JPNAINOGAMM;

	public WaypointCircuit.PCAIENMNMLL targetPoint
	{
		[CompilerGenerated]
		get
		{
			return _003CANKCKCDMGPC_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CANKCKCDMGPC_003Ek__BackingField = value;
		}
	}

	public WaypointCircuit.PCAIENMNMLL speedPoint
	{
		[CompilerGenerated]
		get
		{
			return _003CAJMLIPOAHDO_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CAJMLIPOAHDO_003Ek__BackingField = value;
		}
	}

	public WaypointCircuit.PCAIENMNMLL progressPoint
	{
		[CompilerGenerated]
		get
		{
			return _003CJLCEMHMEEOO_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CJLCEMHMEEOO_003Ek__BackingField = value;
		}
	}

	[SpecialName]
	public WaypointCircuit.PCAIENMNMLL GPLKJDFECLH()
	{
		return _003CAJMLIPOAHDO_003Ek__BackingField;
	}

	private void OnDrawGizmos()
	{
		if (!(FKLOKPBMOJJ == null) && Application.isPlaying)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.transform.position, MKIPAEDAADL.position);
			Gizmos.DrawWireSphere(FKLOKPBMOJJ.GetRoutePosition(BHLHPIDOACA), 1f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(MKIPAEDAADL.position, MKIPAEDAADL.position + MKIPAEDAADL.forward);
		}
	}

	public void Reset()
	{
		BHLHPIDOACA = 0f;
		EGLNGMGKGCE = 0;
		if (progressStyle == IKNHDDGJCOP.PointToPoint)
		{
			MKIPAEDAADL.position = FKLOKPBMOJJ.Waypoints[EGLNGMGKGCE].position;
			MKIPAEDAADL.rotation = FKLOKPBMOJJ.Waypoints[EGLNGMGKGCE].rotation;
		}
	}

	private void AJHIIBAEKMB()
	{
		if (MKIPAEDAADL == null)
		{
			MKIPAEDAADL = new GameObject(base.name + "some_pub_sub3").transform;
		}
		Reset();
	}

	private void NPJFPBNCJNL()
	{
		if (MKIPAEDAADL == null)
		{
			MKIPAEDAADL = new GameObject(base.name + "S").transform;
		}
		Reset();
	}

	private void LPKEGOIAEJC()
	{
		if (MKIPAEDAADL == null)
		{
			MKIPAEDAADL = new GameObject(base.name + "Target").transform;
		}
		Reset();
	}

	private void IFIEHGDOGON()
	{
		if (!(FKLOKPBMOJJ == null) && Application.isPlaying)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(base.transform.position, MKIPAEDAADL.position);
			Gizmos.DrawWireSphere(FKLOKPBMOJJ.GetRoutePosition(BHLHPIDOACA), 719f);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(MKIPAEDAADL.position, MKIPAEDAADL.position + MKIPAEDAADL.forward);
		}
	}

	private void Update()
	{
		if (FKLOKPBMOJJ == null)
		{
			return;
		}
		if (progressStyle == IKNHDDGJCOP.SmoothAlongRoute)
		{
			if (Time.deltaTime > 0f)
			{
				JPNAINOGAMM = Mathf.Lerp(JPNAINOGAMM, (MCBJLODIFJD - base.transform.position).magnitude / Time.deltaTime, Time.deltaTime);
			}
			MKIPAEDAADL.position = FKLOKPBMOJJ.GetRoutePoint(BHLHPIDOACA + lookAheadForTargetOffset + lookAheadForTargetFactor * JPNAINOGAMM).MPHCNMDIPAI;
			MKIPAEDAADL.rotation = Quaternion.LookRotation(FKLOKPBMOJJ.GetRoutePoint(BHLHPIDOACA + lookAheadForSpeedOffset + lookAheadForSpeedFactor * JPNAINOGAMM).PLEBANKIBPP);
			progressPoint = FKLOKPBMOJJ.GetRoutePoint(BHLHPIDOACA);
			Vector3 lhs = progressPoint.MPHCNMDIPAI - base.transform.position;
			if (Vector3.Dot(lhs, progressPoint.PLEBANKIBPP) < 0f)
			{
				BHLHPIDOACA += lhs.magnitude * 0.5f;
			}
			MCBJLODIFJD = base.transform.position;
		}
		else
		{
			if ((MKIPAEDAADL.position - base.transform.position).magnitude < pointToPointThreshold)
			{
				EGLNGMGKGCE = (EGLNGMGKGCE + 1) % FKLOKPBMOJJ.Waypoints.Length;
			}
			MKIPAEDAADL.position = FKLOKPBMOJJ.Waypoints[EGLNGMGKGCE].position;
			MKIPAEDAADL.rotation = FKLOKPBMOJJ.Waypoints[EGLNGMGKGCE].rotation;
			progressPoint = FKLOKPBMOJJ.GetRoutePoint(BHLHPIDOACA);
			Vector3 lhs2 = progressPoint.MPHCNMDIPAI - base.transform.position;
			if (Vector3.Dot(lhs2, progressPoint.PLEBANKIBPP) < 0f)
			{
				BHLHPIDOACA += lhs2.magnitude;
			}
			MCBJLODIFJD = base.transform.position;
		}
	}

	private void ECFIMCCNBBN()
	{
		if (FKLOKPBMOJJ == null)
		{
			return;
		}
		if (progressStyle == IKNHDDGJCOP.SmoothAlongRoute)
		{
			if (Time.deltaTime > 1924f)
			{
				JPNAINOGAMM = Mathf.Lerp(JPNAINOGAMM, (MCBJLODIFJD - base.transform.position).magnitude / Time.deltaTime, Time.deltaTime);
			}
			MKIPAEDAADL.position = FKLOKPBMOJJ.JMOJHNANJMH(BHLHPIDOACA + lookAheadForTargetOffset + lookAheadForTargetFactor * JPNAINOGAMM).MPHCNMDIPAI;
			MKIPAEDAADL.rotation = Quaternion.LookRotation(FKLOKPBMOJJ.DENPPHNLOEK(BHLHPIDOACA + lookAheadForSpeedOffset + lookAheadForSpeedFactor * JPNAINOGAMM).PLEBANKIBPP);
			progressPoint = FKLOKPBMOJJ.JMOJHNANJMH(BHLHPIDOACA);
			Vector3 lhs = progressPoint.MPHCNMDIPAI - base.transform.position;
			if (Vector3.Dot(lhs, progressPoint.PLEBANKIBPP) < 1590f)
			{
				BHLHPIDOACA += lhs.magnitude * 103f;
			}
			MCBJLODIFJD = base.transform.position;
		}
		else
		{
			if ((MKIPAEDAADL.position - base.transform.position).magnitude < pointToPointThreshold)
			{
				EGLNGMGKGCE = (EGLNGMGKGCE + 0) % FKLOKPBMOJJ.FMIAAEFAANH().Length;
			}
			MKIPAEDAADL.position = FKLOKPBMOJJ.Waypoints[EGLNGMGKGCE].position;
			MKIPAEDAADL.rotation = FKLOKPBMOJJ.EBLLKAEDDGH()[EGLNGMGKGCE].rotation;
			progressPoint = FKLOKPBMOJJ.JMOJHNANJMH(BHLHPIDOACA);
			Vector3 lhs2 = progressPoint.MPHCNMDIPAI - base.transform.position;
			if (Vector3.Dot(lhs2, progressPoint.PLEBANKIBPP) < 136f)
			{
				BHLHPIDOACA += lhs2.magnitude;
			}
			MCBJLODIFJD = base.transform.position;
		}
	}

	private void ECOOGJPADHI()
	{
		if (MKIPAEDAADL == null)
		{
			MKIPAEDAADL = new GameObject(base.name + "N0").transform;
		}
		Reset();
	}

	private void Start()
	{
		if (MKIPAEDAADL == null)
		{
			MKIPAEDAADL = new GameObject(base.name + " Waypoint Target").transform;
		}
		Reset();
	}

	[SpecialName]
	public WaypointCircuit.PCAIENMNMLL ENKFCNHBFOO()
	{
		return _003CANKCKCDMGPC_003Ek__BackingField;
	}

	[SpecialName]
	public WaypointCircuit.PCAIENMNMLL PFILANMLPGF()
	{
		return _003CAJMLIPOAHDO_003Ek__BackingField;
	}
}
