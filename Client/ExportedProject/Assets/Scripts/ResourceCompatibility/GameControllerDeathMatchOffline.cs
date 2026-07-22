using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public class GameControllerDeathMatchOffline : IGameController
{
	private sealed class AIJLEKGCINF : IEnumerator<object>, IEnumerator, IDisposable
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
		public AIJLEKGCINF(int HEIHBBOBLGF)
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

	private sealed class FONLMGDLBML : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerDeathMatchOffline HNNCIECPFEJ;

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
		public FONLMGDLBML(int HEIHBBOBLGF)
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

	private int HEIJGCAOCEH;

	protected PlayerController JMPCHAAJIEJ;

	private float KEKPPOJNHLL;

	private bool FLHCGJDAAAN;

	private bool BCKEBPHMCKF;

	private bool GFJMHEJMFIF;

	[CompilerGenerated]
	private float _003CBCFOMKNEAIB_003Ek__BackingField;

	private bool EBNBEBLLOAN;

	private int PHHGHOODINO;

	private PlayerController GJMLNGMJLLB => null;

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

	public override bool dropCreates => false;

	public override bool canShowPause => false;

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

	public override float time
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	private int HNKLFBDIEKD => 0;

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

	public override bool canDeployUnits => false;

	public override string quitText => null;

	public override bool pauseCountDown => false;

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

	public void PausematchMaking(bool JAOPIKCFOEA)
	{
	}

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

	protected MapDefinition.DefendPosition NNHIHJBLAKO(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	protected void PIEBCKCNDDC()
	{
	}

	public void PrepareBot()
	{
	}

	private void MMLAHCPAJPE(PHOFJEDENDJ AGECANAKJOL, DestroyableObject.LDOKCBNNLCH IEDOEMFMGCP)
	{
	}

	protected override void Awake()
	{
	}

	private void BGMLFMIIGKD(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	protected void Update()
	{
	}

	protected virtual void CMOHMCAIKOL()
	{
	}

	protected void DCKGICIFKKP()
	{
	}

	public override void GetTimeProgressText(StringBuilder BALEOFOKIOC)
	{
	}

	public void SkipCam()
	{
	}

	[CompilerGenerated]
	private void KGEKLJIPGIG()
	{
	}
}
