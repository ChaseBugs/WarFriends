using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SelectFriendsFacebookTab : Core_BaseScript
{
	private enum EFJEKJCFIOI
	{
		ConnectToFacebook,
		ReconnectToFacebook,
		WaitingForServerData,
		NoFacebookFriends,
		FacebookList
	}

	private sealed class LPCCDKKPDGH : IEnumerator<object>, IEnumerator, IDisposable
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
		public LPCCDKKPDGH(int HEIHBBOBLGF)
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
	private GameObject mFacebookPart;

	[SerializeField]
	private GameObject mFacebookLoginButton;

	[SerializeField]
	private UITable mFacebookRewardTable;

	[SerializeField]
	private UILabel mFacebookRewardNumber;

	[SerializeField]
	private UILabel mFacebookRewardClaimed;

	[SerializeField]
	private UILabel mFacebookHintLabel;

	[SerializeField]
	private UILabel mFacebookButtonText;

	[SerializeField]
	private GameObject mEmptyFacebookPart;

	[SerializeField]
	private GameObject mEmptyFacebookButton;

	[SerializeField]
	private UILabel mEmptyFacebookLabel;

	[SerializeField]
	private GameObject mFacebookResultsPart;

	[SerializeField]
	private UIPooledGrid mFacebookGrid;

	[SerializeField]
	private FriendGuiRecord mFriendGuiRecordPrefab;

	[SerializeField]
	private UIDraggablePanel mScrollview;

	[SerializeField]
	private UIPanel mScrollviewPanel;

	[SerializeField]
	private GameObject mWaitingPart;

	private RadicalRoutine NCFFCIJNHKP;

	private List<GDFHGNLOPDG> HGGGKIBIIFI;

	private EFJEKJCFIOI MCEKELLGGPB => default(EFJEKJCFIOI);

	public void SetScrolling(bool EAHEABFKNDC)
	{
	}

	public void InitControls()
	{
	}

	private void IJFGGGEKIAH()
	{
	}

	private void JNNJBHCCAAJ(GameObject LJFDGDIAGIN)
	{
	}

	private void INELMLCLKDD()
	{
	}

	public void InitGuiValues()
	{
	}

	public void DoAfterHide()
	{
	}

	private Transform OKOGCBCKBPL(int EPNGMAHENPA)
	{
		return null;
	}

	private void OBJLOHNMAKI(Transform NDJLKGIHCLF)
	{
	}

	private void ECDCJGFEECN()
	{
	}

	private void BDMHGJHIKEA()
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
