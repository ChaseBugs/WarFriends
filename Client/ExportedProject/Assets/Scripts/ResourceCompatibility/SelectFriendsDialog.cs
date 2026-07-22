using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SelectFriendsDialog : GuiElementSingle<SelectFriendsDialog>, DKLFANCEFML
{
	public enum INJMKCHAKFB
	{
		COOP,
		INVITE,
		FIGHT
	}

	private enum CPFKDBBDAPG
	{
		Facebook,
		Squad,
		Search,
		Commander
	}

	private sealed class HHIBAOECDAP
	{
		public SelectFriendsDialog EJOPIJNPCGG;

		public Action<DatabasePlayer, bool> OGGCFPIGJGK;

		public UIDraggablePanel ICKPAEEPOBH;

		internal void IDHBNHHALGL()
		{
		}
	}

	private sealed class LNCLINBBMKP
	{
		public SelectFriendsDialog EJOPIJNPCGG;

		public Action<DatabasePlayer, bool> OGGCFPIGJGK;

		public string LNMEJDEHBAC;

		internal void GDNCGLPPDBN()
		{
		}
	}

	private sealed class IGIACCIFNGN
	{
		public SelectFriendsDialog EJOPIJNPCGG;

		public Action<DatabasePlayer, bool> OGGCFPIGJGK;

		internal void BDLELBLJKAK()
		{
		}
	}

	private sealed class IMMJJCFLDMG
	{
		public GameObject LJFDGDIAGIN;

		internal bool EBIKIEKEHPL(SelectFriendsButton OEKEOADHEOB)
		{
			return false;
		}
	}

	public Action<DatabasePlayer, bool> JCIDAHIKNMN;

	[SerializeField]
	private GameObject mCloseButton;

	[SerializeField]
	private UILabel mTitleLabel;

	[SerializeField]
	private GameObject mCoopIcon;

	[SerializeField]
	private GameObject mInviteIcon;

	[SerializeField]
	private GameObject mFightIcon;

	[SerializeField]
	private GameObject mSettingsPart;

	[SerializeField]
	private GameObject mButtonPart;

	[SerializeField]
	private UILabel mLeftLabel;

	[SerializeField]
	private UILabel mRightLabel;

	[SerializeField]
	private EqualSettingsSwitch mSettingsSwitch;

	[SerializeField]
	private GameObject mHintButton;

	[SerializeField]
	private UISprite mHintButtonSprite;

	[SerializeField]
	private UIPanel mDialogPanel;

	[SerializeField]
	private BoxCollider mDialogCollider;

	[SerializeField]
	private GameObject mHeaderButtonsPart;

	[SerializeField]
	private List<SelectFriendsButton> mHeaderButtons;

	[SerializeField]
	private SelectFriendsFacebookTab mFacebookTab;

	[SerializeField]
	private SelectFriendsSquadTab mSquadTab;

	[SerializeField]
	private SelectFriendsSearchTab mSearchTab;

	[SerializeField]
	private SelectFriendsCommanderTab mCommanderTab;

	[CompilerGenerated]
	private INJMKCHAKFB _003CFHCPKKHNPBL_003Ek__BackingField;

	[CompilerGenerated]
	private UIDraggablePanel _003CMOOHEOCALBC_003Ek__BackingField;

	private CPFKDBBDAPG PPIFBHPJNMK;

	private List<string> LFFEPPOPNNC;

	private bool FAHNJBCIMNG;

	public INJMKCHAKFB currentType
	{
		[CompilerGenerated]
		get
		{
			return default(INJMKCHAKFB);
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public UIDraggablePanel panelToDisable
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public static void ShowSquadInviteDialog(Action<DatabasePlayer, bool> OGGCFPIGJGK, UIDraggablePanel ICKPAEEPOBH, float PCCJGICLAEL)
	{
	}

	public static void ShowCoopDialog(Action<DatabasePlayer, bool> OGGCFPIGJGK, float PCCJGICLAEL, string LNMEJDEHBAC)
	{
	}

	public static void ShowFightFriendsDialog(Action<DatabasePlayer, bool> OGGCFPIGJGK, float PCCJGICLAEL)
	{
	}

	public void SetScrolling(bool EAHEABFKNDC)
	{
	}

	public override void InitControls()
	{
	}

	private void BBFFHABDKPC(GameObject LJFDGDIAGIN)
	{
	}

	private void PCOJNCDILOM(GameObject LJFDGDIAGIN)
	{
	}

	private void DCMDENJANLA(GameObject LJFDGDIAGIN)
	{
	}

	private void ADGEJMLMIDB(GameObject LJFDGDIAGIN)
	{
	}

	private void KHLOEEKCBML(GameObject LJFDGDIAGIN)
	{
	}

	private void ICMNKLDCNBH(GameObject LJFDGDIAGIN)
	{
	}

	public override void InitGUIValues()
	{
	}

	private void PBMPFJJGDHL()
	{
	}

	public override void DoBeforeShowUp()
	{
	}

	public override void DoAfterShowUp()
	{
	}

	public override void DoBeforeHide()
	{
	}

	public override void DoAfterHide()
	{
	}

	public void Select(DatabasePlayer GDMBMAPOKCL)
	{
	}

	private void FDJPCBFCJJF(INJMKCHAKFB JFACCKJNHHC)
	{
	}

	private void JKJIPDHHEJI(string ECIJDHLNIJO)
	{
	}

	public bool WasPlayerInvited(DatabasePlayer GDMBMAPOKCL)
	{
		return false;
	}

	private void GJBCBMOKBAA()
	{
	}

	private void FKFDOMPBDHO()
	{
	}

	private void MGAGFFOBNML()
	{
	}

	public GuiElement GetGuiElement()
	{
		return null;
	}

	public override void OnBack()
	{
	}

	[CompilerGenerated]
	private void NCIGCCGBGBN(UITweener GDPAJADKOPD)
	{
	}
}
