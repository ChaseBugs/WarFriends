using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Google2u;

public class UpgradeSlotsBaseSoldier<T> : UpgradeSlotsGeneric<T> where T : Google2uComponentBase
{
	private sealed class IIKBNMDPMCK : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public UnitUpgrades BOCCHNDLCOJ;

		public UpgradeSlotsBaseSoldier<T> HNNCIECPFEJ;

		public bool OHOPOOEPMNP;

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
		public IIKBNMDPMCK(int HEIHBBOBLGF)
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

	private sealed class NEAANOGOGGP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public UnitUpgrades BOCCHNDLCOJ;

		public UpgradeSlotsBaseSoldier<T> HNNCIECPFEJ;

		public bool OHOPOOEPMNP;

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
		public NEAANOGOGGP(int HEIHBBOBLGF)
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

	public List<TechnologyVisualDefinition> GNGBFNOGOFJ;

	public List<TechnologyVisualDefinition> LGHFHIKLCOK;

	public List<TechnologyVisualDefinition> EEJPFNBFLJP;

	public List<TechnologyVisualDefinition> JEOMDPJIHAC;

	public List<TechnologyVisualDefinition> AIDEJHHNHAP;

	public List<TechnologyVisualDefinition> OBOALLIGGCG;

	public List<TechnologyVisualDefinition> AJDKEHLCDBF;

	public List<TechnologyVisualDefinition> JHGNGNKOGGM;

	public override float damage => 0f;

	protected override void LIHJODCEONO(BehaviourDefinititon INCKGPGHNEF, int KPJIJGPAEOD)
	{
	}

	public override List<Tuple<string, float[]>> GetGuiStats(UpgradeSlot DHBBBJLNMPH)
	{
		return null;
	}

	public override List<Tuple<string, float[]>> GetBmGuiStats(UpgradeSlot DHBBBJLNMPH)
	{
		return null;
	}

	public override IEnumerator LoadMineVisualsCoroutine(UnitUpgrades BOCCHNDLCOJ, bool OHOPOOEPMNP)
	{
		return null;
	}

	public override IEnumerator LoadOponentVisualsCoroutine(UnitUpgrades BOCCHNDLCOJ, bool OHOPOOEPMNP)
	{
		return null;
	}

	public override void NullOpponentVisuals()
	{
	}

	public override void NullMineVisuals()
	{
	}

	public override void UnloadVisuals()
	{
	}

	public override List<TechnologyVisualDefinition> GetVisuals(UnitUpgrades BOCCHNDLCOJ)
	{
		return null;
	}
}
