using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class LandingSpot : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GetFlockChild_002415 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal FlockChild _0024fChild_002416;

			internal int _0024i_002417;

			internal FlockChild _0024child_002418;

			internal float _0024minDelay_002419;

			internal float _0024maxDelay_002420;

			internal LandingSpot _0024self__002421;

			public _0024(float minDelay, float maxDelay, LandingSpot self_)
			{
				_0024minDelay_002419 = minDelay;
				_0024maxDelay_002420 = maxDelay;
				_0024self__002421 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(_0024minDelay_002419, _0024maxDelay_002420))) ? 1 : 0);
					break;
				case 2:
					if (_0024self__002421._controller._flock.gameObject.activeInHierarchy && !_0024self__002421.landingChild)
					{
						_0024self__002421.RandomRotate();
						_0024fChild_002416 = null;
						for (_0024i_002417 = 0; _0024i_002417 < _0024self__002421._controller._flock._roamers.Count; _0024i_002417++)
						{
							_0024child_002418 = _0024self__002421._controller._flock._roamers[_0024i_002417] as FlockChild;
							if (!_0024child_002418._landing && !_0024child_002418._dived)
							{
								if (!_0024self__002421._controller._onlyBirdsAbove)
								{
									if (!_0024fChild_002416 && !(_0024self__002421._controller._maxBirdDistance <= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)) && !(_0024self__002421._controller._minBirdDistance >= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)))
									{
										_0024fChild_002416 = _0024child_002418;
										if (!_0024self__002421._controller._takeClosest)
										{
											break;
										}
									}
									else if ((bool)_0024fChild_002416 && !(Vector3.Distance(_0024fChild_002416._thisT.position, _0024self__002421._thisT.position) <= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)))
									{
										_0024fChild_002416 = _0024child_002418;
									}
								}
								else if (!_0024fChild_002416 && !(_0024child_002418._thisT.position.y <= _0024self__002421._thisT.position.y) && !(_0024self__002421._controller._maxBirdDistance <= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)) && !(_0024self__002421._controller._minBirdDistance >= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)))
								{
									_0024fChild_002416 = _0024child_002418;
									if (!_0024self__002421._controller._takeClosest)
									{
										break;
									}
								}
								else if ((bool)_0024fChild_002416 && !(_0024child_002418._thisT.position.y <= _0024self__002421._thisT.position.y) && !(Vector3.Distance(_0024fChild_002416._thisT.position, _0024self__002421._thisT.position) <= Vector3.Distance(_0024child_002418._thisT.position, _0024self__002421._thisT.position)))
								{
									_0024fChild_002416 = _0024child_002418;
								}
							}
						}
						if ((bool)_0024fChild_002416)
						{
							_0024self__002421.landingChild = _0024fChild_002416;
							_0024self__002421.landing = true;
							_0024self__002421.landingChild._landing = true;
							_0024self__002421.StartCoroutine(_0024self__002421.ReleaseFlockChild(_0024self__002421._controller._autoDismountDelay.x, _0024self__002421._controller._autoDismountDelay.y));
						}
						else if (!(_0024self__002421._controller._autoCatchDelay.x <= 0f))
						{
							_0024self__002421.StartCoroutine(_0024self__002421.GetFlockChild(_0024self__002421._controller._autoCatchDelay.x, _0024self__002421._controller._autoCatchDelay.y));
						}
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024minDelay_002422;

		internal float _0024maxDelay_002423;

		internal LandingSpot _0024self__002424;

		public _0024GetFlockChild_002415(float minDelay, float maxDelay, LandingSpot self_)
		{
			_0024minDelay_002422 = minDelay;
			_0024maxDelay_002423 = maxDelay;
			_0024self__002424 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024minDelay_002422, _0024maxDelay_002423, _0024self__002424);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ReleaseFlockChild_002425 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024minDelay_002426;

			internal float _0024maxDelay_002427;

			internal LandingSpot _0024self__002428;

			public _0024(float minDelay, float maxDelay, LandingSpot self_)
			{
				_0024minDelay_002426 = minDelay;
				_0024maxDelay_002427 = maxDelay;
				_0024self__002428 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(UnityEngine.Random.Range(_0024minDelay_002426, _0024maxDelay_002427))) ? 1 : 0);
					break;
				case 2:
					if (_0024self__002428._controller._flock.gameObject.activeInHierarchy && (bool)_0024self__002428.landingChild)
					{
						_0024self__002428.lerpCounter = 0;
						if ((bool)_0024self__002428._controller._featherPS)
						{
							_0024self__002428._controller._featherPS.position = _0024self__002428.landingChild._thisT.position;
							_0024self__002428._controller._featherPS.GetComponent<ParticleSystem>().Emit(UnityEngine.Random.Range(0, 3));
						}
						_0024self__002428.landing = false;
						_0024self__002428._idle = false;
						_0024self__002428.landingChild._avoid = true;
						_0024self__002428.landingChild._damping = _0024self__002428.landingChild._spawner._maxDamping;
						_0024self__002428.landingChild._model.GetComponent<Animation>().CrossFade(_0024self__002428.landingChild._spawner._flapAnimation, 0.2f);
						_0024self__002428.landingChild._dived = true;
						_0024self__002428.landingChild._speed = 0f;
						_0024self__002428.landingChild._move = true;
						_0024self__002428.landingChild._landing = false;
						_0024self__002428.landingChild.Flap();
						_0024self__002428.landingChild._wayPoint = new Vector3(_0024self__002428.landingChild._wayPoint.x, _0024self__002428._thisT.position.y + 10f, _0024self__002428.landingChild._wayPoint.z);
						result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					goto IL_0293;
				case 3:
					if (!(_0024self__002428._controller._autoCatchDelay.x <= 0f))
					{
						_0024self__002428.StartCoroutine(_0024self__002428.GetFlockChild(_0024self__002428._controller._autoCatchDelay.x, _0024self__002428._controller._autoCatchDelay.y));
					}
					_0024self__002428.landingChild = null;
					goto IL_0293;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0293:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024minDelay_002429;

		internal float _0024maxDelay_002430;

		internal LandingSpot _0024self__002431;

		public _0024ReleaseFlockChild_002425(float minDelay, float maxDelay, LandingSpot self_)
		{
			_0024minDelay_002429 = minDelay;
			_0024maxDelay_002430 = maxDelay;
			_0024self__002431 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024minDelay_002429, _0024maxDelay_002430, _0024self__002431);
		}
	}

	[HideInInspector]
	public FlockChild landingChild;

	[HideInInspector]
	public bool landing;

	private int lerpCounter;

	[HideInInspector]
	public LandingSpotController _controller;

	private bool _idle;

	public Transform _thisT;

	public virtual void Start()
	{
		if (!_thisT)
		{
			_thisT = transform;
		}
		if (!_controller)
		{
			_controller = (LandingSpotController)_thisT.parent.GetComponent(typeof(LandingSpotController));
		}
		if (!(_controller._autoCatchDelay.x <= 0f))
		{
			StartCoroutine(GetFlockChild(_controller._autoCatchDelay.x, _controller._autoCatchDelay.y));
		}
		RandomRotate();
	}

	public virtual void OnDrawGizmos()
	{
		if (!_thisT)
		{
			_thisT = transform;
		}
		if (!_controller)
		{
			_controller = (LandingSpotController)_thisT.parent.GetComponent(typeof(LandingSpotController));
		}
		Gizmos.color = Color.yellow;
		if ((bool)landingChild && landing)
		{
			Gizmos.DrawLine(_thisT.position, landingChild._thisT.position);
		}
		if (_thisT.rotation.eulerAngles.x != 0f || _thisT.rotation.eulerAngles.z != 0f)
		{
			_thisT.eulerAngles = new Vector3(0f, _thisT.eulerAngles.y, 0f);
		}
		Gizmos.DrawWireCube(new Vector3(_thisT.position.x, _thisT.position.y, _thisT.position.z), new Vector3(0.2f, 0.2f, 0.2f));
		Gizmos.DrawWireCube(_thisT.position + _thisT.forward * 0.2f, new Vector3(0.1f, 0.1f, 0.1f));
		Gizmos.color = new Color(1f, 1f, 0f, 0.05f);
		Gizmos.DrawWireSphere(_thisT.position, _controller._maxBirdDistance);
	}

	public virtual void LateUpdate()
	{
		if (!_controller._flock.gameObject.activeInHierarchy || !landing || !landingChild)
		{
			return;
		}
		if (!landingChild.gameObject.activeInHierarchy)
		{
			StartCoroutine(ReleaseFlockChild(0f, 0f));
		}
		float num = Vector3.Distance(landingChild._thisT.position, _thisT.position);
		if (!(num >= 5f) && !(num <= 0.5f))
		{
			if (_controller._soarLand)
			{
				landingChild._model.GetComponent<Animation>().CrossFade(landingChild._spawner._soarAnimation, 0.5f);
				if (!(num >= 2f))
				{
					landingChild._model.GetComponent<Animation>().CrossFade(landingChild._spawner._flapAnimation, 0.5f);
				}
			}
			landingChild._targetSpeed = landingChild._spawner._maxSpeed * 0.5f;
			landingChild._wayPoint = _thisT.position;
			landingChild._damping = _controller._landingTurnSpeedModifier;
			landingChild._avoid = false;
		}
		else if (!(num > 0.5f))
		{
			landingChild._wayPoint = _thisT.position;
			if (!(num >= 0.1f) && !_idle)
			{
				_idle = true;
				landingChild._model.GetComponent<Animation>().CrossFade(landingChild._spawner._idleAnimation, 0.55f);
			}
			if (!(num <= 0.01f))
			{
				landingChild._targetSpeed = landingChild._spawner._minSpeed * _controller._landingSpeedModifier;
				landingChild._thisT.position = landingChild._thisT.position + (_thisT.position - landingChild._thisT.position) * Time.deltaTime * landingChild._speed * _controller._landingSpeedModifier;
			}
			landingChild._move = false;
			lerpCounter++;
			Quaternion rotation = landingChild._thisT.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			eulerAngles.y = Mathf.LerpAngle(landingChild._thisT.rotation.eulerAngles.y, _thisT.rotation.eulerAngles.y, (float)lerpCounter * Time.deltaTime * 0.005f);
			rotation.eulerAngles = eulerAngles;
			landingChild._thisT.rotation = rotation;
			landingChild._damping = _controller._landingTurnSpeedModifier;
		}
		else
		{
			landingChild._wayPoint = _thisT.position;
			landingChild._damping = 1f;
		}
	}

	public virtual IEnumerator GetFlockChild(float minDelay, float maxDelay)
	{
		return new _0024GetFlockChild_002415(minDelay, maxDelay, this).GetEnumerator();
	}

	public virtual void RandomRotate()
	{
		if (_controller._randomRotate)
		{
			Quaternion rotation = _thisT.rotation;
			Vector3 eulerAngles = rotation.eulerAngles;
			eulerAngles.y = UnityEngine.Random.Range(0, 360);
			rotation.eulerAngles = eulerAngles;
			_thisT.rotation = rotation;
		}
	}

	public virtual void InstantLand()
	{
		if (!_controller._flock.gameObject.activeInHierarchy || (bool)landingChild)
		{
			return;
		}
		FlockChild flockChild = null;
		for (int i = 0; i < _controller._flock._roamers.Count; i++)
		{
			FlockChild flockChild2 = _controller._flock._roamers[i] as FlockChild;
			if (!flockChild2._landing && !flockChild2._dived)
			{
				flockChild = flockChild2;
			}
		}
		if ((bool)flockChild)
		{
			landingChild = flockChild;
			landing = true;
			landingChild._landing = true;
			landingChild._thisT.position = _thisT.position;
			landingChild._model.GetComponent<Animation>().Play(landingChild._spawner._idleAnimation);
			StartCoroutine(ReleaseFlockChild(_controller._autoDismountDelay.x, _controller._autoDismountDelay.y));
		}
		else if (!(_controller._autoCatchDelay.x <= 0f))
		{
			StartCoroutine(GetFlockChild(_controller._autoCatchDelay.x, _controller._autoCatchDelay.y));
		}
	}

	public virtual IEnumerator ReleaseFlockChild(float minDelay, float maxDelay)
	{
		return new _0024ReleaseFlockChild_002425(minDelay, maxDelay, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
