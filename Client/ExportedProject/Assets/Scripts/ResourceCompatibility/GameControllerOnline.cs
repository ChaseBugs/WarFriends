using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ExitGames.Client.Photon;

public abstract class GameControllerOnline : IGameController, IOnConnectedToPhotonSubscriber, IPhotonEventSubscriber, IOnLeftRoomSubscriber, IOnPhotonCreateRoomFailedSubscriber, IOnPhotonJoinRoomFailedSubscriber, IOnCreatedRoomSubscriber, IOnJoinedLobbySubscriber, IOnDisconnectedFromPhotonSubscriber, IOnConnectionFailSubscriber, IOnJoinedRoomSubscriber, IOnPhotonPlayerConnectedSubscriber, IOnPhotonPlayerDisconnectedSubscriber, IOnConnectedToMasterSubscriber, IOnPhotonCustomRoomPropertiesChangedSubscriber, IOnCustomAuthenticationFailedSubscriber
{
	private sealed class GGEPOIMDLKG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerOnline HNNCIECPFEJ;

		private float FFBFDIPGEOC;

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
		public GGEPOIMDLKG(int HEIHBBOBLGF)
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

	private sealed class LDCKOFPFAPC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public GameControllerOnline HNNCIECPFEJ;

		private float FFBFDIPGEOC;

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
		public LDCKOFPFAPC(int HEIHBBOBLGF)
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

	private sealed class IAEJIBMHMGE : IEnumerator<object>, IEnumerator, IDisposable
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
		public IAEJIBMHMGE(int HEIHBBOBLGF)
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

	protected static PlayerController ELNBIBOEJEO;

	protected bool HGFPPJHBNKH;

	protected int LIHJBFFPIBM;

	protected List<int> OPJOFIHPLPO;

	protected PhotonView IBBJLFJLAFA;

	private bool BBADOJJELKC;

	private bool BDBEGHGAIEA;

	private bool NLKCJKOIKLG;

	private bool PLLPAGCMBAD;

	protected bool FBMJGCJKOFP;

	[CompilerGenerated]
	private float _003CBCFOMKNEAIB_003Ek__BackingField;

	private double NCABJMDBNAJ;

	protected bool GMAMPOIOMEL;

	protected int KKMLPAEMPGO;

	private float OHLGFCMJCNE;

	protected bool HJEEKDMOOAG;

	protected int PHHGHOODINO;

	protected float GKFCIEEHJNG;

	protected float LHPHGGIEEGD;

	protected float OBCPKJKGODJ;

	[CompilerGenerated]
	private Guid? _003CMHOEGBAGFNO_003Ek__BackingField;

	private int HNKLFBDIEKD => 0;

	public override bool dropCreates => false;

	protected PlayerController GJMLNGMJLLB => null;

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

	public virtual string loadingWaitingCards => null;

	public virtual string loadingWaiting => null;

	private bool IOPKJNDOEPA => false;

	private bool FKOLLCANBDF => false;

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

	public bool isInMatch
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

	protected virtual bool JFLDBOGBPBG => false;

	public override bool pauseCountDown => false;

	public override bool canDeployUnits => false;

	public Guid? PhotonSubscriberId
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

	protected override void Awake()
	{
	}

	private void LDIGDJOJFAC(DatabaseAction JMAECKMPPBI)
	{
	}

	protected override void Start()
	{
	}

	public override IEnumerator StartGame()
	{
		return null;
	}

	protected bool KOECBJNLMJM(LIIMFPNNGAC.PKCPBLCPPJC CBADPHMMCIM)
	{
		return false;
	}

	protected bool ODHFJGHAALA(LIIMFPNNGAC.PKCPBLCPPJC CBADPHMMCIM)
	{
		return false;
	}

	[PunRPC]
	protected void LoadingFinishedRPC(int MIFHPHNIMPF, int FLOFOBIDBIP)
	{
	}

	public virtual void OnPhotonCustomRoomPropertiesChanged(ExitGames.Client.Photon.Hashtable NKCIBKHFNDB)
	{
	}

	private void BADKKDFLCGK(double OIEMNMJADKD)
	{
	}

	public override void FinishChoosingCards()
	{
	}

	protected virtual void KGJFNMNJMHF()
	{
	}

	protected virtual void POMIMAMGPCM()
	{
	}

	[PunRPC]
	public virtual void FinishChoosingCardsRPC(string FGDKEGGKFEO, string DHFPFCIILPM, int ECIJDHLNIJO, int FLOFOBIDBIP, string ADNKCLMKFDB, string AIHHGGDDAEL)
	{
	}

	protected virtual MapDefinition.DefendPosition NNHIHJBLAKO(HPHFGNJPDKN LBHJBBKENEO, int IOCKOPOGPBG, PhotonPlayer MNMLHIMCENE)
	{
		return null;
	}

	protected virtual HPHFGNJPDKN CHIDOHADAPH(PhotonPlayer GDMBMAPOKCL)
	{
		return default(HPHFGNJPDKN);
	}

	protected virtual void IKMPMCBNMCH()
	{
	}

	[PunRPC]
	protected void StartCameraAnimationFinishedRPC(int AOCDKEILCLP)
	{
	}

	protected void HLDFAIDBHGO()
	{
	}

	[PunRPC]
	protected void SkipCameraPreviewSetRPC(bool PAKPGGKDLKF)
	{
	}

