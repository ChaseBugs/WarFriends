using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;

public class GameControllerWarArena : GameControllerPVP
{
	private sealed class MECJIILJDFP : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerWarArena HNNCIECPFEJ;

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
		public MECJIILJDFP(int HEIHBBOBLGF)
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

	private bool KBNNEFDKHIL;

	private PlayerInventory.EquippedWeapon[] NOOAMBBLMGO;

	private bool IHKGGGCEFEN;

	private ObscuredFloat JLGBJKFIKEP;

	private ObscuredFloat HGDGNFHIKAH;

	private ObscuredFloat LHCFFNCMNJL;

	private float CHPGMOFKDAM;

	private float NFLKJIFPHDF;

	private CardManager.CardFilter IMDACEACEBC;

	private List<CardSet> GNINKMIJIAJ;

	private LevelBehaviour.UnitType? IGKJJEMECCJ;

	private IBMHKHLJJNA DEJGKIPGEAF;

	private int LOFDIFMDACE;

	private List<LevelBehaviour> EPONFHOHFFB;

	[CompilerGenerated]
	private bool _003CLIHBFLHHDJH_003Ek__BackingField;

	[CompilerGenerated]
	private ObscuredFloat _003CKBHFPJFEBGP_003Ek__BackingField;

	public bool isFirstMatchMakingRound
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public ObscuredFloat destroyRandomShieldEveryNSeconds => default(ObscuredFloat);

	public float lastDestroyRandomShieldEveryNSecondsTime
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public ReadOnlyCollection<LevelBehaviour> equippedUnits => null;

	public override string loadingWaiting => null;

	protected override string IPGMJIEGPGN => null;

	public override bool dropCreates => false;

	public override CardManager.CardFilter cardsFilter => default(CardManager.CardFilter);

	public LevelBehaviour.UnitType? forbiddenUnitType => null;

	public override IBMHKHLJJNA spawningType => default(IBMHKHLJJNA);

	protected override bool JFLDBOGBPBG => false;

	public override bool ableToQuit
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override string quitText => null;

	public override PlayerInventory.EquippedWeapon[] equippedWeapons => null;

	public override int playerLevel => 0;

	public override int playerPrestigeLevel => 0;

	public ObscuredFloat hpCoeficient
	{
		[CompilerGenerated]
		get
		{
			return default(ObscuredFloat);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public override string[] equppedVisuals => null;

	public override bool isEqualMatch => false;

	public override bool isIgnoringMax2UnitsPerCategory => false;

	public override bool isUsingAugmentations => false;

	public override bool isSuperChargedUnitsEnabled => false;

	public bool isRandomUnitsRule => false;

	public override IEnumerator StartGame()
	{
		return null;
	}

	public void StartRandomMatchMaking(float KIHDEICDFBE = 1.5f)
	{
	}

	public void DisableCrates()
	{
	}

	public void SetShieldHP(float HHDCBKDKICG)
	{
	}

	public void SetDestroyRandomShieldEveryNSeconds(float HHDCBKDKICG)
	{
	}

	public void SetPlayerHP(float CDDIIBHEIBL)
	{
	}

	public void SetSpawningType(IBMHKHLJJNA FCCGBAPMCIL)
	{
	}

	public void SetCardsFilter(CardManager.CardFilter CHKFNKIGAGE)
	{
	}

	public void SetMatchCards(List<Card> HEILPAPPHKJ, CardManager.CardFilter CHKFNKIGAGE)
	{
	}

	public void SetForbiddenUnitType(LevelBehaviour.UnitType CHKFNKIGAGE)
	{
	}

	public void SetFixedEnergy(int MILOGOPCNAA)
	{
	}

	public void SetWeapons(PlayerInventory.EquippedWeapon[] FJJILDEABAH)
	{
	}

	public void SetUnits(List<LevelBehaviour> LEHEACGMAFI)
	{
	}

	public void ResetRules()
	{
	}

	private void PLBGKPFCBPG(bool CDOLGKGJDKO = true)
	{
	}

	public override void FinishGame()
	{
	}

	[PunRPC]
	protected override void FinishGameMultiplayerRPC(byte DFEHIADKKNO)
	{
	}

	public void SetOverTime(int GMMDNOEKNMG)
	{
	}

	protected override void IKMPMCBNMCH()
	{
	}

	public int GetTopRunGroup()
	{
		return 0;
	}

	public override int GetUnitPower(LevelBehaviour HDNJKKKHFNG)
	{
		return 0;
	}

	protected override void Update()
	{
	}

	protected override void GBGLDFMMPAB()
	{
	}

	protected override void Reset()
	{
	}

	public override void Rematch()
	{
	}

	public override void Quit()
	{
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool CJPHFLKKIPD, AIObject BAIADEIEOBB)
	{
		return default(UpgradeSlots.UnitUpgrades);
	}

	public override List<UnitUpgradeDefinition> GetUnitsUpgrades()
	{
		return null;
	}

	private void CDDAICCBICO()
	{
	}

	public override float GetPlayerHP(PlayerController EGJCNDAINGF)
	{
		return 0f;
	}

	public override float GetShieldHP(PlayerController EGJCNDAINGF)
	{
		return 0f;
	}

	protected void EDIJLGMNNAF()
	{
	}

	public override void ShowResultsScreen()
	{
	}

	protected override void POMIMAMGPCM()
	{
	}

	public override void OnConnectionFail(DisconnectCause EJAHBBBFHKK)
	{
	}

	protected override void PJFOCABKBPB(PhotonPlayer MBIHLECMNNJ)
	{
	}

	public override void OnPhotonJoinRoomFailed(object[] MAFMBGMNHBG)
	{
	}

	public override void UnPauseGame()
	{
	}

	protected override void KGJFNMNJMHF()
	{
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator GDPLJEIBFPN()
	{
		return null;
	}

	[CompilerGenerated]
	private void KLHJDMGPHAI(ConfirmDialog EJOPIJNPCGG, bool EGMJAECMHBP)
	{
	}

	[CompilerGenerated]
	private void GNCHDOPEJLI()
	{
	}

	[CompilerGenerated]
	private void OOLOPIDIAON()
	{
	}
}
