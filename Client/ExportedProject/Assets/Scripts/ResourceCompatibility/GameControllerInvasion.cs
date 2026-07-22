using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public class GameControllerInvasion : IGameController
{
	public enum CHCODCJPJPB
	{
		InvaderDied,
		PlayerDied,
		PlayerForfeit,
		BattleTimeout
	}

	private sealed class OEMKJCIHLBN : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerInvasion HNNCIECPFEJ;

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
		public OEMKJCIHLBN(int HEIHBBOBLGF)
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

	private sealed class MJPDPOMLNEP : IEnumerator<object>, IEnumerator, IDisposable
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
		public MJPDPOMLNEP(int HEIHBBOBLGF)
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

	private sealed class KIOEKLHCIKF
	{
		public LevelBehaviour DJDKOBKAJEO;

		internal bool NGDGIJGMDPF(InvasionManager.RegularUnit CFIOGPBCGGP)
		{
			return false;
		}
	}

	private float LDDPOOFMOEO;

	private float PJFMPKFIDBE;

	private PlayerController GJMLNGMJLLB;

	[NonSerialized]
	public CHCODCJPJPB DEOBGKMOKEN;

	[CompilerGenerated]
	private Dictionary<string, UnitUpgradeDefinition> _003CMLKHJHJGECH_003Ek__BackingField;

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

	public override bool dropCreates => false;

	public override bool canShowPause => false;

	public override bool canDeployUnits => false;

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

	public override bool isUsingAugmentations => false;

	public override IEnumerator StartGame()
	{
		return null;
	}

	private void EBAMICDDFKC(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
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

	public override void Quit()
	{
	}

	public override void Forfeit()
	{
	}

	public override void PauseGame(bool PHDBMIIGJKC)
	{
	}

	public override void ResumeGame()
	{
	}

	public override void UnPauseGame()
	{
	}

	public override void FinishChoosingCards()
	{
	}

	public override void Rematch()
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

	private void Update()
	{
	}

	public override void ShowResultsScreen()
	{
	}

	private List<UnitUpgradeDefinition> APINFLMIEJB()
	{
		return null;
	}

	public override void ShowGameOverScreen()
	{
	}

	public override bool DidGameOverScreenClose()
	{
		return false;
	}
}
