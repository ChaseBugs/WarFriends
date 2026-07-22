using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpecterLaser : Gun
{
	private sealed class KHFCAHBKGIP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public SpecterLaser HNNCIECPFEJ;

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
		public KHFCAHBKGIP(int HEIHBBOBLGF)
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

	public const string HFOFIDKPBBE = "game-ico-specter-hiddensniper-mark";

	private float KMMHJBNINIA;

	private float JLLKANAGHJN;

	private float OJFAELBGOPO;

	[SerializeField]
	private LaserRenderer m_LaserRay;

	[SerializeField]
	private Color allyColor;

	[SerializeField]
	private Color enemyColor;

	private double MEJIPMLMEKC;

	private bool GLMOFEIBHCO;

	private Vector3 HOKGPBHOKHH;

	private Vector3 DENGFHNDCLP;

	[CompilerGenerated]
	private Vector3 _003CCGFAGJOCJIF_003Ek__BackingField;

	public Vector3 actualPoint
	{
		[CompilerGenerated]
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public Vector3 offScreenPosition => default(Vector3);

	public void InitConstants()
	{
	}

	public void SetSize(bool HMPKDOPDPPI)
	{
	}

	public void ShowForMenu(Vector3 ELJBCOMHNDF, Vector3 EGKHODBDOPM, float JINBCBCBAJO, Vector3 DHPDMPBGCBO)
	{
	}

	public void Show(Vector3 LJCGBLJIHFA, Vector3 ENMPMMJOEKA, Vector3 DHPDMPBGCBO, double GAMFJEOGHJD, bool MKCGBDFLJNJ, bool CCKBEKGHHKH)
	{
	}

	public void AnimateHide()
	{
	}

	private IEnumerator HHLCHCCILMA()
	{
		return null;
	}

	public void SetActualPoint(Vector3 GDDFEGMEOAK)
	{
	}

	public void ChangeCamera(Camera LGMLIACICIP)
	{
	}

	private void FixedUpdate()
	{
	}

	private void NAPGCONBBEH()
	{
	}

	public void ShootNow(Vector3 LGFMBOJMMMB, bool KMKNPEHKLMI)
	{
	}
}
