using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SpiderBotAnimator : AnimationController
{
	private sealed class HBOGAAPKBCF : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public SpiderBotAnimator HNNCIECPFEJ;

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
		public HBOGAAPKBCF(int HEIHBBOBLGF)
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

	public AudioSource AHFBNJHCANA;

	public AudioSource JIGFCIOAPBJ;

	private PhotonView IBBJLFJLAFA;

	protected override void Awake()
	{
	}

	public void StartFalling()
	{
	}

	public void EndFall()
	{
	}

	public void PrepareMenu()
	{
	}

	[PunRPC]
	public void StartShoot()
	{
	}

	[PunRPC]
	public void EndShoot()
	{
	}

	private IEnumerator EHDHBLCPHED()
	{
		return null;
	}

	[PunRPC]
	public void StartEngineSound()
	{
	}

	public void Die()
	{
	}

	[PunRPC]
	public void SpawnSpiderling()
	{
	}
}
