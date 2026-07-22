using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

public class GameControllerCoop : GameControllerOnline
{
	private sealed class GLECLIPLDGH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerCoop HNNCIECPFEJ;

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
		public GLECLIPLDGH(int HEIHBBOBLGF)
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

	private sealed class ADIPLADGIBC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerCoop HNNCIECPFEJ;

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
		public ADIPLADGIBC(int HEIHBBOBLGF)
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

	private sealed class GPHIFBGLOGH
	{
		public PlayerController GDMBMAPOKCL;

		internal void BFJACLHPEAM()
		{
		}
	}

	private sealed class PKOIJHGJEGE : IEnumerator<object>, IEnumerator, IDisposable
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
		public PKOIJHGJEGE(int HEIHBBOBLGF)
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

	public override string loadingWaitingCards => null;

	public override string loadingWaiting => null;

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

	public override bool canDeployUnits => false;

	protected override bool JFLDBOGBPBG => false;

	public override string quitText => null;

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

	public override List<UnitUpgradeDefinition> myUpgrades => null;

	protected override void POMIMAMGPCM()
	{
	}

	protected override void IKMPMCBNMCH()
	{
	}

	protected override MapDefinition.DefendPosition NNHIHJBLAKO(HPHFGNJPDKN LBHJBBKENEO, int IOCKOPOGPBG, PhotonPlayer GDMBMAPOKCL)
	{
		return null;
	}

	public new void StartMultiplayerGame(DatabasePlayer MBIHLECMNNJ, out string JFAOHOOMBLA, out bool KMBHKOKKHGG)
	{
		JFAOHOOMBLA = null;
		KMBHKOKKHGG = default(bool);
	}

	protected override void GBGLDFMMPAB()
	{
	}

	public override void StartMultiplayerGame(string JFAOHOOMBLA, CloudRegionCode KJJHOBNEOJI)
	{
	}

	private void JMFJMJHKOOM()
	{
	}

	public override IEnumerator StartGame()
	{
		return null;
	}

	private void OBNFKCFJHPM(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public override void GetTimeProgressText(StringBuilder BALEOFOKIOC)
	{
	}

	public override void Quit()
	{
	}

	private void BGMLFMIIGKD(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	private IEnumerator OCNGMEBEGFB()
	{
		return null;
	}

	protected override void ONPDJELADGC()
	{
	}

	public override void Forfeit()
	{
	}

	public override void FinishGame()
	{
	}

	[PunRPC]
	private void FinishGameCoopClient(byte DFEHIADKKNO, int ECIJDHLNIJO)
	{
	}

	private void OOPIDDHOPDJ(int ECIJDHLNIJO, float GAMFJEOGHJD, GameController.ALOAMODMHMO DFEHIADKKNO)
	{
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte DFEHIADKKNO)
	{
	}

	protected override void OIBDCLJCHDP(PlayerController EGJCNDAINGF)
	{
	}

	protected override void CMOHMCAIKOL()
	{
	}

	protected override void Update()
	{
	}

	public override IEnumerator AquireLevelName()
	{
		return null;
	}

	public override void FinishChoosingCards()
	{
	}

	public override void Rematch()
	{
	}

	public override void PauseGame(bool PHDBMIIGJKC)
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

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator GDPLJEIBFPN()
	{
		return null;
	}
}
