using System;
using System.Collections;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class FlockChild : MonoBehaviour
{
	[HideInInspector]
	public FlockController _spawner;

	[HideInInspector]
	public Vector3 _wayPoint;

	public float _speed;

	[HideInInspector]
	public bool _dived;

	[HideInInspector]
	public float _stuckCounter;

	[HideInInspector]
	public float _damping;

	[HideInInspector]
	public bool _soar;

	[HideInInspector]
	public bool _landing;

	private int _lerpCounter;

	[HideInInspector]
	public float _targetSpeed;

	[HideInInspector]
	public bool _move;

	public GameObject _model;

	public Transform _modelT;

	[HideInInspector]
	public float _avoidValue;

	[HideInInspector]
	public float _avoidDistance;

	private float _soarTimer;

	private bool _instantiated;

	[NonSerialized]
	private static int _updateNextSeed;

	private int _updateSeed;

	[HideInInspector]
	public bool _avoid;

	public Transform _thisT;

	public FlockChild()
	{
		_dived = true;
		_soar = true;
		_move = true;
		_updateSeed = -1;
		_avoid = true;
	}

	public virtual void Start()
	{
		FindRequiredComponents();
		Wander(0f);
		SetRandomScale();
		_thisT.position = findWaypoint();
		RandomizeStartAnimationFrame();
		InitAvoidanceValues();
		_speed = _spawner._minSpeed;
		_spawner._activeChildren += 1f;
		_instantiated = true;
		if (_spawner._updateDivisor > 1)
		{
			int num = _spawner._updateDivisor - 1;
			_updateNextSeed++;
			_updateSeed = _updateNextSeed;
			_updateNextSeed %= num;
		}
	}

	public virtual void Update()
	{
		if (_spawner._updateDivisor <= 1 || _spawner._updateCounter == _updateSeed)
		{
			SoarTimeLimit();
			CheckForDistanceToWaypoint();
			RotationBasedOnWaypointOrAvoidance();
			LimitRotationOfModel();
		}
	}

	public virtual void OnDisable()
	{
		CancelInvoke();
		_spawner._activeChildren -= 1f;
	}

	public virtual void OnEnable()
	{
		if (_instantiated)
		{
			_spawner._activeChildren += 1f;
			if (_landing)
			{
				_model.GetComponent<Animation>().Play(_spawner._idleAnimation);
			}
			else
			{
				_model.GetComponent<Animation>().Play(_spawner._flapAnimation);
			}
		}
	}

	public virtual void FindRequiredComponents()
	{
		if (!_thisT)
		{
			_thisT = transform;
		}
		if (!_model)
		{
			_model = _thisT.FindChild("Model").gameObject;
		}
		if (!_modelT)
		{
			_modelT = _model.transform;
		}
	}

	public virtual void RandomizeStartAnimationFrame()
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(_model.GetComponent<Animation>());
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			animationState.time = UnityEngine.Random.value * animationState.length;
			UnityRuntimeServices.Update(enumerator, animationState);
		}
	}

	public virtual void InitAvoidanceValues()
	{
		_avoidValue = UnityEngine.Random.Range(0.3f, 0.1f);
		if (_spawner._birdAvoidDistanceMax != _spawner._birdAvoidDistanceMin)
		{
			_avoidDistance = UnityEngine.Random.Range(_spawner._birdAvoidDistanceMax, _spawner._birdAvoidDistanceMin);
		}
		else
		{
			_avoidDistance = _spawner._birdAvoidDistanceMin;
		}
	}

	public virtual void SetRandomScale()
	{
		float num = UnityEngine.Random.Range(_spawner._minScale, _spawner._maxScale);
		_thisT.localScale = new Vector3(num, num, num);
	}

	public virtual void SoarTimeLimit()
	{
		if (_soar && !(_spawner._soarMaxTime <= 0f))
		{
			if (!(_soarTimer <= _spawner._soarMaxTime))
			{
				Flap();
				_soarTimer = 0f;
			}
			else
			{
				_soarTimer += _spawner._newDelta;
			}
		}
	}

	public virtual void CheckForDistanceToWaypoint()
	{
		if (!_landing && !((_thisT.position - _wayPoint).magnitude >= _spawner._waypointDistance + _stuckCounter))
		{
			Wander(0f);
			_stuckCounter = 0f;
		}
		else if (!_landing)
		{
			_stuckCounter += _spawner._newDelta;
		}
		else
		{
			_stuckCounter = 0f;
		}
	}

	public virtual void RotationBasedOnWaypointOrAvoidance()
	{
		Vector3 vector = _wayPoint - _thisT.position;
		if (!(_targetSpeed <= -1f) && vector != Vector3.zero)
		{
			Quaternion b = Quaternion.LookRotation(vector);
			_thisT.rotation = Quaternion.Slerp(_thisT.rotation, b, _spawner._newDelta * _damping);
		}
		if (_spawner._childTriggerPos && !((_thisT.position - _spawner._posBuffer).magnitude >= 1f))
		{
			_spawner.SetFlockRandomPosition();
		}
		_speed = Mathf.Lerp(_speed, _targetSpeed, (float)_lerpCounter * _spawner._newDelta * 0.05f);
		_lerpCounter++;
		if (_move)
		{
			_thisT.position += _thisT.forward * _speed * _spawner._newDelta;
			if (_avoid && _spawner._birdAvoid)
			{
				Avoidance();
			}
		}
	}

	public virtual bool Avoidance()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 forward = _modelT.forward;
		bool result = default(bool);
		Quaternion quaternion = default(Quaternion);
		Vector3 vector = default(Vector3);
		Vector3 vector2 = default(Vector3);
		vector2 = _thisT.position;
		quaternion = _thisT.rotation;
		vector = _thisT.rotation.eulerAngles;
		if (Physics.Raycast(_thisT.position, forward + _modelT.right * _avoidValue, out hitInfo, _avoidDistance, _spawner._avoidanceMask))
		{
			vector.y -= (float)_spawner._birdAvoidHorizontalForce * _spawner._newDelta * _damping;
			quaternion.eulerAngles = vector;
			_thisT.rotation = quaternion;
			result = true;
		}
		else if (Physics.Raycast(_thisT.position, forward + _modelT.right * (0f - _avoidValue), out hitInfo, _avoidDistance, _spawner._avoidanceMask))
		{
			vector.y += (float)_spawner._birdAvoidHorizontalForce * _spawner._newDelta * _damping;
			quaternion.eulerAngles = vector;
			_thisT.rotation = quaternion;
			result = true;
		}
		if (_spawner._birdAvoidDown && !_landing && Physics.Raycast(_thisT.position, -Vector3.up, out hitInfo, _avoidDistance, _spawner._avoidanceMask))
		{
			vector.x -= (float)_spawner._birdAvoidVerticalForce * _spawner._newDelta * _damping;
			quaternion.eulerAngles = vector;
			_thisT.rotation = quaternion;
			vector2.y += (float)_spawner._birdAvoidVerticalForce * _spawner._newDelta * 0.01f;
			_thisT.position = vector2;
			result = true;
		}
		else if (_spawner._birdAvoidUp && !_landing && Physics.Raycast(_thisT.position, Vector3.up, out hitInfo, _avoidDistance, _spawner._avoidanceMask))
		{
			vector.x += (float)_spawner._birdAvoidVerticalForce * _spawner._newDelta * _damping;
			quaternion.eulerAngles = vector;
			_thisT.rotation = quaternion;
			vector2.y -= (float)_spawner._birdAvoidVerticalForce * _spawner._newDelta * 0.01f;
			_thisT.position = vector2;
			result = true;
		}
		return result;
	}

	public virtual void LimitRotationOfModel()
	{
		Quaternion quaternion = default(Quaternion);
		Vector3 vector = default(Vector3);
		quaternion = _modelT.localRotation;
		vector = quaternion.eulerAngles;
		if ((((_soar && _spawner._flatSoar) || (_spawner._flatFly && !_soar)) && _wayPoint.y > _thisT.position.y) || _landing)
		{
			vector.x = Mathf.LerpAngle(_modelT.localEulerAngles.x, 0f - _thisT.localEulerAngles.x, (float)_lerpCounter * _spawner._newDelta * 0.75f);
			quaternion.eulerAngles = vector;
			_modelT.localRotation = quaternion;
		}
		else
		{
			vector.x = Mathf.LerpAngle(_modelT.localEulerAngles.x, 0f, (float)_lerpCounter * _spawner._newDelta * 0.75f);
			quaternion.eulerAngles = vector;
			_modelT.localRotation = quaternion;
		}
	}

	public virtual void Wander(float delay)
	{
		if (!_landing)
		{
			_damping = UnityEngine.Random.Range(_spawner._minDamping, _spawner._maxDamping);
			_targetSpeed = UnityEngine.Random.Range(_spawner._minSpeed, _spawner._maxSpeed);
			_lerpCounter = 0;
			Invoke("SetRandomMode", delay);
		}
	}

	public virtual void SetRandomMode()
	{
		CancelInvoke("SetRandomMode");
		if (!_dived && !(UnityEngine.Random.value >= _spawner._soarFrequency))
		{
			Soar();
		}
		else if (!_dived && !(UnityEngine.Random.value >= _spawner._diveFrequency))
		{
			Dive();
		}
		else
		{
			Flap();
		}
	}

	public virtual void Flap()
	{
		if (_move)
		{
			if ((bool)_model)
			{
				_model.GetComponent<Animation>().CrossFade(_spawner._flapAnimation, 0.5f);
			}
			_soar = false;
			animationSpeed();
			_wayPoint = findWaypoint();
			_dived = false;
		}
	}

	public virtual Vector3 findWaypoint()
	{
		return new Vector3
		{
			x = UnityEngine.Random.Range(0f - _spawner._spawnSphere, _spawner._spawnSphere) + _spawner._posBuffer.x,
			z = UnityEngine.Random.Range(0f - _spawner._spawnSphereDepth, _spawner._spawnSphereDepth) + _spawner._posBuffer.z,
			y = UnityEngine.Random.Range(0f - _spawner._spawnSphereHeight, _spawner._spawnSphereHeight) + _spawner._posBuffer.y
		};
	}

	public virtual void Soar()
	{
		if (_move)
		{
			_model.GetComponent<Animation>().CrossFade(_spawner._soarAnimation, 1.5f);
			_wayPoint = findWaypoint();
			_soar = true;
		}
	}

	public virtual void Dive()
	{
		if (_spawner._soarAnimation != null)
		{
			_model.GetComponent<Animation>().CrossFade(_spawner._soarAnimation, 1.5f);
		}
		else
		{
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(_model.GetComponent<Animation>());
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				if (!(obj is AnimationState))
				{
					obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj;
				if (!(_thisT.position.y >= _wayPoint.y + 25f))
				{
					animationState.speed = 0.1f;
					UnityRuntimeServices.Update(enumerator, animationState);
				}
			}
		}
		_wayPoint = findWaypoint();
		_wayPoint.y -= _spawner._diveValue;
		_dived = true;
	}

	public virtual void animationSpeed()
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(_model.GetComponent<Animation>());
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			if (!(obj is AnimationState))
			{
				obj = RuntimeServices.Coerce(obj, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj;
			if (!_dived && !_landing)
			{
				animationState.speed = UnityEngine.Random.Range(_spawner._minAnimationSpeed, _spawner._maxAnimationSpeed);
				UnityRuntimeServices.Update(enumerator, animationState);
			}
			else
			{
				animationState.speed = _spawner._maxAnimationSpeed;
				UnityRuntimeServices.Update(enumerator, animationState);
			}
		}
	}

	public virtual void Main()
	{
	}
}
