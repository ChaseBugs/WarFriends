using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SelectFriendsSquadTab : Core_BaseScript
{
	private enum NIPOLPGEEKG
	{
		NotInSquad,
		WaitingForServerData,
		NoSquadMates,
		SquadList
	}

	private sealed class MKDLLCOCCOG : IEnumerator<object>, IEnumerator, IDisposable
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
		public MKDLLCOCCOG(int HEIHBBOBLGF)
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
	private GameObject mSquadPart;

	[SerializeField]
	private BoxCollider mJoinSquadButtonCollider;

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
	private BoxCollider mCreateSquadButtonCollider;

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
	private GameObject mEmptySquadPart;

	[SerializeField]
	private GameObject mEmptySquadButton;

	[SerializeField]
	private UILabel mEmptySquadLabel;

	[SerializeField]
	private GameObject mSquadResultsPart;

	[SerializeField]
	private UIPooledGrid mSquadGrid;

	[SerializeField]
	private FriendGuiRecord mFriendGuiRecordPrefab;

	[SerializeField]
	private UIDraggablePanel mScrollview;

	[SerializeField]
	private UIPanel mScrollviewPanel;

	[SerializeField]
	private GameObject mWaitingPart;

	private RadicalRoutine NCFFCIJNHKP;

	private List<DatabasePlayer> GNKEJDHGDKC;

	private bool NJGFCPIJKNH;

	private NIPOLPGEEKG MCEKELLGGPB => default(NIPOLPGEEKG);

	public void SetScrolling(bool EAHEABFKNDC)
	{
	}

	public void InitControls()
	{
	}

	private void IJFGGGEKIAH()
	{
	}

	private void OGKMKHLNKHD(GameObject LJFDGDIAGIN)
	{
	}

	private void MHGKCLFMINM(GameObject LJFDGDIAGIN)
	{
	}

	private void OIMELKCJCPD(GameObject LJFDGDIAGIN)
	{
	}

	public void InitGuiValues()
	{
	}

	public void DoAfterShowUp()
	{
	}

	public void DoAfterHide()
	{
	}

	private void FKEAFEKAFEE()
	{
	}

	private void MFAIGDGKIBN()
	{
	}

	private void AIMCJEBAPHB()
	{
	}

	private void ECDCJGFEECN()
	{
	}

	private Transform HAKPPAAKGHA(int EPNGMAHENPA)
	{
		return null;
	}

	private void FOACFGLKFMM(Transform KIHIFIBOOIM)
	{
	}

	private void BLKOMKKEHCM()
	{
	}

	private void ENACPDLOHMD()
	{
	}

	private IEnumerator NMGCNMDLKEJ()
	{
		return null;
	}

	public void SetDialogTo(SelectFriendsDialog.INJMKCHAKFB JFACCKJNHHC)
	{
	}
}
