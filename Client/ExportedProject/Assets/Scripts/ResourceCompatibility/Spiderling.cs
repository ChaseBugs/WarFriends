using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Spiderling : MechanicalUnit<SpiderlingBehaviour>, IOnPhotonSerializeViewSubscriber, IPhotonEventSubscriber
{
	private sealed class MIDEEBKEMLB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public Spiderling HNNCIECPFEJ;

		private PlayerController ENOAOFDFGII;

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
		public MIDEEBKEMLB(int HEIHBBOBLGF)
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

	public NavMeshAgent LPAJIFHNLKO;

	public SpiderlingAnimation HKDIBMOHOJE;

	private SpiderBot AGDBMBIOEKO;

	private bool ODJLKLFAKGK;

	private Vector3 PNOJBGAFKLA;

	private Vector3 CBBIKFFOCIA;

	private float FANMIAHOPMF;

	[SerializeField]
	private DestroyableObjectMultipleParts mDestroyableObject;

	private readonly GBNMKDCEBLE HNNGHKNFNFL;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	public override DestroyableObject destroyableObj => null;

	public Guid? PhotonSubscriberId
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	protected override void Awake()
	{
	}

	protected override void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	protected override void IOOJIDNOILO()
	{
	}

	private void DKNJINLKJOA(DestroyableObject KIHIFIBOOIM, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public void SetSpiderbotOwner(SpiderBot ALCEAEELEJJ)
	{
	}

	private void AFLIDJOLDPG(PHOFJEDENDJ AGECANAKJOL, DestroyableObject.LDOKCBNNLCH IEDOEMFMGCP)
	{
	}

	public override void OnInstancied()
	{
	}

	public override void DestroyPooled()
	{
	}

	public override void UpgradesLoaded()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public override void StartEnemyBehaviour()
	{
	}

	private IEnumerator NEMJMFHGKKJ()
	{
		return null;
	}

	private void EIPGHAPHKGN(Vector3 MPHCJEIMBEB)
	{
	}

	[PunRPC]
	private void TargetReached()
	{
	}

	protected override void Update()
	{
	}

	public void OnPhotonSerializeView(PhotonStream EENHMNOPHDF, PhotonMessageInfo INADGPICPMO)
	{
	}
}
