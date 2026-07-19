using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FlockController : MonoBehaviour
{
	public FlockChild _childPrefab;

	public int _childAmount;

	public bool _slowSpawn;

	public float _spawnSphere;

	public float _spawnSphereHeight;

	public float _spawnSphereDepth;

	public float _minSpeed;

	public float _maxSpeed;

	public float _minScale;

	public float _maxScale;

	public float _soarFrequency;

	public string _soarAnimation;

	public string _flapAnimation;

	public string _idleAnimation;

	public float _diveValue;

	public float _diveFrequency;

	public float _minDamping;

	public float _maxDamping;

	public float _waypointDistance;

	public float _minAnimationSpeed;

	public float _maxAnimationSpeed;

	public float _randomPositionTimer;

	public float _positionSphere;

	public float _positionSphereHeight;

	public float _positionSphereDepth;

	public bool _childTriggerPos;

	public bool _forceChildWaypoints;

	public float _forcedRandomDelay;

	public bool _flatFly;

	public bool _flatSoar;

	public bool _birdAvoid;

	public int _birdAvoidHorizontalForce;

	public bool _birdAvoidDown;

	public bool _birdAvoidUp;

	public int _birdAvoidVerticalForce;

	public float _birdAvoidDistanceMax;

	public float _birdAvoidDistanceMin;

	public float _soarMaxTime;

	public LayerMask _avoidanceMask;

	public List<FlockChild> _roamers;

	public Vector3 _posBuffer;

	public int _updateDivisor;

	public float _newDelta;

	public int _updateCounter;

	public float _activeChildren;

	public bool _groupChildToNewTransform;

	public Transform _groupTransform;

	public string _groupName;

	public bool _groupChildToFlock;

	public Vector3 _startPosOffset;

	public Transform _thisT;

	public FlockController()
	{
		_childAmount = 250;
		_spawnSphere = 3f;
		_spawnSphereHeight = 3f;
		_spawnSphereDepth = -1f;
		_minSpeed = 6f;
		_maxSpeed = 10f;
		_minScale = 0.7f;
		_maxScale = 1f;
		_soarAnimation = "Soar";
		_flapAnimation = "Flap";
		_idleAnimation = "Idle";
		_diveValue = 7f;
		_diveFrequency = 0.5f;
		_minDamping = 1f;
		_maxDamping = 2f;
		_waypointDistance = 1f;
		_minAnimationSpeed = 2f;
		_maxAnimationSpeed = 4f;
		_randomPositionTimer = 10f;
		_positionSphere = 25f;
		_positionSphereHeight = 25f;
		_positionSphereDepth = -1f;
		_forcedRandomDelay = 1.5f;
		_birdAvoidHorizontalForce = 1000;
		_birdAvoidVerticalForce = 300;
		_birdAvoidDistanceMax = 4.5f;
		_birdAvoidDistanceMin = 5f;
		_avoidanceMask = -1;
		_updateDivisor = 1;
		_groupName = string.Empty;
	}

	public virtual void Start()
	{
		_thisT = transform;
		if (_positionSphereDepth == -1f)
		{
			_positionSphereDepth = _positionSphere;
		}
		if (_spawnSphereDepth == -1f)
		{
			_spawnSphereDepth = _spawnSphere;
		}
		_posBuffer = _thisT.position + _startPosOffset;
		if (!_slowSpawn)
		{
			AddChild(_childAmount);
		}
		InvokeRepeating("SetFlockRandomPosition", _randomPositionTimer, _randomPositionTimer);
	}

	public virtual void AddChild(int amount)
	{
		if (_groupChildToNewTransform)
		{
			InstantiateGroup();
		}
		for (int i = 0; i < amount; i++)
		{
			FlockChild flockChild = UnityEngine.Object.Instantiate(_childPrefab);
			flockChild._spawner = this;
			_roamers.Add(flockChild);
			AddChildToParent(flockChild.transform);
		}
	}

	public virtual void AddChildToParent(Transform obj)
	{
		if (_groupChildToFlock)
		{
			obj.parent = transform;
		}
		else if (_groupChildToNewTransform)
		{
			obj.parent = _groupTransform;
		}
	}

	public virtual void RemoveChild(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			FlockChild flockChild = _roamers[_roamers.Count - 1];
			_roamers.RemoveAt(_roamers.Count - 1);
			UnityEngine.Object.Destroy(flockChild.gameObject);
		}
	}

	public virtual void Update()
	{
		if (!(_activeChildren <= 0f))
		{
			if (_updateDivisor > 1)
			{
				_updateCounter++;
				_updateCounter %= _updateDivisor;
				_newDelta = Time.deltaTime * (float)_updateDivisor;
			}
			else
			{
				_newDelta = Time.deltaTime;
			}
		}
		UpdateChildAmount();
	}

	public virtual void InstantiateGroup()
	{
		if (!_groupTransform)
		{
			GameObject gameObject = new GameObject();
			_groupTransform = gameObject.transform;
			_groupTransform.position = _thisT.position;
			if (_groupName != string.Empty)
			{
				gameObject.name = _groupName;
			}
			else
			{
				gameObject.name = _thisT.name + " Fish Container";
			}
		}
	}

	public virtual void UpdateChildAmount()
	{
		if (_childAmount >= 0 && _childAmount < _roamers.Count)
		{
			RemoveChild(1);
		}
		else if (_childAmount > _roamers.Count)
		{
			AddChild(1);
		}
	}

	public virtual void OnDrawGizmos()
	{
		if (!_thisT)
		{
			_thisT = transform;
		}
		if (!Application.isPlaying && _posBuffer != _thisT.position + _startPosOffset)
		{
			_posBuffer = _thisT.position + _startPosOffset;
		}
		if (_positionSphereDepth == -1f)
		{
			_positionSphereDepth = _positionSphere;
		}
		if (_spawnSphereDepth == -1f)
		{
			_spawnSphereDepth = _spawnSphere;
		}
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(_posBuffer, new Vector3(_spawnSphere * 2f, _spawnSphereHeight * 2f, _spawnSphereDepth * 2f));
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(_thisT.position, new Vector3(_positionSphere * 2f + _spawnSphere * 2f, _positionSphereHeight * 2f + _spawnSphereHeight * 2f, _positionSphereDepth * 2f + _spawnSphereDepth * 2f));
	}

	public virtual void SetFlockRandomPosition()
	{
		_posBuffer = new Vector3
		{
			x = UnityEngine.Random.Range(0f - _positionSphere, _positionSphere) + _thisT.position.x,
			z = UnityEngine.Random.Range(0f - _positionSphereDepth, _positionSphereDepth) + _thisT.position.z,
			y = UnityEngine.Random.Range(0f - _positionSphereHeight, _positionSphereHeight) + _thisT.position.y
		};
		if (_forceChildWaypoints)
		{
			for (int i = 0; i < _roamers.Count; i++)
			{
				(_roamers[i] as FlockChild).Wander(UnityEngine.Random.value * _forcedRandomDelay);
			}
		}
	}

	public virtual void destroyBirds()
	{
		for (int i = 0; i < _roamers.Count; i++)
		{
			UnityEngine.Object.Destroy((_roamers[i] as FlockChild).gameObject);
		}
		_childAmount = 0;
		_roamers.Clear();
	}

	public virtual void Main()
	{
	}
}
