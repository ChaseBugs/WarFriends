using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class QuickRope2 : MonoBehaviour
{
	public const float PRECISION = 0.0001f;

	public const int MAX_JOINT_COUNT = 500;

	public const float MAX_JOINT_SPACING = 50f;

	public const float MIN_JOINT_SPACING = 0.1f;

	public GameObject ropeEnd;

	public LayerMask layer;

	public float jointSpacing;

	public bool showJoints;

	[HideInInspector]
	[SerializeField]
	private GameObject jointPrefab;

	[HideInInspector]
	[SerializeField]
	private float jointScale;

	[HideInInspector]
	[SerializeField]
	private bool alternateJoints;

	[HideInInspector]
	[SerializeField]
	private bool firstJointAlternated;

	[HideInInspector]
	[SerializeField]
	private List<Vector3> controlPoints;

	[HideInInspector]
	[SerializeField]
	private List<Vector3> splinePoints;

	[SerializeField]
	public List<GameObject> Joints;

	[HideInInspector]
	[SerializeField]
	private List<Vector3> calculatedPositions;

	[HideInInspector]
	[SerializeField]
	private Quaternion[] calculatedRotations;

	[HideInInspector]
	[SerializeField]
	public List<RopeAttachedObject> attachedObjects;

	private int prevJointcount;

	private float ropeLength;

	private bool freeFallMode;

	private Vector3 pastUp;

	private Vector3 pRopeEndPos;

	private bool initialized;

	public bool enablePhysics;

	public RopeColliderType colliderType;

	public PhysicMaterial physicsMaterial;

	public float colliderRadius;

	public RopeConstraint constraint;

	public float mass;

	public float drag;

	public float angDrag;

	public bool useGravity;

	public float LowAngXLimit;

	public float HighAngXLimit;

	public float LTLBounce;

	public float LTLSpring;

	public float LTLDamper;

	public float AngYLimit;

	public float AngZLimit;

	public float S1LBounce;

	public float S1LSpring;

	public float S1LDamper;

	public float breakForce;

	public float breakTorque;

	public int solverOverride;

	private float distBetweenJoints;

	private float currentVelocity;

	public bool enableRopeController;

	public KeyCode extendRopeKey;

	public KeyCode retractRopeKey;

	public float acceleration;

	public float dampening;

	public float sleepVelocity;

	public float minRopeLength;

	public float maxRopeLength;

	public float maxVelocity;

	[HideInInspector]
	public int EDITOR_TAB_SELECTED;

	[HideInInspector]
	public static float EDITOR_GUI_SCALE;

	[HideInInspector]
	public bool EDITOR_SHOW_RIGIDBODY;

	[HideInInspector]
	public bool EDITOR_SHOW_JOINTSETTINGS;

	[HideInInspector]
	public bool EDITOR_SHOW_COLLIDERSETTINGS;

	public GameObject JointPrefab
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float JointScale
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool AlternateJoints
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool FirstJointAlternated
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public List<Vector3> ControlPoints
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Vector3> SplinePoints => null;

	public Vector3[] JointPositions => null;

	public Quaternion[] JointRotations => null;

	public float RopeLength => 0f;

	public bool FreeFallMode
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public event Action OnInitializeMesh
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

	private void OnDrawGizmosSelected()
	{
	}

	private void OnDrawGizmos()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void Update()
	{
	}

	public void RetractRope(float velocity)
	{
	}

	public void ExtendRope(float velocity)
	{
	}

	private void UpdateFreeFall()
	{
	}

	public void GenerateJointObjects()
	{
	}

	public void ClearJointObjects()
	{
	}

	private void PreCalculateRotations()
	{
	}

	public Quaternion[] GetRotations(Vector3[] points)
	{
		return null;
	}

	private Vector3 CalcPositionAtTime(float t)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	private void UpdatePhysics()
	{
	}

	private ConfigurableJoint AddConfigJoint(GameObject joint)
	{
		return null;
	}

	private void AddColliders()
	{
	}

	private void AttachObjects()
	{
	}

	public void ApplyRopeSettings()
	{
	}

	public void RebuildMesh()
	{
	}

	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, Vector3 hingeAxis, bool centerOnIndex)
	{
	}

	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, bool centerOnIndex)
	{
	}

	public void AttachObject(GameObject obj, int jointIndex, bool centerOnIndex)
	{
	}

	public void DetachObject(GameObject obj)
	{
	}

	public static QuickRope2 Create(GameObject pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(GameObject pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return null;
	}

	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return null;
	}
}
