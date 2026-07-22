using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierBehaviourOverseer : SoldierBehaviourGeneric<SoldierBehaviourDefinititonBasicSoldier>
{
	private sealed class OMGKCOJJJGI : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public float ABDDACBFJOP;

		public SoldierBehaviourOverseer HNNCIECPFEJ;

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
		public OMGKCOJJJGI(int HEIHBBOBLGF)
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

	[SerializeField]
	private Material mTransparent;

	[SerializeField]
	private OrbBehaviour mOrbBehaviour;

	[SerializeField]
	private Texture mAttachmentsTexture;

	[SerializeField]
	private Texture mEliteAttachmentsTexture;

	private OverseerOrb CPPDOGOPFGN;

	private float EAKDPHEFBCL;

	public override void UpdateVisual()
	{
	}

	public override void Unload()
	{
	}

	public override void DestroyBehaviour()
	{
	}

	public override void StartEnemyBehaviour()
	{
	}

	public void RemoveOrb(OverseerOrb JAHEJLIBIPH, bool FEHIMKGEHAE)
	{
	}

	private IEnumerator ALHMJFIECOM(float ABDDACBFJOP = 0f)
	{
		return null;
	}

	[PunRPC]
	private void SetOrbOwner(int NCNDABEOPDL)
	{
	}

	protected override void DEKOLCBBMAM()
	{
	}

	private void OnDisable()
	{
	}

	[CompilerGenerated]
	private void CHOPFNNFMJL()
	{
	}
}
