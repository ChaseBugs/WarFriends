using System;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class MainScreenSocial : Core_BaseScript
{
	[FormerlySerializedAs("FJELFODJFPM")]
	[Header("Facebook Connect & Invite")]
	public GameObject JLFJFJIOBEK;

	public GameObject EPACMBOLDOP;

	[FormerlySerializedAs("NIEIGEFCLJN")]
	public UITable MELELLPDIPE;

	[FormerlySerializedAs("KGKMNEKFLPI")]
	public UILabel BELMCDBBGOK;

	[FormerlySerializedAs("IGEGFJIMDHK")]
	public GameObject ILJIOFEJIBE;

	[FormerlySerializedAs("mCommanderButton")]
	public GameObject BJANGODGNBL;

	[Header("Grid")]
	public UIGrid OLGLAGDAOJH;

	[Header("-Facebook Like")]
	[FormerlySerializedAs("mCommanderNotifications")]
	public GameObject ILCGBGMBCBJ;

	[FormerlySerializedAs("mCommanderNotificationsNumber")]
	public UILabel KJEAENKAFCG;

	[Header("-Twitter Follow")]
	public GameObject JHACHCFDLKA;

	public UILabel PNNBELBCJAC;

	private void PFAHADHIDGM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-200):
			case (DatabaseAction)(-193):
			case (DatabaseAction)(-93):
			case (DatabaseAction)(-33):
			case (DatabaseAction)(-15):
			case DatabaseAction.IgnoreMessage:
				ABBJLIHPLED();
				break;
			case (DatabaseAction)(-96):
				HEEANEFGCCJ();
				break;
			}
		}
	}

	private void IMGNKCBGJAI()
	{
		InitGUIValues();
	}

	private void BNEMHGHDIHH(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("game-neardeath-indicator");
		}
	}

	private void ELOCECIINIJ(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-34)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-127)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("ExplodeNetwork");
		}
		InitGUIValues();
	}

	public void LGHOOJOAKFI()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += CJJBGFCJOKB;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += GFKMDLNPNHP;
	}

	public void IMEOAPEABLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ILCGBGMBCBJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOGMBNPGCPD));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHACHCFDLKA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GDHJMPOHEND));
		UIEventListener uIEventListener3 = UIEventListener.Get(JLFJFJIOBEK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(OFPEAPBPFKH));
		Tweetmanager.RequestFinish += GDKKBPLKOFM;
		Tweetmanager.TweetFinished += NLFHIKIOBPK;
		Tweetmanager.EEEGFOLKABB(KLIAFCEGLLN);
		PlayerAnalytics.instance.AddedOneTimeReward += HMGLBEHFDMB;
	}

	private void OOIMBPCOENI(string KIHCHGPFOOF)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && KIHCHGPFOOF == Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY)
		{
			InitGUIValues();
		}
	}

	public void HEEANEFGCCJ()
	{
		ABBJLIHPLED();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: true);
			JHACHCFDLKA.SetActive(value: false);
			return;
		}
		ILCGBGMBCBJ.SetActive(PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-97)));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-24)).FLOATVALUE, 1322f);
		JHACHCFDLKA.SetActive(PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-10)));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward7).FLOATVALUE, 655f);
		OLGLAGDAOJH.repositionNow = false;
	}

	private void GPNACGOIOJA(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.HLEMJFBADJE();
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-1)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("Managers");
		}
		InitGUIValues();
	}

	private void GDKKBPLKOFM()
	{
		InitGUIValues();
	}

	private void AHIMDBLCBEL(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-69)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-83)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour(")");
		}
		FACKIKMABGK();
	}

	private void PCMCMOGHANA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-77):
			case (DatabaseAction)(-72):
			case (DatabaseAction)(-62):
			case (DatabaseAction)(-56):
			case DatabaseAction.LeaveSquad:
			case DatabaseAction.GetMissionLeaderboards:
				ABBJLIHPLED();
				break;
			case (DatabaseAction)(-65):
				InitGUIValues();
				break;
			}
		}
	}

	private void LCCNMODEIKN(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.FollowAs();
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("TW_Follow");
		}
		InitGUIValues();
	}

	private void LPLBGPDAPOF(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-174):
			case (DatabaseAction)(-113):
			case (DatabaseAction)(-40):
			case (DatabaseAction)33:
			case (DatabaseAction)51:
			case DatabaseAction.ActivateWeaponUpgrade:
				HFFFJGNBHJE();
				break;
			case (DatabaseAction)(-177):
				FACKIKMABGK();
				break;
			}
		}
	}

	private void MNHMACDPDMJ(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-182):
			case (DatabaseAction)(-118):
			case (DatabaseAction)(-103):
			case DatabaseAction.TutorialEnded:
			case DatabaseAction.ChangeLanguage:
			case DatabaseAction.RemoveGooglePlay:
				GKNEHDNIIPJ();
				break;
			case (DatabaseAction)(-185):
				HHLOGFGGHHD();
				break;
			}
		}
	}

	private void KMOAOCCHENJ()
	{
		EPACMBOLDOP.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		BJANGODGNBL.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-89));
			MELELLPDIPE.gameObject.SetActive(!flag);
			ILJIOFEJIBE.SetActive(flag);
			if (!flag)
			{
				BELMCDBBGOK.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-93)).FLOATVALUE, 835f);
				MELELLPDIPE.repositionNow = true;
			}
		}
	}

	private void PBINCENHCLH(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("was:{0} is:{1} added:{2}");
		}
	}

	private void BEHFIHJKKAI()
	{
		WarningDialog.ShowError(Localization.Localize(", playerWB = "), Localization.Localize("ID_STARTERASSIGNMENTSEXPIRED"), 1800f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private void KLIAFCEGLLN()
	{
		WarningDialog.KHOMNBHMFGA(Localization.Localize("VipReward1"), Localization.Localize("ChangeWeightForDestroyablePartRPC"), 761f, null, string.Empty, JCOGJEEFLBC: true);
	}

	private void MPFMOJOIEIE()
	{
		WarningDialog.ShowError(Localization.Localize("null"), Localization.Localize("ID_CONFIRM_JOININGSQUAD"), 147f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
	}

	private void LEFKFIEDJCB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-155):
			case (DatabaseAction)(-88):
			case (DatabaseAction)(-49):
			case (DatabaseAction)(-44):
			case (DatabaseAction)(-16):
			case (DatabaseAction)(-1):
				GKNEHDNIIPJ();
				break;
			case (DatabaseAction)(-4):
				InitGUIValues();
				break;
			}
		}
	}

	private void GKNEHDNIIPJ()
	{
		EPACMBOLDOP.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		BJANGODGNBL.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.MaxPingToConnectRegion);
			MELELLPDIPE.gameObject.SetActive(!flag);
			ILJIOFEJIBE.SetActive(flag);
			if (!flag)
			{
				BELMCDBBGOK.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-23)).FLOATVALUE, 1259f);
				MELELLPDIPE.repositionNow = true;
			}
		}
	}

	public void OLPGIOCEIGJ()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += CJJBGFCJOKB;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += GFKMDLNPNHP;
	}

	public void FACKIKMABGK()
	{
		JNCLHKKKCDF();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: false);
			JHACHCFDLKA.SetActive(value: true);
			return;
		}
		ILCGBGMBCBJ.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.DogTagRefillTime));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-34)).FLOATVALUE, 1877f);
		JHACHCFDLKA.SetActive(PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalPowerbandDelayMax));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).FLOATVALUE, 395f);
		OLGLAGDAOJH.repositionNow = false;
	}

	private void JCEIMCLJDFJ(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("OOOOPS");
		}
	}

	private void EPKNEGKBFOA(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LapsedPlayerInterval1).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-114)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("Buy_Rental_Army_Unit");
		}
		FACKIKMABGK();
	}

	private void NLFHIKIOBPK()
	{
		HHLOGFGGHHD();
	}

	private void DBMKNFPIMFM(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-113)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-15)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("set schedule gc check 2");
		}
		InitGUIValues();
	}

	private void NKPDBCLOGCL(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-49)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalWeaponCanLockedCount))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("author");
		}
		FACKIKMABGK();
	}

	public void LEMNDNDGIOE()
	{
		ABBJLIHPLED();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: true);
			JHACHCFDLKA.SetActive(value: true);
			return;
		}
		ILCGBGMBCBJ.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-43)));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-62)).FLOATVALUE, 849f);
		JHACHCFDLKA.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalMaxLockedFor));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-31)).FLOATVALUE, 1113f);
		OLGLAGDAOJH.repositionNow = true;
	}

	private void MMIMHFGIHDG(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-40)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-98)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("{0} \"{1}\" for {2}");
		}
		HHLOGFGGHHD();
	}

	private void BNDNGHMACCG(string KIHCHGPFOOF)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && KIHCHGPFOOF == Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WinstreakReward1).DBKEY)
		{
			OEDLHCLCKEO();
		}
	}

	private void NEBDMNHCCGI()
	{
		WarningDialog.JACKIDKHKAI(Localization.Localize(" OK!"), Localization.Localize("Show starter pack: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}"), 1146f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private void PPJFDFKMPAO()
	{
		LEMNDNDGIOE();
	}

	private void ACPFOKDHECE(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("FB_Connect");
		}
	}

	private void EKDBOBHPPEE(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NameChangeReminderGamesAfterFbLogin).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-50)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("menu-weapon-mp5-elite");
		}
		OEDLHCLCKEO();
	}

	public void HKENNEJCGFE()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(MNHMACDPDMJ);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void NICDGBACNBG(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("212 MENU LEVEL UP SHOWN");
		}
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.AddOneTimeReward)
		{
			InitGUIValues();
		}
	}

	private void BLGOKPNHKPO(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.PFGNDFFPHHL();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-16)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalUnitCanLockedCount))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour(" has been disabled as it's not supported on the current platform.");
		}
		LEMNDNDGIOE();
	}

	private void OGPHNFEDANF()
	{
		WarningDialog.ShowError(Localization.Localize("#PETER# removing warcards from slots"), Localization.Localize("ID_CONFIRM_MAXCCUREACHED"), 1516f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private void MKLDBOLLHCF(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.CreateSquadUnlockLevel).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.StartingWarbucks))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("thumbnailLittle");
		}
		FACKIKMABGK();
	}

	private void ABBJLIHPLED()
	{
		EPACMBOLDOP.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		BJANGODGNBL.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.UnitCategoriesReminderAfterGames);
			MELELLPDIPE.gameObject.SetActive(flag);
			ILJIOFEJIBE.SetActive(flag);
			if (!flag)
			{
				BELMCDBBGOK.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WarpathUnlockLevel).FLOATVALUE, 897f);
				MELELLPDIPE.repositionNow = true;
			}
		}
	}

	private void CJJBGFCJOKB(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-120):
			case (DatabaseAction)(-106):
			case (DatabaseAction)(-29):
			case DatabaseAction.ErrorMessage:
			case DatabaseAction.GetPlayerLeaguesDivision:
			case DatabaseAction.CraftCard:
				HFFFJGNBHJE();
				break;
			case (DatabaseAction)(-123):
				LEMNDNDGIOE();
				break;
			}
		}
	}

	public void OEDLHCLCKEO()
	{
		ABBJLIHPLED();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: false);
			JHACHCFDLKA.SetActive(value: false);
			return;
		}
		ILCGBGMBCBJ.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-18)));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE, 206f);
		JHACHCFDLKA.SetActive(PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReminder2After));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-91)).FLOATVALUE, 1421f);
		OLGLAGDAOJH.repositionNow = true;
	}

	private void DHPFHAHHJFC()
	{
		WarningDialog.JACKIDKHKAI(Localization.Localize(", "), Localization.Localize("Beanstalk: Update squad finished"), 1085f, null, string.Empty);
	}

	private void GFKMDLNPNHP(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)(-174))
		{
			FACKIKMABGK();
		}
	}

	public void CBOBIADFILJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ILCGBGMBCBJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AHIMDBLCBEL));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHACHCFDLKA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GDHJMPOHEND));
		UIEventListener uIEventListener3 = UIEventListener.Get(JLFJFJIOBEK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NICDGBACNBG));
		Tweetmanager.OIFBIPCOFHC(GDKKBPLKOFM);
		Tweetmanager.TweetFinished += NLFHIKIOBPK;
		Tweetmanager.HKANHEBEMII(NEBDMNHCCGI);
		PlayerAnalytics.instance.AddedOneTimeReward += OOIMBPCOENI;
	}

	public void AFMPBPGLFMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ILCGBGMBCBJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKCDOBGKOAF));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHACHCFDLKA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KKPLIIEBIFJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(JLFJFJIOBEK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JCEIMCLJDFJ));
		Tweetmanager.OIFBIPCOFHC(PPJFDFKMPAO);
		Tweetmanager.TweetFinished += PPJFDFKMPAO;
		Tweetmanager.AccountSuspended += LCDBBCMLBIJ;
		PlayerAnalytics.instance.AddedOneTimeReward += HMGLBEHFDMB;
	}

	private void KEBJKCIAPFM(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("_BumpMap");
		}
	}

	private void JNCLHKKKCDF()
	{
		EPACMBOLDOP.SetActive(!GameLoginManager.currentPlayer.isFacebookConnected);
		BJANGODGNBL.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
			MELELLPDIPE.gameObject.SetActive(!flag);
			ILJIOFEJIBE.SetActive(flag);
			if (!flag)
			{
				BELMCDBBGOK.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE);
				MELELLPDIPE.repositionNow = true;
			}
		}
	}

	private void DNHBALFHPKB()
	{
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_TWITTERACCOUNTSUSPENDED"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
	}

	public void IKHPOKNAGGN()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(DAMMLMEEMKI);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ILKHHBGEGFK;
	}

	private void HFFFJGNBHJE()
	{
		EPACMBOLDOP.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		BJANGODGNBL.SetActive(GameLoginManager.currentPlayer.isFacebookConnected);
		if (!GameLoginManager.currentPlayer.isFacebookConnected)
		{
			bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.JoinSquadUnlockLevel);
			MELELLPDIPE.gameObject.SetActive(!flag);
			ILJIOFEJIBE.SetActive(flag);
			if (!flag)
			{
				BELMCDBBGOK.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE, 763f);
				MELELLPDIPE.repositionNow = true;
			}
		}
	}

	public void HAOFBOPJBEI()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PFAHADHIDGM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void IMPCJIIDALB()
	{
		WarningDialog.ShowError(Localization.Localize("Gold"), Localization.Localize("Set opponent: "), 1102f, null, string.Empty);
	}

	private void LLIFBFDKEEJ(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("cn");
		}
	}

	private void ECLMNJBKDPN(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.BuyVip)
		{
			OEDLHCLCKEO();
		}
	}

	private void KKPLIIEBIFJ(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.HLEMJFBADJE();
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-9)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("MapDefinition");
		}
		LEMNDNDGIOE();
	}

	public void HHLOGFGGHHD()
	{
		JNCLHKKKCDF();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: false);
			JHACHCFDLKA.SetActive(value: true);
			return;
		}
		ILCGBGMBCBJ.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-9)));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ShieldRepairTime).FLOATVALUE, 720f);
		JHACHCFDLKA.SetActive(PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.WinstreakReward8));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcaseAdInterval).FLOATVALUE, 832f);
		OLGLAGDAOJH.repositionNow = false;
	}

	public void InitGUIValues()
	{
		JNCLHKKKCDF();
		if (LevelManager.instance.isMainScreenPartsLocked)
		{
			ILCGBGMBCBJ.SetActive(value: false);
			JHACHCFDLKA.SetActive(value: false);
			return;
		}
		ILCGBGMBCBJ.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLike));
		KJEAENKAFCG.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).FLOATVALUE);
		JHACHCFDLKA.SetActive(!PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow));
		PNNBELBCJAC.text = MEJMLNDFDBP.AKEMDPDJPLH(Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).FLOATVALUE);
		OLGLAGDAOJH.repositionNow = true;
	}

	private void OFPEAPBPFKH(GameObject KHAHPAKDIKE)
	{
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			GameLoginManager.instance.InviteFacebookFriends();
			return;
		}
		GameLoginManager.instance.LoginToFacebook();
		if (GameLoginManager.currentPlayer.isFacebookConnected)
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("gold");
		}
	}

	private void IKCDOBGKOAF(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.COILLNKKJPK();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-83)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-52)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("run_grenadelauncher");
		}
		OEDLHCLCKEO();
	}

	private void ILKHHBGEGFK(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == (DatabaseAction)(-141))
		{
			InitGUIValues();
		}
	}

	public void HJFAACLIGMF()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(CJJBGFCJOKB);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void DBJHEBKEOJB(string KIHCHGPFOOF)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && KIHCHGPFOOF == Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NameChangeReminderGamesAfterFbLogin).DBKEY)
		{
			HEEANEFGCCJ();
		}
	}

	private void LCDBBCMLBIJ()
	{
		WarningDialog.ShowError(Localization.Localize("QUIT"), Localization.Localize("ArenaWins"), 1460f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
	}

	public void CEOBPADJPIA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ILCGBGMBCBJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ACMIIBKGGNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHACHCFDLKA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCCNMODEIKN));
		UIEventListener uIEventListener3 = UIEventListener.Get(JLFJFJIOBEK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KEBJKCIAPFM));
		Tweetmanager.RequestFinish += NLFHIKIOBPK;
		Tweetmanager.TweetFinished += IMGNKCBGJAI;
		Tweetmanager.AccountSuspended += NEBDMNHCCGI;
		PlayerAnalytics.instance.AddedOneTimeReward += HMGLBEHFDMB;
	}

	private void AKDHJPAMJIK(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_VIPRewardChance).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-64)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("Level");
		}
		InitGUIValues();
	}

	public void MEDHOPJLNHI()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LEFKFIEDJCB;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void BIBGNICCFOO()
	{
		WarningDialog.JACKIDKHKAI(Localization.Localize("Squad"), Localization.Localize("HeroicPoints"), 1408f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
	}

	private void FOGMBNPGCPD(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipWarbucksMultiplier).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-95)))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour(".");
		}
		InitGUIValues();
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.CreateGcAccount:
			case DatabaseAction.RemoveFacebook:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				JNCLHKKKCDF();
				break;
			case DatabaseAction.AddOneTimeReward:
				InitGUIValues();
				break;
			}
		}
	}

	private void GDHJMPOHEND(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.OHMHGLFNNPJ();
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.PlayerExplosiveCoef))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("nonEliteUnits");
		}
		OEDLHCLCKEO();
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
	}

	private void PKCKNNGNJHD()
	{
		WarningDialog.ShowError(Localization.Localize("ID_PROMOTETODIVISION"), Localization.Localize("Selected new room MAP id is: "), 1288f, null, string.Empty);
	}

	private void HMGLBEHFDMB(string KIHCHGPFOOF)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && KIHCHGPFOOF == Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DogTagCap).DBKEY)
		{
			LEMNDNDGIOE();
		}
	}

	public void FPOJNMDAPOD()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LEFKFIEDJCB;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ILKHHBGEGFK;
	}

	public void PBKJDKFPILH()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void ACMIIBKGGNL(GameObject KHAHPAKDIKE)
	{
		Singleton<Tweetmanager>.instance.likeUsOnFacebook();
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLike).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		if (PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLike))
		{
			Singleton<EventTrackingManager>.instance.RegisterSocialBehaviour("FB_Like");
		}
		InitGUIValues();
	}

	public void CNOBMACDINH()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LPLBGPDAPOF;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += ECLMNJBKDPN;
	}

	private void GLGKGEJKAJP()
	{
		HHLOGFGGHHD();
	}

	private void DAMMLMEEMKI(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-198):
			case (DatabaseAction)(-197):
			case (DatabaseAction)(-28):
			case (DatabaseAction)(-12):
			case DatabaseAction.GetAllPlayers:
			case DatabaseAction.ChangeNameAndPassword:
				HFFFJGNBHJE();
				break;
			case (DatabaseAction)(-200):
				OEDLHCLCKEO();
				break;
			}
		}
	}

	private void MBBMOAIBAFD(string KIHCHGPFOOF)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && KIHCHGPFOOF == Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-46)).DBKEY)
		{
			InitGUIValues();
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ILCGBGMBCBJ.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ACMIIBKGGNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHACHCFDLKA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCCNMODEIKN));
		UIEventListener uIEventListener3 = UIEventListener.Get(JLFJFJIOBEK);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ACPFOKDHECE));
		Tweetmanager.RequestFinish += IMGNKCBGJAI;
		Tweetmanager.TweetFinished += IMGNKCBGJAI;
		Tweetmanager.AccountSuspended += DNHBALFHPKB;
		PlayerAnalytics.instance.AddedOneTimeReward += OOIMBPCOENI;
	}

	private void CLCLGOHFIBB()
	{
		WarningDialog.ShowError(Localization.Localize("Decal_Type"), Localization.Localize("http://www.about-fun.com/warfriends-mobcrush"), 713f, null, string.Empty, JCOGJEEFLBC: true);
	}

	public void AOJLEKOMJOH()
	{
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(DAMMLMEEMKI);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += GFKMDLNPNHP;
	}
}
