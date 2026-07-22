using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public class GameControllerCampaign : IGameController
{
	private sealed class LDPOEIMDGFB : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerCampaign HNNCIECPFEJ;

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
		public LDPOEIMDGFB(int HEIHBBOBLGF)
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

	private sealed class CMFFMABBAOC : IEnumerator<object>, IEnumerator, IDisposable
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
		public CMFFMABBAOC(int HEIHBBOBLGF)
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

	private sealed class JKOCLJMHPAH : IEnumerator<object>, IEnumerator, IDisposable
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
		public JKOCLJMHPAH(int HEIHBBOBLGF)
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

	[CompilerGenerated]
	private Dictionary<string, UnitUpgradeDefinition> _003CMLKHJHJGECH_003Ek__BackingField;

	protected PlayerController GJMLNGMJLLB => null;

	public override bool dropCreates => false;

	public override float time
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public override List<Card> cardsForGame
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public GameController mMainController
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public override bool gameIsRunning
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override bool canShowPause => false;

	public override bool canDeployUnits => false;

	public bool shouldLooseDogtagWhenQuit => false;

	public override string quitText => null;

	public override bool pauseCountDown => false;

	private Dictionary<string, UnitUpgradeDefinition> MDEIKJLMKAF
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

	public override List<UnitUpgradeDefinition> opponentUpgrades => null;

	public override IEnumerator StartGame()
	{
		return null;
	}

	public override void FinishGame()
	{
	}

	public override void LoadingStarted()
	{
	}

	public override void StopGame(bool FKIOECHJOOO = true)
	{
	}

	public override void FreeLevel()
	{
	}

	public override IEnumerator AquireLevelName()
	{
		return null;
	}

	public virtual IEnumerator WaitForServerResponse()
	{
		return null;
	}

	public override void Quit()
	{
	}

	public void PausematchMaking(bool JAOPIKCFOEA)
	{
	}

	public override void Forfeit()
	{
	}

	public override void PauseGame(bool PHDBMIIGJKC)
	{
	}

	public override void FinishChoosingCards()
	{
	}

	public override void Rematch()
	{
	}

	public override void ResumeGame()
	{
	}

	public override void UnPauseGame()
	{
	}

	public override void GetTimeProgressText(StringBuilder BALEOFOKIOC)
	{
	}

	protected override Dictionary<string, UnitUpgradeDefinition> IMBPKPDEKEP(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool CJPHFLKKIPD, AIObject BAIADEIEOBB)
	{
		return default(UpgradeSlots.UnitUpgrades);
	}

	public override void ShowResultsScreen()
	{
	}
}
