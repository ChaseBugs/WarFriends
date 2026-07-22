using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class CameraPath : MonoBehaviour
{
	public enum PointModes
	{
		Transform,
		ControlPoints,
		FOV,
		Events,
		Speed,
		Delay,
		Ease,
		Orientations,
		Tilt,
		AddPathPoints,
		RemovePathPoints,
		AddOrientations,
		RemoveOrientations,
		TargetOrientation,
		AddFovs,
		RemoveFovs,
		AddTilts,
		RemoveTilts,
		AddEvents,
		RemoveEvents,
		AddSpeeds,
		RemoveSpeeds,
		AddDelays,
		RemoveDelays,
		Options
	}

	public enum Interpolation
	{
		Linear,
		SmoothStep,
		CatmullRom,
		Hermite,
		Bezier
	}

	public delegate void RecalculateCurvesHandler();

	public delegate void PathPointAddedHandler(CameraPathControlPoint point);

	public delegate void PathPointRemovedHandler(CameraPathControlPoint point);

	public delegate void CheckStartPointCullHandler(float percentage);

	public delegate void CheckEndPointCullHandler(float percentage);

	public delegate void CleanUpListsHandler();

	public static float CURRENT_VERSION_NUMBER;

	public float version;

	[SerializeField]
	private List<CameraPathControlPoint> _points;

	[SerializeField]
	private Interpolation _interpolation;

	[SerializeField]
	private bool initialised;

	[SerializeField]
	private float _storedTotalArcLength;

	[SerializeField]
	private float[] _storedArcLengths;

	[SerializeField]
	private float[] _storedArcLengthsFull;

	[SerializeField]
	private Vector3[] _storedPoints;

	[SerializeField]
	private float[] _normalisedPercentages;

	[SerializeField]
	private float _storedPointResolution;

	[SerializeField]
	private int _storedValueArraySize;

	[SerializeField]
	private Vector3[] _storedPathDirections;

	[SerializeField]
	private CameraPathControlPoint[] _pointALink;

	[SerializeField]
	private CameraPathControlPoint[] _pointBLink;

	[SerializeField]
	private CameraPathOrientationList _orientationList;

	[SerializeField]
	private CameraPathFOVList _fovList;

	[SerializeField]
	private CameraPathTiltList _tiltList;

	[SerializeField]
	private CameraPathSpeedList _speedList;

	[SerializeField]
	private CameraPathEventList _eventList;

	[SerializeField]
	private CameraPathDelayList _delayList;

	[SerializeField]
	private bool _addOrientationsWithPoints;

	[SerializeField]
	private bool _looped;

	[SerializeField]
	private bool _normalised;

	private const float CLIP_THREASHOLD = 0.5f;

	[SerializeField]
	private Bounds _pathBounds;

	public float hermiteTension;

	public float hermiteBias;

	public GameObject editorPreview;

	public int selectedPoint;

	public PointModes pointMode;

	public float addPointAtPercent;

	[SerializeField]
	private CameraPath _nextPath;

	[SerializeField]
	private bool _interpolateNextPath;

	public bool showGizmos;

	public Color selectedPathColour;

	public Color unselectedPathColour;

	public Color selectedPointColour;

	public Color unselectedPointColour;

	public bool showOrientationIndicators;

	public float orientationIndicatorUnitLength;

	public Color orientationIndicatorColours;

	public bool autoSetStoedPointRes;

	public bool enableUndo;

	public bool showPreview;

	public bool enablePreviews;

	public CameraPathControlPoint Item => null;

	public int numberOfPoints => 0;

	public int realNumberOfPoints => 0;

	public int numberOfCurves => 0;

	public bool loop
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float pathLength => 0f;

	public CameraPathOrientationList orientationList => null;

	public CameraPathFOVList fovList => null;

	public CameraPathTiltList tiltList => null;

	public CameraPathSpeedList speedList => null;

	public CameraPathEventList eventList => null;

	public CameraPathDelayList delayList => null;

	public Bounds bounds => default(Bounds);

	public int storedValueArraySize => 0;

	public CameraPathControlPoint[] pointALink => null;

	public CameraPathControlPoint[] pointBLink => null;

	public Vector3[] storedPoints => null;

	public bool normalised
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Interpolation interpolation
	{
		get
		{
			return default(Interpolation);
		}
		set
		{
		}
	}

	public CameraPath nextPath
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool interpolateNextPath
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool shouldInterpolateNextPath => false;

	public float storedPointResolution
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public event RecalculateCurvesHandler RecalculateCurvesEvent
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

	public event PathPointAddedHandler PathPointAddedEvent
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

	public event PathPointRemovedHandler PathPointRemovedEvent
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

	public event CheckStartPointCullHandler CheckStartPointCullEvent
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

	public event CheckEndPointCullHandler CheckEndPointCullEvent
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

	public event CleanUpListsHandler CleanUpListsEvent
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

	public float StoredArcLength(int curve)
	{
		return 0f;
	}

	public int StoredValueIndex(float percentage)
	{
		return 0;
	}

	public CameraPathControlPoint AddPoint(Vector3 position)
	{
		return null;
	}

	public void AddPoint(CameraPathControlPoint point)
	{
	}

	public void InsertPoint(CameraPathControlPoint point, int index)
	{
	}

	public CameraPathControlPoint InsertPoint(int index)
	{
		return null;
	}

	public void RemovePoint(int index)
	{
	}

	public bool RemovePoint(string pointName)
	{
		return false;
	}

	public void RemovePoint(Vector3 pointPosition)
	{
	}

	public void RemovePoint(CameraPathControlPoint point)
	{
	}

	private float ParsePercentage(float percentage)
	{
		return 0f;
	}

	public float CalculateNormalisedPercentage(float percentage)
	{
		return 0f;
	}

	public float DeNormalisePercentage(float normalisedPercent)
	{
		return 0f;
	}

	public int GetPointNumber(float percentage)
	{
		return 0;
	}

	public Vector3 GetPathPosition(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public Vector3 GetPathPosition(float percentage, bool ignoreNormalisation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public Quaternion GetPathRotation(float percentage, bool ignoreNormalisation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	public Vector3 GetPathDirection(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public Vector3 GetPathDirection(float percentage, bool normalisePercent)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public float GetPathTilt(float percentage)
	{
		return 0f;
	}

	public float GetPathFOV(float percentage)
	{
		return 0f;
	}

	public float GetPathSpeed(float percentage)
	{
		return 0f;
	}

	public float GetPathEase(float percentage)
	{
		return 0f;
	}

	public void CheckEvents(float percentage)
	{
	}

	public float GetPathPercentage(CameraPathControlPoint point)
	{
		return 0f;
	}

	public float GetPathPercentage(int pointIndex)
	{
		return 0f;
	}

	public int GetNearestPointIndex(float percentage)
	{
		return 0;
	}

	public int GetLastPointIndex(float percentage, bool isNormalised)
	{
		return 0;
	}

	public int GetNextPointIndex(float percentage, bool isNormalised)
	{
		return 0;
	}

	public float GetCurvePercentage(CameraPathControlPoint pointA, CameraPathControlPoint pointB, float percentage)
	{
		return 0f;
	}

	public float GetCurvePercentage(CameraPathPoint pointA, CameraPathPoint pointB, float percentage)
	{
		return 0f;
	}

	public float GetCurvePercentage(CameraPathPoint point)
	{
		return 0f;
	}

	public float GetOutroEasePercentage(CameraPathDelay point)
	{
		return 0f;
	}

	public float GetIntroEasePercentage(CameraPathDelay point)
	{
		return 0f;
	}

	public float GetPathPercentage(CameraPathControlPoint pointA, CameraPathControlPoint pointB, float curvePercentage)
	{
		return 0f;
	}

	public float GetPathPercentage(float pointA, float pointB, float curvePercentage)
	{
		return 0f;
	}

	public int GetStoredPoint(float percentage)
	{
		return 0;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnValidate()
	{
	}

	private void OnDestroy()
	{
	}

	public void RecalculateStoredValues()
	{
	}

	public float GetNearestPoint(Vector3 fromPostition)
	{
		return 0f;
	}

	public float GetNearestPoint(Vector3 fromPostition, bool ignoreNormalisation)
	{
		return 0f;
	}

	public float GetNearestPoint(Vector3 fromPostition, bool ignoreNormalisation, int refinments)
	{
		return 0f;
	}

	public void Clear()
	{
	}

	public CameraPathControlPoint GetPoint(int index)
	{
		return null;
	}

	public int GetPointIndex(int index)
	{
		return 0;
	}

	public int GetCurveIndex(int startPointIndex)
	{
		return 0;
	}

	private void Init()
	{
	}

	private void InitialiseLists()
	{
	}
}
