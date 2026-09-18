using System;
using System.Collections.Generic;
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

	public float jointSpacing = 1f;

	public bool showJoints;

	[SerializeField]
	[HideInInspector]
	private GameObject jointPrefab;

	[HideInInspector]
	[SerializeField]
	private float jointScale = 1f;

	[SerializeField]
	[HideInInspector]
	private bool alternateJoints;

	[SerializeField]
	[HideInInspector]
	private bool firstJointAlternated;

	[HideInInspector]
	[SerializeField]
	private List<Vector3> controlPoints = new List<Vector3>();

	[HideInInspector]
	[SerializeField]
	private List<Vector3> splinePoints = new List<Vector3>();

	[SerializeField]
	public List<GameObject> Joints = new List<GameObject>();

	[SerializeField]
	[HideInInspector]
	private List<Vector3> calculatedPositions = new List<Vector3>();

	[SerializeField]
	[HideInInspector]
	private Quaternion[] calculatedRotations;

	[SerializeField]
	[HideInInspector]
	public List<RopeAttachedObject> attachedObjects = new List<RopeAttachedObject>();

	private int prevJointcount;

	private float ropeLength;

	private bool freeFallMode;

	private Vector3 pastUp = Vector3.zero;

	private Vector3 pRopeEndPos = Vector3.zero;

	private bool initialized;

	public bool enablePhysics;

	public RopeColliderType colliderType;

	public PhysicMaterial physicsMaterial;

	public float colliderRadius = 0.25f;

	public RopeConstraint constraint;

	public float mass = 1f;

	public float drag = 0.2f;

	public float angDrag = 0.05f;

	public bool useGravity = true;

	public float LowAngXLimit = -60f;

	public float HighAngXLimit = 60f;

	public float LTLBounce;

	public float LTLSpring;

	public float LTLDamper;

	public float AngYLimit = 35f;

	public float AngZLimit = 35f;

	public float S1LBounce;

	public float S1LSpring;

	public float S1LDamper;

	public float breakForce = float.PositiveInfinity;

	public float breakTorque = float.PositiveInfinity;

	public int solverOverride = -1;

	private float distBetweenJoints;

	private float currentVelocity;

	public bool enableRopeController;

	public KeyCode extendRopeKey = KeyCode.DownArrow;

	public KeyCode retractRopeKey = KeyCode.UpArrow;

	public float acceleration = 10f;

	public float dampening = 0.96f;

	public float sleepVelocity = 0.5f;

	public float minRopeLength = 5f;

	public float maxRopeLength = 25f;

	public float maxVelocity = 5f;

	[HideInInspector]
	public int EDITOR_TAB_SELECTED;

	[HideInInspector]
	public static float EDITOR_GUI_SCALE = 0.5f;

	[HideInInspector]
	public bool EDITOR_SHOW_RIGIDBODY = true;

	[HideInInspector]
	public bool EDITOR_SHOW_JOINTSETTINGS;

	[HideInInspector]
	public bool EDITOR_SHOW_COLLIDERSETTINGS;

	public GameObject JointPrefab
	{
		get
		{
			return jointPrefab;
		}
		set
		{
			jointPrefab = value;
		}
	}

	public float JointScale
	{
		get
		{
			return jointScale;
		}
		set
		{
			jointScale = value;
		}
	}

	public bool AlternateJoints
	{
		get
		{
			return alternateJoints;
		}
		set
		{
			alternateJoints = value;
		}
	}

	public bool FirstJointAlternated
	{
		get
		{
			return firstJointAlternated;
		}
		set
		{
			firstJointAlternated = value;
		}
	}

	public List<Vector3> ControlPoints
	{
		get
		{
			return controlPoints;
		}
		set
		{
			controlPoints = value;
		}
	}

	public List<Vector3> SplinePoints => splinePoints;

	public Vector3[] JointPositions
	{
		get
		{
			if (Joints.Count == 0)
			{
				return new Vector3[1] { Vector3.zero };
			}
			Vector3[] array = new Vector3[Joints.Count];
			for (int i = 0; i < array.Length; i++)
			{
				ref Vector3 reference = ref array[i];
				reference = Joints[i].transform.position;
			}
			return array;
		}
	}

	public Quaternion[] JointRotations
	{
		get
		{
			Quaternion[] array = new Quaternion[Joints.Count];
			ref Quaternion reference = ref array[0];
			reference = Quaternion.LookRotation(Joints[0].transform.position - Joints[1].transform.position);
			for (int i = 1; i < array.Length; i++)
			{
				ref Quaternion reference2 = ref array[i];
				reference2 = Quaternion.LookRotation(Joints[i - 1].transform.position - Joints[i].transform.position);
			}
			return array;
		}
	}

	public float RopeLength
	{
		get
		{
			if (prevJointcount != Joints.Count)
			{
				ropeLength = 0f;
				for (int i = 1; i < Joints.Count; i++)
				{
					ropeLength += Vector3.Distance(Joints[i - 1].transform.position, Joints[i].transform.position);
				}
				prevJointcount = Joints.Count;
			}
			return ropeLength;
		}
	}

	public bool FreeFallMode
	{
		get
		{
			return freeFallMode;
		}
		set
		{
			freeFallMode = value;
			if (value)
			{
				Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
				Joints[1].transform.parent = Joints[0].transform;
			}
			else
			{
				Joints[0].GetComponent<ConfigurableJoint>().connectedBody = Joints[1].GetComponent<Rigidbody>();
				Joints[1].transform.parent = null;
			}
		}
	}

	public event Action OnInitializeMesh;

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
		for (int i = 2; i < splinePoints.Count - 1; i++)
		{
			Gizmos.DrawLine(splinePoints[i], splinePoints[i - 1]);
		}
		for (int j = 1; j < controlPoints.Count; j++)
		{
			Gizmos.DrawLine(controlPoints[j], controlPoints[j - 1]);
		}
		if (!enablePhysics || colliderType == RopeColliderType.DEFAULT)
		{
			return;
		}
		Gizmos.color = new Color(0.1f, 0.7f, 0.4f);
		foreach (GameObject joint in Joints)
		{
			Gizmos.DrawWireSphere(joint.transform.position, colliderRadius);
		}
	}

	private void OnDrawGizmos()
	{
		if (Application.isPlaying)
		{
			return;
		}
		if (splinePoints.Count > 3)
		{
			Gizmos.color = Color.black;
			Vector3 to = CalcPositionAtTime(0f);
			for (int i = 1; i <= 100; i++)
			{
				float t = (float)i / 100f;
				Vector3 vector = CalcPositionAtTime(t);
				Gizmos.DrawLine(vector, to);
				to = vector;
			}
			Gizmos.color = Color.white;
		}
		if ((bool)ropeEnd && QuickRope2Helper.HasMoved(ref pRopeEndPos, ropeEnd.transform.position))
		{
			ApplyRopeSettings();
		}
	}

	private void OnDestroy()
	{
		if (enablePhysics && Application.isPlaying)
		{
			foreach (RopeAttachedObject attachedObject in attachedObjects)
			{
				UnityEngine.Object.Destroy(attachedObject.jointRef);
			}
		}
		ClearJointObjects();
	}

	private void Start()
	{
		if (!(ropeEnd == null))
		{
			if (!initialized)
			{
				ApplyRopeSettings();
				AttachObjects();
			}
			distBetweenJoints = Vector3.Distance(Joints[0].transform.position, Joints[1].transform.position);
		}
	}

	private void OnEnable()
	{
		ApplyRopeSettings();
		AttachObjects();
	}

	private void Update()
	{
		if (!enablePhysics)
		{
			return;
		}
		if (freeFallMode)
		{
			UpdateFreeFall();
		}
		else
		{
			if (!enableRopeController)
			{
				return;
			}
			bool flag = false;
			if (Input.GetKey(extendRopeKey))
			{
				currentVelocity += acceleration * Time.deltaTime;
				flag = true;
			}
			if (Input.GetKey(retractRopeKey))
			{
				currentVelocity -= acceleration * Time.deltaTime;
				flag = true;
			}
			currentVelocity = Mathf.Clamp(currentVelocity, 0f - maxVelocity, maxVelocity);
			if ((RopeLength < minRopeLength && currentVelocity < 0f) || (RopeLength > maxRopeLength && currentVelocity > 0f))
			{
				currentVelocity = 0f;
			}
			if (currentVelocity > 0f)
			{
				ExtendRope(currentVelocity);
			}
			if (currentVelocity < 0f)
			{
				RetractRope(currentVelocity);
			}
			if (!flag)
			{
				currentVelocity *= dampening;
				if (currentVelocity != 0f && Mathf.Abs(currentVelocity) < sleepVelocity)
				{
					currentVelocity = 0f;
				}
			}
		}
	}

	public void RetractRope(float velocity)
	{
		Joints[1].transform.parent = Joints[0].transform;
		Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
		Joints[1].GetComponent<Rigidbody>().isKinematic = true;
		Joints[1].transform.position = Vector3.MoveTowards(Joints[1].transform.position, Joints[0].transform.position, Time.deltaTime * velocity * -1f);
		if (Vector3.Distance(Joints[1].transform.position, Joints[0].transform.position) <= 0.001f)
		{
			GameObject obj = Joints[1];
			Joints.RemoveAt(1);
			Joints.TrimExcess();
			UnityEngine.Object.Destroy(obj);
		}
		Joints[0].GetComponent<ConfigurableJoint>().connectedBody = Joints[1].GetComponent<Rigidbody>();
		Joints[1].GetComponent<Rigidbody>().isKinematic = false;
	}

	public void ExtendRope(float velocity)
	{
		Joints[0].GetComponent<ConfigurableJoint>().connectedBody = null;
		Joints[1].GetComponent<Rigidbody>().isKinematic = true;
		Joints[1].transform.position = Vector3.MoveTowards(Joints[1].transform.position, Joints[1].transform.position - (Joints[0].transform.position - Joints[2].transform.position).normalized, Time.deltaTime * velocity);
		if (Vector3.Distance(Joints[1].transform.position, Joints[0].transform.position) > distBetweenJoints * 1.5f)
		{
			GameObject gameObject;
			if (JointPrefab != null)
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(JointPrefab, Joints[1].transform.position - (Joints[1].transform.position - Joints[0].transform.position).normalized * distBetweenJoints, Quaternion.LookRotation(Joints[0].transform.position - Joints[1].transform.position));
				float zAngle = (alternateJoints ? (firstJointAlternated ? ((Joints.Count % 2 == 0) ? 90 : 0) : ((Joints.Count % 2 != 0) ? 90 : 0)) : 0);
				gameObject.transform.Rotate(0f, 0f, zAngle);
				gameObject.transform.localScale = Vector3.one * jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_" + Joints.Count);
				gameObject.transform.position = Joints[1].transform.position - (Joints[1].transform.position - Joints[0].transform.position).normalized * distBetweenJoints;
				gameObject.transform.rotation = Quaternion.LookRotation(Joints[0].transform.position - Joints[1].transform.position);
				float zAngle2 = (alternateJoints ? (firstJointAlternated ? ((Joints.Count % 2 != 0) ? 90 : 0) : ((Joints.Count % 2 == 0) ? 90 : 0)) : 0);
				gameObject.transform.Rotate(0f, 0f, zAngle2);
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!showJoints)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable;
			}
			if ((bool)gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			AddConfigJoint(gameObject).connectedBody = Joints[1].GetComponent<Rigidbody>();
			switch (colliderType)
			{
			case RopeColliderType.Sphere:
			{
				SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
				sphereCollider.radius = colliderRadius;
				sphereCollider.center = Vector3.zero;
				if (physicsMaterial != null)
				{
					sphereCollider.sharedMaterial = physicsMaterial;
				}
				break;
			}
			case RopeColliderType.Capsule:
			{
				float num = Vector3.Distance(gameObject.transform.position, Joints[1].transform.position);
				CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
				capsuleCollider.radius = colliderRadius;
				capsuleCollider.center = new Vector3(0f, 0f, num / 2f);
				capsuleCollider.direction = 2;
				capsuleCollider.height = num + (capsuleCollider.radius + capsuleCollider.radius);
				if (physicsMaterial != null)
				{
					capsuleCollider.sharedMaterial = physicsMaterial;
				}
				break;
			}
			}
			Joints[1].GetComponent<Rigidbody>().isKinematic = false;
			Joints.Insert(1, gameObject);
			Joints.TrimExcess();
		}
		Joints[1].GetComponent<Rigidbody>().isKinematic = false;
		Joints[0].GetComponent<ConfigurableJoint>().connectedBody = Joints[1].GetComponent<Rigidbody>();
	}

	private void UpdateFreeFall()
	{
		if (RopeLength > maxRopeLength)
		{
			FreeFallMode = false;
		}
		else if (Vector3.Distance(Joints[1].transform.position, Joints[0].transform.position) > distBetweenJoints)
		{
			GameObject gameObject;
			if (JointPrefab != null)
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(JointPrefab, Joints[1].transform.position - (Joints[1].transform.position - Joints[0].transform.position).normalized * distBetweenJoints, Quaternion.identity);
				gameObject.transform.LookAt(Joints[0].transform.position);
				float zAngle = (alternateJoints ? (firstJointAlternated ? ((Joints.Count % 2 == 0) ? 90 : 0) : ((Joints.Count % 2 != 0) ? 90 : 0)) : 0);
				gameObject.transform.Rotate(0f, 0f, zAngle);
				gameObject.transform.localScale = Vector3.one * jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_NULL");
				gameObject.transform.position = Joints[1].transform.position - (Joints[1].transform.position - Joints[0].transform.position).normalized * distBetweenJoints;
				gameObject.transform.rotation = Quaternion.identity;
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!showJoints)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable;
			}
			if ((bool)gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			AddConfigJoint(gameObject).connectedBody = Joints[1].GetComponent<Rigidbody>();
			Joints[1].transform.parent = null;
			Joints.Insert(1, gameObject);
			Joints.TrimExcess();
			Joints[1].transform.parent = Joints[0].transform;
		}
	}

	public void GenerateJointObjects()
	{
		ClearJointObjects();
		Joints.Add(base.gameObject);
		for (int i = 1; i < SplinePoints.Count - 1; i++)
		{
			GameObject gameObject;
			if (JointPrefab != null)
			{
				gameObject = (GameObject)UnityEngine.Object.Instantiate(JointPrefab, SplinePoints[i], calculatedRotations[i]);
				if (alternateJoints)
				{
					int num = (firstJointAlternated ? 1 : 0);
					gameObject.transform.Rotate(0f, 0f, (i % 2 == num) ? 90 : 0);
				}
				gameObject.transform.localScale = jointPrefab.transform.localScale * jointScale;
			}
			else
			{
				gameObject = new GameObject("Jnt_" + i);
				gameObject.transform.position = SplinePoints[i];
				gameObject.transform.rotation = calculatedRotations[i];
			}
			gameObject.layer = base.gameObject.layer;
			gameObject.tag = base.gameObject.tag;
			if (!Application.isPlaying)
			{
				gameObject.transform.parent = base.transform;
			}
			if (!showJoints)
			{
				gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.NotEditable;
			}
			if ((bool)gameObject.GetComponent<Collider>())
			{
				gameObject.GetComponent<Collider>().enabled = false;
			}
			Joints.Add(gameObject);
		}
		Joints.Add(ropeEnd);
	}

	public void ClearJointObjects()
	{
		for (int i = 0; i < Joints.Count; i++)
		{
			if (Joints[i].GetInstanceID() != base.gameObject.GetInstanceID() && Joints[i].GetInstanceID() != ropeEnd.GetInstanceID())
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(Joints[i]);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(Joints[i]);
				}
			}
		}
		Joints.Clear();
		Joints.TrimExcess();
	}

	private void PreCalculateRotations()
	{
		calculatedRotations = new Quaternion[SplinePoints.Count];
		ref Quaternion reference = ref calculatedRotations[0];
		reference = Quaternion.LookRotation(SplinePoints[0] - SplinePoints[1]);
		for (int i = 1; i < calculatedRotations.Length; i++)
		{
			ref Quaternion reference2 = ref calculatedRotations[i];
			reference2 = Quaternion.LookRotation(SplinePoints[i - 1] - SplinePoints[i]);
		}
	}

	public Quaternion[] GetRotations(Vector3[] points)
	{
		Vector3[] array = new Vector3[points.Length];
		Quaternion[] array2 = new Quaternion[points.Length];
		for (int i = 0; i < points.Length - 1; i++)
		{
			ref Vector3 reference = ref array[i];
			reference = points[i + 1] - points[i];
		}
		ref Vector3 reference2 = ref array[points.Length - 1];
		reference2 = array[points.Length - 2];
		Vector3 vector = ((!(pastUp == Vector3.zero)) ? pastUp : ((array[0].x != 0f || array[0].z != 0f) ? Vector3.up : Vector3.right));
		for (int j = 0; j < points.Length; j++)
		{
			Vector3 vector2 = ((j != 0 && j != points.Length - 1) ? (array[j] + array[j - 1]) : ((!(points[0] == points[points.Length - 1])) ? array[j] : (array[points.Length - 1] + array[0])));
			if (vector2 == Vector3.zero)
			{
				ref Quaternion reference3 = ref array2[j];
				reference3 = Quaternion.identity;
				continue;
			}
			vector2.Normalize();
			Vector3 vector3 = Vector3.Cross(vector, vector2);
			if (vector3 == Vector3.zero)
			{
				vector3 = Vector3.Cross(new Vector3(-0.3f, 0.1f, 0f), new Vector3(0f, 0f, 0.4f));
			}
			vector = Vector3.Cross(vector2, vector3);
			if (j == 0)
			{
				pastUp = vector;
			}
			if (vector3 != Vector3.zero)
			{
				array2[j].SetLookRotation(-vector3, vector);
			}
		}
		return array2;
	}

	private Vector3 CalcPositionAtTime(float t)
	{
		int num = calculatedPositions.Count - 3;
		int num2 = Mathf.Min(Mathf.FloorToInt(t * (float)num), num - 1);
		float num3 = t * (float)num - (float)num2;
		Vector3 vector = calculatedPositions[num2];
		Vector3 vector2 = calculatedPositions[num2 + 1];
		Vector3 vector3 = calculatedPositions[num2 + 2];
		Vector3 vector4 = calculatedPositions[num2 + 3];
		return 0.5f * ((-vector + 3f * vector2 - 3f * vector3 + vector4) * (num3 * num3 * num3) + (2f * vector - 5f * vector2 + 4f * vector3 - vector4) * (num3 * num3) + (-vector + vector3) * num3 + 2f * vector2);
	}

	private void UpdatePhysics()
	{
		if (Joints.Count == 0 || !enablePhysics)
		{
			return;
		}
		for (int i = 0; i < Joints.Count; i++)
		{
			GameObject gameObject = Joints[i];
			if (gameObject == null)
			{
				return;
			}
			if (gameObject.GetComponent<Rigidbody>() == null)
			{
				gameObject.AddComponent<Rigidbody>();
			}
			switch (constraint)
			{
			case RopeConstraint.NONE:
				gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
				break;
			case RopeConstraint.X_Y:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)56;
				break;
			case RopeConstraint.Y_Z:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)98;
				break;
			case RopeConstraint.Z_X:
				gameObject.GetComponent<Rigidbody>().constraints = (RigidbodyConstraints)84;
				break;
			}
			if (solverOverride != -1 && solverOverride > 1)
			{
				gameObject.GetComponent<Rigidbody>().solverIterations = solverOverride;
			}
			gameObject.GetComponent<Rigidbody>().mass = mass;
			gameObject.GetComponent<Rigidbody>().angularDrag = angDrag;
			gameObject.GetComponent<Rigidbody>().drag = drag;
			gameObject.GetComponent<Rigidbody>().useGravity = useGravity;
		}
		if (Application.isPlaying)
		{
			for (int j = 0; j < Joints.Count - 1; j++)
			{
				AddConfigJoint(Joints[j]).connectedBody = Joints[j + 1].GetComponent<Rigidbody>();
			}
			if (colliderType != RopeColliderType.DEFAULT)
			{
				AddColliders();
			}
		}
	}

	private ConfigurableJoint AddConfigJoint(GameObject joint)
	{
		if (Application.isPlaying)
		{
			UnityEngine.Object.Destroy(joint.GetComponent<ConfigurableJoint>());
		}
		else
		{
			UnityEngine.Object.DestroyImmediate(joint.GetComponent<ConfigurableJoint>());
		}
		if (Application.isPlaying && (bool)joint.GetComponent<Collider>() && colliderType == RopeColliderType.DEFAULT)
		{
			joint.GetComponent<Collider>().enabled = true;
		}
		ConfigurableJoint configurableJoint = joint.AddComponent<ConfigurableJoint>();
		configurableJoint.anchor = Vector3.zero;
		configurableJoint.xMotion = ConfigurableJointMotion.Locked;
		configurableJoint.yMotion = ConfigurableJointMotion.Locked;
		configurableJoint.zMotion = ConfigurableJointMotion.Locked;
		configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
		configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;
		configurableJoint.lowAngularXLimit = new SoftJointLimit
		{
			limit = LowAngXLimit,
			bounciness = LTLBounce
		};
		configurableJoint.highAngularXLimit = new SoftJointLimit
		{
			limit = HighAngXLimit,
			bounciness = LTLBounce
		};
		configurableJoint.angularYLimit = new SoftJointLimit
		{
			limit = AngYLimit,
			bounciness = S1LBounce
		};
		configurableJoint.angularZLimit = new SoftJointLimit
		{
			limit = AngZLimit,
			bounciness = S1LBounce
		};
		configurableJoint.angularXLimitSpring = new SoftJointLimitSpring
		{
			spring = LTLSpring,
			damper = LTLDamper
		};
		configurableJoint.angularYZLimitSpring = new SoftJointLimitSpring
		{
			spring = S1LSpring,
			damper = S1LDamper
		};
		if (!enableRopeController)
		{
			configurableJoint.breakForce = breakForce;
			configurableJoint.breakTorque = breakTorque;
		}
		return configurableJoint;
	}

	private void AddColliders()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		switch (colliderType)
		{
		case RopeColliderType.Sphere:
		{
			for (int j = 1; j < Joints.Count - 1; j++)
			{
				SphereCollider sphereCollider = Joints[j].AddComponent<SphereCollider>();
				sphereCollider.radius = colliderRadius;
				sphereCollider.center = Vector3.zero;
				if (physicsMaterial != null)
				{
					sphereCollider.sharedMaterial = physicsMaterial;
				}
			}
			break;
		}
		case RopeColliderType.Capsule:
		{
			for (int i = 1; i < Joints.Count; i++)
			{
				float num = Vector3.Distance(Joints[i].transform.position, Joints[i - 1].transform.position);
				if (!(num < colliderRadius))
				{
					CapsuleCollider capsuleCollider = Joints[i].AddComponent<CapsuleCollider>();
					capsuleCollider.radius = colliderRadius;
					capsuleCollider.center = new Vector3(0f, 0f, num / 2f);
					capsuleCollider.direction = 2;
					capsuleCollider.height = num + (capsuleCollider.radius + capsuleCollider.radius);
					if (physicsMaterial != null)
					{
						capsuleCollider.sharedMaterial = physicsMaterial;
					}
				}
			}
			break;
		}
		}
	}

	private void AttachObjects()
	{
		if (!enablePhysics || !Application.isPlaying)
		{
			return;
		}
		foreach (RopeAttachedObject attachedObject in attachedObjects)
		{
			if (!(attachedObject.go == null))
			{
				if (attachedObject.jointIndex > Joints.Count - 1)
				{
					attachedObject.jointIndex = Joints.Count - 1;
				}
				switch (attachedObject.jointType)
				{
				case RopeAttachmentJointType.Fixed:
					attachedObject.jointRef = Joints[attachedObject.jointIndex].AddComponent<FixedJoint>();
					attachedObject.jointRef.connectedBody = attachedObject.go.GetComponent<Rigidbody>();
					break;
				case RopeAttachmentJointType.Hinge:
					attachedObject.jointRef = attachedObject.go.AddComponent<HingeJoint>();
					(attachedObject.jointRef as HingeJoint).axis = attachedObject.hingeAxis;
					attachedObject.jointRef.connectedBody = Joints[attachedObject.jointIndex].GetComponent<Rigidbody>();
					break;
				}
			}
		}
	}

	public void ApplyRopeSettings()
	{
		if (ropeEnd == null)
		{
			return;
		}
		calculatedPositions.Clear();
		calculatedPositions.TrimExcess();
		calculatedPositions.Add(base.transform.position);
		calculatedPositions.AddRange(controlPoints);
		calculatedPositions.Add(ropeEnd.transform.position);
		calculatedPositions.Insert(0, base.transform.position - (calculatedPositions[1] - calculatedPositions[0]).normalized);
		calculatedPositions.Add(calculatedPositions[calculatedPositions.Count - 1] + (calculatedPositions[calculatedPositions.Count - 1] - calculatedPositions[calculatedPositions.Count - 2]).normalized);
		float num = 0f;
		Vector3 zero = Vector3.zero;
		splinePoints.Clear();
		splinePoints.TrimExcess();
		splinePoints.Add(CalcPositionAtTime(num));
		for (; num <= 1f; num += 0.0001f)
		{
			Vector3 vector = CalcPositionAtTime(num);
			if (Vector3.Distance(splinePoints[splinePoints.Count - 1], vector + zero) >= jointSpacing)
			{
				splinePoints.Add(vector);
			}
		}
		splinePoints.Add(CalcPositionAtTime(1f));
		PreCalculateRotations();
		base.transform.rotation = calculatedRotations[0];
		ropeEnd.transform.rotation = calculatedRotations[calculatedRotations.Length - 1];
		if (base.gameObject.GetComponent<QuickRope2Prefab>() == null && base.gameObject.GetComponent<QuickRope2Cloth>() == null)
		{
			GenerateJointObjects();
		}
		JointPrefab = null;
		if (this.OnInitializeMesh != null)
		{
			this.OnInitializeMesh();
		}
		if (base.gameObject.GetComponent<QuickRope2Cloth>() == null)
		{
			UpdatePhysics();
		}
		initialized = true;
	}

	public void RebuildMesh()
	{
		if (initialized && this.OnInitializeMesh != null)
		{
			this.OnInitializeMesh();
		}
	}

	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, Vector3 hingeAxis, bool centerOnIndex)
	{
		if ((bool)base.gameObject.GetComponent<QuickRope2Cloth>())
		{
			Debug.LogError("You must use the \"Cloth\" component to attach objects when using the Cloth mesh type.");
			return;
		}
		RopeAttachedObject ropeAttachedObject = new RopeAttachedObject();
		ropeAttachedObject.go = obj;
		ropeAttachedObject.jointIndex = jointIndex;
		ropeAttachedObject.jointType = jointType;
		ropeAttachedObject.hingeAxis = hingeAxis;
		if (centerOnIndex)
		{
			ropeAttachedObject.go.transform.position = Joints[ropeAttachedObject.jointIndex].transform.position;
		}
		attachedObjects.Add(ropeAttachedObject);
		if (Application.isPlaying && !(ropeAttachedObject.go == null))
		{
			switch (ropeAttachedObject.jointType)
			{
			case RopeAttachmentJointType.Fixed:
				ropeAttachedObject.jointRef = Joints[ropeAttachedObject.jointIndex].AddComponent<FixedJoint>();
				ropeAttachedObject.jointRef.connectedBody = ropeAttachedObject.go.GetComponent<Rigidbody>();
				break;
			case RopeAttachmentJointType.Hinge:
				ropeAttachedObject.jointRef = ropeAttachedObject.go.AddComponent<HingeJoint>();
				(ropeAttachedObject.jointRef as HingeJoint).axis = ropeAttachedObject.hingeAxis;
				ropeAttachedObject.jointRef.connectedBody = Joints[ropeAttachedObject.jointIndex].GetComponent<Rigidbody>();
				break;
			}
		}
	}

	public void AttachObject(GameObject obj, int jointIndex, RopeAttachmentJointType jointType, bool centerOnIndex)
	{
		AttachObject(obj, jointIndex, jointType, Vector3.forward, centerOnIndex);
	}

	public void AttachObject(GameObject obj, int jointIndex, bool centerOnIndex)
	{
		AttachObject(obj, jointIndex, RopeAttachmentJointType.Fixed, centerOnIndex);
	}

	public void DetachObject(GameObject obj)
	{
		foreach (RopeAttachedObject attachedObject in attachedObjects)
		{
			if (attachedObject.go.GetInstanceID() == obj.GetInstanceID())
			{
				if (Application.isPlaying)
				{
					UnityEngine.Object.Destroy(attachedObject.jointRef);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(attachedObject.jointRef);
				}
				attachedObjects.Remove(attachedObject);
				attachedObjects.TrimExcess();
				break;
			}
		}
	}

	public static QuickRope2 Create(GameObject pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		QuickRope2 quickRope = pointA.AddComponent<QuickRope2>();
		quickRope.ropeEnd = pointB;
		switch (ropeType)
		{
		case BasicRopeTypes.Line:
			quickRope.gameObject.AddComponent<QuickRope2Line>();
			break;
		case BasicRopeTypes.Prefab:
			quickRope.gameObject.AddComponent<QuickRope2Prefab>();
			break;
		case BasicRopeTypes.Mesh:
			quickRope.gameObject.AddComponent<QuickRope2Mesh>();
			break;
		case BasicRopeTypes.Cloth:
			quickRope.gameObject.AddComponent<QuickRope2Cloth>();
			break;
		}
		quickRope.ApplyRopeSettings();
		return quickRope;
	}

	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		GameObject gameObject = new GameObject("Rope");
		GameObject gameObject2 = new GameObject("Rope_End");
		gameObject.transform.position = pointA;
		gameObject2.transform.position = pointB;
		return Create(gameObject, gameObject2, curvePoints, ropeType);
	}

	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		GameObject gameObject = new GameObject("Rope_End");
		gameObject.transform.position = pointB;
		return Create(pointA, gameObject, curvePoints, ropeType);
	}

	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, List<Vector3> curvePoints, BasicRopeTypes ropeType)
	{
		GameObject gameObject = new GameObject("Rope");
		gameObject.transform.position = pointA;
		return Create(gameObject, pointB, curvePoints, ropeType);
	}

	public static QuickRope2 Create(GameObject pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return Create(pointA, pointB, null, ropeType);
	}

	public static QuickRope2 Create(Vector3 pointA, GameObject pointB, BasicRopeTypes ropeType)
	{
		return Create(pointA, pointB, null, ropeType);
	}

	public static QuickRope2 Create(GameObject pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return Create(pointA, pointB, null, ropeType);
	}

	public static QuickRope2 Create(Vector3 pointA, Vector3 pointB, BasicRopeTypes ropeType)
	{
		return Create(pointA, pointB, null, ropeType);
	}
}
