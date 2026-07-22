using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public class PlayerVisualCategoryGeneric<T> : PlayerVisualCategory where T : PlayerVisual
{
	private sealed class AJKIHHDDKCG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

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
		public AJKIHHDDKCG(int HEIHBBOBLGF)
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

	public List<T> FOJGCGFNEHL;

	private Dictionary<string, T> JGACKEOMNMG;

	public T t_equippedVisual => null;

	public override IEnumerable<PlayerVisual> allVisuals => null;

	public override int count => 0;

	public override PlayerVisual equippedVisual => null;

	public override PlayerVisual Item => null;

	public override void SetVisualIds()
	{
	}

	public override void InitVisuals()
	{
	}

	public override IEnumerator PrepareAssets()
	{
		return null;
	}
}
