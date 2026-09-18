using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class LandingSpotController : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InstantLandOnStart_002432 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_002433;

			internal LandingSpot _0024spot_002434;

			internal float _0024delay_002435;

			internal LandingSpotController _0024self__002436;

			public _0024(float delay, LandingSpotController self_)
			{
				_0024delay_002435 = delay;
				_0024self__002436 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024delay_002435)) ? 1 : 0);
					break;
				case 2:
					for (_0024i_002433 = 0; _0024i_002433 < _0024self__002436._thisT.childCount; _0024i_002433++)
					{
						if ((bool)(LandingSpot)_0024self__002436._thisT.GetChild(_0024i_002433).GetComponent(typeof(LandingSpot)))
						{
							_0024spot_002434 = (LandingSpot)_0024self__002436._thisT.GetChild(_0024i_002433).GetComponent(typeof(LandingSpot));
							_0024spot_002434.InstantLand();
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

		internal float _0024delay_002437;

		internal LandingSpotController _0024self__002438;

		public _0024InstantLandOnStart_002432(float delay, LandingSpotController self_)
		{
			_0024delay_002437 = delay;
			_0024self__002438 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024delay_002437, _0024self__002438);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InstantLand_002439 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_002440;

			internal LandingSpot _0024spot_002441;

			internal float _0024delay_002442;

			internal LandingSpotController _0024self__002443;

			public _0024(float delay, LandingSpotController self_)
			{
				_0024delay_002442 = delay;
				_0024self__002443 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024delay_002442)) ? 1 : 0);
					break;
				case 2:
					for (_0024i_002440 = 0; _0024i_002440 < _0024self__002443._thisT.childCount; _0024i_002440++)
					{
						if ((bool)(LandingSpot)_0024self__002443._thisT.GetChild(_0024i_002440).GetComponent(typeof(LandingSpot)))
						{
							_0024spot_002441 = (LandingSpot)_0024self__002443._thisT.GetChild(_0024i_002440).GetComponent(typeof(LandingSpot));
							_0024spot_002441.InstantLand();
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

		internal float _0024delay_002444;

		internal LandingSpotController _0024self__002445;

		public _0024InstantLand_002439(float delay, LandingSpotController self_)
		{
			_0024delay_002444 = delay;
			_0024self__002445 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024delay_002444, _0024self__002445);
		}
	}

	public bool _randomRotate;

	public Vector2 _autoCatchDelay;

	public Vector2 _autoDismountDelay;

	public float _maxBirdDistance;

	public float _minBirdDistance;

	public bool _takeClosest;

	public FlockController _flock;

	public bool _landOnStart;

	public bool _soarLand;

	public bool _onlyBirdsAbove;

	public float _landingSpeedModifier;

	public float _landingTurnSpeedModifier;

	public Transform _featherPS;

	public Transform _thisT;

	public LandingSpotController()
	{
		_randomRotate = true;
		_autoCatchDelay = new Vector2(10f, 20f);
		_autoDismountDelay = new Vector2(10f, 20f);
		_maxBirdDistance = 20f;
		_minBirdDistance = 5f;
		_soarLand = true;
		_landingSpeedModifier = 0.5f;
		_landingTurnSpeedModifier = 5f;
	}

	public virtual void Start()
	{
		if (!_thisT)
		{
			_thisT = transform;
		}
		if (!_flock)
		{
			_flock = (FlockController)UnityEngine.Object.FindObjectOfType(typeof(FlockController));
			Debug.Log(this + " has no assigned FlockController, a random FlockController has been assigned");
		}
		if (_landOnStart)
		{
			StartCoroutine(InstantLandOnStart(0.1f));
		}
	}

	public virtual void ScareAll()
	{
		for (int i = 0; i < _thisT.childCount; i++)
		{
			if ((bool)(LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot)))
			{
				LandingSpot landingSpot = (LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot));
				StartCoroutine(landingSpot.ReleaseFlockChild(0f, 1f));
			}
		}
	}

	public virtual void ScareAll(float minDelay, float maxDelay)
	{
		for (int i = 0; i < _thisT.childCount; i++)
		{
			if ((bool)(LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot)))
			{
				LandingSpot landingSpot = (LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot));
				StartCoroutine(landingSpot.ReleaseFlockChild(minDelay, maxDelay));
			}
		}
	}

	public virtual void LandAll()
	{
		for (int i = 0; i < _thisT.childCount; i++)
		{
			if ((bool)(LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot)))
			{
				LandingSpot landingSpot = (LandingSpot)_thisT.GetChild(i).GetComponent(typeof(LandingSpot));
				StartCoroutine(landingSpot.GetFlockChild(0f, 2f));
			}
		}
	}

	public virtual IEnumerator InstantLandOnStart(float delay)
	{
		return new _0024InstantLandOnStart_002432(delay, this).GetEnumerator();
	}

	public virtual IEnumerator InstantLand(float delay)
	{
		return new _0024InstantLand_002439(delay, this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
