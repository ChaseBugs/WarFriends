using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ShieldPreviewCamera : Singleton<ShieldPreviewCamera>
{
	private sealed class KMIGGEKADEL : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public ShieldPreviewCamera HNNCIECPFEJ;

		public int IEFJMCLOCMB;

		public ShieldCosmeticsManager.ShieldCosmeticModel OMONCKAICBN;

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
		public KMIGGEKADEL(int HEIHBBOBLGF)
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

	private sealed class NMLIPHJFNKH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public bool KOAGNDKBFLM;

		public int EPNGMAHENPA;

		public float KIHALGIPHIJ;

		public ShieldPreviewCamera HNNCIECPFEJ;

		private float ABMEIPKNFDB;

		private float PBKBFLJOABN;

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
		public NMLIPHJFNKH(int HEIHBBOBLGF)
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

	private sealed class ADCINNCLCNN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public int EPNGMAHENPA;

		public float KIHALGIPHIJ;

		public ShieldPreviewCamera HNNCIECPFEJ;

		private float ABMEIPKNFDB;

		private float PBKBFLJOABN;

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
		public ADCINNCLCNN(int HEIHBBOBLGF)
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
	private List<ShieldRigInstance> mShieldInstances;

	[SerializeField]
	private List<GameObject> mShieldModels;

	[SerializeField]
	private List<Renderer> mShieldSubModels;

	[SerializeField]
	private List<ParticleSystem> mShieldParticles;

	[SerializeField]
	private Transform mTarget;

	private List<float> JECIJANJHBJ;

	public Camera FBMLLDMDNFC;

	private ShieldCosmeticsManager.ShieldCosmeticModel[] LNBKHDLPFAH;

	private ShieldRigInstance BKIFLCEGPGE;

	private static bool DLOPFFOPLBO;

	private float MKLOIKGOHPJ;

	private bool JAMJKGBGGMM;

	protected override void Start()
	{
	}

	protected override void Awake()
	{
	}

	public void SelectShieldSlot(int PKELBCEPGLI)
	{
	}

	private void GDPJBMCHBCP()
	{
	}

	public void DisplayShield(ShieldCosmeticsManager.ShieldCosmeticModel HMIIAANDMAO, int IEFJMCLOCMB)
	{
	}

	public void DisplayShieldAll(ShieldCosmeticsManager.ShieldCosmeticModel HMIIAANDMAO)
	{
	}

	private IEnumerator AMKPNGPACLE(ShieldCosmeticsManager.ShieldCosmeticModel OMONCKAICBN, int IEFJMCLOCMB)
	{
		return null;
	}

	public void HideShields()
	{
	}

	private void JCONFMJJIJC()
	{
	}

	public void RotateShieldsAllOnEquip()
	{
	}

	public void RotateShieldOnEquip(int PKELBCEPGLI)
	{
	}

	public void RotateShieldsAll()
	{
	}

	private IEnumerator OKFELJPKCPJ(int EPNGMAHENPA, float KIHALGIPHIJ, bool KOAGNDKBFLM)
	{
		return null;
	}

	private IEnumerator FDGEHEGGIFL(int EPNGMAHENPA, float KIHALGIPHIJ)
	{
		return null;
	}

	public void Pause()
	{
	}

	public void Resume()
	{
	}
}
