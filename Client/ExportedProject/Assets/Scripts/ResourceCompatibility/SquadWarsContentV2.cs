using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SquadWarsContentV2 : Core_BaseScript
{
	public class NHOLNKBKJGD
	{
		public int MPHCJEIMBEB;

		public int PFMIAPGEHOP;

		public int IHBLALIAAJC;

		public DatabasePlayer GDMBMAPOKCL;

		public string DHGLLIFODIO;

		public int GAMKCDKDPKL;

		public static NHOLNKBKJGD HMNDGGDOBNE(int OIMMJIGPNDK, int PHCJGGDIPIN, int HIHMJECBMDC, DatabasePlayer HIHHCMDMDFI)
		{
			return null;
		}
	}

	public class OGFOCOKJCPF
	{
		public bool MIHLLAJBNOK;

		public KJMHIFOHDCO JFACCKJNHHC;

		public int PFMIAPGEHOP;

		public int IHBLALIAAJC;

		public int MMOKLDNMHLN;

		public int HPCBLHAKJIL;

		public int POGEBBEJJIM;

		public int MPHCJEIMBEB;

		public string HLIHJDECJAO;

		public string OFOMNJAPIBJ;

		public int LHNDACKMGBG;

		public int BGKHMINPHBM;

		public int LJKBNMGMPCL;

		public int CNCEINPPNPI;

		public static OGFOCOKJCPF NNDILJKPNIL(int OIMMJIGPNDK, string HPOCJBBBPOC, string LEGNKFCNBGA, int EEKAHLOJFPA, int MGBGDCAPMLG, int PFMIAPGEHOP, int IHBLALIAAJC, int MMOKLDNMHLN, KJMHIFOHDCO NOKPDBFCEIH)
		{
			return null;
		}

		public static OGFOCOKJCPF PJPMNHONAJJ(int JMAECKMPPBI, int LOPCJMHFMDB, KJMHIFOHDCO NOKPDBFCEIH, int LJKBNMGMPCL, int CNCEINPPNPI, int MGBGDCAPMLG)
		{
			return null;
		}
	}

	private sealed class LIEBNJCMDFI
	{
		public bool BELBMDNMLHN;

		public SquadWarsContentV2 HNNCIECPFEJ;

		internal void LBKKNAMDIPE(UITweener GDPAJADKOPD)
		{
		}
	}

	private sealed class PENMCIPJFCH
	{
		public DatabasePlayer GDMBMAPOKCL;

		internal bool DIFIOCINCEL(DatabasePlayer MNMLHIMCENE)
		{
			return false;
		}
	}

	private sealed class OAGKKMHMHJH
	{
		public DatabasePlayer GDMBMAPOKCL;

		internal bool LANKHKDOHGC(DBKHOLCDPJA KEGGJMBLEPK)
		{
			return false;
		}
	}

	private sealed class POEFNBKCECO
	{
		public DatabasePlayer GDMBMAPOKCL;

		internal bool FJPMPKCLLFO(OGFOCOKJCPF KEGGJMBLEPK)
		{
			return false;
		}
	}

	private sealed class MBKDFFOLNKO
	{
		public DatabasePlayer GDMBMAPOKCL;

		internal bool PGDOECMEDMP(NHOLNKBKJGD EMKIONJKPDK)
		{
			return false;
		}
	}

	[SerializeField]
	private GameObject mNotInSquadPart;

	[SerializeField]
	private UIGrid mNotInSquadButtonGrid;

	[SerializeField]
	private List<UIButtonSetter> mNotInSquadButtonSetters;

	[SerializeField]
	private BoxCollider mJoinSquadCollider;

	[SerializeField]
	private GameObject mSoldierIconPart;

	[SerializeField]
	private GameObject mFirstRewardPart;

	[SerializeField]
	private UILabel mGetRewardLabel;

	[SerializeField]
	private UILabel mRewardValueLabel;

	[SerializeField]
	private GameObject mJoinLockedPart;

	[SerializeField]
	private UILabel mJoinUnlockLabel;

	[SerializeField]
	private UIPanel mJoinInsidePanel;

	[SerializeField]
	private BoxCollider mCreateNewSquadCollider;

	[SerializeField]
	private UISprite mCreateSoldierIconPart;

	[SerializeField]
	private GameObject mCreateFirstRewardPart;

	[SerializeField]
	private UILabel mCreateGetRewardLabel;

	[SerializeField]
	private UILabel mCreateRewardValueLabel;

	[SerializeField]
	private GameObject mCreateLockedPart;

	[SerializeField]
	private UILabel mCreateUnlockLabel;

	[SerializeField]
	private UIPanel mCreateInsidePanel;

	[SerializeField]
	private GameObject mInSquadLowSPPart;

	[SerializeField]
	private UIButton mToMultiplayer;

	[SerializeField]
	private GameObject mInSquadPart;

	[SerializeField]
	private BoxCollider mSquadWarMembersRewardsHint;

	[SerializeField]
	private UISprite mMembersBorder;

	[SerializeField]
	private UISprite mSquadWarMembersRewardsHintBackground;

	[SerializeField]
	private UITable mSquadWarRewardTable;

	[SerializeField]
	private UILabel mSquadPointsCurrent;

	[SerializeField]
	private UILabel mSquadWarMineGoldReward;

	[SerializeField]
	private UILabel mSquadWarMineLpReward;

	[SerializeField]
	private UILabel mYourRewardLabel;

	[SerializeField]
	private UILabel mYourContributionLabel;

	[SerializeField]
	private List<GameObject> mRewardParts;

	[SerializeField]
	private SquadPlayerRecordV2 mSquadPlayerRecordPrefab;

	[SerializeField]
	private UIPooledGrid mMembersGrid;

	[SerializeField]
	private UIPanel mMembersPanel;

	public UIDraggablePanel HENHCADGPLA;

	[SerializeField]
	private GameObject mWaitingMembers;

	[SerializeField]
	private UIPanel mHintSquadWarsRewardsDialogPanel;

	[SerializeField]
	private SquadWarsRewardHintRecord mRewardHintRecordPrefab;

	[SerializeField]
	private UITable mRewardHintTable;

	[SerializeField]
	private UIPanel mSquadsHeaderPanel;

	[SerializeField]
	private UILabel mDivisionLabel;

	[SerializeField]
	private UISprite[] mDivisionBackgrounds;

	[SerializeField]
	private UISprite[] mDivisionArrows;

	[SerializeField]
	private UILabel mSquadWarEndTimerLabel;

	[SerializeField]
	private BoxCollider mSquadWarDivisionsHint;

	[SerializeField]
	private UISprite mSquadWarDivisionsHintSprite;

	[SerializeField]
	private SquadWarsRecordV2 mSquadWarsRecordPrefab;

	[SerializeField]
	private UIPooledGrid mSquadsGrid;

	[SerializeField]
	private UIPanel mSquadsPanel;

	public UIDraggablePanel LNNENAGGGEI;

	[SerializeField]
	private GameObject mWaitingSquads;

	[SerializeField]
	private GameObject mInSquadProcessingPart;

	[SerializeField]
	private GameObject mWaitingForServerPart;

	[SerializeField]
	private GameObject mDebugPart;

	[SerializeField]
	private BoxCollider mDebugScheduleButtonCollider;

	private int JHDBBAJFAJJ;

	private int BFBEBIAOFGJ;

	private int IIPJFAFJGNJ;

	private List<OGFOCOKJCPF> GPHKDHGDLNK;

	private List<DBKHOLCDPJA> DIMBNECOOLC;

	private List<NHOLNKBKJGD> MBCDCFNLEAO;

	private List<DatabasePlayer> GAGEHPADAJP;

	private int PCLNMJNGHCC;

	private int LDJIBHKJHCK;

	private int OFLMCJPMHIG;

	private int OKJABIGPMFJ;

	private int EDJJAMIKMBF;

	private int NCBLAIPDCLO;

	private float GPLIOBPBGDO;

	private float POMPLFONLLO;

	private bool DDLLMKOEOMM;

	private List<SquadWarsRewardHintRecord> DKFCLKMIPCD;

	private float CFINELKCGFL => 0f;

	private KJMHIFOHDCO BBPDBDGCKCH(int BGKHMINPHBM)
	{
		return default(KJMHIFOHDCO);
	}

	public void Animate(bool BELBMDNMLHN, bool BDINJAJINGK)
	{
	}

	private void JILJHIILODB(int MPHCJEIMBEB)
	{
	}

	private void GOEFJDMDBLG(int JPIPAIOGHFE, int LOPCJMHFMDB)
	{
	}

	private void PKADJAIDAOL(int MPHCJEIMBEB, int BGKHMINPHBM)
	{
	}

	private void FIGKFIEHDEE(bool PIBDMDLBLOL)
	{
	}

	private void EOPHNPMPFKD()
	{
	}

	private void NIFAIEMOHEL()
	{
	}

	private int OHPDFOALJAP(List<DatabasePlayer> OBDGJHDDLAM)
	{
		return 0;
	}

	public void InitEvents()
	{
	}

	public void InitControls()
	{
	}

	private void MIHHLNMIBON(DatabaseAction JMAECKMPPBI)
	{
	}

	private void KAPDCFIPNGO()
	{
	}

	private void PLLIKOHMPKD()
	{
	}

	private void MHGKCLFMINM(GameObject LJFDGDIAGIN)
	{
	}

	private void OIMELKCJCPD(GameObject LJFDGDIAGIN)
	{
	}

	private void BBJPLGDGHMP(GameObject LJFDGDIAGIN)
	{
	}

	private void HIGLJIHPGOG(GameObject LJFDGDIAGIN)
	{
	}

	private void MGJGAJNBJLA(GameObject LJFDGDIAGIN)
	{
	}

	private void MEKLBMAPAHH(GameObject LJFDGDIAGIN)
	{
	}

	private void LKPBDIPKPKL()
	{
	}

	private void CNDPFOKEGID()
	{
	}

	private void OIJBOFPJCGO()
	{
	}

	public void InitGUIValues()
	{
	}

	private void Update()
	{
	}

	public void DoAfterHide()
	{
	}

	public void InstantHideTab()
	{
	}

	private void ODONONDFKOI(bool AKPKCDINFKP)
	{
	}

	private void NMGGEFFHMGE()
	{
	}

	private void JCAFMHIJNBC(DBKHOLCDPJA DLJJDBLKPDP)
	{
	}

	private void AOMBEELDAPN(List<DBKHOLCDPJA> CDHMAMECLJJ)
	{
	}

	private void HFGOFDDMLLI(List<DBKHOLCDPJA> CDHMAMECLJJ, int LOPCJMHFMDB)
	{
	}

	private void CKJGHJIFMHP()
	{
	}

	private Transform MPEMFBMFDGO(int EPNGMAHENPA)
	{
		return null;
	}

	private void LALECBOMNGG(Transform KIHIFIBOOIM)
	{
	}

	private void ICPGHELGEBB()
	{
	}

	public List<NHOLNKBKJGD> CreateSquadMembersList(List<DatabasePlayer> HAIDNHPLBMJ, int HNNABNDCFKK, int IEJPOMOKLBK)
	{
		return null;
	}

	private void ELOGEHLLECF()
	{
	}

	private Transform NIFFJKEEELE(int EPNGMAHENPA)
	{
		return null;
	}

	private void KFBEDJLOFEA(Transform KIHIFIBOOIM)
	{
	}

	private void DCEMPPBJMFH()
	{
	}

	private void MCPJMKCEAIN()
	{
	}

	private void MHOHLAHHILD()
	{
	}

	private void DKPHCHJHABB()
	{
	}

	public void ShowSquadWarEndTime(int OGCIEBLIHAB)
	{
	}

	private void FDPFGGFPMCG()
	{
	}

	private void HNGHIAODEOA()
	{
	}

	[CompilerGenerated]
	private void HMGICONLPGO()
	{
	}

	[CompilerGenerated]
	private void CHLHCLOLPPP(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void JFHAPACPLBJ(UITweener GDPAJADKOPD)
	{
	}
}
