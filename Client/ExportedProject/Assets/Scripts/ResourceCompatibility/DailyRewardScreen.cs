using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyRewardScreen : GuiScreenSingle<DailyRewardScreen>
{
	private sealed class BDKGJLOEHKM : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public DailyRewardScreen HNNCIECPFEJ;

		private bool NAAMAEFGGFM;

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
		public BDKGJLOEHKM(int HEIHBBOBLGF)
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
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UILabel mSubtitle;

	[SerializeField]
	private UISprite mLine;

	[SerializeField]
	private UIDraggablePanel mDraggablePanel;

	[SerializeField]
	private UIPanel mScrollPanel;

	[SerializeField]
	private UIPooledGrid mGrid;

	[SerializeField]
	private DailyRewardButton mRewardButtonPrefab;

	[SerializeField]
	private UITexture mSoldierTexture;

	[SerializeField]
	private BoxCollider mClaimButtonColider;

	[SerializeField]
	private TweenPosition mClaimButtonTweener;

	[SerializeField]
	private UILabel mClaimButtonText;

	[SerializeField]
	private GameObject mClaimButtonHighlight;

	[SerializeField]
	private UISprite mClaimButtonBackground;

	[SerializeField]
	private CardMenuOwerlay mWarcardOverlay;

	[SerializeField]
	private GameObject mChangeDateDebugContent;

	[SerializeField]
	private UIInput mChangeDayInput;

	[SerializeField]
	private GameObject mChangeDateButton;

	[SerializeField]
	private GameObject mTodayClaimedButton;

	[SerializeField]
	private GameObject mTodayClaimed;

	private List<GameReward> NGDIINPNMNC;

	private int BOBEBMACKAP;

	private RadicalRoutine KDMIPKCIBGK;

	private int DAHNOIODNGF;

	private DailyRewardButton LNMPCNLHIJJ;

	private float DKCAJAPDGMF;

	private bool GKHAMDJDLHA;

	public void SelectReward(DailyRewardButton ANDBILGLPBC)
	{
	}

	protected override void LKNLBIMDMAD()
	{
	}

	private void CJEPNMEFEEG(GameObject LJFDGDIAGIN)
	{
	}

	private void MHMAFEJBOIB(GameObject LJFDGDIAGIN)
	{
	}

	private void PNBNLAMJPCD()
	{
	}

	private void FOINKOKLGDD()
	{
	}

	public override void InitGUIValues()
	{
	}

	public override void AnimateShow(bool JFAMAODFFPG)
	{
	}

	public override void DoBeforeShowUp()
	{
	}

	public override void DoAfterHide()
	{
	}

	private Transform BANKFMDHKLD(int EPNGMAHENPA)
	{
		return null;
	}

	private void CJPLCOIPDPC(Transform KIHIFIBOOIM)
	{
	}

	private void CKCOADCFIIB()
	{
	}

	private void HACHKPEJJKD()
	{
	}

	private void JCGPIHDLIIO()
	{
	}

	private IEnumerator PAGACIHENGI()
	{
		return null;
	}

	private void KNALIJHDCDA()
	{
	}

	private void MDOPHAMGAKA(UITweener HKJICEAAGPA)
	{
	}

	private void NIDHFHNHHIC()
	{
	}

	private void PKEAKCMGGBE()
	{
	}

	private void CJPPFDENCLL(string BALEOFOKIOC)
	{
	}

	public void ShowCards(string[] JNLJKJONLNA, int MGMIJPLPHLN)
	{
	}

	private void CNDPFOKEGID()
	{
	}

	[CompilerGenerated]
	private void JKFIKKJKMJL(bool NAMHCGOEHOK)
	{
	}
}
