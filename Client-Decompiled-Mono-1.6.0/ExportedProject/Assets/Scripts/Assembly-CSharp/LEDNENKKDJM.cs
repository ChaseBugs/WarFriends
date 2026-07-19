using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class LEDNENKKDJM
{
	private sealed class JHOGFIPAAJH
	{
		internal DatabaseAction IFGAGNBDKBE;
	}

	private sealed class PADJFKLJGHH
	{
		internal string PIIIKJJHJPN;

		internal JHOGFIPAAJH AIHDNGDNDHH;

		internal void CIFEDFPPPOK(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("QUITTER");
				LoadingDialog.ShowLoading(Localization.Localize("AddCoopScoreRPC"), false, false, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN);
				return;
			}
			Debug.Log("{0}{1}{2} {3}{4}");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("0"), true, true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void ENOBKGECBGB()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.EquipWeapon)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void MCFGAFBEJDK(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("ID_GUI_REPORTABUSE_LISTITEM5");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("menu-army-ammo-ico"), false, true, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("ID_STARTERASSIGNMENT");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.ClearAllMessages();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.FDBHFJFKALH(Localization.Localize("setEmailCollection"), true, true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void BDCAFHOHEGM(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("LevelExperience");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("special"), false, false, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("#PETER# Animating league arc {0}    from:\"{1}\"  to:\"{2}\"");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.ClearAllMessages();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.ShowLoading(Localization.Localize("Level"), true, true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.InteruptStartingTutorial();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void KJIFNOJILDB(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("/");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("ID_RANDOMWARCARDS"), true, false, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("isConnectionCallbacksRegistered");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("Weapon_ID"));
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			Singleton<GameController>.instance.PGCANLPKKOL();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void IFOPOPPMCFG()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.RemoveGooglePlay)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void LJCDGJKCNEC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("Error Handler: Player si vybral zruseni GC uctu a pridani udaju k tomuto uctu");
				LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("Error Handler: Player si vybral starsi account!");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.ClearAllMessages();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.InteruptStartingTutorial();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void NCIAEPGIOIE()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.BuyUnitUpgrade)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void KBBDIDNKLFN()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)155)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void ILGOBENABHC()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-63))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void EJLGBICBIFK()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.TutorialCheckFBAccount)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void JLMDEGBHOGA()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.GenerateSpecialOffer)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void OMNNEIFECNE()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.GetMissionLeaderboards)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void PKCBGEEBOMA()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == DatabaseAction.JoinSquadRequest)
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void HADLONLCLPM()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-133))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void FHDOHCJJEMM(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("ID_DELIVEREDTIME");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("percent"), false, true, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log(".");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.ClearAllMessages();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.ShowLoading(Localization.Localize("ЗАГРУЗИТЬ"), true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void CBIEBLNLGLB()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-34))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void GMFJFMHNDMC(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("PlayerLeagueProcessing");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("Leaderboard removed succesfully"), true, false, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("ID_CONFIRM_ERROR");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.ClearAllMessages();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.FDBHFJFKALH(Localization.Localize("Grenade_Throwing_Tutorial_Duration"), true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void PEOKGFIGIGH()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-71))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void NAJNECOMDDN(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("ShootAdditive");
				LoadingDialog.PGFBMJFLHPC(Localization.Localize("ID_ARENAWINSREWARDS"));
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("ID_NEWUNIT");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.ShowLoading(Localization.Localize("TotalAmmo"), true, true, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void BMCMDMKGHHO(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("PlayerInventory: Init");
				LoadingDialog.ShowLoading(Localization.Localize("menu-warbucks"), true, true, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN, true);
				return;
			}
			Debug.Log("#,0.#");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.FDBHFJFKALH(Localization.Localize("WarShop"), false, false, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			Singleton<GameController>.instance.FAFIFKHDPKN();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void MPHECHCFCAN(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Debug.Log("RequestBuffer ");
				LoadingDialog.FDBHFJFKALH(Localization.Localize("ДА"), false, true);
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.HBCBKAPGJKG(PIIIKJJHJPN);
				return;
			}
			Debug.Log("jp");
			DialogManager.instance.HideAllDialogs();
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("Grenade_Throwing_Tutorial_Duration"), true, false, true);
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			Singleton<GameController>.instance.PGCANLPKKOL();
			Singleton<BeanstalkServerManager>.instance.CreateGcAccount(PIIIKJJHJPN);
		}

		internal void KCOGEFBNDKA()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-153))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void LEDJMCDANFJ()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-76))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}

		internal void CJPMPGPKIFJ()
		{
			if (AIHDNGDNDHH.IFGAGNBDKBE == (DatabaseAction)(-98))
			{
				GameLoginManager.instance.OnFacebookPlatformErrorDuringTutorial();
			}
		}
	}

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action CCNLMGEJBIB;

	[CompilerGenerated]
	private static Action KBAICANEKOP;

	[CompilerGenerated]
	private static Action AOPBBLDIOCI;

	[CompilerGenerated]
	private static Action GGDOCGDGEDJ;

	[CompilerGenerated]
	private static Action GHMJMKLOPJK;

	[CompilerGenerated]
	private static Action ODJCCLLMIBO;

	[CompilerGenerated]
	private static Action IEPCBHLLNIP;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> OHFLEJJHBPJ;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> CPAMMJBHAEF;

	[CompilerGenerated]
	private static Action AINCBCEGBKN;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> EPOEJFEBIIL;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> NLIPFGNJCCI;

	private static void LEBLHNDFNEK()
	{
		GameLoginManager.Relog(false);
	}

	private static void HJGDBDPLICN()
	{
		GameLoginManager.Relog(false);
	}

	[CompilerGenerated]
	private static void EIIGGCKMFIB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Delete QuickPlay Data");
		GameLoginManager.instance.DeletePlayerAccount();
		GameLoginManager.Relog();
	}

	private static void CLPBLODICMD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("#AccoutCheck# Facebook accoun found - invalid ID");
		GameLoginManager.Relog(false);
	}

	private static void LOLHPMKHCBF()
	{
		GameLoginManager.Relog();
	}

	public static string NPFMGCJFIFA()
	{
		return "Tutorial_Step_Complete";
	}

	[CompilerGenerated]
	private static void IAOMDHPHOEM()
	{
		GameLoginManager.Relog();
	}

	public static string OFGEOGNDLLD()
	{
		return "ID_TOBENUMBERONE1";
	}

	private static void NBDELBDJOBI()
	{
		GameLoginManager.Relog(false);
	}

	private static void CBLOHMGLFNL()
	{
		GameLoginManager.Relog(false);
	}

	internal void PAIDOPMKBPC(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG, DatabaseAction IFGAGNBDKBE, List<Tuple<string, string>> GMDJHENPLHB)
	{
		JHOGFIPAAJH jHOGFIPAAJH = new JHOGFIPAAJH();
		jHOGFIPAAJH.IFGAGNBDKBE = IFGAGNBDKBE;
		DialogManager.instance.HideAllDialogs();
		if (CDLPMHEODBN != (IJEAJGCCHEF)(-123))
		{
			LoadingDialog.Hide();
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE == (DatabaseAction)0 && Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.WaitingForResponse && CDLPMHEODBN != 0)
		{
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
			return;
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.LeagueLeaderboardShown)
		{
			if (jHOGFIPAAJH.IFGAGNBDKBE != (DatabaseAction)(-73))
			{
				if (jHOGFIPAAJH.IFGAGNBDKBE != (DatabaseAction)(-87))
				{
					if (jHOGFIPAAJH.IFGAGNBDKBE == DatabaseAction.GameStartedCoopClient)
					{
						MHEHGPLIFHF.PBFNJOLIEOO(CDLPMHEODBN, EENKJBCCPBG);
					}
				}
				else
				{
					MIFGKEHBPOK.DAJCCCBFDFG(CDLPMHEODBN, EENKJBCCPBG);
				}
			}
			else
			{
				JOPIPCDHOLF.PHKNCEEHBPP(CDLPMHEODBN, EENKJBCCPBG);
			}
		}
		else
		{
			DIENNAGJJOM.KNCMJDBHMFB(CDLPMHEODBN, EENKJBCCPBG);
		}
		PADJFKLJGHH pADJFKLJGHH = new PADJFKLJGHH();
		pADJFKLJGHH.AIHDNGDNDHH = jHOGFIPAAJH;
		switch (CDLPMHEODBN)
		{
		default:
			if (CDLPMHEODBN != (IJEAJGCCHEF)(-58))
			{
				if (CDLPMHEODBN != (IJEAJGCCHEF)20)
				{
					if (CDLPMHEODBN != (IJEAJGCCHEF)(-43))
					{
						if (CDLPMHEODBN != (IJEAJGCCHEF)(-190))
						{
							if (CDLPMHEODBN != (IJEAJGCCHEF)122)
							{
								if (CDLPMHEODBN != (IJEAJGCCHEF)(-126))
								{
									if (CDLPMHEODBN != (IJEAJGCCHEF)(-116) && CDLPMHEODBN != (IJEAJGCCHEF)(-160))
									{
										if (CDLPMHEODBN == (IJEAJGCCHEF)(-104))
										{
											Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
											ConfirmDialog.IGGCEILJEFM(JAIPDGFDJCB, Localization.Localize("Hidding "), Localization.Localize("ID_FEATURE_SHOTSPEED-DESCRIPTION"));
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)159)
										{
											ConfirmDialog.KDAEFLFPBMN(Localization.Localize("Client is newer, configs stored for: {0} and new version is {1} init sheet config {2}, current bundle version {3}"), Localization.Localize("Gold"), 1563f);
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)(-184) || CDLPMHEODBN == (IJEAJGCCHEF)171)
										{
											LoadingDialog.Hide();
											WarningDialog.ShowError(Localization.Localize("null"), Localization.Localize("{0} -> {1}"), 380f, null, string.Empty, true);
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)72)
										{
											WarningDialog.JACKIDKHKAI(Localization.Localize("ID_CONFIRM_ERROR"), Localization.Localize("Updated Player League And Medals to BeginnersLeague:{0} NormalLeague:{1} GlobalMedals:{2} LeagueMedals:{3} RemainingMatches:{4}"), 1528f, null, string.Empty, false, true);
											if (EENKJBCCPBG.ContainsKey("(Lcom/google/android/gms/common/api/GoogleApiClient;)Ljava/lang/String;"))
											{
												Dictionary<string, string> depositedCards = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Days_Since_Install"], string.Empty));
												GameLoginManager.instance.SetDepositedCards(depositedCards);
											}
											CardCraftingManager.instance.SetWaitingForServerResponse(false);
											CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["duplicate WB "], string.Empty));
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)137)
										{
											Debug.LogError(" TOTAL RESERVED: " + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Card_2_Played"], string.Empty));
											WarningDialog.KHOMNBHMFGA(Localization.Localize("StatisticsData"), Localization.Localize("ID_ZEROSECONDS"), 1888f, null, string.Empty);
											Dictionary<string, object> depositedCards2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Chat: Trying to get messages from null or empty channelName"], string.Empty));
											GameLoginManager.instance.SetDepositedCards(depositedCards2);
											CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["C3"], string.Empty));
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)(-175))
										{
											ConfirmDialog.CKGMDJFKNPO(Localization.Localize("groundBoxHit"), Localization.Localize("DEVELOPER_ERROR"), 1823f);
											Dictionary<string, object> depositedCards3 = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["WithdrewWarcard-{0}-{1}-{2}"], string.Empty));
											GameLoginManager.instance.SetDepositedCards(depositedCards3);
											CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_PURCHASED"], string.Empty));
											break;
										}
										if (CDLPMHEODBN == (IJEAJGCCHEF)(-195))
										{
											WarningDialog.ShowError(Localization.Localize("Donate_Card"), Localization.Localize("ERROR FROM SERVER "), 997f, null, string.Empty, true, true);
											CardManager.instance.nextWithdraw = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["com/google/android/gms/common/ConnectionResult"]);
											break;
										}
										if (CDLPMHEODBN != (IJEAJGCCHEF)(-66))
										{
											if (CDLPMHEODBN != (IJEAJGCCHEF)(-181))
											{
												if (CDLPMHEODBN != (IJEAJGCCHEF)94)
												{
													if (CDLPMHEODBN != (IJEAJGCCHEF)(-36))
													{
														switch (CDLPMHEODBN)
														{
														case (IJEAJGCCHEF)(-80):
															Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
															Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
															LoadingDialog.ShowLoading(Localization.Localize("shield_idle"), true, false, true);
															WarningDialog.ShowError(Localization.Localize("/ {0}{1}"), Localization.Localize("ID_VISUALCATEGORY1"), 1276f, BDIKIDFCDKO, Localization.Localize("ID_TUTORIAL_PROGRESS_KILLING2"), true);
															return;
														case (IJEAJGCCHEF)68:
															WarningDialog.ShowError(Localization.Localize("dogtag"), Localization.Localize("LevelName"), 622f, null, string.Empty, false, true);
															return;
														case (IJEAJGCCHEF)71:
															WarningDialog.ShowError(Localization.Localize(". "), Localization.Localize("ID_ARENARULES_DOUBLEAMMO"), 1950f, null, string.Empty, true);
															return;
														case (IJEAJGCCHEF)(-196):
															WarningDialog.JACKIDKHKAI(Localization.Localize("Arena Wins: "), Localization.Localize("\\D*"), 900f, pADJFKLJGHH.IFOPOPPMCFG, string.Empty, true, true);
															GameLoginManager.instance.LogoutFromFacebook(true);
															if (EENKJBCCPBG.ContainsKey("percent"))
															{
																Debug.LogError("{0} {1}" + EENKJBCCPBG["Server response: "]);
															}
															return;
														}
														switch (CDLPMHEODBN)
														{
														default:
															return;
														case (IJEAJGCCHEF)(-60):
															Debug.LogError("ID_STARTERASSIGNMENT");
															WarningDialog.JACKIDKHKAI(Localization.Localize("N"), Localization.Localize("BoughtIndex"), 137f, null, string.Empty);
															CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_CONFIRM_SQUADFULL"], string.Empty));
															return;
														case (IJEAJGCCHEF)(-26):
															Debug.LogError("Database Message does not contain id or type:\n");
															WarningDialog.ShowError(Localization.Localize(" NOT OK!\t\t\t\t\t\t"), Localization.Localize("groundBoxHit"), 1150f, null, string.Empty, true);
															CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["vipId"], string.Empty));
															return;
														case (IJEAJGCCHEF)(-145):
															Debug.Log("shotgun_reload" + jHOGFIPAAJH.IFGAGNBDKBE);
															Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(true);
															return;
														case (IJEAJGCCHEF)18:
															Debug.LogError("seconds" + jHOGFIPAAJH.IFGAGNBDKBE);
															WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_ASSIGNMENTHINTWARPATH"), Localization.Localize("GoldDeducted"), 627f, null, string.Empty, false, true);
															AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["G1"], string.Empty));
															return;
														case (IJEAJGCCHEF)(-189):
															Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
															Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
															GameLoginManager.Relog();
															return;
														case (IJEAJGCCHEF)117:
															LoadingDialog.Hide();
															WarningDialog.ShowError(Localization.Localize(","), Localization.Localize("ID_DIVISION"), 1476f, null, string.Empty, false, true);
															return;
														case (IJEAJGCCHEF)157:
														{
															Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
															FHIPGDADNFG fHIPGDADNFG = FHIPGDADNFG.HMOMMOBOHKL((JToken)EENKJBCCPBG["DogTagRefillTime"]);
															pADJFKLJGHH.PIIIKJJHJPN = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_SLOTUPGRADE_CLIP_SIZE"], string.Empty);
															GuiElementSingle<UserExistsDialog>.instance.AHJFFMAFCEG((AccountType)6, pADJFKLJGHH.GMFJFMHNDMC, fHIPGDADNFG.NOCJHDCEHBE, fHIPGDADNFG.BCCDDJMPBLL, fHIPGDADNFG.CJDHKJFKNAH, string.Empty);
															return;
														}
														case (IJEAJGCCHEF)93:
															Debug.Log(",");
															return;
														case (IJEAJGCCHEF)68:
															WarningDialog.JACKIDKHKAI(Localization.Localize(" set league "), Localization.Localize("Time"), 1595f, null, string.Empty, false, true);
															BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
															return;
														case (IJEAJGCCHEF)(-194):
															break;
														case (IJEAJGCCHEF)133:
															WarningDialog.JACKIDKHKAI(Localization.Localize("AndroidID"), Localization.Localize("ID_WARNING_WRONGINDEXTOACTIVATEELITE"), 1042f, null, string.Empty, true, true);
															return;
														case (IJEAJGCCHEF)(-112):
														{
															int iDLMJLCFMJG = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["de"], 1);
															long aFOPDKIJGHL = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_VETERANPACKDESCRIPTION"], 1L);
															GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(iDLMJLCFMJG, Localization.Localize("{0:D2}:{1:D2}"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
															Singleton<Wallet>.instance.GHPGMPNBJDB(aFOPDKIJGHL);
															return;
														}
														case IJEAJGCCHEF.PlayerNameTaken:
															WarningDialog.ShowError(Localization.Localize("PowerBandId"), Localization.Localize("T_pose"), 1706f, null, string.Empty, true);
															return;
														case (IJEAJGCCHEF)(-147):
															Singleton<Wallet>.instance.DMIHFEDMHIH(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_SLOTUPGRADE_AMMO"], 0L));
															return;
														case (IJEAJGCCHEF)43:
															PlayerAnalytics.instance.AddOneTimeReward(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_UNIT2UPGRADE_UNIT1UPGRADE"], string.Empty));
															Debug.LogError("LootBoxShowUp");
															return;
														case (IJEAJGCCHEF)(-64):
															WarningDialog.KHOMNBHMFGA(Localization.Localize("Cards"), Localization.Localize("Shots_Fired"), 686f, null, string.Empty, false, true);
															if (EENKJBCCPBG.ContainsKey("shield_unhide"))
															{
																Singleton<OfferManager>.instance.UpdateFromServer((JToken)EENKJBCCPBG["0"], true);
															}
															else
															{
																Singleton<OfferManager>.instance.UpdateFromServer(null);
															}
															if (EENKJBCCPBG.ContainsKey("com/google/android/gms/games/Games"))
															{
																string iNFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Warfriend"], string.Empty);
																if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.ActivateUnitUpgrade)
																{
																	if (jHOGFIPAAJH.IFGAGNBDKBE == DatabaseAction.IgnoreMessage)
																	{
																		Singleton<PurchaseProtection>.instance.VIPResponseCame(iNFLHPGMEOB);
																	}
																}
																else
																{
																	Singleton<PurchaseProtection>.instance.LootboxResponseCame(iNFLHPGMEOB);
																}
															}
															Debug.LogError("ID_SELECTFRIENDERRORSHORTNAME" + jHOGFIPAAJH.IFGAGNBDKBE);
															return;
														}
														goto IL_0e12;
													}
													goto case (IJEAJGCCHEF)(-24);
												}
												if (Singleton<GameController>.instance.isInMenuOrWait)
												{
													Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
													Singleton<GameController>.instance.NOKJMDOPFHL();
													Singleton<GameController>.instance.HGBNEFDBFDC();
													Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
													if (EENKJBCCPBG.ContainsKey("GameLauncher.Async started"))
													{
														Debug.LogError("ID_GUI_EQUIPPED" + EENKJBCCPBG["startActivity"]);
													}
													else
													{
														Debug.LogError("ID_LEAGUEDEMOTEHINT2");
													}
													ConfirmDialog.DPGHIAPIAGC(PDCGGAMDGCA, Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"), Localization.Localize("ID_GUI_TIERCOMPLETED"));
												}
												break;
											}
											int iDLMJLCFMJG2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Spend_Warbucks_On_Weapons"]);
											PlayerAnalytics.instance.data.paidInstantBattles = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["country-belarus"], 1);
											GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(iDLMJLCFMJG2, Localization.Localize("Player_relegated"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
											Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_COMPLETEALLTENSTARTERASSIGNMENTS"], 0L));
											break;
										}
									}
									Debug.LogError("如不下载这些额外数据，《战争之友》将无法运行。您希望退出还是下载这些数据？" + CDLPMHEODBN);
									if (Singleton<GameController>.instance.isInMenuOrWait)
									{
										Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
										Singleton<GameController>.instance.NOKJMDOPFHL();
										Singleton<GameController>.instance.Quit();
										if (CDLPMHEODBN == (IJEAJGCCHEF)76)
										{
											WarningDialog.JACKIDKHKAI(Localization.Localize("LootboxCost"), Localization.Localize("forDay"), 22f, MGHBLNJMDHL, string.Empty, false, true);
										}
										else
										{
											WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), 1486f, LEBLHNDFNEK, string.Empty, false, true);
										}
									}
								}
								else
								{
									ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ID_SALEPERCENTLINE"), Localization.Localize("Skill"), 1010f);
								}
							}
							else
							{
								ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("customDate"), Localization.Localize("LevelName"), 855f);
							}
							break;
						}
						goto IL_0e12;
					}
					WarningDialog.ShowError(Localization.Localize("_qbz2"), Localization.Localize("ID_STARTERASSIGNMENT"), 1644f, null, string.Empty, true);
					BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
					break;
				}
				WarningDialog.ShowError(Localization.Localize("-{0}-{1}"), Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"), 95f, null, string.Empty);
				break;
			}
			WarningDialog.JACKIDKHKAI(Localization.Localize("added"), Localization.Localize("Video_feed_watched"), 1420f, null, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)(-26):
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			Debug.LogError("oo" + jHOGFIPAAJH.IFGAGNBDKBE);
			if (EENKJBCCPBG.ContainsKey("ID_TUTORIAL_KILLENEMYUNITS"))
			{
				Debug.LogError("ID_GETFREEGOLD" + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["doesnt exist"], string.Empty));
			}
			LoadingDialog.FDBHFJFKALH(Localization.Localize("withPublisherSub4"), false, true);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_8"), Localization.Localize("D3"), 1732f, AMEDBJHACKK, Localization.Localize(" succesfully joined squad "), true);
			break;
		case (IJEAJGCCHEF)(-91):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("_HeightParams"), Localization.Localize("{0} {1}"), 1992f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)75:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("DOWNLOAD"), Localization.Localize("ID_GOLDCARD"), 1168f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)(-94):
		{
			WarningDialog.ShowError(Localization.Localize(" ID_"), Localization.Localize("No Request ready or already sent"), 95f, null, string.Empty, false, true);
			int num2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Generate army 4"]);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num2);
			int num3 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DOWNLOAD"], 1);
			Singleton<Wallet>.instance.DFHDGPJBFFN(num3);
			break;
		}
		case (IJEAJGCCHEF)(-93):
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Cards_Owned_Silver"), Localization.Localize("setPluginName"), 817f, null, string.Empty, true, true);
			int num4 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["dailyRewardData"]);
			Singleton<Wallet>.instance.DFHDGPJBFFN(num4);
			break;
		}
		case (IJEAJGCCHEF)(-92):
		{
			WarningDialog.ShowError(Localization.Localize("Gold"), Localization.Localize("Cards_Played"), 1551f, null, string.Empty);
			int num13 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["{0}{1}"], 1);
			int num14 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["C1"], 1);
			bool flag = KHJJFPPACBP.FOJOKBCNBCO(EENKJBCCPBG["ID_ISALREADYMEMBEROFANOTHERSQUAD"]);
			Debug.LogError(string.Format("Fusebox: Setting ios app id for about fun = e695d3cf-1ed0-4989-89fe-e041e4ee7e2b", num14, num13, (!flag) ? "OBB: Looking for file Exp '{0}' Main '{1}'" : "Idle"));
			break;
		}
		case (IJEAJGCCHEF)2:
			LoadingDialog.Hide();
			ConfirmDialog.ShowAlert(Localization.Localize("com/google/android/gms/games/Games"), Localization.Localize("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot remove it"), 751f);
			break;
		case (IJEAJGCCHEF)74:
			WarningDialog.ShowError(Localization.Localize("WarArenaData"), Localization.Localize("InstantBattleEnded: LEVEL UP "), 1489f, null, string.Empty, true, true);
			if (EENKJBCCPBG.ContainsKey("ID_CONGRATULATIONSPLACEDINLEAGUE"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.FFAGKCAPLIO(EENKJBCCPBG["ID_CONFIRM_KICKPLAYER"].ToString(), true);
			}
			break;
		case (IJEAJGCCHEF)73:
		{
			string text3 = ((!EENKJBCCPBG.ContainsKey("com/google/android/gms/games/Games")) ? string.Empty : EENKJBCCPBG["Wrong_Weapon"].ToString());
			string hOLNKOFHDNK = Localization.Localize("bazooka_reload");
			object[] array3 = new object[0];
			array3[0] = text3;
			WarningDialog.ShowError(hOLNKOFHDNK, Localization.LocalizeFormat("ID_PLAYERLEAGUEPROCESSINGHINT", array3), 1942f, null, string.Empty, false, true);
			if (EENKJBCCPBG.ContainsKey("ios"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.EOPEBHMLGBP(EENKJBCCPBG["ID_SILVERSMALL"].ToString(), true);
			}
			break;
		}
		case IJEAJGCCHEF.Success:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("Player chose to stay on his account"), Localization.Localize("stand_up_crawl"), 1316f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)(-1):
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("null"), Localization.Localize("Warbucks"), 505f, null, string.Empty, false, true);
			break;
		case IJEAJGCCHEF.SameFacebookAlreadyCreated:
			WarningDialog.JACKIDKHKAI(Localization.Localize("0"), Localization.Localize("mortar_hide"), 1786f, null, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)0:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_STAT_SQUADWARSWINS"), Localization.Localize("RegisterCurrency()"), 1765f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case (IJEAJGCCHEF)20:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("testingidsquadrankup"), Localization.Localize("]"), 952f, null, string.Empty, true);
			break;
		case (IJEAJGCCHEF)(-41):
			WarningDialog.ShowError(Localization.Localize("some_pub_sub3"), Localization.Localize(" AND "), 921f, null, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)17:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_TUTORIAL_TAPON"), Localization.Localize("OnAgeVerificationPendingDisplayed"), 360f, JFJBOAMMHGL, string.Empty, true, true);
			}
			break;
		case (IJEAJGCCHEF)79:
		case (IJEAJGCCHEF)80:
		case (IJEAJGCCHEF)81:
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
			break;
		case (IJEAJGCCHEF)(-59):
		{
			int num11 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["N"], 1);
			long num12 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_NOTIFICATION_INSTANTBATTLEAVAILABLE"], 0L);
			object[] array5 = new object[0];
			array5[0] = "ID_BLACKMARKETLEFTTEXT1";
			array5[1] = num11;
			array5[4] = "AIRSTRIKE";
			array5[2] = num12;
			Debug.LogError(string.Concat(array5));
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("RewardItem"));
			Singleton<Wallet>.instance.GHPGMPNBJDB(num12);
			break;
		}
		case (IJEAJGCCHEF)(-58):
		{
			int num9 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["MaxTiers"], 1);
			long num10 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_ACTIVATION"], 1L);
			object[] array4 = new object[2];
			array4[0] = "UsedCards";
			array4[0] = num9;
			array4[1] = "NULL";
			array4[2] = num10;
			Debug.LogError(string.Concat(array4));
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(PlayerAnalytics.instance.createSquadWarBucksPrice, Localization.Localize("ID_SQUADEVENT"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			Singleton<Wallet>.instance.DMIHFEDMHIH(num10);
			break;
		}
		case (IJEAJGCCHEF)(-60):
		{
			string text7 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Clicked buy on "], string.Empty);
			int num7 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["LEADERBOARDS - showing top squads - global:"]);
			long num8 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["{0}{1}{2} {3}{4}"], 1L);
			Debug.LogError(string.Format("ShotFrequencyMax", num7, num8, text7));
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num7, Localization.Localize("ID_POWERBANDBOX"));
			Singleton<PurchaseProtection>.instance.IOKPHKKICBC(text7);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num8);
			break;
		}
		case (IJEAJGCCHEF)(-57):
		{
			string text6 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["withPublisherSub4"], string.Empty);
			int num5 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Buy_Weapon_Gold"], 1);
			long num6 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_CONFIRM_NOTLEADEROFSQUAD_TEXT"], 1L);
			Debug.LogError(string.Format("PromotedPlayer", num5, num6, text6));
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num5, Localization.Localize("Starting LocalPersistenceManager!"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			Singleton<PurchaseProtection>.instance.LootboxResponseCame(text6);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num6);
			break;
		}
		case (IJEAJGCCHEF)(-56):
		{
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["{0} {1}{2}"], string.Empty);
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_ARENACROWN_DURATION"], string.Empty);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("635 STAGE 10 PLAY CARD"), Localization.Localize("Squad"), 858f, null, string.Empty, true);
			break;
		}
		case (IJEAJGCCHEF)14:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.KKOOPJBADGJ(delegate
			{
				Debug.Log("Delete QuickPlay Data");
				GameLoginManager.instance.DeletePlayerAccount();
				GameLoginManager.Relog();
			}, Localization.Localize("Battle_Number"), Localization.Localize("BattleCount"));
			break;
		case (IJEAJGCCHEF)16:
		{
			string text = "ID_GUI_SQUADRANKUP";
			string text2 = "ok";
			if (EENKJBCCPBG.ContainsKey("damage"))
			{
				text = EENKJBCCPBG["ID_STAYINDIVISION"].ToString();
			}
			if (EENKJBCCPBG.ContainsKey("battlesLostInRow"))
			{
				text2 = EENKJBCCPBG["ID_PLAYBATTLETOENTERBRONZELEAGUE"].ToString();
			}
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			string empty = string.Empty;
			if (EENKJBCCPBG.ContainsKey("WRONG NUMBER OF ALL BOXES "))
			{
				int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["WonBattles"]);
				object[] array = new object[6];
				array[0] = text;
				array[0] = text2;
				array[6] = MEJMLNDFDBP.LEEEFPGPEOM(num);
				empty = Localization.LocalizeFormat("ID_BUTTON_TOPPLAYERS", array);
			}
			else
			{
				object[] array2 = new object[2];
				array2[0] = text;
				array2[0] = text2;
				empty = Localization.LocalizeFormat("ID_WARNING_NOTENOUGHTWARCARDS", array2);
			}
			WarningDialog.KHOMNBHMFGA(empty, Localization.Localize("InAppRow '"), 355f, CMKECGNLPGJ, Localization.Localize("StepId"), true, EENKJBCCPBG.ContainsKey("animationEnd"));
			break;
		}
		case (IJEAJGCCHEF)(-24):
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Debug.LogError("LeagueEvaluation");
				Singleton<GameController>.instance.NOKJMDOPFHL();
				Singleton<GameController>.instance.HGBNEFDBFDC();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog(false);
			}
			break;
		case (IJEAJGCCHEF)(-25):
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<NewVersionDialog>.instance, 1400f);
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
			break;
		case (IJEAJGCCHEF)15:
			{
				Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
				Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
				ConfirmDialog.CGHPOPGKAGN(FDFCAKIKOHB, Localization.Localize("Buy_Army_Unit_At_Rank"), Localization.Localize("ID_STAT_CUSTOMISATIONSPURCHASED"));
				break;
			}
			IL_0e12:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("NotificationAction()"), Localization.Localize("ID_GUI_DELIVERING"), 325f, null, string.Empty, false, true);
			break;
		}
	}

	public static string MGNAHDCCOKL()
	{
		return "DogTagLastUpdate";
	}

	[CompilerGenerated]
	private static void EKOOKEFBDNC()
	{
		GameLoginManager.Relog();
	}

	private static void KEJDKGCNMNA()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void LIPDIGIJKIG()
	{
		GameLoginManager.Relog();
	}

	private static void FDFCAKIKOHB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("menu-assignments-type-cards");
		GameLoginManager.instance.DeletePlayerAccount();
		GameLoginManager.Relog();
	}

	private static void GGIMILOHOBD(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog();
	}

	private static void CMKECGNLPGJ()
	{
		GameLoginManager.Relog();
	}

	private static void LMIOPPOPNLN()
	{
		GameLoginManager.Relog(false);
	}

	private static void JPDHOIAIONH(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("QUIT");
		GameLoginManager.instance.DeletePlayerAccount();
		GameLoginManager.Relog(false);
	}

	private static void AMEDBJHACKK()
	{
		GameLoginManager.Relog(false);
	}

	internal void FKLIAJOJGMG(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		DialogManager.instance.HideAllDialogs();
		switch (MHLAAHNPMFG)
		{
		case (DatabaseAction)22:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(false);
			break;
		case (DatabaseAction)(-106):
		case (DatabaseAction)(-105):
		case (DatabaseAction)(-103):
		case (DatabaseAction)(-102):
		case (DatabaseAction)(-101):
		case DatabaseAction.CreateAccount:
			PMDEGLOIPEH((IJEAJGCCHEF)(-45), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		case (DatabaseAction)(-108):
			GOEHBPFDMLM((IJEAJGCCHEF)52, null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog(false);
			break;
		}
	}

	internal void NCBHMGIMAPK(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		DialogManager.instance.HideAllDialogs();
		switch (MHLAAHNPMFG)
		{
		case DatabaseAction.InstantWeaponUpgrade:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		case (DatabaseAction)102:
		case DatabaseAction.BuyVip:
		case (DatabaseAction)115:
		case (DatabaseAction)117:
		case DatabaseAction.CreateAccount:
		case DatabaseAction.GameStartedTutorial:
			PAIDOPMKBPC((IJEAJGCCHEF)42, null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		case DatabaseAction.SkipAssignment:
			PMDEGLOIPEH((IJEAJGCCHEF)(-74), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog();
			break;
		}
	}

	[CompilerGenerated]
	private static void CGHODKJHNGI()
	{
		GameLoginManager.Relog();
	}

	private static void GECKDCAGPJI()
	{
		GameLoginManager.Relog();
	}

	private static void ABMABLBKOFK(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void CACBEKHNFBA()
	{
		GameLoginManager.Relog();
	}

	private static void EHNJFNPBPOM(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog();
	}

	public static string JLKIELEHAGO()
	{
		return "No row IDs gained from server for new item config download: ";
	}

	private static void HGDEHGJHPBB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog();
	}

	internal void PMDEGLOIPEH(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG, DatabaseAction IFGAGNBDKBE, List<Tuple<string, string>> GMDJHENPLHB)
	{
		JHOGFIPAAJH jHOGFIPAAJH = new JHOGFIPAAJH();
		jHOGFIPAAJH.IFGAGNBDKBE = IFGAGNBDKBE;
		DialogManager.instance.HideAllDialogs();
		if (CDLPMHEODBN != (IJEAJGCCHEF)75)
		{
			LoadingDialog.Hide();
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE == (DatabaseAction)(-56) && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Playing && CDLPMHEODBN != (IJEAJGCCHEF)36)
		{
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
			return;
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.CardpoolShown)
		{
			if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.ChangeNameAndPassword)
			{
				if (jHOGFIPAAJH.IFGAGNBDKBE != (DatabaseAction)(-9))
				{
					if (jHOGFIPAAJH.IFGAGNBDKBE == (DatabaseAction)(-37))
					{
						MHEHGPLIFHF.KLPFJPBMDGG(CDLPMHEODBN, EENKJBCCPBG);
					}
				}
				else
				{
					MIFGKEHBPOK.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
				}
			}
			else
			{
				JOPIPCDHOLF.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
			}
		}
		else
		{
			DIENNAGJJOM.PHNAAJIHEIG(CDLPMHEODBN, EENKJBCCPBG);
		}
		PADJFKLJGHH pADJFKLJGHH = new PADJFKLJGHH();
		pADJFKLJGHH.AIHDNGDNDHH = jHOGFIPAAJH;
		switch (CDLPMHEODBN)
		{
		default:
			if (CDLPMHEODBN != (IJEAJGCCHEF)(-195))
			{
				if (CDLPMHEODBN != (IJEAJGCCHEF)(-59) && CDLPMHEODBN != (IJEAJGCCHEF)96)
				{
					if (CDLPMHEODBN != (IJEAJGCCHEF)9)
					{
						if (CDLPMHEODBN != (IJEAJGCCHEF)38)
						{
							if (CDLPMHEODBN != (IJEAJGCCHEF)(-137))
							{
								if (CDLPMHEODBN != IJEAJGCCHEF.DecalNotBought)
								{
									if (CDLPMHEODBN == (IJEAJGCCHEF)(-87))
									{
										goto case (IJEAJGCCHEF)(-23);
									}
									if (CDLPMHEODBN != (IJEAJGCCHEF)128)
									{
										if (CDLPMHEODBN != (IJEAJGCCHEF)64)
										{
											if (CDLPMHEODBN != IJEAJGCCHEF.DecalCategoryNotFound)
											{
												switch (CDLPMHEODBN)
												{
												default:
													return;
												case (IJEAJGCCHEF)(-106):
													Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
													Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
													LoadingDialog.ShowLoading(Localization.Localize("!!!UNDER TABLE!!! "), false, true, true);
													WarningDialog.JACKIDKHKAI(Localization.Localize("Video {0:2}"), Localization.Localize("PlayerData"), 478f, BDIKIDFCDKO, Localization.Localize("Create player instance at "), true);
													return;
												case (IJEAJGCCHEF)(-164):
													Debug.LogError("Warfriends");
													WarningDialog.JACKIDKHKAI(Localization.Localize("EnteredLeague"), Localization.Localize("OOOOPS"), 1598f, null, string.Empty);
													CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["S"], string.Empty));
													return;
												case (IJEAJGCCHEF)(-151):
													Debug.LogError("dialog shown = {0}, lives = {1}");
													WarningDialog.JACKIDKHKAI(Localization.Localize("ID_BEGINNERSLEAGUE2"), Localization.Localize("unregisterConnectionCallbacks"), 704f, null, string.Empty, true);
													CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["StartingGold"], string.Empty));
													return;
												case (IJEAJGCCHEF)34:
													Debug.Log("CardCraft_Collect" + jHOGFIPAAJH.IFGAGNBDKBE);
													Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(true);
													return;
												case (IJEAJGCCHEF)80:
													Debug.LogError("Squad Card ID \"{0}\" is not pressent" + jHOGFIPAAJH.IFGAGNBDKBE);
													WarningDialog.ShowError(Localization.Localize("ID_READYTIME"), Localization.Localize("NewLevelId"), 1965f, null, string.Empty, true);
													AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["dd/M/yyyy"], string.Empty));
													return;
												case (IJEAJGCCHEF)(-113):
													Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
													Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
													GameLoginManager.Relog(false);
													return;
												case (IJEAJGCCHEF)195:
													LoadingDialog.Hide();
													WarningDialog.ShowError(Localization.Localize("ID_SQUADWAREND"), Localization.Localize(" arena id"), 905f, null, string.Empty, false, true);
													return;
												case (IJEAJGCCHEF)85:
												{
													Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
													FHIPGDADNFG fHIPGDADNFG = FHIPGDADNFG.EOBMFCOBOLB((JToken)EENKJBCCPBG["SlotIndex"]);
													pADJFKLJGHH.PIIIKJJHJPN = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["0"], string.Empty);
													GuiElementSingle<UserExistsDialog>.instance.CPEKKCLJFBA(AccountType.GameCenter, pADJFKLJGHH.GMFJFMHNDMC, fHIPGDADNFG.NOCJHDCEHBE, fHIPGDADNFG.BCCDDJMPBLL, fHIPGDADNFG.CJDHKJFKNAH, string.Empty);
													return;
												}
												case (IJEAJGCCHEF)(-71):
													Debug.Log("MessageType");
													return;
												case (IJEAJGCCHEF)(-56):
													WarningDialog.KHOMNBHMFGA(Localization.Localize("null"), Localization.Localize("Player {0} {1}"), 975f, null, string.Empty, true);
													return;
												case (IJEAJGCCHEF)(-37):
													WarningDialog.KHOMNBHMFGA(Localization.Localize("Mortar"), Localization.Localize(" "), 1291f, null, string.Empty, false, true);
													return;
												case (IJEAJGCCHEF)(-52):
													WarningDialog.ShowError(Localization.Localize("leagueDiff"), Localization.Localize("Para funcionar, WarFriends necesita descargar unos 190 MB de datos adicionales.\nEl tiempo de descarga puede variar, dependiendo de tu red y tu ubicación.\n\n¿Continuar?"), 1638f, null, string.Empty, true, true);
													BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
													return;
												case (IJEAJGCCHEF)(-104):
													WarningDialog.ShowError(Localization.Localize("Ground texture: "), Localization.Localize("#DEBUG_50# "), 496f, pADJFKLJGHH.EJLGBICBIFK, string.Empty, true, true);
													GameLoginManager.instance.LogoutFromFacebook(true);
													if (EENKJBCCPBG.ContainsKey("*.prefab"))
													{
														Debug.LogError("Player disconected 0001" + EENKJBCCPBG["ID_CONFIRM_SQUADISALREADYFULL"]);
													}
													return;
												case (IJEAJGCCHEF)35:
													break;
												case (IJEAJGCCHEF)82:
													WarningDialog.ShowError(Localization.Localize("Generating extra enemy"), Localization.Localize("logout from FB"), 1819f, null, string.Empty, true);
													return;
												case (IJEAJGCCHEF)(-73):
												{
													int iDLMJLCFMJG = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["{0}"]);
													long aFOPDKIJGHL = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["(Lcom/google/android/gms/common/api/ResultCallback;)V"], 1L);
													GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(iDLMJLCFMJG, Localization.Localize("MineCards"));
													Singleton<Wallet>.instance.GHPGMPNBJDB(aFOPDKIJGHL);
													return;
												}
												case (IJEAJGCCHEF)(-155):
													WarningDialog.JACKIDKHKAI(Localization.Localize("com.aboutfun.soldiers"), Localization.Localize("ID_PLAYAGAIN"), 790f, null, string.Empty, false, true);
													return;
												case (IJEAJGCCHEF)134:
													Singleton<Wallet>.instance.DMIHFEDMHIH(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["menu-army-ammo-ico"], 0L));
													return;
												case (IJEAJGCCHEF)(-45):
													PlayerAnalytics.instance.AddOneTimeReward(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Terms: Start"], string.Empty));
													Debug.LogError("Rewards");
													return;
												case (IJEAJGCCHEF)76:
													WarningDialog.JACKIDKHKAI(Localization.Localize("Concrete"), Localization.Localize("Power Band {0} does not exists on client."), 1969f, null, string.Empty);
													if (EENKJBCCPBG.ContainsKey("reset tutorial"))
													{
														Singleton<OfferManager>.instance.UpdateFromServer((JToken)EENKJBCCPBG["RewardMessage"], true);
													}
													else
													{
														Singleton<OfferManager>.instance.UpdateFromServer(null);
													}
													if (EENKJBCCPBG.ContainsKey("ID_BUTTON_YOURSQUAD"))
													{
														string iNFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_WARNING_BADVERSIONERROR"], string.Empty);
														if (jHOGFIPAAJH.IFGAGNBDKBE != (DatabaseAction)(-72))
														{
															if (jHOGFIPAAJH.IFGAGNBDKBE == (DatabaseAction)(-67))
															{
																Singleton<PurchaseProtection>.instance.EGGOPJBCIAA(iNFLHPGMEOB);
															}
														}
														else
														{
															Singleton<PurchaseProtection>.instance.LootboxResponseCame(iNFLHPGMEOB);
														}
													}
													Debug.LogError("GLM: CreateNewAccount - GC: " + jHOGFIPAAJH.IFGAGNBDKBE);
													return;
												}
												goto case (IJEAJGCCHEF)(-195);
											}
											goto case (IJEAJGCCHEF)201;
										}
										if (Singleton<GameController>.instance.isInMenuOrWait)
										{
											Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
											Singleton<GameController>.instance.TryStopLoading();
											Singleton<GameController>.instance.Quit();
											Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
											if (EENKJBCCPBG.ContainsKey(" "))
											{
												Debug.LogError("LoadingFinishedRPC" + EENKJBCCPBG["Cards"]);
											}
											else
											{
												Debug.LogError("Stats");
											}
											ConfirmDialog.NFECLPLEOBN(delegate
											{
												GameLoginManager.Relog();
											}, Localization.Localize("set visual not borrowed"), Localization.Localize("null"));
										}
										break;
									}
									int iDLMJLCFMJG2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_GUI_CHEATWARNING"], 1);
									PlayerAnalytics.instance.data.paidInstantBattles = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["[CFX_SpawnSystem.GetNextPoolObject()] Object hasn't been preloaded: "]);
									GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(iDLMJLCFMJG2, Localization.Localize("Animation for State: Crafting"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
									Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["+{0}%"], 1L));
									break;
								}
								WarningDialog.ShowError(Localization.Localize("attack"), Localization.Localize("ID_ARENAREWARDEXPIRATION"), 1539f, null, string.Empty);
								CardManager.instance.nextWithdraw = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["RETRY"], 1);
								break;
							}
							ConfirmDialog.ShowAlert(Localization.Localize("LeagueEvaluation"), Localization.Localize("ID_READYTIME"), 1032f);
							Dictionary<string, object> depositedCards = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["JA"], string.Empty));
							GameLoginManager.instance.SetDepositedCards(depositedCards);
							CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_DEBUG_GUIERROR"], string.Empty));
							break;
						}
						Debug.LogError("ShotFrequencyMaxCannon" + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["ID_YOURREWARDS"], string.Empty));
						WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_NOTIFICATION_DAILYREWARD_CARD"), Localization.Localize("ManualRegisterForPushNotifications("), 524f, null, string.Empty, false, true);
						Dictionary<string, object> depositedCards2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["AMMOBOX"], string.Empty));
						GameLoginManager.instance.SetDepositedCards(depositedCards2);
						CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["HighLevelGoldRarity"], string.Empty));
						break;
					}
					WarningDialog.ShowError(Localization.Localize("ID_GUI_CHAT_BANNED_DESCBOX_TEMP"), Localization.Localize("+{0}"), 953f, null, string.Empty);
					if (EENKJBCCPBG.ContainsKey("{0}{1}[-]"))
					{
						Dictionary<string, string> depositedCards3 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["/"], string.Empty));
						GameLoginManager.instance.SetDepositedCards(depositedCards3);
					}
					CardCraftingManager.instance.SetWaitingForServerResponse(true);
					CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG[")"], string.Empty));
					break;
				}
				LoadingDialog.Hide();
				WarningDialog.KHOMNBHMFGA(Localization.Localize("ShotFrequencyMax"), Localization.Localize("menu-arena-ticket"), 1245f, null, string.Empty, true);
				break;
			}
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("//"), Localization.Localize("lastWeeksPlayerLeague"), 877f);
			break;
		case (IJEAJGCCHEF)199:
			Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.LogError("shield_unhide" + jHOGFIPAAJH.IFGAGNBDKBE);
			if (EENKJBCCPBG.ContainsKey("ID_READYTIME"))
			{
				Debug.LogError("ID_WARNING_SERVERDATA" + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["]"], string.Empty));
			}
			LoadingDialog.PGFBMJFLHPC(Localization.Localize("ID_RANDOMWARCARDS"));
			WarningDialog.ShowError(Localization.Localize("ID_RENTAL_SHOTGUN"), Localization.Localize("LevelExperience"), 1124f, LOLHPMKHCBF, Localization.Localize("getHighSpenderProbability"), true);
			break;
		case (IJEAJGCCHEF)9:
			WarningDialog.ShowError(Localization.Localize("ID_ONLINE"), Localization.Localize("ID_GUI_WINXPBONUS"), 900f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)(-122):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ID_RANK"), Localization.Localize("Defenders"), 534f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)(-50):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("_FrustumCornersWS"), Localization.Localize("DogTagSeconds"), 362f, GJAENDJLJJF, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)(-125):
		{
			WarningDialog.ShowError(Localization.Localize("0"), Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS_TEXT"), 1724f, null, string.Empty, true);
			int num2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DailyGoldDay"], 1);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num2);
			int num3 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["."], 1);
			Singleton<Wallet>.instance.InitTickets(num3);
			break;
		}
		case (IJEAJGCCHEF)(-124):
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("sniper_idle"), Localization.Localize("menu-sidetab-messageicon"), 1343f, null, string.Empty, false, true);
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["NO"], 1);
			Singleton<Wallet>.instance.DFHDGPJBFFN(num);
			break;
		}
		case (IJEAJGCCHEF)(-123):
		{
			WarningDialog.ShowError(Localization.Localize("not added, called already!!"), Localization.Localize("ID_POSITIONXYREWARD"), 582f, null, string.Empty, false, true);
			int num5 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_TEMPORARY"], 1);
			int num6 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Add request to buffer"]);
			bool flag = KHJJFPPACBP.FOJOKBCNBCO(EENKJBCCPBG["#Mission Rewards# 3 Solo Daily Missions completed. Gained {0} gold"]);
			Debug.LogError(string.Format("Level", num6, num5, (!flag) ? "com/google/android/gms/common/ConnectionResult" : "recordingStartedEvent + mTryToSetRecording"));
			break;
		}
		case (IJEAJGCCHEF)21:
			WarningDialog.ShowError(Localization.Localize("ID_BUTTONPREVIOUSHEROES"), Localization.Localize("Can not find player with fraction "), 893f, null, string.Empty, false, true);
			break;
		case (IJEAJGCCHEF)144:
			LoadingDialog.Hide();
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("seconds"), Localization.Localize("\t\"FALSE\""), 1858f);
			break;
		case (IJEAJGCCHEF)(-51):
			WarningDialog.KHOMNBHMFGA(Localization.Localize("S"), Localization.Localize("ID_MAXSTAT"), 62f, null, string.Empty, true);
			if (EENKJBCCPBG.ContainsKey("fire"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.JEONJCCHDMB(EENKJBCCPBG["SpentParts"].ToString(), false);
			}
			break;
		case (IJEAJGCCHEF)(-52):
		{
			string text3 = ((!EENKJBCCPBG.ContainsKey("game-card-ico-bg-gold")) ? string.Empty : EENKJBCCPBG["ID_LOOTDUPLICATE"].ToString());
			string hOLNKOFHDNK = Localization.Localize("ThrowGrenadeFromCrawl");
			object[] array3 = new object[1];
			array3[1] = text3;
			WarningDialog.JACKIDKHKAI(hOLNKOFHDNK, Localization.LocalizeFormat("Show Ground", array3), 270f, null, string.Empty, false, true);
			if (EENKJBCCPBG.ContainsKey("Chillingo: On Restart Drawing "))
			{
				Singleton<AwaitingSquadMembersManager>.instance.JEONJCCHDMB(EENKJBCCPBG[" AND "].ToString(), true);
			}
			break;
		}
		case (IJEAJGCCHEF)143:
			LoadingDialog.Hide();
			WarningDialog.KHOMNBHMFGA(Localization.Localize("game-card-silver-big"), Localization.Localize("MessageId"), 1911f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)141:
			LoadingDialog.Hide();
			WarningDialog.KHOMNBHMFGA(Localization.Localize("S"), Localization.Localize("Buy_Unit"), 797f, null, string.Empty, false, true);
			break;
		case (IJEAJGCCHEF)145:
			WarningDialog.KHOMNBHMFGA(Localization.Localize("Days_Since_Install"), Localization.Localize("cp: "), 337f, null, string.Empty);
			break;
		case (IJEAJGCCHEF)142:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize(","), Localization.Localize("S"), 1022f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty, true, true);
			break;
		case (IJEAJGCCHEF)122:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("DogTagCap"), Localization.Localize("Wrong_Category"), 393f, null, string.Empty, true);
			break;
		case (IJEAJGCCHEF)(-83):
			WarningDialog.JACKIDKHKAI(Localization.Localize("fire"), Localization.Localize("FB: FacebookLogout - DeletePlayerAccount - 2"), 1457f, null, string.Empty, true);
			break;
		case (IJEAJGCCHEF)130:
			WarningDialog.JACKIDKHKAI(Localization.Localize(" "), Localization.Localize("ID_ARENARULES_NOSHIELDS"), 1688f, null, string.Empty, true, true);
			BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
			break;
		case (IJEAJGCCHEF)(-195):
			WarningDialog.JACKIDKHKAI(Localization.Localize("bronze"), Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), 1620f, null, string.Empty, true);
			break;
		case (IJEAJGCCHEF)(-168):
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.HGBNEFDBFDC();
				WarningDialog.ShowError(Localization.Localize("Chillingo SDK: activate offers"), Localization.Localize("ID_MEMBERSHIP_HINT5TRIAL"), 0f, EBGMHAGCFNB, string.Empty, true, true);
			}
			break;
		case (IJEAJGCCHEF)(-93):
		case (IJEAJGCCHEF)(-92):
		case (IJEAJGCCHEF)(-91):
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
			break;
		case (IJEAJGCCHEF)(-23):
		case (IJEAJGCCHEF)59:
			Debug.LogError("ID_MATCH_STARTS_IN" + CDLPMHEODBN);
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
				Singleton<GameController>.instance.NOKJMDOPFHL();
				Singleton<GameController>.instance.HGBNEFDBFDC();
				if (CDLPMHEODBN == (IJEAJGCCHEF)92)
				{
					WarningDialog.ShowError(Localization.Localize("SquadWarsId"), Localization.Localize("ID_VISUALRARITY3"), 2f, BPPHEBADMAG, string.Empty, true, true);
				}
				else
				{
					WarningDialog.ShowError(Localization.Localize("リトライ"), Localization.Localize("303 STAGE 9 STARTED"), 1318f, CNKJBPNDDMN, string.Empty);
				}
			}
			break;
		case (IJEAJGCCHEF)(-97):
		{
			int num13 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["UNSET_VALUE"]);
			long num14 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["NotificationsEnabled"], 0L);
			object[] array5 = new object[7];
			array5[1] = "flawless";
			array5[0] = num13;
			array5[4] = "game-box-ammo";
			array5[3] = num14;
			Debug.LogError(string.Concat(array5));
			GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize(" 1"));
			Singleton<Wallet>.instance.GHPGMPNBJDB(num14);
			break;
		}
		case (IJEAJGCCHEF)(-96):
		{
			int num11 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_UNIT-BUDDY"]);
			long num12 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["ID_STAT_WEAPONSUPGRADES"], 1L);
			object[] array4 = new object[6];
			array4[1] = "Turret";
			array4[1] = num11;
			array4[0] = "Avg_fps";
			array4[4] = num12;
			Debug.LogError(string.Concat(array4));
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(PlayerAnalytics.instance.createSquadWarBucksPrice, Localization.Localize("menu-health-ico"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			Singleton<Wallet>.instance.OLEBALNELCP(num12);
			break;
		}
		case (IJEAJGCCHEF)(-98):
		{
			string text7 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["BAND_TYPE_EMPTY"], string.Empty);
			int num9 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Level"], 1);
			long num10 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["Buffer already sent!"], 0L);
			Debug.LogError(string.Format("br", num9, num10, text7));
			GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num9, Localization.Localize("Squad Event Ended. Squad completed "), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			Singleton<PurchaseProtection>.instance.EGGOPJBCIAA(text7);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num10);
			break;
		}
		case (IJEAJGCCHEF)(-95):
		{
			string text6 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["game-label-you-red"], string.Empty);
			int num7 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["Unit"]);
			long num8 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["{0}"], 0L);
			Debug.LogError(string.Format("Sessions", num7, num8, text6));
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num7, Localization.Localize("LevelName"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			Singleton<PurchaseProtection>.instance.LootboxResponseCame(text6);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num8);
			break;
		}
		case (IJEAJGCCHEF)(-94):
		{
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["#AccoutCheck# FacebookLoginDuringTutorial - wrong situation -> do nothing"], string.Empty);
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["_DistanceParams"], string.Empty);
			WarningDialog.KHOMNBHMFGA(Localization.Localize("ShowArenaDialog"), Localization.Localize("ID_READYTIME"), 1687f, null, string.Empty);
			break;
		}
		case (IJEAJGCCHEF)188:
			ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("()V"), Localization.Localize("DeathEvent"), 1763f);
			break;
		case (IJEAJGCCHEF)175:
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("WarFriends"), Localization.Localize("_MAX_"), 438f);
			break;
		case (IJEAJGCCHEF)125:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			ConfirmDialog.NFECLPLEOBN(JAIPDGFDJCB, Localization.Localize("ID_COMPLETED"), Localization.Localize(" "));
			break;
		case (IJEAJGCCHEF)(-171):
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.KKOOPJBADGJ(JPDHOIAIONH, Localization.Localize("getMatId"), Localization.Localize("ID_GOLD"));
			break;
		case (IJEAJGCCHEF)(-169):
		{
			string text = "ID_POSITIONXYREWARD";
			string text2 = "Beanstalk: Application not reachable!";
			if (EENKJBCCPBG.ContainsKey("01 "))
			{
				text = EENKJBCCPBG["Can not find asset {0}"].ToString();
			}
			if (EENKJBCCPBG.ContainsKey("ID_SILVERCARD"))
			{
				text2 = EENKJBCCPBG["ID_CONFIRM_LEAVESQUAD_TEXT"].ToString();
			}
			Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			string empty = string.Empty;
			if (EENKJBCCPBG.ContainsKey("ID_SALEPERCENTLINE"))
			{
				int num4 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ID_TUTORIAL_TAPON"], 1);
				object[] array = new object[2];
				array[1] = text;
				array[1] = text2;
				array[6] = MEJMLNDFDBP.LEEEFPGPEOM(num4);
				empty = Localization.LocalizeFormat("Name", array);
			}
			else
			{
				object[] array2 = new object[8];
				array2[1] = text;
				array2[1] = text2;
				empty = Localization.LocalizeFormat(", password = ", array2);
			}
			WarningDialog.KHOMNBHMFGA(empty, Localization.Localize(" {0}{1}"), 1164f, LMIOPPOPNLN, Localization.Localize("ID_PURCHASED"), false, EENKJBCCPBG.ContainsKey("ID_LEAGUEPROMOTION"));
			break;
		}
		case (IJEAJGCCHEF)201:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
				Debug.LogError("BattleId");
				Singleton<GameController>.instance.NOKJMDOPFHL();
				Singleton<GameController>.instance.HGBNEFDBFDC();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog(false);
			}
			break;
		case (IJEAJGCCHEF)200:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = true;
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<NewVersionDialog>.instance, 1998f);
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
			break;
		case (IJEAJGCCHEF)(-170):
			Singleton<BeanstalkServerManager>.instance.INNIDHNEKEA();
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			ConfirmDialog.KKOOPJBADGJ(FDFCAKIKOHB, Localization.Localize("added"), Localization.Localize("Value4"));
			break;
		}
	}

	public static string POKMIGOGBGM()
	{
		return "ID_PERMANENTUNLOCK";
	}

	private static void KPMEAMMMKGG()
	{
		GameLoginManager.Relog(false);
	}

	private static void ANIDODHNPKI()
	{
		GameLoginManager.Relog();
	}

	private static void CFCBKEGIFFG()
	{
		GameLoginManager.Relog(false);
	}

	[CompilerGenerated]
	private static void IEBOAKLEFOM(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Player was removed from db!");
		GameLoginManager.Relog();
	}

	private static void LKILKBFNFDI()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void PLKPCFLCJJI()
	{
		GameLoginManager.Relog();
	}

	public static void MDCHGDJIGAA()
	{
		Singleton<GameController>.instance.TryStopLoading();
		Singleton<GameController>.instance.HGBNEFDBFDC();
		Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
		WarningDialog.ShowError(Localization.Localize("-veteran"), Localization.Localize("GoldCoefficient"), 1209f, delegate
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.Log("RETRY");
			GameLoginManager.Relog();
			LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
		}, Localization.Localize("ID_INROOKIE2"), true);
	}

	[CompilerGenerated]
	private static void CKNJEOFBLGG()
	{
		GameLoginManager.Relog();
	}

	internal void LJBCJOHNELK(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		DialogManager.instance.HideAllDialogs();
		switch (MHLAAHNPMFG)
		{
		case (DatabaseAction)(-82):
			Singleton<BeanstalkServerManager>.instance.EOAILOJFNJG();
			GameLoginManager.Relog(false);
			break;
		case DatabaseAction.HitListPlayerLoggedIn:
		case (DatabaseAction)95:
		case (DatabaseAction)96:
		case DatabaseAction.SendRequestBuffer:
		case (DatabaseAction)99:
		case (DatabaseAction)100:
			PAIDOPMKBPC((IJEAJGCCHEF)(-23), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		case (DatabaseAction)93:
			PAIDOPMKBPC((IJEAJGCCHEF)(-144), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog(false);
			break;
		}
	}

	private static void BDHEDAENDDA()
	{
		GameLoginManager.Relog(false);
	}

	private static void EBGMHAGCFNB()
	{
		GameLoginManager.Relog(false);
	}

	[CompilerGenerated]
	private static void FOLNMOKGNDP()
	{
		Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
		Debug.Log("RETRY");
		GameLoginManager.Relog();
		LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
		Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
	}

	public static void LBLCJNOGPBL()
	{
		Singleton<GameController>.instance.TryStopLoading();
		Singleton<GameController>.instance.Quit();
		Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = true;
		WarningDialog.KHOMNBHMFGA(Localization.Localize("()I"), Localization.Localize("visuals: null"), 346f, delegate
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.Log("RETRY");
			GameLoginManager.Relog();
			LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
		}, Localization.Localize("ID_NA"), false, true);
	}

	private static void MGHBLNJMDHL()
	{
		GameLoginManager.Relog(false);
	}

	private static void BPPHEBADMAG()
	{
		GameLoginManager.Relog();
	}

	private static void DKFPBFFBKHP(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog(false);
	}

	private static void PCLPOLLPKGN()
	{
		GameLoginManager.Relog(false);
	}

	private static void IFICKJKELPN(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("ID_GUI_VIPMEMBERSHIP");
		GameLoginManager.Relog(false);
	}

	internal void EJMJIHBAPEL(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		DialogManager.instance.HideAllDialogs();
		switch (MHLAAHNPMFG)
		{
		case DatabaseAction.GetPlayerData:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		case DatabaseAction.GameStartedMaster:
		case DatabaseAction.GameStartedClient:
		case DatabaseAction.GameStartedCampaign:
		case DatabaseAction.GameStartedCoopMaster:
		case DatabaseAction.GameStartedCoopClient:
		case DatabaseAction.GameStartedTutorial:
			GOEHBPFDMLM(IJEAJGCCHEF.CouldNotStartGame, null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		case DatabaseAction.GameEnded:
			GOEHBPFDMLM(IJEAJGCCHEF.ServerRespondedWithError, null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		}
	}

	private static void ADLLJJNODMM()
	{
		GameLoginManager.Relog(false);
	}

	private static void JODMDEKOPJF()
	{
		GameLoginManager.Relog();
	}

	private static void BDIKIDFCDKO()
	{
		GameLoginManager.Relog(false);
	}

	private static void JFJBOAMMHGL()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void HOOFNHHPCFF(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog();
	}

	private static void CNKJBPNDDMN()
	{
		GameLoginManager.Relog();
	}

	private static void JGAPBBCIJDB()
	{
		GameLoginManager.Relog();
	}

	private static void PDCGGAMDGCA(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		GameLoginManager.Relog(false);
	}

	internal void GOEHBPFDMLM(IJEAJGCCHEF CDLPMHEODBN, Dictionary<string, object> EENKJBCCPBG, DatabaseAction IFGAGNBDKBE, List<Tuple<string, string>> GMDJHENPLHB)
	{
		JHOGFIPAAJH jHOGFIPAAJH = new JHOGFIPAAJH();
		jHOGFIPAAJH.IFGAGNBDKBE = IFGAGNBDKBE;
		DialogManager.instance.HideAllDialogs();
		if (CDLPMHEODBN != IJEAJGCCHEF.ServerMaintenance)
		{
			LoadingDialog.Hide();
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE == DatabaseAction.GameEnded && Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Playing && CDLPMHEODBN != IJEAJGCCHEF.ThroughputExceededException)
		{
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
			return;
		}
		if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.EnterArena)
		{
			if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.WarArenaEnded)
			{
				if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.BuyWarbucksRequest)
				{
					if (jHOGFIPAAJH.IFGAGNBDKBE == DatabaseAction.AddVideoFeed)
					{
						MHEHGPLIFHF.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
					}
				}
				else
				{
					MIFGKEHBPOK.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
				}
			}
			else
			{
				JOPIPCDHOLF.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
			}
		}
		else
		{
			DIENNAGJJOM.ACFGDEDKPAO(CDLPMHEODBN, EENKJBCCPBG);
		}
		PADJFKLJGHH pADJFKLJGHH = new PADJFKLJGHH();
		pADJFKLJGHH.AIHDNGDNDHH = jHOGFIPAAJH;
		switch (CDLPMHEODBN)
		{
		case IJEAJGCCHEF.ServerError:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.LogError("Server error during " + jHOGFIPAAJH.IFGAGNBDKBE);
			if (EENKJBCCPBG.ContainsKey("Reason"))
			{
				Debug.LogError("Reason: " + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Reason"], string.Empty));
			}
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
			WarningDialog.ShowError(Localization.Localize("ID_SERVER_ERROR_TEXT"), Localization.Localize("ID_SERVER_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, Localization.Localize("ID_RETRY"), true);
			break;
		case IJEAJGCCHEF.ServerMaintenance:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"));
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_MAINTENANCE_TEXT"), Localization.Localize("ID_WARNING_MAINTENANCE"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, Localization.Localize("ID_RETRY"), true);
			break;
		case IJEAJGCCHEF.SquadnameTaken:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.OfferNotFoundBM:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_BLACKMARKETDOESNTEXIST"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.CardNotFound:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDNOTFOUNDINCOLLECTION"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			if (EENKJBCCPBG.ContainsKey("DepositedCards"))
			{
				Dictionary<string, string> depositedCards3 = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DepositedCards"], string.Empty));
				GameLoginManager.instance.SetDepositedCards(depositedCards3);
			}
			CardCraftingManager.instance.SetWaitingForServerResponse(false);
			CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CardManagerData"], string.Empty));
			break;
		case IJEAJGCCHEF.AlreadyCrafting:
			Debug.LogError("Error: Player is already crafting -> loading craft data from server");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ALREADYCRAFTING"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CraftData"], string.Empty));
			break;
		case IJEAJGCCHEF.BuddyCardNotReady:
		{
			Debug.LogError("Error: Buddy card not ready! " + KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CardManagerData"], string.Empty));
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_BUDDYCARDNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			Dictionary<string, object> depositedCards2 = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DepositedCards"], string.Empty));
			GameLoginManager.instance.SetDepositedCards(depositedCards2);
			CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CardManagerData"], string.Empty));
			break;
		}
		case IJEAJGCCHEF.SquadWarProcessing:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_SQUADWARPROCESSING"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case IJEAJGCCHEF.CraftedCardNotReady:
			Debug.LogError("Error: Crafted card not ready!");
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CRAFTINGCLAIMNOTREADY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardCraftingManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CraftData"], string.Empty));
			break;
		case IJEAJGCCHEF.NotEnoughGoldForHeart:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHGOLDHEARTH"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["MyGolds"]);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num2);
			int num3 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["TicketsCount"]);
			Singleton<Wallet>.instance.InitTickets(num3);
			break;
		}
		case IJEAJGCCHEF.NotEnoughTicketsForHeart:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTICKETSHEARTH"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["MyTickets"]);
			Singleton<Wallet>.instance.InitTickets(num);
			break;
		}
		case IJEAJGCCHEF.CardAlreadyWithdrawn:
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_WARCARDNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_SELECTEDWARCARDWASALREADY"));
			Dictionary<string, object> depositedCards = JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["DepositedCards"], string.Empty));
			GameLoginManager.instance.SetDepositedCards(depositedCards);
			CardManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["CardManagerData"], string.Empty));
			break;
		}
		case IJEAJGCCHEF.WithdrawNotYetAvailable:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			CardManager.instance.nextWithdraw = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["NextWithdraw"]);
			break;
		case IJEAJGCCHEF.WrongWarArenaHeartPrice:
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGPRICEFORHEART"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			int num13 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ClientPrice"]);
			int num14 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["ServerPrice"]);
			bool flag = KHJJFPPACBP.FOJOKBCNBCO(EENKJBCCPBG["PayWithTickets"]);
			Debug.LogError(string.Format("Server price {0} != client price {1} ({2}) ", num14, num13, (!flag) ? "golds" : "tickets"));
			break;
		}
		case IJEAJGCCHEF.SquadAlreadyExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.CouldNotStartGame:
			Debug.Log("Error: Could not start game " + jHOGFIPAAJH.IFGAGNBDKBE);
			Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(false);
			break;
		case IJEAJGCCHEF.IncorrectAssignments:
			Debug.LogError("Error: Incorrect assignments " + jHOGFIPAAJH.IFGAGNBDKBE);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTASSIGNMENTS_TEXT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["AssignmentData"], string.Empty));
			break;
		case IJEAJGCCHEF.SquadIsNotPublic:
			LoadingDialog.Hide();
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC"), Localization.Localize("ID_CONFIRM_SQUADISNOTPUBLIC_TEXT"));
			break;
		case IJEAJGCCHEF.SquadJoinRequestNotExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADJOINREQUESTNOTEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			if (EENKJBCCPBG.ContainsKey("PlayerId"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(EENKJBCCPBG["PlayerId"].ToString(), true);
			}
			break;
		case IJEAJGCCHEF.PlayerAlreadyInSquad:
		{
			string text3 = ((!EENKJBCCPBG.ContainsKey("Name")) ? string.Empty : EENKJBCCPBG["Name"].ToString());
			WarningDialog.ShowError(Localization.Localize("ID_PLAYERCANTJOINSQUAD"), Localization.LocalizeFormat("ID_ISALREADYMEMBEROFANOTHERSQUAD", text3), 0f, null, string.Empty);
			if (EENKJBCCPBG.ContainsKey("PlayerId"))
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(EENKJBCCPBG["PlayerId"].ToString(), true);
			}
			break;
		}
		case IJEAJGCCHEF.PlayerAlreadyInSquadCantJoin:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			GameLoginManager.Relog();
			break;
		case IJEAJGCCHEF.NotEnoughSkill:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.NotForGuestAccount:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTFORQUESTACCOUNTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.GameCenterAlreadyCreated:
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			FHIPGDADNFG fHIPGDADNFG = FHIPGDADNFG.MAINIENLLIL((JToken)EENKJBCCPBG["PlayerData"]);
			pADJFKLJGHH.PIIIKJJHJPN = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["GameCenterId"], string.Empty);
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.GameCenter, pADJFKLJGHH.LJCDGJKCNEC, fHIPGDADNFG.NOCJHDCEHBE, fHIPGDADNFG.BCCDDJMPBLL, fHIPGDADNFG.CJDHKJFKNAH, string.Empty);
			break;
		}
		case IJEAJGCCHEF.NoOffers:
			Debug.Log("No Offer Available (has all already)");
			break;
		case IJEAJGCCHEF.SquadIsFull:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADISFULL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.SquadNoLongerExists:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTEXISTINGSQUAD"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.JoiningSameSquad:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_JOININGSAMESQUAD"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case IJEAJGCCHEF.SquadNotEmpty:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADNOTEMPTY"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.SquadLeaveError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SQUADLEAVEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.PlayerNameTaken:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERNAMETAKEN"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.PlayerAlreadyExists:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PLAYERALREADYEXISTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.PromotePlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
			break;
		case IJEAJGCCHEF.DemotePlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			BeanstalkServerManager.LoadSquadMembers(EENKJBCCPBG);
			break;
		case IJEAJGCCHEF.AccountAlreadyCreatedOnDifferentPlatform:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ACCOUNTALREADYCREATED"), Localization.Localize("ID_WARNING_LOGINERROR"), 0f, pADJFKLJGHH.EJLGBICBIFK, string.Empty);
			GameLoginManager.instance.LogoutFromFacebook(true);
			if (EENKJBCCPBG.ContainsKey("Os"))
			{
				Debug.LogError("Account is in platform: " + EENKJBCCPBG["Os"]);
			}
			break;
		case IJEAJGCCHEF.PromoteToFounderError:
		case IJEAJGCCHEF.KickPlayerError:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_PROMOTEDEMOTEERROR"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.OnlyLeaderCanSendInvites:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ONLYLEADERSCANINVITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.NoSuchPackExists:
		case IJEAJGCCHEF.InvalidInapp:
			LoadingDialog.Hide();
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOSUCHPACK"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.ServerDidntRespondBeforeGame:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_SERVERDIDNOTRESPOND"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			break;
		case IJEAJGCCHEF.GameAlreadyEnded:
		case IJEAJGCCHEF.GameDidntExist:
		case IJEAJGCCHEF.ServerDidntRespondAfterGame:
			Singleton<GameController>.instance.errorReason = CDLPMHEODBN;
			Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Error;
			break;
		case IJEAJGCCHEF.NotEnoughDogtags:
		case IJEAJGCCHEF.BattleAlreadyExists:
		case IJEAJGCCHEF.NoSkirmishAvailable:
			Debug.LogError("ERROR FROM SERVER " + CDLPMHEODBN);
			if (!Singleton<GameController>.instance.isInMenuOrWait)
			{
				break;
			}
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<GameController>.instance.TryStopLoading();
			Singleton<GameController>.instance.Quit();
			if (CDLPMHEODBN == IJEAJGCCHEF.NoSkirmishAvailable)
			{
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOSKIRMISHAVAILABLE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			else
			{
				WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_NOTENOUGHDOGTAGS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
			}
			break;
		case IJEAJGCCHEF.NotEnoughGoldForSkirmish:
		{
			int iDLMJLCFMJG2 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["SkirmishCost"]);
			PlayerAnalytics.instance.data.paidInstantBattles = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["PaidBattles"]);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(iDLMJLCFMJG2, Localization.Localize("ID_INSTANTBATTLE"));
			Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerGold"], 0L));
			break;
		}
		case IJEAJGCCHEF.NotEnoughGoldForDogtags:
		{
			int iDLMJLCFMJG = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["DogtagPrice"]);
			long aFOPDKIJGHL = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerGold"], 0L);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(iDLMJLCFMJG, Localization.Localize("ID_DOGTAGSREFILL"));
			Singleton<Wallet>.instance.GHPGMPNBJDB(aFOPDKIJGHL);
			break;
		}
		case IJEAJGCCHEF.NotEnoughGoldForChangeName:
		{
			int num11 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["RenameCount"]);
			long num12 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerGold"], 0L);
			Debug.LogError("ServerErrorHandler: renameCount = " + num11 + ", playerGold1 = " + num12);
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("ID_CHANGENAMENOTENOUGHT"));
			Singleton<Wallet>.instance.GHPGMPNBJDB(num12);
			break;
		}
		case IJEAJGCCHEF.NotEnoughWarBucksForCreateSquad:
		{
			int num9 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["squadCreationsCnt"]);
			long num10 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerWB"], 0L);
			Debug.LogError("ServerErrorHandler: squadCreationsCount = " + num9 + ", playerWB = " + num10);
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(PlayerAnalytics.instance.createSquadWarBucksPrice, Localization.Localize("ID_CREATESQUADNOTENOUGH"));
			Singleton<Wallet>.instance.PLLPIAOOFFE(num10);
			break;
		}
		case IJEAJGCCHEF.NotEnoughGoldForVip:
		{
			string text7 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["vipId"], string.Empty);
			int num7 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["VIPCost"]);
			long num8 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerGold"], 0L);
			Debug.LogError(string.Format("VIPCost = {0}, playerGold2 = {1}, id = {2}", num7, num8, text7));
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num7, Localization.Localize("ID_VIPSTATUS"));
			Singleton<PurchaseProtection>.instance.VIPResponseCame(text7);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num8);
			break;
		}
		case IJEAJGCCHEF.NotEnoughGoldForLootboxes:
		{
			string text6 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["lootboxId"], string.Empty);
			int num5 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["LootboxesCost"]);
			long num6 = KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["PlayerGold"], 0L);
			Debug.LogError(string.Format("lootboxesCost = {0}, playerGold = {1}, id= {2}", num5, num6, text6));
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num5, Localization.Localize("ID_LOOTBOXES"));
			Singleton<PurchaseProtection>.instance.LootboxResponseCame(text6);
			Singleton<Wallet>.instance.GHPGMPNBJDB(num6);
			break;
		}
		case IJEAJGCCHEF.NotEnoughLevelForPromote:
		{
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["playerLevel"], string.Empty);
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["requiredLevel"], string.Empty);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHTLEVEL"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
			break;
		}
		case IJEAJGCCHEF.NoRewardToClaim:
			WarningDialog.ShowError(Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD_TEXT"), Localization.Localize("ID_CONFIRM_ERRORCLAIMREWARD"), 0f, null, string.Empty);
			break;
		case IJEAJGCCHEF.NotLeaderOfSquad:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD"), Localization.Localize("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT"));
			break;
		case IJEAJGCCHEF.NotEnoughSquadLevel:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL"), Localization.Localize("ID_CONFIRM_NOTENOUGHTSQUADLEVEL_TEXT"));
			break;
		case IJEAJGCCHEF.NotEnoughWarbucksForSkip:
			Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.OOAIMCEBPOK(EENKJBCCPBG["WarBucks"], 0L));
			break;
		case IJEAJGCCHEF.WrongPlayerData:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Player was removed from db!");
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_WRONGPLAYERDATA"));
			break;
		case IJEAJGCCHEF.NoActiveEvent:
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_JOINSQUADEVENT"), Localization.Localize("ID_CONFIRM_NOTACTIVEEVENT"));
			break;
		case IJEAJGCCHEF.LoginFailure:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Delete QuickPlay Data");
				GameLoginManager.instance.DeletePlayerAccount();
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_LOGINFAILURE"), Localization.Localize("ID_CONFIRM_LOGINFAILURE_TEXT"));
			break;
		case IJEAJGCCHEF.AccountBanned:
		{
			string text = "null";
			string text2 = "null";
			if (EENKJBCCPBG.ContainsKey("accountId"))
			{
				text = EENKJBCCPBG["accountId"].ToString();
			}
			if (EENKJBCCPBG.ContainsKey("accountName"))
			{
				text2 = EENKJBCCPBG["accountName"].ToString();
			}
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			string empty = string.Empty;
			if (EENKJBCCPBG.ContainsKey("seconds"))
			{
				int num4 = KHJJFPPACBP.PELILBMKGHE(EENKJBCCPBG["seconds"]);
				empty = Localization.LocalizeFormat("ID_CONFIRM_TEMPORARBAN", text, text2, MEJMLNDFDBP.LEEEFPGPEOM(num4));
			}
			else
			{
				empty = Localization.LocalizeFormat("ID_CONFIRM_PERMANENTBAN", text, text2);
			}
			WarningDialog.ShowError(empty, Localization.Localize("ID_CONFIRM_ACCOUNTBANNED"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, Localization.Localize("ID_RETRY"), true, EENKJBCCPBG.ContainsKey("canSendLogs"));
			break;
		}
		case IJEAJGCCHEF.InvalidToken:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				if (EENKJBCCPBG.ContainsKey("Token"))
				{
					Debug.LogError("Beanstalk: Invalid Token - " + EENKJBCCPBG["Token"]);
				}
				else
				{
					Debug.LogError("Beanstlak: Invalid Token -> unknown");
				}
				ConfirmDialog.ShowAlert(delegate
				{
					GameLoginManager.Relog();
				}, Localization.Localize("ID_CONFIRM_LOGGEDOUT"), Localization.Localize("ID_CONFIRM_LOGGEDOUT_TEXT"));
			}
			break;
		case IJEAJGCCHEF.OldToken:
		case IJEAJGCCHEF.UnAuthorizedAction:
			if (Singleton<GameController>.instance.isInMenuOrWait)
			{
				Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
				Debug.LogError("Beanstalk: OLD TOKEN!!");
				Singleton<GameController>.instance.TryStopLoading();
				Singleton<GameController>.instance.Quit();
				Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
				GameLoginManager.Relog();
			}
			break;
		case IJEAJGCCHEF.OldClientVersion:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = true;
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<NewVersionDialog>.instance);
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
			break;
		case IJEAJGCCHEF.PlayerNotExists:
			Singleton<BeanstalkServerManager>.instance.UserLoggedOut();
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			ConfirmDialog.ShowAlert(delegate
			{
				Debug.Log("Player was removed from db!");
				GameLoginManager.instance.DeletePlayerAccount();
				GameLoginManager.Relog();
			}, Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS"), Localization.Localize("ID_CONFIRM_PLAYERNOTEXISTS_TEXT"));
			break;
		case IJEAJGCCHEF.RewardWasAlreadyAdded:
			PlayerAnalytics.instance.AddOneTimeReward(KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["RewardId"], string.Empty));
			Debug.LogError("Reward Was Already Added!!");
			break;
		case IJEAJGCCHEF.NoDiscountFound:
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
			if (EENKJBCCPBG.ContainsKey("SpecialOffers"))
			{
				Singleton<OfferManager>.instance.UpdateFromServer((JToken)EENKJBCCPBG["SpecialOffers"]);
			}
			else
			{
				Singleton<OfferManager>.instance.UpdateFromServer(null);
			}
			if (EENKJBCCPBG.ContainsKey("Id"))
			{
				string iNFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK(EENKJBCCPBG["Id"], string.Empty);
				if (jHOGFIPAAJH.IFGAGNBDKBE != DatabaseAction.BuyLootboxes)
				{
					if (jHOGFIPAAJH.IFGAGNBDKBE == DatabaseAction.BuyVip)
					{
						Singleton<PurchaseProtection>.instance.VIPResponseCame(iNFLHPGMEOB);
					}
				}
				else
				{
					Singleton<PurchaseProtection>.instance.LootboxResponseCame(iNFLHPGMEOB);
				}
			}
			Debug.LogError("NO DISCOUNT FOUND!!! " + jHOGFIPAAJH.IFGAGNBDKBE);
			break;
		}
	}

	private static void GJAENDJLJJF()
	{
		GameLoginManager.Relog();
	}

	private static void PGKFNDCFHJC()
	{
		GameLoginManager.Relog(false);
	}

	public static void BKEEBIDAAOG()
	{
		Singleton<GameController>.instance.TryStopLoading();
		Singleton<GameController>.instance.Quit();
		Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = true;
		WarningDialog.ShowError(Localization.Localize("XP"), Localization.Localize("Army_Unit_ID"), 174f, delegate
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.Log("RETRY");
			GameLoginManager.Relog();
			LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
		}, Localization.Localize("Overtime_Was_Already_Explained"), false, true);
	}

	[CompilerGenerated]
	private static void EMJMNCPAIEF()
	{
		GameLoginManager.Relog();
	}

	[CompilerGenerated]
	private static void DILEBOMIJOP(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Player was removed from db!");
		GameLoginManager.instance.DeletePlayerAccount();
		GameLoginManager.Relog();
	}

	private static void JAIPDGFDJCB(ConfirmDialog JAGBOPMGIAA, bool NCMHGPNPEJM)
	{
		Debug.Log("Tier");
		GameLoginManager.Relog(false);
	}

	private static void NOJEHNEBDNM()
	{
		GameLoginManager.Relog();
	}

	public static void IJFOFLNOHFM()
	{
		Singleton<GameController>.instance.TryStopLoading();
		Singleton<GameController>.instance.Quit();
		Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = true;
		WarningDialog.ShowError(Localization.Localize("ID_WARNING_CONNECTIONERROR_TEXT"), Localization.Localize("ID_WARNING_CONNECTIONERROR"), 0f, delegate
		{
			Singleton<BeanstalkServerManager>.instance.CancelAllRequests();
			Debug.Log("RETRY");
			GameLoginManager.Relog();
			LoadingDialog.ShowLoading(Localization.Localize("ID_CONNECTING"));
			Singleton<BeanstalkServerManager>.instance.DHFLFIEBDAF = false;
		}, Localization.Localize("ID_RETRY"), true);
	}

	public static string EBAPAPNOKFD()
	{
		return "PACK";
	}

	internal void OALEBDMKKFL(Exception KIJELCLONNC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		DialogManager.instance.HideAllDialogs();
		switch (MHLAAHNPMFG)
		{
		case DatabaseAction.EquipDecal:
			Singleton<BeanstalkServerManager>.instance.BPDHHBFKHJP();
			GameLoginManager.Relog();
			break;
		case (DatabaseAction)(-37):
		case (DatabaseAction)(-28):
		case (DatabaseAction)(-27):
		case (DatabaseAction)(-25):
		case (DatabaseAction)(-24):
		case (DatabaseAction)(-23):
			PAIDOPMKBPC((IJEAJGCCHEF)(-137), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		case (DatabaseAction)(-30):
			PAIDOPMKBPC((IJEAJGCCHEF)(-156), null, MHLAAHNPMFG, GMDJHENPLHB);
			break;
		default:
			Singleton<BeanstalkServerManager>.instance.BKPEOBBLCNG();
			GameLoginManager.Relog(false);
			break;
		}
	}

	private static void PCOGGANGLFK()
	{
		GameLoginManager.Relog(false);
	}

	private static void PDGHLCNELAL()
	{
		GameLoginManager.Relog();
	}

	public static string KOMJCLFNFIC()
	{
		return "21haWwuY29tMB4XDTE1MDIyNDE1MDI0MFoXDTE3MTEyMTE1MDI0MFowgaExCzAJBgNVBAYTAkNaMQ8wDQYDVQQIDAZQcmFndWUxDzANBgNVBAcMBlByYWd1ZTESMBAGA1UECgwJQWJvdXQgRnVuMQswCQYDVQQLDAJJVDErMCkGA1UEAwwid2FyZnJpZW5kcy1ldS5lbGFzdGljYmVhbnN0YWxrLmNvbTEiMCAGCSqGSIb3DQEJARYTdm9qdGFzaXZyQGdtYWlsLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoCggEBALOLAdUTdkvp5QjE0h0/EXuHUzDjgTk1L9B6Qe/qTgh3sDcEmOacC7vZoyhLzSMTucVYGnTda8wRZP2Qh5UE3SmKXhA5axywLJbI0AeL5VeJsquIQMJ3dy8FNNGiILMqfSnYGfF/ND6xDIKfBq9oZFolOjeYxujhU2Enk08H4gak8cWJNpxzTmUBrHIzQhPabw8hNOA5SwB2xe0jaZQErIJu6A/LgnoStRcddvGfZzCHxkVmEWte6QR00KtZ0lm4p/BR2N8qVYb/LKBLMMflTEa+4HJ508OT6IibgcmDniXON1Rwt608VAZHcGQ71twMx8HlUbHpNtYmLABGHoI3NY0CAwEAATANBgkqhkiG9w0BAQUFAAOCAQEAADNahERiLW4qa8vK1C7Wljax86yb8KX5+gX6DmS5XTkrz736MiF6Wo2ttV4hgw1HzGNitwDZl/3YGIxxQhI6Dpg+ChuHKZsaoCGOPBTSCrw02MGnASLMw9laTUPdip5oHT9PAef8JsuGjJ4t5yBcpzE1FD/Hd6c4BnCNfIiMKLeNoVishmUU/UIv+9RekCJ0gQUzCovyksIy5VVM9q9/tDfmKpONaxnnBDzaLPIA7DE2ZFPEBRGJMno6Zo2JfN/fyl2xj7LWVCzLwr8S3nHa4L6XHtu29LUSzcSrVhUb+31bDdq48ZItbj2w+uK5n2Wgnv/sRkyrxCBC3j0qIz2kTQ==-----END CERTIFICATE-----";
	}
}
