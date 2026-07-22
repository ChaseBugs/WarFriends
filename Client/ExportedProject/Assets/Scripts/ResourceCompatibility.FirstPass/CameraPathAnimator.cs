using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraPathAnimator : MonoBehaviour
{
	public enum animationModes
	{
		once,
		loop,
		reverse,
		reverseLoop,
		pingPong
	}

	public enum orientationModes
	{
		custom,
		target,
		mouselook,
		followpath,
		reverseFollowpath,
		followTransform,
		twoDimentions,
		fixedOrientation,
		none
	}

	public delegate void AnimationStartedEventHandler();

	public delegate void AnimationPausedEventHandler();

	public delegate void AnimationStoppedEventHandler();

	public delegate void AnimationFinishedEventHandler();

	public delegate void AnimationLoopedEventHandler();

	public delegate void AnimationPingPongEventHandler();

	public delegate void AnimationPointReachedEventHandler();

	public delegate void AnimationCustomEventHandler(string eventName);

	public delegate void AnimationPointReachedWithNumberEventHandler(int pointNumber);

	public float MINIMUM_CAMERA_SPEED;

	public Transform orientationTarget;

	[SerializeField]
	private CameraPath _cameraPath;

	public bool playOnStart;

	public Transform animationObject;

	private Camera animationObjectCamera;

	private bool _isCamera;

	private bool _playing;

	public animationModes animationMode;

	public orientationModes orientationMode;

	private float pingPongDirection;

	public Vector3 fixedOrientaion;

	public bool normalised;

	public float editorPercentage;

	[SerializeField]
	private float _pathTime;

	[SerializeField]
	private float _pathSpeed;

	private float _percentage;

	private float _lastPercentage;

	public float nearestOffset;

	private float delayTime;

	public float sensitivity;

	public float minX;

	public float maxX;

	private float rotationX;

	private float rotationY;

	public bool showPreview;

	public GameObject editorPreview;

	public bool showScenePreview;

	private bool _animateSceneObjectInEditor;

	public Vector3 animatedObjectStartPosition;

	public Quaternion animatedObjectStartRotation;

	public float pathSpeed
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float currentTime => 0f;

	public bool isPlaying => false;

	public float percentage => 0f;

	public bool pingPongGoingForward => false;

	public CameraPath cameraPath => null;

	private bool isReversed => false;

	public bool isCamera => false;

	public bool animateSceneObjectInEditor
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public event AnimationStartedEventHandler AnimationStartedEvent
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

	public event AnimationPausedEventHandler AnimationPausedEvent
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

	public event AnimationStoppedEventHandler AnimationStoppedEvent
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

	public event AnimationFinishedEventHandler AnimationFinishedEvent
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

	public event AnimationLoopedEventHandler AnimationLoopedEvent
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

	public event AnimationPingPongEventHandler AnimationPingPongEvent
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

	public event AnimationPointReachedEventHandler AnimationPointReachedEvent
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

	public event AnimationPointReachedWithNumberEventHandler AnimationPointReachedWithNumberEvent
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

	public event AnimationCustomEventHandler AnimationCustomEvent
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

	public void Play()
	{
	}

	public void Stop()
	{
	}

	public void Pause()
	{
	}

	public void Seek(float value)
	{
	}

	public void Reverse()
	{
	}

	public Quaternion GetAnimatedOrientation(float percent, bool ignoreNormalisation)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	private void PlayNextAnimation()
	{
	}

	private void UpdateAnimation()
	{
	}

	private void UpdatePointReached()
	{
	}

	private void UpdateAnimationTime()
	{
	}

	private void UpdateAnimationTime(bool advance)
	{
	}

	private Quaternion GetMouseLook()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	private void CheckEvents()
	{
	}

	private void CleanUp()
	{
	}

	private void OnDelayEvent(float time)
	{
	}

	private void OnCustomEvent(string eventName)
	{
	}
}