	public void SkipCamExec()
	{
	}

	[PunRPC]
	protected void SkipCameraPreviewRPC()
	{
	}

	private void EHGKHDNOHEL()
	{
	}

	protected virtual void GBGLDFMMPAB()
	{
	}

	public virtual void StartMultiplayerGame(DatabasePlayer MBIHLECMNNJ, out string JFAOHOOMBLA, out bool KMBHKOKKHGG)
	{
		JFAOHOOMBLA = null;
		KMBHKOKKHGG = default(bool);
	}

	public virtual void StartChallengeGame(string EAJKCGDIDKF, Dictionary<CloudRegionCode, int> BCJODAODNAL, out bool KMBHKOKKHGG)
	{
		KMBHKOKKHGG = default(bool);
	}

	public virtual void StartMultiplayerGame(string JFAOHOOMBLA, CloudRegionCode KJJHOBNEOJI)
	{
	}

	protected virtual void Reset()
	{
	}

	[PunRPC]
	public void RematchRPC(int MIFHPHNIMPF, int LCBKKOGGEMJ, string PGBCKCMCMBJ)
	{
	}

	private void MPHKFMNFONK()
	{
	}

	public override void Rematch()
	{
	}

	public virtual void OnPhotonPlayerDisconnected(PhotonPlayer MBIHLECMNNJ)
	{
	}

	protected virtual void PJFOCABKBPB(PhotonPlayer MBIHLECMNNJ)
	{
	}

	protected void JMOIHCPJCIB(PhotonPlayer MBIHLECMNNJ)
	{
	}

	protected virtual void OIBDCLJCHDP(PlayerController EGJCNDAINGF)
	{
	}

	void IOnConnectedToMasterSubscriber.OnConnectedToMaster()
	{
	}

	void IOnJoinedRoomSubscriber.OnJoinedRoom()
	{
	}

	protected void MICCIHKMFDJ(PlayerController GDMBMAPOKCL, PhotonPlayer OPGPCNHJDMP)
	{
	}

	private void PIBOBHEPIIH()
	{
	}

	[PunRPC]
	protected void ResyncTimeRPC(float OCNHODJDHFN)
	{
	}

	private void DOFECAMJIKN()
	{
	}

	private void AKBIFJIKMLM(PhotonPlayer GDMBMAPOKCL)
	{
	}

	[PunRPC]
	protected void SetMapRPC(int AKBOMMEMLHM)
	{
	}

	private void DOFHIKLMKIO(PlayerController GDMBMAPOKCL)
	{
	}

	private void BEBGFIPLIAC(PhotonPlayer GDMBMAPOKCL)
	{
	}

	void IOnPhotonPlayerConnectedSubscriber.OnPhotonPlayerConnected(PhotonPlayer GDMBMAPOKCL)
	{
	}

	protected void DKHFEPOJIKM(DisconnectCause EJAHBBBFHKK)
	{
	}

	public virtual void OnCustomAuthenticationFailed(string IKIKBOCOJNL)
	{
	}

	public virtual void OnConnectionFail(DisconnectCause EJAHBBBFHKK)
	{
	}

	protected void PDMJHIIAHAL()
	{
	}

	protected void PJEAGKJKEFA()
	{
	}

	protected virtual void CMOHMCAIKOL()
	{
	}

	protected void MIGGOAJEGOC()
	{
	}

	protected void DCKGICIFKKP()
	{
	}

	void IOnDisconnectedFromPhotonSubscriber.OnDisconnectedFromPhoton()
	{
	}

	protected void ECHOLOKMPJF(int NNCFCHPCADD)
	{
	}

	private void FEPPPCPPKNI()
	{
	}

	public virtual void OnPhotonJoinRoomFailed(object[] MAFMBGMNHBG)
	{
	}

	void IOnConnectedToPhotonSubscriber.OnConnectedToPhoton()
	{
	}

	void IOnJoinedLobbySubscriber.OnJoinedLobby()
	{
	}

	void IOnPhotonCreateRoomFailedSubscriber.OnPhotonCreateRoomFailed(object[] MAFMBGMNHBG)
	{
	}

	void IOnCreatedRoomSubscriber.OnCreatedRoom()
	{
	}

	void IOnLeftRoomSubscriber.OnLeftRoom()
	{
	}

	protected void BGBJIHFGKMG(LIIMFPNNGAC.PKCPBLCPPJC CBADPHMMCIM)
	{
	}

	public override void FinishGame()
	{
	}

	private GameController.ALOAMODMHMO MIAFCIFLILK(GameController.ALOAMODMHMO FKJKOAIIMNC)
	{
		return default(GameController.ALOAMODMHMO);
	}

	[PunRPC]
	protected virtual void FinishGameMultiplayerRPC(byte DFEHIADKKNO)
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

	protected virtual void MPEGGINOJOJ()
	{
	}

	protected virtual void LAPFJODMKAI()
	{
	}

	public override void Quit()
	{
	}

	public virtual void PausematchMaking(bool JAOPIKCFOEA)
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

	public void Disconnect()
	{
	}

	public virtual IEnumerator WaitForServerResponse()
	{
		return null;
	}

	protected virtual void Update()
	{
	}

	protected virtual void ONPDJELADGC()
	{
	}

	[CompilerGenerated]
	private void HNCJKIDKAIM()
	{
	}

	[CompilerGenerated]
	private void BJDEBFOBDDE()
	{
	}
}
